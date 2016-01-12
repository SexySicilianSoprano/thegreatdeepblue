using UnityEngine;
using System.Collections;

public abstract class Combat : MonoBehaviour, IAttackable {

    protected RTSObject m_Parent;
    protected RTSObject m_Target;

    public Projectile Projectile;

    public float Damage;
    public float Range;
    public float FireRate;
    public float TurretSpeed;

    public bool isRanged;
    public bool isAntiArmor;
    public bool isAntiStructure;

    public abstract Vector3 CurrentLocation { get; }
    
    public abstract Vector3 TargetLocation { get; }

    public abstract void AssignDetails(Weapon weapon);

    public abstract void Attack(RTSObject obj);

    public abstract void Stop();

}
