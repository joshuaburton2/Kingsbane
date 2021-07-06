using CategoryEnums;

/// <summary>
/// 
/// Object for storing a cost adjusment on a card
/// 
/// </summary>
public class AdjustCostObject
{
    public int Value { get; set; }
    public StatModifierTypes AdjustmentType { get; set; }
    public int? MinCost { get; set; }
    public int? MustBeGreaterThan { get; set; }
    public CardResources? TargetResource { get; set; }
    public CardTypes? TargetCardType { get; set; }
    public bool FromPassive { get; set; }
}
