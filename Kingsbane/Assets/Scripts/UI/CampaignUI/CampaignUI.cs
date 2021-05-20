using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignUI : MonoBehaviour
{
    [SerializeField]
    private GameObject loadCampaignArea;

    public void LoadCampaignUI()
    {
        loadCampaignArea.SetActive(true);

        loadCampaignArea.GetComponent<LoadCampaignUI>().InitialiseLoadCampaignUI();
    }

    public void SelectDeck()
    {

    }
}
