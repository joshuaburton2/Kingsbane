using TMPro;
using UnityEngine;
using UnityEngine.UI;

class HealingEffect : EffectUI
{
    [SerializeField]
    private Button healButton;
    [SerializeField]
    private TMP_InputField healValueInput;

    /// <summary>
    /// 
    /// Inisitalise the effect UI
    /// 
    /// </summary>
    public override void InitialiseEffectUI(EffectsBarUI.EffectTypes _effectType, GameplayUI _gameplayUI, EffectsBarUI _effectBarUI)
    {
        base.InitialiseEffectUI(_effectType, _gameplayUI, _effectBarUI);

        ResetState();

    }

    /// <summary>
    /// 
    /// Reset the effect back to its default state
    /// 
    /// </summary>
    private void ResetState()
    {
        healButton.interactable = true;
    }

    /// <summary>
    /// 
    /// Button click event for setting to healing mode
    /// 
    /// </summary>
    public void HealButton()
    {
        effectBarUI.ActivateEffect();
        effectComplete = false;

        if (string.IsNullOrWhiteSpace(healValueInput.text))
            healValueInput.text = "1";
        var healValue = int.Parse(healValueInput.text);
        //Forces the damage value to be a minimum of 1
        if (healValue <= 0)
        {
            healValueInput.text = "1";
            healValue = 1;
        }
        GameManager.instance.effectManager.SetHealMode(healValue);
    }

    /// <summary>
    /// 
    /// Button click event for setting to regenerate mode
    /// 
    /// </summary>
    public void RegenerateButton()
    {
        effectBarUI.ActivateEffect();
        effectComplete = false;

        GameManager.instance.effectManager.SetHealMode();
    }

    /// <summary>
    /// 
    /// Cancel the healing effect
    /// 
    /// </summary>
    public override void CancelEffect()
    {
        base.CancelEffect();

        healValueInput.text = "";
    }
}
