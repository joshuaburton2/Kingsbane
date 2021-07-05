using System;
using System.Collections.Generic;
using System.Linq;
using CategoryEnums;
using UnityEngine;

/// <summary>
/// 
/// Object for storing enchantment details for a unit
/// 
/// </summary>
public class UnitEnchantment
{
    public enum EnchantmentStatus
    {
        None, //Default case for the status. Should not be used on an enchantment that is actually being applied
        Base,
        Permanent,
        StartOfOwnersTurn,
        EndOfOwnersTurn,
        StartOfOpponentTurn,
        EndOfOpponentTurn,
        AfterAttack,
        Passive,
        OverloadPassive,
    }

    /// <summary>
    /// 
    /// Object for storing a stat modifier in an enchantment
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Adds a new stat modifier to the enchantment
    /// 
    /// </summary>
    /// <param name="statType"></param>
    /// <param name="modType"></param>
    /// <param name="value"></param>
    public void AddStatModifier(Unit.StatTypes statType, StatModifierTypes modType, int value)
    {
        if (statType == Unit.StatTypes.Default || modType == StatModifierTypes.None)
            throw new Exception("Not valid stat modifier inputs");

        if (StatModifiers.Any(x => x.StatType == statType))
            StatModifiers.RemoveAll(x => x.StatType == statType);

        StatModifiers.Add(new StatModifier() { StatType = statType, ModType = modType, Value = value });
    }

    /// <summary>
    /// 
    /// Gets a description text for an enchantment
    /// 
    /// </summary>
    /// <returns></returns>
    public string DescriptionText()
    {
        //Does require some work, formatting is not right currently

        var text = new List<string>();

        //Adds the stat modifiers text
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

        //Adds the keyword and status effect texts
        foreach (var keyword in Keywords)
            text.Add($"{keyword.GetEnumDescription()}, ");

        foreach (var statusEffect in StatusEffects)
            text.Add($"{statusEffect.GetEnumDescription()}, ");

        //Adds the enchantment status text
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
            case EnchantmentStatus.OverloadPassive:
                text.Add("passively.");
                break;
            case EnchantmentStatus.Base:
            case EnchantmentStatus.Permanent:
                noStatusText = true;
                break;
            default:
                throw new Exception("Not a valid enchantment status");
        }

        //Joins the text together
        var joinedText = string.Join("", text.OrderBy(x => x));
        //If a base or permanent enchantment, removes the comma and space from the end of the text
        if (noStatusText)
        {
            joinedText = joinedText.Substring(0, joinedText.Length - 2);
        }
        return joinedText;
    }
}

