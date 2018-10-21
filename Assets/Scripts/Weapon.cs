using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string wepName;
    public Camera mainCamera;
    public GameObject ammo;
    public int speed;
    private bool canFire = true;
    public float fireingTimer;
    public int reloadTimer;
    public int maxAmmocount;
    private int ammocount;
    private bool reloading = true;
    
    private void Start()
    {
        ammocount = maxAmmocount;
    }
 
    private void Update()
    {
        if (Input.GetButton("Fire1") && canFire && ammocount > 0)
        {
            FireBullet();
            ammocount -= 1;
            StartCoroutine (FireTimer());
        } else if (Input.GetButtonDown("Reload") && reloading){
            StartCoroutine (ReloadTimer());
            print ("reload");
        } else if (ammocount == 0 && reloading) {
            StartCoroutine (ReloadTimer());
            print ("reload");
        }
    }
    private void FireBullet()
    {
        Quaternion rotation = mainCamera.transform.rotation;
        GameObject ammoObj = Instantiate(ammo, transform.position, rotation);
        ammoObj.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * speed, ForceMode.Force);
    }

    private IEnumerator FireTimer(){
        canFire = false;
        yield return new WaitForSeconds (fireingTimer);
        canFire = true;
    }

    private IEnumerator ReloadTimer() {
        reloading = false;
        yield return new WaitForSeconds (reloadTimer);
        ammocount = maxAmmocount;
        reloading = true;
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
