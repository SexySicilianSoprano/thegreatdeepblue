using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    

    public GameObject victoryPanel;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameObject.Find("FloatingFortressEnemy"))
        {
            victoryPanel.SetActive(true);
        } 
	}
}
