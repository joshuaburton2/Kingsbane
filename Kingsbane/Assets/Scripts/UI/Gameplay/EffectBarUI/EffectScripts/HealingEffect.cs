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
        healButton.interactable = true;
    }

    /// <summary>
    /// 
    /// Button click event for setting to deal damage mode
    /// 
    /// </summary>
    public void HealButton()
    {
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
    /// Complete the deal damage effect
    /// 
    /// </summary>
    public override void CompleteEffect()
    {
        base.CompleteEffect();

        healValueInput.text = "";
    }
}
