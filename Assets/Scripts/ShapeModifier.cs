using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShapeModifier
{
    [Range(0.0f, 5.0f)]
    public float gridSize;
    public bool protrude;
    public bool IsObjectSelected
    {
        get { return selectedObject != null; }
    }

    public bool EditorUiVisible
    {
        get { return editor.IsUIVisible; }
        set { editor.IsUIVisible = value; }
    }

    public bool IsDragging
    {
        get;
        private set;
    } = false;

    [SerializeField]
    private Material selectMaterial, defaultMaterial;

    [SerializeField]
    private ShapeEditorController editor;
    [SerializeField]
    private ModifierController modifierSettings;

    private GameObject selectedObject = null;
    private Collider selectedCollider = null;
    private PrimitiveType objectShape;

    // DEBUGGING
    private Debugger debugger = new Debugger(false); // easily toggle console output debugging

    public void Setup()
    {
        editor.modifier = this;
        modifierSettings.modifier = this;
        modifierSettings.Setup();
    }

    /// <summary>
    /// Get Vector3 data from selected object
    /// </summary>
    /// <param name="type">Which vector value to grab</param>
    /// <returns>Vector3</returns>
    public Vector3 GetObjectVector(VectorType type)
    {
        switch (type)
        {
            case VectorType.Position:
                return selectedObject.transform.position;
            case VectorType.Rotation:
                return selectedObject.transform.localEulerAngles;
            case VectorType.Scale:
                return selectedObject.transform.localScale;
        }
        return new Vector3(0, 0, 0);
    }

    /// <summary>
    /// Set Vector3 data on selected object
    /// </summary>
    /// <param name="value"> Value to set</param>
    /// <param name="type"> Which value to set</param>
    public void SetObjectVector(Vector3 value, VectorType type)
    {
        switch (type)
        {
            case VectorType.Position:
                selectedObject.transform.position = value;
                break;
            case VectorType.Rotation:
                selectedObject.transform.localRotation = Quaternion.Euler(value); // Unity stores rotations as Quaternion rather than (the more readable) Euler, to avoid Gimbal Lock 
                break;
            case VectorType.Scale:
                selectedObject.transform.localScale = value;
                break;
        }
    }

    /// <summary>
    /// Remove object from world space
    /// </summary>
    public void DeleteObject()
    {
        GameObject.Destroy(selectedObject);
    }

    /// <summary>
    /// Place clone of selected object above, and select it
    /// </summary>
    public void CopyObject()
    {
        GameObject newObject = GameObject.Instantiate(selectedObject);
        newObject.transform.position = selectedObject.transform.position + new Vector3(0, 1, 0);
        SetObject(newObject);
    }

    /// <summary>
    /// Register mouse click
    /// </summary>
    /// <param name="mousePosition">Mouse position on screen</param>
    public void Click(Vector2 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition); // Casts ray from camera to world space
        RaycastHit mouseRayHit;
        if (Physics.Raycast(ray, out mouseRayHit, 100)) // If any object was hit by ray
            ClickObject(mouseRayHit);
        else
            ClickPosition();
    }

    /// <summary>
    /// Let go of mouse
    /// </summary>
    public void Release()
    {
        if (IsDragging)
            debugger.Log("Stop dragging object");
        IsDragging = false;
        if (IsObjectSelected)
            selectedObject.layer = 0; // Allow raycasts to detect this object again
    }

    /// <summary>
    /// Provide mouse position input to raycast from screen into world
    /// </summary>
    /// <param name="mousePosition">Mouse position on the screen</param>
    /// <param name="castShape">Whether to cast shape or ray. Ray casting results in shape placement being based on center of object</param>
    public void UpdateMouse(Vector2 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Vector3 mouseWorldPos = GetCastPosition(ray);
        selectedObject.transform.position = mouseWorldPos;
        editor.UpdateLabels();
    }

    /// <summary>
    /// Round vector values to grid size
    /// </summary>
    /// <param name="value">Vector3 value to round</param>
    /// <returns>Rounded vector3</returns>
    private Vector3 RoundVectorToGrid(Vector3 value)
    {
        return new Vector3
            (
                Mathf.Round(value.x / gridSize) * gridSize,
                Mathf.Round(value.y / gridSize) * gridSize,
                Mathf.Round(value.z / gridSize) * gridSize
            );
    }

    /// <summary>
    /// Get position after raycasting and protrusion
    /// </summary>
    /// <param name="ray">Initial ray that stores origin and direction</param>
    /// <returns>Position of ray hit after applying protrusion if applicable</returns>
    private Vector3 GetCastPosition(Ray ray)
    {
        Vector3 position = selectedObject.transform.position;
        RaycastHit mouseRayHit;
        if (Physics.Raycast(ray, out mouseRayHit, 100))
            position = protrude ? ProtrudeShape(mouseRayHit) : RoundVectorToGrid(mouseRayHit.point);
        return position;
    }

    /// <summary>
    /// Place object's border against mouse position rather than object's center
    /// </summary>
    /// <param name="mouseRayHit">Raycasting information</param>
    /// <returns>Position after protrusion</returns>
    private Vector3 ProtrudeShape(RaycastHit mouseRayHit)
    {
        Vector3 roundedMousePos = RoundVectorToGrid(mouseRayHit.point);
        // ClosestPointOnBounds finds position on the border of object that is closest to a given position
        Vector3 colliderClosestPoint = selectedCollider.ClosestPointOnBounds(roundedMousePos);
        // How far to place object center from hit position
        float distanceFromBorderToCenter = (selectedObject.transform.position - colliderClosestPoint).magnitude;
        // Position as chosen distance along the normal of the raycasted surface
        Vector3 newPosition = roundedMousePos + mouseRayHit.normal * distanceFromBorderToCenter;
        return newPosition;
    }

    /// <summary>
    /// Choose position when a cast of same shape detects an object
    /// </summary>
    /// <param name="ray">ray information with origin and direction</param>
    /// <returns>Position after ray hit</returns>
    [System.Obsolete("This method is obsolete, use ProtrudeShape instead")]
    private Vector3 CastShape(Ray ray)
    {
        // Using Shape Casts resulted in strange behaviour where the selected shape would move erratically along every axes' at 0
        RaycastHit mouseRayHit;
        Vector3 objScale = selectedObject.transform.localScale;
        Vector3 position = selectedObject.transform.position;
        bool equalScales = objScale.x == objScale.y && objScale.y == objScale.z; // Are shape dimensions uniform 
        if (objectShape == PrimitiveType.Sphere && equalScales) // SphereCast does not function as intended if the sphere object in question deforms in any way. 
        {
            debugger.Log("Doing Sphere cast");
            float radius = objScale.x * 0.5f;
            if (Physics.SphereCast(ray, radius, out mouseRayHit, 100))
                position = mouseRayHit.point;
        }
        else
        {
            debugger.Log("Doing Box cast");
            // BoxCast does not accept Ray as an argument
            // CylinderCast does not exist, so will be treated like a cube
            Vector3 halfObjectSize = selectedObject.transform.localScale * 0.5f;
            Quaternion objectRotation = selectedObject.transform.rotation;
            if (Physics.BoxCast(ray.origin, halfObjectSize, ray.direction, out mouseRayHit, objectRotation, 100))
                position = mouseRayHit.point;
        }
        return position;
    }

    /// <summary>
    /// Raycast from user click hit an object
    /// </summary>
    /// <param name="hitData">Results from raycast</param>
    private void ClickObject(RaycastHit hitData)
    {
        GameObject hitObject = hitData.collider.gameObject;
        if (hitObject.tag == "Shape") // if hit an object inserted into game via menu
        {
            debugger.Log("Clicked shape");
            if (IsObjectSelected && selectedObject == hitObject) // an Object is already selected
            {
                debugger.Log("Begin dragging object");
                IsDragging = true;
                selectedObject.layer = 2; // prevent selected object interacting with mouse raycasting
            }
            else
                SetObject(hitObject); // Select object
        }
        else
            UnsetObject(); // Deselect object if click elsewhere
    }

    /// <summary>
    /// Raycast from user click hit nothing
    /// </summary>
    private void ClickPosition()
    {
        debugger.Log("Clicked position");
        UnsetObject();
    }

    /// <summary>
    /// Select new object
    /// </summary>
    /// <param name="obj">Object to be selected</param>
    private void SetObject(GameObject obj)
    {
        debugger.Log("Selecting object");
        if (selectedObject != null) // an object was selected before
            selectedObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        selectedObject = obj;
        selectedCollider = selectedObject.GetComponent<Collider>(); // Cache collider for raycasting when dragging
        selectedObject.GetComponent<MeshRenderer>().material = selectMaterial;
        objectShape = PrimitiveType.Sphere; // Default object shape
        // Finding object shape by name isn't ideal, however they are named correctly by default when instantiated and no 
        // existing system under player influence can change their name. Alternatively, directly check mesh against existing assets
        // or store object details in attached MonoBehaviour or GameObject>PrimitiveType dictionary lookup
        if (selectedObject.name == "Cube")
            objectShape = PrimitiveType.Cube;
        else if (selectedObject.name == "Cylinder")
            objectShape = PrimitiveType.Cylinder;
        editor.IsUIVisible = true;
        editor.UpdateLabels();
    }

    /// <summary>
    /// Unselect object
    /// </summary>
    private void UnsetObject()
    {
        debugger.Log("Deselecting object");
        if (selectedObject == null) // no object already selected
            return;
        selectedObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        selectedObject = null;
        editor.IsUIVisible = false;
    }

}