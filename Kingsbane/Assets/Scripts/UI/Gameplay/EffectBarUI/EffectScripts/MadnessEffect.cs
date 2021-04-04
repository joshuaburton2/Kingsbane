using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadnessEffect : EffectUI
{
    [SerializeField]
    private Button madnessButton;

    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        ResetState();
    }

    public void ResetState()
    {
        madnessButton.interactable = true;
    }

    public void MadnessButton()
    {
        effectComplete = false;

        GameManager.instance.effectManager.SetMadnessMode();
    }
}
