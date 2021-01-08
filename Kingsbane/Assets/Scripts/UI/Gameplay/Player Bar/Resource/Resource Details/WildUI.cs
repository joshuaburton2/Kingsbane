using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WildUI : ResourceDetailUI
{
    //Converts the player resource to wild
    private PlayerWild ResourceWild { get { return (PlayerWild)playerResource; } }

    [SerializeField]
    private TMP_InputField wildInput;
    [SerializeField]
    private TMP_InputField cycleInput;

    /// <summary>
    /// 
    /// Refreshes the resource details
    /// 
    /// </summary>
    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        propertyText.text = $"Max Wild: {ResourceWild.MaxWild}";
        wildInput.text = "";
        cycleInput.text = "";
    }

    /// <summary>
    /// 
    /// Button click event for increasing wild
    /// 
    /// </summary>
    public void WildButton()
    {
        if (int.TryParse(wildInput.text, out int wildVal))
            ResourceWild.ModifyValue(wildVal);

        RefreshResourceDetailUI();
    }

    /// <summary>
    /// 
    /// Button click event for triggering cycle effects
    /// 
    /// </summary>
    public void CycleButton()
    {
        if (int.TryParse(cycleInput.text, out int cycleVal))
            ResourceWild.CycleWild(cycleVal);

        RefreshResourceDetailUI();
    }
}
