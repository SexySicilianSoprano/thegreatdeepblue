using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    // Mouse variables with default values
    private HoverOver m_HoverOver = HoverOver.Land;
    private Mode m_Mode = Mode.Normal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SwitchMouseMode(Mode mode)
    {
        switch (mode)
        {
            case Mode.Normal:
                break;

            case Mode.Menu:
                break;

            case Mode.PlaceBuilding:
                break;

            case Mode.Disabled:
                break;
        }
    }

    public enum HoverOver
    {
        Menu,
        Land,
        FriendlyUnit,
        EnemyUnit,
        FriendlyBuilding,
        EnemyBuilding,
    }

    public enum InteractionState
    {
        Nothing = 0,
        Invalid = 1,
        Move = 2,
        Attack = 3,
        Select = 4,
        Deploy = 5,
        Interact = 6,
        Sell = 7,
        CantSell = 8,
        Fix = 9,
        CantFix = 10,
        Disable = 11,
        CantDisable = 12,
    }

    public enum Mode
    {
        Normal,
        Menu,
        PlaceBuilding,
        Disabled,
    }
}
