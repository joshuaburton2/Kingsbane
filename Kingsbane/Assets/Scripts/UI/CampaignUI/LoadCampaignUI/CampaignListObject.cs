using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CampaignListObject : MonoBehaviour, IPointerClickHandler
{
    private CampaignListUI campaignListUI;
    public Campaign campaign;

    [SerializeField]
    private TextMeshProUGUI campaignNameText;
    [SerializeField]
    public GameObject selectionIcon;

    public void InitCampaignObject(Campaign _campaign, CampaignListUI _campaignListUI)
    {
        campaign = _campaign;
        campaignListUI = _campaignListUI;

        campaignNameText.text = campaign.Name;
        selectionIcon.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (campaignListUI != null)
            {
                campaignListUI.SelectCampaign(campaign);
            }
        }
    }
}
