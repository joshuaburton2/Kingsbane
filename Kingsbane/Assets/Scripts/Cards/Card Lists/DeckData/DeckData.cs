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
    public int? Id { get; set; }
    public string Name { get; set; }
    public TierLevel HeroTier { get; set; }
    // Tier of the hero ability
    public TierLevel AbilityTier { get; set; }
    public List<int> CardIdList { get; set; }
    public List<int> UpgradeIdList { get; set; }
    public Classes.ClassList DeckClass { get; set; }
    public bool IsNPCDeck { get; set; }

    public DeckSaveData()
    {
        Id = null;
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
        UpgradeIdList = deckData.UpgradeIdList.ToList();
        DeckClass = deckData.DeckClass;
        IsNPCDeck = deckData.IsNPCDeck;
    }
}

public class DeckData : DeckSaveData
{
    public UnitData HeroCard { get; set; }
    public List<CardData> CardList { get; set; }
    public List<UpgradeData> UpgradeList { get; set; }
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
        UpgradeIdList = deckData.UpgradeIdList.ToList();
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
    public DeckData(DeckSaveData deckSaveData, LibraryManager libraryManager, UpgradeManager upgradeManager)
    {
        Id = deckSaveData.Id;
        Name = deckSaveData.Name;
        HeroTier = deckSaveData.HeroTier;
        AbilityTier = deckSaveData.AbilityTier;
        CardIdList = deckSaveData.CardIdList.ToList();
        UpgradeIdList = deckSaveData.UpgradeIdList.ToList();
        DeckClass = deckSaveData.DeckClass;
        IsNPCDeck = deckSaveData.IsNPCDeck;

        //Synchronizes the card and upgrade Ids with the cards in the library
        SyncDeckCards(libraryManager, upgradeManager);
    }

    /// <summary>
    /// 
    /// Synchronizes the card ids with the cards in the library
    /// 
    /// </summary>
    public void SyncDeckCards()
    {
        var libraryManager = GameManager.instance.libraryManager;
        var upgradeManager = GameManager.instance.upgradeManager;

        SyncDeckCards(libraryManager, upgradeManager);
    }

    /// <summary>
    /// 
    /// Synchronizes the card and upgrades ids with the values in their relevant library. Since this is called in during Awake, have to reference
    /// Library Manager directly rather than through singleton Game Manager, since it is not initialised
    /// 
    /// </summary>
    public void SyncDeckCards(LibraryManager libraryManager, UpgradeManager upgradeManager)
    {
        LoadHero(libraryManager);

        CardList = new List<CardData>();
        foreach (var cardId in CardIdList)
        {
            CardList.Add(libraryManager.GetCard(cardId));
        }
        CardList = LibraryManager.OrderCardList(CardList);

        UpgradeList = new List<UpgradeData>();
        foreach (var upgradeId in UpgradeIdList)
        {
            UpgradeList.Add(upgradeManager.GetUpgrade(upgradeId));
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
        CardIdList.Add(cardData.Id.Value);
        CardList = LibraryManager.OrderCardList(CardList);
    }

    /// <summary>
    /// 
    /// Function for updating the tier level of the hero card
    /// 
    /// </summary>
    public void UpdateHeroCard(TierLevel heroTier, TierLevel abilityTier)
    {
        HeroTier = heroTier;
        AbilityTier = abilityTier;
        HeroCard = GameManager.instance.libraryManager.GetHero(DeckClass, heroTier, abilityTier);

        //Add the hero upgrades. Loops between tier 1 and the selected Hero Tier
        for (int tierIndex = (int)TierLevel.Tier1; tierIndex <= (int)heroTier; tierIndex++)
        {
            var heroUpgrade = GameManager.instance.upgradeManager.GetUpgrade(UpgradeTags.HeroUpgrade, (TierLevel)tierIndex);
            UpgradeList.Add(heroUpgrade);
            UpgradeIdList.Add(heroUpgrade.Id.Value);
        }
        //Add the hero ability upgrades. Loops between tier 1 and the selected Hero Tier
        for (int tierIndex = (int)TierLevel.Tier1; tierIndex <= (int)abilityTier; tierIndex++)
        {
            var abilityUpgrade = GameManager.instance.upgradeManager.GetUpgrade(UpgradeTags.AbilityUpgrade, (TierLevel)tierIndex);
            UpgradeList.Add(abilityUpgrade);
            UpgradeIdList.Add(abilityUpgrade.Id.Value);
        }
    }

    /// <summary>
    /// 
    /// Remove a card from the deck
    /// 
    /// </summary>
    public void RemoveCard(CardData cardData)
    {
        if (CardIdList.Contains(cardData.Id.Value))
        {
            CardList.Remove(cardData);
            CardIdList.Remove(cardData.Id.Value);
        }
        else
        {
            throw new Exception($"Card {cardData.Id} does not exist in the deck");
        }
    }

    /// <summary>
    /// 
    /// Adds an upgrade to the deck
    /// 
    /// </summary>
    public void AddUpgrade(UpgradeData upgradeData)
    {
        UpgradeList.Add(upgradeData);
        UpgradeIdList.Add(upgradeData.Id.Value);
    }

    /// <summary>
    /// 
    /// Removes an upgrade from the deck
    /// 
    /// </summary>
    public void RemoveUpgrade(UpgradeData upgradeData)
    {
        if (UpgradeIdList.Contains(upgradeData.Id.Value))
        {
            UpgradeList.Remove(upgradeData);
            UpgradeIdList.Remove(upgradeData.Id.Value);
        }
        else
        {
            throw new Exception($"Upgrade {upgradeData.Id} does not exist in the deck");
        }
    }
}
