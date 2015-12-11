using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MultiplayerManager : NetworkBehaviour {

    [SyncVar]
    public Player Player1;

    [SyncVar]
    public Player Player2;

    [SyncVar]
    public bool playersResolved = false;

    public Player primaryPlayer()
    {
        return GetComponent<GameManager>().primaryPlayer();
    }

    public Player enemyPlayer()
    {
        return GetComponent<GameManager>().enemyPlayer();
    }

    public bool arePlayersResolved()
    {
        return playersResolved;
    }

    // Use this for initialization
    public void Start ()
    {
        if (SceneManager.GetActiveScene().name == "Scene_Multiplayer")
        {
            
            
        }	
	}

    public void ResolvePlayers()
    {
        if (Player1 == null)
        {
            GetComponent<GameManager>().setPrimaryPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player1);
            GetComponent<GameManager>().setEnemyPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player2);
            Player1 = primaryPlayer();
            Player2 = enemyPlayer();
            playersResolved = true;
        }
        else
        {
            GetComponent<GameManager>().setPrimaryPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player2);
            GetComponent<GameManager>().setEnemyPlayer(GameObject.Find("Manager").GetComponent<GameManager>().m_Player1);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
