using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptainOfTheGuardEffect : EffectUI
{
    [SerializeField]
    private Button confiscateButton;
    [SerializeField]
    private Button imprisonButton;

    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        ResetState();
    }

    private void ResetState()
    {
        confiscateButton.interactable = true;
        imprisonButton.interactable = true;
    }

    public void ConfiscateButton()
    {
        effectComplete = false;

        GameManager.instance.effectManager.SetConfiscateMode();
    }

    public void ImprisonButton()
    {
        effectComplete = false;

        GameManager.instance.effectManager.SetImprisonMode();
    }
}
