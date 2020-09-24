using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 
/// Object for keeping track of the filters for a particular set of cards
/// 
/// </summary>
public class CardFilter
{
    public string SearchString { get; set; }
    public List<CardTypes> CardTypeFilter { get; set; }
    public List<Rarity> RaritiyFilter { get; set; }
    public List<Sets> SetFilter { get; set; }
    public Classes.ClassList ClassPlayableFilter { get; set; }

    /// <summary>
    /// 
    /// When searching through the library, can utilise commas to seperate search terms
    /// 
    /// </summary>
    public List<string> SearchStrings
    {
        get
        {
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
        RaritiyFilter = new List<Rarity>() { Rarity.Common, Rarity.Uncommon, Rarity.Rare, Rarity.Epic, Rarity.Legendary };
        SetFilter = new List<Sets>();
        foreach (var set in Enum.GetValues(typeof(Sets)).Cast<Sets>())
            SetFilter.Add(set);
        SetFilter.Remove(Sets.Default);
        ClassPlayableFilter = Classes.ClassList.Default;
    }
}
