using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShapeMenuController : MonoBehaviour
{
    public bool ShapeMenuVisible
    {
        get { return gameObject.activeSelf; }
        set { gameObject.SetActive(value); }
    }

    // SerializeField shows values in the unity inspector

    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    private Transform cameraTransform;
    // Point to the prefab of shape button
    [SerializeField]
    private GameObject shapeButtonPrefab;
    // Allow easy setting of scrollbar content pane
    [SerializeField]
    private GameObject contentPane;
    // Allow easy changes to available shapes 
    [SerializeField]
    private PrimitiveType[] availableShapes;

    private GameObject[] shapeButtons;

    /// <summary>
    /// Save shapes in world
    /// </summary>
    public void SaveShapes()
    {
        SaveSystem.SaveShapes();
    }

    /// <summary>
    /// Get shapes from disk. If they exist, remove existing shapes and add new ones
    /// </summary>
    public void LoadShapes()
    {
        WorldData world = SaveSystem.LoadShapes();  // Get saved information
        if (world.shapes.Length>0) // Clear shapes already in the world if there are new shapes to load
        {
            GameObject[] shapesInWorldspace = GameObject.FindGameObjectsWithTag("Shape");
            foreach (GameObject shape in shapesInWorldspace)
                GameObject.Destroy(shape);
        }
        // Create new shape for each saved instance
        foreach (ShapeData shapeInfo in world.shapes)
        {
            int index = shapeInfo.availableShapeIndex;
            Vector3 position = ConvertVector(shapeInfo.position);
            Vector3 eulerRotation = ConvertVector(shapeInfo.rotation);
            Vector3 scale = ConvertVector(shapeInfo.scale);
            AddShape(availableShapes[index], position, eulerRotation, scale);
        }
    }

    /// <summary>
    /// Add new object into world
    /// </summary>
    /// <param name="shapeType">What shape</param>
    /// <param name="position">Position</param>
    /// <param name="rotation">Euler Rotation</param>
    /// <param name="scale">Size</param>
    private void AddShape(PrimitiveType shapeType, Vector3 position, Vector3 rotation, Vector3 scale)
    {
        GameObject newShape = GameObject.CreatePrimitive(shapeType);
        newShape.transform.position = position;
        newShape.transform.localRotation = Quaternion.Euler(rotation);
        newShape.transform.localScale = scale;
        newShape.tag = "Shape";
        newShape.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    /// <summary>
    /// User clicked on shape
    /// </summary>
    /// <param name="shapeIndex">Which index was pressed</param>
    private void ShapeClicked(int shapeIndex)
    {
        AddShape(availableShapes[shapeIndex], cameraTransform.position + cameraTransform.forward * 5, new Vector3(0, 0, 0), new Vector3(1, 1, 1));
    }

    /// <summary>
    /// Convert SerializableVector to normal vector for setting object values
    /// </summary>
    /// <param name="vector">Serializable Vector3</param>
    /// <returns>Regular Vector3</returns>
    private Vector3 ConvertVector(SerializableVector3 vector)
    {
        return new Vector3(vector.x, vector.y, vector.z);
    }

    /// <summary>
    ///  Initialization
    /// </summary>
    private void Start()
    {
        shapeButtons = new GameObject[availableShapes.Length];
        // CREATE BUTTONS FOR EACH SHAPE
        for (int i = 0; i < availableShapes.Length; i++)
        {
            int index = i; // create new index for each button
            shapeButtons[i] = Instantiate(shapeButtonPrefab); // Create new button

            shapeButtons[i].name = availableShapes[i].ToString() + "_Button";
            shapeButtons[i].transform.Find("Label").gameObject.GetComponent<TMP_Text>().text = availableShapes[i].ToString();
            shapeButtons[i].transform.SetParent(contentPane.transform, false);

            // set button image texture

            Button shapeButton = shapeButtons[i].GetComponent<Button>();
            shapeButton.onClick.AddListener(delegate () { ShapeClicked(index); });
        }
    }
}
