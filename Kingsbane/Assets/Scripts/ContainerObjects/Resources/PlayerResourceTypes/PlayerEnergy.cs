using CategoryEnums;

public class PlayerEnergy : PlayerResource
{
    private const int DEFAULT_BASE_ENERGY = 3;
    private const int DEFAULT_SURGES = 2;
    private const int SURGE_INCREASE_VALUE = 1;

    public int BaseEnergyGain { get; set; }
    public int Surges { get; set; }

    public PlayerEnergy()
    {
        ResourceType = CardResources.Energy;
        BaseEnergyGain = DEFAULT_BASE_ENERGY;
        Surges = DEFAULT_SURGES;
    }

    /// <summary>
    /// 
    /// Refresh Energy to its base amount. Should be called at the start of the players turn
    /// 
    /// </summary>
    public int RefreshValue()
    {
        Value = BaseEnergyGain;
        return Value;
    }

    /// <summary>
    /// 
    /// To be called when the player uses a Surge
    /// 
    /// </summary>
    public int UseSurge(out int numSurges)
    {
        Surges--;
        Value += BaseEnergyGain;

        numSurges = Surges;
        return Value;
    }

    /// <summary>
    /// 
    /// Increase number of surges
    /// 
    /// </summary>
    public int AddSurges()
    {
        return Surges += SURGE_INCREASE_VALUE;
    }
}