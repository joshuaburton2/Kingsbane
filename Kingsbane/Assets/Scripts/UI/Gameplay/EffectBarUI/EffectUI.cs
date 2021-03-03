using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectUI : MonoBehaviour
{
    protected EffectsBarUI.EffectTypes effectType;

    public bool effectComplete;

    protected GameplayUI gameplayUI;
    protected EffectsBarUI effectBarUI;

    [SerializeField]
    private TextMeshProUGUI effectTitle;
    [SerializeField]
    private CanvasGroup buttonGroup;

    private void Update()
    {
        buttonGroup.interactable = !GameManager.instance.effectManager.IsUILocked;

        if (!GameManager.instance.effectManager.IsUILocked && !effectComplete)
        {
            if (GameManager.instance.effectManager.CancelEffect)
                CancelEffect();
            else
                CompleteEffect();
        }
    }

    public virtual void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        effectComplete = true;
        effectType = _effectType;
        effectTitle.text = _effectType.GetEnumDescription();
        gameplayUI = _gameplayUI;
        effectBarUI = _effectBarUI;
        buttonGroup.interactable = true;
    }

    public virtual void CompleteEffect()
    {
        effectComplete = true;
    }

    public virtual void CancelEffect()
    {
        GameManager.instance.effectManager.CancelEffect = false;
        effectComplete = true;
    }
}
