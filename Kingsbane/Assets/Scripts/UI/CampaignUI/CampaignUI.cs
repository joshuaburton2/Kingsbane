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

    public void SelectDeck(DeckData deck, bool showLootGenerator = false)
    {
        campaignManagerArea.SetActive(true);

        var campaignManager = campaignManagerArea.GetComponent<CampaignManagerUI>();
        campaignManager.InitialiseCampaignManager(deck);

        if (showLootGenerator)
        {
            campaignManager.OpenLootGenerator();
        }
    }
}
