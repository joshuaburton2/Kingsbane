using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellbindEffect : EffectUI
{
    [SerializeField]
    private Button spellbindButton;
    [SerializeField]
    private Button restoreButton;

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
        spellbindButton.interactable = true;
        restoreButton.interactable = true;
    }

    /// <summary>
    /// 
    /// Button click event for setting to spellbind mode
    /// 
    /// </summary>
    public void SpellbindButton()
    {
        effectComplete = false;

        GameManager.instance.effectManager.SetSpellbindMode();
    }

    /// <summary>
    /// 
    /// Button click event for setting to restore enchantment mode
    /// 
    /// </summary>
    public void RestoreButton()
    {
        effectComplete = false;

        GameManager.instance.effectManager.SetRestoreEnchantmentMode();
    }
}
