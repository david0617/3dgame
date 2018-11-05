﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour {
 public void OnTriggerEnter(Collider go){
		if (go.CompareTag("Player")){
			go.BroadcastMessage("AddclipToSelectedWeapon",SendMessageOptions.RequireReceiver);
			Destroy(gameObject);
		}
 	}
}
