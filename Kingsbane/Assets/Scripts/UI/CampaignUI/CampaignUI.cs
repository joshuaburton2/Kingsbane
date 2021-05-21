using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignUI : MonoBehaviour
{
    [SerializeField]
    private GameObject loadCampaignArea;
    [SerializeField]
    private GameObject campaignManagerArea;

    public void LoadCampaignUI()
    {
        loadCampaignArea.SetActive(true);
        campaignManagerArea.SetActive(false);

        loadCampaignArea.GetComponent<LoadCampaignUI>().InitialiseLoadCampaignUI();
    }

    public void SelectDeck(DeckData deck)
    {
        campaignManagerArea.SetActive(true);

        campaignManagerArea.GetComponent<CampaignManagerUI>().InitialiseCampaignManager(deck);
    }
}
