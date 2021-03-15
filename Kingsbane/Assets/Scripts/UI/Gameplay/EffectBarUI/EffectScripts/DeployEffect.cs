using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeployEffect : EffectUI
{
    [SerializeField]
    private Button deployButton;

    /// <summary>
    /// 
    /// Initialise the effect UI
    /// 
    /// </summary>
    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        ResetState();
    }

    /// <summary>
    /// 
    /// Resets the effect back to its default state
    /// 
    /// </summary>
    public void ResetState()
    {
        deployButton.interactable = true;
    }

    /// <summary>
    /// 
    /// Button click event for setting to deployment mode
    /// 
    /// </summary>
    public void DeployButton()
    {
        effectBarUI.ShowEffectExtension(effectType, this);
    }
}
