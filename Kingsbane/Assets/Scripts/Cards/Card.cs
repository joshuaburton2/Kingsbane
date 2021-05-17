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

    public virtual void InitCard(CardData _cardData, Player owner)
    {
        CardData = _cardData;
        Owner = owner;
        CardArt = GameManager.instance.imageManager.GetCardImage(ImageTag, CardClass);
        CreatedByName = "";
        NumShuffles = 0;
        SpyMasterLurenCard = null;
        ResourceInit();
        CostAdjustments = new List<AdjustCostObject>();

        if (Owner != null)
        {
            if (GameManager.instance.CurrentGamePhase != GameManager.GamePhases.Menu)
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
    public void ResourceInit()
    {
        if (!ResourceConvertedTo.HasValue || ResourceCost.Count == 0)
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
            ResourceCost.FirstOrDefault().SetValue(CardData.TotalResource);
            ResourceConvert(ResourceConvertedTo.Value);
        }
    }

    public virtual void ResourceConvert(CardResources newResource)
    {
        if (ResourceCost.Count != 0)
        {
            ResourceCost = new List<Resource>() { new Resource(newResource, TotalResource) };
            Resources = new List<CardResources> { newResource };
            ResourceConvertedTo = newResource;
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
        if (SpyMasterLurenCard != null)
        {
            SpyMasterLurenCard = null;
            GameManager.instance.effectManager.ReturnLurenCards(playedCard: this);
        }

        Owner.ModifyResources(ResourceCost);

        ResourceInit();
        Owner.PlayFromHand(this);

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

    public bool ModifyCost(AdjustCostObject adjustCostObject)
    {
        CostAdjustments.Add(adjustCostObject);

        return RecalculateCost();
    }

    public bool RecalculateCost()
    {
        ResourceInit();
        
        foreach (var adjustCostObject in CostAdjustments)
        {
            if (!adjustCostObject.MustBeGreaterThan.HasValue || adjustCostObject.MustBeGreaterThan.HasValue && TotalResource < -adjustCostObject.MustBeGreaterThan.Value)
            {
                if (adjustCostObject.TargetResource.HasValue)
                {
                    if (!Resources.Contains(adjustCostObject.TargetResource.Value))
                        return false;

                    var resourceCost = ResourceCost.Single(x => x.ResourceType == adjustCostObject.TargetResource);

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
                else
                {
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

    public virtual void CopyCardStats(Card copyFrom)
    {
        foreach (var resource in ResourceCost)
        {
            var copyResource = copyFrom.ResourceCost.Single(x => x.ResourceType == resource.ResourceType);
            resource.Value = copyResource.Value;
        }
    }
}
