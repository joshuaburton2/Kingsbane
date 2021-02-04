using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Player
{
    public int Id { get; set; }
    public string Name { get { return DeckData.Name; } }
    public Classes.ClassList PlayerClass { get { return DeckData.DeckClass; } }
    public bool IsActivePlayer { get { return Id == GameManager.instance.ActivePlayerId; } }

    private DeckData DeckData { get; set; }

    public Deck Deck { get; set; }
    public Hand Hand { get; set; }
    public CardList Graveyard { get; set; }
    public CardList Discard { get; set; }
    public List<UpgradeData> Upgrades { get; set; }
    public Hero Hero { get; set; }
    public List<UnitCounter> DeployedUnits { get; set; }
    public int ItemCapacity { get { return DeckData.ItemCapacity; } }

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
        Hero = (Hero)GameManager.instance.libraryManager.CreateCard(DeckData.HeroCard, this);
        DeployedUnits = new List<UnitCounter>();

        Resources = DeckData.PlayerResources;
    }

    public void InitialisePlayer(int id)
    {
        Id = id;
        Deck.Shuffle();
        DrawMulligan();

        foreach (var resource in Resources)
            resource.StartOfGameUpdate(Id);
    }

    public void StarOfTurn(bool isActive)
    {
        if (isActive)
        {
            GameManager.instance.effectManager.RefreshEffectManager();

            if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            {
                Draw();

                foreach (var resource in Resources)
                    resource.StartOfTurnUpdate();
            }

            UnitStartOfTurn(isActive);
        }
        else
        {
            UnitStartOfTurn(isActive);
        }

    }

    private void UnitStartOfTurn(bool isActive)
    {
        foreach (var unit in DeployedUnits)
        {
            unit.Unit.StartOfTurn(isActive);
            unit.RefreshUnitCounter();
        }
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

    public void DrawMulligan()
    {
        var cardsToMulligan = Hand.cardList.ToList();
        Hand.EmptyList();
        Draw(DeckData.InitialHandSize);
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

    public void AddToHand(Card newCard, string createdBy = "")
    {
        var handFull = !Hand.AddToHand(newCard, createdBy);
        if (handFull)
        {
            Discard.AddCard(newCard);
        }
    }

    public void PlayFromHand(Card playedCard)
    {
        Hand.RemoveCard(playedCard);
    }

    public void DiscardFromHand(Card discardCard)
    {
        Hand.RemoveCard(discardCard);
        Discard.AddCard(discardCard);
    }

    public void AddToGraveyard(Card deadCard)
    {
        Graveyard.AddCard(deadCard);
    }
}
