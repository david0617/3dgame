﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersitentObject : MonoBehaviour {
	public GameObject go;
	public int spawnDelay;
	private GameObject spawnedObject;
	private bool isSpawning = false;	
	// Use this for initialization
	void Start () {
		spawnedObject  = Instantiate(go, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if(spawnedObject == null && isSpawning == false) {
			StartCoroutine(SpawnAfterDelay());
		}
	}
	IEnumerator SpawnAfterDelay(){
		isSpawning = true;
		yield return new WaitForSeconds(spawnDelay);
		spawnedObject = Instantiate(go, transform.position, Quaternion.identity); 
		isSpawning = false;
	}
}
