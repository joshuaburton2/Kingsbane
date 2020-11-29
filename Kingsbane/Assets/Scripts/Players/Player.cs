using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Player
{
    public string Name { get { return DeckData.Name; } }
    public Classes.ClassList PlayerClass { get { return DeckData.DeckClass; } }

    private DeckData DeckData { get; set; }

    public Deck Deck { get; set; }
    public Hand Hand { get; set; }
    public List<UpgradeData> Upgrades { get; set; }

    public List<PlayerResource> Resources { get; set; }
    public List<CardResources> UsedResources { get { return Resources.Select(x => x.ResourceType).ToList(); } }

    public Player(DeckData _deckData)
    {
        DeckData = _deckData;

        Deck = new Deck(DeckData.CardList);
        Hand = new Hand();
        Upgrades = DeckData.UpgradeList;

        Resources = DeckData.PlayerResources;

    }

    /// <summary>
    /// 
    /// Calculates the difference in resources if an effect is to change them
    /// 
    /// </summary>
    /// <param name="resource">The resource which is being modified as well as the relevant value</param>
    public Resource CalcNewResource(Resource resource)
    {
        var selectedResource = Resources.First(x => x.ResourceType == resource.ResourceType);
        var newValue = selectedResource.CalcNewValue(resource.Value);

        return new Resource(selectedResource.ResourceType, newValue);
    }

    /// <summary>
    /// 
    /// Modifies a particular player resource with a given resource value
    /// 
    /// </summary>
    public void ModifyResources(List<Resource> resourceChanges)
    {
        foreach (var resourceChange in resourceChanges)
        {
            var resourceToChange = Resources.First(x => x.ResourceType == resourceChange.ResourceType);

            resourceToChange.ModifyValue(resourceChange.Value);
        }
    }

    #region Draw Functions
    public void Draw()
    {
        var drawnCard = Deck.Draw();

        if (drawnCard != null)
        {
            //drawnCard.transform.parent = hand.gameObject.transform;
            Hand.AddToHand(drawnCard);
        }
        else
        {
            Debug.Log("Deck is empty");
        }
    }

    public void Draw(int numToDraw)
    {
        var drawnCards = Deck.Draw(numToDraw, out int failedDraws);

        if (drawnCards.Count != 0)
        {
            foreach (var drawnCard in drawnCards)
            {
                //drawnCard.transform.parent = hand.gameObject.transform;
                Hand.AddToHand(drawnCard);
            }
        }
        else
        {
            Debug.Log("Deck is empty");
        }
    }

    #endregion
}
