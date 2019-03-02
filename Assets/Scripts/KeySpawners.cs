using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawners : MonoBehaviour
{
    public GameObject[] keys;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        System.Random key = new System.Random();
        int randomNumber = key.Next(0, 6);
        print(randomNumber + 1);
        SpawnKey(randomNumber);
    }
    public void SpawnKey(int a)
    {
        Quaternion rotation = keys[a].transform.rotation;
        GameObject keyObj = Instantiate(key, keys[a].transform.position, rotation);
    }
}
