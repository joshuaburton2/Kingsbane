using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// Script for handling the Loot Generator UI
/// 
/// </summary>
public class LootGeneratorUI : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField]
    private GameObject lootArea;
    [SerializeField]
    private DeckListUI deckListUI;
    [SerializeField]
    private CampaignManagerUI campaignManagerUI;
    [SerializeField]
    private Button addSelectedButton;
    [SerializeField]
    private TextMeshProUGUI cardsToSelectText;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject cardDisplayContainer;
    [SerializeField]
    private GameObject lootStatPrefab;

    [Header("Loot Properties")]
    [SerializeField]
    private int numLootCards;
    [SerializeField]
    private int numCardsToSelect;
    private List<CardData> cardsSelected;

    [Header("Other Properties")]
    [SerializeField]
    private float scalingFactor;

    //String to show how many cards the player still needs to select
    private string CardsToSelectString { get { return (numCardsToSelect - cardsSelected.Count).ToString(); } }
    //Boolean to determine if the player has selected the full number of cards to select
    public bool FullCardsSelected { get { return numCardsToSelect == cardsSelected.Count; } }

    /// <summary>
    /// 
    /// Refreshes the loot generator with a new set of cards
    /// 
    /// </summary>
    public List<LootCard> RefreshLootGenerator(List<LootCard> lootCards = null, int totalWeighting = 0)
    {
        if (deckListUI != null && campaignManagerUI != null)
            throw new Exception("UI not initialised properly");

        //Refreshed the loot grid
        GameManager.DestroyAllChildren(lootArea);

        addSelectedButton.interactable = false;

        //Gets the current deck and the generated loot cards
        DeckData selectedDeck = null;
        if (deckListUI != null)
        {
            selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(deckListUI.DeckEditId.Value);
        }
        else if (campaignManagerUI != null)
        {
            selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(campaignManagerUI.loadedDeck.Id.Value);
        }

        if (lootCards == null)
            lootCards = GameManager.instance.libraryManager.GenerateLootCards(selectedDeck, numLootCards, out totalWeighting);

        cardsSelected = new List<CardData>();

        //Sets the text of the number of cards to select
        cardsToSelectText.text = CardsToSelectString;

        //Loop through each card in the generated loot cards
        foreach (var lootCard in lootCards)
        {
            //Initialises a new container for the loot card
            var cardContainer = Instantiate(cardDisplayContainer, lootArea.transform);
            cardContainer.name = $"Container {lootCard.CardData.Name}";
            var cardLibaryContainer = cardContainer.GetComponentInChildren<CardLibraryContainer>();
            var cardName = $"Card {lootCard.CardData.Name}";
            cardLibaryContainer.InitCardContainer(lootCard.CardData, deckListUI, campaignManagerUI, cardName, scalingFactor, this);

            //Displays the loot properties of the card in text below the card
            var lootStatsObject = Instantiate(lootStatPrefab, cardLibaryContainer.transform);
            var weightingPercentage = Math.Round((float)lootCard.Weighting / totalWeighting * 100, 2);
            lootStatsObject.GetComponent<TextMeshProUGUI>().text = $"Weighting: {lootCard.Weighting} Chance: {weightingPercentage}%";
        }

        return lootCards;
    }

    /// <summary>
    /// 
    /// Event for clicking on a loot card when it is unselected
    /// 
    /// </summary>
    public void SelectLootCard(CardData cardData)
    {
        cardsSelected.Add(cardData);
        cardsToSelectText.text = CardsToSelectString;

        if (FullCardsSelected)
        {
            addSelectedButton.interactable = true;
        }
    }

    /// <summary>
    /// 
    /// Event for clicking on a loot card when it is selected
    /// 
    /// </summary>
    public void RemoveLootCard(CardData cardData)
    {
        cardsSelected.Remove(cardData);
        cardsToSelectText.text = CardsToSelectString;
        addSelectedButton.interactable = false;
    }

    /// <summary>
    /// 
    /// Button click event for adding the selected cards to deck
    /// 
    /// </summary>
    public void AddCardsToDeck()
    {
        if (deckListUI != null)
        {
            var updatedDeck = GameManager.instance.deckManager.AddCardsToPlayerDeck(deckListUI.DeckEditId.Value, cardsSelected);

            deckListUI.RefreshActiveDeckDetails(updatedDeck);
            RefreshLootGenerator();
        }
        else if (campaignManagerUI != null)
        {
            GameManager.instance.deckManager.AddCardsToPlayerDeck(campaignManagerUI.loadedDeck.Id.Value, cardsSelected);

            campaignManagerUI.AddLootCards();
        }
    }

    /// <summary>
    /// 
    /// Button click event for refreshing the selected loot cards
    /// 
    /// </summary>
    public void RefreshCards()
    {
        RefreshLootGenerator();
    }
}
