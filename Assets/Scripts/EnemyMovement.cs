using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	NavMeshAgent navMeshAgent;
	GameObject player;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag(ObjectTags.PLAYER);

		
	}
	
	// Update is called once per frame
	void Update () {
		if(player)
		navMeshAgent.SetDestination(player.transform.position);
	}
}
