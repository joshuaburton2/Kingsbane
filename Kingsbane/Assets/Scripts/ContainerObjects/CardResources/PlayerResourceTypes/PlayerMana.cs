using CategoryEnums;
using System;
using System.Linq;
using UnityEngine;

[Serializable]

public class PlayerMana : PlayerResource
{
    private readonly int[] STARTING_MANA_VALUES = new int[] { 12, 16, 24 };
    private readonly int SET_OVERLOAD_MODIFIER = -1; //Value to modify Empowered, Attack and Health values by for each point Overloaded
    private readonly int OVERLOAD_REDUCTION = 6;
    private readonly int DEFAULT_SUMMON_CAPACITY = 1;

    public int StartingMana { get; set; }
    public int PreviousOverload { get; set; }
    public int CurrentOverload { get; set; }
    public int TotalOverload { get { return PreviousOverload + CurrentOverload; } }
    public int OverloadModifier { get { return TotalOverload * SET_OVERLOAD_MODIFIER; } }

    public int PassiveEmpowered { get; set; }
    public int CurrentEmpowered { get; set; }
    public int BaseSummonCapactiy { get; set; }
    public int SummonCapcity { get; set; }
    public int CurrentSummons { get; set; }


    public PlayerMana()
    {
        InitPlayerResource(CardResources.Mana);
        PassiveEmpowered = 0;
        BaseSummonCapactiy = DEFAULT_SUMMON_CAPACITY;
        ResetValue();
    }

    public PlayerMana(int startingMana, int overload)
    {
        ResourceType = CardResources.Mana;
        StartingMana = startingMana;
        CurrentOverload = overload;

        PassiveEmpowered = 0;
        BaseSummonCapactiy = DEFAULT_SUMMON_CAPACITY;
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
        PassiveEmpowered = playerMana.PassiveEmpowered;
        BaseSummonCapactiy = playerMana.BaseSummonCapactiy;
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

        CurrentEmpowered = PassiveEmpowered;
        SummonCapcity = BaseSummonCapactiy;
    }

    /// <summary>
    /// 
    /// Modifying the resource value for mana requires a check to update Overload value as well
    /// 
    /// </summary>
    public override void ModifyValue(int valueChange)
    {
        base.ModifyValue(valueChange);

        //If the value is less than 0, it means there is an Overload value
        CurrentOverload = Value < 0 ? -Value : 0;
    }

    /// <summary>
    /// 
    /// Reduce Overload from previous scenario by base reduction amount. Called when adding upgrades
    /// 
    /// </summary>
    public int ReduceOverload()
    {
        return PreviousOverload -= OVERLOAD_REDUCTION;
    }

    private void SetOverloadModifiers(Player player)
    {
        //Need to add Empowered debuff in here when determined how this is going to work

        foreach (var unit in player.DeployedUnits.Select(x => x.Unit))
        {
            //unit.Attack = Mathf.Max(1, )
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
    }

    /// <summary>
    /// 
    /// Modify the current empowered value
    /// 
    /// </summary>
    public void ModifyEmpowered(int value)
    {
        CurrentEmpowered += value;
        CurrentEmpowered = Mathf.Max(0, CurrentEmpowered);
    }

    /// <summary>
    /// 
    /// Modify the current summon capacity
    /// 
    /// </summary>
    public void ModifySummonCapacity(int value)
    {
        SummonCapcity += value;
        SummonCapcity = Mathf.Max(1, SummonCapcity);
    }

    /// <summary>
    /// 
    /// Modify the current summon amount
    /// 
    /// </summary>
    public void ModifyCurrentSummons(int value)
    {
        CurrentSummons += value;
        CurrentSummons = Mathf.Clamp(CurrentSummons, 0, SummonCapcity);
    }
}