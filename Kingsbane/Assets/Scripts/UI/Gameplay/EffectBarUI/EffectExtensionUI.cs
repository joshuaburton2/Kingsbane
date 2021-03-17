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

    /// <summary>
    /// 
    /// Set the effect extension into confirmation mode
    /// Need to add this to the confirm button of the extension being clicked
    /// 
    /// </summary>
    protected void StartEffect()
    {
        effectUI.effectComplete = false;
    }
}
