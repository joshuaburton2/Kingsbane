using CategoryEnums;
using System;

[Serializable]

public class PlayerEnergy : PlayerResource
{
    private readonly int[] BASE_ENERGY_GAINS = new int[] { 3, 5, 7 };
    private readonly int DEFAULT_SURGES = 2;
    private readonly int SURGE_INCREASE_VALUE = 1;

    public int BaseEnergyGain { get; set; }
    public int Surges { get; set; }

    public PlayerEnergy()
    {
        InitPlayerResource(CardResources.Energy);
        RefreshValue();
        Surges = DEFAULT_SURGES;
    }

    public PlayerEnergy(int baseEnergyGain, int surges)
    {
        ResourceType = CardResources.Energy;
        BaseEnergyGain = baseEnergyGain;
        Surges = surges;
    }

    /// <summary>
    /// 
    /// Constructor for copying player resource information
    /// 
    /// </summary>
    public PlayerEnergy(PlayerEnergy playerEnergy)
    {
        CopyCommonResourceValues(playerEnergy);
        BaseEnergyGain = playerEnergy.BaseEnergyGain;
        Surges = playerEnergy.Surges;
    }

    /// <summary>
    /// 
    /// Sets the tier level of the player resource
    /// 
    /// </summary>
    public override void SetTierLevel(TierLevel tierLevel)
    {
        base.SetTierLevel(tierLevel);
        BaseEnergyGain = BASE_ENERGY_GAINS[(int)tierLevel];
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

    /// <summary>
    /// 
    /// Start of turn update for energy
    /// 
    /// </summary>
    public override void StartOfTurnUpdate()
    {
        RefreshValue();
    }
}