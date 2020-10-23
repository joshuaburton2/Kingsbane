using CategoryEnums;
using System;

/// <summary>
/// 
/// Object for storing resource data
/// 
/// </summary>
[Serializable]
public class Resource
{
    public CardResources ResourceType { get; set; }
    public int Value { get; set; } //To add Protected clause to Set

    public Resource()
    {
        ResourceType = CardResources.Neutral;
        Value = 0;
    }

    public Resource(CardResources resourceType, int value)
    {
        ResourceType = resourceType;
        Value = value;
    }

    /// <summary>
    /// 
    /// Copy a resource from one object to another
    /// 
    /// </summary>
    /// <param name="resource"></param>
    public Resource(Resource resource)
    {
        ResourceType = resource.ResourceType;
        Value = resource.Value;
    }

    /// <summary>
    /// 
    /// Calculate the new resource value if a given change is applied to it
    /// 
    /// </summary>
    public int CalcNewValue(int valueChange)
    {
        return Value + valueChange;
    }

    /// <summary>
    /// 
    /// Modify the value of the resource
    /// 
    /// </summary>
    public virtual int ModifyValue(int valueChange)
    {
        Value = CalcNewValue(valueChange);
        return Value;
    }


}
