﻿using CategoryEnums;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 
/// Script for handling an upgrade card display
/// 
/// </summary>
public class UpgradeDisplay : MonoBehaviour, IPointerClickHandler
{
    UpgradeData upgradeData;
    DeckData currentDeck;

    [Header("Main Card Objects")]
    [SerializeField]
    private TextMeshProUGUI upgradeName;
    [SerializeField]
    private TextMeshProUGUI upgradePrerequisites;
    [SerializeField]
    private TextMeshProUGUI honourPoints;
    [SerializeField]
    private TextMeshProUGUI isRepeatable;
    [SerializeField]
    private TextMeshProUGUI upgradeText;
    [SerializeField]
    private Image upgradeImage;

    /// <summary>
    /// 
    /// Initialise the display. This is for properties which should not reset during the game
    /// 
    /// </summary>
    public void InitDisplay(UpgradeData _upgradeData, DeckData _currentDeck)
    {
        upgradeData = _upgradeData;
        currentDeck = _currentDeck;

        upgradeName.text = upgradeData.Name;
        upgradePrerequisites.text = $"Prerequisites: {upgradeData.PrerequisiteString()}";
        var honourPointMod = currentDeck != null && currentDeck.IsCampaign && upgradeData.IsTierLevel ? currentDeck.CampaignTracker.CompletedSinceTierUpgrade : 0;
        var colourTag = honourPointMod > 0 ? GameManager.instance.colourManager.GetStatModColour(StatisticStatuses.Buffed, true).ConvertToHexadecimal() : "";
        honourPoints.text = $"Honour: {colourTag}{upgradeData.GetHonourPointsCost(honourPointMod)}";
        isRepeatable.text = $"Repeatable: {upgradeData.IsRepeatableString()}";
        upgradeText.text = upgradeData.Text;

        upgradeImage.sprite = GameManager.instance.imageManager.GetUpgradeImage(upgradeData.ImageTag);
    }

    /// <summary>
    /// 
    /// Event for clicking on upgrade object
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            DisplayUpgradeDetail();
        }
    }

    /// <summary>
    /// 
    /// Display the upgrade detail
    /// 
    /// </summary>
    public void DisplayUpgradeDetail()
    {
        GameManager.instance.uiManager.ActivateUpgradeDetail(upgradeData, currentDeck);
    }
}
