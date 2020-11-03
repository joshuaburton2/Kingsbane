using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 
/// Object for storing data about each card in the game
/// 
/// </summary>
public class CardData
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string ImageLocation { get; set; }

    public List<Resource> Resources { get; set; }

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

    public bool IsHero { get { return Rarity == Rarity.Hero || Rarity == Rarity.NPCHero; } }

    /// <summary>
    /// 
    /// Default Constructor. Cards should not have an Id of negative 1 so this is a good test to see if a card should exist or not.
    /// 
    /// </summary>
    public CardData()
    {
        Id = null;
    }

    /// <summary>
    /// 
    /// Constructor for copying card data. Should rarely be used as card data should almost always be drawn directly from CardLibary.cs
    /// 
    /// </summary>
    public CardData(CardData cardData)
    {
        Id = cardData.Id;
        Name = cardData.Name;
        ImageLocation = cardData.ImageLocation;

        Resources = cardData.Resources.ToList();

        Text = cardData.Text;
        LoreText = cardData.LoreText;
        Notes = cardData.Notes;

        Set = cardData.Set;
        Class = cardData.Class;
        Rarity = cardData.Rarity;
        CardType = cardData.CardType;

        Tags = cardData.Tags;
        Synergies = cardData.Synergies;
        RelatedCards = cardData.RelatedCards;
    }

    /// <summary>
    /// 
    /// Fetches the card resources as a list. Note that Value is forced to be negative for Cards as they reduce the players resources when they are played
    /// 
    /// </summary>
    public List<Resource> GetResources 
    {
        get
        {
            var cardResources = new List<Resource>();

            foreach (var resource in Resources)
            {
                cardResources.Add(new Resource(resource.ResourceType, -resource.Value));
            }

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
                if (Rarity == Rarity.Hero)
                {
                    //Only hero cards should have no cost. Subtrats from 3 since this means that the highest tier level is ordered last
                    totalResource = 3 - (int)((UnitData)this).GetHeroTier();
                }
                else if(Rarity == Rarity.NPCHero)
                {
                    totalResource = 1;
                }
                else
                {
                    throw new Exception("Card is not a hero");
                }
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
                if (Rarity == Rarity.Hero)
                {
                    //Only hero cards should have no cost. Subtrats from 3 since this means that the highest tier level is ordered last
                    highestResource = 3 - (int)((UnitData)this).GetHeroTier();
                }
                else if (Rarity == Rarity.NPCHero)
                {
                    highestResource = 1;
                }
                else
                {
                    throw new Exception("Card is not a hero");
                }
            }

            return highestResource;
        }
    }


}
