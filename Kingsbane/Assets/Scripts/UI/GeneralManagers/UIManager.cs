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
    public enum CardDisplayTypes
    {
        CardChoice,
        Divinate,
        AlterFate,
    }

    [SerializeField]
    GameObject currentSceneController;

    public bool OverGameplayArea { get; set; }

    [Header("Main Menu Pages")]
    [SerializeField]
    LobbyUI lobbyPage;
    [SerializeField]
    CardLibraryParent cardLibrary;

    [Header("Gameplay Pages")]
    [SerializeField]
    private GameplayUI gameplayUI;

    [Header("Detail Displays")]
    [SerializeField]
    private CardDetailUI cardDetailDisplay;
    [SerializeField]
    private UpgradeDetailUI upgradeDetailDisplay;

    [Header("Other Properties")]
    public ActiveMainPanels activeMainPanel;

    public int RefreshHeroStats { get; set; }

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

        cardDetailDisplay = mainMenuUIReferences.cardDetailDisplay.GetComponent<CardDetailUI>();
        upgradeDetailDisplay = mainMenuUIReferences.upgradeDetailDisplay.GetComponent<UpgradeDetailUI>();
        lobbyPage = mainMenuUIReferences.lobbyUI.GetComponent<LobbyUI>();
        cardLibrary = mainMenuUIReferences.libraryUI.GetComponent<CardLibraryParent>();

        cardDetailDisplay.gameObject.SetActive(false);
        upgradeDetailDisplay.gameObject.SetActive(false);
        lobbyPage.gameObject.SetActive(false);
        cardLibrary.gameObject.SetActive(false);

        RefreshHeroStats = 0;
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

        cardDetailDisplay = gameplayUIReferences.cardDetailDisplay.GetComponent<CardDetailUI>();
        upgradeDetailDisplay = gameplayUIReferences.upgradeDetailDisplay.GetComponent<UpgradeDetailUI>();
        gameplayUI = gameplayUIReferences.gameplayUI.GetComponent<GameplayUI>();

        gameplayUI.gameObject.SetActive(true);
        cardDetailDisplay.gameObject.SetActive(false);
        upgradeDetailDisplay.gameObject.SetActive(false);

        gameplayUI.InitialiseUI();
    }

    /// <summary>
    /// 
    /// Activates the card detail display
    /// 
    /// </summary>
    public void ActivateCardDetail(CardData cardData)
    {
        upgradeDetailDisplay.gameObject.SetActive(false);
        cardDetailDisplay.gameObject.SetActive(true);
        cardDetailDisplay.ShowCardDetails(cardData);
    }

    /// <summary>
    /// 
    /// Activates the upgrade detail display
    /// 
    /// </summary>
    public void ActivateUpgradeDetail(UpgradeData upgradeData, DeckData currentDeck = null)
    {
        cardDetailDisplay.gameObject.SetActive(false);
        upgradeDetailDisplay.gameObject.SetActive(true);
        upgradeDetailDisplay.ShowUpgradeDetails(upgradeData, currentDeck);
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
                gameplayUI.RefreshPlayerBar();
                break;
            default:
                throw new Exception("Not a valid scene to refresh");
        }
    }

    public void ShowCardChoiceDisplay(List<Card> cards)
    {
        if (GameManager.instance.sceneManager.ActiveScene == SceneList.GameplayScene)
            gameplayUI.ShowCardChoice(cards);
        else
            throw new Exception("Not a valid scene to show card choice display");
    }

    public void ShowDivinateDisplay(List<Card> cards)
    {
        if (GameManager.instance.sceneManager.ActiveScene == SceneList.GameplayScene)
            gameplayUI.ShowDivinate(cards);
        else
            throw new Exception("Not a valid scene to show divinate display");
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
