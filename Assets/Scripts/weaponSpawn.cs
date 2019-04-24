using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSpawn : MonoBehaviour
{
    public GameObject[] spawn;
    public GameObject weapon;
    public int spawnSize, time;
    // Start is called before the first frame update
    void Start()
    {
        spawnSize--;
        StartCoroutine(timer());
    }
    public IEnumerator timer()
    {
        yield return new WaitForSeconds(time);
        spawnWeapon();
    }
    public void spawnWeapon()
    {
        System.Random K1 = new System.Random();
        int spawnPoint = K1.Next(0, spawnSize);
        Instantiate(weapon, spawn[spawnPoint].transform.position, Quaternion.identity);
    }
}
