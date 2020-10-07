using CategoryEnums;

/// <summary>
/// 
/// Object for storing resource data
/// 
/// </summary>
public class Resource
{
    public CardResources ResourceType { get; set; }
    public int Value { get; set; }

    public Resource()
    {
        ResourceType = CardResources.Neutral;
        Value = 0;
    }

    public Resource(Resource resource)
    {
        ResourceType = resource.ResourceType;
        Value = resource.Value;
    }
}
