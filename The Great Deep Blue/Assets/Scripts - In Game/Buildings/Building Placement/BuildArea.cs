﻿using UnityEngine;
using System.Collections;

public class BuildArea : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other) {
        
        if (!other.GetComponent<BuildingBeingPlaced>())
        {
           // Physics.IgnoreCollision(GetComponent<SphereCollider>(), other);
        }
    }
}