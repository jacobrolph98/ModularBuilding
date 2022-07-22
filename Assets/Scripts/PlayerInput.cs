using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput
{
    public bool InputMouseLocked
    {
        get;
        private set;
    }

    public Vector2 MousePosition
    {
        get { return Mouse.current.position.ReadValue(); }
    }

    public Vector2 InputMoveVector
    {
        get;
        private set;
    }

    public Vector2 MouseMoveVector
    {
        get;
        private set;
    }
    
    public float InputVerticality
    {
        get;
        private set;
    }

    private PlayerInputActions playerInputActions;
    private PlayerController controller;

    /// <summary>
    /// Hook methods to input actions set up
    /// </summary>
    public PlayerInput(PlayerController control)
    {
        controller = control;
        playerInputActions = new PlayerInputActions();
        // Update properties to be read by player
        playerInputActions.CameraControl.Movement.performed += context => InputMoveVector = context.ReadValue<Vector2>();
        playerInputActions.CameraControl.Movement.canceled += context => InputMoveVector = context.ReadValue<Vector2>();
        playerInputActions.CameraControl.MouseMove.performed += context => MouseMoveVector = context.ReadValue<Vector2>();
        playerInputActions.CameraControl.MouseMove.canceled += context => MouseMoveVector = context.ReadValue<Vector2>();
        playerInputActions.CameraControl.Verticality.performed += context => InputVerticality = context.ReadValue<float>();
        playerInputActions.CameraControl.Verticality.canceled += context => InputVerticality = context.ReadValue<float>();
        // Call methods to trigger behaviours
        playerInputActions.CameraControl.ShapeMenu.performed += MenuButtonPressed;
        playerInputActions.CameraControl.Interact.performed += InteractPressed;
        playerInputActions.CameraControl.Interact.canceled += InteractReleased;
        playerInputActions.CameraControl.LockAndMove.performed += LockCursor;
        playerInputActions.CameraControl.LockAndMove.canceled += UnlockCursor;

    }

    /// <summary>
    /// Toggle whether to enable user input
    /// </summary>
    /// <param name="val">Whether to enable</param>
    public void SetInputEnabled(bool val)
    {
        if (val)
            playerInputActions.CameraControl.Enable();
        else
            playerInputActions.CameraControl.Disable();
    }

    /// <summary>
    /// User pressed Shape Menu
    /// </summary>
    private void MenuButtonPressed(InputAction.CallbackContext obj)
    {
        controller.ShapeMenuPressed();
    }

    /// <summary>
    /// User is beginning interaction
    /// </summary>
    private void InteractPressed(InputAction.CallbackContext obj)
    {
        controller.InteractPressed();
    }

    /// <summary>
    /// User is ending interaction
    /// </summary>
    private void InteractReleased(InputAction.CallbackContext obj)
    {
        controller.InteractReleased();
    }

    /// <summary>
    /// User is beginning lock
    /// </summary>
    private void LockCursor(InputAction.CallbackContext obj)
    {
        controller.LockCursor();
    }

    /// <summary>
    /// User is ending lock
    /// </summary>
    private void UnlockCursor(InputAction.CallbackContext obj)
    {
        controller.UnlockCursor();
    }
}
