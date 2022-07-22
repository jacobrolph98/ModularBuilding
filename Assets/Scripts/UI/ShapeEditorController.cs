using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShapeEditorController : MonoBehaviour
{
    [SerializeField]
    public GameObject vectorRowPrefab; // 1 Vector row per dimension
    [SerializeField]
    private GameObject[] controlButtons;  // position, rotation & scale

    [System.NonSerialized]
    public ShapeModifier modifier;

    public bool IsUIVisible
    {
        get { return gameObject.activeSelf; }
        set { gameObject.SetActive(value); }
    }

    private VectorRowUI[] vectorRows;
    private int activeVectorIndex = 0;  // Which control is selected

    /// <summary>
    /// Refresh Vector values in object editor. 
    /// </summary>
    public void UpdateLabels()
    {
        // Values are not passed as arguments but are retrieved  via reference as this method 
        // is called when input field editing is finished, which cannot pass required arguments
        SetVectorVal(modifier.GetObjectVector((VectorType)activeVectorIndex));
    }

    /// <summary>
    /// Update object values based on values in editor
    /// </summary>
    public void UpdateObject()
    {
        modifier.SetObjectVector(GetVectorVal(), (VectorType)activeVectorIndex);
    }

    /// <summary>
    /// Open position tab of editor
    /// </summary>
    public void OpenPosition()
    {
        SetVectorVal(modifier.GetObjectVector(VectorType.Position));
        activeVectorIndex = 0;
        UpdateButtonHighlight();
    }

    /// <summary>
    /// Open rotation tab of editor
    /// </summary>
    public void OpenRotation()
    {
        SetVectorVal(modifier.GetObjectVector(VectorType.Rotation));
        activeVectorIndex = 1;
        UpdateButtonHighlight();
    }

    /// <summary>
    /// Open scale tab of editor
    /// </summary>
    public void OpenScale()
    {
        SetVectorVal(modifier.GetObjectVector(VectorType.Scale));
        activeVectorIndex = 2;
        UpdateButtonHighlight();
    }

    /// <summary>
    ///  Tell modifier to delete selected object
    /// </summary>
    public void DeleteObject()
    {
        modifier.DeleteObject();
    }

    /// <summary>
    /// Tell modifier to copy object
    /// </summary>
    public void CopyObject()
    {
        modifier.CopyObject();
    }

    /// <summary>
    ///  Convert individual values from editor tab to a Vector3 value
    /// </summary>
    /// <returns>Vector3 value</returns>
    private Vector3 GetVectorVal()
    {
        return new Vector3(vectorRows[0].GetValue(), vectorRows[1].GetValue(), vectorRows[2].GetValue());
    }

    /// <summary>
    /// Set vector values in editor tab
    /// </summary>
    /// <param name="val">Vector to set</param>
    private void SetVectorVal(Vector3 val)
    {
        vectorRows[0].SetValue(val.x);
        vectorRows[1].SetValue(val.y);
        vectorRows[2].SetValue(val.z);
    }

    /// <summary>
    /// Update which vector editor buttons are highlighted
    /// </summary>
    private void UpdateButtonHighlight()
    {
        // For every button
        for (int i = 0; i < 3; i++)
        {
            // Button colour is determined by whether it has the same index as active vector 
            Color32 buttonColour = i == activeVectorIndex ? new Color32(200, 200, 200, 255) : new Color32(255, 255, 255, 255);
            controlButtons[i].GetComponent<Image>().color = buttonColour;
        }
    }

    /// <summary>
    /// Initialization
    /// </summary>
    private void Awake()
    {
        // Create vector rows
        string[] dims = { "x", "y", "z" };
        vectorRows = new VectorRowUI[3];
        for (int i = 0; i < 3; i++)
        {
            GameObject rowObject = Instantiate(vectorRowPrefab);
            rowObject.transform.SetParent(transform.Find("VectorControls"));
            rowObject.transform.Find("InputField").gameObject.GetComponent<TMP_InputField>().onEndEdit.AddListener(delegate { UpdateObject(); });
            vectorRows[i] = rowObject.GetComponent<VectorRowUI>();
            vectorRows[i].SetDimension(dims[i]);
        }
        IsUIVisible = false; // Hide editor to start
    }
}
