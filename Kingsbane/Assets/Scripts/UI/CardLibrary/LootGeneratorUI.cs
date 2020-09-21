using System.Collections;
using System.Collections.Generic;
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

    [Header("Loot Properties")]
    [SerializeField]
    private int numLootCards;

    public void RefreshLootGenerator()
    {

        addSelectedButton.interactable = false;

        var selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(deckListUI.DeckEditId.Value);
        var lootCards = GameManager.instance.libraryManager.GenerateLootCards(selectedDeck, numLootCards, out int totalWeighting);

        foreach (var lootCard in lootCards)
        {

        }
    }
}
