using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Overall manager for the UI
/// 
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("Page Types")]
    [SerializeField]
    GameObject lobbyPage;
    [SerializeField]
    GameObject cardLibrary;

    [Header("Detail Displays")]
    [SerializeField]
    private GameObject cardDetailDisplay;
    [SerializeField]
    private GameObject upgradeDetailDisplay;

    private void Start()
    {
        cardDetailDisplay.SetActive(false);
        upgradeDetailDisplay.SetActive(false);
    }

    /// <summary>
    /// 
    /// Activates the card detail display
    /// 
    /// </summary>
    public void ActivateCardDetail(CardData cardData)
    {
        upgradeDetailDisplay.SetActive(false);
        cardDetailDisplay.SetActive(true);
        cardDetailDisplay.GetComponent<CardDetailUI>().ShowCardDetails(cardData);
    }

    /// <summary>
    /// 
    /// Activates the upgrade detail display
    /// 
    /// </summary>
    public void ActivateUpgradeDetail(UpgradeData upgradeData, DeckData currentDeck = null)
    {
        cardDetailDisplay.SetActive(false);
        upgradeDetailDisplay.SetActive(true);
        upgradeDetailDisplay.GetComponent<UpgradeDetailUI>().ShowUpgradeDetails(upgradeData, currentDeck);
    }

    /// <summary>
    /// 
    /// General function for closing a panel
    /// 
    /// </summary>
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    /// <summary>
    /// 
    /// Button click event for opening the game lobby
    /// 
    /// </summary>
    public void OpenLobby()
    {

    }

    /// <summary>
    /// 
    /// Button click event for opening the card library
    /// 
    /// </summary>
    public void OpenCardLibrary()
    {
        cardLibrary.SetActive(true);
        cardLibrary.GetComponent<CardLibraryParent>().RefreshCardLibrary();
    }

    /// <summary>
    /// 
    /// Button click event for exiting the game
    /// 
    /// </summary>
    public void ExitGame()
    {
        GameManager.instance.deckManager.SaveDecks();
        Application.Quit();
    }
}
