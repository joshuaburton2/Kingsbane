using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CategoryEnums;
using System;

public class PassiveExtensionEffect : EffectExtensionUI
{
    [Header("Basic Fields")]
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private TMP_Dropdown affectedCardTypeDropdown;
    [SerializeField]
    private TMP_Dropdown affectedTagDropdown;
    [SerializeField]
    private TMP_Dropdown affectedUnitTagDropdown;

    [Header("Passive Effects Area")]
    [SerializeField]
    private TMP_Dropdown costResourceDropdown;
    [SerializeField]
    private TMP_InputField costValueInput;
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
    private TMP_Dropdown specialPassiveValueDropdown;
    [SerializeField]
    private TMP_InputField specialPassiveValueInput;

    private const string DEFAULT_INPUT_STRING_ANY = "Any";
    private const string DEFAULT_INPUT_STRING_NONE = "None";

    public override void RefreshEffectExtension(EffectUI _effectUI)
    {
        base.RefreshEffectExtension(_effectUI);

        ClearFields();
    }

    private void ClearFields()
    {
        GeneralUIExtensions.InitDropdownOfType(affectedCardTypeDropdown, new List<CardTypes> { CardTypes.Default }, DEFAULT_INPUT_STRING_ANY);
        GeneralUIExtensions.InitDropdownOfType(affectedTagDropdown, new List<Tags> { Tags.Default }, DEFAULT_INPUT_STRING_ANY, true);
        GeneralUIExtensions.InitDropdownOfType(affectedUnitTagDropdown, new List<UnitTags> { UnitTags.Default }, DEFAULT_INPUT_STRING_ANY, true);

        GeneralUIExtensions.InitDropdownOfType(attackModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(healthModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(rangeModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(speedModTypeDropdown, new List<StatModifierTypes>());

        GeneralUIExtensions.InitDropdownOfType(costResourceDropdown, new List<CardResources>() { CardResources.Neutral }, DEFAULT_INPUT_STRING_NONE);
        GeneralUIExtensions.InitDropdownOfType(specialPassiveValueDropdown, new List<SpecialPassiveEffects>() { }, DEFAULT_INPUT_STRING_NONE, true);

        nameInput.text = "";
        costValueInput.text = "";
        attackValueInput.text = "";
        healthValueInput.text = "";
        rangeValueInput.text = "";
        speedValueInput.text = "";
        speedValueInput.text = "";
    }

    public void ConfirmButton()
    {
        var passive = new Passive();

        passive.Name = nameInput.text;
        switch (GameManager.instance.CurrentGamePhase)
        {
            case GameManager.GamePhases.Setup:
                passive.SourceUpgrade = GameManager.instance.upgradeManager.GetUpgrade(nameInput.text);
                break;
            case GameManager.GamePhases.Gameplay:
                passive.SourceCard = GameManager.instance.libraryManager.GetCard(nameInput.text);
                break;
        }

        if (affectedCardTypeDropdown.captionText.text != DEFAULT_INPUT_STRING_ANY)
            passive.AffectedCardTypes = (CardTypes)Enum.Parse(typeof(CardTypes), affectedCardTypeDropdown.captionText.text);
        if (affectedTagDropdown.captionText.text != DEFAULT_INPUT_STRING_ANY)
            passive.AffectedCardTag = (Tags)Enum.Parse(typeof(Tags), affectedTagDropdown.captionText.text);
        if (affectedUnitTagDropdown.captionText.text != DEFAULT_INPUT_STRING_ANY)
            passive.AffectedUnitTags = (UnitTags)Enum.Parse(typeof(UnitTags), affectedUnitTagDropdown.captionText.text);


        if (costResourceDropdown.captionText.text != DEFAULT_INPUT_STRING_NONE)
             passive.TargetResource = (CardResources)Enum.Parse(typeof(CardResources), costResourceDropdown.captionText.text);
        if (int.TryParse(costValueInput.text, out int result))
            passive.CostModification = result;
        else
            passive.CostModification = null;

        var enchantment = new UnitEnchantment()
        {
            Status = UnitEnchantment.EnchantmentStatus.Passive,
            Source = nameInput.text,
        };
        GetStatModifier(enchantment, Unit.StatTypes.Attack, attackModTypeDropdown, attackValueInput);
        GetStatModifier(enchantment, Unit.StatTypes.MaxHealth, healthModTypeDropdown, healthValueInput);
        GetStatModifier(enchantment, Unit.StatTypes.Range, rangeModTypeDropdown, rangeValueInput);
        GetStatModifier(enchantment, Unit.StatTypes.Speed, speedModTypeDropdown, speedValueInput);
        if (enchantment.ValidEnchantment)
            passive.Enchantment = enchantment;

        if (specialPassiveValueDropdown.captionText.text != DEFAULT_INPUT_STRING_NONE)
        {
            passive.SpecialPassive = (SpecialPassiveEffects)Enum.Parse(typeof(SpecialPassiveEffects), specialPassiveValueDropdown.captionText.text);
            if (int.TryParse(specialPassiveValueInput.text, out int specialPassive))
                passive.SpecialPassiveProperty = specialPassive;
            else
                passive.SpecialPassiveProperty = 0;
        }

        GameManager.instance.effectManager.AddPassive(passive);
        gameObject.SetActive(false);
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
