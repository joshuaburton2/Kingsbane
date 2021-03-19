using System;
using System.Collections.Generic;
using System.Linq;
using CategoryEnums;
using UnityEngine;

public class UnitEnchantment
{
    public enum EnchantmentStatus
    {
        None, //Default case for the status. Should not be used
        Base,
        Permanent,
        StartOfOwnersTurn,
        EndOfOwnersTurn,
        StartOfOpponentTurn,
        EndOfOpponentTurn,
        AfterAttack,
        Passive,
    }

    public class StatModifier
    {
        public Unit.StatTypes StatType { get; set; }
        public StatModifierTypes ModType { get; set; }
        public int Value { get; set; }
    }

    public EnchantmentStatus Status { get; set; }

    public List<StatModifier> StatModifiers { get; set; }
    public List<Keywords> Keywords { get; set; }
    public List<Unit.StatusEffects> StatusEffects { get; set; }

    public string Source { get; set; }

    public bool ValidEnchantment { get { return StatModifiers.Count > 0 || Keywords.Count > 0 || StatusEffects.Count > 0; } }

    public UnitEnchantment()
    {
        Status = EnchantmentStatus.None;

        StatModifiers = new List<StatModifier>();
        Keywords = new List<Keywords>();
        StatusEffects = new List<Unit.StatusEffects>();
    }

    public void AddStatModifier(Unit.StatTypes statType, StatModifierTypes modType, int value)
    {
        if (statType == Unit.StatTypes.Default || modType == StatModifierTypes.None)
            throw new Exception("Not valid stat modifier inputs");

        StatModifiers.Add(new StatModifier() { StatType = statType, ModType = modType, Value = value });
    }

    public string DescriptionText()
    {
        var text = new List<string>();

        foreach (var statModifier in StatModifiers)
        {
            string statText;
            switch (statModifier.ModType)
            {
                case StatModifierTypes.Modify:
                    var valueSign = statModifier.Value >= 0 ? "+" : "-";
                    statText = $"{valueSign}{Mathf.Abs(statModifier.Value)} {statModifier.StatType}, ";
                    break;
                case StatModifierTypes.Set:
                    statText = $"Set {statModifier.StatType} to {statModifier.Value}, ";
                    break;
                default:
                    throw new Exception("Not a valid modifier type");
            }
            text.Add(statText);
        }
        foreach (var keyword in Keywords)
            text.Add($"{keyword.GetEnumDescription()}, ");

        foreach (var statusEffect in StatusEffects)
            text.Add($"{statusEffect.GetEnumDescription()}, ");

        var noStatusText = false;

        switch (Status)
        {
            case EnchantmentStatus.StartOfOwnersTurn:
                text.Add("until start of owner's next turn.");
                break;
            case EnchantmentStatus.EndOfOwnersTurn:
                text.Add("until end of owner's next turn.");
                break;
            case EnchantmentStatus.StartOfOpponentTurn:
                text.Add("until start of opponent's next turn.");
                break;
            case EnchantmentStatus.EndOfOpponentTurn:
                text.Add("until end of opponent's next turn.");
                break;
            case EnchantmentStatus.AfterAttack:
                text.Add("until after the unit attacks.");
                break;
            case EnchantmentStatus.Passive:
                text.Add("passively.");
                break;
            case EnchantmentStatus.Base:
            case EnchantmentStatus.Permanent:
                noStatusText = true;
                break;
            default:
                throw new Exception("Not a valid enchantment status");
        }

        var joinedText = string.Join("", text.OrderBy(x => x));
        if (noStatusText)
        {
            joinedText = joinedText.Substring(0, joinedText.Length - 2);
        }
        return joinedText;
    }
}

