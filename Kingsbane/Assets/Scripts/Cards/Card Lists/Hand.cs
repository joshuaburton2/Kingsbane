using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardList
{
    private const int maxHandSize = 10;

    public int HandCount { get { return cardList.Count; } }

    /// <summary>
    /// 
    /// Adds a card to the hand
    /// 
    /// </summary>
    /// <param name="card">The card to add</param>
    /// <returns>Whether the card could be added or not</returns>
    public bool AddToHand(Card card)
    {
        //Checks if the hand is to full to take another card. If not adds the card. Otherwise returns false
        if (HandCount < maxHandSize)
        {
            cardList.Add(card);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 
    /// Adds a list of cards to the hand
    /// 
    /// </summary>
    /// <param name="cards">The list of cards to add</param>
    /// <returns>The list of cards which could not be added</returns>
    public List<Card> AddToHand(List<Card> cards)
    {
        var failedCards = cards;

        foreach (var cardToAdd in cards)
        {
            //Checks if the hand is to full to take another card. If not adds, the card and removes it from the list of failed cards
            //If the hand grows larger than its max hand size at any point, then it breaks from the loop and returns the cards which were
            //not added
            if (HandCount < maxHandSize)
            {
                cardList.Add(cardToAdd);
                failedCards.Remove(cardToAdd);
            }
            else
            {
                break;
            }
        }

        return failedCards;
    }
}
