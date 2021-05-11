using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForetellingEffect : EffectUI
{
    [SerializeField]
    private Button fortuneTellerButton;
    [SerializeField]
    private Button alterFateButton;

    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        ResetState();
    }

    private void ResetState()
    {
        alterFateButton.interactable = true;
    }

    public void AlterFateButton()
    {
        effectBarUI.ActivateEffect();
        effectComplete = false;

        var player = GameManager.instance.GetPlayer();

        var canAlterFate = player.InitAlterFate();

        if (!canAlterFate)
            CancelEffect();
    }

    public void FortuneTellerButton()
    {
        effectBarUI.ActivateEffect();
        effectComplete = false;

        var player = GameManager.instance.GetPlayer();

        var canAlterFate = player.InitFortuneTeller();

        if (!canAlterFate)
            CancelEffect();
    }
}
