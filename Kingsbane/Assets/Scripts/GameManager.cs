using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        Mulligan,
        [Description("Deploy Hero")]
        HeroDeploy,
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
    public DeckData CampaignDeck { get; set; }
    public bool IsCampaign { get { return CampaignDeck != null; } }

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

    /// <summary>
    /// 
    /// Quits the game and saves the player decks.
    /// 
    /// </summary>
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
        //If loading into the game for the first time, reset the effect manager
        if (!isInit)
        {
            effectManager.RefreshEffectManager(true);
        }
        else
        {
            //Unloads the campaign deck is returning from the gameplay scene
            CampaignDeck = null;
        }


    }

    /// <summary>
    /// 
    /// Initialises a gameplay session. Requires a list of player decks and a map
    /// 
    /// </summary>
    public void LoadGameplay(DeckData[] decks, Map map, int scenarioId, bool isCampaign = false)
    {
        //If loading into a campaign, sets the campaign deck as the only non-npc deck in the list
        if (isCampaign)
        {
            CampaignDeck = decks.Single(x => !x.IsNPCDeck);
            //Cannot load a campaign deck if the selected deck is not a campaign deck
            if (!CampaignDeck.IsCampaign)
                throw new Exception("Deck is not a campaign deck");
        }

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
        //If the phase is still menu, this means the gameplay data has not been loaded, as such, requiring default decks
        if (CurrentGamePhase == GamePhases.Menu)
        {
            //Loading into the gameplay scene means that this is not a campaign mission by default
            CampaignDeck = null;

            var orderedNPCDecks = deckManager.NPCDeckList.OrderBy(x => x.Id);
            var defaultDecks = new DeckData[]
            {
                orderedNPCDecks.FirstOrDefault(),
                //deckManager.NPCDeckList.FirstOrDefault(),
                orderedNPCDecks.FirstOrDefault(x => x != orderedNPCDecks.FirstOrDefault()), //Gets the second NPC Deck in the List
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
    public Player GetPlayer(int? id)
    {
        if (id != null)
            return LoadedPlayers[id.Value];
        else
            return GetPlayer();

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
        //Gets the map grid object. Not displayed initially so does not refresh it
        var mapGridObject = GameObject.FindGameObjectWithTag("MapGrid");
        mapGrid = mapGridObject.GetComponent<MapGrid>();

        //If loading from a campaign deck, this means need to load into the campaign UI by default
        if (IsCampaign)
        {
            if (CampaignDeck.IsCampaign)
            {
                //Loads into the campaign UI, then unloads the campaign deck
                uiManager.ShowLootGeneratorForCampaign();
                CampaignDeck = null;
            }
            else
            {
                throw new Exception("Deck is not a campaign deck");
            }
        }
    }

    /// <summary>
    /// 
    /// Initialise the gameplay scene with all required data
    /// 
    /// </summary>
    public void InitialiseGameplayScene()
    {
        //Gets the map grid objects and refreshes the grid
        var mapGridObject = GameObject.FindGameObjectWithTag("MapGrid");
        mapGrid = mapGridObject.GetComponent<MapGrid>();
        mapGrid.RefreshGrid(LoadedMap, LoadedScenarioId.Value);
    }

    /// <summary>
    /// 
    /// Starts the game upon loading into the gameplay scene
    /// 
    /// </summary>
    public void StartGame()
    {
        //Reset the base variables
        ActivePlayerId = 0;
        CurrentRound = 0;

        //Initialises each player with their required id
        var index = 0;
        foreach (var player in LoadedPlayers)
        {
            player.InitialisePlayer(index);
            index++;
        }

    }

    /// <summary>
    /// 
    /// Moves the game to the next player's turn
    /// 
    /// </summary>
    /// <returns>True if the round has ended and the game has passed back to the first player. False otherwise</returns>
    public bool NextPlayerTurn()
    {
        //Conducts the end of turn prompts for each player, then increases the active ID
        PlayerEndOfTurn();

        ActivePlayerId++;

        //If the active ID is equal to the number of players, need to loop the active player back to the first player
        if (ActivePlayerId == NumPlayers)
        {
            //Loops the player ID back
            ActivePlayerId = 0;

            //If in the hero deploy or mulligan phase, looping through all players means game needs to move to next phase,
            // as each player only needs to do these phases once
            if (CurrentGamePhase == GamePhases.HeroDeploy || CurrentGamePhase == GamePhases.Mulligan)
            {
                CurrentGamePhase++;
            }

            //If in the gameplay phase, moves to the next gameplay round
            if (CurrentGamePhase == GamePhases.Gameplay)
            {
                CurrentRound++;
            }

            //Does the start of turn for each player, then returns true as was required to loop to first player
            PlayerStartOfTurn();

            return true;
        }

        //Does the start of turn for each player, then returns false as did not require a loop
        PlayerStartOfTurn();

        return false;
    }

    /// <summary>
    /// 
    /// Does the start of turn effects for players and the map
    /// 
    /// </summary>
    private void PlayerStartOfTurn()
    {
        mapGrid.MapStartOfTurn(ActivePlayerId.Value);

        foreach (var player in LoadedPlayers)
        {
            player.StartOfTurn();
        }
    }

    /// <summary>
    /// 
    /// Does the end of turn effects for players
    /// 
    /// </summary>
    public void PlayerEndOfTurn()
    {
        //End of turn effects are only required during the gameplay phases
        if (CurrentGamePhase == GamePhases.Gameplay)
        {
            foreach (var player in LoadedPlayers)
            {
                player.EndOfTurn();
            }
        }
    }

    /// <summary>
    /// 
    /// Checks the warden effects on all players
    /// 
    /// </summary>
    public void CheckWarden()
    {
        if (CurrentGamePhase != GamePhases.Menu && CurrentGamePhase != GamePhases.Setup)
        {
            foreach (var player in LoadedPlayers)
                player.CheckWarden();
        }
        else
        {
            throw new Exception("Cannot check Warden effects outside of gameplay phase");
        }
    }

    /// <summary>
    /// 
    /// Triggers victory for a particular player
    /// 
    /// </summary>
    /// <param name="lossPlayerId">The id of the player who lost</param>
    /// <param name="isSceneExit">True only if exiting the scene. Required to check due to overriding code in exiting the gameplay scene as well as displaying victory UI</param>
    public void TriggerVictory(int lossPlayerId, bool isSceneExit = false)
    {
        //Moves game to end phase
        CurrentGamePhase = GamePhases.End;

        foreach (var player in LoadedPlayers)
        {
            //Does each game end update for each player
            player.GameEndUpdates();

            //Updates the players campaign progress if it is a campaign deck
            var playerDeck = player.DeckData;
            if (!playerDeck.IsNPCDeck && playerDeck.IsCampaign)
            {
                if (lossPlayerId == player.Id)
                {
                    playerDeck.CampaignTracker.TriggerDefeat();
                }
                else
                {
                    playerDeck.CampaignTracker.CompleteScenario(player.CompletedBonusObjective);
                }
            }
        }

        //If not exiting the scene, saves the game and refreshes the effect manager. Not required if exiting the scene as this code is handled externally.
        // Also displays the victory screen if still in the gameplay scene
        if (!isSceneExit)
        {
            deckManager.SaveDecks();
            effectManager.RefreshEffectManager(true);
            uiManager.ShowVictoryState(lossPlayerId == 0 ? 1 : 0);
        }
    }
}
