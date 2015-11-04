using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ProjectileDB {

    private static List<Projectile> AllProjectiles = new List<Projectile>();

    public static Projectile CannonBall = new Projectile
    {
        ID = 0,
        Name = "CannonBall",
        Prefab = Resources.Load("Projectiles/CannonBall", typeof (GameObject)) as GameObject
    };

    public static void Initialise() {
        InitialiseProjectile(CannonBall);
    }

    private static void InitialiseProjectile(Projectile projectile) {
        AllProjectiles.Add(projectile);
    }
}
