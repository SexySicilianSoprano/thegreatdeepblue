using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(RTSObject))]
public class VehicleCombat : Combat {

    // ##### Private variables #####
    private bool TargetSet = false;
    private bool canFire = true;

    private float m_FireRate;

    private Vector3 CurrentPos;
    private Vector3 TargetPos;

    private Transform Spawner;
    private Vector3 SpawnerPos;

    // Use this for initialization
    void Start()
    {
        m_Parent = GetComponent<RTSObject>();
        CalculateFireRate();
        Spawner = m_Parent.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Update positions
        SpawnerPos = Spawner.transform.position;
        CurrentPos = CurrentLocation;

        if (TargetSet && canFire == true)
        {
            TargetPos = TargetLocation;
            Attack(m_Target);
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

    // ##### Functions #####
    public override void Attack(RTSObject obj)
    {
        m_Target = obj;
        TargetSet = true;
        if (m_Target)
        {
            if (TargetInRange())
            {
                // Target is within range
                Debug.Log("Target in range!");
                // Start firing
                Debug.DrawLine(CurrentPos, TargetPos);
                LaunchProjectile(Projectile);
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
            Stop();
        }
    }

    public override void Stop()
    {
        // Set no target and target to null
        TargetSet = false;
        m_Target = null;
    }

    private void LaunchProjectile(Projectile projectile)
    {

        //float dist = Vector3.Distance(CurrentPos, TargetPos);
        float ProjectileSpeed = 100;
        float startTime = Time.time;
        float dist = Vector3.Distance(SpawnerPos, TargetPos);

        float distCovered = (Time.time - startTime) * ProjectileSpeed;
        float fracJourney = distCovered / dist;

        GameObject NewProjectile = Instantiate(projectile.Prefab, SpawnerPos, Spawner.rotation) as GameObject;

        NewProjectile.transform.position = Vector3.Lerp(SpawnerPos, TargetPos, fracJourney);
                
    }


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

    IEnumerator WaitAndFire()
    {
        yield return new WaitForSeconds(m_FireRate);
        canFire = true;
    }

  
}
