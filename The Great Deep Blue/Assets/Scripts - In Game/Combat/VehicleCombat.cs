﻿using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(RTSObject))]
public class VehicleCombat : Combat {

    // ##### Private variables #####
    private bool TargetSet = false;
    private bool canFire = true;
    private bool m_FollowEnemy = false;
    private bool m_FireAtEnemy = false;

    private float m_FireRate;

    private Vector3 CurrentPos;
    private Vector3 TargetPos;
    /* 
    private Transform Spawner;
    private Vector3 SpawnerPos;
    */

    
    
    // Use this for initialization
    void Start()
    {
        SwitchMode(CombatMode.Defensive);
        m_Parent = GetComponent<RTSObject>();
        //Spawner = m_Parent.transform.GetChild(0);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        // Update positions
        SpawnerPos = Spawner.transform.position;
        CurrentPos = CurrentLocation;

        Debug.DrawRay(SpawnerPos, Spawner.forward, Color.green);

        if (TargetSet && canFire == true)
        {
            if (TargetInLine())
            {
                TargetPos = TargetLocation;
                Attack(m_Target);
            }
            else
            {
                RotateTurret();
            }
            
        }

    } */

    void Update()
    {
        // Update positions
        //SpawnerPos = Spawner.transform.position;
        CurrentPos = CurrentLocation;
        CalculateFireRate();

        if (TargetSet && canFire == true)
        {
            TargetPos = TargetLocation;
            Attack(m_Target);
        }        
        else if (TargetSet == false || m_Target == null)
        {
            Stop();
        }

        if (m_Parent.AttackingEnemy)
        {
            m_Target = m_Parent.AttackingEnemy;
            if (m_FireAtEnemy == true && m_FollowEnemy == true)
            {
                Attack(m_Target);
            }
            else if (m_FireAtEnemy == true && m_FollowEnemy == false)
            {
                Attack(m_Target);
            }
            else if (m_FireAtEnemy == false && m_FollowEnemy == false)
            {

            }
            else
            {
                Debug.LogError("Something went wrong with stances");
            }
        }
    }

    // ##### Assign Details #####
    public override Vector3 CurrentLocation
    {
        get
        {
            return m_Parent.transform.position;
        }
    }

    public override Vector3 TargetLocation
    {
        get
        {
            return m_Target.transform.position;
        }
    }
    
    public override void AssignDetails(Weapon weapon)
    {
        Damage = weapon.Damage;
        Range = weapon.Range;
        FireRate = weapon.FireRate;
        isAntiArmor = weapon.isAntiArmor;
        isAntiStructure = weapon.isAntiStructure;
        Projectile = weapon.Projectile;
    }

    /*
    // ##### Functions #####
    public override void Attack(RTSObject obj)
    {
        m_Target = obj;
        TargetSet = true;
        if (m_Target)
        {
            // Is target in line with the turret?
            if (TargetInLine())
            {                
                // Is the target within maximum range?
                if (TargetInRange())
                {
                    // Target is within range
                    Debug.Log("Target in range!");
                    // Start firing
                    Debug.DrawLine(SpawnerPos, TargetPos);
                    //LaunchProjectile(Projectile);
                    m_Target.TakeDamage(Damage);
                    canFire = false;
                    StartCoroutine(WaitAndFire());

                    if (m_Target == null)
                    {
                        Stop();
                    }
                }
                else
                {
                    // Target not in range
                    // Move to range
                    Debug.Log("Target not in range!");
                }
            }
            else
            {
                RotateTurret();
            }
        }
        else
        {
            Stop();
        }
    } 
    */

    public override void Attack(RTSObject obj)
    {
        m_Target = obj;
        TargetSet = true;
        if (m_Target)
        {
            if (canFire)
            {
                // Is the target within maximum range?
                if (TargetInRange())
                {
                    Fire();

                    if (m_Target == null)
                    {
                        Stop();
                    }
                }
                else
                {
                    Follow();
                }
            }
            else
            {
                WaitAndFire();
            }            
        }
        else
        {
            Stop();
        }
    }

    private void Fire()
    {
        // Start firing
        Debug.DrawLine(CurrentPos, TargetPos);
        //LaunchProjectile(Projectile);
        m_Target.TakeDamage(Damage);
        m_Target.AttackingEnemy = m_Parent;
        canFire = false;
        StartCoroutine(WaitAndFire());
    }

    public override void Stop()
    {
        // Set no target and target to null
        TargetSet = false;
        m_Target = null;
        m_Parent.AttackingEnemy = null;
    }

    public void Follow() {
        // Follow target until in range
        GetComponent<Movement>().Follow(m_Target.transform);

        if (TargetInRange()) {
            GetComponent<Movement>().Stop();
        }
    }

    /*
    private void LaunchProjectile(Projectile projectile)
    {
        float ProjectileSpeed = 100;
        Vector3 Direction = SpawnerPos + TargetPos;

        GameObject NewProjectile = Instantiate(projectile.Prefab, SpawnerPos, Spawner.rotation) as GameObject;

        NewProjectile.GetComponent<Rigidbody>().AddForce(Direction * ProjectileSpeed);   
    }

    private bool TargetInLine()
    {
        //Vector3 Forward = Spawner.transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(Spawner.position, TargetPos, Mathf.Infinity))
        {
            Debug.Log("Target in line!");
            return true;
        }
        else
        {
            Debug.Log("Target not in line");
            return false;
        }
    }

    // Rotates the turrent towards target
    private void RotateTurret() {
        Vector3 targetDir = TargetPos - SpawnerPos;
        float turnSpeed = 1 * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(Spawner.transform.forward, targetDir, turnSpeed, 0.0F);
        Debug.DrawRay(Spawner.transform.position, newDir, Color.red);
        Spawner.transform.rotation = Quaternion.LookRotation(newDir);
    } */

    private void CalculateFireRate() {
        // Calculates rate of fire with 60 divided by shots per minute
        m_FireRate = 60 / FireRate;
    }
    
    private bool TargetInRange()
    { 
        TargetPos = TargetLocation;
        float dist = Vector3.Distance(CurrentPos, TargetPos);

        if (dist <= Range)
        {            
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SwitchMode(CombatMode mode)
    {
        switch (mode)
        {
            case CombatMode.Passive:
                break;

            case CombatMode.Aggressive:
                break;

            case CombatMode.Defensive:
                m_FollowEnemy = false;
                m_FireAtEnemy = true;
                break;

        }
    }

    IEnumerator WaitAndFire()
    {
        yield return new WaitForSeconds(m_FireRate);
        canFire = true;
    }

    public enum CombatMode {
        Passive,
        Aggressive,
        Defensive
    } 
  
}
