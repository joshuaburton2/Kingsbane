using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEnums;
using UnityEngine;

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
        ScenarioCreated = false;
        CardType = CardTypes.Default;
        IntFilters = new Dictionary<IntFilterTypes, KeyValuePair<IntValueFilter, int?>>();
    }

    public void AddIntFilter(IntFilterTypes filterType, IntValueFilter valueFilterType, int? value)
    {
        var isValidFilter = false;

        if (filterType != IntFilterTypes.None)
        {
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
            }
        }

        if (isValidFilter)
        {
            var valueFilter = new KeyValuePair<IntValueFilter, int?>(valueFilterType, value);
            IntFilters.Add(filterType, valueFilter);
        }
        else
        {
            Debug.LogError($"Filter of Type {filterType} cannot be applied to card of Type {CardType}");
        }
    }
}
