using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipExtensionEffect : EffectExtensionUI
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
    private Toggle isChoiceToggle;
    [SerializeField]
    private Toggle includeUncollectablesToggle;
    [SerializeField]
    private TMP_InputField numToChooseInput;

    [Header("Stat Area")]
    [SerializeField]
    private TMP_Dropdown durabilityModTypeDropdown;
    [SerializeField]
    private TMP_InputField durabilityValueInput;

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
        GeneralUIExtensions.InitDropdownOfType(durabilityModTypeDropdown, new List<StatModifierTypes>());

        GeneralUIExtensions.InitDropdownOfType(tagDropdown, new List<Tags> { Tags.Default }, DEFAULT_DROPDOWN_STRING, true);

        nameInput.text = "";
        durabilityValueInput.text = "";
        createdByInput.text = "";
        numToChooseInput.text = "";

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

            var generationFilter = new GenerateCardFilter(player.PlayerClass)
            {
                Name = nameInput.text,
                CardType = CardTypes.Item,
                IncludeUncollectables = includeUncollectablesToggle.isOn,
            };
            generationFilter.IsUnique = isChoiceToggle.isOn;

            var statModType = (StatModifierTypes)Enum.Parse(typeof(StatModifierTypes), durabilityModTypeDropdown.captionText.text);
            if (statModType != StatModifierTypes.None)
            {
                if (string.IsNullOrWhiteSpace(durabilityValueInput.text))
                    durabilityValueInput.text = "0";
                var durabilityValue = int.Parse(durabilityValueInput.text);

                generationFilter.DurabilityChange = new KeyValuePair<StatModifierTypes, int>(statModType, durabilityValue);
            }

            if (tagDropdown.captionText.text != DEFAULT_DROPDOWN_STRING)
                generationFilter.Tag = (Tags)Enum.Parse(typeof(Tags), tagDropdown.captionText.text.Replace(" ", ""));

            if (isChoiceToggle.isOn)
            {
                if (int.TryParse(numToChooseInput.text, out int result) && numToChooseInput.text != "0")
                    generationFilter.NumToGenerate = Mathf.Max(1, result);
                else
                    generationFilter.NumToGenerate = 1;
            }

            if (player.GenerateCards(generationFilter, CardGenerationTypes.Equip, isChoiceToggle.isOn, createdByInput.text))
            {
                StartEffect();
                titleText.text = defaultTitleText;
            }
            else
                titleText.text = $"{defaultTitleText} (Failed)";
        }
        else
        {
            createdByInput.placeholder.color = new Color(0.8f, 0.0f, 0.0f, 0.5f);
            titleText.text = $"{defaultTitleText} (Input Created By)";
        }
    }

    public void ResetButton()
    {
        ClearFields();
    }

    public void IsChoiceToggleChange()
    {
        numToChooseInput.interactable = isChoiceToggle.isOn;
        numToChooseInput.text = "";
    }
}
