using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using CategoryEnums;
using System.Linq;
using System;

public class DeckManager : MonoBehaviour
{
    public List<DeckData> PlayerDeckList { get; private set; }
    public List<DeckData> NPCDeckList { get; private set; }

    private const string deckFileName = "/DeckData.dat";

    /// <summary>
    /// 
    /// Convert a list of save data objects into deck objects
    /// 
    /// </summary>
    private List<DeckData> ConvertDeckSave(List<DeckSaveData> deckSaveDatas, bool isNewDeck)
    {
        var deckDatas = new List<DeckData>();
        foreach (var saveDeck in deckSaveDatas)
        {
            deckDatas.Add(new DeckData(saveDeck, isNewDeck));
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

        //Moves the Empty Deck Template to the beginning of the template list and orders everything else in alphabetical
        var emptyDeckTemplate = deckSaveTemplates.Single(x => x.Name == "Empty Deck");
        deckSaveTemplates.Remove(emptyDeckTemplate);
        deckSaveTemplates.Insert(0, emptyDeckTemplate);

        return ConvertDeckSave(deckSaveTemplates, true);
    }

    /// <summary>
    /// 
    /// Load saved decks from file
    /// 
    /// </summary>
    public void LoadDecks()
    {
        //If there is an exception to loading the save file, creates a new version, then loads them again
        if (File.Exists(Application.persistentDataPath + deckFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + deckFileName, FileMode.Open);
            try
            {
                var saveDeckList = (List<DeckSaveData>)bf.Deserialize(file);
                PlayerDeckList = ConvertDeckSave(saveDeckList, false);

                file.Close();
            }
            catch
            {
                file.Close();
                ResetDecks();
                LoadDecks();
            }
        }
        else
        {
            PlayerDeckList = new List<DeckData>();
        }

        LoadNPCDecks();

    }

    /// <summary>
    /// 
    /// Load NPC Decks
    /// 
    /// </summary>
    public void LoadNPCDecks()
    {
        var npcDeckList = Classes.ClassDataList.SelectMany(x => x.DeckTemplates).Where(x => x.IsNPCDeck == true).ToList();
        NPCDeckList = ConvertDeckSave(npcDeckList, false);
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
    public DeckData CreatePlayerDeck(DeckData deckTemplate, string deckName, int? campaignId = null)
    {
        //Generate the ID of the deck. Takes the last deck id in the list and adds one to it
        var newId = 0;
        if (PlayerDeckList.Count > 0)
        {
            newId = PlayerDeckList.LastOrDefault().Id.Value + 1;
        }

        //Adds the deck to the list
        var newDeck = new DeckData(deckTemplate)
        {
            Id = newId,
            Name = deckName,
        };
        PlayerDeckList.Add(newDeck);

        if (campaignId.HasValue)
        {
            newDeck.CampaignTracker = new CampaignProgression(campaignId.Value);
        }

        //Save decks to file
        SaveDecks();

        return newDeck;
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
    /// Gets a list of player decks based on whether it is for a campaign or not
    /// 
    /// </summary>
    public List<DeckData> GetPlayerDecks(bool isCampaign = false)
    {
        //Note that if is campaign 
        return PlayerDeckList.Where(x => x.IsCampaign == isCampaign && (!isCampaign || isCampaign && !x.CampaignTracker.CompletedCampaign)).ToList();
    }


    /// <summary>
    /// 
    /// Gets an NPC deck of a particular ID
    /// 
    /// </summary>
    public DeckData GetNPCDeck(int id)
    {
        return NPCDeckList.FirstOrDefault(x => x.Id == id);
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
