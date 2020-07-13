using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;

    public Deck deck;
    public Hand hand;

    public int[] playerResources = new int[] { 0, 0, 0, 0, 0 };

    int counter;

    private void Start()
    {
        counter = 0;
    }

    #region Draw Functions
    public void Draw()
    {
        GameObject drawnCard = deck.Draw();

        if(drawnCard != null)
        {
            drawnCard.transform.parent = hand.gameObject.transform;
            hand.AddToHand(drawnCard);
        }
        else
        {
            Debug.Log("Deck is empty");
        }
    }

    public void Draw(int numToDraw)
    {
        List<GameObject> drawnCards = deck.Draw(numToDraw, out int failedDraws);

        if(drawnCards.Count != 0)
        {
            foreach (GameObject drawnCard in drawnCards)
            {
                drawnCard.transform.parent = hand.gameObject.transform;
                hand.AddToHand(drawnCard);
            }
        }
        else
        {
            Debug.Log("Deck is empty");
        }
    }

    #endregion

    public void AddTestCard(GameObject testPrefab)
    {
        GameObject newCard = Instantiate(testPrefab, deck.gameObject.transform);
        newCard.name = $"Card {counter}";
        counter++;

        deck.AddToDeck(newCard, deck.DeckCount);
    }
}
