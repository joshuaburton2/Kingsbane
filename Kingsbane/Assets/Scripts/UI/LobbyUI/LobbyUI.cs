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
    [SerializeField]
    private Button playButton;

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

    [Header("Scenario UI Objects")]
    [SerializeField]
    private GameObject ruleListParent;
    [SerializeField]
    private GameObject ruleDisplayPrefab;
    private List<GameObject> ruleObjectList;

    /// <summary>
    /// 
    /// Loads the UI of the Lobby
    /// 
    /// </summary>
    public void LoadLobbyUI()
    {
        gameMode = SelectedGameMode;

        playerDecks = new DeckData[NUM_PLAYERS];
        playButton.interactable = false;

        //Refresh the two deck lists
        playerDeckList[0].RefreshDeckList(false, "Player 1 Deck List");
        playerDeckList[1].RefreshDeckList(IsPVE, IsPVE ? "NPC Deck List" : "Player 2 Deck List");

        RefreshMapList();
    }

    /// <summary>
    /// 
    /// Refreshes the list of maps
    /// 
    /// </summary>
    private void RefreshMapList()
    {
        mapDropdown.ClearOptions();

        var mapList = GameManager.instance.scenarioManager.GetMaps();
        //The dropdown id list is a reference to the actual map ID for the items in the dropdown
        mapDropdownIds = mapList.Select(x => x.Id.Value).ToList();
        mapDropdown.AddOptions(mapList.Select(x => new TMP_Dropdown.OptionData(x.Name)).ToList());

        RefreshSelectedMap();
    }

    /// <summary>
    /// 
    /// Refreshes the selected map details. Also used as a selected value changed event on the dropdown
    /// 
    /// </summary>
    public void RefreshSelectedMap()
    {
        //Gets the actual ID of the map, then uses that to get the map from the library
        var selectedMapId = mapDropdownIds[mapDropdown.value];
        selectedMap = GameManager.instance.scenarioManager.GetMap(selectedMapId);

        mapDescription.text = selectedMap.Description;

        RefreshScenarioList();

        //Refreshes the map grid with the new map details
        mapGrid.RefreshGrid(selectedMap, selectedScenarioId);
    }

    /// <summary>
    /// 
    /// Refreshes the list of scenarios for the selected map
    /// 
    /// </summary>
    private void RefreshScenarioList()
    {
        scenarioDropdown.ClearOptions();

        var scenarioList = selectedMap.Scenarios;
        //The dropdown id list is a reference to the actual scenario ID for the items in the dropdown
        scenarioDropdownIds = scenarioList.Select(x => x.Id.Value).ToList();
        scenarioDropdown.AddOptions(scenarioList.Select(x => new TMP_Dropdown.OptionData(x.Name)).ToList());

        RefreshSelectedScenario();
    }

    /// <summary>
    /// 
    /// Refreshes the selected scenario details. Also used as a selected value changed event on the dropdown
    /// 
    /// </summary>
    public void RefreshSelectedScenario()
    {
        selectedScenarioId = scenarioDropdownIds[scenarioDropdown.value];
        var selectedScenario = selectedMap.Scenarios.FirstOrDefault(x => x.Id == selectedScenarioId);

        scenarioDescription.text = selectedScenario.Description;

        //Creates the list of rules for the scenario
        GameManager.DestroyAllChildren(rulesParent);
        ruleObjectList = new List<GameObject>();
        foreach (var rule in selectedScenario.Rules)
        {
            var ruleObject = Instantiate(ruleDisplayPrefab, ruleListParent.transform);
            ruleObject.GetComponent<RuleDisplayObject>().RefreshRuleDisplay(rule, this);
            ruleObjectList.Add(ruleObject);
        }
    }

    /// <summary>
    /// 
    /// Refreshes the rule list. If wanting only a particular rule to be shown (such as when a rule is selected)
    /// then need to provide an ID of the rule in the list
    /// 
    /// </summary>
    /// <param name="id"></param>
    public void RefreshRuleList(int? id = null)
    {
        foreach (var ruleObject in ruleObjectList)
        {
            if (id.HasValue)
                if (ruleObject.GetComponent<RuleDisplayObject>().rule.Id != id)
                    ruleObject.SetActive(false);
            else
                ruleObject.SetActive(true);
        }
    }

    /// <summary>
    /// 
    /// Dropdown change event for switching the game mode between PVE and PVP game modes
    /// 
    /// </summary>
    public void SwitchGameMode()
    {
        gameMode = SelectedGameMode;
        playerDeckList[1].RefreshDeckList(IsPVE, IsPVE ? "NPC Deck List" : "Player 2 Deck List");
        playerDecks[1] = null;
    }

    /// <summary>
    /// 
    /// Function call for the deck lists when a deck is selected from the list
    /// 
    /// </summary>
    public void SelectDeck(int playerId, DeckData deck)
    {
        //Assigned the deck to the required player deck
        playerDecks[playerId] = deck;

        //If all required decks are selected (i.e. not null), then can begin playing the game (there is no way for a map to not be selected)
        playButton.interactable = true;
        foreach (var deckCheck in playerDecks)
        {
            if (deckCheck == null)
            {
                playButton.interactable = false;
                break;
            }
        }
    }

    /// <summary>
    /// 
    /// Button click event for changing the map filter on the displayed grid
    /// 
    /// </summary>
    public void ChangeMapFilter(int mapFilterId)
    {
        var mapFilter = (MapGrid.MapFilters)mapFilterId;
        mapGrid.SwitchMapFilter(mapFilter);
        mapKey.RefreshKey(mapFilter, NUM_PLAYERS);
    }

    /// <summary>
    /// 
    /// Button click event for begining a gameplay session
    /// 
    /// </summary>
    public void PlayGame()
    {
        GameManager.instance.LoadGameplay(playerDecks, selectedMap, selectedScenarioId);
    }
}
