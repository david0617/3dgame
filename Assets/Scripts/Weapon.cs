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
    /*
    wepname is the name for the weapon
    maincamera is to get the direction the player is facing 
    ammo is the bullet to be spawn in
    spawnpoint is the point where the bullet is spawn
    canfire is use for is the player can attack or not
    fireingtimer is use for a timer between attack
    maxammocount is the max amount ammo the gun can hold
    ammocount is how much ammo the have
    reloadtimer is how long the time reloading take 
    speed is how fast the bullet travel
    ammopickup is how much ammo to add to bulletcount 
    maxbulletcount is how much max amount bullet the player can have
    bulletcount is how much bullet the player have
    reloading is if the gun is reloading or not
    reloadcount is how much ammo is being add to the ammocount
    animator is for animation
    */
    private void Start()
    {
        ammocount = maxAmmocount;
        BulletCount = maxBulletCount;
        animator = GetComponent<Animator>();
    }
    /*
    line 36 is to set the ammocount to maxammocount to make reloding easier to code
    line 37 is to set bulletcount to maxbulletcount to make reloding easierto code
    line 38 is for animation
    */
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
    /*
    line 47 is to make sure ammocount is not 0 and canfire is true.
    line 49-52 is for firing the weapon and it have a delay and whan it fired the ammocount is going down by 1.
    line 53-54 is to reload the weapon manually.
    line 55-56 is to relode the automatically whan the ammocount is at 0
    */


    private void FireBullet()
    {
        Quaternion rotation = mainCamera.transform.rotation;
        GameObject ammoObj = Instantiate(ammo, spawnPoint.transform.position, rotation);
        ammoObj.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * speed, ForceMode.Force);
    }
    /*
    line 69-71 is to spawn the bullet in game
    */
    private IEnumerator FireTimer(){
        canFire = false;
        yield return new WaitForSeconds (fireingTimer);
        canFire = true;
    }
    /*
    line 77-79 is the time between the bullet spawn
    */

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
    /*
    line 86-95 is to reload the weapon whan the ammocount is not at 0 and add just enough for ammocount and maxammocount to be the same and for bulltcount go down the same numder 
    line 96-101 is to reload the weapon whan the ammocount is at 0 and make ammocount and maxammocount the same and bulletcount go down the same numder
    line 102-107 is to reload whan the is not enough to reload a full clip 
    */  
        }
    public void PickUp() {
        BulletCount += ammoPickUP;
        if (BulletCount > maxBulletCount){
            BulletCount = maxBulletCount;
        }
    } 
    /*
    line 116-118 is for whan the player pick up a ammo box for more ammo and to make sure is not over the limit
    */
	void OnEnable(){
		reloading = false;
        canFire = true;
	}
    /*
    line 125-126 is to make sure the weapon can be used whan the player is switching between weapon whan it is reloading
    */
}
/*
The code is used for weapon in the game I'm making
*/