using UnityEngine;
using UnityEngine.EventSystems;

public class CardLibraryContainer : MonoBehaviour, IPointerClickHandler
{
    private CardDisplay cardDisplay;
    private DeckListUI deckListUI;

    public void InitCardContainer(CardData cardData, DeckListUI _deckListUI, string cardName = "")
    {
        deckListUI = _deckListUI;

        var newCardObj = GameManager.instance.libraryManager.CreateCard(cardData, gameObject.transform.parent);
        newCardObj.name = cardName;
        newCardObj.transform.SetSiblingIndex(0);
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
            var updatedDeck = GameManager.instance.deckManager.AddToPlayerDeck(deckListUI.DeckEditId.Value, cardDisplay.card.cardData);
            deckListUI.activeDeckCardList.RefreshCardList(updatedDeck, deckListUI, deckListUI.DeckEditId.Value);
        }
    }
}
