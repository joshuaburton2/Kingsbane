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

    public void InitReserveForces(DeckData inputDeck, CampaignManagerUI _campaignManagerUI)
    {
        campaignManagerUI = _campaignManagerUI;

        currentDeck = new DeckData(inputDeck);
        reserveDeck = new DeckData();

        RefreshCardLists();
    }

    private void RefreshCardLists()
    {
        currentCardList.RefreshCardList(currentDeck);
        reserveCardList.RefreshCardList(reserveDeck);
    }
}
