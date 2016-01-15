using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Initialise();     
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void Initialise()
    {
        ItemDB.Initialise();
    }
}
