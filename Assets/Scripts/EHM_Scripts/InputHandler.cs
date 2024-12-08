using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;
    public InputManager inputManager;
    public InputManager.PlayerActions playerActions;
    public Vector2 movementInput;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        inputManager = new InputManager();
        playerActions = inputManager.Player;
    }

    private void Update()
    {
        movementInput = inputManager.Player.Movement.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        playerActions.Enable();
        // Debug.Log("  _inGameActions.Enable();");
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
    public Vector2 GetMovementInputNormalized() => movementInput.normalized;
}