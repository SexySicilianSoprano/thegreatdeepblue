using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WeaponDB {

    private static List<Weapon> AllWeapons = new List<Weapon>();

    public static Weapon TestCannon = new Weapon {
        ID = 0,
        Name = "TestCannon",
        Damage = 100,
        Range = 500,
        FireRate = 0.5f,
        isRanged = true,
        isAntiArmor = true,
        isAntiStructure = false            
    };

    public static Weapon TestMachineGun = new Weapon
    {
        ID = 0,
        Name = "TestCannon",
        Damage = 10,
        Range = 300,
        FireRate = 10,
        isRanged = true,
        isAntiArmor = true,
        isAntiStructure = false
    };

    public static void Initialise() {
        InitialiseWeapon(TestCannon);
    }

    private static void InitialiseWeapon(Weapon weapon)
    {        
        AllWeapons.Add(weapon);
    }

}
