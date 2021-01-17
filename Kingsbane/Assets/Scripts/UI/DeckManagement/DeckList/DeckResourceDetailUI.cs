using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class DeckResourceDetailUI : MonoBehaviour, IPointerClickHandler
{
    private PlayerResource playerResource;

    [SerializeField]
    TextMeshProUGUI resourceTitle;
    [SerializeField]
    TextMeshProUGUI propertyOneText;
    [SerializeField]
    TextMeshProUGUI propertyTwoText;
    [SerializeField]
    Image resourceIcon;

    /// <summary>
    /// 
    /// Initialise the details about the players resources for a particular deck
    /// 
    /// </summary>
    public void InitDeckResourceDetail(PlayerResource _playerResource)
    {
        playerResource = _playerResource;

        //Set the generic properties of the details
        resourceTitle.text = playerResource.ResourceType.ToString();
        resourceIcon.sprite = GameManager.instance.iconManager.GetIcon(playerResource.ResourceType);

        RefreshResourceProperties();
    }

    /// <summary>
    /// 
    /// Refreshes the text properties of the resource details
    /// 
    /// </summary>
    public void RefreshResourceProperties()
    {
        //Set the property text for the particular resource types
        switch (playerResource.ResourceType)
        {
            case CategoryEnums.CardResources.Devotion:
                var playerDevotion = (PlayerDevotion)playerResource;
                propertyOneText.text = $"Prayer Modifier: {playerDevotion.PrayerModifier}";
                propertyTwoText.text = $"Lasting Prayer: {playerDevotion.LastingPrayer}";
                break;
            case CategoryEnums.CardResources.Energy:
                var playerEnergy = (PlayerEnergy)playerResource;
                propertyOneText.text = $"Energy Gain: {playerEnergy.BaseEnergyGain}";
                propertyTwoText.text = $"Current Surges: {playerEnergy.Surges}";
                break;
            case CategoryEnums.CardResources.Gold:
                var playerGold = (PlayerGold)playerResource;
                propertyOneText.text = $"Current Gold: {playerGold.Value}";
                propertyTwoText.text = $"Bounty Gain: {playerGold.BountyGain}";
                break;
            case CategoryEnums.CardResources.Knowledge:
                var playerKnowledge = (PlayerKnowledge)playerResource;
                propertyOneText.text = $"Knowledge Gain: {playerKnowledge.BaseKnowledgeGain}";
                propertyTwoText.text = $"Ignorance: {playerKnowledge.Ignorance}, {playerKnowledge.ExcessStagnation}/{playerKnowledge.IGNORANCE_THRESHOLD}";
                break;
            case CategoryEnums.CardResources.Mana:
                var playerMana = (PlayerMana)playerResource;
                propertyOneText.text = $"Starting Mana: {playerMana.StartingMana}";
                propertyTwoText.text = $"Overload: {playerMana.CurrentOverload}";
                break;
            case CategoryEnums.CardResources.Wild:
                var playerWild = (PlayerWild)playerResource;
                propertyOneText.text = $"Wild Gain: {playerWild.WildGain}";
                propertyTwoText.text = $"Maximum Wild: {playerWild.MaxWild}";
                break;
            case CategoryEnums.CardResources.Neutral:
            default:
                throw new Exception("Not a valid resource type");
        }
    }

    /// <summary>
    /// 
    /// Used here to prevent the card list being able to be clicked on and closing the edit mode
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
