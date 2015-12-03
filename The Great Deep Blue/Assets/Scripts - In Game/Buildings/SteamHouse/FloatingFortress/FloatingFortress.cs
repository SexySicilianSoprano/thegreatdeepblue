using UnityEngine;
using System.Collections;

public class FloatingFortress : Building {

	// Use this for initialization
	new void Start () 
	{
		//Assign all the details
		AssignDetails (ItemDB.FloatingFortress);
		
		//Tell the base class to start as well, must be done after AssignDetails
		base.Start();
		
		//Tell Idle animation to play
		//GetComponent<Animation>().Play ("idle");
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
