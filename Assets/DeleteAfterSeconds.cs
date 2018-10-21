using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterSeconds : MonoBehaviour {
    public float delay;

	// Use this for initialization
	void Start () {
        Invoke("DestroyThis", delay);
	}

    private void DestroyThis() {
        Destroy(this.gameObject);
    }
}
