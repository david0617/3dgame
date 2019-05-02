using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
	public GameObject objToSpawn;
	public int count;
	public bool infinite, boss;
	public int delayInSeconds;
	// Use this for initialization
	void Start () {
		if (infinite) StartCoroutine(spawnObjectsInfinite());
		else if (boss) StartCoroutine(spawnObjectBoss());
		else StartCoroutine(spawnObjects()) ;
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

	IEnumerator spawnObjectBoss() {
		for (; count > 0; count--){
			yield return new WaitForSeconds(delayInSeconds);
			Instantiate(objToSpawn, transform.position, Quaternion.identity);
		}
	}
}
