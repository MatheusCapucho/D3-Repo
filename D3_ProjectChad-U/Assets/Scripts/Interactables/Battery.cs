using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : InteractableBase
{
    private Transform cameraTransform;
    private Rigidbody rb;

    private bool isHolding = false;

    private void Awake()
    {
        cameraTransform = GameObject.Find("CameraScript").transform;
        rb = GetComponent<Rigidbody>();
    }
    protected override void Interact()
    {
        if (!isHolding)
        {
            isHolding = !isHolding;
            rb.useGravity = false;
            rb.drag = 5f;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            transform.parent = cameraTransform;
            
        } else
        {
            isHolding = !isHolding;
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            transform.parent = null;
           
        }
    }

    private void Update()
    {
        if (isHolding)
        {
            MoveAlong();
        }
    }

    private void MoveAlong()
    {
        if (Vector3.Distance(cameraTransform.position, rb.position) > 0.1f)
        {
            Vector3 dir = cameraTransform.position - rb.position;
            rb.AddForce(dir * 150f);
        }
    }

}
