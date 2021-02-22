﻿using CategoryEnums;
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
            AddToHand(drawnCard);
        else
            Debug.Log("Deck is empty");
    }

    public void Draw(int numToDraw)
    {
        var drawnCards = Deck.Draw(numToDraw, out int failedDraws);

        if (drawnCards.Count != 0)
        {
            foreach (var drawnCard in drawnCards)
                AddToHand(drawnCard);

            if (failedDraws > 0)
                Debug.Log($"Failed to draw {failedDraws} from the deck as there were not enough cards remaining");
        }
        else
            Debug.Log("Deck is empty");
    }

    public bool Draw(CardListFilter filter)
    {
        var drawnCard = Deck.Draw(filter, out bool failedFilter);

        if (!failedFilter)
        {
            if (drawnCard != null)
                AddToHand(drawnCard);
            else
                Debug.Log("Deck is empty");

            return true;
        }
        else
        {
            Debug.Log("Given filter cannot draw any cards from the deck");
            return false;
        }
    }

    public void Draw(int numToDraw, CardListFilter filter)
    {
        var drawnCards = Deck.Draw(numToDraw, filter, out int failedDraws, out bool failedFilter);

        if (!failedFilter)
        {
            if (drawnCards.Count != 0)
            {
                foreach (var drawnCard in drawnCards)
                    AddToHand(drawnCard);

                if (failedDraws > 0)
                    Debug.Log($"Failed to draw {failedDraws} from the deck as there were not enough cards remaining");
            }
            else
                Debug.Log("Deck is empty");
        }
        else
            Debug.Log("Given filter cannot draw any cards from the deck");
    }

    public bool AddToHand(Card newCard, string createdBy = "")
    {
        if (string.IsNullOrWhiteSpace(createdBy))
            createdBy = newCard.CreatedByName;

        var handFull = !Hand.AddToHand(newCard, createdBy);
        if (handFull)
            DiscardCard(newCard);

        return handFull;
    }

    public bool GenerateCards(GenerateCardFilter filter, CardGenerationTypes generationType, string createdBy, DeckPositions deckPosition = DeckPositions.Random)
    {
        var generatedCardDatas = GameManager.instance.libraryManager.GenerateGameplayCards(filter);

        if (generatedCardDatas.Count == 0)
            return false;

        foreach (var cardData in generatedCardDatas)
        {
            var generatedCard = GameManager.instance.libraryManager.CreateCard(cardData, this);
            switch (generationType)
            {
                case CardGenerationTypes.Hand:
                    AddToHand(generatedCard, createdBy);
                    break;
                case CardGenerationTypes.Deck:
                    Deck.ShuffleIntoDeck(generatedCard, createdBy, deckPosition);
                    break;
                case CardGenerationTypes.Graveyard:
                    AddToGraveyard(generatedCard, createdBy);
                    break;
                default:
                    throw new Exception("Not a valid Generation Type");
            }
        }

        return true;
    }

    public void PlayFromHand(Card playedCard)
    {
        Hand.RemoveCard(playedCard);
    }

    public void DiscardFromHand(Card discardCard)
    {
        Hand.RemoveCard(discardCard);
        DiscardCard(discardCard);
    }

    public void DiscardCard(Card discardCard)
    {
        Discard.AddCard(discardCard);
    }

    public void ReturnFromDiscard(Card returningCard = null)
    {
        if (Discard.ListCount == 0)
            Debug.Log("Discard Pool is Empty");
        else
        {
            if (returningCard == null)
            {
                var randomPos = UnityEngine.Random.Range(0, Discard.ListCount);
                returningCard = Discard.cardList[randomPos];
            }

            if (!Discard.cardList.Contains(returningCard))
                throw new Exception("Card does not exist in Discard Pool");

            Discard.RemoveCard(returningCard);
            AddToHand(returningCard);
        }
    }

    public void AddToGraveyard(Card deadCard, string createdBy = "")
    {
        if (!string.IsNullOrWhiteSpace(createdBy))
            deadCard.CreatedByName = createdBy;

        Graveyard.AddCard(deadCard);
    }
}
