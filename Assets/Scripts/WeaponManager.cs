﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponManager : MonoBehaviour {
	public GameObject[] weapons;
	private int prevWepIndex = 0;
	private int curWepIndex = 0;
	public Text ammoDisplay;
	public bool weapon1, weapon2, weapon3;
	// Use this for initialization
	void Start () {
		foreach (GameObject weapon in weapons)
		{
			weapon.SetActive(false);
		}
		weapons[0].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchWeapon(0);
		 else if (Input.GetKeyDown(KeyCode.Alpha2) && weapon1 == true) SwitchWeapon(1);
		 else if (Input.GetKeyDown(KeyCode.Alpha3) && weapon2 == true) SwitchWeapon(2);
		 else if (Input.GetKeyDown(KeyCode.Alpha4) && weapon3 == true) SwitchWeapon(3);
		 else if (Input.GetKeyDown(KeyCode.Alpha5)) SwitchWeapon(4);
		 else if (Input.GetKeyDown(KeyCode.Q)) SwitchWeapon(prevWepIndex);

		GameObject activeWeapon = weapons[curWepIndex];
		string ammoCount = activeWeapon.GetComponent<Weapon>().ammocount.ToString();
		string maxBulletCount = activeWeapon.GetComponent<Weapon>().BulletCount.ToString();
		bool reloading = activeWeapon.GetComponent<Weapon>().reloading;
		if (reloading) {
			ammoDisplay.text = "Reloading";
		}else { 
			ammoDisplay.text = "Ammo " + ammoCount + "/" + maxBulletCount;
		}
	}

	private void SwitchWeapon (int index)
	{
		weapons[curWepIndex].SetActive(false);
		prevWepIndex = curWepIndex;
		curWepIndex = index;
		weapons[curWepIndex].SetActive(true);
	}
	public void AddclipToSelectedWeapon(){
		weapons[curWepIndex].GetComponent<Weapon>().PickUp();
	}
}
