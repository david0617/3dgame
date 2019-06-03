using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;
    public GameObject objToSpawn;
    public int point;
    public int killtime;
    private Animator animator;
    public bool Dead;

    void Start()
    {
        animator = GetComponent<Animator>();
        Dead = false;
    }
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

    public IEnumerator Destroyssequence()
    {
        Dead = true;
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(killtime);
        GameObject.Find("player").GetComponent<Pointdisplay>().add(point);
        Instantiate(objToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
