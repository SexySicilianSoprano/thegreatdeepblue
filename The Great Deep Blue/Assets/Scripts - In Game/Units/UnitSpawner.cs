using UnityEngine;
using System.Collections;

public class UnitSpawner : MonoBehaviour {

    private Transform Spawner;
    private Vector3 SpawnerPos;

	// Use this for initialization
	void Start ()
    {
        Spawner = gameObject.transform.GetChild(0);
    }

    void Update()
    {
        SpawnerPos = Spawner.transform.position;
    }
	
    public void Spawn (Item item)
    {
        Vector3 m_ReadyPosition = new Vector3(SpawnerPos.x * 10, SpawnerPos.y, SpawnerPos.z * 10);
        GameObject newUnit = Instantiate(item.Prefab, SpawnerPos, Spawner.rotation) as GameObject;
        Debug.Log(newUnit.GetComponent<Unit>());
        newUnit.GetComponent<Movement>().MoveTo(m_ReadyPosition);
        
    }
}
