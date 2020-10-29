using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// Object for storing cards so that they are more easily able to scale and also to handle adding cards to deck (don't want that functionality on card display)
/// 
/// </summary>
public class CardLibraryContainer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    float cardSizex;
    [SerializeField]
    float cardSizey;

    [SerializeField]
    private GameObject cardSelectionBorder;

    private CardDisplay cardDisplay;
    private DeckListUI deckListUI;

    //Variables for handling loot generator
    private LootGeneratorUI lootGeneratorUI;
    private bool isSelected;

    private const float defaultScalingFactor = 0.37f;

    /// <summary>
    /// 
    /// Initialise the container object
    /// 
    /// </summary>
    public void InitCardContainer(
        CardData cardData,
        DeckListUI _deckListUI,
        string cardName = "",
        float scalingFactor = defaultScalingFactor,
        LootGeneratorUI _lootGeneratorUI = null)
    {
        deckListUI = _deckListUI;
        lootGeneratorUI = _lootGeneratorUI;

        isSelected = false;

        transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(cardSizex * scalingFactor, cardSizey * scalingFactor);
        //Object is instantiated on the parent of this object in order to prevent conflicts with click handling
        var newCardObj = GameManager.instance.libraryManager.CreateCardObject(cardData, gameObject.transform.parent, scalingFactor);
        newCardObj.name = cardName;
        //Sibling Index is set to 1 so that the click handler on card display doesn't interfere with the click handler on the container (which is only used when adding cards to a deck)
        newCardObj.transform.SetSiblingIndex(1);
        cardDisplay = newCardObj.GetComponent<CardDisplay>();
    }

    /// <summary>
    /// 
    /// Function handler for click events
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        //Right clicking on a card always shows the card detail display
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            cardDisplay.DisplayCardDetail();
        }
        
        //Left clicking functionality varies depending on which part of the library you are in
        if (eventData.button == PointerEventData.InputButton.Left && deckListUI.DeckEditMode)
        {
            //If the loot generator UI is null, this means the card is in the library display, and as such, the card just needs to be added to the deck
            if (lootGeneratorUI == null)
            {
                var updatedDeck = GameManager.instance.deckManager.AddCardToPlayerDeck(deckListUI.DeckEditId.Value, cardDisplay.card.cardData);
                deckListUI.RefreshActiveDeckDetails(updatedDeck);
            }
            //If there is a loot generator, this means the card is being selected on the loot generator panel
            else
            {
                //Variance depending on if the card is selected already or not
                if (!isSelected)
                {
                    //Cannot select more than the maximum number of cards in the loot generator
                    if (!lootGeneratorUI.FullCardsSelected)
                    {
                        lootGeneratorUI.SelectLootCard(cardDisplay.card.cardData);
                        isSelected = true;
                        cardSelectionBorder.SetActive(true);
                    }
                }
                else
                {
                    lootGeneratorUI.RemoveLootCard(cardDisplay.card.cardData);
                    isSelected = false;
                    cardSelectionBorder.SetActive(false);
                }
            }
        }
    }
}
