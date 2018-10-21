using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour {
	public GameObject grenadePreafab;
	public float throwForce;
	public GameObject spawnPoint;
	private GameObject grenade;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire3")){
			grenade = Instantiate(grenadePreafab, spawnPoint.transform.position, Quaternion.identity);
			grenade.GetComponent<Rigidbody>().isKinematic = true;
			grenade.transform.parent = this.transform;
		}
		else if (Input.GetButtonUp("Fire3") && grenade){
			grenade.GetComponent<Rigidbody>().isKinematic = false;
			grenade.transform.parent = null;
			grenade.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
		}
	}
}
