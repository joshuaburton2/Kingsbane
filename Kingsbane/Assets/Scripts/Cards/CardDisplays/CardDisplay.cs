using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using CategoryEnums;
using System.Linq;


/// <summary>
/// 
/// Object for storing the rarity border colour for a class's hero
/// 
/// </summary>
[System.Serializable]
public class ClassColour
{
    public Classes.ClassList Class;
    public Color classColour;

    ClassColour()
    {
        Class = Classes.ClassList.Default;
        classColour = new Color();
    }
}


/// <summary>
/// 
/// Object for storing the rarity border colour based on the rarity of the card
/// 
/// </summary>
[System.Serializable]
public class RarityColour
{
    public Rarity Rarity;
    public Color rarityColour;

    RarityColour()
    {
        Rarity = Rarity.Default;
        rarityColour = new Color();
    }
}

/// <summary>
/// 
/// Script for displaying the card information in a UI Panel
/// 
/// </summary>
public class CardDisplay : MonoBehaviour
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

    [Header("Border Colours")]
    [SerializeField]
    List<RarityColour> rarityColours;

    [Header("Hero Border Colours")]
    [SerializeField]
    private ClassColour[] classColours = new ClassColour[Classes.NUM_CLASSES];

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
        Color borderColour;

        if (card.Rarity == Rarity.Hero)
            borderColour = GetClassColour(card.CardClass);
        else
            borderColour = GetRarityColour(card.Rarity);

        rarityBorder.color = borderColour;
    }

    /// <summary>
    /// 
    /// Update the colour of the card background
    /// 
    /// </summary>
    private void UpdateCardBackground()
    {
        cardBackground.color = GetClassColour(card.CardClass);
    }

    /// <summary>
    /// 
    /// Obtain a particular rarities colour
    /// 
    /// </summary>
    private Color GetRarityColour(Rarity neededRarity)
    {
        return rarityColours.FirstOrDefault(x => x.Rarity == neededRarity).rarityColour;
    }

    /// <summary>
    /// 
    /// Obtain a particular classes colour
    /// 
    /// </summary>
    private Color GetClassColour(Classes.ClassList neededClass)
    {
        return classColours.FirstOrDefault(x => x.Class == neededClass).classColour;
    }

    /// <summary>
    /// 
    /// Refresh the properties which can update during the game
    /// 
    /// </summary>
    [ContextMenu("Update Properties")]
    public void UpdateProperties()
    {
        UpdateResourceText();

        switch (card.Type)
        {
            case CardTypes.Unit:
                Unit unitCard = card as Unit;

                attackText.text = $"Attack: {unitCard.Attack}";
                healthText.text = $"Health: {unitCard.Health}";
                unitRangeText.text = $"Range: {unitCard.Range}";
                speedText.text = $"Speed: {unitCard.Speed}";

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
    private void UpdateResourceText()
    {
        List<Resource> cardResources = card.ResourceCost;

        string resourceString = "";

        foreach (var resource in cardResources)
        {
            var resourceVal = resource.Value.ToString().Replace("-", "");
            resourceString += $" {resourceVal} {resource.ResourceType}";
        }

        resourceText.text = resourceString;
    }
}

