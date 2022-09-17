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
        if (inputManager.NextScene())
            Next();
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Next()
    {
        if (SceneManager.sceneCount == 2)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(SceneManager.sceneCount + 1);

    }
}
