using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class CardDisplay : MonoBehaviour
{
    [SerializeField]
    private Card card;

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
    private Image cardImage;
    [SerializeField]
    private Image rarityBorder;

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

    [SerializeField]
    private GameObject spellProps;
    [SerializeField]
    private TextMeshProUGUI spellRangeText;

    [SerializeField]
    private GameObject itemProps;
    [SerializeField]
    private TextMeshProUGUI durabilityText;

    [SerializeField]
    Color COMMON = new Color(0.81f, 1f, 0.91f);
    [SerializeField]
    Color UNCOMMON = new Color(0.12f, 0.34f, 0.82f);
    [SerializeField]
    Color RARE = new Color(0.32f, 0.23f, 0.64f);
    [SerializeField]
    Color EPIC = new Color(0.67f, 0.21f, 0.1f);
    [SerializeField]
    Color LEGENDARY = new Color(0.91f, 0.59f, 0.08f);
    [SerializeField]
    private Color[] classColours = new Color[Classes.NUM_CLASSES];

    private void Awake()
    {
        ResetProps();
        InitDisplay();
    }

    public void InitDisplay()
    {
        cardName.text = card.CardName;
        classText.text = card.cardClass.ToString();
        cardText.text = card.cardText;
        cardImage.sprite = card.cardArt;

        UpdateCardType();
        UpdateRarityBorder();

        UpdateProperties();
    }

    private void ResetProps()
    {
        unitProps.SetActive(false);
        spellProps.SetActive(false);
        itemProps.SetActive(false);
    }

    private void UpdateCardType()
    {
        string subTextString;

        switch (card.cardType)
        {
            case Card.CardType.Unit:
                Unit unitCard = (card as Unit);

                if (unitCard.IsHero)
                {
                    subTextString = "Hero - ";
                }
                else
                {
                    subTextString = "Minion - ";
                }

                subTextString = subTextString + unitCard.UnitTag;

                ResetProps();
                unitProps.SetActive(true);
                break;
            case Card.CardType.Spell:
                subTextString = "Spell";

                ResetProps();
                spellProps.SetActive(true);
                break;
            case Card.CardType.Item:
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

    private void UpdateRarityBorder()
    {
        Color rarityColour;

        switch (card.rarity)
        {
            case Card.Rarity.Uncollectable:
            case Card.Rarity.Common:
                break;
            case Card.Rarity.Uncommon:
                break;
            case Card.Rarity.Rare:
                break;
            case Card.Rarity.Epic:
                break;
            case Card.Rarity.Legendary:
                break;
            default:
                break;
        }
    }

    private Color GetClassColour(Classes.ClassList neededClass)
    {
        return classColours[(int)neededClass];
    }

    public void UpdateProperties()
    {
        UpdateResourceText();

        switch (card.cardType)
        {
            case Card.CardType.Default:
                break;
            case Card.CardType.Unit:
                Unit unitCard = card as Unit;

                break;
            case Card.CardType.Spell:
                Spell spellCard = card as Spell;


                break;
            case Card.CardType.Item:
                Item itemCard = card as Item;


                break;
            default:
                break;
        }
    }

    private void UpdateResourceText()
    {

    }
}
