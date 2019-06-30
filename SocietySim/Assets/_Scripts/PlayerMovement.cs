using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    // VARIABLES

    [SerializeField]
    private float MouseSensitivity = 1f;

    private float horDirection;
    private float verDirection;
    private float mouseX;
    private float mouseY;

    private Rigidbody rb;

    // EXECUTION METHODS

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Update () {
        GetInput();
    }

    private void FixedUpdate() {
        Move();
    }

    // METHODS

    private void GetInput() {
        horDirection = Input.GetAxis("Horizontal");
        verDirection = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    private void Move() {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, mouseX * MouseSensitivity, 0)));
        rb.MovePosition(transform.position + (transform.forward * verDirection * movementSpeed) + (transform.right * horDirection * movementSpeed));
    }
}
