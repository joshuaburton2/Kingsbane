using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 
/// Object for storing a list of cards. Has extra functionality than a regular list
/// 
/// </summary>
public class CardList
{
    public List<Card> List { get; set; }
    public int ListCount { get { return List.Count; } }

    public CardList()
    {
        List = new List<Card>();
    }

    public CardList(List<Card> _cardList)
    {
        List = _cardList;
    }

    /// <summary>
    /// 
    /// Adds a card to the list
    /// 
    /// </summary>
    /// <param name="card"></param>
    public void AddCard(Card card)
    {
        List.Add(card);
        List.OrderBy(x => x.TotalResource);
    }

    /// <summary>
    /// 
    /// Removes a card from the list
    /// 
    /// </summary>
    /// <param name="card"></param>
    public void RemoveCard(Card card)
    {
        List.Remove(card);
    }

    /// <summary>
    /// 
    /// Removes a list of cards from the list
    /// 
    /// </summary>
    public void RemoveCard(List<Card> cards)
    {
        List.RemoveAll(x => cards.Contains(x));
    }

    /// <summary>
    /// 
    /// Removes a card at a certain position
    /// 
    /// </summary>
    /// <param name="pos"></param>
    public void RemoveCard(int pos = 0)
    {
        List.RemoveAt(pos);
    }

    /// <summary>
    /// 
    /// Empties the list
    /// 
    /// </summary>
    public void EmptyList()
    {
        List.Clear();
    }

    /// <summary>
    /// 
    /// Gets a single random card from the list
    /// 
    /// </summary>
    /// <returns></returns>
    public Card GetRandomCard()
    {
        var randomCards = GetRandomCards(1);
        return randomCards.FirstOrDefault();
    }

    /// <summary>
    /// 
    /// Gets a random number of cards from the deck
    /// 
    /// </summary>
    /// <param name="numToGet"></param>
    /// <returns></returns>
    public List<Card> GetRandomCards(int numToGet)
    {
        //Can only get a number of cards greater than 0
        if (numToGet > 0)
        {
            var selectedCardList = new List<Card>();
            //Minimises the number so that more than the number of cards in the list can be retrieved
            var numToChoose = Mathf.Min(ListCount, numToGet);

            //Loops through a number of times for each card that needs to be selected
            for (int randomIndex = 0; randomIndex < numToChoose; randomIndex++)
            {
                //Loops until each random card is unique, then adds to the selection
                Card selectedCard = new Card();
                do
                {
                    var randomVal = UnityEngine.Random.Range(0, ListCount);
                    selectedCard = List[randomVal];
                } while (selectedCardList.Contains(selectedCard));

                selectedCardList.Add(selectedCard);
            }

            return selectedCardList;
        }
        else
        {
            throw new Exception("Cannot randomly get to less than 0 cards");
        }
    }

    /// <summary>
    /// 
    /// Filters a card list using a given filter object
    /// 
    /// </summary>
    public CardList FilterCardList(CardListFilter filter)
    {
        var filteredCardList = new List<Card>();

        //Dictionary used to track either the highest or lowest value of each int value filter
        var intValueTracker = new Dictionary<CardListFilter.IntFilterTypes, int?>();

        //Loop through each card in the list. If fails a filter, continues through the loop
        foreach (var card in List)
        {
            if (filter.Name.Length > 0)
            {
                if (!filter.Name.ToLower().Contains(card.Name.ToLower()))
                    continue;
            }

            if (filter.Rarity != Rarity.Default)
            {
                if (filter.Rarity != card.Rarity)
                    continue;
            }

            if (filter.Class != Classes.ClassList.Default)
            {
                if (filter.Class != card.CardClass)
                    continue;
            }

            if (filter.Tag != Tags.Default)
            {
                if (!card.Tags.Contains(filter.Tag))
                    continue;
            }

            if (filter.Resource != CardResources.Neutral)
            {
                if (!card.Resources.Contains(filter.Resource))
                    continue;
            }

            if (filter.ScenarioCreated.HasValue)
            {
                if (!filter.ScenarioCreated.Value != string.IsNullOrWhiteSpace(card.CreatedByName))
                    continue;
            }

            if (filter.CardType != CardTypes.Default)
            {
                if (filter.CardType != card.Type)
                    continue;
            }

            //Flag to determine if failed the filter. Sets to false to assume that the card succceeds the filter
            bool intFilterFlag = false;

            //Loops through each of the int filters
            foreach (var intFilter in filter.IntFilters)
            {
                //Checks that the filter is not a none value
                if (intFilter.Value.Key != IntValueFilter.None)
                {
                    int? value = null;
                    //Sets the value to the required property of the card. Converts cards to a different type if required
                    switch (intFilter.Key)
                    {
                        case CardListFilter.IntFilterTypes.Cost:
                            //Convert total cost to a positive, as total resource provides a negative value
                            value = -card.TotalResource;
                            break;
                        case CardListFilter.IntFilterTypes.Attack:
                            if (card.Type == CardTypes.Unit)
                                value = ((Unit)card).GetStat(Unit.StatTypes.Attack);
                            break;
                        case CardListFilter.IntFilterTypes.Health:
                            if (card.Type == CardTypes.Unit)
                                value = ((Unit)card).GetStat(Unit.StatTypes.MaxHealth);
                            break;
                        case CardListFilter.IntFilterTypes.Range:
                            if (card.Type == CardTypes.Unit)
                                value = ((Unit)card).GetStat(Unit.StatTypes.Range);
                            break;
                        case CardListFilter.IntFilterTypes.Speed:
                            if (card.Type == CardTypes.Unit)
                                value = ((Unit)card).GetStat(Unit.StatTypes.Speed);
                            break;
                        case CardListFilter.IntFilterTypes.SpellRange:
                            if (card.Type == CardTypes.Unit)
                                value = ((Spell)card).SpellRange;
                            break;
                        case CardListFilter.IntFilterTypes.Durability:
                            if (card.Type == CardTypes.Unit)
                                value = ((Item)card).Durability;
                            break;
                        default:
                            throw new Exception("Not a valid filter type");
                    }

                    //Sets the value filter to the given filter
                    var intvalueFilter = intFilter.Value;

                    //If highest or lowest, need to record the current highest or lowest value
                    if (intFilter.Value.Key == IntValueFilter.Highest || intFilter.Value.Key == IntValueFilter.Lowest)
                    {
                        //If the key does not exist in the highest/lowest record, adds it
                        if (!intValueTracker.ContainsKey(intFilter.Key))
                            intValueTracker.Add(intFilter.Key, value);

                        //Creates the value filter as the recorded highest value
                        intvalueFilter = new KeyValuePair<IntValueFilter, int?>
                            (intFilter.Value.Key, intValueTracker.FirstOrDefault(x => x.Key == intFilter.Key).Value);
                    }

                    //Determines if the recorded value has a value
                    if (value.HasValue)
                    {
                        //If the value fails the filter sets the flag to true and breaks from the loop, which will then continue the loop through the cards
                        if (!IntValueFilterer.CheckIntValueFilter(value.Value, intvalueFilter))
                        {
                            intFilterFlag = true;
                            break;
                        }
                        else
                        {
                            //If succeeds the filter, means need to check the highest or lowest value to futher filter the card list
                            if (intFilter.Value.Key == IntValueFilter.Highest || intFilter.Value.Key == IntValueFilter.Lowest)
                            {
                                //If the value is not equal to the current highest or lowest value, means that it has beat the previous highest or lowest card in the comparison
                                if (intFilter.Value.Value != value)
                                {
                                    //Removes the previous highest or lowest value from the record, then adds the new record to keep it for the next card iteration
                                    intValueTracker.Remove(intFilter.Key);
                                    intValueTracker.Add(intFilter.Key, value);

                                    //Removes all the cards in the filtered card list which share the same property value of the previous highest or lowest value
                                    switch (intFilter.Key)
                                    {
                                        case CardListFilter.IntFilterTypes.Cost:
                                            filteredCardList.RemoveAll(x => x.TotalResource == value);
                                            break;
                                        case CardListFilter.IntFilterTypes.Attack:
                                            filteredCardList.RemoveAll(x => ((Unit)x).GetStat(Unit.StatTypes.Attack) == value);
                                            break;
                                        case CardListFilter.IntFilterTypes.Health:
                                            filteredCardList.RemoveAll(x => ((Unit)x).GetStat(Unit.StatTypes.MaxHealth) == value);
                                            break;
                                        case CardListFilter.IntFilterTypes.Range:
                                            filteredCardList.RemoveAll(x => ((Unit)x).GetStat(Unit.StatTypes.Range) == value);
                                            break;
                                        case CardListFilter.IntFilterTypes.Speed:
                                            filteredCardList.RemoveAll(x => ((Unit)x).GetStat(Unit.StatTypes.Speed) == value);
                                            break;
                                        case CardListFilter.IntFilterTypes.SpellRange:
                                            filteredCardList.RemoveAll(x => ((Spell)x).SpellRange == value);
                                            break;
                                        case CardListFilter.IntFilterTypes.Durability:
                                            filteredCardList.RemoveAll(x => ((Item)x).Durability == value);
                                            break;
                                        default:
                                            throw new Exception("Not a valid filter type");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (intFilterFlag)
                continue;

            //If card passes all filters, then adds the card to the filtered card list
            filteredCardList.Add(card);
        }

        return new CardList(filteredCardList);
    }
}
