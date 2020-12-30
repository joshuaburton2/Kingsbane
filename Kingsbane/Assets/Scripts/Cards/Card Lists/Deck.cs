using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : CardList
{
    public int DeckCount { get { return cardList.Count; } }

    public Deck(List<CardData> _cardList, Player player)
    {
        cardList = new List<Card>();

        foreach (var cardData in _cardList)
        {
            var card = GameManager.instance.libraryManager.CreateCard(cardData, player);
            AddToDeck(card);
        }
    }

    #region Draw Function
    /// <summary>
    /// 
    /// Draw a single card from the deck. The card is drawn from the last position in the list
    /// 
    /// </summary>
    /// <returns>Returns the card drawn. If there is no card in the deck, returns an empty card object</returns>
    public Card Draw()
    {
        int currentCount = DeckCount;
        //Tests if there are cards in the deck to draw
        if(currentCount != 0)
        {
            //Saves the card to return and removes it from the deck list
            var drawnCard = cardList[DeckCount - 1];
            cardList.RemoveAt(DeckCount - 1);

            return drawnCard;
        }
        else
        {
            //If there are no cards left in the deck, returns a new game object
            return null;
        }
    }

    /// <summary>
    /// 
    /// Draw a certain number of cards from the deck. The cards are drawn from the subsequen last positions in the deck
    /// 
    /// </summary>
    /// <param name="numToDraw">The number of cards to draw</param>
    /// <param name="failedDraws">If the player tries to draw a number of cards greater than the number left in the deck, this number will be the difference</param>
    /// <returns>The list of cards drawn. If list is smaller than numToDraw, then there were not enough cards in the deck to draw</returns>
    public List<Card> Draw(int numToDraw, out int failedDraws)
    {
        var drawnCards = new List<Card>();

        failedDraws = numToDraw;

        for (int count = 0; count < numToDraw; count++)
        {
            int currentCount = DeckCount;
            //Tests if there are cards in the deck to draw
            if (currentCount != 0)
            {
                //Saves the card to return and removes it from the deck list
                drawnCards.Add(cardList[DeckCount - 1]);
                cardList.RemoveAt(DeckCount - 1);
                failedDraws--;
            }
            else
            {
                //If there are no cards left in the deck ends the loop
                break;
            }
        }

        return drawnCards;
    }
    #endregion

    #region Deck Addition Functions
    /// <summary>
    /// 
    /// Shuffle a card into a random position in the deck
    /// 
    /// </summary>
    public void ShuffleIntoDeck(Card card)
    {
        //Randomises the position to shuffle to. Adds 1 to maximum since this will be adding a new card to the deck
        int randPos = Random.Range(0, DeckCount + 1);

        AddToDeck(card, randPos);
    }

    /// <summary>
    /// 
    /// Shuffle a list of cards into random posistions in the deck
    /// 
    /// </summary>
    public void ShuffleIntoDeck(List<Card> cards)
    {
        foreach (var card in cards)
            ShuffleIntoDeck(card);
    }

    /// <summary>
    /// 
    /// Adds a card to the deck in a specific position
    /// 
    /// </summary>
    /// <param name="card">The card to add</param>
    /// <param name="position">The position in the deck to add it to. Note that cards are drawn from the end of the list</param>
    public void AddToDeck(Card card, int position = 0)
    {
        int currentCount = DeckCount;

        //Clamps the position to ensure it isn't outside the bounds of the deck
        position = Mathf.Clamp(position, 0, currentCount);

        //Tests if the new card is in the last position or not
        if(position != currentCount)
        {
            //Add a new card to the deck as a duplicate of the card already in the last position
            cardList.Add(cardList[currentCount - 1]);

            //Loops down through the upper part of the list, shifting all cards one position up to account for the new card addition.
            //This will essentially duplicate each card one position up, and then overwrite the original with each iteration of the loop
            for (int i = currentCount - 1; i > position; i--)
            {
                cardList[i] = cardList[i - 1];
            }

            //Add the new card at the desired position
            cardList[position] = card;
        }
        else
        {
            //If the new card is in the last position of the list, adds it
            cardList.Add(card);
        }   
    }

    #endregion

    /// <summary>
    /// 
    /// Shuffles the deck in a random order
    /// 
    /// </summary>
    public void Shuffle()
    {
        int currentCount = DeckCount;

        //Loops through all positions in the deck to ensure they all move at least once
        for (int currentPos = 0; currentPos < currentCount; currentPos++)
        {
            int randPos = Random.Range(0, currentCount);

            //Swaps the cards in each position
            var randCard = cardList[randPos];
            cardList[randPos] = cardList[currentPos];
            cardList[currentPos] = randCard;
        }
    }

    
}
