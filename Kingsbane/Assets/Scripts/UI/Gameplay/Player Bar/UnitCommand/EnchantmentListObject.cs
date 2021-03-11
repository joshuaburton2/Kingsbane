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

    public void InitEnchantmentObject(AppliedEnchantment _enchantment)
    {
        var activeText = !_enchantment.IsActive ? "- Spellbound" : "";
        sourceText.text = $"{_enchantment.Enchantment.Source}{activeText}";
        descriptionText.text = _enchantment.Enchantment.DescriptionText();
    }
}
