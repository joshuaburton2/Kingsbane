using CategoryEnums;
using System;
using System.Collections.Generic;

/// <summary>
/// 
/// Filter object for generating cards during gameplay
/// 
/// </summary>
public class GenerateCardFilter
{
    //The number of cards to generate
    public int NumToGenerate { get; set; }
    //Used when deploying created units. Is the number of units required to create
    public int UnitsToCreate { get; set; }
    public string Name { get; set; }
    public bool IncludeUncollectables { get; set; }
    public bool IsUnique { get; set; }
    public CardTypes CardType { get; set; }
    public CardResources Resource { get; set; }
    public Classes.ClassList Class { get; set; }
    public Classes.ClassList ClassPlayable { get; set; }
    public Tags Tag { get; set; }
    public List<Sets> SetFilter { get; set; }

    public int? CostModification { get; set; }
    public CardResources? ResourceModification { get; set; }

    public UnitEnchantment Enchantment { get; set; }
    public KeyValuePair<StatModifierTypes, int>? DurabilityChange { get; set; }

    public GenerateCardFilter(Classes.ClassList playerClass, int numToGenerate = 1)
    {
        //Ensures the card at least has a playable class
        if (playerClass == Classes.ClassList.Default)
            throw new Exception("Card Filter requires a class");
        ClassPlayable = playerClass;

        //Ensures there is at least one card generated
        if (numToGenerate < 1)
            throw new Exception("Filter requires at least one card to generate");
        NumToGenerate = numToGenerate;

        Name = "";
        IncludeUncollectables = false;
        IsUnique = false;
        CardType = CardTypes.Default;
        Resource = CardResources.Neutral;
        Class = Classes.ClassList.Default;
        Tag = Tags.Default;
        SetFilter = new List<Sets>() { Sets.Standard };

        Enchantment = null;
        DurabilityChange = null;
    }
}
