using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public GameObject[] pickUp;
    public int point;
    void Update (){
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
            pickUpSequence();
        }
    }

    public void Destroyssequence()
    {
        Destroy(gameObject);
        GameObject.Find("player").GetComponent<Pointdisplay>().add(point);
    }
    public void pickUpSequence()
    {
        System.Random R1 = new System.Random();
        int x = R1.Next(0, 150);
        if (x >= 0 && x <= 20)
        {
            Instantiate(pickUp[0], transform.position, Quaternion.identity);
        }
        else if (x >= 30 && x <= 50)
        {
            Instantiate(pickUp[1], transform.position, Quaternion.identity);
        }
        else if (x >= 60 && x <= 70)
        {
            Instantiate(pickUp[2], transform.position, Quaternion.identity);
        }
        else if (x >= 80 && x <= 90)
        {
            Instantiate(pickUp[3], transform.position, Quaternion.identity);
        }
        else if (x >= 91 && x <= 96)
        {
            Instantiate(pickUp[4], transform.position, Quaternion.identity);
        }
        else if (x >= 21 && x <= 22)
        {
            Instantiate(pickUp[5], transform.position, Quaternion.identity);
        }
    }
    public IEnumerator kill(){
        yield return new WaitForSeconds(1);
        int PH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currenthealth;
    }
}
