using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    public float sensitivity;
    private GameObject head;
    public float yRotation;
    public Vector3 originalRotation;
	// Use this for initialization
	void Start () {
        head = transform.Find("Head").gameObject;
        originalRotation = transform.localRotation.eulerAngles;
        yRotation = originalRotation.y;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float xspeed = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * xspeed * sensitivity * Time.deltaTime);

        float yspeed = -Input.GetAxis("Mouse Y");
        yRotation += yspeed * sensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -80, 80);

        Quaternion localRotation = Quaternion.Euler(yRotation,0,0);
        head.transform.localRotation = localRotation;
    }
	
}
