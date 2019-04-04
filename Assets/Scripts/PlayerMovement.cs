using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6.0F, speedUp, energyUseTime, energyBackTime;
    public int energy;
    private int maxEnergy;
    private float gravity = 20.0F, jumpSpeed = 8.0F;
    private Vector3 moveDirection = Vector3.zero;
    public Text energydisplay;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        maxEnergy = energy;
    }

    void Update()
    {
        if (controller.isGrounded && Input.GetButton("left shift") && energy > 0)
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * speedUp;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        else if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        if (Input.GetButtonDown("left shift"))
        {
            StopAllCoroutines();
            StartCoroutine(Energy());
        }
        if (Input.GetButtonUp("left shift"))
        {
            StopAllCoroutines();
            StartCoroutine(EnergyBack1());
        }
        if (energy > 100)
        {
            StopAllCoroutines();
            energy = 100;
            energydisplay.text = "Energy " + maxEnergy.ToString() + "/" + energy.ToString();
        }
         if (energy < 0)
        {
            energy = 0;
            energydisplay.text = "Energy " + maxEnergy.ToString() + "/" + energy.ToString();
        }
    }
    public IEnumerator Energy()
    {
        yield return new WaitForSeconds(energyUseTime);
        energy--;
        energydisplay.text = "Energy " + maxEnergy.ToString() + "/" + energy.ToString();
        StartCoroutine(Energy());
    }
    public IEnumerator EnergyBack1()
    {
        yield return new WaitForSeconds(energyBackTime);
        StartCoroutine(EnergyBack2());
    }
    public IEnumerator EnergyBack2()
    {
        yield return new WaitForSeconds(1);
        energy++;
        energydisplay.text = "Energy " + maxEnergy.ToString() + "/" + energy.ToString();
        if (energy >= 100)
        {
            StopAllCoroutines();
        }
        StartCoroutine(EnergyBack2());
    }
}
