using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool m_GameStarted = false;
    private bool m_GameSet = false;
    public Player m_Player1 = new Player();
    public Player m_Player2 = new Player();
    private GameObject m_FloatingFortress1;
    private GameObject m_FloatingFortress2;
    private Player m_SetPlayer1 = new Player();
    private Player m_SetPlayer2 = new Player();

    public void setPrimaryPlayer(Player player)
    {
        m_SetPlayer1 = player;
    }

    public void setEnemyPlayer(Player player)
    {
        m_SetPlayer2 = player;
    }

    public Player primaryPlayer()
    {
        return m_Player1;
    }

    public Player enemyPlayer()
    {
        return m_Player2;
    }


    public GameObject victoryPanel;

	// Use this for initialization
	void Start ()
    {
        m_Player1.AssignDetails(SetPlayer.Player1);
        m_Player2.AssignDetails(SetPlayer.Player2);   
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (SceneManager.GetActiveScene().name == "Scene_Multiplayer" && !m_GameStarted)
        {
            if (m_FloatingFortress1 && m_FloatingFortress2)
            {
                m_GameStarted = true;

                m_FloatingFortress1 = GameObject.Find("Player1");
                m_FloatingFortress2 = GameObject.Find("Player2");

            }
        }
        if (m_GameStarted)
        {
            if (!m_GameSet)
            {
                // Win condition
                if (!m_FloatingFortress1 && primaryPlayer() == m_Player2 || !m_FloatingFortress2 && primaryPlayer() == m_Player1)
                {
                    victoryPanel.SetActive(true);
                    m_GameSet = true;
                }
                // Lose condition
                else if (!m_FloatingFortress1 && primaryPlayer() == m_Player1 || !m_FloatingFortress2 && primaryPlayer() == m_Player2)
                {
                    m_GameSet = true;
                }
            }
        }
	}
}
