using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private InputManager inputManager;
    private void Start()
    {
        inputManager = InputManager.Instance;
    }
    void Update()
    {
        if (inputManager.RestartScene())
            Restart();
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
