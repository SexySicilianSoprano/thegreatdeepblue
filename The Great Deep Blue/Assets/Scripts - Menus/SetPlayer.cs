using UnityEngine;
using System.Collections;

public class SetPlayer : MonoBehaviour {
    
    public Player Player1 = new Player()
    {
        playerID = 1,
        playerScreenName = "Mingebag",
        playerColor = new Color (255,0,0),
        playerTeam = 1
        
    };

    public Player Player2 = new Player()
    {
        playerID = 2,
        playerScreenName = "TestEnemy",
        playerColor = new Color(0, 0, 255),
        playerTeam = 2

    };



}
