using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEnums;

public class CardListFilter
{
    public enum IntFilterTypes
    {
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
    public Dictionary<IntFilterTypes, KeyValuePair<IntValueFilter, int?>> IntFilters { get; set; }

    public CardListFilter()
    {
        Name = "";
        Rarity = Rarity.Default;
        Class = Classes.ClassList.Default;
        Tag = Tags.Default;
        Resource = CardResources.Neutral;
        ScenarioCreated = false;
        IntFilters = new Dictionary<IntFilterTypes, KeyValuePair<IntValueFilter, int?>>();
    }

    public void AddIntFilter(IntFilterTypes filterType, IntValueFilter valueFilterType, int? value)
    {
        var valueFilter = new KeyValuePair<IntValueFilter, int?>(valueFilterType, value);
        IntFilters.Add(filterType, valueFilter);
    }
}
