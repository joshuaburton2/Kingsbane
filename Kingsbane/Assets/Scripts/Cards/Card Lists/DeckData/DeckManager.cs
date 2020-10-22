using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using CategoryEnums;
using System.Linq;
using System;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    private LibraryManager libraryManager;
    [SerializeField]
    private UpgradeManager upgradeManager;

    public List<DeckData> PlayerDeckList { get; private set; }
    public Dictionary<Classes.ClassList, List<DeckData>> DeckTemplates;
    private const string deckFileName = "/DeckData.dat";

    /// <summary>
    /// 
    /// Convert a list of save data objects into deck objects
    /// 
    /// </summary>
    private List<DeckData> ConvertDeckSave(List<DeckSaveData> deckSaveDatas)
    {
        var deckDatas = new List<DeckData>();
        foreach (var saveDeck in deckSaveDatas)
        {
            deckDatas.Add(new DeckData(saveDeck, libraryManager, upgradeManager));
        }

        return deckDatas;
    }

    /// <summary>
    /// 
    /// Gets a list of player deck templates for a particular class
    /// 
    /// </summary>
    public List<DeckData> GetPlayerDeckTemplates(Classes.ClassList neededClass)
    {
        //Gets the relevant class object
        var classData = Classes.ClassDataList.FirstOrDefault(x => x.ThisClass == neededClass);
        //Filters out any NPC decks
        var deckSaveTemplates = classData.DeckTemplates.Where(x => x.IsNPCDeck == false).OrderBy(x => x.Name).ToList();

        return ConvertDeckSave(deckSaveTemplates);
    }

    /// <summary>
    /// 
    /// Load saved decks from file
    /// 
    /// </summary>
    public void LoadDecks()
    {
        if(File.Exists(Application.persistentDataPath + deckFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + deckFileName, FileMode.Open);
            var saveDeckList = (List<DeckSaveData>)bf.Deserialize(file);

            PlayerDeckList = ConvertDeckSave(saveDeckList);

            file.Close();
        }
        else
        {
            PlayerDeckList = new List<DeckData>();
        }
    }

    /// <summary>
    /// 
    /// Save decks to file
    /// 
    /// </summary>
    public void SaveDecks()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + deckFileName);

        var saveDeckList = new List<DeckSaveData>();
        foreach (var deck in PlayerDeckList)
        {
            saveDeckList.Add(new DeckSaveData(deck));
        }

        bf.Serialize(file, saveDeckList);
        file.Close();
    }

    /// <summary>
    /// 
    /// Reset save deck file
    /// 
    /// </summary>
    public void ResetDecks()
    {
        if (File.Exists(Application.persistentDataPath + deckFileName))
        {
            File.Delete(Application.persistentDataPath + deckFileName);
        }

        PlayerDeckList = new List<DeckData>();
    }

    /// <summary>
    /// 
    /// Create a new player deck
    /// 
    /// </summary>
    public void CreatePlayerDeck(DeckData deck, string deckName)
    {
        //Generate the ID of the deck. Takes the last deck id in the list and adds one to it
        var newId = 0;
        if (PlayerDeckList.Count > 0)
        {
            newId = PlayerDeckList.LastOrDefault().Id.Value + 1;
        }

        //Adds the deck to the list
        PlayerDeckList.Add(
            new DeckData(deck)
            {
                Id = newId,
                Name = deckName,
            });

        //Save decks to file
        SaveDecks();
    }
    
    /// <summary>
    /// 
    /// Removes a player deck from the list
    /// 
    /// </summary>
    public void DeletePlayerDeck(DeckData deck)
    {
        PlayerDeckList.Remove(deck);
        //Resets the deck indexes for the remaining decks
        for (int deckIndex = 0; deckIndex < PlayerDeckList.Count; deckIndex++)
        {
            PlayerDeckList[deckIndex].Id = deckIndex;
        }
        SaveDecks();
    }

    /// <summary>
    /// 
    /// Gets a player deck of a particular ID
    /// 
    /// </summary>
    public DeckData GetPlayerDeck(int id)
    {
        return PlayerDeckList.FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// 
    /// Adds a new card to a particular deck
    /// 
    /// </summary>
    public DeckData AddCardToPlayerDeck(int id, CardData cardData)
    {
        //Cannot add hero or uncollectable cards to the deck
        if (!cardData.IsHero && cardData.Rarity != Rarity.Uncollectable)
        {
            PlayerDeckList[id].AddCard(cardData);
            SaveDecks();
        }
        return PlayerDeckList[id];
    }

    /// <summary>
    /// 
    /// Adds a list of cards to a particular deck
    /// 
    /// </summary>
    public DeckData AddCardsToPlayerDeck(int id, List<CardData> cardDatas)
    {
        foreach (var cardData in cardDatas)
        {
            AddCardToPlayerDeck(id, cardData);
        }
        return PlayerDeckList[id];
    }

    /// <summary>
    /// 
    /// Remove a card from a particular deck
    /// 
    /// </summary>
    public DeckData RemoveCardFromPlayerDeck(int id, CardData cardData)
    {
        if (!cardData.IsHero)
        {
            PlayerDeckList[id].RemoveCard(cardData);
            SaveDecks();
        }
        return PlayerDeckList[id];
    }

    /// <summary>
    /// 
    /// Adds a list of upgrades to a particular deck
    /// 
    /// </summary>
    public DeckData AddUpgradesToPlayerDeck(int id, List<UpgradeData> upgradeDatas)
    {
        foreach (var upgradeData in upgradeDatas)
        {
            PlayerDeckList[id].AddUpgrade(upgradeData);
        }
        SaveDecks();
        return PlayerDeckList[id];
    }

    /// <summary>
    /// 
    /// Removes an upgrade from a particular deck
    /// 
    /// </summary>
    public DeckData RemoveUpgradeFromPlayerDeck(int id, UpgradeData upgradeData)
    {
        PlayerDeckList[id].RemoveUpgrade(upgradeData);
        SaveDecks();
        return PlayerDeckList[id];
    }
}
