using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnchantmentListObject : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI sourceText;
    [SerializeField]
    private TextMeshProUGUI descriptionText;
    [SerializeField]
    private Button deleteButton;

    private Unit unit;
    private AppliedEnchantment enchantment;
    private UnitCommandUI unitCommandUI;

    public void InitEnchantmentObject(AppliedEnchantment _enchantment, Unit _unit, UnitCommandUI _unitCommandUI)
    {
        unit = _unit;
        enchantment = _enchantment;
        unitCommandUI = _unitCommandUI;

        var activeText = !_enchantment.IsActive ? "- Spellbound" : "";
        sourceText.text = $"{_enchantment.Enchantment.Source}{activeText}";
        descriptionText.text = _enchantment.Enchantment.DescriptionText();

        var unRemoveableEnchantments = new List<UnitEnchantment.EnchantmentStatus>()
        {
            UnitEnchantment.EnchantmentStatus.OverloadPassive,
            UnitEnchantment.EnchantmentStatus.Passive,
        };
        deleteButton.interactable = !unRemoveableEnchantments.Contains(enchantment.Enchantment.Status);
    }

    public void DeleteEnchantment()
    {
        unit.DeleteEnchantment(enchantment);
        unitCommandUI.RefreshCommandBar();
    }
}
