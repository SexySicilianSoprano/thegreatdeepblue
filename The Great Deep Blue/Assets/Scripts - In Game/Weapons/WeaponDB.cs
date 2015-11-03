using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WeaponDB {

    private static List<Weapon> AllWeapons = new List<Weapon>();

    public static Weapon TestCannon = new Weapon
    {
        ID = 0,
        Name = "TestCannon",
        Damage = 10,
        Range = 500,
        FireRate = 30,
        isAntiArmor = true,
        isAntiStructure = false,
        Prefab = Resources.Load("Resources/Projectiles/CannonBall", typeof(GameObject)) as GameObject
    };

    public static Weapon TestMachineGun = new Weapon
    {
        ID = 0,
        Name = "TestMachinegun",
        Damage = 10,
        Range = 300,
        FireRate = 120,
        isAntiArmor = true,
        isAntiStructure = false,
        Prefab = Resources.Load("Resources/Projectiles/CannonBall", typeof(GameObject)) as GameObject
    };

    public static void Initialise()
    {
        InitialiseWeapon(TestCannon);
    }

    private static void InitialiseWeapon(Weapon weapon)
    {
        AllWeapons.Add(weapon);
    }

}
