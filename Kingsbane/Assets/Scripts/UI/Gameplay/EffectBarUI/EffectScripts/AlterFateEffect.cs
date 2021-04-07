using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlterFateEffect : EffectUI
{
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
        effectComplete = false;

        var player = GameManager.instance.GetPlayer();

        var canAlterFate = player.InitAlterFate();

        if (!canAlterFate)
            CancelEffect();
    }
}
