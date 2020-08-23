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

        cardList = cardLibrary.CardList;

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

        foreach (var card in cardList)
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
                    keyList = card.GetResources.Select(x => x.ResourceType) as List<T>;
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

        return newDictionary;
    }

    public List<CardData> GetDictionaryList<T> (T key) where T : Enum
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

        return OrderCardList(dictionaryList);
    }

    public CardData GetCard(int Id)
    {
        return cardList.FirstOrDefault(x => x.Id == Id);
    }

    public List<CardData> GetAllCards()
    {
        return OrderCardList(cardList);
    }

    private List<CardData> OrderCardList(List<CardData> cardList)
    {
        return cardList.OrderBy(x => x.Rarity).ThenBy(x => x.TotalResource).ThenBy(x => x.Name).ThenBy(x => x.CardType).ToList();
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
        orderedCardList.OrderBy(x => x.Name);

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

        return allCardsSplit.Where(x => x.Count != 0).ToList();
    }

    private List<List<CardData>> SplitCardList<T>(List<CardData> cardList) where T : Enum
    {
        var splitList = new List<List<CardData>>();

        foreach (var splitType in Enum.GetValues(typeof(T)).Cast<T>().ToList())
        {
            var splitItems = new List<CardData>();
            foreach (var card in cardList)
            {
                var type = typeof(T);
                switch (type)
                {
                    case Type _ when type == typeof(Classes.ClassList):
                        if (card.Class == (Classes.ClassList)(object)splitType)
                            splitItems.Add(card);
                        break;
                    case Type _ when type == typeof(CardResources):
                        if (card.GetResources.Any(x => x.ResourceType == (CardResources)(object)splitType))
                            splitItems.Add(card);
                        break;
                    default:
                        break;
                }
            }
            splitList.Add(splitItems);
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
                unitScript.InitCard();

                cardDisplay = createdCard.GetComponent<CardDisplay>();
                cardDisplay.card = unitScript;
                break;
            case CardTypes.Spell:
                Spell spellScript = (Spell)createdCard.AddComponent(typeof(Spell));

                spellScript.cardData = card;
                spellScript.InitCard();

                cardDisplay = createdCard.GetComponent<CardDisplay>();
                cardDisplay.card = spellScript;
                break;
            case CardTypes.Item:
                Item itemScript = (Item)createdCard.AddComponent(typeof(Item));

                itemScript.cardData = card;
                itemScript.InitCard();

                cardDisplay = createdCard.GetComponent<CardDisplay>();
                cardDisplay.card = itemScript;
                break;
            default:
                Card cardScript = (Card)createdCard.AddComponent(typeof(Card));

                cardScript.cardData = card;
                cardScript.InitCard();

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
