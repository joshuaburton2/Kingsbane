using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CategoryEnums;
using System;
using System.Linq;

public class PassiveExtensionEffect : EffectExtensionUI
{
    [Header("Basic Fields")]
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private TMP_Dropdown affectedCardTypeDropdown;
    [SerializeField]
    private TMP_Dropdown affectedTagDropdown;
    [SerializeField]
    private TMP_Dropdown affectedUnitTagDropdown;
    [SerializeField]
    private Toggle isTemporaryToggle;
    [SerializeField]
    private TMP_Dropdown playerNumberDropdown;

    [Header("Passive Effects Area")]
    [SerializeField]
    private TMP_Dropdown costResourceDropdown;
    [SerializeField]
    private TMP_InputField minCostInput;
    [SerializeField]
    private TMP_InputField greaterThanInput;
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

    private string defaultTitleText;

    public override void RefreshEffectExtension(EffectUI _effectUI)
    {
        base.RefreshEffectExtension(_effectUI);

        defaultTitleText = titleText.text;

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

        playerNumberDropdown.ClearOptions();
        playerNumberDropdown.AddOptions(GameManager.instance.LoadedPlayers.Select(x => (x.Id + 1).ToString()).ToList());
        playerNumberDropdown.gameObject.SetActive(GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Setup);

        nameInput.text = "";
        costValueInput.text = "";
        minCostInput.text = "";
        greaterThanInput.text = "";
        attackValueInput.text = "";
        healthValueInput.text = "";
        rangeValueInput.text = "";
        speedValueInput.text = "";
        speedValueInput.text = "";

        titleText.text = defaultTitleText;

        isTemporaryToggle.isOn = false;
        isTemporaryToggle.interactable = GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay;
    }

    public void ConfirmButton()
    {
        UpgradeData sourceUpgrade = null;
        CardData sourceCard = null;
        int? playerId = null;
        switch (GameManager.instance.CurrentGamePhase)
        {
            case GameManager.GamePhases.Setup:
                sourceUpgrade = GameManager.instance.upgradeManager.GetUpgrade(nameInput.text);
                playerId = int.Parse(playerNumberDropdown.captionText.text) - 1;
                break;
            case GameManager.GamePhases.Gameplay:
                sourceCard = GameManager.instance.libraryManager.GetCard(nameInput.text);
                break;
        }

        if (sourceUpgrade != null || sourceCard != null)
        {
            var passive = new Passive
            {
                Name = nameInput.text,
                IsTemporary = isTemporaryToggle.isOn,
                SourceUpgrade = sourceUpgrade,
                SourceCard = sourceCard
            };

            if (affectedCardTypeDropdown.captionText.text != DEFAULT_INPUT_STRING_ANY)
                passive.AffectedCardTypes = (CardTypes)Enum.Parse(typeof(CardTypes), affectedCardTypeDropdown.captionText.text);
            if (affectedTagDropdown.captionText.text != DEFAULT_INPUT_STRING_ANY)
                passive.AffectedCardTag = (Tags)Enum.Parse(typeof(Tags), affectedTagDropdown.captionText.text);
            if (affectedUnitTagDropdown.captionText.text != DEFAULT_INPUT_STRING_ANY)
                passive.AffectedUnitTags = (UnitTags)Enum.Parse(typeof(UnitTags), affectedUnitTagDropdown.captionText.text);


            if (costResourceDropdown.captionText.text != DEFAULT_INPUT_STRING_NONE)
                passive.TargetResource = (CardResources)Enum.Parse(typeof(CardResources), costResourceDropdown.captionText.text);
            if (int.TryParse(costValueInput.text, out int result))
            {
                var costAdjustment = new AdjustCostObject() { AdjustmentType = StatModifierTypes.Modify, FromPassive = true };

                costAdjustment.Value = result;

                if (int.TryParse(minCostInput.text, out int minCostResult))
                    costAdjustment.MinCost = minCostResult;
                if (int.TryParse(greaterThanInput.text, out int greaterThanResult))
                    costAdjustment.MustBeGreaterThan = greaterThanResult;

                passive.CostAdjustment = costAdjustment;
            }

            else
                passive.CostAdjustment = null;

            var enchantment = new UnitEnchantment()
            {
                BaseStatus = EnchantmentStatus.Passive,
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

            if (GameManager.instance.effectManager.AddPassive(passive, playerId))
            {
                gameObject.SetActive(false);
            }
            else
            {
                titleText.text = $"{defaultTitleText} (Failed)";
            }
        }
        else
        {
            titleText.text = $"{defaultTitleText} (Failed)";
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
