using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class DeckSaveData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TierLevel HeroTier { get; set; }
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

    public DeckData(DeckData deckData)
    {
        Id = deckData.Id;
        Name = deckData.Name;
        HeroTier = deckData.HeroTier;
        AbilityTier = deckData.AbilityTier;
        CardIdList = deckData.CardIdList.ToList();
        DeckClass = deckData.DeckClass;
        IsNPCDeck = deckData.IsNPCDeck;

        SyncDeckCards();
    }

    public DeckData(DeckSaveData deckSaveData, LibraryManager libraryManager)
    {
        Id = deckSaveData.Id;
        Name = deckSaveData.Name;
        HeroTier = deckSaveData.HeroTier;
        AbilityTier = deckSaveData.AbilityTier;
        CardIdList = deckSaveData.CardIdList.ToList();
        DeckClass = deckSaveData.DeckClass;
        IsNPCDeck = deckSaveData.IsNPCDeck;

        SyncDeckCards(libraryManager);
    }

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

    public void LoadHero()
    {
        if (HeroTier != TierLevel.Default)
        {
            HeroCard = GameManager.instance.libraryManager.GetHero(DeckClass, HeroTier, AbilityTier);
        }
    }

    public void LoadHero(LibraryManager libraryManager)
    {
        if (HeroTier != TierLevel.Default)
        {
            HeroCard = libraryManager.GetHero(DeckClass, HeroTier, AbilityTier);
        }
    }

    public void AddCard(CardData cardData)
    {
        CardList.Add(cardData);
        CardIdList.Add(cardData.Id);
        CardList = LibraryManager.OrderCardList(CardList);
    }

    public void RemoveCard(CardData cardData)
    {
        CardList.Remove(cardData);
        CardIdList.Remove(cardData.Id);
    }
}
