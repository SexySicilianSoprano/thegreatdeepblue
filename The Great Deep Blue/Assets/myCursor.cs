using UnityEngine;
using System.Collections;

public class myCursor : MonoBehaviour {

	static myCursor instance = null;
	
	void Start(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
