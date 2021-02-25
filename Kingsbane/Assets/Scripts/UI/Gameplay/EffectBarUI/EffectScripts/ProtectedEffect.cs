using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProtectedEffect : EffectUI
{
    [SerializeField]
    private Button protectedButton;
    [SerializeField]
    private TMP_InputField protectedValueInput;
    [SerializeField]
    private Toggle temporaryToggle;

    /// <summary>
    /// 
    /// Inisitalise the effect UI
    /// 
    /// </summary>
    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI);

        ResetState();

    }

    /// <summary>
    /// 
    /// Reset the effect back to its default state
    /// 
    /// </summary>
    private void ResetState()
    {
        protectedButton.interactable = true;
        temporaryToggle.isOn = false;
    }

    /// <summary>
    /// 
    /// Button click event for setting to protected mode
    /// 
    /// </summary>
    public void ProtectedButton()
    {
        effectComplete = false;

        if (string.IsNullOrWhiteSpace(protectedValueInput.text))
            protectedValueInput.text = "1";
        var protectedValue = int.Parse(protectedValueInput.text);
        //Forces the damage value to be a minimum of 1
        if (protectedValue <= 0)
        {
            protectedValueInput.text = "1";
            protectedValue = 1;
        }
        GameManager.instance.effectManager.SetProtectedMode(protectedValue, temporaryToggle.isOn);
    }

    /// <summary>
    /// 
    /// Button click event for setting to infinite protected mode
    /// 
    /// </summary>
    public void InfiniteProtectedButton()
    {
        effectComplete = false;

        temporaryToggle.isOn = true;
        GameManager.instance.effectManager.SetProtectedMode(null, temporaryToggle.isOn);
    }

    /// <summary>
    /// 
    /// Cancel the deal damage effect
    /// 
    /// </summary>
    public override void CancelEffect()
    {
        base.CancelEffect();

        protectedValueInput.text = "";
        temporaryToggle.isOn = false;
    }
}