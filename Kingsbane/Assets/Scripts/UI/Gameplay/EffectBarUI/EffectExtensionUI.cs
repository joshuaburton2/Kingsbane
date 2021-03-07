using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExtensionUI : MonoBehaviour
{
    public EffectUI effectUI { get; set; }

    public virtual void RefreshEffectExtension(EffectUI _effectUI)
    {
        effectUI = _effectUI;
    }
}
