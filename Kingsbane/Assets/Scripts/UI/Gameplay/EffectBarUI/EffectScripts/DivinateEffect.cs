using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DivinateEffect : EffectUI
{
    [SerializeField]
    private Button divinateButton;
    [SerializeField]
    private TMP_InputField divinateInput;
    [SerializeField]
    private Toggle activePlayerToggle;

    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        ResetState();
    }

    private void ResetState()
    {
        divinateButton.interactable = true;
        divinateInput.text = "";
        activePlayerToggle.isOn = true;
    }

    public void DivinateButton()
    {
        effectBarUI.ActivateEffect();
        effectComplete = false;

        var player = GameManager.instance.GetPlayer(activePlayerToggle.isOn);

        var divinateNumber = 1;
        if (string.IsNullOrWhiteSpace(divinateInput.text))
            divinateInput.text = "1";
        if (int.TryParse(divinateInput.text, out int result) || divinateInput.text != "0")
            divinateNumber = Mathf.Max(1, result);

        var canDivinate = player.InitDivinate(divinateNumber);

        if (!canDivinate)
            CancelEffect();
    }

    public override void CancelEffect()
    {
        base.CancelEffect();

        divinateInput.text = "";
        activePlayerToggle.isOn = true;
    }
}
