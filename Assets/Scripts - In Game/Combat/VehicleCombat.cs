using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(RTSObject))]
public class VehicleCombat : Combat {

    private VehicleMovement movement = new VehicleMovement();
    private bool TargetSet = false;
    private bool canFire = true;

    private Vector3 CurrentPos;
    private Vector3 TargetPos;

    // Use this for initialization
    void Start()
    {
        m_Parent = GetComponent<RTSObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update 
        CurrentPos = CurrentLocation;
        
        if (TargetSet && canFire == true) {
            //float translation = Time.deltaTime * FireRate;

            Attack(m_Target);
            canFire = false;
            StartCoroutine(WaitAndFire());
        }
    }

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

    // Assign Details
    public override void AssignDetails(Weapon weapon)
    {
        Damage = weapon.Damage;
        Range = weapon.Range;
        FireRate = weapon.FireRate;
        isRanged = weapon.isRanged;
        isAntiArmor = weapon.isAntiArmor;
        isAntiStructure = weapon.isAntiStructure;
    }

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
                Debug.DrawLine(CurrentLocation, TargetLocation);
                m_Target.TakeDamage(Damage);


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
        TargetSet = false;
        m_Target = null;
    }

    private bool TargetInRange() {

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
        yield return new WaitForSeconds(2);
        canFire = true;
    }

}
