using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Spawner : NetworkBehaviour {
	public GameObject[] spawnPrefab;
	[SerializeField]
	public NetworkConnection owner;

	public override void OnStartLocalPlayer() {
		base.OnStartLocalPlayer();

		NetworkIdentity identity = this.GetComponent<NetworkIdentity>();
		if (this.isServer) {
			this.owner = identity.connectionToClient;
		}
		else {
			this.owner = identity.connectionToServer;
		}

		//On initialization, make the client (local client and remote clients) tell the server to call on an [ClientRpc] method.
		//CmdCall(spawnUnit);
		
		//Muuta tämä myöhemmin johonkin toiseen scriptiin!
		GameObject.Find("Main Camera").GetComponent<MyCamera>().thePlayer = this.gameObject;
	}

	[Command]
	public void CmdCall(int spawnUnit) {
		//Calling [ClientRpc] on the server.
		RpcLog(spawnUnit);
	}

	[ClientRpc]
	public void RpcLog(int spawnUnit) {
		//First, checks to see what type of recipient is receiving this message. If it's server, the output message should tell the user what the type is.
		Debug.Log("RPC: This is " + (this.isServer ? " Server" : " Client"));

		//Second, initialize everything that is common for both server and client. 

		Debug.Log(this.connectionToServer);

		//Finally, initialize server only stuff or client only stuff.
		//Also, finally found a use-case for [Server] / [ServerCallback]. Simplifies things a bit.
		ServerInitialize(spawnUnit);
	}

	[ServerCallback]
	public void ServerInitialize(int spawnUnit) {
		//Server code
		//This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
		//NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.

		//Player unit
		GameObject obj = MonoBehaviour.Instantiate(this.spawnPrefab[spawnUnit], new Vector3(this.gameObject.transform.position.x + 20, 0, this.gameObject.transform.position.z + 20), Quaternion.identity) as GameObject;
		NetworkIdentity objIdentity = obj.GetComponent<NetworkIdentity>();
		NetworkServer.SpawnWithClientAuthority(obj, this.connectionToClient);

		//Player selection manager
		/*GameObject manager = MonoBehaviour.Instantiate(this.selectionManagerPrefab) as GameObject;
		SelectionManager selectionManager = manager.GetComponent<SelectionManager>();
		if (selectionManager != null) {
			selectionManager.allObjects.Add(obj);
			selectionManager.authorityOwner = objIdentity.clientAuthorityOwner;
		}
		NetworkServer.SpawnWithClientAuthority(manager, this.connectionToClient);

		//Player split manager
		manager = MonoBehaviour.Instantiate(this.splitManagerPrefab) as GameObject;
		SplitManager splitManager = manager.GetComponent<SplitManager>();
		if (splitManager != null) {
			splitManager.selectionManager = selectionManager;
        }
		NetworkServer.SpawnWithClientAuthority(manager, this.connectionToClient);*/
	}

	public void OnDestroy() {
		//By default, NetworkManager destroys game objects that were spawned into the game via NetworkServer.Spawn() or NetworkServer.SpawnWithClientAuthority().
		//This is why NetworkBehaviours and MonoBehaviours could not fire OnPlayerDisconnected() and OnDisconnectedFromServer() event methods. The
		//game objects the NetworkBehaviours and MonoBehaviours had been attached to are destroyed before they have the chance to fire the event methods.

		//This hasAuthority flag checking is still required, just like any other event methods from NetworkBehaviours.
		if (!this.hasAuthority) {
			return;
		}

		//This is called to destroy the camera panning. When the game ends, the player shouldn't be moving around.
		
	}
}