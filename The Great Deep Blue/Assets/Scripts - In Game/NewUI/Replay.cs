using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Quite()
    {
        Application.Quit();
    }
	
	public void ReplayLevel(string scenenNimi){
		SceneManager.LoadScene(scenenNimi);
	}
}
