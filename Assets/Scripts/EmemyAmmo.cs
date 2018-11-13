using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyAmmo : MonoBehaviour {
	public int timer;
	public int Damage;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, timer);
	}

	public void OnTriggerEnter(Collider go){
		PlayerHealth eh = go.gameObject.GetComponent<PlayerHealth>();
		if (eh != null){
			eh.DealDamage(Damage);
		} 
		Destroy(gameObject);
	}
}
