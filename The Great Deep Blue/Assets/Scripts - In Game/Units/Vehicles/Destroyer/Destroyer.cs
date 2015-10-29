using UnityEngine;
using System.Collections;

public class Destroyer : Vehicle {

	// Use this for initialization
	protected new void Start () 
	{
		//Assign variables for health/movement and so on..
		AssignDetails (ItemDB.DestroyerShip);
		GetComponent<Movement>().AssignDetails (ItemDB.DestroyerShip);        
        		
		//Call base class start
		base.Start ();
	}
	
	// Update is called once per frame
	protected new void Update () 
	{
		base.Update ();
	}
}