using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadCampaignUI : MonoBehaviour
{
    public enum SelectionType
    {
        New,
        Load,
    }

    [SerializeField]
    private CampaignDeckListUI campaignDeckList;
    [SerializeField]
    private CampaignListUI campaignList;
    [SerializeField]
    private TextMeshProUGUI selectionButtonText;

    private SelectionType selectionType;

    public void InitialiseLoadCampaignUI()
    {
        campaignDeckList.RefreshDeckList();
        campaignList.RefreshCampaignList();

        SwitchSelectionType(true);
    }

    public void SwitchSelectionType(bool isNew = false)
    {
        if (isNew)
            selectionType = SelectionType.Load;

        switch (selectionType)
        {
            case SelectionType.New:
                selectionType = SelectionType.Load;
                selectionButtonText.text = "Switch to New";
                break;
            case SelectionType.Load:
                selectionType = SelectionType.New;
                selectionButtonText.text = "Switch to Load";
                break;
        }


    }
}
