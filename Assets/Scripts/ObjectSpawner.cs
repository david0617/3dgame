using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
	public GameObject objToSpawn;
	public int count;
	public bool infinite;
	public int delayInSeconds;
	private bool Spawn = false;
	// Use this for initialization
	void Start () {
		if (infinite) StartCoroutine(spawnObjectsInfinite());
		else StartCoroutine(spawnObjects());
	}

	void Update () {
		if (infinite && Spawn == true){
			Spawn = false;
			StartCoroutine(spawnObjectsInfinite());
		 }
	}

	 public void OnTriggerStay(Collider go){
		 if (go != null) {
			StopAllCoroutines();
		 }
	 }
	 public void OnTriggereExit(Collider no){
			 print("hi");
			 Spawn = true;
	 }

	
	IEnumerator spawnObjectsInfinite() {
		while(true){
			Instantiate(objToSpawn, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(delayInSeconds);
		}
	}

	IEnumerator spawnObjects() {
		for (; count > 0; count--){
			Instantiate(objToSpawn, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(delayInSeconds);
		}
	}

}
