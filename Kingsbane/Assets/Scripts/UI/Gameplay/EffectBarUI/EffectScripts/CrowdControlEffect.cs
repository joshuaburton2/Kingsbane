using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrowdControlEffect : EffectUI
{
    [SerializeField]
    private Button rootButton;
    [SerializeField]
    private Button stunButton;

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
        rootButton.interactable = true;
        stunButton.interactable = true;
    }

    /// <summary>
    /// 
    /// Button click event for setting to root mode
    /// 
    /// </summary>
    public void RootButton()
    {
        effectComplete = false;

        GameManager.instance.effectManager.SetRootMode();
    }

    /// <summary>
    /// 
    /// Button click event for setting to stun mode
    /// 
    /// </summary>
    public void StunButton()
    {
        effectComplete = false;

        GameManager.instance.effectManager.SetStunMode();
    }
}
