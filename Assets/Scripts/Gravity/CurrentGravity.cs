using UnityEngine;
using System.Collections;

    /* 
        TO DO
        - Continuing force, no cut-offs between objects
        - Smarter way to create streams on board
        - Smarter way to optimize streams
        - 
    
    */

public class CurrentGravity : MonoBehaviour {
    
    public float yAxis = 0;
    public float xAxis = 0;
    public float zAxis = 0;    
    public float velocity = 0; // the speed

	void OnTriggerStay (Collider other) {
		// Move colliding rigidbodies to a direction in set velocity
		other.GetComponent<Rigidbody>().AddForce(xAxis * velocity, yAxis * velocity, zAxis * velocity);
	}

}
