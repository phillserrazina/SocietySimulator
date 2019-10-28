﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    // VARIABLES

    [SerializeField]
    private float mouseSensitivity = 1f;

    private float horDirection;
    private float verDirection;
    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;

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
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);
    }

    private void Move() {
        transform.Rotate(Vector3.up * mouseX);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        rb.MovePosition(transform.position + 
                        (transform.forward * verDirection * movementSpeed * Time.fixedDeltaTime) + 
                        (transform.right * horDirection * movementSpeed * Time.fixedDeltaTime));
    }
}
