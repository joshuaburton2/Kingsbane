using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using UnityEngine;

public class Card
{
    public CardData cardData;

    public int Id { get { return cardData.Id.Value; } }
    public string CardName { get { return cardData.Name; } }

    public Rarity Rarity { get { return cardData.Rarity; } }
    public CardTypes Type { get { return cardData.CardType; } }
    public Classes.ClassList CardClass { get { return cardData.Class; } }
    public Sets Set { get { return cardData.Set; } }

    public Sprite cardArt;
    private string ImageLocation { get { return cardData.ImageLocation; } }

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

    public virtual void InitCard (CardData _cardData, Player owner)
    {
        cardData = _cardData;
        Owner = owner;
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
        var playerResources = Owner.Resources;

        //The resource differences will be the difference between the player's current resources and their mandatory spending
        //of their resources based on the cost of the card
        var resourceDifferences = new List<Resource>();

        foreach (var resource in ResourceCost)
        {
            //Tests if the current resource is not a neutral cost
            if (resource.ResourceType != CardResources.Neutral)
            {
                //Calculate the resource difference
                var resourceDif = Owner.CalcNewResource(resource);
                resourceDifferences.Add(resourceDif);

                //If the difference between the cost of a card and the player's resource is less than 0, this means the card cannot be played
                if (resourceDif.Value < 0)
                {
                    return false;
                }
            }
            //Case for if the card has a neutral cost
            else
            {

                //Loops through all the resource difference values. Note that this will be filled since Neutral Resource is the last resource checked
                foreach (var resourceDifference in resourceDifferences)
                {
                    //If the player has enough resources remaining after spending the mandatory cost of the card, they can play
                    //the card
                    if (resourceDifference.Value - ResourceCost.First(x => x.ResourceType == resourceDifference.ResourceType).Value > 0)
                    {
                        return true;
                    }
                }

                //If none of the player's resources have the neutral cost remaining after spending the mandatory cost of the card, returns false
                return false;
            }
        }

        //Default outcome of the function. This will also return true if the card has no cost associated with it
        return true;
    }

    public virtual void Play()
    {
        foreach (var resource in ResourceCost)
        {
            //Owner.ModifyResources(resource);  //To Fix
        }
    }
}
