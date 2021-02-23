using TMPro;
using UnityEngine;
using UnityEngine.UI;

class DealDamageEffect : EffectUI
{
    [SerializeField]
    private Button damageButton;
    [SerializeField]
    private TMP_InputField damageValueInput;

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
        damageButton.interactable = true;
    }

    /// <summary>
    /// 
    /// Button click event for setting to deal damage mode
    /// 
    /// </summary>
    public void DealDamageButton()
    {
        effectComplete = false;

        if (string.IsNullOrWhiteSpace(damageValueInput.text))
            damageValueInput.text = "1";
        var damageValue = int.Parse(damageValueInput.text);
        //Forces the damage value to be a minimum of 1
        if (damageValue <= 0)
        {
            damageValueInput.text = "1";
            damageValue = 1;
        }
        GameManager.instance.effectManager.SetDealDamageMode(damageValue);
    }

    /// <summary>
    /// 
    /// Complete the deal damage effect
    /// 
    /// </summary>
    public override void CompleteEffect()
    {
        base.CompleteEffect();

        damageValueInput.text = "";
    }
}
