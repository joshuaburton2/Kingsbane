using CategoryEnums;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public override void RefreshEffectExtension(EffectUI _effectUI)
    {
        base.RefreshEffectExtension(_effectUI);

        ClearFields();
    }

    private void ClearFields()
    {
        GeneralUIExtensions.InitDropdownOfType(attackModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(healthModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(rangeModTypeDropdown, new List<StatModifierTypes>());
        GeneralUIExtensions.InitDropdownOfType(speedModTypeDropdown, new List<StatModifierTypes>());

        GeneralUIExtensions.InitDropdownOfType(tagDropdown, new List<Tags> { Tags.Default }, "Any", true);

        nameInput.text = "";
        attackValueInput.text = "";
        healthValueInput.text = "";
        rangeValueInput.text = "";
        speedValueInput.text = "";
    }

    public void ConfirmButton()
    {
        var player = GameManager.instance.GetActivePlayer();
        var generationFilter = new GenerateCardFilter(player.PlayerClass);

        generationFilter.Name = nameInput.text;
        generationFilter.CardType = CardTypes.Unit;
        generationFilter.Tag = (Tags)Enum.Parse(typeof(Tags), tagDropdown.captionText.text.Replace(" ", ""));

        if (player.GenerateCards(generationFilter, CardGenerationTypes.Deploy, createdByInput.text))
        {

        }

    }

    public void ResetButton()
    {
        ClearFields();
    }
}
