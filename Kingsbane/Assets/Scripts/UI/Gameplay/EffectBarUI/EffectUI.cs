using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectUI : MonoBehaviour
{
    protected EffectsBarUI.EffectTypes effectType;

    [SerializeField]
    private TextMeshProUGUI effectTitle;
    [SerializeField]
    private CanvasGroup buttonGroup;

    private void Update()
    {
        buttonGroup.interactable = GameManager.instance.effectManager.isUILocked;
    }

    public virtual void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType)
    {
        effectType = _effectType;
        effectTitle.text = _effectType.GetEnumDescription();
        buttonGroup.interactable = true;
    }
}
