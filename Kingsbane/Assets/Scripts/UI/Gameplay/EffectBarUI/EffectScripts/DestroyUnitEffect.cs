using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DestroyUnitEffect : EffectUI
{
    [SerializeField]
    private Button destroyButton;
    [SerializeField]
    private Button removeButton;

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
        destroyButton.interactable = true;
        removeButton.interactable = true;
    }

    /// <summary>
    /// 
    /// Button click event for destroying a unit
    /// 
    /// </summary>
    public void DestroyButton()
    {
        effectComplete = false;
        GameManager.instance.effectManager.SetDestroyUnitMode();
    }

    /// <summary>
    /// 
    /// Button click event for removing a unit
    /// 
    /// </summary>
    public void RemoveButton()
    {
        effectComplete = false;
        GameManager.instance.effectManager.SetRemoveUnitMode();
    }
}
