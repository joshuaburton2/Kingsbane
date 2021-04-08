using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileStatusEffect : EffectUI
{
    [SerializeField]
    private TMP_Dropdown tileStatusDropdown;
    [SerializeField]
    private Button tileStatusButton;

    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        GeneralUIExtensions.InitDropdownOfType(tileStatusDropdown, new List<TileStatuses>(), orderAlphabetical: true);

        ResetState();
    }

    private void ResetState()
    {
        tileStatusDropdown.value = 0;
        tileStatusButton.interactable = true;
    }

    public void SetStatusButton()
    {
        var tileStatus = (TileStatuses)Enum.Parse(typeof(TileStatuses), tileStatusDropdown.captionText.text.Replace(" ", ""));

        effectComplete = false;
        GameManager.instance.effectManager.SetTileStatusMode(tileStatus);
    }

    public override void CancelEffect()
    {
        base.CancelEffect();

        ResetState();
    }

    public override void CompleteEffect()
    {
        base.CompleteEffect();

        ResetState();
    }
}
