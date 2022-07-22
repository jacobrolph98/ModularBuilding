using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f, rotateSensitivity = 5f;

    [SerializeField]
    private ShapeMenuController shapeMenuController;

    [SerializeField]
    private ShapeModifier modifier;

    private PlayerInput input;
    private GameObject cameraObject;
    private new Camera camera;  //  new because MonoBehaviour contains a deprecated reference to camera

    // VARIABLES
    private float inputVerticality; // player Q/E input
    private Vector2 inputMoveVector, mouseMoveVector;
    private Vector3 velocity = new Vector3(0, 0, 0), rotate = new Vector3(0, 0, 0);

    private bool IsCursorLocked
    {
        get { return Cursor.lockState == CursorLockMode.Locked; }
        set { Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None; }
    }

    private bool IsMouseOverUI
    {
        get { return EventSystem.current.IsPointerOverGameObject(); }
    }

    /// <summary>
    /// Open or close shape menu
    /// </summary>
    public void ShapeMenuPressed()
    {
        shapeMenuController.ShapeMenuVisible = !shapeMenuController.ShapeMenuVisible; // Toggle shape menu 
    }

    /// <summary>
    /// Register a user click
    /// </summary>
    public void InteractPressed()
    {
        if (!IsMouseOverUI) // Mouse is over the environment
            modifier.Click(input.MousePosition);
    }

    /// <summary>
    ///  Register user releasing click
    /// </summary>
    public void InteractReleased()
    {
        modifier.Release();
    }

    /// <summary>
    /// Lock cursor for camera rotation
    /// </summary>
    public void LockCursor()
    {
        IsCursorLocked = true;
    }

    /// <summary>
    /// Unlock cursor to end rotation
    /// </summary>
    public void UnlockCursor()
    {
        IsCursorLocked = false;
    }

    /// <summary>
    ///  Initialization
    /// </summary>
    private void Start()
    {
        input = new PlayerInput(this);
        cameraObject = gameObject.transform.Find("MainCamera").gameObject;
        camera = cameraObject.GetComponent<Camera>();
        input.SetInputEnabled(true);
        modifier.Setup();
    }

    /// <summary>
    /// Regularly poll user input and update accordingly
    /// </summary>
    private void Update() // Called every frame (variable)
    {
        UpdateInputs();
        UpdateMovement();
        if (IsCursorLocked) //Only rotate when cursor locked
            UpdateRotation();
    }

    /// <summary>
    /// Less regularly update shape modifier about mouse position when dragging
    /// </summary>
    private void FixedUpdate() // Called every physics tick (1/50th second / 0.02)
    {
        if (modifier.IsObjectSelected && modifier.IsDragging)
            modifier.UpdateMouse(input.MousePosition);
    }

    #region Update Functions

    /// <summary>
    /// Refresh player's references to input values
    /// </summary>
    private void UpdateInputs()
    {
        inputVerticality = input.InputVerticality;
        inputMoveVector = input.InputMoveVector;
        mouseMoveVector = input.MouseMoveVector;
    }

    /// <summary>
    /// Move player object according to player input
    /// </summary>
    private void UpdateMovement()
    {
        // Time.deltaTime is time since last frame
        velocity = new Vector3(0, 0, 0);
        velocity = velocity + cameraObject.transform.forward * moveSpeed * Time.deltaTime * inputMoveVector.y;
        velocity = velocity + cameraObject.transform.up * moveSpeed * Time.deltaTime * inputVerticality;
        velocity = velocity + cameraObject.transform.right * moveSpeed * Time.deltaTime * inputMoveVector.x;
        transform.position = transform.position + velocity;
    }

    /// <summary>
    /// Rotate player object according to mouse input
    /// </summary>
    private void UpdateRotation()
    {
        // Time.deltaTime is time since last frame
        rotate.y = -mouseMoveVector.x * rotateSensitivity * Time.deltaTime;
        rotate.x = mouseMoveVector.y * rotateSensitivity * Time.deltaTime;
        transform.eulerAngles = transform.eulerAngles - rotate;
    }

    #endregion

}
