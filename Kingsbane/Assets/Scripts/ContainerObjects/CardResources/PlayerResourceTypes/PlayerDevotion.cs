using CategoryEnums;
using System;

[Serializable]
public class PlayerDevotion : PlayerResource
{
    private readonly int[] PRAYER_MODIFIERS = new int[] { 0, 1, 2 };
    private readonly int DEFAULT_LASTING_PRAYER = 2;
    private readonly int LASTING_PRAYER_INCREASE = 1;

    public int PrayerModifier { get; set; }
    public int LastingPrayer { get; set; }

    public PlayerDevotion()
    {
        InitPlayerResource(CardResources.Devotion);
        LastingPrayer = DEFAULT_LASTING_PRAYER;
        ResetValue();
    }

    public PlayerDevotion(int prayerModifier, int lastingPrayer)
    {
        ResourceType = CardResources.Devotion;
        PrayerModifier = prayerModifier;
        LastingPrayer = lastingPrayer;
        ResetValue();
    }

    /// <summary>
    /// 
    /// Constructor for copying player resource information
    /// 
    /// </summary>
    public PlayerDevotion (PlayerDevotion playerDevotion)
    {
        CopyCommonResourceValues(playerDevotion);
        PrayerModifier = playerDevotion.PrayerModifier;
        LastingPrayer = playerDevotion.LastingPrayer;
    }

    /// <summary>
    /// 
    /// Sets the tier level of the player resource
    /// 
    /// </summary>
    public override void SetTierLevel(TierLevel tierLevel)
    {
        base.SetTierLevel(tierLevel);
        PrayerModifier = PRAYER_MODIFIERS[(int)tierLevel];
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
    public void TriggerPrayer(int basePrayer)
    {
        ModifyValue(basePrayer + PrayerModifier);
    }

    /// <summary>
    /// 
    /// Functon for updating the players Devotion with their Lasting Prayer. To be called at the start of each turn
    /// 
    /// </summary>
    public void TriggerLastingPrayer()
    {
        ModifyValue(LastingPrayer);
    }

    /// <summary>
    /// 
    /// Increases the players lasting prayer by the base amount. Called when the upgrade is added
    /// 
    /// </summary>
    public void IncreaseLastingPrayer()
    {
        LastingPrayer += LASTING_PRAYER_INCREASE;
    }

    /// <summary>
    /// 
    /// Sets the base lasting prayer for the next scenario
    /// 
    /// </summary>
    public void SetLastingPrayer(int numPrayerUnits)
    {
        LastingPrayer = numPrayerUnits + 1;
    }

    /// <summary>
    /// 
    /// Start of game update for devotion
    /// 
    /// </summary>
    public override void StartOfGameUpdate(Player player)
    {
        base.StartOfGameUpdate(player);

        ResetValue();
    }

    /// <summary>
    /// 
    /// Start of turn update for devotion
    /// 
    /// </summary>
    public override void StartOfTurnUpdate()
    {
        TriggerLastingPrayer();
    }
}