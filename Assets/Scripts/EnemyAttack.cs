using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public int DamageToPlayer;
    private Coroutine attackRoutine;
    public float attackDelay;
	private float counter;

	void Start () {
		counter = attackDelay;
	}
    public void OnCollisionEnter(Collision go)
    {
        if (go.gameObject.CompareTag("Player"))
        {
            attackRoutine = StartCoroutine(Attack(go.gameObject));

        }
    }
    void OnCollisionExit(Collision go)
    {
        if (go.gameObject.CompareTag("Player"))
        {
            if (attackRoutine != null) StopCoroutine(attackRoutine);
        }
    }
    private IEnumerator Attack(GameObject Player)
    {
        while (true)
        {
            PlayerHealth ph = Player.GetComponent<PlayerHealth>();
            if (counter >= attackDelay) {
				if (ph)
            	{	
                	ph.DealDamage(DamageToPlayer);
            	}
				counter = 0;
			} else counter ++;
            yield return new WaitForSeconds(1);
        }
    }

}
