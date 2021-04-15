using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using CategoryEnums;
using System;

public class ModifyCostEffect : EffectUI
{
     
    [SerializeField]
    private TMP_InputField costInput;
    [SerializeField]
    private TMP_Dropdown targetDropdown;
    [SerializeField]
    private TMP_Dropdown resourceDropdown;
    [SerializeField]
    private Button modifyButton;

    private const string DEFAULT_TARGET_STRING = "Target";
    private const string DEFAULT_RESOURCE_STRING = "None";

    /// <summary>
    /// 
    /// Inisitalise the effect UI
    /// 
    /// </summary>
    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        GeneralUIExtensions.InitDropdownOfType(targetDropdown, new List<CardTypes>() { CardTypes.Default }, DEFAULT_TARGET_STRING);
        GeneralUIExtensions.InitDropdownOfType(resourceDropdown, new List<CardResources>() { CardResources.Neutral }, DEFAULT_RESOURCE_STRING, true);

        ResetState();
    }

    /// <summary>
    /// 
    /// Reset the effect back to its default state
    /// 
    /// </summary>
    private void ResetState()
    {
        modifyButton.interactable = true;

    }

    /// <summary>
    /// 
    /// Cancel the modification effect
    /// 
    /// </summary>
    public override void CancelEffect()
    {
        base.CancelEffect();

        costInput.text = "";
        targetDropdown.value = 0;
        resourceDropdown.value = 0;
    }

    /// <summary>
    /// 
    /// Button click event for setting to modify cost mode
    /// 
    /// </summary>
    public void ModifyButton()
    {

        //Gets the card resource from the dropdown
        CardResources? cardResource;
        if (resourceDropdown.captionText.text == DEFAULT_RESOURCE_STRING)
            cardResource = null;
        else
            cardResource = (CardResources)Enum.Parse(typeof(CardResources), resourceDropdown.captionText.text);

        var value = -1;
        if(int.TryParse(costInput.text, out int result) && costInput.text != "0")
        {
            value = result;
        }
        else
        {
            value = -1;
            costInput.text = "-1";
        }

        //Chooses the target for the cost modification
        if (targetDropdown.captionText.text == DEFAULT_TARGET_STRING)
        {
            effectComplete = false;

            GameManager.instance.effectManager.SetModifyCostMode(value, cardResource);
        }
        else
        {
            var cardTarget = (CardTypes)Enum.Parse(typeof(CardTypes), targetDropdown.captionText.text);
            GameManager.instance.effectManager.ModifyCostOfTargetCards(value, cardTarget, cardResource);
        }
    }
}
