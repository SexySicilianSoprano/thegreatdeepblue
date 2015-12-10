using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private bool m_GameSet = false;
    public Player m_Player1 = new Player();
    public Player m_Player2 = new Player();
    private GameObject m_FloatingFortress1;
    private GameObject m_FloatingFortress2;

    public Player primaryPlayer
    {
    	get;
    	set;
        //return m_Player1;
    }

    public Player enemyPlayer
    {
		get;
		set;
        //return m_Player2;
    }    

    public GameObject victoryPanel;

	// Use this for initialization
	void Start ()
    {
        m_Player1.AssignDetails(SetPlayer.Player1);
        m_Player2.AssignDetails(SetPlayer.Player2);

        m_FloatingFortress1 = GameObject.Find("FloatingFortress_1");
        m_FloatingFortress2 = GameObject.Find("FloatingFortress_2");    
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!m_GameSet)
        {
            // Win condition
            if (!m_FloatingFortress1 && primaryPlayer == m_Player2 || !m_FloatingFortress2 && primaryPlayer == m_Player1)
            {
                //victoryPanel.SetActive(true);
                m_GameSet = true;
            }
            // Lose condition
            else if (!m_FloatingFortress1 && primaryPlayer == m_Player1 || !m_FloatingFortress2 && primaryPlayer == m_Player2)
            {
                m_GameSet = true;
            }
        }
	}
}
