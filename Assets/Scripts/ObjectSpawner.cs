using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
	public GameObject objToSpawn;
	public int count, minT, maxT;
	public bool infinite, boss;
	public int delayInSeconds;
	// Use this for initialization
	void Start () {
		if (infinite) StartCoroutine(spawnObjectsInfinite());
		else if (boss) StartCoroutine(spawnObjectBoss());
		else if (infinite && boss) StartCoroutine(spawnObjectsInfiniteBoss());
		else StartCoroutine(spawnObjects()) ;
	}
	IEnumerator spawnObjectsInfinite() {
		while(true){
			Instantiate(objToSpawn, transform.position, Quaternion.identity);
			System.Random R1 = new System.Random();
            int time = R1.Next(minT, maxT);
			yield return new WaitForSeconds(delayInSeconds + time);
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
		IEnumerator spawnObjectsInfiniteBoss() {
		while(true){
			Instantiate(objToSpawn, transform.position, Quaternion.identity);
			System.Random R1 = new System.Random();
            int time = R1.Next(minT, maxT);
			yield return new WaitForSeconds(delayInSeconds + time);
		}
}
