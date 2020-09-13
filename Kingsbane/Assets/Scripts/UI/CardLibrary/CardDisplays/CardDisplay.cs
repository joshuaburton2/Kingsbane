
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CategoryEnums;
using UnityEngine.EventSystems;

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
    public bool isClickable = true;

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
    public void InitDisplay()
    {
        cardName.text = card.CardName;
        classText.text = card.CardClass.ToString();
        cardText.text = card.Text;
        cardImage.sprite = card.cardArt;

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
                Unit unitCard = (card as Unit);

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
                Spell spellCard = (card as Spell);

                subTextString = "Spell";

                ResetProps();
                spellProps.SetActive(true);
                break;
            case CardTypes.Item:
                Item itemCard = card as Item;
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
        Color borderColour = GameManager.instance.colourManager.GetRarityColour(card.Rarity, card.CardClass);

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
        resourceText.text = GenerateResourceText(card.ResourceCost);

        switch (card.Type)
        {
            case CardTypes.Unit:
                Unit unitCard = card as Unit;

                attackText.text = $"Attack: {unitCard.Attack}";
                healthText.text = $"Health: {unitCard.Health}";
                unitRangeText.text = $"Range: {unitCard.Range}";
                speedText.text = $"Speed: {unitCard.Speed}";

                List<AbilityData> abilities = unitCard.Abilities;
                if (abilities != null)
                {
                    foreach (var ability in abilities)
                    {
                        var resourceText = GenerateResourceText(ability.GetResources);
                        var commaText = resourceText.Length == 0 ? "" : ", ";
                        var actionText = ability.CostsAction ? $"{commaText}1 Action" : "";
                        var abilityText = $"<b>{ability.Name} ({resourceText}{actionText}):</b> {ability.Text}";
                        cardText.text = $"{cardText.text}\n{abilityText}";
                    }
                }

                break;
            case CardTypes.Spell:
                Spell spellCard = card as Spell;

                spellRangeText.text = $"Range: {spellCard.SpellRange}";

                break;
            case CardTypes.Item:
                Item itemCard = card as Item;

                durabilityText.text = $"Durability: {itemCard.Durability}";

                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 
    /// Update the resource text to include the resource words
    /// 
    /// </summary>
    private string GenerateResourceText(List<Resource> resourceList)
    {
        string resourceString = "";

        foreach (var resource in resourceList)
        {
            var resourceVal = resource.Value.ToString().Replace("-", "");
            resourceString += $"{resourceVal} {resource.ResourceType},";
        }

        // Remove the first space last comma from the resource text
        if (resourceString.Length != 0)
        {
            resourceString = resourceString.Remove(resourceString.Length - 1);
        }

        resourceString = resourceString.Replace(",", ", ");

        return resourceString;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && isClickable)
        {
            GameManager.instance.uiManager.ActivateCardDetail(card.cardData);
        }
    }
}

