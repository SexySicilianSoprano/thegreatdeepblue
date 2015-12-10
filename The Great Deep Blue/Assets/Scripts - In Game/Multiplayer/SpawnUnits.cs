using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpawnUnits : NetworkBehaviour {
	
	public GameObject[] units;
	public Transform spawnpoint;
	
	void Start(){
		spawnpoint = this.gameObject.GetComponent<UnitSpawner>().transform;
		Debug.Log ("Hello! I am " + this.gameObject.tag);
	}
	
	public void SpawnRequest(){
		CmdSpawnUnit();
		Debug.Log ("Hello! I " + this.gameObject.tag + " have had a request to spawn a unit!");
	}
	
	public override void OnStartLocalPlayer ()
	{
		base.OnStartLocalPlayer();
	}
	
	[Command]
	public void CmdSpawnUnit() {
		RpcLog();
	}
	
	[ClientRpc]
	public void RpcLog() {		
			GameObject newUnit = Instantiate (units[0], spawnpoint.position, Quaternion.identity) as GameObject;
			NetworkServer.SpawnWithClientAuthority(newUnit, this.connectionToClient);	
			Debug.Log ("Hello! I " + this.gameObject.tag + " have spawned a unit!");		
	}
	
	
}
