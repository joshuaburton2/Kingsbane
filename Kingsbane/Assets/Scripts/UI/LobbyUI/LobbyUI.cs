using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public enum GameModes
{
    PVP,
    PVE,
}

public class LobbyUI : MonoBehaviour
{
    private const int NUM_PLAYERS = 2;

    public GameModes gameMode;
    private GameModes SelectedGameMode { get { return (GameModes)Enum.Parse(typeof(GameModes), gameModeDropdown.captionText.text); } }
    private bool IsPVE { get { return gameMode == GameModes.PVE; } }

    Map selectedMap;
    List<int> mapDropdownIds;
    Scenario selectedScenario;
    List<int> scenarioDropdownIds;

    [SerializeField]
    private TMP_Dropdown gameModeDropdown;

    [SerializeField]
    List<LobbyDeckListUI> playerDeckList;

    [Header("Map UI Objects")]
    [SerializeField]
    private TMP_Dropdown mapDropdown;
    [SerializeField]
    private TMP_Dropdown scenarioDropdown;
    [SerializeField]
    private GameObject keyParent;
    [SerializeField]
    private TextMeshProUGUI mapDescription;
    [SerializeField]
    private TextMeshProUGUI scenarioDescription;
    [SerializeField]
    private GameObject rulesParent;

    private DeckData[] playerDecks;

    public void LoadLobbyUI()
    {
        gameMode = SelectedGameMode;

        playerDecks = new DeckData[NUM_PLAYERS];       

        playerDeckList[0].RefreshDeckList(false, "Player 1 Deck List");
        playerDeckList[1].RefreshDeckList(IsPVE, IsPVE ? "NPC Deck List" : "Player 2 Deck List");

        RefreshMapList();
    }

    public void RefreshMapList()
    {
        var mapList = GameManager.instance.scenarioManager.GetMaps();
        mapDropdownIds = mapList.Select(x => x.Id.Value).ToList();
        mapDropdown.options.AddRange(mapList.Select(x => new TMP_Dropdown.OptionData(x.Name)));

        mapDropdown.value = 0;
    }

    public void RefreshScenarioList()
    {
        var scenarioList = selectedMap.Scenarios;
        scenarioDropdownIds = scenarioList.Select(x => x.Id.Value).ToList();
        scenarioDropdown.options.AddRange(scenarioList.Select(x => new TMP_Dropdown.OptionData(x.Name)));

        mapDropdown.value = 0;
    }

    public void SwitchGameMode()
    {
        gameMode = SelectedGameMode;
        playerDeckList[1].RefreshDeckList(IsPVE, IsPVE ? "NPC Deck List" : "Player 2 Deck List");
        playerDecks[1] = null;
    }

    public void SelectDeck(int playerId, DeckData deck)
    {
        playerDecks[playerId] = deck;
    }
}
