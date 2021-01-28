using CategoryEnums;
using System;
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

    public bool OverGameplayArea { get; set; }

    [Header("Main Menu Pages")]
    [SerializeField]
    GameObject lobbyPage;
    [SerializeField]
    GameObject cardLibrary;

    [Header("Gameplay Pages")]
    [SerializeField]
    public GameObject gameplayUI;

    [Header("Detail Displays")]
    [SerializeField]
    private GameObject cardDetailDisplay;
    [SerializeField]
    private GameObject upgradeDetailDisplay;

    [Header("Other Properties")]
    public ActiveMainPanels activeMainPanel;

    /// <summary>
    /// 
    /// Find the required pages for the main menu
    /// 
    /// </summary>
    public void SyncMenuPages()
    {
        activeMainPanel = ActiveMainPanels.Default;

        currentSceneController = GameObject.FindGameObjectWithTag("MainMenuUIController");
        var mainMenuUIReferences = currentSceneController.GetComponent<MainMenuUIReferences>();

        cardDetailDisplay = mainMenuUIReferences.cardDetailDisplay;
        upgradeDetailDisplay = mainMenuUIReferences.upgradeDetailDisplay;
        lobbyPage = mainMenuUIReferences.lobbyUI;
        cardLibrary = mainMenuUIReferences.libraryUI;

        cardDetailDisplay.SetActive(false);
        upgradeDetailDisplay.SetActive(false);
        lobbyPage.SetActive(false);
        cardLibrary.SetActive(false);
    }

    /// <summary>
    /// 
    /// Find the required pages for the gameplay section
    /// 
    /// </summary>
    public void SyncGameplayPages()
    {
        activeMainPanel = ActiveMainPanels.Gameplay;

        currentSceneController = GameObject.FindGameObjectWithTag("GameplayUIController");
        var gameplayUIReferences = currentSceneController.GetComponent<GameplayUIReferences>();

        cardDetailDisplay = gameplayUIReferences.cardDetailDisplay;
        upgradeDetailDisplay = gameplayUIReferences.upgradeDetailDisplay;
        gameplayUI = gameplayUIReferences.gameplayUI;

        gameplayUI.SetActive(true);
        cardDetailDisplay.SetActive(false);
        upgradeDetailDisplay.SetActive(false);

        gameplayUI.GetComponent<GameplayUI>().InitialiseUI();
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
    /// Refreshes the UI based on the scene currently in
    /// 
    /// </summary>
    public void RefreshUI()
    {
        switch (GameManager.instance.sceneManager.ActiveScene)
        {
            case SceneList.MainMenuScene:
                throw new Exception("Not a valid scene to refresh");
            case SceneList.GameplayScene:
                gameplayUI.GetComponent<GameplayUI>().RefreshPlayerBar();
                break;
            default:
                throw new Exception("Not a valid scene to refresh");
        }
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
}
