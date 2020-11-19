using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
