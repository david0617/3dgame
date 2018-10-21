using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
	public GameObject[] weapons;
	private int prevWepIndex = 0;
	private int curWepIndex = 0;
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
		 else if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchWeapon(1);
		 else if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchWeapon(2);
		 else if (Input.GetKeyDown(KeyCode.Alpha4)) SwitchWeapon(3);
		 //else if (Input.GetKeyDown(KeyCode.Alpha5)) SwitchWeapon(4);
		 else if (Input.GetKeyDown(KeyCode.Q)) SwitchWeapon(prevWepIndex);
	}

	private void SwitchWeapon (int index)
	{
		weapons[curWepIndex].SetActive(false);
		prevWepIndex = curWepIndex;
		curWepIndex = index;
		weapons[curWepIndex].SetActive(true);
	}
}
