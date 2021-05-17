using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeDividerObject : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dividerText;

    public void InitDivider(string name)
    {
        dividerText.text = name;
    }
}
