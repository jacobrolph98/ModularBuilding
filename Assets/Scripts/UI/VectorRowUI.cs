using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VectorRowUI : MonoBehaviour
{
    private TMP_Text dimension; // Refers to x, y or z
    private TMP_InputField valueField;

    public float GetValue()
    {
        return float.Parse(valueField.text); // input field is set to accept decimals only
    }

    public void SetDimension(string val)
    {
        dimension.text = val;
    }

    public void SetValue(float val)
    {
        valueField.text = val.ToString("0.00"); // format value to 2 decimal places
    }

    private void Awake()
    {
        dimension = transform.Find("Dimension").Find("Text").GetComponent<TMP_Text>();
        valueField = transform.Find("InputField").GetComponent<TMP_InputField>();
    }
}
