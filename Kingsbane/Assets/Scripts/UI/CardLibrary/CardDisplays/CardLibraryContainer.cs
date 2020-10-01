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
        var newCardObj = GameManager.instance.libraryManager.CreateCard(cardData, gameObject.transform.parent, scalingFactor);
        newCardObj.name = cardName;
        newCardObj.transform.SetSiblingIndex(1);
        cardDisplay = newCardObj.GetComponent<CardDisplay>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            cardDisplay.DisplayCardDetail();
        }

        if (eventData.button == PointerEventData.InputButton.Left && deckListUI.DeckEditMode)
        {
            if (lootGeneratorUI == null)
            {
                var updatedDeck = GameManager.instance.deckManager.AddToPlayerDeck(deckListUI.DeckEditId.Value, cardDisplay.card.cardData);
                deckListUI.activeDeckCardList.RefreshCardList(updatedDeck, deckListUI, deckListUI.DeckEditId.Value);
            }
            else
            {
                if (!isSelected)
                {
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
