using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private bool _isGrounded;

    [SerializeField]
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    private InputManager inputManager;
    private Transform cameraTransform;

    private void Start()
    {
        inputManager = InputManager.Instance;
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        _isGrounded = controller.isGrounded;
        MovePlayer();       
    }

    private void MovePlayer()
    {
        var input = inputManager.GetMovement();
        Vector3 move = new Vector3(input.x, 0f, input.y);
        move = cameraTransform.right * move.x + cameraTransform.forward * move.z;
        move.y = 0f;
       
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
