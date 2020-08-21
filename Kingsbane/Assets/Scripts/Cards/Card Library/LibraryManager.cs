using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CardOrdering
{
    None,
    Classes,
    Resources
}

public class LibraryManager : MonoBehaviour
{
    [SerializeField]
    //Card Object for rendering on 2D canvas
    private GameObject cardObject;
    [SerializeField]
    //World Space Canvas for rendering cards in world
    private GameObject cardCanvas;

    private List<CardData> cardList;

    private Dictionary<Tags, List<CardData>> tagLookup;
    private Dictionary<Synergies, List<CardData>> synergyLookup;

    private void Start()
    {
        //Load in cardList upon initialisation of the game
        CardLibrary cardLibrary;

        cardLibrary = new CardLibrary();
        cardLibrary.InitLibrary();

        cardList = cardLibrary.CardList;

        LoadDirectionaries();
    }

    private void LoadDirectionaries()
    {
        foreach (var card in cardList)
        {
            foreach (var tag in card.Tags)
            {
                if (!tagLookup.ContainsKey(tag))
                {
                    tagLookup.Add(tag, new List<CardData>() { card });
                }
                else
                {
                    tagLookup[tag].Add(card);
                }
            }

            foreach (var synergy in card.Synergies)
            {
                if (!synergyLookup.ContainsKey(synergy))
                {
                    synergyLookup.Add(synergy, new List<CardData>() { card });
                }
                else
                {
                    synergyLookup[synergy].Add(card);
                }
            }
        }
    }

    public List<CardData> GetCardsWithTag(Tags tag)
    {
        tagLookup.TryGetValue(tag, out var cardList);
        return cardList;
    }

    public List<CardData> GetCardsWithSynergy(Synergies synergy)
    {
        synergyLookup.TryGetValue(synergy, out var cardList);
        return cardList;
    }

    public CardData GetCard(int Id)
    {
        return cardList.FirstOrDefault(x => x.Id == Id);
    }

    public List<CardData> GetAllCards(CardOrdering cardOrdering)
    {
        List<CardData> orderedCardList = new List<CardData>();

        switch (cardOrdering)
        {
            case CardOrdering.Classes:
                orderedCardList = cardList;
                orderedCardList.OrderBy(x => x.Class);
                break;
            case CardOrdering.Resources:
                foreach (CardResources resource in Enum.GetValues(typeof(CardResources)).Cast<CardResources>().ToList())
                {
                    List<CardData> resourceList = new List<CardData>();

                    foreach (var card in cardList)
                    {
                        if (card.GetResources.FirstOrDefault(x => x.ResourceType == resource) != null)
                        {
                            resourceList.Add(card);
                        }
                    }

                    orderedCardList.AddRange(resourceList);
                }
                break;
            case CardOrdering.None:
                orderedCardList = cardList;
                break;
        }

        orderedCardList.OrderBy(x => x.TotalResource);

        return orderedCardList;
    }

    public List<List<CardData>> GetAllCardsSplit(CardOrdering cardOrdering)
    {
        List<List<CardData>> allCardsSplit = new List<List<CardData>>();

        List<CardData> allCards = GetAllCards(cardOrdering);

        switch (cardOrdering)
        {
            case CardOrdering.Classes:
                allCardsSplit = SplitCardList<Classes.ClassList>(allCards);
                break;
            case CardOrdering.Resources:
                allCardsSplit = SplitCardList<CardResources>(allCards);
                break;
        }

        return allCardsSplit;
    }

    private List<List<CardData>> SplitCardList<T>(List<CardData> cardList) where T : Enum
    {
        List<List<CardData>> splitList = new List<List<CardData>>();

        foreach (var splitType in Enum.GetValues(typeof(T)).Cast<T>().ToList())
        {
            splitList[(int)(object)splitType] = new List<CardData>();
        }

        return splitList;
    }

    public GameObject CreateCard(CardData card, Transform parent)
    {
        GameObject createdCard = Instantiate(cardObject, parent);

        CardDisplay cardDisplay;

        switch (card.CardType)
        {
            case CardTypes.Unit:
                Unit unitScript = (Unit)createdCard.AddComponent(typeof(Unit));

                unitScript.cardData = card;

                cardDisplay = createdCard.GetComponent<CardDisplay>();
                cardDisplay.card = unitScript;
                break;
            case CardTypes.Spell:
                Spell spellScript = (Spell)createdCard.AddComponent(typeof(Spell));

                spellScript.cardData = card;

                cardDisplay = createdCard.GetComponent<CardDisplay>();
                cardDisplay.card = spellScript;
                break;
            case CardTypes.Item:
                Item itemScript = (Item)createdCard.AddComponent(typeof(Item));

                itemScript.cardData = card;

                cardDisplay = createdCard.GetComponent<CardDisplay>();
                cardDisplay.card = itemScript;
                break;
            default:
                Card cardScript = (Card)createdCard.AddComponent(typeof(Card));

                cardScript.cardData = card;

                cardDisplay = createdCard.GetComponent<CardDisplay>();
                cardDisplay.card = cardScript;
                break;
        }

        cardDisplay.InitDisplay();

        return createdCard;
    }

    public GameObject CreateCard(int Id, Transform parent)
    {
        CardData card = GetCard(Id);

        return CreateCard(card, parent);
    }

    public GameObject CreatedWorldCard(CardData card, Transform parent)
    {
        GameObject worldCanvas = Instantiate(cardCanvas, parent);

        CreateCard(card, worldCanvas.transform);

        return worldCanvas;
    }

    public GameObject CreateWorldCard(int Id, Transform parent)
    {
        CardData card = GetCard(Id);

        return CreatedWorldCard(card, parent);
    }
}
