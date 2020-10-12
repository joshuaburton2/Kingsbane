using CategoryEnums;

public class PlayerMana : Resource
{
    private const int DEFAULT_MANA_VALUE = 12;
    private const int SET_OVERLOAD_MODIFIER = -1; //Value to modify Empowered, Attack and Health values by for each point Overloaded

    public int StartingMana { get; set; }
    public int PreviousOverload { get; set; }
    public int CurrentOverload { get; set; }
    public int TotalOverload { get { return PreviousOverload + CurrentOverload; } }
    public int OverloadModifier { get { return TotalOverload * SET_OVERLOAD_MODIFIER; } }

    public PlayerMana()
    {
        ResourceType = CardResources.Mana;
        StartingMana = DEFAULT_MANA_VALUE;
        PreviousOverload = 0;
        CurrentOverload = 0;
    }

    /// <summary>
    /// 
    /// Reset the resouce values. To be called at the start of each scenario
    /// 
    /// </summary>
    public int ResetValue()
    {
        Value = StartingMana;
        //Sets the Overload from the previous scenario and resets the new Overload value
        PreviousOverload = CurrentOverload;
        CurrentOverload = 0;
        return Value;
    }

    /// <summary>
    /// 
    /// Modifying the resource value for mana requires a check to update Overload value as well
    /// 
    /// </summary>
    public override int ModifyValue(int valueChange)
    {
        base.ModifyValue(valueChange);

        //If the value is less than 0, it means there is an Overload value
        CurrentOverload = Value < 0 ? - Value : 0;

        return Value;
    }
}