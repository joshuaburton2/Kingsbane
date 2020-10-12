using CategoryEnums;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 
/// Data for storing Abilities on cards
/// 
/// </summary>
public class AbilityData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public int? ResourceDevotion { get; set; }
    public int? ResourceEnergy { get; set; }
    public int? ResourceGold { get; set; }
    public int? ResourceKnowledge { get; set; }
    public int? ResourceMana { get; set; }
    public int? ResourceWild { get; set; }
    public int? ResourceNeutral { get; set; }
    public bool CostsAction { get; set; }

    /// <summary>
    /// 
    /// Fetches the ability resources as a list. Note that Value is forced to be negative for abilites as they reduce the players resources when they are played
    /// 
    /// </summary>
    public List<Resource> GetResources
    {
        get
        {
            var abilityResources = new List<Resource>();

            if (ResourceDevotion.HasValue)
                abilityResources.Add(new Resource() { ResourceType = CardResources.Devotion, Value = -ResourceDevotion.Value });
            if (ResourceEnergy.HasValue)
                abilityResources.Add(new Resource() { ResourceType = CardResources.Energy, Value = -ResourceEnergy.Value });
            if (ResourceGold.HasValue)
                abilityResources.Add(new Resource() { ResourceType = CardResources.Gold, Value = -ResourceGold.Value });
            if (ResourceKnowledge.HasValue)
                abilityResources.Add(new Resource() { ResourceType = CardResources.Knowledge, Value = -ResourceKnowledge.Value });
            if (ResourceMana.HasValue)
                abilityResources.Add(new Resource() { ResourceType = CardResources.Mana, Value = -ResourceMana.Value });
            if (ResourceWild.HasValue)
                abilityResources.Add(new Resource() { ResourceType = CardResources.Wild, Value = -ResourceWild.Value });
            if (ResourceNeutral.HasValue)
                abilityResources.Add(new Resource() { ResourceType = CardResources.Neutral, Value = -ResourceNeutral.Value });

            //Order the resources by their largest value
            abilityResources = abilityResources.OrderBy(x => x.Value).ToList();

            return abilityResources;
        }
    }
}
