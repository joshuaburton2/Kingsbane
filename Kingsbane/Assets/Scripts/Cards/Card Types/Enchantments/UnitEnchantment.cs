using System;
using System.Collections.Generic;
using CategoryEnums;

public class UnitEnchantment
{
    public enum EnchantmentStatus
    {
        None, //Default case for the status. Should not be used
        Default, //For keywords that come from the base unit stats
        Base,
        Permanent,
        StartOfTurn,
        EndOfTurn,
        StartOfOpponentTurn,
        EndOfOpponentTurn,
        AfterAttack,
    }

    public class StatModifier
    {
        public Unit.StatTypes StatType { get; set; }
        public StatModifierType ModType { get; set; }
        public int Value { get; set; }
    }

    public EnchantmentStatus Status { get; set; }

    public List<StatModifier> StatModifiers { get; set; }
    public List<BaseUnitKeywords> Keywords { get; set; }
    public List<Unit.StatusEffects> StatusEffects { get; set; }

    public bool IsActive { get; set; }
    public string Source { get; set; }

    public UnitEnchantment()
    {
        IsActive = true;
        Status = EnchantmentStatus.None;

        StatModifiers = new List<StatModifier>();
        Keywords = new List<BaseUnitKeywords>();
        StatusEffects = new List<Unit.StatusEffects>();
    }

    public void AddStatModifier(Unit.StatTypes statType, StatModifierType modType, int value)
    {
        if (statType == Unit.StatTypes.Default || modType == StatModifierType.None)
            throw new Exception("Not valid stat modifier inputs");

        StatModifiers.Add(new StatModifier() { StatType = statType, ModType = modType, Value = value });
    }

    public string DescriptionText()
    {
        return "";
    }
}

