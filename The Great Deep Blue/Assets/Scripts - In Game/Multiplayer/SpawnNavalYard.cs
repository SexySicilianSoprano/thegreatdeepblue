using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SpawnNavalYard : NetworkBehaviour {

	public GameObject navalYardGameObject;
	
	public override void OnStartLocalPlayer ()
	{
		base.OnStartLocalPlayer();
		CmdSpawnNavalYard();
	}
	
	[Command]
	public void CmdSpawnNavalYard() {
		RpcLog();
	}
	
	[ClientRpc]
	public void RpcLog() {		
		GameObject newNavalYard = Instantiate (navalYardGameObject, new Vector3(this.gameObject.transform.position.x + 20, this.gameObject.transform.position.y + 20, this.gameObject.transform.position.z + 20), Quaternion.identity) as GameObject;		
		NetworkServer.SpawnWithClientAuthority(newNavalYard, this.connectionToClient);
		
	}
	
}
