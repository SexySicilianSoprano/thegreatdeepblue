using UnityEngine;
using System.Collections;

public class CurrentGravity : MonoBehaviour {
    
    public float yAxis = 0;
    public float xAxis = 0;
    public float zAxis = 0;    
    public float velocity = 0; // the speed

	void OnTriggerStay (Collider other) {
		// Move colliding rigidbodies to a direction in set velocity

			other.GetComponent<Rigidbody> ().AddForce (xAxis * (velocity / 100), yAxis * (velocity / 100), zAxis * (velocity / 100));
	}

}
