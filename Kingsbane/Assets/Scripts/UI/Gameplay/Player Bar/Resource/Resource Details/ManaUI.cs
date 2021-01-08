using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaUI : ResourceDetailUI
{
    //Converts the player resource to mana
    private PlayerMana ResourceMana { get { return (PlayerMana)playerResource; } }

    [SerializeField]
    private TMP_InputField manaInput;

    /// <summary>
    /// 
    /// Refreshes the resource details
    /// 
    /// </summary>
    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        propertyText.text = $"Overload: {ResourceMana.TotalOverload}";
        manaInput.text = "";
    }

    /// <summary>
    /// 
    /// Button click event for increasing mana
    /// 
    /// </summary>
    public void ManaButton()
    {
        if (int.TryParse(manaInput.text, out int manaVal))
            ResourceMana.ModifyValue(manaVal);

        RefreshResourceDetailUI();
    }
}
