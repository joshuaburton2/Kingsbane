using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel;
using System;
using CategoryEnums;

public class RecruitEffect : EffectUI
{
    public enum RecruitTypes
    {
        [Description("Deployed Unit")]
        DeployedUnit,
        [Description("Top Of Deck")]
        TopOfDeck,
        [Description("Spycraft")]
        Spycraft,
        [Description("Spymaster Luren")]
        SpymasterLuren,
    }

    [SerializeField]
    private TMP_Dropdown recruitTypeDropdown;
    [SerializeField]
    private Button recruitButton;

    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        GeneralUIExtensions.InitDropdownOfType(recruitTypeDropdown, new List<RecruitTypes>());

        ResetState();
    }

    /// <summary>
    /// 
    /// Reset the effect back to its default state
    /// 
    /// </summary>
    private void ResetState()
    {
        recruitButton.interactable = true;
        recruitTypeDropdown.value = 0;
    }

    public void RecruitButton()
    {
        if (GameManager.instance.GetPlayer().UsedResources.Contains(CardResources.Gold))
        {
            var recruitType = (RecruitTypes)Enum.Parse(typeof(RecruitTypes), recruitTypeDropdown.captionText.text.Replace(" ", ""));

            switch (recruitType)
            {
                case RecruitTypes.DeployedUnit:
                    effectBarUI.ActivateEffect();
                    effectComplete = false;
                    GameManager.instance.effectManager.SetUnitRecruitMode();
                    break;
                case RecruitTypes.TopOfDeck:
                    GameManager.instance.effectManager.RecruitTopOfDeck();
                    break;
                case RecruitTypes.Spycraft:
                    effectBarUI.ActivateEffect();
                    effectComplete = false;
                    var numToSpycraft = 3;
                    GameManager.instance.effectManager.SetSpycraftChoiceMode(numToSpycraft);
                    break;
                case RecruitTypes.SpymasterLuren:
                    var numToRecruit = 3;
                    GameManager.instance.effectManager.SpymasterLurenEffect(numToRecruit);
                    break;
                default:
                    throw new Exception("Not a valid recruit type.");
            }
        }
    }

    public override void CancelEffect()
    {
        base.CancelEffect();

        ResetState();
    }

    public override void CompleteEffect()
    {
        base.CompleteEffect();

        ResetState();
    }
}
