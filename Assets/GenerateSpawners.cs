using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpawners : MonoBehaviour {
	
	public int count;
	public GameObject spawners;
	public Terrain terrain; 

	// Use this for initialization
	void Start () {
		for (int i = 0; i < count; i++) {
			float xSize = terrain.terrainData.size.x;
			float zSize = terrain.terrainData.size.z;
			System.Random r = new System.Random();
			float xSpawnPoint = terrain.GetPosition().x + r.Next(0, (int) xSize);
			float zSpawnPoint = terrain.GetPosition().z + r.Next(0, (int) zSize);
			float ySpawnPoint = terrain.GetPosition().y - 2;
			Vector3 SpawnPoint  = new Vector3(xSpawnPoint, ySpawnPoint, zSpawnPoint);

			Instantiate(spawners, SpawnPoint, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
