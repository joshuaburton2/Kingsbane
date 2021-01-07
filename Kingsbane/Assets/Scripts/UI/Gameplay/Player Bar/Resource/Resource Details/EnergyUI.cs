using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : ResourceDetailUI
{
    private PlayerEnergy ResourceEnergy { get { return (PlayerEnergy)playerResource; } }

    [SerializeField]
    private TMP_InputField energyInput;
    [SerializeField]
    private Button surgeButton;

    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        propertyText.text = $"Surges: {ResourceEnergy.Surges}";
        energyInput.text = "";
        surgeButton.interactable = !ResourceEnergy.UsedSurge;
    }

    public void EnergyButton()
    {
        if (int.TryParse(energyInput.text, out int energyVal))
            ResourceEnergy.ModifyValue(energyVal);

        RefreshResourceDetailUI();
    }

    public void SurgeButton()
    {
        ResourceEnergy.UseSurge();
        RefreshResourceDetailUI();
    }
}
