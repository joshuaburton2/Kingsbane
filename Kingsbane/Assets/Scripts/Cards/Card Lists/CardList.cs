using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CardList
{
    public List<Card> cardList;

    public CardList()
    {
        cardList = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cardList.Remove(card);
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
}
