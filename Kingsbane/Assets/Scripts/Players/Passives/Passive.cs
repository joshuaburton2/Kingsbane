using CategoryEnums;
using System.Collections.Generic;

public class Passive
{
    public string Name { get; set; }
    public CardData SourceCard { get; set; }
    public UpgradeData SourceUpgrade { get; set; }
    public CardTypes AffectedCardTypes { get; set; }
    public List<Tags> AffectedCardTags { get; set; }
    public UnitEnchantment Enchantment { get; set; }
    public int CostModification { get; set; }
    public SpecialPassiveEffects SpecialPassive { get; set; }

}