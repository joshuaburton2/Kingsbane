using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 
/// Object used to save deck data to file. Used so that card data objects are not stored in file, instead IDs are kept
/// 
/// </summary>
[Serializable]
public class DeckSaveData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TierLevel HeroTier { get; set; }
    // Tier of the hero ability
    public TierLevel AbilityTier { get; set; }
    public List<int> CardIdList { get; set; }
    public Classes.ClassList DeckClass { get; set; }
    public bool IsNPCDeck { get; set; }

    public DeckSaveData()
    {
        Id = -1;
        HeroTier = TierLevel.Default;
        AbilityTier = TierLevel.Default;
    }

    /// <summary>
    /// 
    /// Used for copying deck data into the save object. Cast doesn't work
    /// 
    /// </summary>
    public DeckSaveData(DeckData deckData)
    {
        Id = deckData.Id;
        Name = deckData.Name;
        HeroTier = deckData.HeroTier;
        AbilityTier = deckData.AbilityTier;
        CardIdList = deckData.CardIdList.ToList();
        DeckClass = deckData.DeckClass;
        IsNPCDeck = deckData.IsNPCDeck;
    }
}

public class DeckData : DeckSaveData
{
    public UnitData HeroCard { get; set; }
    public List<CardData> CardList { get; set; }
    public int DeckCount { get { return CardList.Count; } }
    public List<CardResources> DeckResources { get { return Classes.GetClassData(DeckClass).GetClassResources(); } }

    /// <summary>
    /// 
    /// Constructor for copying deck data to a new deck data
    /// 
    /// </summary>
    public DeckData(DeckData deckData)
    {
        Id = deckData.Id;
        Name = deckData.Name;
        HeroTier = deckData.HeroTier;
        AbilityTier = deckData.AbilityTier;
        CardIdList = deckData.CardIdList.ToList();
        DeckClass = deckData.DeckClass;
        IsNPCDeck = deckData.IsNPCDeck;

        //Synchronizes the card Ids with the cards in the library
        SyncDeckCards();
    }

    /// <summary>
    /// 
    /// Constructor for copying deck save data into a new deck data object. Since this is called in during Awake, have to reference
    /// Library Manager directly rather than through singleton Game Manager, since it is not initialised
    /// 
    /// </summary>
    public DeckData(DeckSaveData deckSaveData, LibraryManager libraryManager)
    {
        Id = deckSaveData.Id;
        Name = deckSaveData.Name;
        HeroTier = deckSaveData.HeroTier;
        AbilityTier = deckSaveData.AbilityTier;
        CardIdList = deckSaveData.CardIdList.ToList();
        DeckClass = deckSaveData.DeckClass;
        IsNPCDeck = deckSaveData.IsNPCDeck;

        //Synchronizes the card Ids with the cards in the library
        SyncDeckCards(libraryManager);
    }

    /// <summary>
    /// 
    /// Synchronizes the card ids with the cards in the library
    /// 
    /// </summary>
    public void SyncDeckCards()
    {
        LoadHero();

        CardList = new List<CardData>();
        foreach (var cardId in CardIdList)
        {
            CardList.Add(GameManager.instance.libraryManager.GetCard(cardId));
        }
        CardList = LibraryManager.OrderCardList(CardList);
    }

    /// <summary>
    /// 
    /// Synchronizes the card ids with the cards in the library. Since this is called in during Awake, have to reference
    /// Library Manager directly rather than through singleton Game Manager, since it is not initialised
    /// 
    /// </summary>
    public void SyncDeckCards(LibraryManager libraryManager)
    {
        LoadHero(libraryManager);

        CardList = new List<CardData>();
        foreach (var cardId in CardIdList)
        {
            CardList.Add(libraryManager.GetCard(cardId));
        }
        CardList = LibraryManager.OrderCardList(CardList);
    }

    /// <summary>
    /// 
    /// Load the hero card into the deck
    /// 
    /// </summary>
    public void LoadHero()
    {
        if (HeroTier != TierLevel.Default)
        {
            HeroCard = GameManager.instance.libraryManager.GetHero(DeckClass, HeroTier, AbilityTier);
        }
    }

    /// <summary>
    /// 
    /// Load the hero card into the deck. Since this is called in during Awake, have to reference
    /// Library Manager directly rather than through singleton Game Manager, since it is not initialised
    /// 
    /// </summary>
    public void LoadHero(LibraryManager libraryManager)
    {
        if (HeroTier != TierLevel.Default)
        {
            HeroCard = libraryManager.GetHero(DeckClass, HeroTier, AbilityTier);
        }
    }

    /// <summary>
    /// 
    /// Add a card to the deck
    /// 
    /// </summary>
    public void AddCard(CardData cardData)
    {
        CardList.Add(cardData);
        CardIdList.Add(cardData.Id);
        CardList = LibraryManager.OrderCardList(CardList);
    }

    /// <summary>
    /// 
    /// Remove a card from the deck
    /// 
    /// </summary>
    public void RemoveCard(CardData cardData)
    {
        if (CardIdList.Contains(cardData.Id))
        {
            CardList.Remove(cardData);
            CardIdList.Remove(cardData.Id);
        }
        else
        {
            throw new Exception($"Card {cardData.Id} does not exist in the deck");
        }

    }
}
