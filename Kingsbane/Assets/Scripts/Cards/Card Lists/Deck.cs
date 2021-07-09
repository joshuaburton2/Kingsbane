using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CategoryEnums;

public class Deck : CardList
{
    private Player player { get; set; }

    public Deck(List<CardData> _cardList, Player _player)
    {
        List = new List<Card>();
        player = _player;

        //Initialise each card in the list
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
            var drawnCard = List.LastOrDefault();
            List.Remove(drawnCard);

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
                drawnCards.Add(List.LastOrDefault());
                List.Remove(drawnCards.LastOrDefault());
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

    /// <summary>
    /// 
    /// Draw a card from the deck using a filter
    /// 
    /// </summary>
    public Card Draw(CardListFilter filter, out bool failedFilter, int? numToChoose = null)
    {
        int currentCount = ListCount;
        failedFilter = false;

        //If the current count of the deck is 0, then cannot draw any cards
        if (currentCount != 0)
        {
            //Obtains the filtered list based on the list filter
            var filteredDeck = FilterCardList(filter);

            //If there are no cards that meet the filter criteria, returns null and fails the filter
            if (filteredDeck.List.Count != 0)
            {
                //If num to choose is null, does not require a choice mode and just draws 1 card that meets the filter
                if (numToChoose == null)
                {
                    //Removes the drawn card from the deck and returns it (note that last or default is used as the top of the deck is the bottom of the list)
                    var drawnCard = filteredDeck.List.LastOrDefault();
                    List.Remove(drawnCard);

                    return drawnCard;
                }
                //If num to choose is not null, need to grab cards for the choice mode
                else
                {
                    //Gets the top number of cards from the filtered card list, capping it out at 0
                    var cardChoiceList = List.Skip(Mathf.Max(0, filteredDeck.ListCount - numToChoose.Value)).Reverse().ToList();

                    //Sets the choice mode up to display
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

    /// <summary>
    /// 
    /// Draws the given card. If it does not exist in the deck, returns null
    /// 
    /// </summary>
    public Card Draw(Card card)
    {
        if (List.Contains(card))
        {
            List.Remove(card);
            return card;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// Draws a given number of cards based on a filter
    /// 
    /// </summary>
    public List<Card> Draw(int numToDraw, CardListFilter filter, out int failedDraws, out bool failedFilter)
    {
        var drawnCards = new List<Card>();

        //Sets up the failed parameters
        failedDraws = numToDraw;
        failedFilter = false;

        //Loops for each card required to draw
        for (int count = 0; count < numToDraw; count++)
        {
            int currentCount = ListCount;

            //fails out of the loop if the deck count is 0
            if (currentCount != 0)
            {
                //Filters the card list and stores the deck
                var filteredDeck = FilterCardList(filter);

                //If there are no cards that meet the filter, fails the filter and breaks out of the loop
                if (filteredDeck.List.Count != 0)
                {
                    //If successful filter, draws the card
                    drawnCards.Add(filteredDeck.List.LastOrDefault());
                    List.Remove(drawnCards.LastOrDefault());
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

    /// <summary>
    /// 
    /// Shuffles a card into a given preset position
    /// 
    /// </summary>
    public void ShuffleIntoDeck(Card card, string createdBy, DeckPositions deckPosition, bool trackShuffle = true)
    {
        switch (deckPosition)
        {
            case DeckPositions.Random:
                ShuffleIntoDeck(card, createdBy, trackShuffle);
                break;
            case DeckPositions.First:
                //Note that the first position in the deck is the last position in the deck
                int firstPos = ListCount;
                AddToDeck(card, firstPos, createdBy, trackShuffle);
                break;
            case DeckPositions.Last:
                //The last position in the deck is the first position in the list
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

        //Inserts the card at the required position
        List.Insert(position, card);

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
            var randCard = List[randPos];
            List[randPos] = List[currentPos];
            List[currentPos] = randCard;
        }
    }

    /// <summary>
    /// 
    /// Gets the top n cards of the deck
    /// 
    /// </summary>
    public List<Card> GetTopCards(int numToGet)
    {
        return List.Skip(Mathf.Max(0, ListCount - numToGet)).Reverse().ToList();
    }
    
}
