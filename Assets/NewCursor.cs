using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewCursor : MonoBehaviour {

	public RawImage cursor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Input.mousePosition;
	}
}
