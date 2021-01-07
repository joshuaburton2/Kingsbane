using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaUI : ResourceDetailUI
{
    private PlayerMana ResourceMana { get { return (PlayerMana)playerResource; } }

    [SerializeField]
    private TMP_InputField manaInput;

    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        propertyText.text = $"Overload: {ResourceMana.TotalOverload}";
        manaInput.text = "";
    }

    public void ManaButton()
    {
        if (int.TryParse(manaInput.text, out int manaVal))
            ResourceMana.ModifyValue(manaVal);

        RefreshResourceDetailUI();
    }
}
