using CategoryEnums;
using UnityEngine;
using System;

[Serializable]

public class PlayerKnowledge : PlayerResource
{
    private readonly int[] BASE_KNOWLEDGE_GAINS = new int[] { 2, 3, 4 };
    public readonly int IGNORANCE_THRESHOLD = 3;

    public int BaseKnowledgeGain { get; set; }
    public int Stagnation { get; set; }
    public int Ignorance { get { return  (int)Mathf.Floor(Stagnation / IGNORANCE_THRESHOLD); } }
    public int ExcessStagnation { get { return Stagnation % IGNORANCE_THRESHOLD; } }

    public PlayerKnowledge()
    {
        InitPlayerResource(CardResources.Knowledge);
        Stagnation = 0;
    }

    public PlayerKnowledge(int baseKnowledgeGain, int stagnation)
    {
        ResourceType = CardResources.Knowledge;
        BaseKnowledgeGain = baseKnowledgeGain;
        Stagnation = stagnation;
    }

    /// <summary>
    /// 
    /// Constructor for copying player resource information
    /// 
    /// </summary>
    public PlayerKnowledge(PlayerKnowledge playerKnowledge)
    {
        CopyCommonResourceValues(playerKnowledge);
        BaseKnowledgeGain = playerKnowledge.BaseKnowledgeGain;
        Stagnation = playerKnowledge.Stagnation;
    }

    /// <summary>
    /// 
    /// Sets the tier level of the player resource
    /// 
    /// </summary>
    public override void SetTierLevel(TierLevel tierLevel)
    {
        base.SetTierLevel(tierLevel);
        BaseKnowledgeGain = BASE_KNOWLEDGE_GAINS[(int)tierLevel];
    }

    /// <summary>
    /// 
    /// Refresh Knowledge to its base amount. Should be called at the start of the player's turn
    /// 
    /// </summary>
    public int RefreshValue()
    {
        Value = BaseKnowledgeGain;
        return Value;
    }

    /// <summary>
    /// 
    /// Update the players Knowledge base gain. 
    /// 
    /// </summary>
    public int UpdateBaseGain(int gainIncrease)
    {
        BaseKnowledgeGain += gainIncrease;
        return BaseKnowledgeGain;
    }

    /// <summary>
    /// 
    /// Reduces the player's Ignorance by 1 level
    /// 
    /// </summary>
    public int ReduceIgnorance()
    {
        //Makes sure to have a lower bound on stagnation to prevent it from being negative
        return Stagnation =  Mathf.Max(0, Stagnation - IGNORANCE_THRESHOLD);
    }
}