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
    public Classes.ClassList Class { get; set; }
    public Classes.ClassList ClassPlayableFilter { get; set; }
    public List<Tags> Tags { get; set; }

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
    /// If true generates the default filter. Includes all cards except Uncollectable ones and Neutral Cards
    /// If false generates a blank filter
    /// 
    /// </summary>
    public CardFilter(bool isDefault = true)
    {
        if (isDefault)
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
        else
        {
            SearchString = "";
            CardTypeFilter = new List<CardTypes>();
            RaritiyFilter = new List<Rarity>();
            SetFilter = new List<Sets>();
            ClassPlayableFilter = Classes.ClassList.Default;
        }
    }
}
