using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;
    public GameObject objToSpawn;
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
        Instantiate(objToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
