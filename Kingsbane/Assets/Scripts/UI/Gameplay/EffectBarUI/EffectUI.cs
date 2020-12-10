using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EffectUI : MonoBehaviour
{
    protected EffectsBarUI.EffectTypes effectType;

    [SerializeField]
    private TextMeshProUGUI effectTitle;

    public virtual void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType)
    {
        effectType = _effectType;
    }
}
