using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static CardListsUI;

/// <summary>
/// 
/// Script for handling the different tabs in the card list area
/// 
/// </summary>
public class CardListTab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tabText;
    [SerializeField]
    private Color selectedColour;
    [SerializeField]
    private Color unSelectedColour;
    [SerializeField]
    private Image tabBackground;

    public TabTypes TabType { get; set; }
    private CardListsUI CardListUI { get; set; }

    /// <summary>
    /// 
    /// Initialises the card list tab
    /// 
    /// </summary>
    /// <param name="isTop">Used to determine the alignment of the text based on which side of the canvas the panel is on</param>
    public void InitTab(CardListsUI _cardListUI, TabTypes _tabType, bool isTop)
    {
        CardListUI = _cardListUI;
        TabType = _tabType;

        tabText.text = TabType.GetEnumDescription();

        //tabText.alignment = isTop ? TextAlignmentOptions.Top : TextAlignmentOptions.Bottom;
        if (isTop)
        {
            tabText.gameObject.GetComponent<RectTransform>().SetBottom(15.0f);
        }
        else
        {
            tabText.gameObject.GetComponent<RectTransform>().SetTop(15.0f);
        }
    }

    /// <summary>
    /// 
    /// Button click event for selecting the tab
    /// 
    /// </summary>
    public void SelectTab()
    {
        CardListUI.SelectTab(TabType);
    }

    /// <summary>
    /// 
    /// Updates the tab with the selected colour or not
    /// 
    /// </summary>
    /// <param name="isSelected"></param>
    public void UpdateSelectedColour(bool isSelected)
    {
        tabBackground.color = isSelected ? selectedColour : unSelectedColour;
    }
}
