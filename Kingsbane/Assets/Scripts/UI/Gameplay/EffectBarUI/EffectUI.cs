using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectUI : MonoBehaviour
{
    protected EffectsBarUI.EffectTypes effectType;

    public virtual void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType)
    {
        effectType = _effectType;
    }
}
