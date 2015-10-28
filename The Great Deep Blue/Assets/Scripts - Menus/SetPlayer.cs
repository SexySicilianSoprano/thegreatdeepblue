using UnityEngine;
using System.Collections;

public class SetPlayer : MonoBehaviour {

    public Player Player1;
    public Player Player2;

    public void initialise(Player player1, Player player2) {
        player1 = new Player()
        {
            ID = 1,
            ScreenName = "Mingebag",
            Color = new Color(255, 0, 0)
        };

        player2 = new Player()
        {
            ID = 2,
            ScreenName = "TestEnemy",
            Color = new Color(0, 0, 255)
        };
    }

    public void Start() {
        initialise(Player1, Player2);
    }
}
