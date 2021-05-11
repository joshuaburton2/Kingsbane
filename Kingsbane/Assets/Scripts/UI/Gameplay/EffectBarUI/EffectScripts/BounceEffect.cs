using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceEffect : EffectUI
{
    [SerializeField]
    private Button returnToHandButton;
    [SerializeField]
    private Button redeployButton;

    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        ResetState();
    }

    private void ResetState()
    {
        returnToHandButton.interactable = true;
        redeployButton.interactable = true;
    }

    public void ReturnToHandButton()
    {
        effectBarUI.ActivateEffect();
        effectComplete = false;

        GameManager.instance.effectManager.SetReturnToHandMode();
    }

    public void RedeployButton()
    {
        effectBarUI.ActivateEffect();
        effectComplete = false;

        GameManager.instance.effectManager.SetRedeployMode();
    }
}
