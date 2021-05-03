using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckPassiveObject : MonoBehaviour, IPointerClickHandler
{
    Passive passive;

    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI passiveTypeText;
    [SerializeField]
    Image colourBorder;

    [SerializeField]
    Color upgradeColour;

    /// <summary>
    /// 
    /// Initialise the object. Refreshes the text properties of the upgrade
    /// 
    /// </summary>
    public void InitPassiveObject(Passive _passive)
    {
        passive = _passive;

        nameText.text = passive.Name;
        if (passive.SourceCard != null)
        {
            passiveTypeText.text = "Card";
            colourBorder.color = GameManager.instance.colourManager.GetRarityColour(passive.SourceCard.Rarity, passive.SourceCard.Class);
        }
        else if (passive.SourceUpgrade != null)
        {
            passiveTypeText.text = "Upgrade";
            colourBorder.color = upgradeColour;
        }
        else
        {
            throw new Exception("Passive not initialised properly");
        }
    }

    /// <summary>
    /// 
    /// Handler for clicking on the object
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        //Right click always shows the upgrade detail display
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (passive.SourceCard != null)
            {
                GameManager.instance.uiManager.ActivateCardDetail(passive.SourceCard);
            }
            else if (passive.SourceUpgrade != null)
            {
                GameManager.instance.uiManager.ActivateUpgradeDetail(passive.SourceUpgrade);
            }
            else
            {
                throw new Exception("Passive not initialised properly");
            }
        }
    }
}
