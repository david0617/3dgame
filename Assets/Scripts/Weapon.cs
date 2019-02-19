using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string wepName;
    public Camera mainCamera;
    public GameObject ammo,spawnPoint;
    private bool canFire = true;
    public float fireingTimer;
    public int maxAmmocount,ammocount,reloadTimer,speed,ammoPickUP,maxBulletCount,BulletCount;
    public bool reloading = false;
    private int reloadCount;
    private Animator animator;

    private void Start()
    {
        ammocount = maxAmmocount;
        BulletCount = maxBulletCount;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1") && canFire && ammocount > 0)
        {
            FireBullet();
            animator.SetTrigger("Shoot");
            ammocount -= 1;
            StartCoroutine (FireTimer());
        } else if (Input.GetButtonDown("Reload") && !reloading){
            StartCoroutine (ReloadTimer());
        } else if (ammocount == 0 && !reloading) {
            StartCoroutine (ReloadTimer());
        }
    }

    private void FireBullet()
    {
        Quaternion rotation = mainCamera.transform.rotation;
        GameObject ammoObj = Instantiate(ammo, spawnPoint.transform.position, rotation);
        ammoObj.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * speed, ForceMode.Force);
    }
   
    private IEnumerator FireTimer(){
        canFire = false;
        yield return new WaitForSeconds (fireingTimer);
        canFire = true;
    }

    private IEnumerator ReloadTimer() {
        if(ammocount > 0){
            reloading = true;
            reloadCount =  0;
            while (ammocount < maxAmmocount){
                ammocount ++;
                reloadCount ++;
            }
            yield return new WaitForSeconds (reloadTimer);
            BulletCount -= reloadCount;
            reloading = false;            
        }else if (BulletCount > maxAmmocount) {
            reloading = true;
            yield return new WaitForSeconds (reloadTimer);
            ammocount = maxAmmocount;
            BulletCount -= maxAmmocount;
            reloading = false;
        }else if(BulletCount > 0){
            reloading = true;
            yield return new WaitForSeconds (reloadTimer);
            ammocount = BulletCount;
            BulletCount -= BulletCount;
            reloading = false;
        }
    
    }
    public void PickUp() {
        BulletCount += ammoPickUP;
        if (BulletCount > maxBulletCount){
            BulletCount = maxBulletCount;
        }
    } 
    
	void OnEnable(){
		reloading = false;
        canFire = true;
	}   
}