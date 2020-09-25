using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    [Serializable]
    private class RarityWeighting
    {
        public Rarity rarity;
        public int weighting;
    }

    [Header("Card Prefabs")]
    [SerializeField]
    //Card Object for rendering on 2D canvas
    private GameObject cardObject;
    [SerializeField]
    //World Space Canvas for rendering cards in world
    private GameObject cardCanvas;

    private const float defaultCardScaling = 0.37f;

    [Header("Loot Weightings")]
    [SerializeField]
    private List<RarityWeighting> rarityWeightings;
    [SerializeField]
    private int classWeighting;
    [SerializeField]
    private int synergyWeighting;
    [SerializeField]
    private int duplicateWeighting;

    private CardLibrary cardLibrary;

    private Dictionary<Tags, List<CardData>> tagLookup;
    private Dictionary<Synergies, List<CardData>> synergyLookup;
    private Dictionary<Classes.ClassList, List<CardData>> classLookup;
    private Dictionary<ClassResources, List<CardData>> classPlayableLookup;
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

    /// <summary>
    /// 
    /// Load deck templates from the card library
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Load the relevant cards into their appropriate dictionaries for lookup later
    /// 
    /// </summary>
    private void LoadDirectionaries()
    {
        tagLookup = ConstructDictionary<Tags>();
        synergyLookup = ConstructDictionary<Synergies>();
        classLookup = ConstructDictionary<Classes.ClassList>();
        classPlayableLookup = ConstructDictionary<ClassResources>();
        resourceLookup = ConstructDictionary<CardResources>();
        setLookup = ConstructDictionary<Sets>();
        rarityLookup = ConstructDictionary<Rarity>();
        typeLookup = ConstructDictionary<CardTypes>();

        ConstructHeroLookup();
    }

    /// <summary>
    /// 
    /// Constructs a dictionary of a generic type. The keys are the different values which the type can be and the card list is
    /// the cards which are part of that key. These dictionaries are only intended to be constructed on startup
    /// 
    /// </summary>
    private Dictionary<T, List<CardData>> ConstructDictionary<T>()
    {
        var newDictionary = new Dictionary<T, List<CardData>>();

        // Loop through all cards and obtain which keys in the dictionary that card falls into
        foreach (var card in cardLibrary.CardList)
        {
            var keyList = new List<T>();
            var type = typeof(T);

            //Constructs the keylist the card falls into. The keylist is constructed depending on the type of key that the dictionary uses.
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
                //Class Resources type is the cards which are obtainable by a particular class (i.e. they exclusively cost resources which the class can play)
                case Type _ when type == typeof(ClassResources):
                    //Loops through all the classes in the game. If the card is playable by that class, adds it to the keylist for the card
                    foreach (var thisClass in Enum.GetValues(typeof(Classes.ClassList)).Cast<Classes.ClassList>())
                    {
                        var classResource = new ClassResources(thisClass);
                        var classResources = classResource.resources;

                        var cardResources = card.GetResources.Select(x => x.ResourceType).ToList();

                        var metResources = true;

                        //Loops through all the resources the card costs. If the resource on the card costs a resource that the class cannot play, then
                        // it will fail the test, and the ClassResources is not added as a key
                        foreach (var resource in cardResources)
                        {
                            if (!classResources.Contains(resource))
                            {
                                metResources = false;
                                break;
                            }
                        }
                        if (metResources)
                        {
                            keyList.Add((T)(object)classResource);
                        }
                    }
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

            //Loops through the keylist and adds the card to the relevant key in the dictionary
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

    /// <summary>
    /// 
    /// Constructs the hero lookup dictionary. The hero lookup is used to construct the different combinations of heroes and abilities
    /// 
    /// </summary>
    private void ConstructHeroLookup()
    {
        var tempHeroLookup = new Dictionary<Classes.ClassList, List<CardData>>();
        heroLookup = new Dictionary<HeroTier, UnitData>();
        heroAbilityLookup = new Dictionary<HeroTier, AbilityData>();

        foreach (var cardClass in Enum.GetValues(typeof(Classes.ClassList)).Cast<Classes.ClassList>())
        {
            if (cardClass != Classes.ClassList.Default)
            {
                //Obtain all the heroes for a particular class. Intersects the rarity lookup and the classlookup
                tempHeroLookup.Add(cardClass, rarityLookup[Rarity.Hero].Intersect(classLookup[cardClass]).ToList());

                foreach (var card in tempHeroLookup[cardClass])
                {
                    var heroCard = (UnitData)card;
                    var heroTier = new HeroTier() { heroClass = cardClass, tierLevel = HeroTier.ConvertTierLevel(heroCard) };
                    heroLookup.Add(heroTier, heroCard);

                    var heroAbility = heroCard.Abilities.FirstOrDefault(); //Should only be one element in the hero ability list
                    heroAbilityLookup.Add(heroTier, heroAbility);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// Tries to get the card list for a given dictionary key. Generic so that the key can be suited for any of the constructed dictionaries
    /// 
    /// </summary>
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
            case Type _ when type == typeof(ClassResources):
                classPlayableLookup.TryGetValue((ClassResources)(object)key, out dictionaryList);
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
            return FilterCardList(OrderCardList(dictionaryList), listFilter);
        else
            return new List<CardData>();
    }

    /// <summary>
    /// 
    /// Gets a hero of a particular tier level and class
    /// 
    /// </summary>
    public UnitData GetHero(Classes.ClassList neededClass, TierLevel heroTierLevel, TierLevel abilityTierLevel)
    {
        if (neededClass != Classes.ClassList.Default)
        {
            var heroTier = new HeroTier() { heroClass = neededClass, tierLevel = heroTierLevel };
            var abilityTier = new HeroTier() { heroClass = neededClass, tierLevel = abilityTierLevel };

            heroLookup.TryGetValue(heroTier, out var heroData);
            heroAbilityLookup.TryGetValue(abilityTier, out var abilityData);

            //Removes the default ability on the hero card and replaces it with the required ability
            heroData.Abilities.Clear();
            heroData.Abilities.Add(abilityData);

            return heroData;
        }
        else
        {
            throw new Exception("Cannot get hero from Default class");
        }
    }

    /// <summary>
    /// 
    /// Gets a card of a particular Id
    /// 
    /// </summary>
    public CardData GetCard(int Id)
    {
        return cardLibrary.CardList.FirstOrDefault(x => x.Id == Id);
    }

    /// <summary>
    /// 
    /// Gets a card of a particular name
    /// 
    /// </summary>
    public CardData GetCard(string nameSearch)
    {
        return cardLibrary.CardList.FirstOrDefault(x => x.Name.ToLower().Contains(nameSearch.ToLower()));
    }

    /// <summary>
    /// 
    /// Gets all cards in the game with an applied filter
    /// 
    /// </summary>
    public List<CardData> GetAllCards(CardFilter listFilter)
    {
        return FilterCardList(OrderCardList(cardLibrary.CardList), listFilter);
    }

    /// <summary>
    /// 
    /// Orders the card list with the default ordering
    /// 
    /// </summary>
    public static List<CardData> OrderCardList(List<CardData> cardList)
    {
        //Note that the resource ordering is descending since the values are negative
        return cardList.OrderByDescending(x => x.HighestResource).ThenBy(x => x.Name).ThenBy(x => x.CardType).ToList();
    }

    /// <summary>
    /// 
    /// Instantiates a card in the scene
    /// 
    /// </summary>
    public GameObject CreateCard(CardData card, Transform parent, float scaling = defaultCardScaling)
    {
        GameObject createdCard = Instantiate(cardObject, parent);
        createdCard.GetComponent<RectTransform>().localScale = new Vector3(scaling, scaling, 1.0f);

        switch (card.CardType)
        {
            case CardTypes.Unit:
                SetCardType<Unit>(card, createdCard);
                break;
            case CardTypes.Spell:
                SetCardType<Spell>(card, createdCard);
                break;
            case CardTypes.Item:
                SetCardType<Item>(card, createdCard);
                break;
            default:
                SetCardType<Card>(card, createdCard);
                break;
        }

        return createdCard;
    }

    /// <summary>
    /// 
    /// Sets the card type of the card object. 
    /// 
    /// </summary>
    private void SetCardType<T>(CardData cardData, GameObject createdCard)
    {
        //Adds the relevant script of the card type to the game object
        T typeScript = (T)(object)createdCard.AddComponent(typeof(T));

        ((Card)(object)typeScript).InitCard(cardData);

        createdCard.GetComponent<CardDisplay>().InitDisplay((Card)(object)typeScript);
    }

    /// <summary>
    /// 
    /// Instantiates a card of a particular Id
    /// 
    /// </summary>
    public GameObject CreateCard(int Id, Transform parent, float scaling = defaultCardScaling)
    {
        CardData card = GetCard(Id);

        return CreateCard(card, parent, scaling);
    }

    /// <summary>
    /// 
    /// Instantiates a card on a world space canvas to move around in 3d
    /// 
    /// </summary>
    public GameObject CreatedWorldCard(CardData card, Transform parent, float scaling = defaultCardScaling)
    {
        GameObject worldCanvas = Instantiate(cardCanvas, parent);

        CreateCard(card, worldCanvas.transform, scaling);

        return worldCanvas;
    }

    /// <summary>
    /// 
    /// Instantiates a card of a particular Id on a world space canvas to move around in 3d
    /// 
    /// </summary>
    public GameObject CreateWorldCard(int Id, Transform parent, float scaling = defaultCardScaling)
    {
        CardData card = GetCard(Id);

        return CreatedWorldCard(card, parent, scaling);
    }

    /// <summary>
    /// 
    /// Applies a filter to a a given card list and returns it. Options to filter a card list are:
    /// - A search string
    /// - Card types
    /// - Rarities
    /// - Sets
    /// - Whether the card is playable by a class
    /// 
    /// </summary>
    public List<CardData> FilterCardList(List<CardData> cardList, CardFilter listFilter)
    {
        var searchStrings = listFilter.SearchStrings;
        var numSearchStrings = searchStrings.Count;

        var filteredCardList = new List<CardData>();

        foreach (var card in cardList)
        {
            //In order for a card to be added to the filter, it needs to meet all the active filters in the Card Filter object
            var numActiveFilters = 0;
            var numMetFilters = 0;

            //Search string filtering. Only active if there is a non-empty string
            //Search string also looks through the cards tags
            if (listFilter.SearchString.Length != 0)
            {
                numActiveFilters++;

                var numStringsMet = 0;

                foreach (var searchString in searchStrings)
                {
                    if (searchString.Length > 0)
                    {
                        //First checks if the search string is a tag. Note the true property is to ignore the case of the string
                        var isTag = Enum.TryParse(searchString.Replace(" ", ""), true, out Tags tag);
                        if (isTag)
                        {
                            if (card.Tags.Contains(tag))
                                numStringsMet++;
                            else
                            {
                                //Even if the search string is a tag, it is still possible that the card text or name contains the search string
                                //As such, even if the card doesn't have the tag, still checks through the other search fields
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

                //If the card contains all the given search terms, then it meets the filter
                if (numStringsMet == numSearchStrings)
                    numMetFilters++;
            }

            //Card type filter area
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

            //Rarity filter area
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

            //Set filter area
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

            //Class playable filter area
            if (listFilter.ClassPlayableFilter != Classes.ClassList.Default)
            {
                numActiveFilters++;
                //Filters out all heroes from the list
                if (!card.IsHero)
                {
                    var classResource = new ClassResources(listFilter.ClassPlayableFilter);
                    //Uses the default filter when obtaining the dictionary list. Also adds uncollectable rarity to the filter
                    var cardFilter = new CardFilter();
                    cardFilter.RaritiyFilter.Add(Rarity.Uncollectable);
                    if (GetDictionaryList(classResource, cardFilter).Contains(card))
                    {
                        numMetFilters++;
                    }
                }
            }

            //If the num of active filters are all met on the card, the card passes the filter
            if (numMetFilters == numActiveFilters)
            {
                filteredCardList.Add(card);
            }
        }

        return filteredCardList;
    }

    /// <summary>
    /// 
    /// Checks if the card name, the card text or the card abilities contains a particular search string
    /// 
    /// </summary>
    private static bool CardStringContainsSearch(CardData card, string searchString)
    {
        searchString = searchString.ToLower();
        var abilityMet = false;

        //Only unit cards will have an ability
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

    public class LootCard
    {
        public CardData CardData { get; set; }
        public int Weighting { get; set; }
    }

    /// <summary>
    /// 
    /// Generates a list of random cards for loot based on the properties of a given deck
    /// 
    /// </summary>
    public List<LootCard> GenerateLootCards(DeckData deckData, int numCards, out int totalWeighting)
    {
        //Totals the number of cards in a deck which have a particular synergy
        var deckSynergyCounts = new Dictionary<Synergies, int>();
        foreach (var card in deckData.CardList)
        {
            foreach (var synergy in card.Synergies)
            {
                if (!deckSynergyCounts.ContainsKey(synergy))
                {
                    deckSynergyCounts.Add(synergy, 1);
                }
                else
                {
                    deckSynergyCounts[synergy] += 1;
                }
            }
        }

        var lootCards = new List<LootCard>();
        totalWeighting = 0;

        var cardFilter = new CardFilter();
        var classResource = new ClassResources(deckData.DeckClass);
        var classPlayableList = GetDictionaryList(classResource, cardFilter);

        //Loops through all the cards which are possible to be played by a class and determines their weighting in the random selection
        foreach (var card in classPlayableList)
        {
            var lootCard = new LootCard()
            {
                CardData = card,
                Weighting = 0,
            };

            //Add the weighting of the rarity of the card
            lootCard.Weighting += rarityWeightings.FirstOrDefault(x => x.rarity == card.Rarity).weighting;

            //Adds the class weighting if the card is of the decks class
            if (card.Class == deckData.DeckClass)
            {
                lootCard.Weighting += classWeighting;
            }

            //If the card shares synergies with the cards already in the deck, increases the weighting accordingly
            foreach (var synergy in card.Synergies)
            {
                if (deckSynergyCounts.TryGetValue(synergy, out int synergyCount))
                {
                    lootCard.Weighting += synergyCount * synergyWeighting;
                }
            }

            //Reduces the weighting of the card based on the number of that card already in the deck
            var duplicateCount = deckData.CardList.Count(x => x.Id == card.Id);
            lootCard.Weighting += duplicateCount * duplicateWeighting;

            lootCards.Add(lootCard);
            totalWeighting += lootCard.Weighting;
        }

        var lootSelection = new List<LootCard>();

        //Loops through the number of cards which are required to be randomly determined
        for (int randomCardNum = 0; randomCardNum < numCards; randomCardNum++)
        {
            var selectedLootCard = new LootCard();

            do
            {
                //Randomly determines a card to be added
                //First determines a random weighting
                var randomVal = UnityEngine.Random.Range(0, totalWeighting);
                var weightingIndex = 0;

                //Runs through all the possible cards and the weighting
                foreach (var lootCard in lootCards)
                {
                    weightingIndex += lootCard.Weighting;

                    //If the random weighting is within the weighting range of the card, it is the card that is randomly selected
                    if (randomVal < weightingIndex)
                    {
                        selectedLootCard = lootCard;
                        break;
                    }
                }
            //If the selection already contains the card, repeats the random selection
            } while (lootSelection.Where(x => x.CardData.Id == selectedLootCard.CardData.Id).Any());

            lootSelection.Add(selectedLootCard);
        }

        return lootSelection;
    }
}
