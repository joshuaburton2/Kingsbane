using CategoryEnums;
using System;

[Serializable]

public class PlayerGold : PlayerResource
{
    private readonly int DEFAULT_GOLD = 12;
    private readonly int[] BOUNTY_GAINS = new int[] { 1, 2, 3 };
    private readonly int GOLD_INCREASE = 3;

    public int BountyGain { get; set; }

    public PlayerGold()
    {
        InitPlayerResource(CardResources.Gold);
        Value = DEFAULT_GOLD;
    }

    /// <summary>
    /// 
    /// Constructor for copying player resource information
    /// 
    /// </summary>
    public PlayerGold(PlayerGold playerGold)
    {
        CopyCommonResourceValues(playerGold);
        BountyGain = playerGold.BountyGain;
    }

    /// <summary>
    /// 
    /// Sets the tier level of the player resource
    /// 
    /// </summary>
    public override void SetTierLevel(TierLevel tierLevel)
    {
        base.SetTierLevel(tierLevel);
        BountyGain = BOUNTY_GAINS[(int)tierLevel];
    }

    /// <summary>
    /// 
    /// Increases the gold value by the bounty amount
    /// 
    /// </summary>
    public int TriggerBounty(int extraBounty = 0, int multiplier = 1)
    { 
        return ModifyValue((BountyGain + extraBounty) * multiplier);
    }

    /// <summary>
    /// 
    /// Increases Gold amount. Intended to be used through an upgrade
    /// 
    /// </summary>
    public int IncreaseGold()
    {
        return ModifyValue(GOLD_INCREASE);
    }
}