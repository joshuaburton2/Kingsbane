using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : CardList
{


    public Deck(List<CardData> _cardList, Player player)
    {
        cardList = new List<Card>();

        foreach (var cardData in _cardList)
        {
            var card = GameManager.instance.libraryManager.CreateCard(cardData, player);
            card.CreatedByName = "";
            AddToDeck(card, trackShuffle: false);
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
        int currentCount = ListCount;
        //Tests if there are cards in the deck to draw
        if(currentCount != 0)
        {
            //Saves the card to return and removes it from the deck list
            var drawnCard = cardList.LastOrDefault();
            cardList.Remove(drawnCard);

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
            int currentCount = ListCount;
            //Tests if there are cards in the deck to draw
            if (currentCount != 0)
            {
                //Saves the card to return and removes it from the deck list
                drawnCards.Add(cardList.LastOrDefault());
                cardList.Remove(drawnCards.LastOrDefault());
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

    public Card Draw(CardListFilter filter, out bool failedFilter, int? numToChoose = null)
    {
        int currentCount = ListCount;
        failedFilter = false;

        if (currentCount != 0)
        {
            var filteredDeck = FilterCardList(filter);

            if (filteredDeck.cardList.Count != 0)
            {
                if (numToChoose == null)
                {
                    var drawnCard = filteredDeck.cardList.LastOrDefault();
                    cardList.Remove(drawnCard);

                    return drawnCard;
                }
                else
                {
                    if (numToChoose.Value > filteredDeck.ListCount)
                        numToChoose = filteredDeck.ListCount;

                    var cardChoiceList = new List<Card>();
                    var completedList = false;
                    for (int choiceIndex = 0; choiceIndex < numToChoose; choiceIndex++)
                    {
                        for (int cardIndex = 0; cardIndex < filteredDeck.ListCount; cardIndex++)
                        {
                            var card = filteredDeck.cardList[filteredDeck.ListCount - 1 - cardIndex];
                            if (cardChoiceList.Select(x => x.Name).Contains(card.Name))
                            {
                                if (cardIndex == filteredDeck.ListCount - 1)
                                {
                                    completedList = true;
                                    break;
                                }
                                continue;
                            }
                            cardChoiceList.Add(card);
                            break;
                        }

                        if (completedList)
                            break;
                    }

                    GameManager.instance.effectManager.SetDrawChoiceMode(cardChoiceList);

                    return null;
                }
            }
            else
            {
                failedFilter = true;
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public Card Draw(Card card)
    {
        if (cardList.Contains(card))
        {
            cardList.Remove(card);
            return card;
        }
        else
        {
            return null;
        }
    }

    public List<Card> Draw(int numToDraw, CardListFilter filter, out int failedDraws, out bool failedFilter)
    {
        var drawnCards = new List<Card>();

        failedDraws = numToDraw;
        failedFilter = false;

        for (int count = 0; count < numToDraw; count++)
        {
            int currentCount = ListCount;

            if (currentCount != 0)
            {
                var filteredDeck = FilterCardList(filter);

                if (filteredDeck.cardList.Count != 0)
                {
                    drawnCards.Add(filteredDeck.cardList.LastOrDefault());
                    cardList.Remove(drawnCards.LastOrDefault());
                    failedDraws--;
                }
                else
                {
                    failedFilter = true;
                    break;
                }
            }
            else
            {
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
    public void ShuffleIntoDeck(Card card, string createdBy = "", bool trackShuffle = true)
    {
        //Randomises the position to shuffle to. Adds 1 to maximum since this will be adding a new card to the deck
        int randPos = UnityEngine.Random.Range(0, ListCount + 1);

        AddToDeck(card, randPos, createdBy, trackShuffle);
    }

    public void ShuffleIntoDeck(Card card, string createdBy, DeckPositions deckPosition, bool trackShuffle = true)
    {
        switch (deckPosition)
        {
            case DeckPositions.Random:
                ShuffleIntoDeck(card, createdBy, trackShuffle);
                break;
            case DeckPositions.First:
                int firstPos = ListCount;
                AddToDeck(card, firstPos, createdBy, trackShuffle);
                break;
            case DeckPositions.Last:
                int lastPos = 0;
                AddToDeck(card, lastPos, createdBy, trackShuffle);
                break;
            default:
                throw new Exception("Not a valid deck position");
        }
    }

    /// <summary>
    /// 
    /// Shuffle a list of cards into random posistions in the deck
    /// 
    /// </summary>
    public void ShuffleIntoDeck(List<Card> cards, string createdBy = "", bool trackShuffle = true)
    {
        foreach (var card in cards)
            ShuffleIntoDeck(card, createdBy, trackShuffle);
    }

    /// <summary>
    /// 
    /// Adds a card to the deck in a specific position
    /// 
    /// </summary>
    /// <param name="card">The card to add</param>
    /// <param name="position">The position in the deck to add it to. Note that cards are drawn from the end of the list</param>
    public void AddToDeck(Card card, int position = 0, string createdBy = "", bool trackShuffle = true)
    {
        if (!string.IsNullOrWhiteSpace(createdBy))
            card.CreatedByName = createdBy;
        
        int currentCount = ListCount;

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

        if (trackShuffle)
            card.NumShuffles++;
    }

    #endregion

    /// <summary>
    /// 
    /// Shuffles the deck in a random order
    /// 
    /// </summary>
    public void Shuffle()
    {
        int currentCount = ListCount;

        //Loops through all positions in the deck to ensure they all move at least once
        for (int currentPos = 0; currentPos < currentCount; currentPos++)
        {
            int randPos = UnityEngine.Random.Range(0, currentCount);

            //Swaps the cards in each position
            var randCard = cardList[randPos];
            cardList[randPos] = cardList[currentPos];
            cardList[currentPos] = randCard;
        }
    }

    
}
