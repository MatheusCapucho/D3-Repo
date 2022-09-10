using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private Camera _cam;

    [SerializeField]
    private float rayDistance = 2f;

    [SerializeField]
    private LayerMask interactableMask;

    private InputManager inputManager;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    void Update()
    {
        transform.rotation = _cam.transform.rotation;
        var ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.blue);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableMask))
        {
            if (hit.collider.GetComponent<InteractableBase>() != null)
            {
                var interactable = hit.collider.GetComponent<InteractableBase>();

                if (inputManager.MouseClicked())
                    interactable.BaseInteract();
            }
        }
    }
}
