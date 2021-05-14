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
    private Button modifyButton;

    /// <summary>
    /// 
    /// Inisitalise the effect UI
    /// 
    /// </summary>
    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);


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
    /// Button click event for setting to modify cost mode
    /// 
    /// </summary>
    public void ModifyButton()
    {
        effectBarUI.ShowEffectExtension(effectType, this);
    }
}
