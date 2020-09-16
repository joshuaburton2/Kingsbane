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

    private CardLibrary cardLibrary;

    private Dictionary<Tags, List<CardData>> tagLookup;
    private Dictionary<Synergies, List<CardData>> synergyLookup;
    private Dictionary<Classes.ClassList, List<CardData>> classLookup;
    private Dictionary<CardResources, List<CardData>> resourceLookup;
    private Dictionary<Sets, List<CardData>> setLookup;
    private Dictionary<Rarity, List<CardData>> rarityLookup;
    private Dictionary<CardTypes, List<CardData>> typeLookup;

    //heroLookup and heroAbilityLookup should be used when creating player heroes to add to a deck and allow the customisation of abilities on the hero card
    //These should not be used to pull the hero cards into the library
    private Dictionary<HeroTier, UnitData> heroLookup;
    private Dictionary<HeroTier, AbilityData> heroAbilityLookup;

    private void Start()
    {
        //Load in cardList upon initialization of the game
        cardLibrary = new CardLibrary();
        cardLibrary.InitLibrary();

        LoadDirectionaries();
        LoadDeckTemplates();        
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

        ConstructHeroLookup();
    }

    private void LoadDeckTemplates()
    {
        var deckTemplates = cardLibrary.ClassDeckList;
        foreach (var classDecks in deckTemplates.Values)
        {
            foreach (var deck in classDecks)
            {
                deck.CardList = OrderCardList(deck.CardList);
            }
        }
        GameManager.instance.deckManager.DeckTemplates = deckTemplates;
    }

    private Dictionary<T, List<CardData>> ConstructDictionary<T>() where T : Enum
    {
        var newDictionary = new Dictionary<T, List<CardData>>();

        foreach (var card in cardLibrary.CardList)
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

    private void ConstructHeroLookup()
    {
        var tempHeroLookup = new Dictionary<Classes.ClassList, List<CardData>>();
        heroLookup = new Dictionary<HeroTier, UnitData>();
        heroAbilityLookup = new Dictionary<HeroTier, AbilityData>();

        foreach (var cardClass in Enum.GetValues(typeof(Classes.ClassList)).Cast<Classes.ClassList>())
        {
            if (cardClass != Classes.ClassList.Default)
            {
                tempHeroLookup.Add(cardClass, rarityLookup[Rarity.Hero].Intersect(classLookup[cardClass]).ToList());

                foreach (var card in tempHeroLookup[cardClass])
                {
                    var heroCard = (UnitData)card;
                    var heroTier = new HeroTier() { heroClass = cardClass, tierLevel = HeroTier.ConvertTierLevel(heroCard) };
                    heroLookup.Add(heroTier, heroCard);

                    var heroAbility = heroCard.Abilities[0]; //Should only be one element in the hero ability list
                    heroAbilityLookup.Add(heroTier, heroAbility);
                }
            }
        }
    }

    public List<CardData> GetDictionaryList<T>(T key, CardFilter listFilter)
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
            default:
                throw new Exception("Not a valid Dictionary Type");
        }

        if (dictionaryList != null)
        {
            return FilterCardList(OrderCardList(dictionaryList), listFilter);
        } 
        else
            return new List<CardData>();
    }

    public UnitData GetHero (Classes.ClassList neededClass, TierLevel heroTierLevel, TierLevel abilityTierLevel )
    {
        if (neededClass != Classes.ClassList.Default)
        {
            var heroTier = new HeroTier() { heroClass = neededClass, tierLevel = heroTierLevel };
            var abilityTier = new HeroTier() { heroClass = neededClass, tierLevel = abilityTierLevel };

            heroLookup.TryGetValue(heroTier, out var heroData);
            heroAbilityLookup.TryGetValue(abilityTier, out var abilityData);

            heroData.Abilities.Clear();
            heroData.Abilities.Add(abilityData);

            return heroData;
        }
        else
        {
            throw new Exception("Cannot get hero from Default class");
        }
    }

    public CardData GetCard(int Id)
    {
        return cardLibrary.CardList.FirstOrDefault(x => x.Id == Id);
    }

    public CardData GetCard(string nameSearch)
    {
        return cardLibrary.CardList.FirstOrDefault(x => x.Name.ToLower().Contains(nameSearch.ToLower()));
    }

    public List<CardData> GetAllCards(CardFilter listFilter)
    {
        return FilterCardList(OrderCardList(cardLibrary.CardList), listFilter);
    }

    public static List<CardData> OrderCardList(List<CardData> cardList)
    {
        return cardList.OrderByDescending(x => x.HighestResource).ThenBy(x => x.Name).ThenBy(x => x.CardType).ToList();
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

    private void SetCardType<T>(CardData cardData, GameObject createdCard, out CardDisplay cardDisplay)
    {
        T typeScript = (T)(object)createdCard.AddComponent(typeof(T));

        ((Card)(object)typeScript).InitCard(cardData);

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
        var numSearchStrings = searchStrings.Count;

        var newCardList = new List<CardData>();

        foreach (var card in cardList)
        {
            var numActiveFilters = 0;
            var numMetFilters = 0;

            if (listFilter.SearchString.Length != 0)
            {
                numActiveFilters++;

                var numStringsMet = 0;

                foreach (var searchString in searchStrings)
                {
                    if (searchString.Length > 0)
                    {
                        var isTag = Enum.TryParse(searchString.Replace(" ", ""), true, out Tags tag);
                        if (isTag)
                        {
                            if (card.Tags.Contains(tag))
                                numStringsMet++;
                            else
                            {
                                if (CardStringContainsSearch(card, searchString))
                                    numStringsMet++;
                            }
                        }
                        else
                        {
                            if (CardStringContainsSearch(card, searchString))
                                numStringsMet++;
                        }
                    }
                }

                if (numStringsMet == numSearchStrings)
                    numMetFilters++;
            }


            if (listFilter.CardTypeFilter.Count != 0)
            {
                numActiveFilters++;

                foreach (var cardType in listFilter.CardTypeFilter)
                    if (card.CardType == cardType)
                    {
                        numMetFilters++;
                        break;
                    }
            }

            if (listFilter.RaritiyFilter.Count != 0)
            {
                numActiveFilters++;

                foreach (var rarity in listFilter.RaritiyFilter)
                    if (card.Rarity == rarity)
                    { 
                        numMetFilters++;
                        break;
                    }
            }

            if (listFilter.SetFilter.Count != 0)
            {
                numActiveFilters++;

                foreach (var set in listFilter.SetFilter)
                    if (card.Set == set)
                    {
                        numMetFilters++;
                        break;
                    }
            }

            if (listFilter.ResourceFilter.Count != 0)
            {
                numActiveFilters++;
                var cardResources = card.GetResources.Select(x => x.ResourceType).ToList();
                var numResourcesMet = listFilter.ResourceFilter.Count;
                foreach (var resource in cardResources)
                {
                    if (!listFilter.ResourceFilter.Contains(resource))
                    {
                        numResourcesMet--;
                    }
                }

                if (numResourcesMet == listFilter.ResourceFilter.Count)
                {
                    numMetFilters++;
                }
            }

            

            if (numMetFilters == numActiveFilters)
            {
                newCardList.Add(card);
            }
        }

        return newCardList;
    }

    private static bool CardStringContainsSearch(CardData card, string searchString)
    {
        searchString = searchString.ToLower();
        var abilityMet = false;

        if (card.CardType == CardTypes.Unit)
        {
            var unit = (UnitData)card;
            
            foreach (var ability in unit.Abilities)
            {
                if (ability.Text.ToLower().Contains(searchString))
                {
                    abilityMet = true;
                    break;
                }
            }
        }
        return card.Name.ToLower().Contains(searchString) 
            || card.Text.ToLower().Contains(searchString)
            || abilityMet;
    }
}
