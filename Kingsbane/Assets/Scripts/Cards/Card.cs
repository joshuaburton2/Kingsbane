using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using UnityEngine;

public class Card
{
    public CardData cardData;

    public int Id { get { return cardData.Id.Value; } }
    public string Name { get { return cardData.Name; } }

    public Rarity Rarity { get { return cardData.Rarity; } }
    public CardTypes Type { get { return cardData.CardType; } }
    public Classes.ClassList CardClass { get { return cardData.Class; } }
    public Sets Set { get { return cardData.Set; } }

    public Sprite CardArt { get; set; }
    public CardImageTags ImageTag { get { return cardData.ImageTag; } }

    public List<Tags> Tags { get { return cardData.Tags; } }
    public List<Synergies> Syngergies { get { return cardData.Synergies; } }
    public List<CardData> RelatedCards { get { return cardData.RelatedCards; } }

    public Player Owner { get; set; }

    //The resource cost of the card. Default cost is the base cost without modifications based on the cards played in a game.
    //The resource cost is the cost of the card with modifications which may arise during a game.
    //The resource cost should always be set to the default cost at the start of each game.
    public List<Resource> DefaultCost { get { return cardData.GetResources; } }
    public List<Resource> ResourceCost { get; private set; }
    public List<CardResources> Resources { get; private set; }

    public string Text { get { return cardData.Text; } }
    public string LoreText { get { return cardData.LoreText; } }
    public string Notes { get { return cardData.Notes; } }

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
            if (ResourceCost.Count != 0)
            {
                totalResource = ResourceCost.Sum(x => x.Value);
            }
            else
            {
                if (Rarity == Rarity.Hero)
                {
                    //Only hero cards should have no cost. Subtrats from 3 since this means that the highest tier level is ordered last
                    totalResource = 3 - (int)((UnitData)cardData).GetHeroTier();
                }
                else if (Rarity == Rarity.NPCHero)
                {
                    totalResource = 1;
                }
                else
                {
                    throw new Exception($"Card {Name} is not a hero");
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
            if (ResourceCost.Count != 0)
            {
                // Note that Min is used since resources on a card are negative values
                highestResource = ResourceCost.Min(x => x.Value);
            }
            else
            {
                if (Rarity == Rarity.Hero)
                {
                    //Only hero cards should have no cost. Subtrats from 3 since this means that the highest tier level is ordered last
                    highestResource = 3 - (int)((UnitData)cardData).GetHeroTier();
                }
                else if (Rarity == Rarity.NPCHero)
                {
                    highestResource = 1;
                }
                else
                {
                    throw new Exception($"Card {Name} is not a hero");
                }
            }

            return highestResource;
        }
    }

    public virtual void InitCard (CardData _cardData, Player owner)
    {
        cardData = _cardData;
        Owner = owner;
        CardArt = GameManager.instance.imageManager.GetCardImage(ImageTag, CardClass);
        ResourceInit();
    }

    /// <summary>
    /// 
    /// Initialises the Resource Data on the card. To be called when the card is created
    /// 
    /// </summary>
    private void ResourceInit()
    {
        ResourceCost = new List<Resource>();
        Resources = new List<CardResources>();
        foreach (var resource in DefaultCost)
        {
            ResourceCost.Add(new Resource(resource));
            Resources.Add(resource.ResourceType);
        }
    }

    /// <summary>
    /// 
    /// Tests if a card is playable based on the player's current resources
    /// 
    /// IMPORTANT: Can be reworked to integrate Resources in Player and Card class
    /// 
    /// </summary>
    /// <returns>True if the card can be played. False otherwise</returns>
    public bool IsPlayable()
    {
        return Resource.CanSpendResources(Owner, ResourceCost);
    }

    public virtual void Play()
    {
        Owner.ModifyResources(ResourceCost);

        Owner.PlayFromHand(this);

        //ToDo: Might need to pass out an on play parameter. This will determine the effect of spells as well as deployment effects for units and items
    }

    public void Discard()
    {
        Owner.DiscardFromHand(this);
    }
}
