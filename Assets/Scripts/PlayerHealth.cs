using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth;
	private int currenthealth;
	private GameObject gameController;

	// Use this for initialization
	void Start () {
		currenthealth = maxHealth;
		gameController = GameObject.FindGameObjectWithTag("GameController");
	}
	
	public void DealDamage (int Damage) {
		currenthealth -= Damage; 
		if (currenthealth <= 0 ){
			Destroy(gameObject);
			gameController.GetComponent<GameManager>().GameOver();
		}
	}
}
