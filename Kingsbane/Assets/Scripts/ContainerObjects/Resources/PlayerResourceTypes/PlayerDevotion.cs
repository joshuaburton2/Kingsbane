using CategoryEnums;

public class PlayerDevotion : Resource
{
    private const int DEFAULT_PRAYER_MOD = 0;
    private const int DEFAULT_LASTING_PRAYER = 2;

    public int PrayerModifier { get; set; }
    public int LastingPrayer { get; set; }

    public PlayerDevotion()
    {
        ResourceType = CardResources.Energy;
        PrayerModifier = DEFAULT_PRAYER_MOD;
        LastingPrayer = DEFAULT_LASTING_PRAYER;
    }

    /// <summary>
    /// 
    /// Resets the value to 0. To be called at the start of each scenario
    /// 
    /// </summary>
    public void ResetValue()
    {
        Value = 0;
    }

    /// <summary>
    /// 
    /// Function for when a card triggers a prayer effect
    /// 
    /// </summary>
    public int TriggerPrayer(int basePrayer)
    {
        return ModifyValue(basePrayer + PrayerModifier);
    }

    /// <summary>
    /// 
    /// Functon for updating the players Devotion with their Lasting Prayer. To be called at the start of each turn
    /// 
    /// </summary>
    public int IncreaseLastingPrayer()
    {
        return ModifyValue(LastingPrayer);
    }
}