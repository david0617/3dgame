using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpawners : MonoBehaviour {
	public GameObject spawners1,ship2;
	public Terrain terrain; 
	public int timeM1,timeS1,tiemM2,timeS2,count1,count2;
	private int time1,time2,spawnCount1,spawnCount2;
	public bool endLess1,endLess2;


	// Use this for initialization
	void Start () {
		spawnCount1 = count1;
		spawnCount2 = count2;

		time1 = timeM1*60 + timeS1;
		time2 = tiemM2*60 + timeS2;

		StartCoroutine(Spawn1());
		//StartCoroutine(Spawn2());
	}

	public IEnumerator Spawn1(){

		if (spawnCount1 == count1){
			float xSize1 = terrain.terrainData.size.x;
			float zSize1 = terrain.terrainData.size.z;
			System.Random R1 = new System.Random();
			float xSpawnPoint1 = terrain.GetPosition().x + R1.Next(0, (int) xSize1);
			float zSpawnPoint1 = terrain.GetPosition().z + R1.Next(0, (int) zSize1);
			float ySpawnPoint = terrain.GetPosition().y;
			Vector3 SpawnPoint  = new Vector3(xSpawnPoint1, ySpawnPoint, zSpawnPoint1);

			Instantiate(spawners1, SpawnPoint, Quaternion.identity);
			spawnCount1--;
		} else if (spawnCount1 > 0 || endLess1){
			float xSize1 = terrain.terrainData.size.x;
			float zSize1 = terrain.terrainData.size.z;
			System.Random R1 = new System.Random();
			float xSpawnPoint1 = terrain.GetPosition().x + R1.Next(0, (int) xSize1);
			float zSpawnPoint1 = terrain.GetPosition().z + R1.Next(0, (int) zSize1);
			float ySpawnPoint = terrain.GetPosition().y;
			Vector3 SpawnPoint  = new Vector3(xSpawnPoint1, ySpawnPoint, zSpawnPoint1);

			Instantiate(spawners1, SpawnPoint, Quaternion.identity);
			spawnCount1--;
		}
		
		yield return new WaitForSeconds(time1);
		
		StartCoroutine(Spawn1());
	}

	 	/*public IEnumerator Spawn2(){

		if(spawnCount2 == count2){
			yield return new WaitForSeconds(1);
			float xSize2 = terrain.terrainData.size.x;
			float zSize2 = terrain.terrainData.size.z;
			System.Random R2 = new System.Random();
			float xSpawnPoint2 = terrain.GetPosition().x + R2.Next(0, (int) xSize2);
			float zSpawnPoint2 = terrain.GetPosition().z + R2.Next(0, (int) zSize2);
			float ySpawnPoint = terrain.GetPosition().y + 20;
			Vector3 SpawnPoint  = new Vector3(xSpawnPoint2, ySpawnPoint, zSpawnPoint2);

			Instantiate(ship2, SpawnPoint, Quaternion.identity);
			spawnCount2--;
		}else if (spawnCount2 > 0 || endLess2){
			float xSize2 = terrain.terrainData.size.x;
			float zSize2 = terrain.terrainData.size.z;
			System.Random R2 = new System.Random();
			float xSpawnPoint2 = terrain.GetPosition().x + R2.Next(0, (int) xSize2);
			float zSpawnPoint2 = terrain.GetPosition().z + R2.Next(0, (int) zSize2);
			float ySpawnPoint = terrain.GetPosition().y + 20;
			Vector3 SpawnPoint  = new Vector3(xSpawnPoint2, ySpawnPoint, zSpawnPoint2);

			Instantiate(ship2, SpawnPoint, Quaternion.identity);
			spawnCount2--;
		}

		yield return new WaitForSeconds(time2);

		StartCoroutine(Spawn2());
	}*/
}
