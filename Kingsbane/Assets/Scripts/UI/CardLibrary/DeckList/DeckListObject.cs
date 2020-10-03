using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 
/// Object for handling a deck UI object in a deck list
/// 
/// </summary>
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

    /// <summary>
    /// 
    /// Initialise the deck object. Updates the text properties of the object
    /// 
    /// </summary>
    public void InitDeckListObject(DeckData _deckData, DeckListUI _deckListUI)
    {
        //Need to pass in the deck list UI to handle certain click interactions on this object
        deckListUI = _deckListUI;
        deckData = _deckData;

        deckId = deckData.Id;
        nameText.text = deckData.Name;
        classBorder.color = GameManager.instance.colourManager.GetClassColour(deckData.DeckClass);
        classText.text = deckData.DeckClass.ToString();
        deckCardList.RefreshCardList(deckData, deckListUI, deckId);
        deckCardList.gameObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// Click handler for the object
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //If there is a deck currently being edited, refreshes the deck list (which will close the card list panel for this object)
            if (deckListUI.DeckEditMode)
            {
                deckListUI.RefreshDeckList();
            }
            //If not, sets the deck list UI into edit mode and opens the card list panel on this object
            else
            {
                deckListUI.EditDeck(deckId, deckData.DeckClass, deckCardList);
                deckCardList.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// 
    /// Function for deleting the deck
    /// 
    /// </summary>
    public void DeleteDeck()
    {
        GameManager.instance.deckManager.DeletePlayerDeck(deckData);
        deckListUI.RefreshDeckList();
    }
}
