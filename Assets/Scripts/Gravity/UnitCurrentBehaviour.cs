using UnityEngine;
using System.Collections;

public class UnitCurrentBehaviour : MonoBehaviour {

    public bool IsInCurrent;
    public Rigidbody UnitRb = new Rigidbody();
    public Vector3 Course = new Vector3();

	// Use this for initialization
	void Start () {
        UnitRb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        

    }

}
