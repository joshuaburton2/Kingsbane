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

    private Map selectedMap;
    List<int> mapDropdownIds;
    int selectedScenarioId;
    List<int> scenarioDropdownIds;

    [SerializeField]
    private TMP_Dropdown gameModeDropdown;

    [SerializeField]
    List<LobbyDeckListUI> playerDeckList;
    private DeckData[] playerDecks;

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
    [SerializeField]
    private MapGrid mapGrid;
    [SerializeField]
    private MapKeyUI mapKey;

    public void LoadLobbyUI()
    {
        gameMode = SelectedGameMode;

        playerDecks = new DeckData[NUM_PLAYERS];       

        playerDeckList[0].RefreshDeckList(false, "Player 1 Deck List");
        playerDeckList[1].RefreshDeckList(IsPVE, IsPVE ? "NPC Deck List" : "Player 2 Deck List");

        RefreshMapList();
    }

    private void RefreshMapList()
    {
        mapDropdown.options.Clear();

        var mapList = GameManager.instance.scenarioManager.GetMaps();
        mapDropdownIds = mapList.Select(x => x.Id.Value).ToList();
        mapDropdown.options.AddRange(mapList.Select(x => new TMP_Dropdown.OptionData(x.Name)));

        mapDropdown.value = 0;
        RefreshSelectedMap();
    }

    public void RefreshSelectedMap()
    {
        var selectedMapId = mapDropdownIds[mapDropdown.value];
        selectedMap = GameManager.instance.scenarioManager.GetMap(selectedMapId);

        mapDescription.text = selectedMap.Description;

        RefreshScenarioList();

        mapGrid.RefreshGrid(selectedMap, selectedScenarioId);
    }

    private void RefreshScenarioList()
    {
        scenarioDropdown.options.Clear();

        var scenarioList = selectedMap.Scenarios;
        scenarioDropdownIds = scenarioList.Select(x => x.Id.Value).ToList();
        scenarioDropdown.options.AddRange(scenarioList.Select(x => new TMP_Dropdown.OptionData(x.Name)));

        scenarioDropdown.value = 0;

        RefreshSelectedScenario();
    }

    public void RefreshSelectedScenario()
    {
        selectedScenarioId = scenarioDropdownIds[scenarioDropdown.value];
        var selectedScenario = selectedMap.Scenarios.FirstOrDefault(x => x.Id == selectedScenarioId);

        scenarioDescription.text = selectedScenario.Description;
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

    public void ChangeMapFilter(int mapFilterId)
    {
        var mapFilter = (MapGrid.MapFilters)mapFilterId;
        mapGrid.SwitchMapFilter(mapFilter);
        mapKey.RefreshKey(mapFilter);
    }
}
