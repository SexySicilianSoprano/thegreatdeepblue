using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayerSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.layer == 0){
			SetLayer();
		}
	}
	
	[Client]
	void SetLayer(){
		
		if(GetComponent<NetworkIdentity>().isServer && GetComponent<NetworkIdentity>().isLocalPlayer){
			this.gameObject.layer = 8;
		} else {
			this.gameObject.layer = 9;
		}
	}
	
}
