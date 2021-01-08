using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : ResourceDetailUI
{
    //Converts the player resource to gold
    private PlayerGold ResourceGold { get { return (PlayerGold)playerResource; } }

    [SerializeField]
    private TMP_InputField goldInput;
    [SerializeField]
    private TMP_InputField bountyIncreaseInput;
    [SerializeField]
    private TMP_InputField bountyMultiplierInput;

    /// <summary>
    /// 
    /// Refreshes the resource details
    /// 
    /// </summary>
    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        propertyText.text = $"Bounty: {ResourceGold.BountyGain}";
        goldInput.text = "";
        bountyIncreaseInput.text = "";
        bountyMultiplierInput.text = "";
    }

    /// <summary>
    /// 
    /// Button click event for gaining gold not through bounty
    /// 
    /// </summary>
    public void GoldButton()
    {
        ResourceGold.ModifyValue(int.Parse(goldInput.text));
        RefreshResourceDetailUI();
    }

    /// <summary>
    /// 
    /// Button click event for gaining bounty. Incorporates the increase and multiplier to the bounty
    /// 
    /// </summary>
    public void BountyButton()
    {
        //Tries to parse the input as an int, otherwise sets them as the default value
        if (!int.TryParse(bountyIncreaseInput.text, out var increaseVal))
            increaseVal = 0;
        if (!int.TryParse(bountyMultiplierInput.text, out var multiplierVal))
            multiplierVal = 1;

        ResourceGold.TriggerBounty(increaseVal, multiplierVal);

        RefreshResourceDetailUI();
    }
}
