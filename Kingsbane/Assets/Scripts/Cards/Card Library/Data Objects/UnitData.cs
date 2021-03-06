﻿using System;
using System.Collections.Generic;
using System.Linq;
using CategoryEnums;

/// <summary>
/// 
/// Object for storing unique data for unit cards
/// 
/// </summary>
public class UnitData : CardData
{
    public List<UnitTags> UnitTag { get; set; }

    public int Attack { get; set; }
    public int Health { get; set; }
    public int Protected { get; set; }
    public int Range { get; set; }
    public int Speed { get; set; }
    public int Empowered { get; set; }

    public List<AbilityData> Abilities { get; set; }

    public List<Keywords> Keywords { get; set; }

    /// <summary>
    /// 
    /// Default Constructor. Cards should not have an Id of negative 1 so this is a good test to see if a card should exist or not.
    /// 
    /// </summary>
    public UnitData()
    {
        Id = -1;
    }

    /// <summary>
    /// 
    /// Used to copy unit data into a new object. Should rarely be used as card data should almost always be pulled from CardLibrary.cs
    /// 
    /// </summary>
    public UnitData(UnitData unitData)
    {
        //Not sure if there is a way to improve this to use the copying constructor of CardData as a base. Should investigate
        Id = unitData.Id;
        Name = unitData.Name;
        ImageTag = unitData.ImageTag;

        Resources = unitData.Resources.ToList();

        Text = unitData.Text;
        LoreText = unitData.LoreText;
        Notes = unitData.Notes;

        Set = unitData.Set;
        Class = unitData.Class;
        Rarity = unitData.Rarity;
        CardType = unitData.CardType;

        Tags = unitData.Tags;
        Synergies = unitData.Synergies;
        RelatedCards = unitData.RelatedCards;

        UnitTag = unitData.UnitTag;
        Attack = unitData.Attack;
        Health = unitData.Health;
        Range = unitData.Range;
        Speed = unitData.Speed;

        Abilities = unitData.Abilities;
    }

    public TierLevel GetHeroTier()
    {
        return HeroTier.ConvertTierLevel(this);
    }
}
