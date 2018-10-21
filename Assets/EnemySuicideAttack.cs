using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuicideAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            print(this + " touched the player.");
        }
        print(this + "touched something.");
    }
}
