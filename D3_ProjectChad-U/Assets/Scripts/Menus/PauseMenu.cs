using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PauseMenu : MonoBehaviour
{
    private InputManager inputManager;

    private bool isPaused = false;

    [SerializeField]
    private CinemachineInputProvider cip;
    private InputActionReference iar;

    [SerializeField]
    private GameObject monster;

    private void Start()
    {
        inputManager = InputManager.Instance;
        iar = cip.XYAxis;
        monster = GameObject.FindGameObjectWithTag("Enemy");
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
            inputManager.enabled = true;
            cip.XYAxis = iar;
            if (monster != null)
                monster.GetComponent<NavMeshAgent>().speed = 0f;

        } else
        {
            isPaused = !isPaused;
            inputManager.enabled = false;
            cip.XYAxis = null;
            if (monster != null)
                monster.GetComponent<NavMeshAgent>().speed = 5f;
        }
    }

}
