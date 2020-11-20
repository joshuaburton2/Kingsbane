using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// Object for displaying data about an element of a key
/// 
/// </summary>
public class KeyColourObject : MonoBehaviour
{
    [SerializeField]
    private Image iconColour;
    [SerializeField]
    private TextMeshProUGUI keyText;

    public void RefreshKeyElement(Color keyColour, string keyName)
    {
        iconColour.color = keyColour;
        keyText.text = keyName;
    }
}
