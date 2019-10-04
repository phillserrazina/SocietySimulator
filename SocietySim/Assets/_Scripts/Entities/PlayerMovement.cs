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
    private Camera playerCamera;

    // EXECUTION METHODS

    private void Start() {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
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
        playerCamera.transform.Rotate(new Vector3(mouseY * MouseSensitivity, 0, 0));
        rb.MovePosition(transform.position + 
                        (transform.forward * verDirection * movementSpeed * Time.fixedDeltaTime) + 
                        (transform.right * horDirection * movementSpeed * Time.fixedDeltaTime));
    }
}
