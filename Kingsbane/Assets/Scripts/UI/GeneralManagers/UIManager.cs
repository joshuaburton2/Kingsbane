﻿using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActiveMainPanels
{
    Default,
    Campaign,
    Lobby,
    Gameplay,
    Library,
}

/// <summary>
/// 
/// Overall manager for the UI
/// 
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject currentSceneController;

    [Header("Main Menu Pages")]
    [SerializeField]
    GameObject lobbyPage;
    [SerializeField]
    GameObject cardLibrary;

    [Header("Detail Displays")]
    [SerializeField]
    private GameObject cardDetailDisplay;
    [SerializeField]
    private GameObject upgradeDetailDisplay;

    [Header("Other Properties")]
    public ActiveMainPanels activeMainPanel;

    private void Start()
    {
        cardDetailDisplay.SetActive(false);
        upgradeDetailDisplay.SetActive(false);

        activeMainPanel = ActiveMainPanels.Default;

        if (GameManager.instance.sceneManager.ActiveScene == SceneList.MainMenuScene)
        {
            lobbyPage.SetActive(false);
            cardLibrary.SetActive(false);
        }
    }

    /// <summary>
    /// 
    /// Finds the detail displays in the scene
    /// 
    /// </summary>
    public void SyncDetailDisplays()
    {
        cardDetailDisplay = GameObject.FindGameObjectWithTag("CardDetailDisplay");
        upgradeDetailDisplay = GameObject.FindGameObjectWithTag("UpgradeDetailDisplay");
    }

    /// <summary>
    /// 
    /// Find the required pages for the main menu
    /// 
    /// </summary>
    public void SyncMenuPages()
    {
        currentSceneController = GameObject.FindGameObjectWithTag("MainMenuUIController");
        var mainMenuUIReferences = currentSceneController.GetComponent<MainMenuUIReferences>();

        cardDetailDisplay = mainMenuUIReferences.cardDetailDisplay;
        upgradeDetailDisplay = mainMenuUIReferences.upgradeDetailDisplay;
        lobbyPage = mainMenuUIReferences.lobbyUI;
        cardLibrary = mainMenuUIReferences.libraryUI;
    }

    /// <summary>
    /// 
    /// Find the required pages for the gameplay section
    /// 
    /// </summary>
    public void SyncGameplayPages()
    {
        currentSceneController = GameObject.FindGameObjectWithTag("GameplayUIController");
        var gameplayUIReferences = currentSceneController.GetComponent<GameplayUIReferences>();

        cardDetailDisplay = gameplayUIReferences.cardDetailDisplay;
        upgradeDetailDisplay = gameplayUIReferences.upgradeDetailDisplay;
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
        lobbyPage.SetActive(true);
        lobbyPage.GetComponent<LobbyUI>().LoadLobbyUI();
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
