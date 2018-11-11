using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour {
	public float fireDealy;
	public int damage, speed; 
	public float spread;
	private bool canFire = true;
	public GameObject ammo,spawnPoint;
	private RangedAIMove moveScript;

	// Use this for initialization
	void Start () {
		moveScript = this.GetComponent<RangedAIMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if (moveScript.ReadyToAttack() && canFire){
			FireBullet();
			StartCoroutine(FireTimer());
		} 
	}
	private void FireBullet()
    {
        Quaternion rotation = transform.rotation;
        GameObject ammoObj = Instantiate(ammo, spawnPoint.transform.position, rotation);
        ammoObj.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Force);
	}
	   private IEnumerator FireTimer(){
        canFire = false;
        yield return new WaitForSeconds (fireDealy);
        canFire = true;
    }
}
