using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public List<CardData> GetCardsWithTag (Tags tag)
    {
        tagLookup.TryGetValue(tag, out var cardList);
        return cardList;
    }

    public List<CardData> GetCardsWithSynergy (Synergies synergy)
    {
        synergyLookup.TryGetValue(synergy, out var cardList);
        return cardList;
    }

    public CardData GetCard(int Id)
    {
        return cardList.FirstOrDefault(x => x.Id == Id);
    }

    public List<CardData> GetAllCards()
    {
        return cardList;
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
