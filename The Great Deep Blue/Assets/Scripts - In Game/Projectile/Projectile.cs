using UnityEngine;
using System.Collections;

public class Projectile
{
    // Projectile Identification
    public int ID;
    public string Name;
    public GameObject Prefab;

    // Assign details
    public void AssignDetails(Projectile projectile)
    {
        ID = projectile.ID;
        Name = projectile.Name;
        Prefab = projectile.Prefab;
    }
}