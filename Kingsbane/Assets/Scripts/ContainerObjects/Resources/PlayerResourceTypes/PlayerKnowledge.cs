using CategoryEnums;
using UnityEngine;

public class PlayerKnowledge : PlayerResource
{
    private const int DEFAULT_BASE_KNOWLEDGE = 2;
    private const int IGNORANCE_THRESHOLD = 3;

    public int BaseKnowledgeGain { get; set; }
    public int Stagnation { get; set; }
    public int Ignorance { get { return  (int)Mathf.Floor(Stagnation / IGNORANCE_THRESHOLD); } }
    public int ExcessStagnation { get { return Stagnation % IGNORANCE_THRESHOLD; } }

    public PlayerKnowledge()
    {
        ResourceType = CardResources.Knowledge;
        BaseKnowledgeGain = DEFAULT_BASE_KNOWLEDGE;
        Stagnation = 0;
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
    /// <returns></returns>
    public int ReduceIgnorance()
    {
        return Stagnation -= IGNORANCE_THRESHOLD;
    }
}