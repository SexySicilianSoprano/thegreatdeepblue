using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Selected))]
public class Unit : RTSObject, IOrderable {
	
	//Member Variables
    protected bool m_IsMoveable = true;	
	protected bool m_IsDeployable = false;
	protected bool m_IsAttackable = true;
	protected bool m_IsInteractable = false;

    protected IGUIManager guiManager
	{
		get;
		private set;
	}
	
	protected ISelectedManager selectedManager
	{
		get;
		private set;
	}
	
	protected void Start()
	{
        guiManager = ManagerResolver.Resolve<IGUIManager>();
		selectedManager = ManagerResolver.Resolve<ISelectedManager>();
        ManagerResolver.Resolve<IManager>().UnitAdded(this);
        /*
		m_IsDeployable = this is IDeployable;
		m_IsAttackable = this is IAttackable;
		m_IsInteractable = this is IInteractable;
        */
    }
	
	protected void Update()
	{
		if (GetComponent<Renderer>().isVisible && guiManager.Dragging)
		{
			if (guiManager.IsWithin (transform.position))
			{
				selectedManager.AddObject(this);
			}
			else
			{
				selectedManager.DeselectObject (this);				
			}
		}
	}
		
	public override void SetSelected ()
	{
		if (!GetComponent<Selected>().IsSelected)
		{
			GetComponent<Selected>().SetSelected ();
		}
	}

	public override void SetDeselected ()
	{
		GetComponent<Selected>().SetDeselected ();
	}

	public override void AssignToGroup (int groupNumber)
	{
		GetComponent<Selected>().AssignGroupNumber (groupNumber);
	}

	public override void RemoveFromGroup ()
	{
		GetComponent<Selected>().RemoveGroupNumber ();
	}
	
	public override void ChangeTeams(int team)
	{
		switch (team)
		{
		case Const.TEAM_STEAMHOUSE:
			
			break;

		}
	}

	public bool IsDeployable ()
	{
		//return m_IsDeployable;
		return this is IDeployable;
	}

	public bool IsAttackable ()
	{
        return m_IsAttackable;
	}

	public bool IsMoveable ()
	{
		return m_IsMoveable;
	}

	public bool IsInteractable ()
	{
		return m_IsInteractable;
	}

    public void GiveOrder (Order order)
	{
		switch (order.OrderType)
		{
			// Stop Order
		    case Const.ORDER_STOP:

                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/" + Name + "/" + Name + "_confirm", transform.position.normalized);     
                GetComponent<Combat>().Stop();
			    if (IsMoveable())
			    {
				    if (IsDeployable ())
				    {
					    CancelDeploy ();
				    }
				    GetComponent<Movement>().Stop ();
			    }
			    break;
			
			// Move Order
		    case Const.ORDER_MOVE_TO:

                GetComponent<Combat>().Stop();
                if (IsMoveable())
			    {
				    if (IsDeployable ())
				    {
					    CancelDeploy ();
				    }
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/" + Name + "/" + Name + "_confirm", transform.position.normalized);
                    GetComponent<Movement>().MoveTo (order.OrderLocation);
			    }
			    break;

			// Deploy Order
		    case Const.ORDER_DEPLOY:
			    
			    GetComponent<Movement>().Stop ();
			
			    ((IDeployable)this).Deploy();
                break;

            // Attack Order
            case Const.ORDER_ATTACK:

                GetComponent<Combat>().Stop();
                if (IsAttackable())
                {
                    // Attack
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/" + Name + "/" + Name + "_attack", transform.position.normalized);
                    GetComponent<Combat>().Attack(order.Target);
                }

                break;

		}
	}

	public bool ShouldInteract (HoverOver hoveringOver)
	{
		switch (hoveringOver)
		{
		    case HoverOver.Land:
                return m_IsMoveable;
                
            case HoverOver.EnemyBuilding:
                return m_IsAttackable;

		    case HoverOver.EnemyUnit:
                return m_IsAttackable;
			
		    case HoverOver.FriendlyUnit:
                return m_IsDeployable && ManagerResolver.Resolve<IUIManager>().IsCurrentUnit (this);
			
		    default:
                Debug.LogError("Switch hoverOver didn't work");
			    return false;
		}
	}

    // Trigger reactions for unit creation
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            Physics.IgnoreCollision(GetComponent<BoxCollider>(), other.GetComponent<BoxCollider>());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        GetComponent<BoxCollider>().isTrigger = false;      
    }
    
	private void CancelDeploy()
	{
		((IDeployable)this).StopDeploy ();
	}
   
    new void OnDestroy()
	{
        if (gameObject.layer == primaryPlayer.controlledLayer)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/" + Name + "/" + Name + "_kill", transform.position.normalized);
        }
            
        //Remove object from selected manager
        selectedManager.DeselectObject(this);
	}
}
