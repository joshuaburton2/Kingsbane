using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// Object for handling a list of cards in a deck
/// 
/// </summary>
public class DeckCardListUI : MonoBehaviour, IPointerClickHandler
{
    private DeckListUI deckListUI;
    private int? deckId;
    private List<CardData> deckCardList;
    private List<UpgradeData> deckUpgradeList;

    [SerializeField]
    GameObject cardListArea;
    [SerializeField]
    GameObject cardTemplate;
    [SerializeField]
    GameObject upgradeTemplate;
    [SerializeField]
    TextMeshProUGUI cardCountText;

    /// <summary>
    /// 
    /// Refreshes the card list
    /// 
    /// </summary>
    public void RefreshCardList(DeckData deckData = null, DeckListUI _deckListUI = null)
    {
        deckListUI = _deckListUI;

        GameManager.DestroyAllChildren(cardListArea);
        
        //Certain situations may require an empty card list, so will leave the object empty
        if (deckData != null)
        {
            deckId = deckData.Id;
            deckCardList = deckData.CardList;
            deckUpgradeList = deckData.UpgradeList;

            //Add the hero card to the list
            AddHeroCard(deckData);

            //Add the upgrades to the list
            AddUpgrades();

            //Add the cards to the list
            AddCards();

            //Update the card count text
            cardCountText.text = $"Cards: {deckData.DeckCount}";
        }
    }

    /// <summary>
    /// 
    /// Adds the hero card to the card list
    /// 
    /// </summary>
    private void AddHeroCard(DeckData deckData)
    {
        var heroCardObject = Instantiate(cardTemplate, cardListArea.transform);
        heroCardObject.GetComponent<DeckCardObject>().InitCardObject(deckData.HeroCard, deckListUI, 1, deckId);
        heroCardObject.name = $"Card- {deckData.HeroCard.Name}";
    }

    /// <summary>
    /// 
    /// Adds the deck upgrades to the card list
    /// 
    /// </summary>
    private void AddUpgrades()
    {
        foreach (var upgradeData in deckUpgradeList)
        {
            var deckUpgradeObject = Instantiate(upgradeTemplate, cardListArea.transform);
            deckUpgradeObject.GetComponent<DeckUpgradeObject>().InitUpgradeObject(upgradeData, deckListUI, deckId);
            deckUpgradeObject.name = $"Upgrade- {upgradeData.Name}";
        }
    }

    private void AddCards()
    {
        //Loops through each card in the card list
        for (int cardIndex = 0; cardIndex < deckCardList.Count; cardIndex++)
        {
            //Creates the card in the list
            var deckCardObject = Instantiate(cardTemplate, cardListArea.transform);
            var cardData = deckCardList[cardIndex];

            var numCopies = 1;

            //Loop to determine how many copies of a card there are in the deck. Loop starts at an index one ahead of the current card and goes to the end of the deck
            for (int forwardCardIndex = cardIndex + 1; forwardCardIndex < deckCardList.Count; forwardCardIndex++)
            {
                //Gets the next card in the sequence
                var forwardCardData = deckCardList[forwardCardIndex];
                //If the card is the same, adds a new copy
                if (cardData.Id == forwardCardData.Id)
                {
                    numCopies++;
                }
                //If the card is not the same breaks from loop and continues
                else
                {
                    break;
                }
            }

            //Initialise the card object
            deckCardObject.GetComponent<DeckCardObject>().InitCardObject(cardData, deckListUI, numCopies, deckId);
            deckCardObject.name = $"Card- {cardData.Name}";

            //Shifts the index of the overall card loop to the last instance of the current card in the deck. Note that when the code returns to the top of the loop,
            //the index will increase to move onto the index of the next unique card
            cardIndex += numCopies - 1;
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
