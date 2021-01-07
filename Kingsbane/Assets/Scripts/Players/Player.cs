using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Player
{
    public const int MULLIGAN_SIZE = 4;

    public string Name { get { return DeckData.Name; } }
    public Classes.ClassList PlayerClass { get { return DeckData.DeckClass; } }

    private DeckData DeckData { get; set; }

    public Deck Deck { get; set; }
    public Hand Hand { get; set; }
    public CardList Graveyard { get; set; }
    public CardList Discard { get; set; }
    public List<UpgradeData> Upgrades { get; set; }
    public Unit Hero { get; set; }
    public List<UnitCounter> DeployedUnits { get; set; }

    public List<PlayerResource> Resources { get; set; }
    public List<CardResources> UsedResources { get { return Resources.Select(x => x.ResourceType).ToList(); } }

    public Player(DeckData _deckData)
    {
        DeckData = _deckData;

        Deck = new Deck(DeckData.CardList, this);
        Hand = new Hand();
        Graveyard = new CardList();
        Discard = new CardList();
        Upgrades = DeckData.UpgradeList;
        Hero = (Unit)GameManager.instance.libraryManager.CreateCard(DeckData.HeroCard, this);
        DeployedUnits = new List<UnitCounter>();

        Resources = DeckData.PlayerResources;
    }

    public void InitialisePlayer()
    {
        Deck.Shuffle();
        DrawMulligan();

        foreach (var resource in Resources)
            resource.StartOfGameUpdate(this);
    }

    public void StartOfTurn()
    {
        Draw();
        ResourceStartOfTurnUpdate();
    }

    private void ResourceStartOfTurnUpdate()
    {
        foreach (var resource in Resources)
            resource.StartOfTurnUpdate();
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
    public void DrawMulligan()
    {
        var cardsToMulligan = Hand.cardList.ToList();
        Hand.EmptyList();
        Draw(MULLIGAN_SIZE);
        Deck.ShuffleIntoDeck(cardsToMulligan);
    }

    public void Draw()
    {
        var drawnCard = Deck.Draw();

        if (drawnCard != null)
        {
            AddToHand(drawnCard);
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
                AddToHand(drawnCard);
            }
        }
        else
        {
            Debug.Log("Deck is empty");
        }
    }

    public void AddToHand(Card newCard)
    {
        var handFull = !Hand.AddToHand(newCard);
        if (handFull)
        {
            Discard.AddCard(newCard);
        }
    }

    #endregion
}
