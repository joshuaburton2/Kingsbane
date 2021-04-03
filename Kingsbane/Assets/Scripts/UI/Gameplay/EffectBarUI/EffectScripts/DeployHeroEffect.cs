using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeployHeroEffect : EffectUI
{
    [SerializeField]
    private Button deployButton;
    [SerializeField]
    private Button cancelButton;

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
        deployButton.interactable = true;
        cancelButton.interactable = false;

        gameplayUI.SetActionButtonState(false);
    }

    /// <summary>
    /// 
    /// Button click event for the deploy button
    /// 
    /// </summary>
    public void DeployButtonClick()
    {
        effectComplete = false;
        var heroUnit = GameManager.instance.GetPlayer().Hero;
        GameManager.instance.effectManager.SetDeployUnit(heroUnit);
    }

    /// <summary>
    /// 
    /// Button click event for the cancel button
    /// 
    /// </summary>
    public void CancelButtonClick()
    {
        GameManager.instance.effectManager.RemoveAllPlayerUnits(GameManager.instance.GetPlayer());

        ResetState();
    }

    /// <summary>
    /// 
    /// Complete the deploy hero effect
    /// 
    /// </summary>
    public override void CompleteEffect()
    {
        base.CompleteEffect();

        deployButton.interactable = false;
        cancelButton.interactable = true;

        gameplayUI.SetActionButtonState(true);
    }
}
