using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth,currenthealth;
	public GameObject gameController;
	public Text healthDisplay;
	private string maxHealthDisplay,currentHealthDisplay;
	public GameObject[] players;
	

	// Use this for initialization
	void Start () {
		currenthealth = maxHealth;
		maxHealthDisplay = maxHealth.ToString();
		players[12].SetActive(false);
	}
	void Update () {
		currentHealthDisplay = currenthealth.ToString();
		healthDisplay.text = "Health" + currentHealthDisplay + "/" + maxHealthDisplay;
	}
	public void DealDamage (int Damage) {
		currenthealth -= Damage; 
		if (currenthealth <= 0 ){
		//	gameController.GetComponent<GameManager>().GameOver();
		foreach (GameObject player in players)
		{
			player.SetActive(false);
		}
		players[12].SetActive(true);
		}
	}

	 public void HealthPickUp(int HealthAdd) {
		currenthealth += HealthAdd;
		if (currenthealth > maxHealth){
			currenthealth = maxHealth;
		}
	}
}
