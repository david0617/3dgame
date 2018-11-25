using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DsetroyWhenDone : MonoBehaviour {
	ParticleSystem ps;
	// Use this for initialization
	void Start () {
		ps =  GetComponent<ParticleSystem>();
		print(ps.main.duration);
		StartCoroutine(DestroyAfterDelay(ps.main.duration));
	}
	
	IEnumerator DestroyAfterDelay(float delay){
		yield return new WaitForSeconds(delay);
		Destroy(gameObject);
	}
}
