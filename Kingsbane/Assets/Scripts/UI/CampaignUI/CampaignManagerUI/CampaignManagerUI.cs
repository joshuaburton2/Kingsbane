using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignManagerUI : MonoBehaviour
{
    private DeckData loadedDeck;
    private Campaign loadedCampaign;

    public void InitialiseCampaignManager(DeckData deckData)
    {
        if (deckData.IsCampaign)
        {
            loadedDeck = deckData;
            loadedCampaign = deckData.CampaignTracker.GetCampaign();
        }
        else
        {
            throw new Exception("Deck is invalid to manage- not a campaign deck");
        }
    }
}
