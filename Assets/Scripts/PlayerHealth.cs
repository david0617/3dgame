using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth;
	private int currenthealth,healthAdd,HPU;
	public GameObject gameController;
	public Text healthDisplay;
	private string maxHealthDisplay,currentHealthDisplay;
	

	// Use this for initialization
	void Start () {
		currenthealth = maxHealth;
		maxHealthDisplay = maxHealth.ToString();
	}
	void Update () {
		currentHealthDisplay = currenthealth.ToString();
		healthDisplay.text = "Health" + currentHealthDisplay + "/" + maxHealthDisplay;
	}
	public void DealDamage (int Damage) {
		currenthealth -= Damage; 
		if (currenthealth <= 0 ){
			gameController.GetComponent<GameManager>().GameOver();
		}
	}

	 public void HealthPickUp(int HealthAdd) {
		currenthealth += HealthAdd;
		if (currenthealth > maxHealth){
			currenthealth = maxHealth;
		}
	}
}
