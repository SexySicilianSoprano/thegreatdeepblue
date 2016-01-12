using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour {

	public GameObject Info;
	public Button Btn;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Input.mousePosition;
	}

	void MousePosition () {
		if  (Input.mousePosition == Btn.transform.position ) {
			Info.SetActive(true);
		}
		else {
			Info.SetActive(false);
		}
	}
}
