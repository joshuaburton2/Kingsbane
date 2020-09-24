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

    [Header("Prefabs")]
    [SerializeField]
    private GameObject cardDisplayContainer;
    [SerializeField]
    private GameObject lootStatPrefab;

    [Header("Loot Properties")]
    [SerializeField]
    private int numLootCards;

    [Header("Other Properties")]
    [SerializeField]
    private float scalingFactor;

    public void RefreshLootGenerator()
    {
        foreach (Transform child in lootArea.transform)
        {
            Destroy(child.gameObject);
        }

        addSelectedButton.interactable = false;

        var selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(deckListUI.DeckEditId.Value);
        var lootCards = GameManager.instance.libraryManager.GenerateLootCards(selectedDeck, numLootCards, out int totalWeighting);

        foreach (var lootCard in lootCards)
        {
            var cardContainer = Instantiate(cardDisplayContainer, lootArea.transform);

            cardContainer.name = $"Container {lootCard.CardData.Name}";
            var cardLibaryContainer = cardContainer.GetComponentInChildren<CardLibraryContainer>();
            var cardName = $"Card {lootCard.CardData.Name}";
            cardLibaryContainer.InitCardContainer(lootCard.CardData, deckListUI, cardName, scalingFactor);

            var lootStatsObject = Instantiate(lootStatPrefab, cardLibaryContainer.transform);
            var weightingPercentage = Math.Round((float)lootCard.Weighting / totalWeighting * 100, 2);
            lootStatsObject.GetComponent<TextMeshProUGUI>().text = $"Weighting: {lootCard.Weighting} Chance: {weightingPercentage}%";
        }
    }
}
