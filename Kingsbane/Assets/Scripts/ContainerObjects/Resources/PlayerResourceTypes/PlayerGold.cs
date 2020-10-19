using CategoryEnums;

public class PlayerGold : PlayerResource
{
    private const int DEFAULT_GOLD = 12;
    private const int DEFAULT_BOUNTY = 3;
    private const int GOLD_INCREASE = 3;

    public int BountyGain { get; set; }

    public PlayerGold()
    {
        ResourceType = CardResources.Gold;
        Value = DEFAULT_GOLD;
        BountyGain = DEFAULT_BOUNTY;
    }

    /// <summary>
    /// 
    /// Increases the gold value by the bounty amount
    /// 
    /// </summary>
    public int TriggerBounty()
    { 
        return ModifyValue(BountyGain);
    }

    /// <summary>
    /// 
    /// Increases Gold amount. Intended to be used through an upgrade
    /// 
    /// </summary>
    /// <returns></returns>
    public int IncreaseGold()
    {
        return ModifyValue(GOLD_INCREASE);
    }
}