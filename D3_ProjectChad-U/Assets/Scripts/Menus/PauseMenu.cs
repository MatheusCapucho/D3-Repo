using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private InputManager inputManager;

    private bool isPaused = false;
    [SerializeField]
    private CinemachineInputProvider cip;
    private InputActionReference iar;

    public static PauseMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject, 2f);
            return;
        }


        DontDestroyOnLoad(gameObject);
    }

        private void Start()
    {
        inputManager = InputManager.Instance;
        iar = cip.XYAxis; 
    }
    void Update()
    {
        if (inputManager.PauseGame())
            Pause();
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
        int index = SceneManager.GetActiveScene().buildIndex;
        if (SceneManager.GetActiveScene().buildIndex > 3)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(1+index);

    }
    public void Pause()
    {
        if (isPaused)
        {
            isPaused = !isPaused;
            Time.timeScale = 0f;
            inputManager.enabled = true;
            cip.XYAxis = iar;

        } else
        {
            isPaused = !isPaused;
            Time.timeScale = 1f;
            inputManager.enabled = false;
            cip.XYAxis = null;
        }
    }

}
