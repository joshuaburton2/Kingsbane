using CategoryEnums;
using System;

[Serializable]
public class PlayerResource : Resource
{
    public TierLevel TierLevel { get; set; }

    /// <summary>
    /// 
    /// Sets a new tier level for the player resource
    /// 
    /// </summary>
    public virtual void SetTierLevel(TierLevel tierLevel)
    {
        TierLevel = tierLevel;
    }

    /// <summary>
    /// 
    /// Initialise the Player Resource Object. To be called in the subclasses of this object
    /// 
    /// </summary>
    protected void InitPlayerResource(CardResources resourceType)
    {
        SetTierLevel(TierLevel);
        ResourceType = resourceType;
    }

    /// <summary>
    /// 
    /// Function to be called in player resource subclasses to copy common values between the different player resource types
    /// 
    /// </summary>
    protected void CopyCommonResourceValues(PlayerResource playerResource)
    {
        Value = playerResource.Value;
        ResourceType = playerResource.ResourceType;
        TierLevel = playerResource.TierLevel;
    }
}
