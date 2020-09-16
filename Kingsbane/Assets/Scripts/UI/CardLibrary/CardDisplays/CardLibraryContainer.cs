using UnityEngine;
using UnityEngine.EventSystems;

public class CardLibraryContainer : MonoBehaviour, IPointerClickHandler
{
    public CardDisplay cardDisplay;
    public DeckListUI deckListUI;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            cardDisplay.DisplayCardDetail();
        }
        Debug.Log("Test");

        if (eventData.button == PointerEventData.InputButton.Left && deckListUI.DeckEditMode)
        {
            var updatedDeck = GameManager.instance.deckManager.AddToPlayerDeck(deckListUI.DeckEditId.Value, cardDisplay.card.cardData);
            deckListUI.activeDeckCardList.RefreshCardList(updatedDeck, deckListUI);
        }
    }
}
