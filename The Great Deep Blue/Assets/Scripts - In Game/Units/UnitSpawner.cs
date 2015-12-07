using UnityEngine;
using System.Collections;

public class UnitSpawner : MonoBehaviour {

    private Transform m_Spawner;
    private Transform m_ReadySpot;
    private Vector3 m_SpawnerPos;
    private Vector3 m_ReadyPos;

    // Use this for initialization
    void Start ()
    {
        m_Spawner = gameObject.transform.GetChild(0);
        m_ReadySpot = gameObject.transform.GetChild(1);
    }

    void Update()
    {
        m_SpawnerPos = m_Spawner.transform.position;
        m_ReadyPos = m_ReadySpot.transform.position;
    }
	
    public void Spawn (Item item)
    {
        //Quaternion m_SpawnRot = Quaternion.LookRotation(new Vector3(m_SpawnerPos.x, m_SpawnerPos.y, m_SpawnerPos.z));     
        GameObject newUnit = Instantiate(item.Prefab, m_SpawnerPos, m_Spawner.rotation) as GameObject;
        newUnit.layer = gameObject.layer;
        newUnit.tag = gameObject.tag;
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/" + item.Name + "/" + item.Name + "_ready", transform.position.normalized);

        //newUnit.GetComponent<Movement>().MoveTo(m_ReadyPos);       
    }
}
