using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckListObject : MonoBehaviour, IPointerClickHandler
{
    private int deckId;
    private DeckListUI deckListUI;

    public DeckData deckData;

    [SerializeField]
    Image classBorder;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI classText;
    [SerializeField]
    DeckCardListUI deckCardList;

    public void InitDeckListObject(DeckData _deckData, DeckListUI _deckListUI)
    {
        deckListUI = _deckListUI;
        deckData = _deckData;

        deckId = deckData.Id;
        nameText.text = deckData.Name;
        classBorder.color = GameManager.instance.colourManager.GetClassColour(deckData.DeckClass);
        classText.text = deckData.DeckClass.ToString();
        deckCardList.RefreshCardList(deckData, deckListUI);
        deckCardList.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (deckListUI.DeckEditMode)
        {
            deckListUI.RefreshDeckList(true);
        }
        else
        {
            deckListUI.EditDeck(deckId, deckCardList);
            deckCardList.gameObject.SetActive(true);
        }
    }

    public void DeleteDeck()
    {
        GameManager.instance.deckManager.DeletePlayerDeck(deckData);
        deckListUI.RefreshDeckList(true);
    }
}
