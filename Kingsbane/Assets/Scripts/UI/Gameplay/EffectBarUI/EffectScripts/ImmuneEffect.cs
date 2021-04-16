using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImmuneEffect : EffectUI
{
    [SerializeField]
    private Button immuneButton;
    [SerializeField]
    private Button indestructibleButton;

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
        immuneButton.interactable = true;
        indestructibleButton.interactable = true;
    }

    /// <summary>
    /// 
    /// Button click event for setting to root mode
    /// 
    /// </summary>
    public void ImmuneButton()
    {
        effectComplete = false;

        GameManager.instance.effectManager.SetImmuneMode();
    }

    /// <summary>
    /// 
    /// Button click event for setting to stun mode
    /// 
    /// </summary>
    public void IndestructibleButton()
    {
        effectComplete = false;

        GameManager.instance.effectManager.SetIndestructibleMode();
    }
}
