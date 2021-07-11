
using System.Collections.Generic;
using System.Linq;
using CategoryEnums;
using Helpers;

public class Ability
{
    public AbilityData AbilityData { get; set; }
    public Unit Unit { get; set; }

    public int Id { get { return AbilityData.Id; } }
    public string Name { get { return AbilityData.Name; } }
    public string Text { get { return AbilityData.Text; } }
    public bool CostsAction { get { return AbilityData.CostsAction; } }
    public int Range { get { return AbilityData.Range; } }

    public List<Resource> DefaultCost { get { return AbilityData.GetResources; } }
    public List<Resource> ResourceCost { get; set; }
    public List<CardResources> Resources { get; set; }
    public bool ResourcesConverted { get; set; }

    public Ability(AbilityData abilityData, Unit unit)
    {
        AbilityData = abilityData;
        Unit = unit;
        ResourceInit();
    }

    /// <summary>
    /// 
    /// The total resource cost of the card
    /// 
    /// </summary>
    public int TotalResource
    {
        get
        {
            int totalResource = 0;
            //Certain cards (namely heroes) may not have a resource cost, so this needs to return a count of 0
            if (ResourceCost.Count != 0)
            {
                totalResource = ResourceCost.Sum(x => x.Value);
            }

            return totalResource;
        }
    }

    /// <summary>
    /// 
    /// Initialises the Resource Data on the ability. To be called when the ability is created
    /// 
    /// </summary>
    private void ResourceInit()
    {
        if (!ResourcesConverted)
        {
            ResourceCost = new List<Resource>();
            Resources = new List<CardResources>();
            foreach (var resource in DefaultCost)
            {
                ResourceCost.Add(new Resource(resource));
                Resources.Add(resource.ResourceType);
            }
        }
        else
        {
            var convertedResource = Resources.FirstOrDefault();
            ConvertResource(convertedResource);
        }
    }

    /// <summary>
    /// 
    /// Converts the resource cost to a different resource
    /// 
    /// </summary>
    public void ConvertResource(CardResources newResource)
    {
        //Required for hero cards, as these cannot be resource converted
        if (ResourceCost.Count != 0)
        {
            ResourceCost = new List<Resource>() { new Resource(newResource, TotalResource) };
            Resources = new List<CardResources> { newResource };
            ResourcesConverted = true;
        }
    }

    /// <summary>
    /// 
    /// Generates the ability text to display to the player
    /// 
    /// </summary>
    /// <param name="includeName">True if including the abilities name, false otherwise</param>
    public string AbilityText(bool includeName = true)
    {
        var nameText = includeName ? $"{Name} " : "";
        var resourceText = StringHelpers.GenerateResourceText(ResourceCost);
        var commaText = resourceText.Length == 0 ? "" : ", "; //For handling in case the ability just costs an action, in which case doesn't need a comma
        var actionText = CostsAction ? $"{commaText}1 Action" : "";

        return $"<b>{nameText}({resourceText}{actionText}):</b> {Text}";
    }
}

