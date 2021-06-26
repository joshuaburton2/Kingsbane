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
    private ReserveForcesUI reserveForcesUI;
    private bool isReserved;
    private int? deckId;

    Card card;

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
    /// Initialise the object with card data. Refreshes the text properties of the card. Used for library lists
    /// 
    /// </summary>
    public void InitCardObject(CardData _cardData, int numCards, int? _deckId = null, DeckListUI _deckListUI = null, ReserveForcesUI _reserveForcesUI = null, bool _isReserved = false)
    {
        cardData = _cardData;
        //Needs to pass in the deck list UI to this object in order to know which deck is being edited
        deckListUI = _deckListUI;
        reserveForcesUI = _reserveForcesUI;
        isReserved = _isReserved;
        deckId = _deckId;

        nameText.text = cardData.Name;
        typeText.text = cardData.CardType.ToString();

        cardCountText.text = cardData.IsHero ? "Hero" : $"x{numCards}";

        rarityBorder.color = GameManager.instance.colourManager.GetRarityColour(cardData.Rarity, cardData.Class);

        totalCostText.text = StringHelpers.GenerateResourceText(cardData.GetResources);
    }

    /// <summary>
    /// 
    /// Initialise the object with a card. Refreshes the text properties of the card. Used for gameplay lists
    /// 
    /// </summary>
    public void InitCardObject(Card _card)
    {
        card = _card;
        cardData = card.CardData;

        deckListUI = null;

        nameText.text = card.Name;
        typeText.text = card.Type.ToString();

        cardCountText.gameObject.SetActive(false);

        rarityBorder.color = GameManager.instance.colourManager.GetRarityColour(card.Rarity, card.CardClass);

        totalCostText.text = StringHelpers.GenerateResourceText(card.ResourceCost, card.GetResourceColours());
    }

    /// <summary>
    /// 
    /// Handler for clicking on the object
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        //Right click always shows the card detail display
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.instance.uiManager.ActivateCardDetail(cardData);
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Left click removes the card from the player deck
            if (deckListUI != null && deckListUI.DeckEditMode)
            {
                var updatedDeck = GameManager.instance.deckManager.RemoveCardFromPlayerDeck(deckId.Value, cardData);
                deckListUI.RefreshActiveDeckDetails(updatedDeck);
            }

            if (reserveForcesUI != null)
            {
                reserveForcesUI.SwitchCardState(cardData, isReserved);
            }
        }
    }
}
