using UnityEngine;
using System.Collections;

public class NavalYard : Building {

	// Use this for initialization
	new void Start () 
	{
		AssignDetails (ItemDB.NavalYard);
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
