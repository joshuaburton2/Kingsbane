﻿using CategoryEnums;
using System;
using System.Linq;
using UnityEngine;

[Serializable]

public class PlayerMana : PlayerResource
{
    private readonly int[] STARTING_MANA_VALUES = new int[] { 12, 16, 24 };
    private readonly int SET_OVERLOAD_MODIFIER = -1; //Value to modify Empowered, Attack and Health values by for each point Overloaded
    private readonly int OVERLOAD_REDUCTION = 6;

    public int StartingMana { get; set; }
    public int PreviousOverload { get; set; }
    public int CurrentOverload { get; set; }
    public int TotalOverload { get { return PreviousOverload + CurrentOverload; } }
    public int OverloadModifier { get { return TotalOverload * SET_OVERLOAD_MODIFIER; } }

    public PlayerMana()
    {
        InitPlayerResource(CardResources.Mana);
        ResetValue();
    }

    public PlayerMana(int startingMana, int overload)
    {
        ResourceType = CardResources.Mana;
        StartingMana = startingMana;
        CurrentOverload = overload;
    }

    /// <summary>
    /// 
    /// Constructor for copying player resource information
    /// 
    /// </summary>
    public PlayerMana(PlayerMana playerMana)
    {
        CopyCommonResourceValues(playerMana);
        StartingMana = playerMana.StartingMana;
        PreviousOverload = playerMana.PreviousOverload;
        CurrentOverload = playerMana.CurrentOverload;
    }

    /// <summary>
    /// 
    /// Sets the tier level of the player resource
    /// 
    /// </summary>
    public override void SetTierLevel(TierLevel tierLevel)
    {
        base.SetTierLevel(tierLevel);
        StartingMana = STARTING_MANA_VALUES[(int)tierLevel];
    }

    /// <summary>
    /// 
    /// Reset the resouce values. To be called at the start of each scenario
    /// 
    /// </summary>
    public void ResetValue()
    {
        Value = StartingMana;
        //Sets the Overload from the previous scenario and resets the new Overload value
        PreviousOverload = CurrentOverload;
        CurrentOverload = 0;
    }

    /// <summary>
    /// 
    /// Modifying the resource value for mana requires a check to update Overload value as well
    /// 
    /// </summary>
    public override void ModifyValue(int valueChange, bool clamp = false, int? clampValue = null)
    {
        base.ModifyValue(valueChange, clamp, clampValue);

        var pastOverload = TotalOverload;
        //If the value is less than 0, it means there is an Overload value
        CurrentOverload = Value < 0 ? -Value : 0;

        SetOverloadModifiers(pastOverload);
    }

    /// <summary>
    /// 
    /// Reduce Overload from previous scenario by base reduction amount. Called when adding upgrades
    /// 
    /// </summary>
    public int ReduceOverload()
    {
        return CurrentOverload -= OVERLOAD_REDUCTION;
    }

    public void SetOverloadModifiers(int? pastOverload = null)
    {
        var player = GameManager.instance.GetPlayer(PlayerId);

        if (pastOverload.HasValue)
        {
            player.ModifyEmpowered(pastOverload.Value);
            player.ModifyEmpowered(-TotalOverload);
        }

        foreach (var unit in player.DeployedUnits.Select(x => x.Unit))
        {
            unit.ModifyOverloadEnchantment(this);
        }
    }

    /// <summary>
    /// 
    /// Start of game update for Mana
    /// 
    /// </summary>
    public override void StartOfGameUpdate(int playerId)
    {
        base.StartOfGameUpdate(playerId);

        ResetValue();
        SetOverloadModifiers(0);
    }
}