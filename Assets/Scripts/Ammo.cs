using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

	public int timer;
	public int Damage;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, timer);
	}

	public void OnTriggerEnter(Collider go){
		EnemyHealth eh = go.gameObject.GetComponent<EnemyHealth>();
		if (eh != null){
			eh.dealDamage(Damage);
		} 
		Destroy(gameObject);
	}
}
