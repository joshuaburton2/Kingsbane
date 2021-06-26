using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadCampaignUI : MonoBehaviour
{
    public enum SelectionType
    {
        New,
        Load,
    }

    private Campaign selectedNewCampaign;
    private DeckData selectedCampaignDeck;

    [SerializeField]
    private CampaignUI campaignUI;

    [Header("List Objects")]
    [SerializeField]
    private CampaignDeckListUI campaignDeckList;
    [SerializeField]
    private CampaignListUI campaignList;
    [SerializeField]
    private TextMeshProUGUI selectionButtonText;

    [Header("Campaign Detail Objects")]
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI descriptionText;
    [SerializeField]
    private TextMeshProUGUI campaignLengthText;
    [SerializeField]
    private Button confirmButton;
    [SerializeField]
    private TextMeshProUGUI confirmButtonText;

    [Header("Other Objects")]
    [SerializeField]
    private NewDeckUI newDeckUI;

    private SelectionType selectionType;

    public void InitialiseLoadCampaignUI()
    {
        selectedNewCampaign = null;
        selectedCampaignDeck = null;

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

                campaignDeckList.gameObject.SetActive(true);
                campaignDeckList.RefreshDeckList();
                campaignList.gameObject.SetActive(false);

                confirmButtonText.text = "Load Campaign";
                break;
            case SelectionType.Load:
                selectionType = SelectionType.New;
                selectionButtonText.text = "Switch to Load";

                campaignDeckList.gameObject.SetActive(false);
                campaignList.gameObject.SetActive(true);
                campaignList.RefreshCampaignList();

                confirmButtonText.text = "Start Campaign";
                break;
        }
    }

    public void SelectCampaign(Campaign campaign = null, bool isFromDeck = false)
    {
        selectedNewCampaign = campaign;
        if (!isFromDeck)
            selectedCampaignDeck = null;

        if (campaign == null)
        {
            nameText.text = "-";
            descriptionText.text = "-";
            campaignLengthText.text = "-";
            confirmButton.interactable = false;
        }
        else
        {
            nameText.text = campaign.Name;
            descriptionText.text = campaign.Description;
            campaignLengthText.text = campaign.Scenarios.Count.ToString();
            confirmButton.interactable = true;
        }
    }

    public void SelectDeck(DeckData deckData = null)
    {
        selectedNewCampaign = null;
        selectedCampaignDeck = deckData;

        if (deckData != null)
        {
            SelectCampaign(deckData.CampaignTracker.GetCampaign(), true);
        }
        else
        {
            SelectCampaign();
        }
    }

    public void ConfirmButton()
    {
        if (selectedCampaignDeck != null && selectedNewCampaign != null)
        {
            LoadCampaignDeck(selectedCampaignDeck);
        }
        else if (selectedNewCampaign != null && selectedCampaignDeck == null)
        {
            newDeckUI.gameObject.SetActive(true);
            newDeckUI.InitNewDeckPage(selectedNewCampaign.Id);
        }
        else
        {
            throw new Exception("Objects are not selected correctly");
        }
    }

    public void LoadCampaignDeck(DeckData deck)
    {
        if (deck.IsCampaign)
        {
            campaignUI.SelectDeck(deck);
            InitialiseLoadCampaignUI();
        }
        else
        {
            throw new Exception("Loaded deck is not a campaign deck so cannot be loaded");
        }
    }
}
