using UnityEngine;
using System.Collections;

public abstract class RTSObject : MonoBehaviour {

	//The base class for all playable objects
	
	public string Name
	{
		get;
		private set;
	}
	
	public int ID
	{
		get;
		private set;
	}
	
	public int UniqueID
	{
		get;
		private set;
	}
	
	public int TeamIdentifier
	{
        get;
        private set;
	}

    public int PlayerIdentifier {
        get;
        private set;
    }

    public Color PlayerColor {
        get;
        private set;
    }

    public Weapon Weapon {
        get;
        private set;
    }
    
    public RTSObject AttackingEnemy;
    public UnitSpawner Spawner;
	
    // Health details
	private float m_Health;
	private float m_MaxHealth;	

    // Action voids
	public abstract void SetSelected();
	public abstract void SetDeselected();
	public abstract void AssignToGroup(int groupNumber);
	public abstract void RemoveFromGroup();
	public abstract void ChangeTeams(int team);

    // Weapon details
    private float m_Damage;
    private float m_Range;
    private float m_FireRate;
	
	public float GetHealthRatio()
	{
		return m_Health/m_MaxHealth;
	}
	
	protected void Awake()
	{
		UniqueID = ManagerResolver.Resolve<IManager>().GetUniqueID();
	}
	
	protected void AssignDetails(Item item)
	{
		Name = item.Name;
		ID = item.ID;
		TeamIdentifier = item.TeamIdentifier;
		m_MaxHealth = item.Health;
		m_Health = m_MaxHealth;
	}

   	public void TakeDamage(float damage)
	{
		m_Health -= damage;

        if (m_Health == 0 || m_Health <= 0) {

            GameObject Explosion = Instantiate(Resources.Load("Explosion_Ship"), gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            Destroy(gameObject);
        }
	}
        
    protected void AssignPlayer(Player player) {
        // Assign player
        PlayerIdentifier = player.ID;

        // Assign player color
        PlayerColor = player.Color;               
    }
    
}
