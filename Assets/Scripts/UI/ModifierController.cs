using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModifierController : MonoBehaviour
{
    // These are assigned through inspector
    public Slider gridSizeSlider;
    public TMP_Text gridSizeLabel;
    public Toggle placementToggle;

    [System.NonSerialized]
    public ShapeModifier modifier;

    /// <summary>
    /// Display correct initial values from modifier once it is attached 
    /// </summary>
    public void Setup()
    {
        gridSizeSlider.value = modifier.gridSize;
        gridSizeLabel.text = "Grid Size: " + modifier.gridSize;
        placementToggle.isOn = !modifier.protrude;
    }

    /// <summary>
    /// Set modifier grid size based on UI values, and update label
    /// </summary>
    public void SetGridSize()
    {
        float val = (Mathf.Round(gridSizeSlider.value * 100)) / 100; // Round to 2 decimal places
        modifier.gridSize = val;
        gridSizeLabel.text = "Grid Size: " + val;
    }

    /// <summary>
    /// Update modifier protrusion based on UI value
    /// </summary>
    public void SetPlacementToggle()
    {
        modifier.protrude = !placementToggle.isOn; // UI specifies placement by center, so inverse of castShape
    }

}