using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public int timer;
    public int Damage;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, timer);
    }

    public void OnTriggerEnter(Collider go)
    {
        EnemyHealth eh = go.gameObject.GetComponent<EnemyHealth>();
        BossHealth bh = go.gameObject.GetComponent<BossHealth>();
        if (eh != null)
        {
            eh.dealDamage(Damage);
        }
        if (bh != null)
        {
            bh.dealDamage(Damage);
        }
        Destroy(gameObject);
    }
}
