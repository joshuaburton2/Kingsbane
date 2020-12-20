﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectUI : MonoBehaviour
{
    protected EffectsBarUI.EffectTypes effectType;

    public bool effectComplete;

    protected GameplayUI gameplayUI;

    [SerializeField]
    private TextMeshProUGUI effectTitle;
    [SerializeField]
    private CanvasGroup buttonGroup;

    private void Update()
    {
        buttonGroup.interactable = !GameManager.instance.effectManager.isUILocked;

        if (!GameManager.instance.effectManager.isUILocked && !effectComplete)
        {
            if (!GameManager.instance.effectManager.CancelEffect)
            {
                CompleteEffect();
            }
            else
            {
                GameManager.instance.effectManager.CancelEffect = false;
                effectComplete = true;
            }
        }
    }

    public virtual void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI)
    {
        effectComplete = true;
        effectType = _effectType;
        effectTitle.text = _effectType.GetEnumDescription();
        gameplayUI = _gameplayUI;
        buttonGroup.interactable = true;
    }

    public virtual void CompleteEffect()
    {
        effectComplete = true;
    }
}
