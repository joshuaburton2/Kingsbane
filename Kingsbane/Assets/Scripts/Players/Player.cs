using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public Classes.ClassList playerClass = Classes.ClassList.Default;

    public Deck defaultDeck; //Deck to be persisted between scenarios
    public Deck deck; //Deck to be accessed during a scenario
    public Hand hand;

    public int[] playerResources;
    public Resources.ResourceList[] usedResources;
    private const int NUM_RESOURCES = 6;

    int counter;

    private void Start()
    {
        counter = 0;

        ResourceInit();
    }

    /// <summary>
    /// 
    /// Initialises the resource list used by the class. To be called on start
    /// 
    /// </summary>
    private void ResourceInit()
    {
        playerResources = new int[NUM_RESOURCES];

        usedResources = Classes.GetClassResource(playerClass);
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
