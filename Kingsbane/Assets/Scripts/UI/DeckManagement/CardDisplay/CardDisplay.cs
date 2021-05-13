
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CategoryEnums;
using UnityEngine.EventSystems;
using Helpers;

/// <summary>
/// 
/// Script for displaying the card information in a UI Panel
/// 
/// </summary>
public class CardDisplay : MonoBehaviour, IPointerClickHandler
{
    public Card card;

    [Header("Main Card Objects")]
    [SerializeField]
    private TextMeshProUGUI cardName;
    [SerializeField]
    private TextMeshProUGUI subText;
    [SerializeField]
    private TextMeshProUGUI resourceText;
    [SerializeField]
    private TextMeshProUGUI classText;
    [SerializeField]
    private TextMeshProUGUI cardText;
    [SerializeField]
    private Image cardBackground;
    [SerializeField]
    private Image cardImage;
    [SerializeField]
    private Image rarityBorder;
    [SerializeField]
    private GameObject createdByArea;
    [SerializeField]
    private TextMeshProUGUI createdByText;
    [SerializeField]
    private GameObject trackShuffleArea;
    [SerializeField]
    private TextMeshProUGUI trackShuffleText;

    [Header("Unit Card Objects")]
    [SerializeField]
    private GameObject unitProps;
    [SerializeField]
    private TextMeshProUGUI attackText;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private TextMeshProUGUI unitRangeText;
    [SerializeField]
    private TextMeshProUGUI speedText;

    [Header("Spell Card Objects")]
    [SerializeField]
    private GameObject spellProps;
    [SerializeField]
    private TextMeshProUGUI spellRangeText;

    [Header("Item Card Objects")]
    [SerializeField]
    private GameObject itemProps;
    [SerializeField]
    private TextMeshProUGUI durabilityText;

    [Header("Other Props")]
    public DeckListUI deckListUI;

    private void Awake()
    {
        ResetProps();
    }

    /// <summary>
    /// 
    /// Initialise the display. This is for properties which should not reset during the game
    /// 
    /// </summary>
    [ContextMenu("Initialise Display")]
    public void InitDisplay(Card _card)
    {
        card = _card;

        cardName.text = card.Name;
        classText.text = card.CardClass.ToString();
        cardImage.sprite = card.CardArt;

        UpdateCardType();
        UpdateRarityBorder();
        UpdateCardBackground();

        UpdateProperties();
    }

    /// <summary>
    /// 
    /// Reset the card so that it does not display any card type fields
    /// 
    /// </summary>
    private void ResetProps()
    {
        unitProps.SetActive(false);
        spellProps.SetActive(false);
        itemProps.SetActive(false);
    }

    /// <summary>
    /// 
    /// Update the card so the subtext lists the unit type, and the relevant card type fields are activated
    /// 
    /// </summary>
    private void UpdateCardType()
    {
        string subTextString;

        switch (card.Type)
        {
            case CardTypes.Unit:
                var unitCard = (card as Unit);

                if (card.Rarity == Rarity.Hero)
                {
                    subTextString = "Hero - ";
                }
                else
                {
                    subTextString = "Minion - ";
                }

                subTextString += unitCard.UnitTag;

                ResetProps();
                unitProps.SetActive(true);
                break;
            case CardTypes.Spell:
                var spellCard = (card as Spell);

                subTextString = "Spell";

                ResetProps();
                spellProps.SetActive(true);
                break;
            case CardTypes.Item:
                var itemCard = card as Item;
                subTextString = "Item - " + itemCard.ItemTag;

                ResetProps();
                itemProps.SetActive(true);
                break;
            default:
                subTextString = "Type Not Implemented";
                ResetProps();
                break;
        }

        subText.text = subTextString;
    }

    /// <summary>
    /// 
    /// Update the colour of the rarity border based on the rarity of the card
    /// 
    /// </summary>
    private void UpdateRarityBorder()
    {
        var borderColour = GameManager.instance.colourManager.GetRarityColour(card.Rarity, card.CardClass);

        rarityBorder.color = borderColour;
    }

    /// <summary>
    /// 
    /// Update the colour of the card background
    /// 
    /// </summary>
    private void UpdateCardBackground()
    {
        cardBackground.color = GameManager.instance.colourManager.GetClassColour(card.CardClass);
    }

    /// <summary>
    /// 
    /// Refresh the properties which can update during the game
    /// 
    /// </summary>
    [ContextMenu("Update Properties")]
    public void UpdateProperties()
    {
        cardText.text = card.Text;
        resourceText.text = StringHelpers.GenerateResourceText(card.ResourceCost, card.GetResourceColours());

        createdByText.text = $"Created By: {card.CreatedByName}";
        createdByArea.SetActive(!string.IsNullOrWhiteSpace(card.CreatedByName));

        trackShuffleArea.SetActive(card.NumShuffles > 0);
        trackShuffleText.text = card.NumShuffles.ToString();

        switch (card.Type)
        {
            case CardTypes.Unit:
                var unitCard = card as Unit;

                var attackColour = GameManager.instance.colourManager.GetStatModColour(unitCard.HasBuffedAttack, true).ConvertToHexadecimal();
                var currentHealthStatus = unitCard.HealthStatus(false);
                var fixedHealthStatus = currentHealthStatus == StatisticStatuses.Debuffed ? StatisticStatuses.None : currentHealthStatus;
                var healthColour = GameManager.instance.colourManager.GetStatModColour(fixedHealthStatus, true).ConvertToHexadecimal();
                var rangeColour = GameManager.instance.colourManager.GetStatModColour(unitCard.HasBuffedRange, true).ConvertToHexadecimal();
                var speedColour = GameManager.instance.colourManager.GetStatModColour(unitCard.HasBuffedSpeed, true).ConvertToHexadecimal();

                attackText.text = $"A: {attackColour}{unitCard.GetStat(Unit.StatTypes.Attack)}";
                healthText.text = $"H: {healthColour}{unitCard.GetStat(Unit.StatTypes.MaxHealth)}";
                unitRangeText.text = $"R: {rangeColour}{unitCard.GetStat(Unit.StatTypes.Range)}";
                speedText.text = $"S: {speedColour}{unitCard.GetStat(Unit.StatTypes.Speed)}";

                //Add the abilities to the card text
                var abilities = unitCard.Abilities;
                if (abilities != null)
                {
                    foreach (var ability in abilities)
                    {
                        cardText.text = $"{cardText.text}\n{ability.AbilityText()}";
                    }
                }

                break;
            case CardTypes.Spell:
                var spellCard = card as Spell;

                spellRangeText.text = $"R: {spellCard.SpellRange}";

                break;
            case CardTypes.Item:
                var itemCard = card as Item;

                durabilityText.text = $"D: {itemCard.Durability}";

                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 
    /// Event for clicking on card object
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            DisplayCardDetail();
        }
    }

    /// <summary>
    /// 
    /// Display the card detail
    /// 
    /// </summary>
    public void DisplayCardDetail()
    {
        GameManager.instance.uiManager.ActivateCardDetail(card.CardData);
    }
}

