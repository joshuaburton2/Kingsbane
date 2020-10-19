using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Script for the main game manager. Stores references to other managers and more generic functionality required in the game
/// 
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public LibraryManager libraryManager;
    public UpgradeManager upgradeManager;
    public IconManager iconManager;
    public UIManager uiManager;
    public DeckManager deckManager;
    public ColourManager colourManager;

    private void Awake()
    {
        //Load game initialisation information. Order is important- must load decks after card and upgrade libraries are loaded
        libraryManager.LoadLibrary();
        upgradeManager.LoadLibrary();
        deckManager.LoadDecks();

        //Singleton setup
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
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
}
