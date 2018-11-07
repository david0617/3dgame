using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAmmoBox : MonoBehaviour {
 public void OnTriggerEnter(Collider go){
	if (go.CompareTag("Player")){
			go.BroadcastMessage("PickUp",SendMessageOptions.RequireReceiver);
			Destroy(gameObject);
		}
 	}
}
