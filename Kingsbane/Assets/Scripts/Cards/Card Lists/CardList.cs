using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardList
{
    public List<Card> cardList;

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

    public CardList FilterCardList(CardListFilter filter)
    {
        var filteredCardList = new List<Card>();

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

            bool intFilterFlag = false;

            foreach (var intFilter in filter.IntFilters)
            {
                if (intFilter.Value.Key != IntValueFilter.None)
                {
                    int? value = null;
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

                    if (value.HasValue)
                    {
                        if (!IntValueFilterer.CheckIntValueFilter(value.Value, intFilter.Value))
                        {
                            intFilterFlag = true;
                            break;
                        }
                    }
                }
            }

            if (intFilterFlag)
                continue;

            filteredCardList.Add(card);
        }

        foreach (var intFilter in filter.IntFilters)
        {
            if (intFilter.Value.Key == IntValueFilter.Highest)
            {
                switch (intFilter.Key)
                {
                    case CardListFilter.IntFilterTypes.Cost:
                        filteredCardList = filteredCardList.Where(x => x.TotalResource == filteredCardList.Min(y => y.TotalResource)).ToList();
                        break;
                    case CardListFilter.IntFilterTypes.Attack:
                        filteredCardList = filteredCardList.Cast<Unit>().Where(x => x.Attack == filteredCardList.Cast<Unit>().Max(y => y.Attack)).Cast<Card>().ToList();
                        break;
                    case CardListFilter.IntFilterTypes.Health:
                        filteredCardList = filteredCardList.Cast<Unit>().Where(x => x.Health == filteredCardList.Cast<Unit>().Max(y => y.Health)).Cast<Card>().ToList();
                        break;
                    case CardListFilter.IntFilterTypes.Range:
                        filteredCardList = filteredCardList.Cast<Unit>().Where(x => x.Range == filteredCardList.Cast<Unit>().Max(y => y.Range)).Cast<Card>().ToList();
                        break;
                    case CardListFilter.IntFilterTypes.Speed:
                        filteredCardList = filteredCardList.Cast<Unit>().Where(x => x.Speed == filteredCardList.Cast<Unit>().Max(y => y.Speed)).Cast<Card>().ToList();
                        break;
                    case CardListFilter.IntFilterTypes.SpellRange:
                        filteredCardList = filteredCardList.Cast<Spell>().Where(x => x.SpellRange == filteredCardList.Cast<Spell>().Max(y => y.SpellRange)).Cast<Card>().ToList();
                        break;
                    case CardListFilter.IntFilterTypes.Durability:
                        filteredCardList = filteredCardList.Cast<Item>().Where(x => x.Durability == filteredCardList.Cast<Item>().Max(y => y.Durability)).Cast<Card>().ToList();
                        break;
                    default:
                        break;
                }
            }
            else if (intFilter.Value.Key == IntValueFilter.Lowest)
            {
                switch (intFilter.Key)
                {
                    case CardListFilter.IntFilterTypes.Cost:
                        filteredCardList = filteredCardList.Where(x => x.TotalResource == filteredCardList.Max(y => y.TotalResource)).ToList();
                        break;
                    case CardListFilter.IntFilterTypes.Attack:
                        filteredCardList = filteredCardList.Cast<Unit>().Where(x => x.Attack == filteredCardList.Cast<Unit>().Min(y => y.Attack)).Cast<Card>().ToList();
                        break;
                    case CardListFilter.IntFilterTypes.Health:
                        filteredCardList = filteredCardList.Cast<Unit>().Where(x => x.Health == filteredCardList.Cast<Unit>().Min(y => y.Health)).Cast<Card>().ToList();
                        break;
                    case CardListFilter.IntFilterTypes.Range:
                        filteredCardList = filteredCardList.Cast<Unit>().Where(x => x.Range == filteredCardList.Cast<Unit>().Min(y => y.Range)).Cast<Card>().ToList();
                        break;
                    case CardListFilter.IntFilterTypes.Speed:
                        filteredCardList = filteredCardList.Cast<Unit>().Where(x => x.Speed == filteredCardList.Cast<Unit>().Min(y => y.Speed)).Cast<Card>().ToList();
                        break;
                    case CardListFilter.IntFilterTypes.SpellRange:
                        filteredCardList = filteredCardList.Cast<Spell>().Where(x => x.SpellRange == filteredCardList.Cast<Spell>().Min(y => y.SpellRange)).Cast<Card>().ToList();
                        break;
                    case CardListFilter.IntFilterTypes.Durability:
                        filteredCardList = filteredCardList.Cast<Item>().Where(x => x.Durability == filteredCardList.Cast<Item>().Min(y => y.Durability)).Cast<Card>().ToList();
                        break;
                    default:
                        break;
                }
            }
        }

        return new CardList(filteredCardList);
    }
}
