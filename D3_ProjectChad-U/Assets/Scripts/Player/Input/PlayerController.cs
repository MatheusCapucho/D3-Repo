using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private bool _isGrounded;

    [SerializeField]
    private float playerSpeed;

    private InputManager inputManager;
    private Transform cameraTransform;

    private void Start()
    {
        inputManager = InputManager.Instance;
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        cameraTransform.position = transform.position;
    }

    void Update()
    {
        _isGrounded = controller.isGrounded;
        MovePlayer();
        Rotate();

    }

    private void Rotate()
    {
        var look = inputManager.GetMouseDelta();

        transform.rotation = Quaternion.Euler(look.x, look.y, 0f);

    }

    private void MovePlayer()
    {
        var input = inputManager.GetMovement();
        
        Vector3 move = new Vector3(input.x, 0f, input.y);
        move = cameraTransform.right.normalized * move.x + cameraTransform.forward.normalized * move.z;
        move.y = -1f;
       
        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
