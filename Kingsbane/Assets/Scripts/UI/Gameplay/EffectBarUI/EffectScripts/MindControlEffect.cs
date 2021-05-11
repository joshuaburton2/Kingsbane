using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MindControlEffect : EffectUI
{
    [SerializeField]
    private Button mindControlButton;
    [SerializeField]
    private Toggle isActiveToggle;
    [SerializeField]
    private Toggle isTemporaryToggle;

    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        ResetState();
    }

    private void ResetState()
    {
        mindControlButton.interactable = true;
        isActiveToggle.isOn = true;
        isTemporaryToggle.isOn = false;
    }

    public void MindControlButton()
    {
        effectBarUI.ActivateEffect();
        effectComplete = false;

        GameManager.instance.effectManager.SetMindControlMode(isActiveToggle.isOn, isTemporaryToggle.isOn);
    }

    public override void CancelEffect()
    {
        base.CancelEffect();

        isActiveToggle.isOn = true;
        isTemporaryToggle.isOn = false;
    }
}
