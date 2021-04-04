using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using UnityEngine;

public class Card
{
    public CardData CardData { get; set; }

    public int Id { get { return CardData.Id.Value; } }
    public string Name { get { return CardData.Name; } }

    public Rarity Rarity { get { return CardData.Rarity; } }
    public CardTypes Type { get { return CardData.CardType; } }
    public Classes.ClassList CardClass { get { return CardData.Class; } }
    public Sets Set { get { return CardData.Set; } }

    public Sprite CardArt { get; set; }
    public CardImageTags ImageTag { get { return CardData.ImageTag; } }

    public List<Tags> Tags { get { return CardData.Tags; } }
    public List<Synergies> Syngergies { get { return CardData.Synergies; } }
    public List<CardData> RelatedCards { get { return CardData.RelatedCards; } }

    public Player Owner { get; set; }

    //The resource cost of the card. Default cost is the base cost without modifications based on the cards played in a game.
    //The resource cost is the cost of the card with modifications which may arise during a game.
    //The resource cost should always be set to the default cost at the start of each game.
    public List<Resource> DefaultCost { get { return CardData.GetResources; } }
    public List<Resource> ResourceCost { get; private set; }
    public List<CardResources> Resources { get; private set; }
    public bool ResourcesConverted { get; set; }

    public bool IsSpymasterLuren { get; set; }


    public string Text { get { return CardData.Text; } }
    public string LoreText { get { return CardData.LoreText; } }
    public string Notes { get { return CardData.Notes; } }

    public string CreatedByName { get; set; }

    public int NumShuffles { get; set; }

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
                    totalResource = 3 - (int)((UnitData)CardData).GetHeroTier();
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
                    highestResource = 3 - (int)((UnitData)CardData).GetHeroTier();
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

    public virtual void InitCard(CardData _cardData, Player owner)
    {
        CardData = _cardData;
        Owner = owner;
        CardArt = GameManager.instance.imageManager.GetCardImage(ImageTag, CardClass);
        CreatedByName = "";
        NumShuffles = 0;
        ResourcesConverted = false;
        IsSpymasterLuren = false;
        ResourceInit();
    }

    /// <summary>
    /// 
    /// Initialises the Resource Data on the card. To be called when the card is created
    /// 
    /// </summary>
    public void ResourceInit()
    {
        if (!ResourcesConverted || ResourceCost.Count == 0)
        {
            ResourceCost = new List<Resource>();
            Resources = new List<CardResources>();
            foreach (var resource in DefaultCost)
            {
                ResourceCost.Add(new Resource(resource));
                Resources.Add(resource.ResourceType);
            }
        }
        else
        {
            var convertedResource = Resources.FirstOrDefault();
            ResourceConvert(convertedResource);
        }
    }

    public virtual void ResourceConvert(CardResources newResource)
    {
        if (ResourceCost.Count != 0)
        {
            ResourceCost = new List<Resource>() { new Resource(newResource, TotalResource) };
            Resources = new List<CardResources> { newResource };
            ResourcesConverted = true;
        }
    }

    public List<string> GetResourceColours()
    {
        var colourList = new List<string>();

        foreach (var resource in Resources)
        {
            var status = GetResourceStatus(resource);
            colourList.Add(GameManager.instance.colourManager.GetStatModColour(status, true).ConvertToHexadecimal());
        }
        return colourList;
    }

    /// <summary>
    /// 
    /// Gets the status of a particular resource- i.e. whether it is increase, decreased or not changed 
    /// 
    /// </summary>
    private StatisticStatuses GetResourceStatus(CardResources resource)
    {
        if (ResourcesConverted)
            return StatisticStatuses.Converted;

        var currentCost = ResourceCost.Single(x => x.ResourceType == resource).Value;
        var defaultCost = DefaultCost.Single(x => x.ResourceType == resource).Value;

        //Note that the signs are flipped as cost is always negative
        if (currentCost > defaultCost)
            return StatisticStatuses.Buffed;
        else if (currentCost < defaultCost)
            return StatisticStatuses.Debuffed;
        else
            return StatisticStatuses.None;
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

        ResourceInit();
        Owner.PlayFromHand(this);

        if (IsSpymasterLuren)
        {
            IsSpymasterLuren = false;
            GameManager.instance.effectManager.ReturnLurenCards();
        }

        //ToDo: Might need to pass out an on play parameter. This will determine the effect of spells as well as deployment effects for units and items
    }

    public void Discard()
    {
        Owner.DiscardFromHand(this);
    }

    public void Shuffle()
    {
        Owner.ShuffleFromHand(this);
    }

    public void ShuffleThenDraw()
    {
        Owner.ShuffleFromHand(this);
        Owner.Draw(this);
    }

    public bool ModifyCost(int value, CardResources? resource)
    {
        if (resource.HasValue)
        {
            if (!Resources.Contains(resource.Value))
                return false;

            ResourceCost.Single(x => x.ResourceType == resource).ModifyValue(-value, true);
        }
        else
        {
            if (Resources.Count == 1)
            {
                ResourceCost.FirstOrDefault().ModifyValue(-value, true);
            }
            else
            {
                bool isOdd = false;
                if (value % 2 == 1)
                {
                    value -= 1;
                    isOdd = true;
                }
                else if (value % 2 == -1)
                {
                    value += 1;
                    isOdd = true;
                }

                value /= Resources.Count;
                ResourceCost.ForEach(x => x.ModifyValue(-value, true));

                if (isOdd)
                {
                    var highestResources = ResourceCost.Where(x => x.Value == ResourceCost.Min(y => y.Value)).ToList();
                    var valueModifier = value > 0 ? -1 : 1;
                    if (highestResources.Count() == 1)
                    {
                        highestResources.FirstOrDefault().ModifyValue(valueModifier, true);
                    }
                    else
                    {
                        var randomResource = UnityEngine.Random.Range(0, highestResources.Count());
                        highestResources[randomResource].ModifyValue(valueModifier, true);
                    }
                }
            }
        }

        return true;
    }

    public virtual void CopyCardStats(Card copyFrom)
    {
        foreach (var resource in ResourceCost)
        {
            var copyResource = copyFrom.ResourceCost.Single(x => x.ResourceType == resource.ResourceType);
            resource.Value = copyResource.Value;
        }
    }
}
