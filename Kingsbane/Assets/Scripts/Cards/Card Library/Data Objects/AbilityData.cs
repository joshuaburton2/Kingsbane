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
    public List<Resource> Resources { get; set; }
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
            var abilityResources = Resources.ToList();

            foreach (var resource in abilityResources)
            {
                resource.Value *= -1;
            }

            //Order the resources by their largest value
            abilityResources = abilityResources.OrderBy(x => x.Value).ToList();

            return abilityResources;
        }
    }
}
