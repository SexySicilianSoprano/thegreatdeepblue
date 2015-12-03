using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckShit : MonoBehaviour {

    private GameObject[] gameobjects;
    // Use this for initialization
    void Start ()
    {
        gameobjects = GameObject.FindGameObjectsWithTag("Player1");

        foreach (GameObject GO in gameobjects)
        {
            if (GO.GetComponent<MeshRenderer>().material)
            {
                if (GO.GetComponent<MeshRenderer>().material.shader.name == "Lines/Colored Blender")
                {
                    Debug.Log(GO.name);
                }
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
