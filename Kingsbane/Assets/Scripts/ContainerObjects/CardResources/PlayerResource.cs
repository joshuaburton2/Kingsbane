using CategoryEnums;
using System;

[Serializable]
public class PlayerResource : Resource
{
    public TierLevel TierLevel { get; set; }
    public Player Player { get; set; }

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

    /// <summary>
    /// 
    /// Function to be called at the start of the game for each player for each of their resources. Also inserts the player object at the start of the game
    /// 
    /// </summary>
    public virtual void StartOfGameUpdate(Player player)
    {
        Player = player;
    }

    /// <summary>
    /// 
    /// Function to be called at the start of each players turn for each of their resources. Function here should be empty,
    /// and only certain resources are required to utilise it
    /// 
    /// </summary>
    public virtual void StartOfTurnUpdate()
    {

    }
}
