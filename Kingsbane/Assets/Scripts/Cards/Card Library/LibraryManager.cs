using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cardObject;

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
        foreach (var card in cardList)
        {
            if(card.Id == Id)
            {
                return card;
            }
        }

        return new CardData();
    }

    public List<CardData> GetAllCards()
    {
        return cardList;
    }

    public List<CardData> GetRelatedCards(int Id)
    {
        CardData card = GetCard(Id);
        return card.RelatedCards;
    }

    public GameObject CreateCard(CardData card)
    {
        GameObject createdCard = Instantiate(cardObject);

        Card cardScript = (Card)createdCard.AddComponent(typeof(Card));

        switch (card.CardType)
        {
            case CardTypes.Unit:
                Unit unitScript = (Unit)cardScript;
                break;
            case CardTypes.Spell:
                Spell spellScript = (Spell)cardScript;
                break;
            case CardTypes.Item:
                Item itemScript = (Item)cardScript;
                break;
            case CardTypes.Default:
            default:
                break;
        }

        

        return createdCard;
        
    }

    public GameObject CreateCard(int Id)
    {
        CardData card = GetCard(Id);

        return CreateCard(card);
    }
}
