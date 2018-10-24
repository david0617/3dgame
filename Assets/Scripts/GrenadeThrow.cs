using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeThrow : MonoBehaviour {
	public GameObject grenadePreafab;
	public float throwForce;
	public GameObject spawnPoint;
	private GameObject grenade;
	public int maxgrenade;
	private int currentGrenade;
	public Text grenadeDisplay;
	string maxgrenadecount;

	void Start () {
		currentGrenade = maxgrenade;
		maxgrenadecount = maxgrenade.ToString();
	}
	void Update () {
		if (Input.GetButtonDown("Fire3") && currentGrenade > 0){
			grenade = Instantiate(grenadePreafab, spawnPoint.transform.position, Quaternion.identity);
			grenade.GetComponent<Rigidbody>().isKinematic = true;
			grenade.transform.parent = this.transform;
			currentGrenade --;
		}
		else if (Input.GetButtonUp("Fire3") && grenade){
			grenade.GetComponent<Rigidbody>().isKinematic = false;
			grenade.transform.parent = null;
			grenade.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
		}
	string grenadecount = currentGrenade.ToString();
	grenadeDisplay.text = "Grenade" + maxgrenadecount + "/" + grenadecount;

	}
}
