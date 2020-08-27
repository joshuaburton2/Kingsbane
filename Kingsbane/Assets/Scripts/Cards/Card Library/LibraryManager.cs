﻿using CategoryEnums;
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

    private List<CardData> newCardList;

    private Dictionary<Tags, List<CardData>> tagLookup;
    private Dictionary<Synergies, List<CardData>> synergyLookup;
    private Dictionary<Classes.ClassList, List<CardData>> classLookup;
    private Dictionary<CardResources, List<CardData>> resourceLookup;
    private Dictionary<Sets, List<CardData>> setLookup;
    private Dictionary<Rarity, List<CardData>> rarityLookup;
    private Dictionary<CardTypes, List<CardData>> typeLookup;

    private void Start()
    {
        //Load in cardList upon initialisation of the game
        CardLibrary cardLibrary;

        cardLibrary = new CardLibrary();
        cardLibrary.InitLibrary();

        newCardList = cardLibrary.CardList;

        LoadDirectionaries();
    }

    private void LoadDirectionaries()
    {
        tagLookup = ConstructDictionary<Tags>();
        synergyLookup = ConstructDictionary<Synergies>();
        classLookup = ConstructDictionary<Classes.ClassList>();
        resourceLookup = ConstructDictionary<CardResources>();
        setLookup = ConstructDictionary<Sets>();
        rarityLookup = ConstructDictionary<Rarity>();
        typeLookup = ConstructDictionary<CardTypes>();
    }

    private Dictionary<T, List<CardData>> ConstructDictionary<T>() where T : Enum
    {
        var newDictionary = new Dictionary<T, List<CardData>>();

        foreach (var card in newCardList)
        {
            var keyList = new List<T>();
            var type = typeof(T);

            switch (type)
            {
                case Type _ when type == typeof(Tags):
                    keyList = card.Tags as List<T>;
                    break;
                case Type _ when type == typeof(Synergies):
                    keyList = card.Synergies as List<T>;
                    break;
                case Type _ when type == typeof(Classes.ClassList):
                    keyList.Add((T)(object)card.Class);
                    break;
                case Type _ when type == typeof(CardResources):
                    keyList = card.GetResources.Select(x => x.ResourceType).Cast<T>().ToList();
                    break;
                case Type _ when type == typeof(Sets):
                    keyList.Add((T)(object)card.Set);
                    break;
                case Type _ when type == typeof(Rarity):
                    keyList.Add((T)(object)card.Rarity);
                    break;
                case Type _ when type == typeof(CardTypes):
                    keyList.Add((T)(object)card.CardType);
                    break;
            }

            if (keyList != null)
            {
                foreach (var key in keyList)
                {
                    if (!newDictionary.ContainsKey(key))
                    {
                        newDictionary.Add(key, new List<CardData>() { card });
                    }
                    else
                    {
                        newDictionary[key].Add(card);
                    }
                }
            }
        }

        return newDictionary;
    }

    public List<CardData> GetDictionaryList<T>(T key, CardFilter listFilter) where T : Enum
    {
        var dictionaryList = new List<CardData>();
        var type = typeof(T);

        switch (type)
        {
            case Type _ when type == typeof(Tags):
                tagLookup.TryGetValue((Tags)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(Synergies):
                synergyLookup.TryGetValue((Synergies)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(Classes.ClassList):
                classLookup.TryGetValue((Classes.ClassList)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(CardResources):
                resourceLookup.TryGetValue((CardResources)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(Sets):
                setLookup.TryGetValue((Sets)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(Rarity):
                rarityLookup.TryGetValue((Rarity)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(CardTypes):
                typeLookup.TryGetValue((CardTypes)(object)key, out dictionaryList);
                break;
        }

        if (dictionaryList != null)
            return FilterCardList(OrderCardList(dictionaryList), listFilter);
        else
            return new List<CardData>();
    }

    public CardData GetCard(int Id)
    {
        return newCardList.FirstOrDefault(x => x.Id == Id);
    }

    public List<CardData> GetAllCards(CardFilter listFilter)
    {
        return FilterCardList(OrderCardList(newCardList), listFilter);
    }

    private List<CardData> OrderCardList(List<CardData> cardList)
    {
        return cardList.OrderByDescending(x => x.TotalResource).ThenBy(x => x.Name).ThenBy(x => x.CardType).ToList();
    }

    public GameObject CreateCard(CardData card, Transform parent)
    {
        GameObject createdCard = Instantiate(cardObject, parent);

        CardDisplay cardDisplay;

        switch (card.CardType)
        {
            case CardTypes.Unit:
                SetCardType<Unit>(card, createdCard, out cardDisplay);
                break;
            case CardTypes.Spell:
                SetCardType<Spell>(card, createdCard, out cardDisplay);
                break;
            case CardTypes.Item:
                SetCardType<Item>(card, createdCard, out cardDisplay);
                break;
            default:
                SetCardType<Card>(card, createdCard, out cardDisplay);
                break;
        }

        cardDisplay.InitDisplay();

        return createdCard;
    }

    private void SetCardType<T>(CardData card, GameObject createdCard, out CardDisplay cardDisplay)
    {
        T typeScript = (T)(object)createdCard.AddComponent(typeof(T));

        ((Card)(object)typeScript).cardData = card;
        ((Card)(object)typeScript).InitCard();

        cardDisplay = createdCard.GetComponent<CardDisplay>();
        cardDisplay.card = (Card)(object)typeScript;
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

    public List<CardData> FilterCardList(List<CardData> cardList, CardFilter listFilter)
    {
        var searchStrings = listFilter.SearchStrings;

        var newCardList = new List<CardData>();

        foreach (var card in cardList)
        {
            var numActiveFilters = 0;
            var numMetFilters = 0;

            if (listFilter.SearchString.Length != 0)
            {
                numActiveFilters++;

                foreach (var searchString in searchStrings)
                {
                    if (searchString.Length > 0)
                    {
                        var isTag = Enum.TryParse(searchString, out Tags tag);
                        if (isTag)
                        {
                            if (card.Tags.Contains(tag))
                                numMetFilters++;
                        }
                        else
                        {
                            if (card.Name.Contains(searchString) || card.Text.Contains(searchString))
                                numMetFilters++;
                        }
                    }
                }
            }


            if (listFilter.CardTypeFilter.Count != 0)
            {
                numActiveFilters++;

                foreach (var cardType in listFilter.CardTypeFilter)
                    if (card.CardType == cardType)
                    {
                        numMetFilters++;
                    }
            }

            if (listFilter.RaritiyFilter.Count != 0)
            {
                numActiveFilters++;

                foreach (var rarity in listFilter.RaritiyFilter)
                    if (card.Rarity == rarity)
                    { 
                        numMetFilters++;
                    }
            }

            if (listFilter.SetFilter.Count != 0)
            {
                numActiveFilters++;

                foreach (var set in listFilter.SetFilter)
                    if (card.Set == set)
                    {
                        numMetFilters++;
                    }
            }

            if (numMetFilters == numActiveFilters)
            {
                Debug.Log(card.Name);
                newCardList.Add(card);
            }
        }

        return newCardList;
    }
}
