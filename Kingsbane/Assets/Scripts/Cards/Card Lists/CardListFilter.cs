using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEnums;
using UnityEngine;

/// <summary>
/// 
/// Filter object for searching through a card list
/// 
/// </summary>
public class CardListFilter
{
    public enum IntFilterTypes
    {
        None,
        Cost,
        Attack,
        Health,
        Range,
        Speed,
        SpellRange,
        Durability,
    }

    public string Name { get; set; }
    public Rarity Rarity { get; set; }
    public Classes.ClassList Class { get; set; }
    public Tags Tag { get; set; }
    public CardResources Resource { get; set; }
    public bool? ScenarioCreated { get; set; }
    public CardTypes CardType { get; set; }
    public Dictionary<IntFilterTypes, KeyValuePair<IntValueFilter, int?>> IntFilters { get; set; }

    public CardListFilter()
    {
        Name = "";
        Rarity = Rarity.Default;
        Class = Classes.ClassList.Default;
        Tag = Tags.Default;
        Resource = CardResources.Neutral;
        ScenarioCreated = null;
        CardType = CardTypes.Default;
        IntFilters = new Dictionary<IntFilterTypes, KeyValuePair<IntValueFilter, int?>>();
    }

    /// <summary>
    /// 
    /// Adds an integer filter of a given type to the filter
    /// 
    /// </summary>
    /// <param name="filterType">The type of filter required to check</param>
    /// <param name="valueFilterType">The comparison type required for the filter</param>
    /// <param name="value">The value to use in the comparison</param>
    public void AddIntFilter(IntFilterTypes filterType, IntValueFilter valueFilterType, int? value)
    {
        bool isValidFilter;

        //Checks if the filter type is not a default. Otherwise throws an exception
        if (filterType != IntFilterTypes.None)
        {
            //Checks if the given filter type is valid for the filters given card type. Note that certain filter types may not require a particular card type
            switch (filterType)
            {
                case IntFilterTypes.Attack:
                case IntFilterTypes.Health:
                case IntFilterTypes.Range:
                case IntFilterTypes.Speed:
                    isValidFilter = CardType == CardTypes.Unit;
                    break;
                case IntFilterTypes.SpellRange:
                    isValidFilter = CardType == CardTypes.Spell;
                    break;
                case IntFilterTypes.Durability:
                    isValidFilter = CardType == CardTypes.Item;
                    break;
                default:
                    isValidFilter = true;
                    break;
            }

            //Sets the null value for highest and lowest filters as the value here is not required
            if (valueFilterType == IntValueFilter.Highest || valueFilterType == IntValueFilter.Lowest)
            {
                value = null;
            }
        }
        else
        {
            throw new Exception("Not a valid filter type");
        }

        //Checks if a valid filter
        if (isValidFilter)
        {
            //Creates the key value pair and adds it to the filter
            var valueFilter = new KeyValuePair<IntValueFilter, int?>(valueFilterType, value);
            IntFilters.Add(filterType, valueFilter);
        }
        else
        {
            Debug.LogError($"Filter of Type {filterType} cannot be applied to card of Type {CardType}");
        }
    }
}
