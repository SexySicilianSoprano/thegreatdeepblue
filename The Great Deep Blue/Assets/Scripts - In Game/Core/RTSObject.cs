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

    public GameObject Explosion
    {
        get;
        private set;
    }

    public RTSObject AttackingEnemy;
    public UnitSpawner Spawner;
    FMOD.Studio.EventInstance sfx_Manager;

    // Health details
    public float m_Health;
	public float m_MaxHealth;	

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
        Explosion = item.Explosion;
	}

   	public void TakeDamage(float damage)
	{
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/" + Name + "/hit");
        m_Health -= damage;

        if (m_Health == 0 || m_Health <= 0) {
            Vector3 newVector = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z);
            GameObject newExplosion = Instantiate(Explosion, newVector, gameObject.transform.rotation) as GameObject;
            newExplosion.GetComponent<ParticleSystem>().Play(true);
            gameObject.GetComponent<HealthBarArmi>().healthBarSlider.gameObject.SetActive (false);
            Destroy(this.gameObject);
            Destroy(gameObject.GetComponent<HealthBarArmi>().healthBarSlider.gameObject);
        }
	}
        
    protected void AssignPlayer(Player player) {
        // Assign player
        PlayerIdentifier = player.ID;

        // Assign player color
        PlayerColor = player.Color;               
    }

    protected void OnDestroy() {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/" + Name + "/sinking");
        Destroy(gameObject.GetComponent<HealthBarArmi>().healthBarSlider.gameObject);
    }
    
}
