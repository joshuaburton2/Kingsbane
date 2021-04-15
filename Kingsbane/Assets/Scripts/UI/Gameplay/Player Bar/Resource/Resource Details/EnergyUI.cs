using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : ResourceDetailUI
{
    //Converts the player resource to energy
    private PlayerEnergy ResourceEnergy { get { return (PlayerEnergy)playerResource; } }

    [SerializeField]
    private TMP_InputField energyInput;
    [SerializeField]
    private Button surgeButton;

    /// <summary>
    /// 
    /// Refreshes the resource details
    /// 
    /// </summary>
    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        valueText.text = $"{playerResource.ResourceType}: {playerResource.Value}/{ResourceEnergy.BaseEnergyGain}";
        propertyText.text = $"Surges: {ResourceEnergy.Surges}";
        energyInput.text = "";
        surgeButton.interactable = !ResourceEnergy.UsedSurge;
    }

    /// <summary>
    /// 
    /// Button click event for increasing energy for the turn
    /// 
    /// </summary>
    public void EnergyButton()
    {
        if (int.TryParse(energyInput.text, out int energyVal))
            ResourceEnergy.ModifyValue(energyVal);

        playerBar.RefreshPlayerBar();
    }

    /// <summary>
    /// 
    /// Button click event for activating a surge
    /// 
    /// </summary>
    public void SurgeButton()
    {
        ResourceEnergy.UseSurge();
        playerBar.RefreshPlayerBar();
    }
}
