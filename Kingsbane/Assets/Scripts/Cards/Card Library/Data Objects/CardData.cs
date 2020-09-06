using Assets.Scripts.Category_Enums;
using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class CardData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageLocation { get; set; }

    public int? ResourceDevotion { get; set; }
    public int? ResourceEnergy { get; set; }
    public int? ResourceGold { get; set; }
    public int? ResourceKnowledge { get; set; }
    public int? ResourceMana { get; set; }
    public int? ResourceWild { get; set; }
    public int? ResourceNeutral { get; set; }

    public string Text { get; set; }
    public string LoreText { get; set; }
    public string Notes { get; set; }

    public Sets Set { get; set; }
    public Classes.ClassList Class { get; set; }
    public Rarity Rarity { get; set; }
    public CardTypes CardType { get; set; }

    public List<Tags> Tags { get; set; }
    public List<Synergies> Synergies { get; set; }
    public List<CardData> RelatedCards { get; set; }

    /// <summary>
    /// 
    /// Fetches the card resources as a list. Note that Value is forced to be negative for Cards as they reduce the players resources when they are played
    /// 
    /// </summary>
    public List<Resource> GetResources 
    {
        get
        {
            List<Resource> cardResources = new List<Resource>();

            if(ResourceDevotion.HasValue)
                cardResources.Add(new Resource() { ResourceType = CardResources.Devotion, Value = - ResourceDevotion.Value });
            if (ResourceEnergy.HasValue)
                cardResources.Add(new Resource() { ResourceType = CardResources.Energy, Value = - ResourceEnergy.Value });
            if (ResourceGold.HasValue)
                cardResources.Add(new Resource() { ResourceType = CardResources.Gold, Value = - ResourceGold.Value });
            if (ResourceKnowledge.HasValue)
                cardResources.Add(new Resource() { ResourceType = CardResources.Knowledge, Value = - ResourceKnowledge.Value });
            if (ResourceMana.HasValue)
                cardResources.Add(new Resource() { ResourceType = CardResources.Mana, Value = - ResourceMana.Value });
            if (ResourceWild.HasValue)
                cardResources.Add(new Resource() { ResourceType = CardResources.Wild, Value = - ResourceWild.Value });
            if (ResourceNeutral.HasValue)
                cardResources.Add(new Resource() { ResourceType = CardResources.Neutral, Value = - ResourceNeutral.Value });

            //Order the resources by their largest value
            cardResources = cardResources.OrderBy(x => x.Value).ToList();

            return cardResources;
        }
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
            int totalResource;
            //Certain cards (namely heroes) may not have a resource cost, so this needs to return a count of 0
            if (GetResources.Count != 0)
            {
                totalResource = GetResources.Sum(x => x.Value);
            }
            else
            {
                totalResource = 0;
            }
             

            return totalResource;
        }
    }

    /// <summary>
    /// 
    /// Gets the highest resource value of the class on the card
    /// 
    /// </summary>
    public int HighestResource
    {
        get
        {
            int highestResource;
            if (GetResources.Count != 0)
            {
                // Note that Min is used since resources on a card are negative values
                highestResource = GetResources.Min(x => x.Value);
            }
            else
            {
                //Only hero cards should have no cost. Subtrats from 3 since this means that the highest tier level is ordered last
                highestResource = 3 - (int)GetHeroTier();
            }

            return highestResource;
        }
    }

    public TierLevel GetHeroTier()
    {
        return HeroTier.ConvertTierLevel(this);
    }
}
