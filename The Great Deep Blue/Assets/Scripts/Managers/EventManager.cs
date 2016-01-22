using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class EventManager : MonoBehaviour {

    //Singleton
    public static EventManager main;

    //Events
    public Event MouseEvent;
    public Event KeyBoardEvent;

    void Awake()
    {
        main = this;

        //Doubleclick-check
    }
    	
	// Update is called once per frame
	void Update () {
        //Checks for inputs	
	}



}
