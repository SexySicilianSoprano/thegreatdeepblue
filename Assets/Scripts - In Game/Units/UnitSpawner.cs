using UnityEngine;
using System.Collections;

public class UnitSpawner : MonoBehaviour {

    public Transform Spawner;
    public Vector3 SpawnerPos;

	// Use this for initialization
	void Start ()
    {
        Spawner = gameObject.transform.GetChild(0);
        SpawnerPos = Spawner.transform.position;
    }
	
    public void Spawn (Item item)
    {
        GameObject newUnit = Instantiate(item.Prefab, SpawnerPos, Spawner.rotation) as GameObject;
    }
}
