using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

    private CardLibrary CardLibrary { get; set; }

    private Dictionary<Tags, List<CardData>> TagLookup { get; set; }
    private Dictionary<Synergies, List<CardData>> SynergyLookup { get; set; }
    private Dictionary<Classes.ClassList, List<CardData>> ClassLookup { get; set; }
    private Dictionary<ClassResources, List<CardData>> ClassPlayableLookup { get; set; }
    private Dictionary<CardResources, List<CardData>> ResourceLookup { get; set; }
    private Dictionary<Sets, List<CardData>> SetLookup { get; set; }
    private Dictionary<Rarity, List<CardData>> RarityLookup { get; set; }
    private Dictionary<CardTypes, List<CardData>> TypeLookup { get; set; }

    //heroLookup and heroAbilityLookup should be used when creating player heroes to add to a deck and allow the customisation of abilities on the hero card
    //These should not be used to pull the hero cards into the library
    private Dictionary<HeroTier, UnitData> HeroLookup { get; set; }
    private Dictionary<HeroTier, AbilityData> HeroAbilityLookup { get; set; }


    private readonly List<Classes.ClassList> InvalidClasses = new List<Classes.ClassList> { Classes.ClassList.Default, Classes.ClassList.Token };

    /// <summary>
    /// 
    /// Loading card library- to be called on initialisation of game
    /// 
    /// </summary>
    public void LoadLibrary()
    {
        //Load in cardList upon initialization of the game
        CardLibrary = new CardLibrary();
        CardLibrary.InitLibrary();

        LoadDirectionaries();
    }

    /// <summary>
    /// 
    /// Load the relevant cards into their appropriate dictionaries for lookup later
    /// 
    /// </summary>
    private void LoadDirectionaries()
    {
        TagLookup = ConstructDictionary<Tags>();
        SynergyLookup = ConstructDictionary<Synergies>();
        ClassLookup = ConstructDictionary<Classes.ClassList>();
        ClassPlayableLookup = ConstructDictionary<ClassResources>();
        ResourceLookup = ConstructDictionary<CardResources>();
        SetLookup = ConstructDictionary<Sets>();
        RarityLookup = ConstructDictionary<Rarity>();
        TypeLookup = ConstructDictionary<CardTypes>();

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
        foreach (var card in CardLibrary.CardList)
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
                    if (!InvalidClasses.Contains(card.Class))
                        keyList.Add((T)(object)card.Class);
                    break;
                //Class Resources type is the cards which are obtainable by a particular class (i.e. they exclusively cost resources which the class can play)
                case Type _ when type == typeof(ClassResources):
                    //Loops through all the classes in the game. If the card is playable by that class, adds it to the keylist for the card
                    foreach (var thisClass in Enum.GetValues(typeof(Classes.ClassList)).Cast<Classes.ClassList>())
                    {
                        var classResource = new ClassResources(thisClass);
                        var cardResources = card.GetResources.Select(x => x.ResourceType).ToList();

                        //Gets the count of the card resources which are also in the given classes (the intersection)- i.e. any resources on the card which are not in the class
                        //are removed
                        //If the count of the intersection is the same as the original card resources, this means that no resources were removed and as such, there are no
                        //resources in the class that are not on the card- as such, card is playable by this class
                        if (cardResources.Intersect(classResource.resources).Count() == cardResources.Count())
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
        HeroLookup = new Dictionary<HeroTier, UnitData>();
        HeroAbilityLookup = new Dictionary<HeroTier, AbilityData>();

        foreach (var cardClass in Enum.GetValues(typeof(Classes.ClassList)).Cast<Classes.ClassList>())
        {

            if (!InvalidClasses.Contains(cardClass))
            {
                //Obtain all the heroes for a particular class. Intersects the rarity lookup and the classlookup
                tempHeroLookup.Add(cardClass, RarityLookup[Rarity.Hero].Intersect(ClassLookup[cardClass]).ToList());

                foreach (var card in tempHeroLookup[cardClass])
                {
                    var heroCard = (UnitData)card;
                    var heroTier = new HeroTier() { HeroClass = cardClass, TierLevel = HeroTier.ConvertTierLevel(heroCard) };
                    HeroLookup.Add(heroTier, heroCard);

                    var heroAbility = heroCard.Abilities.FirstOrDefault(); //Should only be one element in the hero ability list
                    HeroAbilityLookup.Add(heroTier, heroAbility);
                }
            }
        }
    }

    /// <summary>
    /// 
    /// Tries to get the card list for a given dictionary key. Generic so that the key can be suited for any of the constructed dictionaries
    /// 
    /// </summary>
    public List<CardData> GetDictionaryList<T>(T key, CardFilter listFilter = null)
    {
        var dictionaryList = new List<CardData>();
        var type = typeof(T);

        switch (type)
        {
            case Type _ when type == typeof(Tags):
                TagLookup.TryGetValue((Tags)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(Synergies):
                SynergyLookup.TryGetValue((Synergies)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(Classes.ClassList):
                ClassLookup.TryGetValue((Classes.ClassList)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(ClassResources):
                ClassPlayableLookup.TryGetValue((ClassResources)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(CardResources):
                ResourceLookup.TryGetValue((CardResources)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(Sets):
                SetLookup.TryGetValue((Sets)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(Rarity):
                RarityLookup.TryGetValue((Rarity)(object)key, out dictionaryList);
                break;
            case Type _ when type == typeof(CardTypes):
                TypeLookup.TryGetValue((CardTypes)(object)key, out dictionaryList);
                break;
            default:
                throw new Exception("Not a valid Dictionary Type");
        }

        if (dictionaryList != null)
        {
            if (listFilter != null)
                return FilterCardList(dictionaryList.OrderCardList(), listFilter);
            else
                return dictionaryList.OrderCardList();
        }
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
            var heroTier = new HeroTier() { HeroClass = neededClass, TierLevel = heroTierLevel };
            var abilityTier = new HeroTier() { HeroClass = neededClass, TierLevel = abilityTierLevel };

            HeroLookup.TryGetValue(heroTier, out var heroData);
            HeroAbilityLookup.TryGetValue(abilityTier, out var abilityData);

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
        return CardLibrary.CardList.FirstOrDefault(x => x.Id == Id);
    }

    /// <summary>
    /// 
    /// Gets a card of a particular name
    /// 
    /// </summary>
    public CardData GetCard(string nameSearch)
    {
        return CardLibrary.CardList.FirstOrDefault(x => x.Name.ToLower() == nameSearch.ToLower());
    }

    /// <summary>
    /// 
    /// Gets all cards in the game with an applied filter
    /// 
    /// </summary>
    public List<CardData> GetAllCards(CardFilter listFilter)
    {
        return FilterCardList(CardLibrary.CardList.OrderCardList(), listFilter);
    }

    /// <summary>
    /// 
    /// Creates a card object which does not require a display object
    /// 
    /// </summary>
    public Card CreateCard(CardData cardData, Player owner)
    {
        Card card;

        switch (cardData.CardType)
        {
            case CardTypes.Unit:
                //Initialises unit as unit or hero
                if (cardData.Rarity == Rarity.Hero || cardData.Rarity == Rarity.NPCHero)
                    card = new Hero();
                else
                    card = new Unit();

                break;
            case CardTypes.Spell:
                card = new Spell();
                break;
            case CardTypes.Item:
                card = new Item();
                break;
            case CardTypes.Default:
            default:
                card = new Card();
                break;
        }

        card.InitCard(cardData, owner);
        return card;
    }

    /// <summary>
    /// 
    /// Instantiates a card in the scene
    /// 
    /// </summary>
    public GameObject CreateCardObject(CardData card, Transform parent, float scaling = defaultCardScaling)
    {
        var createdCard = Instantiate(cardObject, parent);
        createdCard.transform.localScale = new Vector3(scaling, scaling, 1.0f);
        //createdCard.GetComponent<RectTransform>().localScale = new Vector3(scaling, scaling, 1.0f);

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
    private void SetCardType<T>(CardData cardData, GameObject createdCard) where T : new()
    {
        //Creates the relevant script of the card type
        T typeScript = new T();

        ((Card)(object)typeScript).InitCard(cardData, null);

        createdCard.GetComponent<CardDisplay>().InitDisplay((Card)(object)typeScript);
    }

    /// <summary>
    /// 
    /// Instantiates a card of a particular Id
    /// 
    /// </summary>
    public GameObject CreateCardObject(int Id, Transform parent, float scaling = defaultCardScaling)
    {
        CardData card = GetCard(Id);

        return CreateCardObject(card, parent, scaling);
    }

    /// <summary>
    /// 
    /// Instantiates a card object in the scene where the card script already exists
    /// 
    /// </summary>
    public GameObject CreateCardObject(Card card, Transform parent, float scaling = defaultCardScaling)
    {
        var createdCard = Instantiate(cardObject, parent);
        createdCard.transform.localScale = new Vector3(scaling, scaling, 1.0f);

        createdCard.GetComponent<CardDisplay>().InitDisplay(card);

        return createdCard;
    }

    /// <summary>
    /// 
    /// Instantiates a card on a world space canvas to move around in 3d
    /// 
    /// </summary>
    public GameObject CreatedWorldCardObject(CardData card, Transform parent, float scaling = defaultCardScaling)
    {
        GameObject worldCanvas = Instantiate(cardCanvas, parent);

        CreateCardObject(card, worldCanvas.transform, scaling);

        return worldCanvas;
    }

    /// <summary>
    /// 
    /// Instantiates a card of a particular Id on a world space canvas to move around in 3d
    /// 
    /// </summary>
    public GameObject CreateWorldCardObject(int Id, Transform parent, float scaling = defaultCardScaling)
    {
        CardData card = GetCard(Id);

        return CreatedWorldCardObject(card, parent, scaling);
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
            bool failedFlag = true;

            //Search string filtering. Only active if there is a non-empty string
            //Search string also looks through the cards tags
            if (listFilter.SearchString.Length != 0)
            {
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
                if (numStringsMet != numSearchStrings)
                    continue;
            }

            //Card type filter area
            if (listFilter.CardTypeFilter.Count != 0)
            {
                foreach (var cardType in listFilter.CardTypeFilter)
                    if (card.CardType == cardType)
                    {
                        failedFlag = false;
                        break;
                    }
                if (failedFlag)
                    continue;
                failedFlag = true;
            }

            //Rarity filter area
            if (listFilter.RaritiyFilter.Count != 0)
            {
                foreach (var rarity in listFilter.RaritiyFilter)
                    if (card.Rarity == rarity)
                    {
                        failedFlag = false;
                        break;
                    }
                if (failedFlag)
                    continue;
                failedFlag = true;
            }

            //Set filter area
            if (listFilter.SetFilter.Count != 0)
            {
                foreach (var set in listFilter.SetFilter)
                    if (card.Set == set)
                    {
                        failedFlag = false;
                        break;
                    }
                if (failedFlag)
                    continue;
                failedFlag = true;
            }

            //Class playable filter area
            if (listFilter.ClassPlayableFilter != Classes.ClassList.Default)
            {
                //Filters out all heroes except the classes hero from the list
                if (card.IsHero && card.Class != listFilter.ClassPlayableFilter)
                    continue;
                //Required to ignore the classes hero for the resource filtering
                else if (!card.IsHero)
                {
                    var classResource = new ClassResources(listFilter.ClassPlayableFilter);
                    //Uses the default filter when obtaining the dictionary list. Also adds uncollectable rarity to the filter
                    var cardFilter = new CardFilter();
                    cardFilter.RaritiyFilter.Add(Rarity.Uncollectable);
                    if (!GetDictionaryList(classResource, cardFilter).Contains(card))
                        continue;
                }
            }

            //If reached this point in the loop, card can be added to the filtered list
            filteredCardList.Add(card);
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

    /// <summary>
    /// 
    /// Gets a selection of cards which are generated during a gameplay scenario
    /// 
    /// </summary>
    /// <param name="generateCardFilter">The filter to select cards by</param>
    /// <param name="numToGenerate">The number of cards to generate</param>
    public List<CardData> GenerateGameplayCards(GenerateCardFilter generateCardFilter)
    {
        //Generates the filter to look through the playable list
        var cardFilter = new CardFilter();
        if (generateCardFilter.CardType != CardTypes.Default)
            cardFilter.CardTypeFilter = new List<CardTypes>() { generateCardFilter.CardType };
        cardFilter.SetFilter = generateCardFilter.SetFilter;

        //If in the setup phase, only want to generate token cards
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Setup)
        {
            cardFilter.RaritiyFilter = new List<Rarity>() { Rarity.Token };
            generateCardFilter.IncludeUncollectables = false;
        }
        //Adds uncollectable cards if generated filter requires it
        if (generateCardFilter.IncludeUncollectables)
        {
            cardFilter.RaritiyFilter.Add(Rarity.Uncollectable);
            cardFilter.RaritiyFilter.Add(Rarity.Token);
        }

        //Gets the class playable list using the generated filter in order to ensure cards which cannot be generated outside of the players class
        var classResource = new ClassResources(generateCardFilter.ClassPlayable);
        var generatedList = GetDictionaryList(classResource, cardFilter);

        //Checks the filters not covered by the normal filtered card list
        if (!string.IsNullOrWhiteSpace(generateCardFilter.Name))
            generatedList = generatedList.Where(x => x.Name.ToLower() == generateCardFilter.Name.ToLower()).ToList();
        if (generateCardFilter.Resource != CardResources.Neutral)
            generatedList = generatedList.Intersect(GetDictionaryList(generateCardFilter.Resource)).Where(x => x.GetResources.Count == 1).ToList();
        if (generateCardFilter.Class != Classes.ClassList.Default)
            generatedList = generatedList.Intersect(GetDictionaryList(generateCardFilter.Class)).ToList();
        if (generateCardFilter.Tag != Tags.Default)
            generatedList = generatedList.Intersect(GetDictionaryList(generateCardFilter.Tag)).ToList();

        var selectedCards = new List<CardData>();
        //If the generated cards are required to be unique and there are not enough cards in the selection to be unique, does not continue with the selection
        if (!generateCardFilter.IsUnique || generateCardFilter.IsUnique && generateCardFilter.NumToGenerate <= generatedList.Count)
        {
            //Selects the number of cards required to be generated randomly from the filtered list and returns the selection
            if (generatedList.Count > 0)
            {
                for (int index = 0; index < generateCardFilter.NumToGenerate; index++)
                {
                    CardData selectedCard;
                    do
                    {
                        var randomVal = UnityEngine.Random.Range(0, generatedList.Count);
                        selectedCard = generatedList[randomVal];
                    } while (generateCardFilter.IsUnique && selectedCards.Select(x => x.Id).Contains(selectedCard.Id));
                    selectedCards.Add(selectedCard);
                }
            }
        }

        return selectedCards;
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

        //Set up the filter and resources and obtain the cards playable by the relevant class
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
            var scalingSynergyWeighting = 0;
            foreach (var synergy in card.Synergies)
            {
                if (deckSynergyCounts.TryGetValue(synergy, out int synergyCount))
                {
                    //Debug.Log($"{card.Name}, {synergy}, {Mathf.Max(1, synergyCount * synergyWeighting - scalingSynergyWeighting)}");
                    lootCard.Weighting += Mathf.Max(1, synergyCount * synergyWeighting - scalingSynergyWeighting);
                    scalingSynergyWeighting++;
                }
            }

            //Reduces the weighting of the card based on the number of that card already in the deck
            var duplicateCount = deckData.CardList.Count(x => x.Id == card.Id);

            lootCard.Weighting += duplicateCount * duplicateWeighting;

            //Prevents weighting from being considered if it is below 0
            if (lootCard.Weighting > 0)
            {
                //Debug.Log($"{card.Name}, {lootCard.Weighting}");
                lootCards.Add(lootCard);
            }

            totalWeighting += lootCard.Weighting;
        }

        var lootSelection = new List<LootCard>();

        //Loops through the number of cards which are required to be randomly determined
        for (int randomCardNum = 0; randomCardNum < numCards; randomCardNum++)
        {
            var selectedLootCard = new LootCard();

            //do
            //{
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
                //If the selection already contains the card, repeats the random selection (TURNED OFF FOR NOW)
            //} while (lootSelection.Where(x => x.CardData.Id == selectedLootCard.CardData.Id).Any());

            lootSelection.Add(selectedLootCard);
        }

        return lootSelection;
    }
}

public static class CardListExtensions
{
    /// <summary>
    /// 
    /// Orders the card list with the default ordering
    /// 
    /// </summary>
    public static List<CardData> OrderCardList(this List<CardData> cardList)
    {
        //Note that the resource ordering is descending since the values are negative
        return cardList.OrderByDescending(x => x.HighestResource).ThenBy(x => x.Name).ThenBy(x => x.CardType).ToList();
    }
}
