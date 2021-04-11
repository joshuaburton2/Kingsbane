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
    protected TextMeshProUGUI effectTitle;
    [SerializeField]
    private CanvasGroup buttonGroup;

    private void Update()
    {
        buttonGroup.interactable = !GameManager.instance.effectManager.IsUILocked;

        //If not in the basic game effects and the effec
        if (!GameManager.instance.effectManager.IsUILocked && !effectComplete)
        {
            if (GameManager.instance.effectManager.CancelEffect)
                CancelEffect();
            else
                CompleteEffect();
        }
    }

    /// <summary>
    /// 
    /// Initialises the effect UI
    /// 
    /// </summary>
    public virtual void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        effectComplete = true;
        effectType = _effectType;
        effectTitle.text = _effectType.GetEnumDescription();
        gameplayUI = _gameplayUI;
        effectBarUI = _effectBarUI;
        buttonGroup.interactable = true;
    }

    /// <summary>
    /// 
    /// Virtual function for completing the effect
    /// 
    /// </summary>
    public virtual void CompleteEffect()
    {
        effectComplete = true;
    }

    /// <summary>
    /// 
    /// Virtual function for cancelling the effect
    /// 
    /// </summary>
    public virtual void CancelEffect()
    {
        GameManager.instance.effectManager.CancelEffect = false;
        effectComplete = true;
    }
}
