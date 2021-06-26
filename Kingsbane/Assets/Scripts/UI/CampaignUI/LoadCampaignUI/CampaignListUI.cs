using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignListUI : MonoBehaviour
{
    [SerializeField]
    private LoadCampaignUI loadCampaignUI;
    [SerializeField]
    private GameObject campaginListParent;
    [SerializeField]
    private GameObject campaignListObjectPrefab;
    [SerializeField]
    private List<GameObject> campaignListObjects;

    public void RefreshCampaignList()
    {
        var campaignList = GameManager.instance.scenarioManager.GetCampaigns();

        GameManager.DestroyAllChildren(campaginListParent);
        campaignListObjects.Clear();

        foreach (var campaign in campaignList)
        {
            var campaignListObject = Instantiate(campaignListObjectPrefab, campaginListParent.transform);
            campaignListObject.name = $"Campaign: {campaign.Name}";
            campaignListObject.GetComponent<CampaignListObject>().InitCampaignObject(campaign, this);
            campaignListObjects.Add(campaignListObject);
        }

        SelectCampaign();
    }

    /// <summary>
    /// 
    /// Function call for selecing a campaign for the player to begin
    /// 
    /// </summary>
    public void SelectCampaign(Campaign campaign = null)
    {
        loadCampaignUI.SelectCampaign(campaign);

        foreach (var campaignObject in campaignListObjects)
        {
            var deckObjectScript = campaignObject.GetComponent<CampaignListObject>();
            if (campaign != null)
            {
                if (deckObjectScript.campaign.Id == campaign.Id)
                {
                    deckObjectScript.selectionIcon.SetActive(true);
                }
                else
                {
                    deckObjectScript.selectionIcon.SetActive(false);
                }
            }
            else
            {
                deckObjectScript.selectionIcon.SetActive(false);
            }
        }
    }
}
