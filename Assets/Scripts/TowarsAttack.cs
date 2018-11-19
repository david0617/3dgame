using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowarsAttack : MonoBehaviour {
	public int EnemyAttackTime;
	public GameObject ammo, spawnPoint;
	public int speed;
	private bool CanFire = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(EnemyAttack());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public IEnumerator EnemyAttack(){
		yield return new WaitForSeconds(EnemyAttackTime);
		FireBullet();
	}
	private void FireBullet()
    {
        Quaternion rotation = spawnPoint.transform.rotation;
        GameObject ammoObj = Instantiate(ammo, spawnPoint.transform.position, rotation);
        ammoObj.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Force);
	}
}
