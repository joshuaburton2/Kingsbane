using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardFilter
{
    public string SearchString { get; set; }
    public List<CardTypes> CardTypeFilter { get; set; }
    public List<Rarity> RaritiyFilter { get; set; }
    public List<Sets> SetFilter { get; set; }
    public List<CardResources> ResourceFilter { get; set; }

    public List<string> SearchStrings
    {
        get
        {
            SearchString = SearchString.Replace(" ", "");
            return SearchString.Split(',').ToList();
        }
    }

    /// <summary>
    /// 
    /// Default filter. Includes all cards except Uncollectable ones and Neutral Cards
    /// 
    /// </summary>
    public CardFilter()
    {
        SearchString = "";
        CardTypeFilter = new List<CardTypes>() { CardTypes.Unit, CardTypes.Spell, CardTypes.Item };
        RaritiyFilter = new List<Rarity>() { Rarity.Common, Rarity.Uncommon, Rarity.Rare, Rarity.Epic, Rarity.Legendary, Rarity.Hero };
        SetFilter = new List<Sets>();
        foreach (var set in Enum.GetValues(typeof(Sets)).Cast<Sets>())
            SetFilter.Add(set);
        SetFilter.Remove(Sets.Default);
        ResourceFilter = new List<CardResources>();
    }
}
