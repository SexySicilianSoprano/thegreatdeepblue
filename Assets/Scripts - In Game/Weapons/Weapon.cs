using UnityEngine;
using System.Collections;

public class Weapon {

    // Insert weapon parameters

    // Weapon Identification
    public int ID;
    public string Name;

    // Weapon type
    public bool isRanged;
    public bool isAntiArmor;
    public bool isAntiStructure;

    // Weapon stats
    public float Damage;
    public float Range;
    public float FireRate;

    // Projectile and animation
    // ..TO DO
    
    // Constructors
    /*
    public Weapon() {

    }
    */

    public void AssignDetails (Weapon Weapon)
    {
        ID = Weapon.ID;
        Name = Weapon.Name;
        Damage = Weapon.Damage;
        Range = Weapon.Range;
        FireRate = Weapon.FireRate;
        isRanged = Weapon.isRanged;
        isAntiArmor = Weapon.isAntiArmor;
        isAntiStructure = Weapon.isAntiStructure;
    }

}
