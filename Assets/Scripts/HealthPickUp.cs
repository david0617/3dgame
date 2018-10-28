using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int Health;

    public void OnTriggerEnter(Collider go)
    {
        PlayerHealth ph = go.gameObject.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.HealthPickUp(Health);
			Destroy(gameObject);
        }
    }
}
