using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour {
 public void OnTriggerEnter(Collider go){
	  Weapon weapon = go.gameObject.GetComponent<Weapon>();
	  weapon.PickUp();
 }
}
