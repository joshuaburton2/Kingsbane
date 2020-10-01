using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootGeneratorUI : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField]
    private GameObject lootArea;
    [SerializeField]
    private DeckListUI deckListUI;
    [SerializeField]
    private Button addSelectedButton;
    [SerializeField]
    private Button refreshButton;
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

    private string CardsToSelectString { get { return (numCardsToSelect - cardsSelected.Count).ToString(); } }
    public bool FullCardsSelected { get { return numCardsToSelect == cardsSelected.Count; } }

    public void RefreshLootGenerator()
    {
        foreach (Transform child in lootArea.transform)
        {
            Destroy(child.gameObject);
        }

        addSelectedButton.interactable = false;

        var selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(deckListUI.DeckEditId.Value);
        var lootCards = GameManager.instance.libraryManager.GenerateLootCards(selectedDeck, numLootCards, out int totalWeighting);

        cardsSelected = new List<CardData>();
        cardsToSelectText.text = CardsToSelectString;

        foreach (var lootCard in lootCards)
        {
            var cardContainer = Instantiate(cardDisplayContainer, lootArea.transform);

            cardContainer.name = $"Container {lootCard.CardData.Name}";
            var cardLibaryContainer = cardContainer.GetComponentInChildren<CardLibraryContainer>();
            var cardName = $"Card {lootCard.CardData.Name}";
            cardLibaryContainer.InitCardContainer(lootCard.CardData, deckListUI, cardName, scalingFactor, this);

            var lootStatsObject = Instantiate(lootStatPrefab, cardLibaryContainer.transform);
            var weightingPercentage = Math.Round((float)lootCard.Weighting / totalWeighting * 100, 2);
            lootStatsObject.GetComponent<TextMeshProUGUI>().text = $"Weighting: {lootCard.Weighting} Chance: {weightingPercentage}%";
        }
    }

    public void SelectLootCard(CardData cardData)
    {
        cardsSelected.Add(cardData);
        cardsToSelectText.text = CardsToSelectString;

        if (FullCardsSelected)
        {
            addSelectedButton.interactable = true;
        }
    }

    public void RemoveLootCard(CardData cardData)
    {
        cardsSelected.Remove(cardData);
        cardsToSelectText.text = CardsToSelectString;
        addSelectedButton.interactable = false;
    }

    public void AddCardsToDeck()
    {
        var updatedDeck = GameManager.instance.deckManager.AddRangeToPlayerDeck(deckListUI.DeckEditId.Value, cardsSelected);

        deckListUI.activeDeckCardList.RefreshCardList(updatedDeck, deckListUI, deckListUI.DeckEditId.Value);
        RefreshLootGenerator();
    }
}
