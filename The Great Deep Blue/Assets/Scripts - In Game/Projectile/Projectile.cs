using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

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
    /*
    public void OnCollisionEnter(Collision other) {

        // If projectile collides with player 2
        if (other.gameObject.tag == "Player2")
        {
            // Destroy the projectile
            Destroy(this);
        }
        else
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), GetComponent<Collider>());            
        }
    }
    */
}