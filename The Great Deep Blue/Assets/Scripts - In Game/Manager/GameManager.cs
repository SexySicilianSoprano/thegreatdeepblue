using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Player m_Player1 = new Player();
    public Player m_Player2 = new Player();

    public Player primaryPlayer = new Player();
    public Player enemyPlayer = new Player();

    public GameObject victoryPanel;

	// Use this for initialization
	void Start ()
    {
        m_Player1.AssignDetails(SetPlayer.Player1);
        m_Player2.AssignDetails(SetPlayer.Player2);

        primaryPlayer = m_Player1;
        enemyPlayer = m_Player2;

        Debug.Log(primaryPlayer.controlledLayer + " is da shiet!");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameObject.Find("FloatingFortressEnemy"))
        {
            victoryPanel.SetActive(true);
        } 
	}
}
