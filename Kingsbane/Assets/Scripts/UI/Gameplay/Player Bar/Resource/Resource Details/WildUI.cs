using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WildUI : ResourceDetailUI
{
    private PlayerWild ResourceWild { get { return (PlayerWild)playerResource; } }

    [SerializeField]
    private TMP_InputField wildInput;
    [SerializeField]
    private TMP_InputField cycleInput;

    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        propertyText.text = $"Max Wild: {ResourceWild.MaxWild}";
        wildInput.text = "";
        cycleInput.text = "";
    }

    public void WildButton()
    {
        if (int.TryParse(wildInput.text, out int wildVal))
            ResourceWild.ModifyValue(wildVal);

        RefreshResourceDetailUI();
    }

    public void CycleButton()
    {
        if (int.TryParse(cycleInput.text, out int cycleVal))
            ResourceWild.ModifyValue(cycleVal);

        RefreshResourceDetailUI();
    }
}
