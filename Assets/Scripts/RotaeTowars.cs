using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaeTowars : MonoBehaviour {
	private Transform target;
	public float speed;
	// Use this for initialization
	void Start () {
		target  = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt(target); 
		Vector3 targetDirection = target.position - transform.position;
		Vector3 currentDirection  = transform.forward;

		float step = speed * Time.deltaTime;

		Vector3 newDir =  Vector3.RotateTowards(currentDirection, targetDirection, step, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDir);
	}
}
