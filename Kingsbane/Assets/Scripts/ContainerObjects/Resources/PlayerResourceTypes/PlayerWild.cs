using CategoryEnums;
using UnityEngine;

public class PlayerWild : Resource
{
    private const int DEFAULT_WILD_GAIN = 2;
    private const int DEFAULT_MAX_WILD = 12;

    public int WildGain { get; set; }
    public int MaxWild { get; set; }

    public PlayerWild()
    {
        ResourceType = CardResources.Wild;
        WildGain = DEFAULT_WILD_GAIN;
        MaxWild = DEFAULT_MAX_WILD;
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
    public int IncreaseWild()
    {
        return ModifyValue(WildGain);
    }

    /// <summary>
    /// 
    /// Modifying the value of Wild requires a check to ensure it does not go above the maximum
    /// 
    /// </summary>
    public override int ModifyValue(int valueChange)
    {
        base.ModifyValue(valueChange);

        Value = Mathf.Min(Value, MaxWild);

        return Value;
    }

    /// <summary>
    /// 
    /// Should be called whenever a cycle effect is activated and modifies the maximum wild
    /// 
    /// </summary>
    public int CycleWild(int cycleValue)
    {
        MaxWild += cycleValue;

        //Ensures the max wild cannot go below 0
        MaxWild = Mathf.Max(MaxWild, 0);

        return MaxWild;
    }
}