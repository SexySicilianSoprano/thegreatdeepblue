using UnityEngine;
using System.Collections;

public class SetPlayer : MonoBehaviour {
    
    public Player Player1 = new Player()
    {
        ID = 1,
        ScreenName = "Mingebag",
        Color = new Color (255,0,0),
    };

    public Player Player2 = new Player()
    {
        ID = 2,
        ScreenName = "TestEnemy",
        Color = new Color(0, 0, 255), 
    };



}
