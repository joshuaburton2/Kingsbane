using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeployHeroEffect : EffectUI
{
    [SerializeField]
    private Button deployButton;
    [SerializeField]
    private Button cancelButton;

    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType)
    {
        base.InitialiseEffectUI(_effectType);

        deployButton.interactable = true;
        cancelButton.interactable = false;
    }

    public void DeployButtonClick()
    {

    }

    public void CancelButtonClick()
    {

    }
}
