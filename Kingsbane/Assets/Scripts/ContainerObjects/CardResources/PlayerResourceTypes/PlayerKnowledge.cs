using CategoryEnums;
using UnityEngine;
using System;
using System.Linq;

[Serializable]

public class PlayerKnowledge : PlayerResource
{
    private readonly int[] BASE_KNOWLEDGE_GAINS = new int[] { 2, 3, 4 };
    public readonly int IGNORANCE_THRESHOLD = 3;
    private readonly int STAGNATION_MODIFIER = 1;

    public int BaseKnowledgeGain { get; set; }
    public int Stagnation { get; set; }
    public int Ignorance { get { return  (int)Mathf.Floor(Stagnation / IGNORANCE_THRESHOLD); } }
    public int ExcessStagnation { get { return Stagnation % IGNORANCE_THRESHOLD; } }

    public PlayerKnowledge()
    {
        InitPlayerResource(CardResources.Knowledge);
        Stagnation = 0;
        ResetValue();
    }

    public PlayerKnowledge(int baseKnowledgeGain, int stagnation)
    {
        ResourceType = CardResources.Knowledge;
        BaseKnowledgeGain = baseKnowledgeGain;
        Stagnation = stagnation;
        ResetValue();
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
    /// Resets the value to 0. To be called at the start of each scenario
    /// 
    /// </summary>
    public void ResetValue()
    {
        Value = 0;
    }

    /// <summary>
    /// 
    /// Refresh Knowledge to its base amount. Should be called at the start of the player's turn
    /// 
    /// </summary>
    public void RefreshValue()
    {
        Value = BaseKnowledgeGain;
    }

    /// <summary>
    /// 
    /// Functionality for triggering a study effect
    /// 
    /// </summary>
    /// <param name="cardClass">The class of the card triggering the study effect. Used to identify which inspiration card to shuffle</param>
    public void TriggerStudy(int studyVal, Classes.ClassList cardClass)
    {
        var inspirationCards = GameManager.instance.libraryManager.GetDictionaryList(Tags.Inspiration, new CardFilter(false));
        var classCards = GameManager.instance.libraryManager.GetDictionaryList(cardClass, new CardFilter(false));
        //Finds the required inpiration card
        var inspirationCardData = inspirationCards.Intersect(classCards).FirstOrDefault();

        //Shuffles the required number of inspiration cards into the deck. ALso subtracts the Ignorance value from the number of cards shuffled
        for (int i = 0; i < studyVal - Ignorance; i++)
        {
            var inspirationCard = GameManager.instance.libraryManager.CreateCard(inspirationCardData, Player());
            Player().Deck.ShuffleIntoDeck(inspirationCard);
        }

        //Modifies the players Stagnation each time they activate a Study effect
        ModifyStagnation(STAGNATION_MODIFIER);
    }

    /// <summary>
    /// 
    /// Update the players Knowledge base gain. 
    /// 
    /// </summary>
    public void UpdateBaseGain(int gainIncrease)
    {
        BaseKnowledgeGain += gainIncrease;
    }

    /// <summary>
    /// 
    /// Reduces the player's stagnation by a given amount
    /// 
    /// </summary>
    public void ModifyStagnation(int modifier)
    {
        Stagnation = Mathf.Max(0, Stagnation + modifier);
    }

    /// <summary>
    /// 
    /// Reduces the player's Ignorance by 1 level. Should only be called through upgrades
    /// 
    /// </summary>
    public void ReduceIgnorance()
    {
        //Makes sure to have a lower bound on stagnation to prevent it from being negative
        Stagnation =  Mathf.Max(0, Stagnation - IGNORANCE_THRESHOLD);
    }

    /// <summary>
    /// 
    /// Start of game update for knowledge
    /// 
    /// </summary>
    public override void StartOfGameUpdate(int playerId)
    {
        base.StartOfGameUpdate(playerId);

        ResetValue();
    }

    /// <summary>
    /// 
    /// Start of turn update for knowledge
    /// 
    /// </summary>
    public override void StartOfTurnUpdate()
    {
        RefreshValue();
    }
}