using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SelectedBuilding))]
public class Building : RTSObject {
	
	private bool sellable = false;
	
	protected void Start()
	{
        //Tell the manager this building has been added
        if (gameObject.tag == "Player1")
        {
            if (!gameObject.GetComponent<BuildingBeingPlaced>())
            {
                ManagerResolver.Resolve<IManager>().BuildingAdded(this);
            }
        }        
    }

    public int BuildingIdentifier
    {
        get; set;
    }
	
	public bool InteractWith(IOrderable obj)
	{
		return false;
	}
	
	public bool CanSell()
	{
		return sellable;
	}

	public override void SetSelected ()
	{
		GetComponent<SelectedBuilding>().SetSelected ();
	}

	public override void SetDeselected ()
	{
		GetComponent<SelectedBuilding>().SetDeselected ();
	}

	public override void AssignToGroup (int groupNumber)
	{
		
	}

	public override void RemoveFromGroup ()
	{
		
	}
	
	public override void ChangeTeams(int team)
	{
		switch (team)
		{
		case Const.TEAM_STEAMHOUSE:
			
			break;
		}
	}

}
