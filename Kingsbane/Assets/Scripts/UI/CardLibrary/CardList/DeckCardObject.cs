using Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 
/// Script for a card object is a deck card list
/// 
/// </summary>
public class DeckCardObject : MonoBehaviour, IPointerClickHandler
{
    CardData cardData;
    private DeckListUI deckListUI;
    private int? deckId;

    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI cardCountText;
    [SerializeField]
    TextMeshProUGUI typeText;
    [SerializeField]
    TextMeshProUGUI totalCostText;

    [SerializeField]
    Image rarityBorder;

    /// <summary>
    /// 
    /// Initialise the object. Refreshes the text properties on the card
    /// 
    /// </summary>
    public void InitCardObject(CardData _cardData, DeckListUI _deckListUI, int numCards, int? _deckId = null)
    {
        cardData = _cardData;
        //Needs to pass in the deck list UI to this object in order to know which deck is being edited
        deckListUI = _deckListUI;
        deckId = _deckId;

        nameText.text = cardData.Name;
        typeText.text = cardData.CardType.ToString();
        cardCountText.text = cardData.IsHero ? "Hero" : $"x{numCards}";
        rarityBorder.color = GameManager.instance.colourManager.GetRarityColour(cardData.Rarity, cardData.Class);

        totalCostText.text = StringHelpers.GenerateResourceText(cardData.GetResources);
    }

    /// <summary>
    /// 
    /// Handler for clicking on the object
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        //Right click always shows the card detail display
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.instance.uiManager.ActivateCardDetail(cardData);
        }

        //Left click removes the card from the player deck
        if (eventData.button == PointerEventData.InputButton.Left && deckListUI.DeckEditMode)
        {
            var updatedDeck = GameManager.instance.deckManager.RemoveFromPlayerDeck(deckId.Value, cardData);
            deckListUI.activeDeckCardList.RefreshCardList(updatedDeck, deckListUI, deckId.Value);
        }
    }
}
