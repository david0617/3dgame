using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmo : MonoBehaviour {
	public int timer;
	public int Damage;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, timer);
	}

	public void OnTriggerEnter(Collider go){
		PlayerHealth ph = go.gameObject.GetComponent<PlayerHealth>();
		if (ph != null){
			ph.DealDamage(Damage);
		} 
		Destroy(gameObject);
	}
}
