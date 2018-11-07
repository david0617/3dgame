using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBox : MonoBehaviour {
 public void OnTriggerEnter(Collider go){
	if (go.CompareTag("Player")){
			go.BroadcastMessage("addGrenade",SendMessageOptions.RequireReceiver);
			Destroy(gameObject);
		}
 	}

}
