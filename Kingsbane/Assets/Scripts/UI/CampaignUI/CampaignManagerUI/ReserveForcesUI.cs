using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReserveForcesUI : MonoBehaviour
{
    private CampaignManagerUI campaignManagerUI;

    [SerializeField]
    private DeckCardListUI currentCardList;
    [SerializeField]
    private DeckCardListUI reserveCardList;
    [SerializeField]
    private TextMeshProUGUI numToReserveText;
    [SerializeField]
    private Button confirmButton;

    private DeckData currentDeck;
    private DeckData reserveDeck;
    private int numToReserve;

    public void InitReserveForces(DeckData inputDeck, CampaignManagerUI _campaignManagerUI)
    {
        if (!inputDeck.IsCampaign)
            throw new Exception("Deck is invalid to reserve- not a campaign deck");

        campaignManagerUI = _campaignManagerUI;
        numToReserve = inputDeck.CampaignTracker.NumToReserve;

        currentDeck = new DeckData(inputDeck);
        reserveDeck = new DeckData();

        RefreshCardLists();
    }

    private void RefreshCardLists()
    {
        currentCardList.RefreshCardList(currentDeck, _reserveForcesUI: this);
        reserveCardList.RefreshCardList(reserveDeck, _reserveForcesUI: this, _isReserved: true);

        numToReserveText.text = numToReserve.ToString();

        confirmButton.interactable = numToReserve == 0;
    }

    public void SwitchCardState(CardData card, bool isReserved)
    {
        if (isReserved)
        {
            reserveDeck.RemoveCard(card);
            currentDeck.AddCard(card);

            numToReserve++;
        }
        else if (numToReserve > 0)
        {
            currentDeck.RemoveCard(card);
            reserveDeck.AddCard(card);

            numToReserve--;
        }

        RefreshCardLists();
    }

    public void AddReserves()
    {
        if (numToReserve == 0)
        {
            GameManager.instance.deckManager.RemoveReserves(currentDeck.Id.Value, reserveDeck.CardList);

            campaignManagerUI.RefreshPlayerDetails();
            gameObject.SetActive(false);
        }
    }
}
