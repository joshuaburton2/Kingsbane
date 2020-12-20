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

    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI);

        ResetState();
    }

    public void ResetState()
    {
        deployButton.interactable = true;
        cancelButton.interactable = false;

        gameplayUI.SetActionButtonState(false);
    }

    public void DeployButtonClick()
    {
        effectComplete = false;
        var heroUnit = GameManager.instance.GetActivePlayer().Hero;
        GameManager.instance.effectManager.SetSelectedUnit(heroUnit);
    }

    public void CancelButtonClick()
    {
        GameManager.instance.effectManager.RemoveAllPlayerUnits(GameManager.instance.GetActivePlayer());

        ResetState();
    }

    public override void CompleteEffect()
    {
        base.CompleteEffect();

        deployButton.interactable = false;
        cancelButton.interactable = true;

        gameplayUI.SetActionButtonState(true);
    }
}
