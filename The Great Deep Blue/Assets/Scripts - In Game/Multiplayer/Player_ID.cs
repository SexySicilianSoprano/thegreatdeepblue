using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_ID : NetworkBehaviour {


	public override void OnStartLocalPlayer ()
	{
		base.OnStartLocalPlayer();
		CmdCall();

	}
	
	[Command]
	public void CmdSliderSpawn(GameObject slider){
		NetworkServer.Spawn (slider);
	}

	[Command]
	public void CmdCall() {
		//Calling [ClientRpc] on the server.
		RpcLog();
	}
	
	[ClientRpc]
	public void RpcLog() {
		//First, checks to see what type of recipient is receiving this message. If it's server, the output message should tell the user what the type is.
		Debug.Log("RPC: This is " + (this.isServer ? " Server " : " Client ") + this.gameObject);
		
		if (this.isServer) {
			//Server code
			//This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
			//NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.
			this.gameObject.tag = "Player1";
			this.gameObject.layer = 8;
			GameObject.Find("Manager").GetComponent<GameManager>().primaryPlayer = GameObject.Find("Manager").GetComponent<GameManager>().m_Player1;
			GameObject.Find("Manager").GetComponent<GameManager>().enemyPlayer = GameObject.Find("Manager").GetComponent<GameManager>().m_Player2;
			
			if (this.gameObject.name == "NavalYardMultiplayer(Clone)") {
				//Server code
				//This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
				//NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.
				this.gameObject.tag = "Player1NavalYard";
			}
			if (this.gameObject.name == "FloatingFortressMultiplayer2(Clone)") {
				//Server code
				//This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
				//NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.
				this.gameObject.name = "Player1";
				GameObject.Find ("myIdentity").GetComponent<myIdentity>().myFoatingFortress.Add(this.gameObject);
			}
		} else {
			//Client code
			//I realized this hardly runs. Placed a log message here for completeness.
			this.gameObject.tag = "Player2";
			this.gameObject.layer = 9;
			GameObject.Find("Manager").GetComponent<GameManager>().primaryPlayer = GameObject.Find("Manager").GetComponent<GameManager>().m_Player2;
			GameObject.Find("Manager").GetComponent<GameManager>().enemyPlayer = GameObject.Find("Manager").GetComponent<GameManager>().m_Player1;
			
			if (this.gameObject.name == "NavalYardMultiplayer(Clone)") {
				//Server code
				//This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
				//NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.
				this.gameObject.tag = "Player2NavalYard";
			}
			if (this.gameObject.name == "FloatingFortressMultiplayer2(Clone)") {
				//Server code
				//This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
				//NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.
				this.gameObject.name = "Player2";
				GameObject.Find ("myIdentity").GetComponent<myIdentity>().myFoatingFortress.Add(this.gameObject);
			}
		}

		
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(this.gameObject.tag == "Enemy"){
			CmdCall();
		}
		
	}
	
	

}
