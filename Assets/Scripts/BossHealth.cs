using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;
    public GameObject objToSpawn;
    public int point;
    void Update()
    {
        int ph = GameObject.Find("player").GetComponent<PlayerHealth>().currenthealth;
        if (ph == 0 || ph < 0)
        {
            Destroy(gameObject);
        }
    }
    public void dealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroyssequence();
        }
    }

    public void Destroyssequence()
    {
        GameObject.Find("player").GetComponent<Pointdisplay>().add(point);
        Instantiate(objToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
