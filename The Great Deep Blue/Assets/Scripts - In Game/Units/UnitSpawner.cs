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
        GameObject newUnit = Instantiate(item.Prefab, SpawnerPos, Spawner.rotation) as GameObject;
    }
}
