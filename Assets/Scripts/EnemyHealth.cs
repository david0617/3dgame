using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public int health;
	
	public void dealDamage(int damage){
		health -= damage;
		if (health <= 0){
			Destroyssequence();
		}
	}

	public void Destroyssequence(){
		Destroy(gameObject);
	}

}
