﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransformEffect : EffectUI
{
    [SerializeField]
    private TMP_InputField transformInput;
    [SerializeField]
    private Toggle isPermanentToggle;
    [SerializeField]
    private Button transformButton;

    private string titleText;

    /// <summary>
    /// 
    /// Initialise the effect UI
    /// 
    /// </summary>
    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        titleText = effectType.GetEnumDescription();

        ResetState();
    }

    /// <summary>
    /// 
    /// Resets the effect back to its default state
    /// 
    /// </summary>
    public void ResetState()
    {
        transformButton.interactable = true;
        isPermanentToggle.isOn = false;
    }

    /// <summary>
    /// 
    /// Button click event for setting to graveyard mode
    /// 
    /// </summary>
    public void TransformButton()
    {
        if (!GameManager.instance.effectManager.SetTransformMode(transformInput.text, isPermanentToggle.isOn))
            titleText += " (Failed)";
        else
        {
            effectBarUI.ActivateEffect();
            effectComplete = false;
        }
    }

    public override void CancelEffect()
    {
        base.CancelEffect();

        effectTitle.text = effectType.GetEnumDescription();
        transformInput.text = "";
        isPermanentToggle.isOn = false;
    }
}
