using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowarsAttack : MonoBehaviour {
	public int EnemyAttackTime;
	public GameObject Ammo;
	private bool CanFire = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public IEnumerator EnemyAttack(){
		CanFire = false;
		yield return new WaitForSeconds(EnemyAttackTime);
		CanFire = true;
	}
}
