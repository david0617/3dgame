using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public int health;
	public GameObject objToSpawn;	
	public void dealDamage(int damage){
		health -= damage;
		if (health <= 0){
			Instantiate(objToSpawn, transform.position, Quaternion.identity);
			Destroyssequence();
		}
	}

	public void Destroyssequence(){
		Destroy(gameObject);
	}
}
