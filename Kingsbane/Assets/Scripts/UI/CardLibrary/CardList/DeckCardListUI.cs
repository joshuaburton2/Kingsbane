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

    [SerializeField]
    GameObject cardListArea;
    [SerializeField]
    List<GameObject> cardObjects;
    [SerializeField]
    GameObject cardTemplate;
    [SerializeField]
    TextMeshProUGUI cardCountText;

    /// <summary>
    /// 
    /// Refreshes the card list
    /// 
    /// </summary>
    public void RefreshCardList(DeckData deckData = null, DeckListUI _deckListUI = null, int? _deckId = null)
    {
        deckListUI = _deckListUI;

        //Resets card list to default state
        foreach (var item in cardObjects)
        {
            Destroy(item);
        }
        cardObjects.Clear();
        
        //Certain situations may require an empty card list, so will leave the object empty
        if (deckData != null)
        {
            deckCardList = deckData.CardList;
            deckId = _deckId;

            //Add the hero card to the card list
            AddHeroCard(deckData);

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
                cardObjects.Add(deckCardObject);

                //Shifts the index of the overall card loop to the last instance of the current card in the deck. Note that when the code returns to the top of the loop,
                //the index will increase to move onto the index of the next unique card
                cardIndex += numCopies - 1;
            }

            //Update the card count text
            cardCountText.text = $"Cards: {deckData.DeckCount}";
        }
    }

    /// <summary>
    /// 
    /// Adds the hero card to the card list. Should be called before the other cards to add it to the top of the list
    /// 
    /// </summary>
    private void AddHeroCard(DeckData deckData)
    {
        var heroCardObject = Instantiate(cardTemplate, cardListArea.transform);
        heroCardObject.GetComponent<DeckCardObject>().InitCardObject(deckData.HeroCard, deckListUI, 1, deckId);
        heroCardObject.name = $"Card- {deckData.HeroCard.Name}";
        cardObjects.Add(heroCardObject);
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
