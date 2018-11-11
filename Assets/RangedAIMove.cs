﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedAIMove : MonoBehaviour {
	public float range;
	private NavMeshAgent nav;
	private GameObject player;
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
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
}
