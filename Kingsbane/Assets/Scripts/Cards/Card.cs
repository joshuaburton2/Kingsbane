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
    public bool IsHero { get { return CardData.IsHero; } }
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
    public List<AdjustCostObject> CostAdjustments { get; set; }
    public List<CardResources> Resources { get; private set; }
    public CardResources? ResourceConvertedTo { get; set; }

    public Unit SpymasterLurenSource { get; set; }
    public Card SpyMasterLurenCard { get; set; }


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

    /// <summary>
    /// 
    /// Initialise the card on being created
    /// 
    /// </summary>
    /// <param name="_cardData"></param>
    /// <param name="owner"></param>
    public virtual void InitCard(CardData _cardData, Player owner)
    {
        CardData = _cardData;
        Owner = owner;
        //Gets the card art, with NPC Hero images being pulled from a different function to regular cards
        if (CardData.Rarity != Rarity.NPCHero)
            CardArt = GameManager.instance.imageManager.GetCardImage(ImageTag, CardClass);
        else
            CardArt = GameManager.instance.imageManager.GetNPCHeroImage(ImageTag);
        CreatedByName = "";
        NumShuffles = 0;
        SpyMasterLurenCard = null;
        ResourceInit(true);

        //Add passive cost modifications
        if (GameManager.instance.CurrentGamePhase != GameManager.GamePhases.Menu)
        {
            if (Owner != null)
            {
                foreach (var passive in Owner.Passives)
                {
                    if (passive.CostAdjustment != null)
                        if (passive.PassiveApplies(this))
                            ModifyCost(passive.CostAdjustment);
                }
            }

            RecalculateCost();
        }
    }

    /// <summary>
    /// 
    /// Initialises the Resource Data on the card. To be called when the card is created
    /// 
    /// </summary>
    public void ResourceInit(bool fullReset = false)
    {
        if (fullReset)
        {
            //Reset the cost adjustment object
            CostAdjustments = new List<AdjustCostObject>();
        }

        //If there is no converted resource or if there is no resource cost (for example hero cards)
        if (!ResourceConvertedTo.HasValue || ResourceCost.Count == 0)
        {
            //Initialise the resources on the card based on the base resources of the card data
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
            //If there is a converted resource, forces the coversion back to the total resource of the card
            //This is required to allow for converted cards returning to hand or being added to graveyard still using the converted resource
            ResourceCost.FirstOrDefault().SetValue(CardData.TotalResource);
            ResourceConvert(ResourceConvertedTo.Value);
        }
    }

    /// <summary>
    /// 
    /// Convert the card to a new resource cost
    /// 
    /// </summary>
    public virtual void ResourceConvert(CardResources newResource)
    {
        //This is required for mind control cards or recruit effects as examples. This allows for these cards to be played/used by the new owners

        //Cannot convert resource of cards which have no resource cost (i.e. hero cards)
        if (ResourceCost.Count != 0)
        {
            ResourceCost = new List<Resource>() { new Resource(newResource, TotalResource) };
            Resources = new List<CardResources> { newResource };
            ResourceConvertedTo = newResource;
        }
    }

    /// <summary>
    /// 
    /// Get a list of hexadecimal colour strings based on the status of each resource on the card
    /// 
    /// </summary>
    public List<string> GetResourceColours()
    {
        var colourList = new List<string>();

        foreach (var resource in Resources)
        {
            //Converts the status and converts it to hexadecimal string, adding it to the list
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
        //Converted resources have their own colour, regardless of whether they are buffed or debuffed
        if (ResourceConvertedTo.HasValue)
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
    /// 
    /// </summary>
    /// <returns>True if the card can be played. False otherwise</returns>
    public bool IsPlayable()
    {
        return Resource.CanSpendResources(Owner, ResourceCost);
    }

    /// <summary>
    /// 
    /// Play the card from hand
    /// 
    /// </summary>
    public virtual void Play()
    {
        //If this card has been recruited by Spymaster Luren, returns the other cards recruited by him. 
        if (SpyMasterLurenCard != null)
        {
            //Removes the Luren card from this card, as it is removed when this is played (this card is the original copy of the card which was recruited)
            SpyMasterLurenCard = null;
            GameManager.instance.effectManager.ReturnLurenCards(playedCard: this);
        }

        //Reduces the owners resources by the current cost of the card
        Owner.ModifyResources(ResourceCost);

        //Initialises the resources on this card, as any cost 
        ResourceInit(true);
        Owner.PlayFromHand(this);

        //ToDo: Might need to pass out an on play parameter. This will determine the effect of spells as well as deployment effects for units and items
    }

    /// <summary>
    /// 
    /// Discard this card from the owners hand
    /// 
    /// </summary>
    public void Discard()
    {
        Owner.DiscardFromHand(this);
    }

    /// <summary>
    /// 
    /// Shuffle this card into the owners deck
    /// 
    /// </summary>
    public void Shuffle()
    {
        Owner.ShuffleFromHand(this);
    }

    /// <summary>
    /// 
    /// Shuffle this card into owners deck, then draw the same card
    /// 
    /// </summary>
    public void ShuffleThenDraw()
    {
        Owner.ShuffleFromHand(this);
        Owner.Draw(this);
    }

    /// <summary>
    /// 
    /// Modifies the cost of the card
    /// 
    /// </summary>
    public bool ModifyCost(AdjustCostObject adjustCostObject)
    {
        CostAdjustments.Add(adjustCostObject);

        return RecalculateCost();
    }

    /// <summary>
    /// 
    /// Recalculates the cost of the card
    /// 
    /// </summary>
    /// <returns>False if the card can not be modifies by a given cost adjustment</returns>
    public bool RecalculateCost()
    {
        //Resets the resources to the cards base. Required as each cost adjustment is applied again
        ResourceInit();

        foreach (var adjustCostObject in CostAdjustments)
        {
            //If there is a must be greater than cap on the adjustment (i.e the total cost of the card, must be larger than the cap in order for the cost to be adjusted)
            //and the total cost of the card is already greater than (less than due to negative), then does not adjust the cost
            if (!adjustCostObject.MustBeGreaterThan.HasValue || adjustCostObject.MustBeGreaterThan.HasValue && TotalResource < -adjustCostObject.MustBeGreaterThan.Value)
            {
                //Case if there is a specific resource target to be adjusted
                if (adjustCostObject.TargetResource.HasValue)
                {
                    //If the card does not contain the resource targeted by the adjustment, then exits the function
                    if (!Resources.Contains(adjustCostObject.TargetResource.Value))
                        return false;

                    //Gets the resource to be adjusted
                    var resourceCost = ResourceCost.Single(x => x.ResourceType == adjustCostObject.TargetResource);

                    switch (adjustCostObject.AdjustmentType)
                    {
                        //Modify or set the cost of the target resource
                        case StatModifierTypes.Modify:
                            resourceCost.ModifyValue(-adjustCostObject.Value, adjustCostObject.MinCost.HasValue, -adjustCostObject.MinCost);
                            break;
                        case StatModifierTypes.Set:
                            resourceCost.SetValue(-adjustCostObject.Value);
                            break;
                        default:
                            throw new Exception("Not a valid stat mod type");
                    }
                }
                else
                {
                    //Loop through each resource, and adjust the cost by the given adjustment value
                    foreach (var resourceCost in ResourceCost)
                    {
                        switch (adjustCostObject.AdjustmentType)
                        {
                            case StatModifierTypes.Modify:
                                resourceCost.ModifyValue(-adjustCostObject.Value, adjustCostObject.MinCost.HasValue, -adjustCostObject.MinCost);
                                break;
                            case StatModifierTypes.Set:
                                resourceCost.SetValue(-adjustCostObject.Value);
                                break;
                            default:
                                throw new Exception("Not a valid stat mod type");
                        }
                    }

                    //Removing the mixed modify cost as it was perhaps too complicated/confusing. May add this in later
                    //For now, modifying cost just modifies each resource in the list
                    #region Mixed Modify Cost
                    //if (Resources.Count == 1)
                    //{
                    //    var resourceCost = ResourceCost.FirstOrDefault();

                    //    switch (statModType)
                    //    {
                    //        case StatModifierTypes.Modify:
                    //            resourceCost.ModifyValue(-value, true);
                    //            break;
                    //        case StatModifierTypes.Set:
                    //            resourceCost.SetValue(value);
                    //            break;
                    //        default:
                    //            throw new Exception("Not a valid stat mod type");
                    //    }
                    //}
                    //else
                    //{
                    //    bool isOdd = false;
                    //    if (statModType == StatModifierTypes.Modify)
                    //    {
                    //        if (value % 2 == 1)
                    //        {
                    //            value -= 1;
                    //            isOdd = true;
                    //        }
                    //        else if (value % 2 == -1)
                    //        {
                    //            value += 1;
                    //            isOdd = true;
                    //        }
                    //        value /= Resources.Count;
                    //    }

                    //    switch (statModType)
                    //    {
                    //        case StatModifierTypes.Modify:
                    //            ResourceCost.ForEach(x => x.ModifyValue(-value, true));
                    //            break;
                    //        case StatModifierTypes.Set:
                    //            ResourceCost.ForEach(x => x.SetValue(value));
                    //            break;
                    //        default:
                    //            throw new Exception("Not a valid stat mod type");
                    //    }


                    //    if (isOdd)
                    //    {
                    //        var highestResources = ResourceCost.Where(x => x.Value == ResourceCost.Min(y => y.Value)).ToList();
                    //        var valueModifier = value > 0 ? -1 : 1;
                    //        if (highestResources.Count() == 1)
                    //        {
                    //            highestResources.FirstOrDefault().ModifyValue(valueModifier, true);
                    //        }
                    //        else
                    //        {
                    //            var randomResource = UnityEngine.Random.Range(0, highestResources.Count());
                    //            highestResources[randomResource].ModifyValue(valueModifier, true);
                    //        }
                    //    }
                    //}
                    #endregion
                }
            }
        }

        //Loops through each resource to clamp the values of each resource
        foreach (var resourceCost in ResourceCost)
        {
            //Modifies the cost by 0 to clamp the resource value
            resourceCost.ModifyValue(0, true);
        }

        return true;
    }

    /// <summary>
    /// 
    /// Copy the a given cards stats to this card
    /// 
    /// </summary>
    /// <param name="copyFrom">The card to copy from</param>
    public virtual void CopyCardStats(Card copyFrom)
    {
        //Copies the resource cost of each card's resource
        foreach (var resource in ResourceCost)
        {
            var copyResource = copyFrom.ResourceCost.Single(x => x.ResourceType == resource.ResourceType);
            resource.Value = copyResource.Value;
        }
    }
}
