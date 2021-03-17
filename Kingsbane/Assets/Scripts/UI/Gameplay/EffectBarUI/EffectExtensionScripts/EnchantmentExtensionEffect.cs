using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private List<EnchantmentEffectListObject> keywordList;
    private List<EnchantmentEffectListObject> statusEffectList;

    public enum EnchantmentType
    {
        UnitStats,
        Keywords,
        StatusEffects,
    }

    public override void RefreshEffectExtension(EffectUI _effectUI)
    {
        base.RefreshEffectExtension(_effectUI);

        ClearFields();
    }

    private void ClearFields()
    {
        GeneralUIExtensions.InitDropdownOfType(typeDropdown, new List<EnchantmentType>() { EnchantmentType.StatusEffects });
        GeneralUIExtensions.InitDropdownOfType(statusDropdown, new List<UnitEnchantment.EnchantmentStatus>()
        {
            UnitEnchantment.EnchantmentStatus.None,
            UnitEnchantment.EnchantmentStatus.Base,
        });

        GeneralUIExtensions.InitDropdownOfType(attackModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(healthModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(rangeModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(speedModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(empoweredModTypeDropdown, new List<StatModifierTypes>());

        GeneralUIExtensions.InitDropdownOfType(keywordDropdown, new List<Keywords>() { Keywords.Summon });
        GeneralUIExtensions.InitDropdownOfType(statusEffectDropdown,
            new List<Unit.StatusEffects>() 
            { 
                Unit.StatusEffects.None, Unit.StatusEffects.Spellbound, Unit.StatusEffects.Rooted , Unit.StatusEffects.Stunned, Unit.StatusEffects.Transformed,
            });

        GameManager.DestroyAllChildren(keywordListParent);
        GameManager.DestroyAllChildren(statusEffectListParent);

        attackValueInput.text = "";
        healthValueInput.text = "";
        rangeValueInput.text = "";
        speedValueInput.text = "";
        empoweredValueInput.text = "";
        sourceInput.text = "";

        keywordList = new List<EnchantmentEffectListObject>();
        statusEffectList = new List<EnchantmentEffectListObject>();

        ChangeEnchantmentType();
    }

    public void ChangeEnchantmentType()
    {
        var selectedType = (EnchantmentType)Enum.Parse(typeof(EnchantmentType), typeDropdown.captionText.text);

        statTypeArea.SetActive(false);
        keywordArea.SetActive(false);
        statusEffectArea.SetActive(false);

        switch (selectedType)
        {
            case EnchantmentType.UnitStats:
                statTypeArea.SetActive(true);
                break;
            case EnchantmentType.Keywords:
                keywordArea.SetActive(true);
                break;
            case EnchantmentType.StatusEffects:
                statusEffectArea.SetActive(true);
                break;
            default:
                throw new Exception("Not a valid enchantment type");
        }
    }

    public void AddKeyword()
    {
        var selectedKeyword = keywordDropdown.captionText.text;

        bool flag = true;
        foreach (var keyword in keywordList)
        {
            if (keyword.Value == selectedKeyword)
            {
                flag = false;
                break;
            }
        }

        if (flag)
        {
            var keywordObject = Instantiate(enchantmentListObjectPrefab, keywordListParent.transform);
            var keywordScript = keywordObject.GetComponent<EnchantmentEffectListObject>();
            keywordScript.InitObject(this, selectedKeyword, EnchantmentType.Keywords);
            keywordList.Add(keywordScript);
        }
    }

    public void AddStatusEffect()
    {
        var selectedStatusEffect = statusEffectDropdown.captionText.text;

        bool flag = true;
        foreach (var statusEffect in statusEffectList)
        {
            if (statusEffect.Value == selectedStatusEffect)
            {
                flag = false;
                break;
            }
        }

        if (flag)
        {
            var statusEffectObject = Instantiate(enchantmentListObjectPrefab, statusEffectListParent.transform);
            var statusEffectScript = statusEffectObject.GetComponent<EnchantmentEffectListObject>();
            statusEffectScript.InitObject(this, selectedStatusEffect, EnchantmentType.StatusEffects);
            statusEffectList.Add(statusEffectScript);
        }
    }

    public void RemoveListObject(EnchantmentEffectListObject listObject, EnchantmentType listType)
    {
        switch (listType)
        {
            case EnchantmentType.Keywords:
                keywordList.Remove(listObject);
                break;
            case EnchantmentType.StatusEffects:
                statusEffectList.Remove(listObject);
                break;
            default:
                throw new Exception("Not a valid enchantment type");
        }

        Destroy(listObject.gameObject);
    }

    public void ConfirmButton()
    {
        if (string.IsNullOrWhiteSpace(sourceInput.text))
        {
            sourceInput.text = "Test Enchantment";
        }

        var enchantment = new UnitEnchantment();

        GetStatModifier(enchantment, Unit.StatTypes.Attack, attackModTypeDropdown, attackValueInput);
        GetStatModifier(enchantment, Unit.StatTypes.MaxHealth, healthModTypeDropdown, healthValueInput);
        GetStatModifier(enchantment, Unit.StatTypes.Range, rangeModTypeDropdown, rangeValueInput);
        GetStatModifier(enchantment, Unit.StatTypes.Speed, speedModTypeDropdown, speedValueInput);
        GetStatModifier(enchantment, Unit.StatTypes.Empowered, empoweredModTypeDropdown, empoweredValueInput);

        foreach (var keywordObject in keywordList)
        {
            var keyword = (Keywords)Enum.Parse(typeof(Keywords), keywordObject.Value);
            enchantment.Keywords.Add(keyword);
        }

        foreach (var statusEffectObject in statusEffectList)
        {
            var statusEffect = (Unit.StatusEffects)Enum.Parse(typeof(Unit.StatusEffects), statusEffectObject.Value);
            enchantment.StatusEffects.Add(statusEffect);
        }

        enchantment.Status = (UnitEnchantment.EnchantmentStatus)Enum.Parse(typeof(UnitEnchantment.EnchantmentStatus), statusDropdown.captionText.text);
        enchantment.Source = sourceInput.text;

        if (enchantment.ValidEnchantment)
        {
            StartEffect();
            GameManager.instance.effectManager.SetEnchantUnitMode(enchantment);
        }
    }

    private void GetStatModifier(UnitEnchantment enchantment, Unit.StatTypes statType, TMP_Dropdown statModTypeDropdown, TMP_InputField statValueInput)
    {
        var statModType = (StatModifierTypes)Enum.Parse(typeof(StatModifierTypes), statModTypeDropdown.captionText.text);

        if (statModType != StatModifierTypes.None)
        {
            if (string.IsNullOrWhiteSpace(statValueInput.text))
                statValueInput.text = "0";
            var statValue = int.Parse(statValueInput.text);

            enchantment.AddStatModifier(statType, statModType, statValue);
        }
    }

    public void ResetButton()
    {
        ClearFields();
    }
}
