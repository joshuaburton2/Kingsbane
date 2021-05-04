using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 
/// Script for the main game manager. Stores references to other managers and more generic functionality required in the game
/// 
/// </summary>
public class GameManager : MonoBehaviour
{
    public enum GamePhases
    {
        Menu,
        Setup,
        HeroDeploy,
        Mulligan,
        Gameplay,
        End,
    }

    public static GameManager instance { get; set; }

    public LibraryManager libraryManager;
    public UpgradeManager upgradeManager;
    public ScenarioManager scenarioManager;
    public IconManager iconManager;
    public UIManager uiManager;
    public DeckManager deckManager;
    public ColourManager colourManager;
    public ImageManager imageManager;
    public GameSceneManager sceneManager;
    public EffectManager effectManager;

    public MapGrid mapGrid;

    public Map LoadedMap { get; set; }
    public int? LoadedScenarioId { get; set; }
    public Scenario LoadedScenario { get { return LoadedMap.Scenarios.FirstOrDefault(x => x.Id == LoadedScenarioId); } }
    public List<Player> LoadedPlayers { get; set; }
    public int NumPlayers { get { return LoadedPlayers.Count; } }

    public int? ActivePlayerId { get; set; }
    public int? InactivePlayerId { get { return LoadedPlayers.Select(x => x.Id).FirstOrDefault(x => x != ActivePlayerId); } }
    public GamePhases CurrentGamePhase { get; set; }
    public int CurrentRound { get; set; }

    private void Awake()
    {
        ResetGameState(true);

        //Singleton setup
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //Load game initialisation information. Order is important- must load decks after card and upgrade libraries are loaded
        libraryManager.LoadLibrary();
        upgradeManager.LoadLibrary();
        deckManager.LoadDecks();
        scenarioManager.LoadScenarios();
        effectManager.InitEffectManager();
    }

    public void ExitGame()
    {
        deckManager.SaveDecks();
        Application.Quit();
    }

    /// <summary>
    /// 
    /// Destroy all child objects of an object
    /// 
    /// </summary>
    public static void DestroyAllChildren(GameObject gameObject)
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// 
    /// Resets the game state to default. Should be called when exiting gameplay scene
    /// 
    /// </summary>
    public void ResetGameState(bool isInit = false)
    {
        LoadedPlayers = null;
        LoadedMap = null;
        LoadedScenarioId = null;
        ActivePlayerId = null;
        CurrentGamePhase = GamePhases.Menu;
        if (!isInit)
            effectManager.RefreshEffectManager(true);
    }

    /// <summary>
    /// 
    /// Initialises a gameplay session. Requires a list of player decks and a map
    /// 
    /// </summary>
    public void LoadGameplay(DeckData[] decks, Map map, int scenarioId)
    {
        LoadGameplayData(decks, map, scenarioId);

        sceneManager.LoadNewScene(SceneList.GameplayScene);
    }

    /// <summary>
    /// 
    /// Used for checking if the game is initialised properly. If not, then sets up a default set of players and map
    /// Mostly used for testing if loading into game from gameplay scene. Change default decks and map as required
    /// 
    /// </summary>
    public void CheckGameLoad()
    {
        if (CurrentGamePhase == GamePhases.Menu)
        {
            var defaultDecks = new DeckData[]
            {
                deckManager.NPCDeckList.FirstOrDefault(),
                //deckManager.NPCDeckList.FirstOrDefault(),
                deckManager.NPCDeckList.FirstOrDefault(x => x != deckManager.NPCDeckList.FirstOrDefault()), //Gets the second NPC Deck in the List
            };
            var defaultMap = scenarioManager.GetMaps().FirstOrDefault();
            var defaultScenarioId = defaultMap.Scenarios.FirstOrDefault().Id.Value;

            LoadGameplayData(defaultDecks, defaultMap, defaultScenarioId);
        }
    }

    /// <summary>
    /// 
    /// Initialise the game with the given deck lists and map
    /// 
    /// </summary>
    private void LoadGameplayData(DeckData[] decks, Map map, int scenarioId)
    {
        CurrentGamePhase = GamePhases.Setup;

        //Ensures that there are no duplicate decks loaded
        if (decks.GroupBy(x => x).Any(x => x.Count() > 1))
            throw new Exception("Cannot load the same deck for different players");

        LoadedPlayers = decks.Select(x => new Player(x)).ToList();
        LoadedMap = map;
        LoadedScenarioId = scenarioId;
    }

    /// <summary>
    /// 
    /// Gets a player of a particular Id
    /// 
    /// </summary>
    public Player GetPlayer(int id)
    {
        return LoadedPlayers[id];
    }

    /// <summary>
    /// 
    /// Gets either the active player or the inactive player
    /// 
    /// </summary>
    public Player GetPlayer(bool isActive = true)
    {
        if (ActivePlayerId.HasValue)
            return GetPlayer(isActive ? ActivePlayerId.Value : InactivePlayerId.Value);
        else
            return null;
    }

    /// <summary>
    /// 
    /// Initialise the menu scene with all required data
    /// 
    /// </summary>
    public void InitialiseMenuScene()
    {
        var mapGridObject = GameObject.FindGameObjectWithTag("MapGrid");
        mapGrid = mapGridObject.GetComponent<MapGrid>();
    }

    /// <summary>
    /// 
    /// Initialise the gameplay scene with all required data
    /// 
    /// </summary>
    public void InitialiseGameplayScene()
    {
        var mapGridObject = GameObject.FindGameObjectWithTag("MapGrid");
        mapGrid = mapGridObject.GetComponent<MapGrid>();
        mapGrid.RefreshGrid(LoadedMap, LoadedScenarioId.Value);
    }

    public void StartGame()
    {
        ActivePlayerId = 0;
        CurrentRound = 0;

        var index = 0;
        foreach (var player in LoadedPlayers)
        {
            player.InitialisePlayer(index);
            index++;
        }

    }

    public bool NextPlayerTurn()
    {
        PlayerEndOfTurn();

        ActivePlayerId++;

        if (ActivePlayerId == NumPlayers)
        {
            ActivePlayerId = 0;

            if (CurrentGamePhase == GamePhases.HeroDeploy || CurrentGamePhase == GamePhases.Mulligan)
            {
                CurrentGamePhase++;
            }

            if (CurrentGamePhase == GamePhases.Gameplay)
            {
                CurrentRound++;
            }

            PlayerStartOfTurn();

            return true;
        }

        PlayerStartOfTurn();

        return false;
    }

    private void PlayerStartOfTurn()
    {
        mapGrid.MapStartOfTurn(ActivePlayerId.Value);

        foreach (var player in LoadedPlayers)
        {
            player.StartOfTurn();
        }
    }

    public void PlayerEndOfTurn()
    {
        if (CurrentGamePhase == GamePhases.Gameplay)
        {
            foreach (var player in LoadedPlayers)
            {
                player.EndOfTurn();
            }
        }
    }

    public void CheckWarden()
    {
        if (CurrentGamePhase == GamePhases.Gameplay)
        {
            foreach (var player in LoadedPlayers)
                player.CheckWarden();
        }
    }

    public void TriggerVictory(int lossPlayerId)
    {
        CurrentGamePhase = GamePhases.End;
        effectManager.RefreshEffectManager(true);
        uiManager.ShowVictoryState(lossPlayerId == 0 ? 1 : 0);
    }
}
