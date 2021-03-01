using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectIndicator : MonoBehaviour
{
    [SerializeField]
    private Image statusColour;

    private Unit.StatusEffects statusEffect;

    /// <summary>
    /// 
    /// Initialises a status effect indicator on a unit counter
    /// 
    /// </summary>
    public void InitIndicator(Unit.StatusEffects _statusEffect)
    {
        statusEffect = _statusEffect;

        statusColour.color = GameManager.instance.colourManager.GetStatusEffectColour(statusEffect);
    }
}
