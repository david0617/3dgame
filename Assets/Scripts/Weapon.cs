﻿using System.Collections;
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
    
    private void Start()
    {
        ammocount = maxAmmocount;
        BulletCount = maxBulletCount;
    }
 
    private void Update()
    {
        if (Input.GetButton("Fire1") && canFire && ammocount > 0)
        {
            FireBullet();
            ammocount -= 1;
            StartCoroutine (FireTimer());
        } else if (Input.GetButtonDown("Reload") && !reloading){
            StartCoroutine (ReloadTimer());
            print ("reload");
        } else if (ammocount == 0 && !reloading) {
            StartCoroutine (ReloadTimer());
            print ("reload");
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
        if (BulletCount > maxAmmocount ) {
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
}
/* if (Input.GetButtonDown("Fire1")) {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range)) {
            print(hit.transform.name);
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            print(hit.collider.gameObject.name);
        }
    }*/
