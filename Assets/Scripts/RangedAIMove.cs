using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedAIMove : MonoBehaviour {
	public float range,speed;
	private NavMeshAgent nav;
	private GameObject player;
	public Transform target;
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
		if(ReadyToAttack()){
			nav.isStopped = true;
		}else {
			nav.isStopped = false;
			nav.SetDestination(player.transform.position);
		}
	}

	public bool ReadyToAttack(){
		return WithInRange() && CanSeePlayer();
	}

	private bool WithInRange(){
		return(Vector3.Distance(transform.position, player.transform.position) <= range);
	}

	private bool CanSeePlayer() {
		RaycastHit hit;
		Vector3 dir = (player.transform.position - transform.position).normalized;
		if (Physics.Raycast(transform.position, dir, out hit, range)){
			if (hit.collider.CompareTag("Player")) return true;
		}
		return false;
	}
	/* private void LookAtPlayer(){
		Vector3 targetDirection = target.position - transform.position;
		Vector3 currentDirection  = transform.forward;

		float step = speed * Time.deltaTime;

		Vector3 newDir =  Vector3.RotateTowards(currentDirection, targetDirection, step, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDir);
	}*/
}
