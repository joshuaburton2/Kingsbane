using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class DeployExtensionEffect : EffectExtensionUI
{
    [Header("Selection Area")]
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private TMP_Dropdown tagDropdown;
    [SerializeField]
    private TMP_InputField createdByInput;
    [SerializeField]
    private Toggle activeOwnerToggle;
    [SerializeField]
    private TMP_InputField numToCreateInput;
    [SerializeField]
    private Toggle isChoiceToggle;
    [SerializeField]
    private Toggle includeUncollectablesToggle;

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

    private const string DEFAULT_DROPDOWN_STRING = "Any";
    private string defaultTitleText;

    public override void RefreshEffectExtension(EffectUI _effectUI)
    {
        base.RefreshEffectExtension(_effectUI);

        defaultTitleText = titleText.text;

        ClearFields();
    }

    private void ClearFields()
    {
        GeneralUIExtensions.InitDropdownOfType(attackModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(healthModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(rangeModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(speedModTypeDropdown, new List<StatModifierTypes>());

        GeneralUIExtensions.InitDropdownOfType(tagDropdown, new List<Tags> { Tags.Default }, DEFAULT_DROPDOWN_STRING, true);

        nameInput.text = "";
        attackValueInput.text = "";
        healthValueInput.text = "";
        rangeValueInput.text = "";
        speedValueInput.text = "";
        createdByInput.text = "";
        numToCreateInput.text = "";

        titleText.text = defaultTitleText;
        createdByInput.placeholder.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);

        activeOwnerToggle.isOn = true;
        isChoiceToggle.isOn = false;
        includeUncollectablesToggle.isOn = true;
    }

    public void ConfirmButton()
    {
        if (!string.IsNullOrWhiteSpace(createdByInput.text))
        {
            var player = GameManager.instance.GetPlayer(activeOwnerToggle.isOn);

            var enchantment = new UnitEnchantment() { Status = UnitEnchantment.EnchantmentStatus.Permanent, Source = createdByInput.text };
            GetStatModifier(enchantment, Unit.StatTypes.Attack, attackModTypeDropdown, attackValueInput);
            GetStatModifier(enchantment, Unit.StatTypes.MaxHealth, healthModTypeDropdown, healthValueInput);
            GetStatModifier(enchantment, Unit.StatTypes.Range, rangeModTypeDropdown, rangeValueInput);
            GetStatModifier(enchantment, Unit.StatTypes.Speed, speedModTypeDropdown, speedValueInput);

            var generationFilter = new GenerateCardFilter(player.PlayerClass)
            {
                Name = nameInput.text,
                CardType = CardTypes.Unit,
                IncludeUncollectables = includeUncollectablesToggle.isOn,
            };
            generationFilter.IsUnique = isChoiceToggle.isOn;

            if (tagDropdown.captionText.text != DEFAULT_DROPDOWN_STRING)
                generationFilter.Tag = (Tags)Enum.Parse(typeof(Tags), tagDropdown.captionText.text.Replace(" ", ""));

            if (enchantment.ValidEnchantment)
                generationFilter.Enchantment = enchantment;

            if (int.TryParse(numToCreateInput.text, out int result) && numToCreateInput.text != "0")
                generationFilter.UnitsToCreate = Mathf.Max(1, result);
            else
                generationFilter.UnitsToCreate = 1;

            if (isChoiceToggle.isOn)
                generationFilter.NumToGenerate = generationFilter.UnitsToCreate;

            if (player.GenerateCards(generationFilter, CardGenerationTypes.Deploy, isChoiceToggle.isOn, createdByInput.text))
                StartEffect();
            else
                titleText.text = $"{defaultTitleText} (Failed)";
        }
        else
        {
            createdByInput.placeholder.color = new Color(0.8f, 0.0f, 0.0f, 0.5f);
            titleText.text = $"{defaultTitleText} (Input Created By)";
        }
    }

    /// <summary>
    /// 
    /// Adds the stat modifier to the enchantment for a particular stat type dropdown and an input
    /// 
    /// </summary>
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
