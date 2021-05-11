using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeployEffect : EffectUI
{
    [SerializeField]
    private Button deployButton;
    [SerializeField]
    private Button copyButton;
    [SerializeField]
    private TMP_InputField copyValueInputField;

    /// <summary>
    /// 
    /// Initialise the effect UI
    /// 
    /// </summary>
    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        ResetState();
    }

    /// <summary>
    /// 
    /// Resets the effect back to its default state
    /// 
    /// </summary>
    public void ResetState()
    {
        deployButton.interactable = true;
        copyButton.interactable = true;
        copyValueInputField.text = "";
    }

    /// <summary>
    /// 
    /// Button click event for setting to deployment mode
    /// 
    /// </summary>
    public void DeployButton()
    {
        ResetState();
        effectBarUI.ShowEffectExtension(effectType, this);
    }

    /// <summary>
    /// 
    /// Button click event for setting to copy unit mode
    /// 
    /// </summary>
    public void CopyButton()
    {
        effectBarUI.ActivateEffect();
        effectComplete = false;

        if (copyValueInputField.text == "" || copyValueInputField.text == "0")
            copyValueInputField.text = "1";

        var copyValue = 1;
        if (int.TryParse(copyValueInputField.text, out int result))
            copyValue = result;

        GameManager.instance.effectManager.SetCopyMode(copyValue);
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
