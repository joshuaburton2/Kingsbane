using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardList
{
    public List<Card> cardList;
    public int ListCount { get { return cardList.Count; } }

    public CardList()
    {
        cardList = new List<Card>();
    }

    public CardList(List<Card> _cardList)
    {
        cardList = _cardList;
    }

    public void AddCard(Card card)
    {
        cardList.Add(card);
        cardList.OrderBy(x => x.TotalResource);
    }

    public void RemoveCard(Card card)
    {
        cardList.Remove(card);
    }

    public void RemoveCard(int pos = 0)
    {
        var card = cardList[pos];
        RemoveCard(card);
    }

    public void EmptyList()
    {
        cardList.Clear();
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
        foreach (var card in cardList)
        {
            if (filter.Name.Length > 0)
            {
                if (!filter.Name.Contains(card.Name))
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
                                value = ((Unit)card).Attack;
                            break;
                        case CardListFilter.IntFilterTypes.Health:
                            if (card.Type == CardTypes.Unit)
                                value = ((Unit)card).Health;
                            break;
                        case CardListFilter.IntFilterTypes.Range:
                            if (card.Type == CardTypes.Unit)
                                value = ((Unit)card).Range;
                            break;
                        case CardListFilter.IntFilterTypes.Speed:
                            if (card.Type == CardTypes.Unit)
                                value = ((Unit)card).Speed;
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
                                            filteredCardList.RemoveAll(x => ((Unit)x).Attack == value);
                                            break;
                                        case CardListFilter.IntFilterTypes.Health:
                                            filteredCardList.RemoveAll(x => ((Unit)x).Health == value);
                                            break;
                                        case CardListFilter.IntFilterTypes.Range:
                                            filteredCardList.RemoveAll(x => ((Unit)x).Range == value);
                                            break;
                                        case CardListFilter.IntFilterTypes.Speed:
                                            filteredCardList.RemoveAll(x => ((Unit)x).Speed == value);
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
