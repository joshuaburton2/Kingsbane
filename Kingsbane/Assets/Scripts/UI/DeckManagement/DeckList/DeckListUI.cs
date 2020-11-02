using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// Script for handling the deck list in the library
/// 
/// </summary>
public class DeckListUI : MonoBehaviour
{
    [SerializeField]
    private LibraryUI libraryUI;
    [SerializeField]
    private GameObject newDeckPage;
    [SerializeField]
    private ScrollRect deckScrollArea;
    [SerializeField]
    private GameObject lootGenerator;
    [SerializeField]
    private Button lootButton;
    [SerializeField]
    private GameObject upgradeManager;
    [SerializeField]
    private Button upgradeButton;
    [SerializeField]
    private GameObject deckListParent;
    [SerializeField]
    private GameObject deckListObjectPrefab;
    [SerializeField]
    private List<GameObject> deckListObjects;

    //The Id of the deck currently being edited. This is public so that objects which can edit a decks state are able to come back here for info
    //About which deck is being edited
    public int? DeckEditId { get; set; }
    public bool DeckEditMode { get { return DeckEditId.HasValue; } }
    private DeckListObject activeDeckObject;

    /// <summary>
    /// 
    /// Button click function for creating a new deck
    /// 
    /// </summary>
    public void CreateNewDeck()
    {
        DeckEditId = null;
        newDeckPage.SetActive(true);
        newDeckPage.GetComponent<NewDeckUI>().InitNewDeckPage();
    }

    /// <summary>
    /// 
    /// Button click function for resetting the saved player decks
    /// 
    /// </summary>
    public void ResetDecks()
    {
        GameManager.instance.deckManager.ResetDecks();
        DeckEditId = null;
        RefreshDeckList();
    }

    /// <summary>
    /// 
    /// Refreshes the deck list. This will reset the UI on a deck being edited as well
    /// 
    /// </summary>
    public void RefreshDeckList(bool resourceFilter = true)
    {
        newDeckPage.SetActive(false);
        lootGenerator.SetActive(false);
        upgradeManager.SetActive(false);

        //Unlocks the deck scrolling
        deckScrollArea.vertical = true;

        DeckEditId = null;
        lootButton.interactable = false;
        lootGenerator.SetActive(false);
        upgradeButton.interactable = false;
        upgradeManager.SetActive(false);

        //Resets the filter to not filter cards to be playable by a class. The if statement should only not be entered during the original initialisation of the UI
        //i.e. In start on this script. This is because the filter object in the library UI doesn't exist yet as it is also created in start.
        if (resourceFilter)
        {
            libraryUI.ApplyClassPlayableFilter(Classes.ClassList.Default);
        }

        //Clears the deck list of objects
        GameManager.DestroyAllChildren(deckListParent);
        deckListObjects.Clear();

        //Initialise and create the objects in the deck list
        var deckList = GameManager.instance.deckManager.PlayerDeckList;
        foreach (var deck in deckList)
        {
            var deckListObject = Instantiate(deckListObjectPrefab, deckListParent.transform);
            deckListObject.name = $"Deck: {deck.Name}";
            deckListObject.GetComponent<DeckListObject>().InitDeckListObject(deck, _deckListUI: this);
            deckListObjects.Add(deckListObject);
        }
    }

    /// <summary>
    /// 
    /// Initialises the editing of a deck
    /// 
    /// </summary>
    public void EditDeck(int deckId, Classes.ClassList selectedDeckClass, DeckListObject _activeDeckObject)
    {
        //Sets the properties of the deck currently being edited
        DeckEditId = deckId;
        activeDeckObject = _activeDeckObject;

        //Locks the deck scrolling
        deckScrollArea.vertical = false;

        //Hides all deck objects in the deck list except the one being edited
        for (int deckIndex = 0; deckIndex < deckListObjects.Count; deckIndex++)
        {
            if (deckIndex != deckId)
            {
                deckListObjects[deckIndex].SetActive(false);
            }
        }

        //Filters the card library to only show cards which are available to the selected decks class
        libraryUI.ApplyClassPlayableFilter(selectedDeckClass);

        lootButton.interactable = true;
        upgradeButton.interactable = true;
    }

    /// <summary>
    /// 
    /// Refreshes the details of the active deck's details
    /// 
    /// </summary>
    public void RefreshActiveDeckDetails(DeckData deckData = null)
    {
        activeDeckObject.RefreshDeckDetails(deckData, this);
    }

    /// <summary>
    /// 
    /// Button click function for opening the loot generator
    /// 
    /// </summary>
    public void OpenLootGenerator()
    {
        if (lootGenerator.activeSelf)
        {
            lootGenerator.SetActive(false);
        }
        else
        {
            upgradeManager.SetActive(false);
            lootGenerator.SetActive(true);
            lootGenerator.GetComponent<LootGeneratorUI>().RefreshLootGenerator();
        }
    }

    /// <summary>
    /// 
    /// Button click function for opening the deck upgrade manager. Need to add in initialisation functionality here
    /// 
    /// </summary>
    public void OpenUpgrades()
    {
        if (upgradeManager.activeSelf)
        {
            upgradeManager.SetActive(false);
        }
        else
        {
            lootGenerator.SetActive(false);
            upgradeManager.SetActive(true);
            upgradeManager.GetComponent<UpgradeUI>().InitUpgradeUI();
        }
    }
}
