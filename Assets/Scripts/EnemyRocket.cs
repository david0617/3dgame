﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour {
	public float radius;
	public int ExplodeDamage;
	public float AddExplosionForce;
	public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
	}

	void Update () {
	}
	public void OnTriggerEnter(Collider go){
		Explode();
	}
	public void Explode() {
		
		Collider[] colliders =  Physics.OverlapSphere(transform.position, radius); 
		foreach (Collider c in colliders){
			Rigidbody r = c.GetComponent<Rigidbody>();
			if (r) r.AddExplosionForce(AddExplosionForce,transform.position,radius);

			PlayerHealth eh = c.gameObject.GetComponent<PlayerHealth>();
			if (eh != null){
				eh.DealDamage(ExplodeDamage);
			}
		}
		Instantiate(explosionPrefab,transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, radius);
	}
}
