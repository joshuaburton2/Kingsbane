using CategoryEnums;

public class AdjustCostObject
{
    public int Value { get; set; }
    public StatModifierTypes AdjustmentType { get; set; }
    public int? MinCost { get; set; }
    public int? MustBeGreaterThan { get; set; }
    public CardResources? TargetResource { get; set; }
    public CardTypes? TargetCardType { get; set; }
}
