using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnchantmentListObject : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI sourceText;
    [SerializeField]
    private TextMeshProUGUI descriptionText;

    public void InitEnchantmentObject(UnitEnchantment _enchantment)
    {
        sourceText.text = _enchantment.Source;
        descriptionText.text = _enchantment.DescriptionText();
    }
}
