using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Toggler : MonoBehaviour
{
    public TMP_Text hideButton; // Text of the button that is pressed to show/hide menu

    public void Toggle() // button points to this method 
    {
        gameObject.SetActive(!gameObject.activeSelf);
        hideButton.text = gameObject.activeSelf ? ">" : "<";
    }
}
