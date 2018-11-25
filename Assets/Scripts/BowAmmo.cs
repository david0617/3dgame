using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAmmo : MonoBehaviour {
	public int FlyTimer,StopTimer;
	public bool usegravity;
	public int Damage;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		Destroy(gameObject, StopTimer);
		if (usegravity){
			StartCoroutine(AmmoFlyTime());
		}
	}
	
	 public IEnumerator AmmoFlyTime(){
		yield return new WaitForSeconds(FlyTimer);
		rb.useGravity = true;
	}
	

	public void OnTriggerEnter(Collider go){
		PlayerHealth ph = go.gameObject.GetComponent<PlayerHealth>();
		if (ph != null){
			ph.DealDamage(Damage);
		} 
		Destroy(gameObject);
	}
}
