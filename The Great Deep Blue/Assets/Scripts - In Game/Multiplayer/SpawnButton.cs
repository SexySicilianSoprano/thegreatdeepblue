using UnityEngine;
using System.Collections;

public class SpawnButton : MonoBehaviour {

	private bool locked = false;
	//tänne voisi laittaa ajastuksen

	public void SpawnRequest(int spawnUnit){
		if (locked == false){
			StartCoroutine(WaitAndSpawn(spawnUnit));
			locked = true;
		}
	}
	
	IEnumerator WaitAndSpawn(int spawnUnit){
		yield return new WaitForSeconds(3);
		GameObject.Find ("myIdentity").GetComponent<myIdentity>().myFoatingFortress[0].GetComponent<Spawner>().CmdCall(spawnUnit);
		locked = false;
	}
	
}
