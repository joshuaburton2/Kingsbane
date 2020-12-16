using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
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
    public GameSceneManager sceneManager;
    public EffectManager effectManager;

    public MapGrid mapGrid;

    public Map LoadedMap { get; set; }
    public int LoadedScenarioId { get; set; }
    public List<Player> LoadedPlayers { get; set; }
    public int NumPlayers { get { return LoadedPlayers.Count; } }

    public int? ActivePlayerId { get; set; }
    public GamePhases CurrentGamePhase { get; set; }

    private void Awake()
    {
        ResetGameState();

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
    public void ResetGameState()
    {
        LoadedPlayers = null;
        LoadedMap = null;
        ActivePlayerId = null;
        CurrentGamePhase = GamePhases.Menu;
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
                deckManager.NPCDeckList.FirstOrDefault(),
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

        LoadedPlayers = decks.Select(x => new Player(x)).ToList();
        LoadedMap = map;
        LoadedScenarioId = scenarioId;
    }

    public Player GetActivePlayer()
    {
        if (ActivePlayerId.HasValue)
            return GetPlayer(ActivePlayerId.Value);
        else
            return null;
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
    /// Initialise the gameplay scene with all required data
    /// 
    /// </summary>
    public void InitialiseGameplayScene()
    {
        var mapGridObject = GameObject.FindGameObjectWithTag("MapGrid");
        mapGrid = mapGridObject.GetComponent<MapGrid>();
        mapGrid.RefreshGrid(LoadedMap, LoadedScenarioId);
    }

    public void StartGame()
    {
        ActivePlayerId = 0;
        CurrentGamePhase = GamePhases.HeroDeploy;
    }

    public void NextPlayerTurn()
    {
        ActivePlayerId++;
        if (ActivePlayerId == NumPlayers)
        {
            ActivePlayerId = 0;
        }
    }
}
