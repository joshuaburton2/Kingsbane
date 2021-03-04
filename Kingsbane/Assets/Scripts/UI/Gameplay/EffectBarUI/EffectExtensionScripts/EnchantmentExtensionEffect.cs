using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnchantmentExtensionEffect : EffectExtensionUI
{
    [Header("Basic Fields")]
    [SerializeField]
    private TMP_Dropdown typeDropdown;
    [SerializeField]
    private TMP_Dropdown statusDropdown;
    [SerializeField]
    private TMP_InputField sourceInput;
    [SerializeField]
    private GameObject enchantmentListObjectPrefab;

    [Header("Type Areas")]
    [SerializeField]
    private GameObject statTypeArea;
    [SerializeField]
    private GameObject keywordArea;
    [SerializeField]
    private GameObject statusEffectArea;

    [Header("Stat Area")]
    [SerializeField]
    private TMP_Dropdown attackModTypeDropdown;
    [SerializeField]
    private TMP_InputField attackValueInput;
    [SerializeField]
    private TMP_Dropdown healthModTypeDropdown;
    [SerializeField]
    private TMP_InputField healthValueInput;
    [SerializeField]
    private TMP_Dropdown rangeModTypeDropdown;
    [SerializeField]
    private TMP_InputField rangeValueInput;
    [SerializeField]
    private TMP_Dropdown speedModTypeDropdown;
    [SerializeField]
    private TMP_InputField speedValueInput;
    [SerializeField]
    private TMP_Dropdown empoweredModTypeDropdown;
    [SerializeField]
    private TMP_InputField empoweredValueInput;

    [Header("Keyword Area")]
    [SerializeField]
    private TMP_Dropdown keywordDropdown;
    [SerializeField]
    private GameObject keywordListParent;

    [Header("Status Effect Area")]
    [SerializeField]
    private TMP_Dropdown statusEffectDropdown;
    [SerializeField]
    private GameObject statusEffectListParent;

    public enum EnchantmentType
    {
        UnitStats,
        Keywords,
        StatusEffects,
    }

    public override void RefreshEffectExtension()
    {
        base.RefreshEffectExtension();

        ClearFields();
    }

    private void ClearFields()
    {
        GeneralUIExtensions.InitDropdownOfType(typeDropdown, new List<EnchantmentType>());
        GeneralUIExtensions.InitDropdownOfType(statusDropdown, new List<UnitEnchantment.EnchantmentStatus>()
        {
            UnitEnchantment.EnchantmentStatus.None,
            UnitEnchantment.EnchantmentStatus.Base,
            UnitEnchantment.EnchantmentStatus.NewBase,
        });

        GeneralUIExtensions.InitDropdownOfType(attackModTypeDropdown, new List<StatModifierType>() { StatModifierType.None });
        GeneralUIExtensions.InitDropdownOfType(healthModTypeDropdown, new List<StatModifierType>() { StatModifierType.None });
        GeneralUIExtensions.InitDropdownOfType(rangeModTypeDropdown, new List<StatModifierType>() { StatModifierType.None });
        GeneralUIExtensions.InitDropdownOfType(speedModTypeDropdown, new List<StatModifierType>() { StatModifierType.None });
        GeneralUIExtensions.InitDropdownOfType(empoweredModTypeDropdown, new List<StatModifierType>() { StatModifierType.None });

        GeneralUIExtensions.InitDropdownOfType(keywordDropdown, new List<BaseUnitKeywords>());
        GeneralUIExtensions.InitDropdownOfType(statusEffectDropdown, new List<Unit.StatusEffects>());

        GameManager.DestroyAllChildren(keywordListParent);
        GameManager.DestroyAllChildren(statusEffectListParent);

        sourceInput.text = "";
    }

    public void AddKeyword()
    {

    }

    public void AddStatusEffect()
    {

    }

    public void RemoveListObject(string value, EnchantmentType listType)
    {

    }

    public void ConfirmButton()
    {

    }

    public void ResetButton()
    {
        ClearFields();
    }
}
