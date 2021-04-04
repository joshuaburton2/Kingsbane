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
    public List<UnitCounter> DeployedSummonUnits { get; set; }
    public int ItemCapacity { get { return DeckData.ItemCapacity; } }

    public List<PlayerResource> Resources { get; set; }
    public List<CardResources> UsedResources { get { return Resources.Select(x => x.ResourceType).ToList(); } }

    public int PassiveEmpowered { get; set; }
    public int CurrentEmpowered { get; set; }
    public int BaseSummonCapactiy { get; set; }
    public int SummonCapcity { get; set; }
    public int CurrentSummons { get; set; }
    private readonly int DEFAULT_SUMMON_CAPACITY = 1;

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
        DeployedSummonUnits = new List<UnitCounter>();

        PassiveEmpowered = DeckData.PassiveEmpowered;
        BaseSummonCapactiy = DeckData.BaseSummonCapactiy;
        CurrentEmpowered = PassiveEmpowered;
        CurrentSummons = 0;
        SummonCapcity = BaseSummonCapactiy;

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

    public void StartOfTurn()
    {
        if (IsActivePlayer)
        {
            GameManager.instance.effectManager.RefreshEffectManager(true);

            if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            {
                Draw();
                foreach (var resource in Resources)
                    resource.StartOfTurnUpdate();
            }

            UnitStartOfTurn();
        }
        else
        {
            UnitStartOfTurn();
        }

        CheckWarden();

    }

    private void UnitStartOfTurn()
    {
        foreach (var unit in DeployedUnits)
        {
            unit.Unit.StartOfTurn();
        }
    }

    public void EndOfTurn(bool isActive)
    {
        var unitList = new List<UnitCounter>(DeployedUnits);
        foreach (var unit in unitList)
        {
            var toDestroy = unit.Unit.EndOfTurn(isActive);

            if (toDestroy)
                unit.Unit.RemoveUnit(true);

            if (unit.Unit.TemporaryMindControlled && !toDestroy)
                unit.Unit.SwitchOwner(GameManager.instance.GetPlayer(!isActive), false);
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
        Deck.ShuffleIntoDeck(cardsToMulligan, trackShuffle: false);
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

    public bool Draw(CardListFilter filter, int? numToChoose = null)
    {
        var drawnCard = Deck.Draw(filter, out bool failedFilter, numToChoose);

        if (!failedFilter)
        {
            if (numToChoose == null)
            {
                if (drawnCard != null)
                    AddToHand(drawnCard);
                else
                    Debug.Log("Deck is empty");
            }

            return true;
        }
        else
        {
            Debug.Log("Given filter cannot draw any cards from the deck");
            return false;
        }
    }


    public void Draw(Card card)
    {
        var drawnCard = Deck.Draw(card);

        if (drawnCard != null)
            AddToHand(drawnCard);
        else
            Debug.Log($"Deck does not contain card: {card.Name}");
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

    public bool InitDivinate(int numToDivinate)
    {
        if (Deck.ListCount == 0)
        {
            Debug.Log("Deck is empty");
            return false;
        }
        var topDeckCards = Deck.cardList.Skip(Mathf.Max(0, Deck.ListCount - numToDivinate)).ToList();

        GameManager.instance.effectManager.SetDivinateMode(topDeckCards, Id);

        return true;
    }

    public void Divinate(List<Card> topCards, List<Card> bottomCards)
    {
        Deck.cardList.RemoveAll(x => topCards.Contains(x) || bottomCards.Contains(x));

        topCards.Reverse();
        foreach (var card in topCards)
            Deck.AddToDeck(card, Deck.ListCount);

        foreach (var card in bottomCards)
            Deck.AddToDeck(card, 0);
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

    public bool CopyHandCard(Card copyCard, string createdBy = "")
    {
        var newCopy = GameManager.instance.libraryManager.CreateCard(copyCard.CardData, this);
        newCopy.CreatedByName = createdBy;
        newCopy.CopyCardStats(copyCard);

        return AddToHand(newCopy);
    }

    public bool GenerateCards(GenerateCardFilter filter, CardGenerationTypes generationType, bool isChoice, string createdBy, DeckPositions deckPosition = DeckPositions.Random)
    {
        var generatedCardDatas = GameManager.instance.libraryManager.GenerateGameplayCards(filter);

        if (generatedCardDatas.Count == 0)
            return false;

        if (!isChoice && generationType == CardGenerationTypes.Deploy && generatedCardDatas.Count > 1)
            return false;

        var generatedCards = new List<Card>();
        foreach (var cardData in generatedCardDatas)
        {
            var generatedCard = GameManager.instance.libraryManager.CreateCard(cardData, this);
            if (generatedCard.Type == CardTypes.Unit && filter.Enchantment != null)
            {
                ((Unit)generatedCard).AddEnchantment(filter.Enchantment);
            }
            if (generatedCard.Type == CardTypes.Item && filter.DurabilityChange != null)
            {
                ((Item)generatedCard).EditDurability(filter.DurabilityChange.Value);
            }

            if (isChoice)
            {
                generatedCards.Add(generatedCard);
            }
            else
            {
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
                    case CardGenerationTypes.Deploy:
                        CreateDeployUnits(cardData, filter.Enchantment, filter.UnitsToCreate, createdBy);
                        break;
                    case CardGenerationTypes.Equip:
                        GameManager.instance.effectManager.SetItemEquip((Item)generatedCard);
                        break;
                    default:
                        throw new Exception("Not a valid Generation Type");
                }
            }
        }

        if (isChoice)
        {
            switch (generationType)
            {
                case CardGenerationTypes.Hand:
                    GameManager.instance.effectManager.SetAddToHandChoiceMode(generatedCards, createdBy);
                    break;
                case CardGenerationTypes.Deck:
                    GameManager.instance.effectManager.SetAddToDeckChoiceMode(generatedCards, createdBy, deckPosition);
                    break;
                case CardGenerationTypes.Graveyard:
                    GameManager.instance.effectManager.SetAddToGraveyardChoiceMode(generatedCards, createdBy);
                    break;
                case CardGenerationTypes.Deploy:
                    GameManager.instance.effectManager.SetDeployChoiceMode(generatedCards, createdBy);
                    break;
                case CardGenerationTypes.Equip:
                    GameManager.instance.effectManager.SetItemChoiceMode(generatedCards, createdBy);
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

    public void ShuffleFromHand(Card card)
    {
        Hand.RemoveCard(card);
        Deck.ShuffleIntoDeck(card);
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
        deadCard.InitCard(deadCard.CardData, this);

        if (!string.IsNullOrWhiteSpace(createdBy))
            deadCard.CreatedByName = createdBy;

        Graveyard.AddCard(deadCard);
    }

    public bool ReturnFromGraveyard(CardListFilter filter, int numToCreate, bool isDeploy, bool isCopy, string createdBy, bool isChoice)
    {
        var filteredCardList = Graveyard.FilterCardList(filter);

        if (filteredCardList.ListCount == 0)
            return false;

        var cardList = filteredCardList.GetRandomCards(numToCreate);

        if (!isChoice)
        {
            if (isDeploy)
            {
                var unitList = cardList.Cast<Unit>().ToList();
                GameManager.instance.effectManager.SetDeployUnits(unitList);
            }
            else
            {
                if (isCopy)
                {
                    cardList = cardList.Select(x => GameManager.instance.libraryManager.CreateCard(x.CardData, this)).ToList();
                    cardList.ForEach(x => x.CreatedByName = createdBy);
                }

                foreach (var card in cardList)
                    AddToHand(card);
            }


            if (!isCopy)
                Graveyard.RemoveCard(cardList);
        }
        else
        {
            if (isDeploy)
                GameManager.instance.effectManager.SetGraveyardToDeployChoiceMode(cardList);
            else
                GameManager.instance.effectManager.SetGraveyardToHandChoiceMode(cardList, isCopy, createdBy);
        }

        return true;
    }

    public void CreateDeployUnits(CardData cardData, UnitEnchantment enchantment, int numToCreate, string createdBy)
    {
        if (cardData.CardType == CardTypes.Unit)
        {
            var unitList = new List<Unit>();

            for (int cardIndex = 0; cardIndex < numToCreate; cardIndex++)
            {
                var unit = (Unit)GameManager.instance.libraryManager.CreateCard(cardData, this);
                unit.CreatedByName = createdBy;
                if (enchantment != null)
                    unit.AddEnchantment(enchantment);
                unitList.Add(unit);
            }

            GameManager.instance.effectManager.SetDeployUnits(unitList);
        }
        else
        {
            throw new Exception("Cannot deploy a non unit card");
        }
    }

    /// <summary>
    /// 
    /// Modify the current empowered value
    /// 
    /// </summary>
    public void ModifyEmpowered(int value)
    {
        CurrentEmpowered += value;
        CurrentEmpowered = Mathf.Max(0, CurrentEmpowered);
    }

    /// <summary>
    /// 
    /// Modify the current summon capacity
    /// 
    /// </summary>
    public void ModifySummonCapacity(int value = 1)
    {
        SummonCapcity += value;
        SummonCapcity = Mathf.Max(1, SummonCapcity);
    }

    /// <summary>
    /// 
    /// Modify the current summon amount. Returns true or false if the increase goes above the players Summon Capacity
    /// 
    /// </summary>
    public bool ModifyCurrentSummons(int value = 1)
    {
        CurrentSummons += value;
        bool exceedCapacity = CurrentSummons > SummonCapcity;
        CurrentSummons = Mathf.Clamp(CurrentSummons, 0, SummonCapcity);
        return exceedCapacity;
    }

    public void AddSummon(UnitCounter summonCounter)
    {
        var exceedCapacity = ModifyCurrentSummons();
        DeployedSummonUnits.Add(summonCounter);

        if (exceedCapacity)
        {
            GameManager.instance.effectManager.DestroyUnit(DeployedSummonUnits.FirstOrDefault().Unit);
        }
    }

    public void RemoveSummon(UnitCounter summonCounter)
    {
        DeployedSummonUnits.Remove(summonCounter);
        ModifyCurrentSummons(-1);
    }

    public void CheckWarden()
    {
        foreach (var unit in DeployedUnits)
        {
            unit.Unit.CheckWarden();
        }
    }

    public void RecruitCard(Card card, bool isCopy = true)
    {
        if (UsedResources.Contains(CardResources.Gold))
        {
            var newCard = card;
            if (isCopy)
                newCard = GameManager.instance.libraryManager.CreateCard(card.CardData, this);
            AddToHand(newCard, "Recruit");
            newCard.ResourceConvert(CardResources.Gold);
            newCard.Owner = this;
        }
        else
        {
            throw new Exception("Cannot recruit cards with a non gold class");
        }
    }
}
