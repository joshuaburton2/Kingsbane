using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MulliganEffect : EffectUI
{
    [SerializeField]
    private Button mulliganButton;

    /// <summary>
    /// 
    /// Inisitalise the effect UI
    /// 
    /// </summary>
    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI);

        mulliganButton.interactable = true;
    }

    /// <summary>
    /// 
    /// Button click event for the deploy button
    /// 
    /// </summary>
    public void MulliganButtonClick()
    {
        GameManager.instance.effectManager.MulliganHand();

        CompleteEffect();
    }

    /// <summary>
    /// 
    /// Complete the deploy hero effect
    /// 
    /// </summary>
    public override void CompleteEffect()
    {
        base.CompleteEffect();

        mulliganButton.interactable = false;

        gameplayUI.SetActionButtonState(true);
        gameplayUI.RefreshPlayerBar(GameManager.instance.ActivePlayerId);
    }
}
