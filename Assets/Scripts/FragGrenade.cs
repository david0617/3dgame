using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragGrenade : MonoBehaviour {
	public float delay;
	public float radius;
	public int Damage;
	public int ExplodeDamage;
	public float AddExplosionForce;
	// Use this for initialization
	void Start () {
		StartCoroutine(Timer());
	}

	void Update () {
		/* if (Input.GetButtonDown("Fire1")){
			StartCoroutine(Timer());
		}*/
	}

	private IEnumerator Timer(){
		yield return new WaitForSeconds(delay);
		Explode();
	}

	public void Explode() {
		Collider[] colliders =  Physics.OverlapSphere(transform.position, radius); 
		foreach (Collider c in colliders){
			Rigidbody r = c.GetComponent<Rigidbody>();
			if (r) r.AddExplosionForce(AddExplosionForce,transform.position,radius);

			EnemyHealth eh = c.gameObject.GetComponent<EnemyHealth>();
			if (eh != null){
				eh.dealDamage(ExplodeDamage);
			}
		}
		Destroy(gameObject);
	}
	public void OnCollisionEnter(Collision go){
		EnemyHealth eh = go.gameObject.GetComponent<EnemyHealth>();
		if (eh != null){
			eh.dealDamage(Damage);
		} 
	}
}
