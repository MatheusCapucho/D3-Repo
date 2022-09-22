using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFeedback : MonoBehaviour
{
    private Camera cam;
    private InputManager inputManager;
    void Start()
    {
        cam = Camera.main;
        inputManager = InputManager.Instance;
    }
    void LateUpdate()
    {
        
    }
}
