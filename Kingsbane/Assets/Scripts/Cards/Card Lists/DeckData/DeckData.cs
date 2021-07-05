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
    //Id of the hero card for NPC decks
    public int HeroCardID { get; set; }
    public List<PlayerResource> PlayerResources { get; set; }
    public int InitialHandSize { get; set; }
    private const int DEFAULT_HAND_SIZE = 3;
    public int ItemCapacity { get; set; }
    private const int DEFAULT_ITEM_CAPACITY = 1;
    public List<int> CardIdList { get; set; }
    public List<int> UpgradeIdList { get; set; }
    public Classes.ClassList DeckClass { get; set; }
    public bool IsNPCDeck { get; set; }
    public List<CardResources> DeckResources { get { return Classes.GetClassData(DeckClass).GetClassResources(); } }
    public int PassiveEmpowered { get; set; }
    public int BaseSummonCapactiy { get; set; }
    public bool DeathDefiant { get; set; }
    public CampaignProgression CampaignTracker { get; set; }
    public bool IsCampaign { get { return CampaignTracker != null; } }

    public DeckSaveData()
    {
        Id = null;
        HeroTier = TierLevel.Default;
        AbilityTier = TierLevel.Default;
        InitialHandSize = DEFAULT_HAND_SIZE;
        ItemCapacity = DEFAULT_ITEM_CAPACITY;
        PassiveEmpowered = 0;
        BaseSummonCapactiy = 1;
        DeathDefiant = false;
        CampaignTracker = null;
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
        InitialHandSize = deckData.InitialHandSize;
        ItemCapacity = deckData.ItemCapacity;
        HeroCardID = deckData.HeroCardID;
        CardIdList = deckData.CardIdList.ToList();
        UpgradeIdList = deckData.UpgradeIdList.ToList();
        DeckClass = deckData.DeckClass;
        IsNPCDeck = deckData.IsNPCDeck;
        PassiveEmpowered = deckData.PassiveEmpowered;
        BaseSummonCapactiy = deckData.BaseSummonCapactiy;
        DeathDefiant = deckData.DeathDefiant;
        CampaignTracker = deckData.CampaignTracker;

        PlayerResources = deckData.CopyPlayerResources();
    }

    /// <summary>
    /// 
    /// Copies the player resources of the deck data to a new object to prevent referencing issues
    /// 
    /// </summary>
    /// <returns></returns>
    public List<PlayerResource> CopyPlayerResources()
    {
        var resourceCopy = new List<PlayerResource>();

        foreach (var resource in PlayerResources)
        {
            if (resource is PlayerDevotion)
                resourceCopy.Add(new PlayerDevotion((PlayerDevotion)resource));

            else if (resource is PlayerEnergy)
                resourceCopy.Add(new PlayerEnergy((PlayerEnergy)resource));

            else if (resource is PlayerGold)
                resourceCopy.Add(new PlayerGold((PlayerGold)resource));

            else if (resource is PlayerKnowledge)
                resourceCopy.Add(new PlayerKnowledge((PlayerKnowledge)resource));

            else if (resource is PlayerMana)
                resourceCopy.Add(new PlayerMana((PlayerMana)resource));

            else if (resource is PlayerWild)
                resourceCopy.Add(new PlayerWild((PlayerWild)resource));

            else
                throw new Exception("Not a valid Player Resource");
        }

        return resourceCopy;
    }

    /// <summary>
    /// 
    /// Initialise the player resource objects for the deck upon creation of the deck
    /// 
    /// </summary>
    public void LoadDeckResources()
    {
        PlayerResources = new List<PlayerResource>();

        foreach (var resource in DeckResources)
        {
            switch (resource)
            {
                case CardResources.Devotion:
                    PlayerResources.Add(new PlayerDevotion());
                    break;
                case CardResources.Energy:
                    PlayerResources.Add(new PlayerEnergy());
                    break;
                case CardResources.Gold:
                    PlayerResources.Add(new PlayerGold());
                    break;
                case CardResources.Knowledge:
                    PlayerResources.Add(new PlayerKnowledge());
                    break;
                case CardResources.Mana:
                    PlayerResources.Add(new PlayerMana());
                    break;
                case CardResources.Wild:
                    PlayerResources.Add(new PlayerWild());
                    break;
                case CardResources.Neutral:
                default:
                    throw new Exception("Not a valid resource type");
            }
        }
    }
}

public class DeckData : DeckSaveData
{
    public UnitData HeroCard { get; set; }
    public List<CardData> CardList { get; set; }
    public List<UpgradeData> UpgradeList { get; set; }
    public int DeckCount { get { return CardList.Count; } }

    public DeckData()
    {
        PlayerResources = new List<PlayerResource>();
        CardIdList = new List<int>();
        UpgradeIdList = new List<int>();
        CardList = new List<CardData>();
        UpgradeList = new List<UpgradeData>();
    }

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
        InitialHandSize = deckData.InitialHandSize;
        ItemCapacity = deckData.ItemCapacity;
        HeroCardID = deckData.HeroCardID;
        CardIdList = deckData.CardIdList.ToList();
        UpgradeIdList = deckData.UpgradeIdList.ToList();
        DeckClass = deckData.DeckClass;
        IsNPCDeck = deckData.IsNPCDeck;
        PassiveEmpowered = deckData.PassiveEmpowered;
        BaseSummonCapactiy = deckData.BaseSummonCapactiy;
        DeathDefiant = deckData.DeathDefiant;
        CampaignTracker = deckData.CampaignTracker;

        PlayerResources = deckData.CopyPlayerResources();

        //Synchronizes the card Ids with the cards in the library
        SyncDeckCards();
    }

    /// <summary>
    /// 
    /// Constructor for copying deck save data into a new deck data object. Since this is called in during Awake, have to reference
    /// Library Manager directly rather than through singleton Game Manager, since it is not initialised
    /// 
    /// </summary>
    public DeckData(DeckSaveData deckSaveData, bool isNewDeck)
    {
        Id = deckSaveData.Id;
        Name = deckSaveData.Name;
        HeroTier = deckSaveData.HeroTier;
        AbilityTier = deckSaveData.AbilityTier;
        InitialHandSize = deckSaveData.InitialHandSize;
        ItemCapacity = deckSaveData.ItemCapacity;
        HeroCardID = deckSaveData.HeroCardID;
        CardIdList = deckSaveData.CardIdList.ToList();
        UpgradeIdList = deckSaveData.UpgradeIdList.ToList();
        DeckClass = deckSaveData.DeckClass;
        IsNPCDeck = deckSaveData.IsNPCDeck;
        PassiveEmpowered = deckSaveData.PassiveEmpowered;
        BaseSummonCapactiy = deckSaveData.BaseSummonCapactiy;
        DeathDefiant = deckSaveData.DeathDefiant;
        CampaignTracker = deckSaveData.CampaignTracker;

        //Only need to create the deck resources if the deck is newly created, not loaded from file
        if (isNewDeck)
        {
            deckSaveData.LoadDeckResources();
        }
        PlayerResources = deckSaveData.CopyPlayerResources();

        //Synchronizes the card and upgrade Ids with the cards in the library
        SyncDeckCards();
    }

    /// <summary>
    /// 
    /// Synchronizes the card and upgrades ids with the values in their relevant library
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
        CardList = CardList.OrderCardList();

        UpgradeList = new List<UpgradeData>();
        foreach (var upgradeId in UpgradeIdList)
        {
            UpgradeList.Add(GameManager.instance.upgradeManager.GetUpgrade(upgradeId));
        }
    }

    /// <summary>
    /// 
    /// Load the hero card into the deck. Since this is called in during Awake, have to reference
    /// Library Manager directly rather than through singleton Game Manager, since it is not initialised
    /// 
    /// </summary>
    public void LoadHero()
    {
        if (IsNPCDeck)
        {
            HeroCard = (UnitData)GameManager.instance.libraryManager.GetCard(HeroCardID);
        }
        else
        {
            if (HeroTier != TierLevel.Default)
            {
                HeroCard = GameManager.instance.libraryManager.GetHero(DeckClass, HeroTier, AbilityTier);
            }
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
        CardList = CardList.OrderCardList();
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
    public void AddUpgrade(UpgradeData upgradeData, bool trackAddition = true)
    {
        UpgradeList.Add(upgradeData);
        UpgradeIdList.Add(upgradeData.Id.Value);
        GameManager.instance.upgradeManager.UpdateUpgradeEffect(upgradeData, this);

        if (IsCampaign)
        {
            if (trackAddition)
            {
                CampaignTracker.HonourPoints -= upgradeData.GetHonourPointsCost(CampaignTracker.CompletedSinceTierUpgrade);
                if (upgradeData.IsTierLevel)
                    CampaignTracker.CompletedSinceTierUpgrade = 0;
            }
        }

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

            if (upgradeData.UpgradeTag == UpgradeTags.DeathDefiant)
                DeathDefiant = false;
        }
        else
        {
            throw new Exception($"Upgrade {upgradeData.Id} does not exist in the deck");
        }
    }

    /// <summary>
    /// 
    /// Gets a player resource of a particular type
    /// 
    /// </summary>
    public PlayerResource GetPlayerResource(CardResources resource)
    {
        return PlayerResources.FirstOrDefault(x => x.ResourceType == resource);
    }

    /// <summary>
    /// 
    /// Converts a campaign deck to a base deck
    /// 
    /// </summary>
    public void ConverToBaseDeck()
    {
        if (IsCampaign)
        {
            CampaignTracker = null;
            //Unloads the campaign deck if converting. Required if the player exits the gameplay scene
            if (GameManager.instance.CampaignDeck.Id == Id)
            {
                GameManager.instance.CampaignDeck = null;
            }
        }
        else
        {
            throw new Exception("Cannot convert an already base deck to a base deck");
        }
    }
}
