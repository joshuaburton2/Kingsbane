using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

class DealDamageEffect : EffectUI
{
    [SerializeField]
    private Button damageButton;
    [SerializeField]
    private TMP_InputField damageValueInput;
    [SerializeField]
    private Toggle deadlyToggle;
    [SerializeField]
    private Toggle lifebondToggle;
    [SerializeField]
    private Toggle piercingToggle;

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
        damageButton.interactable = true;
        deadlyToggle.isOn = false;
        lifebondToggle.isOn = false;
        piercingToggle.isOn = false;
    }

    /// <summary>
    /// 
    /// Button click event for setting to deal damage mode
    /// 
    /// </summary>
    public void DealDamageButton()
    {
        effectBarUI.ActivateEffect();
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

        var keywordList = new List<Keywords>();
        if (deadlyToggle.isOn)
            keywordList.Add(Keywords.Deadly);
        if (lifebondToggle.isOn)
            keywordList.Add(Keywords.Lifebond);
        if (piercingToggle.isOn)
            keywordList.Add(Keywords.Piercing);

        GameManager.instance.effectManager.SetDealDamageMode(damageValue, keywordList);
    }

    /// <summary>
    /// 
    /// Cancel the deal damage effect
    /// 
    /// </summary>
    public override void CancelEffect()
    {
        base.CancelEffect();

        damageValueInput.text = "";
        deadlyToggle.isOn = false;
        lifebondToggle.isOn = false;
        piercingToggle.isOn = false;
    }
}
