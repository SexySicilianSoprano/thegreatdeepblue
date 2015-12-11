using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class iDie : NetworkBehaviour {

	[SyncVar]
	public float myHealth;
	
	// Use this for initialization
	void Start () {

        if (this.gameObject.name == "ScoutMultiplayer2(Clone)")
        {
            myHealth = gameObject.GetComponent<Scout>().m_Health;
        }

        if (this.gameObject.name == "DestroyerMultiplayer2(Clone)"){
			myHealth = gameObject.GetComponent<Destroyer>().m_Health;
		}
		
		if (this.gameObject.name == "Player1" && this.gameObject.name == "Player2")
        {
			myHealth = gameObject.GetComponent<FloatingFortress>().m_Health;
		}
		
		if (this.gameObject.name == "NavalYardMultiplayer(Clone)"){
			myHealth = gameObject.GetComponent<NavalYard>().m_Health;
		}
	}
	
	[Command]
	void CmdPleaseDestroyThisObject(GameObject obj){
		NetworkServer.Destroy (obj);
    }
		
	[Command]
	public void CmdPleaseHurtThisObject(GameObject obj, float dmg){
		obj.gameObject.GetComponent<iDie>().CmdIGotHit(dmg);
	}

	/*
	public void iDied(){
		CmdPleaseDestroyThisObject(GetComponent<HealthBarArmi>().healthBarSlider.gameObject);
		CmdPleaseDestroyThisObject(this.gameObject);
	}*/
	
	/*
	public void iDamagedSomeone(GameObject target, float dmg){
		CmdPleaseHurtThisObject(target, dmg);
	}*/
	
	[Command]
	public void CmdIGotHit(float dmg){
		myHealth -= dmg;
	}
	
	// Update is called once per frame
	void Update () {
        		
		if (this.gameObject.name == "DestroyerMultiplayer2(Clone)"){
			gameObject.GetComponent<Destroyer>().m_Health = myHealth;
		}

        if (this.gameObject.name == "ScoutMultiplayer2(Clone)")
        {
            gameObject.GetComponent<Scout>().m_Health = myHealth;
        }

        if (this.gameObject.name == "Player1" && this.gameObject.name == "Player2")
        {
			gameObject.GetComponent<FloatingFortress>().m_Health = myHealth;
		}
		
		if (this.gameObject.name == "NavalYardMultiplayer(Clone)"){
			gameObject.GetComponent<NavalYard>().m_Health = myHealth;
		}
		
		/*
		if (myHealth <= 0){
			iDied ();
		}*/

	}

    void OnDestroy()
    {
        CmdPleaseDestroyThisObject(this.gameObject);
    }
}
