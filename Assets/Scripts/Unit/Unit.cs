using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public float health;
    public float armor;
    public float damage;
    public float speed;

    // Use this for initialization
    void Start() {
        Rigidbody rg = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update() {

    }
    
}
