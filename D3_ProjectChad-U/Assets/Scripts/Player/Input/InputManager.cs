using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private static InputManager _instance;
    public static InputManager Instance => _instance;

    private PlayerInput playerInput;

    #region Initialization

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    #endregion

    #region Helper Functions

    public Vector2 GetMovement() => playerInput.Player.Movement.ReadValue<Vector2>();
    public Vector2 GetMouseDelta() => playerInput.Player.Look.ReadValue<Vector2>();
    public Vector2 GetMousePosition() => playerInput.Player.MousePosition.ReadValue<Vector2>();
    public bool MouseClicked() => playerInput.Player.Click.triggered;
    public bool RestartScene() => playerInput.Player.RestartScene.triggered;
    public bool NextScene() => playerInput.Player.NextScene.triggered;
    public bool PauseGame() => playerInput.Player.Pause.triggered;

    #endregion

}
