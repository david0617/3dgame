using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickUp : MonoBehaviour
{
    public void OnTriggerEnter(Collider go)
    {
        if (go.CompareTag("weapon1"))
        {
            GameObject.Find("WeponManager").GetComponent<WeaponManager>().weapon1 = true;
        }
        if (go.CompareTag("weapon2"))
        {
            GameObject.Find("WeponManager").GetComponent<WeaponManager>().weapon2 = true;
        }
        if (go.CompareTag("weapon3"))
        {
            GameObject.Find("WeponManager").GetComponent<WeaponManager>().weapon3 = true;
        }
    }
}
