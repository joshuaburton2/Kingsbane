using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckListObject : MonoBehaviour, IPointerClickHandler
{
    private int deckId;
    private DeckListUI deckListUI;

    [SerializeField]
    Image classBorder;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI classText;
    [SerializeField]
    DeckCardListUI deckCardList;

    public void InitDeckListObject(DeckData deck, DeckListUI _deckListUI)
    {
        deckListUI = _deckListUI;

        deckId = deck.Id;
        nameText.text = deck.Name;
        classBorder.color = GameManager.instance.colourManager.GetClassColour(deck.DeckClass);
        classText.text = deck.DeckClass.ToString();
        deckCardList.RefreshCardList(deck, deckListUI);
        deckCardList.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (deckListUI.DeckEditMode)
        {
            deckListUI.RefreshDeckList();
        }
        else
        {
            deckListUI.EditDeck(deckId, deckCardList);
            deckCardList.gameObject.SetActive(true);
        }
    }
}
