using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using UnityEngine;

/// <summary>
///
/// Script for handling the card list UI on the player bar
/// 
/// </summary>
public class CardListsUI : MonoBehaviour
{
    public enum TabTypes
    {
        [Description("Deck")]
        Deck,
        [Description("Graveyard")]
        Graveyard,
        [Description("Discarded")]
        Discard,
        [Description("Upgrades")]
        Upgrades,
    }

    private TabTypes selectedTab;
    private Player player;

    [Header("Tab Objects")]
    [SerializeField]
    private GameObject tabPrefab;
    [SerializeField]
    private GameObject tabParent;
    [SerializeField]
    private List<CardListTab> cardListTabs;
    [SerializeField]
    private bool isTabTextTop;

    [Header("List OBjects")]
    [SerializeField]
    private GameObject cardListPrefab;
    [SerializeField]
    private GameObject upgradeListPrefab;
    [SerializeField]
    private GameObject listParent;
    [SerializeField]
    private TextMeshProUGUI listCountText;

    /// <summary>
    /// 
    /// Initialises the card list. Should be called at the begining of the gameplayer section.
    /// 
    /// </summary>
    public void InitCardLists(Player _player)
    {
        player = _player;

        //Creates the tab objects
        foreach (var tab in Enum.GetValues(typeof(TabTypes)))
        {
            var tabType = (TabTypes)tab;
            var tabObject = Instantiate(tabPrefab, tabParent.transform);

            var tabObjectScript = tabObject.GetComponent<CardListTab>();
            tabObjectScript.InitTab(this, tabType, isTabTextTop);
            cardListTabs.Add(tabObjectScript);
        }
        SelectTab(TabTypes.Deck);

        RefreshCurrentList();
    }

    /// <summary>
    /// 
    /// Refreshes the currently selected list with the selected tab option
    /// 
    /// </summary>
    public void RefreshCurrentList()
    {
        GameManager.DestroyAllChildren(listParent);

        //Switch for determining which tab is selected
        switch (selectedTab)
        {
            case TabTypes.Deck:
                //Copies the deck list and reverses it since drawing from the deck draws from the end of the list
                var deckList = player.Deck.cardList.ToList();
                deckList.Reverse();
                RefreshCardList(deckList);
                break;
            case TabTypes.Graveyard:
                RefreshCardList(player.Graveyard.cardList.OrderByDescending(x => x.TotalResource).ToList());
                break;
            case TabTypes.Discard:
                RefreshCardList(player.Discard.cardList.OrderByDescending(x => x.TotalResource).ToList());
                break;
            case TabTypes.Upgrades:
                foreach (var upgrade in player.Upgrades.OrderBy(x => x.Name))
                {
                    var upgradeListObject = Instantiate(upgradeListPrefab, listParent.transform);
                    upgradeListObject.GetComponent<DeckUpgradeObject>().InitUpgradeObject(upgrade);
                }
                UpdateListCountText(player.Upgrades.Count);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 
    /// Refreshes the list of cards
    /// 
    /// </summary>
    private void RefreshCardList(List<Card> cardList)
    {
        foreach (var card in cardList)
        {
            var cardListObject = Instantiate(cardListPrefab, listParent.transform);
            cardListObject.GetComponent<DeckCardObject>().InitCardObject(card);
        }
        UpdateListCountText(cardList.Count);
    }

    /// <summary>
    /// 
    /// Updates the given list count text
    /// 
    /// </summary>
    private void UpdateListCountText(int listCount)
    {
        listCountText.text = $"Count: {listCount}";
    }

    /// <summary>
    /// 
    /// Function for selecting a tab of a given type
    /// 
    /// </summary>
    public void SelectTab(TabTypes tabType)
    {
        selectedTab = tabType;

        RefreshCurrentList();
        //Loops through the tab list. If the tab type is of the given type then, the tab is selected
        foreach (var tab in cardListTabs)
            tab.UpdateSelectedColour(tab.TabType == tabType);
    }
}
