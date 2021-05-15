using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModifyCostExtensionEffect : EffectExtensionUI
{

    [SerializeField]
    private TMP_InputField costInput;
    [SerializeField]
    private TMP_InputField minCostInput;
    [SerializeField]
    private TMP_InputField mustBeGreaterThanInput;
    [SerializeField]
    private TMP_Dropdown statTypeDropdown;
    [SerializeField]
    private TMP_Dropdown targetDropdown;
    [SerializeField]
    private TMP_Dropdown resourceDropdown;

    private const string DEFAULT_TARGET_STRING = "Target";
    private const string DEFAULT_RESOURCE_STRING = "None";

    public override void RefreshEffectExtension(EffectUI _effectUI)
    {
        base.RefreshEffectExtension(_effectUI);

        ClearFields();
    }

    private void ClearFields()
    {
        GeneralUIExtensions.InitDropdownOfType(statTypeDropdown, new List<StatModifierTypes>() { StatModifierTypes.None });
        GeneralUIExtensions.InitDropdownOfType(targetDropdown, new List<CardTypes>() { CardTypes.Default }, DEFAULT_TARGET_STRING);
        GeneralUIExtensions.InitDropdownOfType(resourceDropdown, new List<CardResources>() { CardResources.Neutral }, DEFAULT_RESOURCE_STRING, true);

        costInput.text = "";
        minCostInput.text = "";
        mustBeGreaterThanInput.text = "";
        targetDropdown.value = 0;
        resourceDropdown.value = 0;
        statTypeDropdown.value = 0;
    }

    public void ConfirmButton()
    {
        var adjustCostObject = new AdjustCostObject();

        //Gets the card resource from the dropdown
        if (resourceDropdown.captionText.text == DEFAULT_RESOURCE_STRING)
            adjustCostObject.TargetResource = null;
        else
            adjustCostObject.TargetResource = (CardResources)Enum.Parse(typeof(CardResources), resourceDropdown.captionText.text);

        if (int.TryParse(costInput.text, out int result))
        {
            adjustCostObject.Value = result;
        }
        else
        {
            adjustCostObject.Value = -1;
            costInput.text = "-1";
        }

        adjustCostObject.MinCost = null;
        if (int.TryParse(minCostInput.text, out int minCostResult))
        {
            adjustCostObject.MinCost = minCostResult;
        }

        adjustCostObject.MustBeGreaterThan = null;
        if (int.TryParse(mustBeGreaterThanInput.text, out int mustBeGreaterThanResult))
        {
            adjustCostObject.MustBeGreaterThan = mustBeGreaterThanResult;
        }

        adjustCostObject.AdjustmentType = (StatModifierTypes)Enum.Parse(typeof(StatModifierTypes), statTypeDropdown.captionText.text);
        if (adjustCostObject.AdjustmentType == StatModifierTypes.Set)
            adjustCostObject.Value = -adjustCostObject.Value;

        //Chooses the target for the cost modification
        if (targetDropdown.captionText.text == DEFAULT_TARGET_STRING)
        {
            StartEffect();

            GameManager.instance.effectManager.SetModifyCostMode(adjustCostObject);
        }
        else
        {
            adjustCostObject.TargetCardType = (CardTypes)Enum.Parse(typeof(CardTypes), targetDropdown.captionText.text);
            GameManager.instance.effectManager.ModifyCostOfTargetCards(adjustCostObject);
            gameObject.SetActive(false);
        }
    }

    public void ResetButton()
    {
        ClearFields();
    }
}
