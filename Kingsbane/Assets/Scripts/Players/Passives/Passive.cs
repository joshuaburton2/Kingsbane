using CategoryEnums;
using System.Collections.Generic;
using UnityEngine;

public class Passive
{
    public string Name { get; set; }
    public CardData SourceCard { get; set; }
    public UpgradeData SourceUpgrade { get; set; }

    public UnitEnchantment Enchantment { get; set; }
    public int? CostModification { get; set; }
    public CardResources? TargetResource { get; set; }
    public SpecialPassiveEffects? SpecialPassive { get; set; }
    public int? SpecialPassiveProperty { get; set; }

    public CardTypes? AffectedCardTypes { get; set; }
    public Tags? AffectedCardTag { get; set; }
    public UnitTags? AffectedUnitTags { get; set; }

    public bool PassiveApplies(Card card)
    {
        var hasTag = !AffectedCardTag.HasValue || AffectedCardTag.HasValue && card.Tags.Contains(AffectedCardTag.Value);
        var isCardType = !AffectedCardTypes.HasValue || AffectedCardTypes.HasValue && card.Type == AffectedCardTypes.Value;
        var hasUnitTag = !AffectedUnitTags.HasValue || AffectedUnitTags.HasValue && card.Type == CardTypes.Unit && ((Unit)card).UnitTags.Contains(AffectedUnitTags.Value);

        return hasTag && isCardType && hasUnitTag;
    }
}