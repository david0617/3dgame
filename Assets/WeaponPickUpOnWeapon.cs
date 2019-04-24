using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUpOnWeapon : MonoBehaviour
{
     public void OnTriggerEnter(Collider go)
    {
        PlayerHealth ph = go.gameObject.GetComponent<PlayerHealth>();
        if (ph != null)
        {
			Destroy(gameObject);
        }
    }
}
