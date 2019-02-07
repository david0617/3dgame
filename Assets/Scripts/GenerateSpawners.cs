using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpawners : MonoBehaviour
{
    public GameObject spawners1, spawners2;
    public Terrain terrain;
    public int timeM1, timeS1, tiemM2, timeS2, count1, count2;
    private int time1, time2, spawnCount1, spawnCount2;
    public bool endLess1, endLess2, spawners1on, spawners2on;


    // Use this for initialization
    void Start()
    {
        spawnCount1 = count1;
        spawnCount2 = count2;

        time1 = timeM1 * 60 + timeS1;
        time2 = tiemM2 * 60 + timeS2;


        if (spawners2on && endLess2)
        {
            StartCoroutine(Spawnendless2());
        }
        else if (spawners2on)
        {
            StartCoroutine(Spawn2());
        }
        if (spawners1on && endLess1)
        {
            StartCoroutine(Spawnendless1());
        }
        else if (spawners1on)
        {
            StartCoroutine(Spawn1());
        }
    }

    public IEnumerator Spawn1()
    {

        if (spawnCount1 == count1)
        {
            yield return new WaitForSeconds(1);
            float xSize1 = terrain.terrainData.size.x;
            float zSize1 = terrain.terrainData.size.z;
            System.Random R1 = new System.Random();
            float xSpawnPoint1 = terrain.GetPosition().x + R1.Next(0, (int)xSize1);
            float zSpawnPoint1 = terrain.GetPosition().z + R1.Next(0, (int)zSize1);
            float ySpawnPoint1 = terrain.GetPosition().y;
            Vector3 SpawnPoint = new Vector3(xSpawnPoint1, ySpawnPoint1, zSpawnPoint1);

            Instantiate(spawners1, SpawnPoint, Quaternion.identity);
            spawnCount1--;
        }

        yield return new WaitForSeconds(time1);

        StartCoroutine(Spawn1());
    }

    public IEnumerator Spawnendless1()
    {
        float xSize1 = terrain.terrainData.size.x;
        float zSize1 = terrain.terrainData.size.z;
        System.Random R1 = new System.Random();
        float xSpawnPoint2 = terrain.GetPosition().x + R1.Next(0, (int)xSize1);
        float zSpawnPoint2 = terrain.GetPosition().z + R1.Next(0, (int)zSize1);
        float ySpawnPoint2 = terrain.GetPosition().y;
        Vector3 SpawnPoint = new Vector3(xSpawnPoint2, ySpawnPoint2, zSpawnPoint2);

        Instantiate(spawners1, SpawnPoint, Quaternion.identity);

        yield return new WaitForSeconds(time1);

        StartCoroutine(Spawnendless1());
    }

    public IEnumerator Spawn2()
    {
        if (spawnCount2 == count2)
        {
            yield return new WaitForSeconds(2);
            float xSize2 = terrain.terrainData.size.x;
            float zSize2 = terrain.terrainData.size.z;
            System.Random R2 = new System.Random();
            float xSpawnPoint3 = terrain.GetPosition().x + R2.Next(0, (int)xSize2);
            float zSpawnPoint3 = terrain.GetPosition().z + R2.Next(0, (int)zSize2);
            float ySpawnPoint3 = terrain.GetPosition().y;
            Vector3 SpawnPoint = new Vector3(xSpawnPoint3, ySpawnPoint3, zSpawnPoint3);

            Instantiate(spawners2, SpawnPoint, Quaternion.identity);
            spawnCount2--;
        }
        yield return new WaitForSeconds(time2);
        StartCoroutine(Spawn2());
    }

    public IEnumerator Spawnendless2()
    {
        float xSize2 = terrain.terrainData.size.x;
        float zSize2 = terrain.terrainData.size.z;
        System.Random R2 = new System.Random();
        float xSpawnPoint4 = terrain.GetPosition().x + R2.Next(0, (int)xSize2);
        float zSpawnPoint4 = terrain.GetPosition().z + R2.Next(0, (int)zSize2);
        float ySpawnPoint4 = terrain.GetPosition().y;
        Vector3 SpawnPoint = new Vector3(xSpawnPoint4, ySpawnPoint4, zSpawnPoint4);

        Instantiate(spawners2, SpawnPoint, Quaternion.identity);

        yield return new WaitForSeconds(time2);

        StartCoroutine(Spawnendless2());
    }
}
