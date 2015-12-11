using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_ID : NetworkBehaviour {

    /*
    private bool playersResolved()
    {
        return GameObject.Find("Manager").GetComponent<MultiplayerManager>().arePlayersResolved();
    }
    */

	public override void OnStartLocalPlayer ()
	{
		base.OnStartLocalPlayer();
	}

    public void Start()
    {
        /*
        if (!playersResolved())
        {
            GameObject.Find("Manager").GetComponent<MultiplayerManager>().ResolvePlayers();

            if (GameObject.Find("Manager").GetComponent<MultiplayerManager>().Player1 == null)
            {
                GameObject.Find("Manager").GetComponent<GameManager>().setPrimaryPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player1);
                GameObject.Find("Manager").GetComponent<GameManager>().setEnemyPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player2);
                GameObject.Find("Manager").GetComponent<MultiplayerManager>().playersResolved = true;
            }            
        }*/

        CmdCall();
        /*
        if (!playersResolved)
        {
            if (!GameObject.Find("Player1"))
            {
                GameObject.Find("Manager").GetComponent<GameManager>().setPrimaryPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player1);
                GameObject.Find("Manager").GetComponent<GameManager>().setEnemyPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player2);
                playersResolved = true;
            }
            else
            {
                GameObject.Find("Manager").GetComponent<GameManager>().setPrimaryPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player2);
                GameObject.Find("Manager").GetComponent<GameManager>().setEnemyPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player1);
                playersResolved = true;
            }
            
            if (GetComponent<FloatingFortress>() && isServer)
            {
                GameObject.Find("Manager").GetComponent<GameManager>().setPrimaryPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player1);
                GameObject.Find("Manager").GetComponent<GameManager>().setEnemyPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player2);
                playersResolved = true;
            }
            else if (GetComponent<FloatingFortress>() && !isServer)
            {
                GameObject.Find("Manager").GetComponent<GameManager>().setPrimaryPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player2);                
                GameObject.Find("Manager").GetComponent<GameManager>().setEnemyPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player1);
                playersResolved = true;
            }*/
        
        
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
		
		if (this.hasAuthority) {
			//Server code
			//This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
			//NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.
			this.gameObject.tag = "Player1";
			this.gameObject.layer = 8;
			
            
			if (this.gameObject.name == "NavalYardMultiplayer(Clone)")
            {
                //Server code
                //This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
                //NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.
                //this.gameObject.tag = "Player1NavalYard";
                this.gameObject.name = "NavalYardPlayer1";
                GetComponent<NavalYard>().AddQueue();

                /*
                if (GameObject.Find("NavalYardMultiplayer(Clone)"))
                {
                    GameObject.Find("NavalYardMultiplayer(Clone)").name = "NavalYardPlayer2";
                    GameObject.Find("NavalYardPlayer2").layer = 9;
                }*/
            }
			if (this.gameObject.name == "FloatingFortressMultiplayer2(Clone)")
            {
				//Server code
				//This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
				//NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.
				this.gameObject.name = "Player1";
				GameObject.Find ("myIdentity").GetComponent<myIdentity>().myFoatingFortress.Add(this.gameObject);
                //GameObject.Find("Manager").GetComponent<GameManager>().setPrimaryPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player1);
                //GameObject.Find("Manager").GetComponent<GameManager>().setEnemyPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player2);
                Debug.Log("The swag is real " + GameObject.Find("Manager").GetComponent<GameManager>().primaryPlayer().controlledLayer);
                GetComponent<FloatingFortress>().AddQueue();
                if (GameObject.Find("FloatingFortressMultiplayer2(Clone)"))
                {
                    GameObject.Find("FloatingFortressMultiplayer2(Clone)").name = "Player2";
                    GameObject.Find("Player2").layer = 9;
                }
            }
        }
        else
        {
			//Client code
			//I realized this hardly runs. Placed a log message here for completeness.
			this.gameObject.tag = "Player2";
			this.gameObject.layer = 9;
			
			
			if (this.gameObject.name == "NavalYardMultiplayer(Clone)")
            {
                //Server code
                //This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
                //NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.
                this.gameObject.name = "NavalYardPlayer2";
                //GetComponent<NavalYard>().AddQueue();
            }
			if (this.gameObject.name == "FloatingFortressMultiplayer2(Clone)")
            {
				//Server code
				//This is run for spawning new non-player objects. Since it is a server calling to all clients (local and remote), it needs to pass in a
				//NetworkConnection that connects from server to THAT PARTICULAR client, who is going to own client authority on the spawned object.
				this.gameObject.name = "Player2";
				GameObject.Find ("myIdentity").GetComponent<myIdentity>().myFoatingFortress.Add(this.gameObject);
                //GameObject.Find("Manager").GetComponent<GameManager>().setPrimaryPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player2);
                //GameObject.Find("Manager").GetComponent<GameManager>().setEnemyPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player1);  
                //GetComponent<FloatingFortress>().AddQueue();
            }
        }

		
	}
	
	
	// Update is called once per frame
	void Update () 
	{ /*
		if(this.gameObject.tag == "Enemy"){
			CmdCall();
		}
		*/
	}
	
	

}
