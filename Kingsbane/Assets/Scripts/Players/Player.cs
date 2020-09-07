using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Player : MonoBehaviour
{
    public string playerName;
    public Classes.ClassList playerClass = Classes.ClassList.Default;

    public Deck defaultDeck; //Deck to be persisted between scenarios
    public Deck deck; //Deck to be accessed during a scenario
    public Hand hand;

    public List<Resource> resources;
    public List<CardResources> usedResources;

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
        usedResources = Classes.GetClassData(playerClass).GetClassResources();

        resources = new List<Resource>();
        foreach (var resource in usedResources)
        {
            resources.Add(new Resource() { ResourceType = resource });
        }
    }

    /// <summary>
    /// 
    /// Calculates the difference in resources if an effect is to change them
    /// 
    /// </summary>
    /// <param name="resource">The resource which is being modified as well as the relevant value</param>
    public Resource CalcNewResource(Resource resource)
    {
        return new Resource()
        {
            ResourceType = resource.ResourceType,
            Value = resources.First(x => x.ResourceType == resource.ResourceType).Value + resource.Value
        };
    }

    /// <summary>
    /// 
    /// Modifies a particular player resource with a given resource value
    /// 
    /// </summary>
    public void ModifyResources(Resource resource)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            if (resource.ResourceType == resources[i].ResourceType)
            {
                resources[i] = CalcNewResource(resource);
            }
        }
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
