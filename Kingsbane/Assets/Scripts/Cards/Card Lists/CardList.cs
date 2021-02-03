using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEnums;

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
            var numActiveFilters = 0;
            var numMetFilters = 0;

            if (filter.Name.Length > 0)
            {
                numActiveFilters++;
                if (filter.Name.Contains(card.Name))
                {
                    numMetFilters++;
                }
            }

            if (filter.Rarity != Rarity.Default)
            {
                numActiveFilters++;
                if (filter.Rarity == card.Rarity)
                {
                    numMetFilters++;
                }
            }

            if (numMetFilters == numActiveFilters)
            {
                filteredCardList.Add(card);
            }
        }

        return new CardList(filteredCardList);
    }
}
