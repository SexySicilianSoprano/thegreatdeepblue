using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(SelectedBuilding))]
public class Building : RTSObject {
	
	private bool sellable = false;
	
	public void Start()
	{        
        
    }

    public int BuildingIdentifier
    {
        get; set;
    }
	
	public bool InteractWith()
	{
		return false;
	}
	
	public bool CanSell()
	{
		return sellable;
	}

	public override void SetSelected ()
	{
		
	}

	public override void SetDeselected ()
	{
		
	}

	public override void AssignToGroup (int groupNumber)
	{
		
	}

	public override void RemoveFromGroup ()
	{
		
	}
	
	public override void ChangeTeams(int team)
	{

	}

}
