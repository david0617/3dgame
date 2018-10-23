using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {
	public int Health;

		public void OnCollisionEnter(Collision go) {
		PlayerHealth ph = go.gameObject.GetComponent<PlayerHealth>();
		if (ph != null){
			ph.HealthPickUp(Health);
		}
	}
}
