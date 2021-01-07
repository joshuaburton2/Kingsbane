using CategoryEnums;
using UnityEngine;
using System;

[Serializable]

public class PlayerWild : PlayerResource
{
    private readonly int[] WILD_GAIN_VALUES = new int[] { 2, 3, 4 };
    private readonly int DEFAULT_MAX_WILD = 12;
    private readonly int BASE_CYCLE_INCREASE = 5;

    public int WildGain { get; set; }
    public int MaxWild { get; set; }

    public PlayerWild()
    {
        InitPlayerResource(CardResources.Wild);
        ResetValue();
        MaxWild = DEFAULT_MAX_WILD;
    }

    public PlayerWild(int wildGain, int maxWild)
    {
        ResourceType = CardResources.Wild;
        WildGain = wildGain;
        MaxWild = maxWild;
        ResetValue();
    }

    /// <summary>
    /// 
    /// Constructor for copying player resource information
    /// 
    /// </summary>
    public PlayerWild(PlayerWild playerWild)
    {
        CopyCommonResourceValues(playerWild);
        WildGain = playerWild.WildGain;
        MaxWild = playerWild.MaxWild;
    }

    /// <summary>
    /// 
    /// Sets the tier level of the player resource
    /// 
    /// </summary>
    public override void SetTierLevel(TierLevel tierLevel)
    {
        base.SetTierLevel(tierLevel);
        WildGain = WILD_GAIN_VALUES[(int)tierLevel];
    }

    /// <summary>
    /// 
    /// Resets the resource value. Should be called at the start of each scenario
    /// 
    /// </summary>
    public void ResetValue()
    {
        Value = 0;
    }

    /// <summary>
    /// 
    /// Increase the players wild by their gain. Should be called at the start of each turn
    /// 
    /// </summary>
    public void IncreaseWild()
    {
        ModifyValue(WildGain);
    }

    /// <summary>
    /// 
    /// Modifying the value of Wild requires a check to ensure it does not go above the maximum
    /// 
    /// </summary>
    public override void ModifyValue(int valueChange)
    {
        base.ModifyValue(valueChange);

        Value = Mathf.Min(Value, MaxWild);
    }

    /// <summary>
    /// 
    /// Should be called whenever a cycle effect is activated and modifies the maximum wild
    /// 
    /// </summary>
    public void CycleWild(int cycleValue)
    {
        MaxWild += cycleValue;

        //Ensures the max wild cannot go below 0
        MaxWild = Mathf.Max(MaxWild, 0);
        //Checks if the max wild has gone below the current value of the resource, and adjusts the value accordingly
        Value = Mathf.Min(Value, MaxWild);
    }

    /// <summary>
    /// 
    /// Cycle Wild by its base value. Called when adding upgrades
    /// 
    /// </summary>
    public void BaseCycleWild()
    {
        CycleWild(BASE_CYCLE_INCREASE);
    }

    /// <summary>
    /// 
    /// Start of game update for wild
    /// 
    /// </summary>
    public override void StartOfGameUpdate(int playerId)
    {
        base.StartOfGameUpdate(playerId);

        ResetValue();
    }

    /// <summary>
    /// 
    /// Start of turn update for wild
    /// 
    /// </summary>
    public override void StartOfTurnUpdate()
    {
        IncreaseWild();
    }
}