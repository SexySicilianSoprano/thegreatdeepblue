using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkSpawning : NetworkBehaviour {


	public override void OnStartLocalPlayer ()
	{
		base.OnStartLocalPlayer();
	}
	
	public void SpawnRequest(){
		CmdCall();
	}
	
	[Command]
	public void CmdCall() {
		RpcLog();
	}
	
	[ClientRpc]
	public void RpcLog() {
		if (this.isServer) {
			GameObject.FindWithTag("Player1NavalYard").gameObject.GetComponent<SpawnUnits>().SpawnRequest();
			Debug.Log ("Hello! Button pressed " + this.gameObject);
		} else {
			GameObject.FindWithTag("Player2NavalYard").gameObject.GetComponent<SpawnUnits>().SpawnRequest();
			Debug.Log ("Hello! Button pressed " + this.gameObject);
		}
		
	}
}
