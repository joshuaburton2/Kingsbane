using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEnums;

public class CardListFilter
{
    public string Name { get; set; }
    public Rarity Rarity { get; set; }
    public Classes.ClassList Class { get; set; }
    public Tags Tag { get; set; }
    public CardResources Resource { get; set; }
    public bool? ScenarioCreated { get; set; }
    public Dictionary<IntValueFilter, int> CostFilter { get; set; }
    public Dictionary<IntValueFilter, int> AttackFilter { get; set; }
    public Dictionary<IntValueFilter, int> HealthFilter { get; set; }
    public Dictionary<IntValueFilter, int> RangeFilter { get; set; }
    public Dictionary<IntValueFilter, int> SpeedFilter { get; set; }
    public Dictionary<IntValueFilter, int> SpellRangeFilter { get; set; }
    public Dictionary<IntValueFilter, int> Durability { get; set; }

    public CardListFilter()
    {
        Name = "";
        Rarity = Rarity.Default;
        Class = Classes.ClassList.Default;
        Tag = Tags.Default;
        Resource = CardResources.Neutral;
        ScenarioCreated = false;
        CostFilter = new Dictionary<IntValueFilter, int>();
        AttackFilter = new Dictionary<IntValueFilter, int>();
        HealthFilter = new Dictionary<IntValueFilter, int>();
        RangeFilter = new Dictionary<IntValueFilter, int>();
        SpeedFilter = new Dictionary<IntValueFilter, int>();
        SpellRangeFilter = new Dictionary<IntValueFilter, int>();
        Durability = new Dictionary<IntValueFilter, int>();
    }
}
