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
    public List<Unit> RedeployUnits { get; set; }
    public List<UnitCounter> DeployedSummonUnits { get; set; }
    public int ItemCapacity { get { return DeckData.ItemCapacity; } }
    public List<Passive> Passives { get; set; }

    public List<PlayerResource> Resources { get; set; }
    public List<CardResources> UsedResources { get { return Resources.Select(x => x.ResourceType).ToList(); } }

    public int PassiveEmpowered { get; set; }
    public int CurrentEmpowered { get; set; }
    public int BaseSummonCapactiy { get; set; }
    public int SummonCapcity { get; set; }
    public int CurrentSummons { get; set; }
    public bool DeathDefiant { get { return DeckData.DeathDefiant; } set { DeckData.DeathDefiant = value; } }

    public bool LoseOnHeroLoss { get; set; }

    public Player(DeckData _deckData)
    {
        DeckData = _deckData;

        Passives = new List<Passive>();
        Deck = new Deck(DeckData.CardList, this);
        Hand = new Hand();
        Graveyard = new CardList();
        Discard = new CardList();
        Upgrades = DeckData.UpgradeList;
        Hero = (Hero)GameManager.instance.libraryManager.CreateCard(DeckData.HeroCard, this);
        DeployedUnits = new List<UnitCounter>();
        RedeployUnits = new List<Unit>();
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

        LoseOnHeroLoss = true;

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
                if (GameManager.instance.CurrentRound == 1)
                    StartOfGameEffects();

                Draw();
                foreach (var resource in Resources)
                    resource.StartOfTurnUpdate();
            }

            UnitStartOfTurn();

            foreach (var passive in new List<Passive>(Passives))
            {
                if (passive.IsTemporary)
                {
                    Passives.Remove(passive);
                }
            }
        }
        else
        {
            UnitStartOfTurn();
        }

        CheckWarden();
    }

    private void StartOfGameEffects()
    {
        if (HasSpecialPassive(SpecialPassiveEffects.BreadthOfKnowledge, out Passive breadthOfKnowledgePassive))
        {
            //Finds the required inspiration card
            var inspirationCardData = GameManager.instance.libraryManager.GenerateGameplayCards(new GenerateCardFilter(PlayerClass)
            {
                IncludeUncollectables = true,
                Class = PlayerClass,
                Tag = Tags.Inspiration,
            }).Single();

            for (int i = 0; i < breadthOfKnowledgePassive.SpecialPassiveProperty; i++)
            {
                var inspirationCard = GameManager.instance.libraryManager.CreateCard(inspirationCardData, this);
                Deck.ShuffleIntoDeck(inspirationCard, breadthOfKnowledgePassive.SourceUpgrade.Name);
            }
        }

        if (HasSpecialPassive(SpecialPassiveEffects.MagisFury))
        {
            Hero.ActiveMagisFury = true;
        }
    }

    private void UnitStartOfTurn()
    {
        foreach (var unit in DeployedUnits)
        {
            unit.Unit.StartOfTurn();
        }
    }

    public void EndOfTurn()
    {
        var unitList = new List<UnitCounter>(DeployedUnits);
        foreach (var unit in unitList)
        {
            var toDestroy = unit.Unit.EndOfTurn(IsActivePlayer);

            if (toDestroy)
                unit.Unit.RemoveUnit(true);

            if (unit.Unit.TemporaryMindControlled && !toDestroy)
                unit.Unit.SwitchOwner(GameManager.instance.GetPlayer(!IsActivePlayer), false);
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

    public void TriggerHeroLoss()
    {
        if (LoseOnHeroLoss)
        {
            if (GameManager.instance.CurrentGamePhase != GameManager.GamePhases.End)
                GameManager.instance.TriggerVictory(Id);
        }
    }

    public void GameEndUpdates()
    {
        if (UsedResources.Contains(CardResources.Devotion))
        {
            var devotion = (PlayerDevotion)Resources.Single(x => x.ResourceType == CardResources.Devotion);
            var numPrayerUnits = DeployedUnits.Where(x => x.Unit.Tags.Contains(Tags.PrayerGain)).Count();
            devotion.SetLastingPrayer(numPrayerUnits);
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
        var topDeckCards = Deck.GetTopCards(numToDivinate);

        GameManager.instance.effectManager.SetDivinateMode(topDeckCards, Id);

        return true;
    }

    public void Divinate(List<Card> topCards, List<Card> bottomCards)
    {
        Deck.cardList.RemoveAll(x => topCards.Contains(x) || bottomCards.Contains(x));

        topCards.Reverse();
        foreach (var card in topCards)
            Deck.AddToDeck(card, Deck.ListCount, trackShuffle: false);

        foreach (var card in bottomCards)
            Deck.AddToDeck(card, 0, trackShuffle: false);
    }

    public bool InitFortuneTeller()
    {
        var baseNumToSelect = 3;

        if (Deck.ListCount == 0)
        {
            Debug.Log("Deck is empty");
            return false;
        }
        var topDeckCards = Deck.GetTopCards(baseNumToSelect);

        GameManager.instance.effectManager.SetFortuneTellerChoiceMode(topDeckCards);

        return true;
    }

    public void FortuneTeller(Card newTopCard)
    {
        Deck.cardList.Remove(newTopCard);
        Deck.AddToDeck(newTopCard, Deck.ListCount, trackShuffle: false);
    }

    public bool InitAlterFate()
    {
        var numToSelect = Mathf.Min(Hand.ListCount, Deck.ListCount);

        if (numToSelect == 0)
            return false;

        var handCards = numToSelect == Hand.ListCount ? new List<Card>(Hand.cardList) : Hand.cardList.GetRange(0, numToSelect);
        var deckCards = Deck.GetTopCards(numToSelect);

        GameManager.instance.effectManager.SetAlterFateMode(handCards, deckCards);

        return true;
    }

    public void AlterFate(List<Card> handCards, List<Card> deckCards, List<bool> isSwapped)
    {
        var cardCount = 0;
        if (handCards.Count != deckCards.Count || handCards.Count != isSwapped.Count)
            throw new Exception("Cannot Alter Fate lists of different sizes");
        else
            cardCount = handCards.Count;

        for (int cardIndex = 0; cardIndex < cardCount; cardIndex++)
        {
            if (isSwapped[cardIndex])
            {
                var handIndex = Hand.cardList.IndexOf(deckCards[cardIndex]);
                Hand.RemoveCard(deckCards[cardIndex]);
                Hand.AddToHand(handCards[cardIndex], handIndex);
                Deck.RemoveCard(handCards[cardIndex]);
                Deck.ShuffleIntoDeck(deckCards[cardIndex]);
            }
        }
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

    public void AddToRedeploy(Unit unit)
    {
        RedeployUnits.Add(unit);
        GameManager.instance.uiManager.RefreshUI();
    }

    public void AddToRedeploy(List<Unit> units)
    {
        RedeployUnits.AddRange(units);
    }

    public bool CopyHandCard(Card copyCard, out Card newCopy, string createdBy = "")
    {
        newCopy = GameManager.instance.libraryManager.CreateCard(copyCard.CardData, this);
        newCopy.CreatedByName = createdBy;
        if (copyCard.ResourceConvertedTo.HasValue)
            newCopy.ResourceConvert(copyCard.ResourceConvertedTo.Value);
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

            if (filter.CostModification != null)
            {
                var adjustCost = new AdjustCostObject()
                {
                    Value = filter.CostModification.Value,
                    TargetResource = filter.ResourceModification,
                    AdjustmentType = StatModifierTypes.Modify,
                };
                generatedCard.ModifyCost(adjustCost);
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
        Hero.HealUnit(-discardCard.TotalResource);
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

    public bool ReturnFromGraveyard(CardListFilter filter, int numToCreate, bool isDeploy, bool isRedeploy, bool isCopy, string createdBy, bool isChoice)
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
                if (isRedeploy)
                {
                    AddToRedeploy(unitList);
                }
                else
                {
                    GameManager.instance.effectManager.SetDeployUnits(unitList);
                }

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

            if (HasSpecialPassive(SpecialPassiveEffects.ThiefsGloves, out Passive thiefsGlovesPassive))
            {
                for (int i = 0; i < thiefsGlovesPassive.SpecialPassiveProperty; i++)
                {
                    CopyHandCard(newCard, out Card newCopy, "Recruit");
                }
            }
        }
        else
        {
            throw new Exception("Cannot recruit cards with a non gold class");
        }
    }

    public bool HasSpecialPassive(SpecialPassiveEffects specialPassive)
    {
        return Passives.Any(x => x.SpecialPassive == specialPassive);
    }

    public bool HasSpecialPassive(SpecialPassiveEffects specialPassive, out Passive passive)
    {
        passive = Passives.SingleOrDefault(x => x.SpecialPassive == specialPassive);
        return passive != null;
    }

    public bool AddPassive(Passive passive)
    {
        if (passive.SourceUpgrade != null)
        {
            if (passive.SourceUpgrade.ResourcePrerequisites.Any() && !passive.SourceUpgrade.ResourcePrerequisites.Intersect(UsedResources).Any())
                return false;

            if (passive.SourceUpgrade.ClassPrerequisites.Any() && !passive.SourceUpgrade.ClassPrerequisites.Contains(PlayerClass))
                return false;
        }

        Passives.Add(passive);

        var cardList = new List<Card>();
        cardList.AddRange(Deck.cardList);
        cardList.AddRange(Hand.cardList);
        cardList.AddRange(Graveyard.cardList);
        cardList.AddRange(Discard.cardList);
        cardList.AddRange(DeployedUnits.Select(x => x.Unit));
        cardList.AddRange(RedeployUnits);

        if (passive.CostAdjustment != null)
        {
            foreach (var card in cardList)
            {
                if (!card.IsHero)
                    if (passive.PassiveApplies(card))
                        card.ModifyCost(passive.CostAdjustment);
            }
        }

        if (passive.Enchantment != null)
        {
            foreach (var card in cardList.Where(x => x.Type == CardTypes.Unit).Cast<Unit>())
            {
                if (passive.PassiveApplies(card))
                    card.AddEnchantment(passive.Enchantment);
            }
        }

        switch (passive.SpecialPassive)
        {
            case SpecialPassiveEffects.LunarEclipse:
                foreach (var unit in DeployedUnits.Select(x => x.Unit))
                {
                    unit.AddProtected(passive.SpecialPassiveProperty);
                }
                break;
            default:
                break;
        }

        return true;
    }
}
