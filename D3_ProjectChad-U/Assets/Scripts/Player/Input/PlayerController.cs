using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool _isGrounded;

    [SerializeField]
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;

    private InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.Instance;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _isGrounded = controller.isGrounded;
        if (_isGrounded && playerVelocity.y < 0) 
        {          
            playerVelocity.y = 0f;
        }

        MovePlayer();
        
    }

    private void MovePlayer()
    {
        var input = inputManager.GetMovement();
        Vector3 move = new Vector3(input.x, 0f, input.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
            gameObject.transform.forward = move;

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
