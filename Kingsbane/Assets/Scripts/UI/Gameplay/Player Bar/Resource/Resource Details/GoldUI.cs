using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : ResourceDetailUI
{
    private PlayerGold ResourceGold { get { return (PlayerGold)playerResource; } }

    [SerializeField]
    private TMP_InputField goldInput;
    [SerializeField]
    private TMP_InputField bountyIncreaseInput;
    [SerializeField]
    private TMP_InputField bountyMultiplierInput;

    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        propertyText.text = $"Bounty: {ResourceGold.BountyGain}";
        goldInput.text = "";
        bountyIncreaseInput.text = "";
        bountyMultiplierInput.text = "";
    }

    public void GoldButton()
    {
        ResourceGold.ModifyValue(int.Parse(goldInput.text));
        RefreshResourceDetailUI();
    }

    public void BountyButton()
    {
        int increaseVal;
        int multiplierVal;
        if (!int.TryParse(bountyIncreaseInput.text, out increaseVal))
            increaseVal = 0;
        if (!int.TryParse(bountyMultiplierInput.text, out multiplierVal))
            multiplierVal = 1;

        ResourceGold.TriggerBounty(increaseVal, multiplierVal);

        RefreshResourceDetailUI();
    }
}
