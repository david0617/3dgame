using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int damage;
    public bool canAttack;
    private Animator animator;
    private Collider boxCollider;
    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        boxCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            animator.SetTrigger("Attack");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        EnemyHealth eh = other.gameObject.GetComponent<EnemyHealth>();
        BossHealth bh = other.gameObject.GetComponent<BossHealth>();
        if (eh != null)
        {
            eh.dealDamage(damage);
        }
        if (bh != null)
        {
            bh.dealDamage(damage);
        }
    }
    void OnEnable()
    {
        canAttack = true;
    }
}
