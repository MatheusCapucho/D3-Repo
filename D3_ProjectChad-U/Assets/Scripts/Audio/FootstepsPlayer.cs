using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsPlayer : MonoBehaviour
{
    private InputManager inputManager;
    private AudioManager audioManager;
    void Start()
    {
        inputManager = InputManager.Instance;
        audioManager = AudioManager.instance;
    }
    void Update()
    {
        if(inputManager.GetMovement().magnitude < 0.1)
        {
            audioManager.StopSound("PlayerFootsteps");
        } else if (!audioManager.IsPlaying("PlayerFootsteps"))
        {
            audioManager.PlaySound("PlayerFootsteps");
        }
    }
}
