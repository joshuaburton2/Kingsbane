using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckUpgradeObject : MonoBehaviour, IPointerClickHandler
{
    UpgradeData upgradeData;
    private DeckListUI deckListUI;
    private int? deckId;

    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI honourPointsText;

    /// <summary>
    /// 
    /// Initialise the object. Refreshes the text properties of the upgrade
    /// 
    /// </summary>
    public void InitUpgradeObject(UpgradeData _upgradeData, DeckListUI _deckListUI, int? _deckId = null)
    {
        upgradeData = _upgradeData;
        //Needs to pass in the deck list UI to this object in order to know which deck is being edited
        deckListUI = _deckListUI;
        deckId = _deckId;

        nameText.text = upgradeData.Name;
        honourPointsText.text = $"Honour: {upgradeData.HonourPoints}";
    }

    /// <summary>
    /// 
    /// Handler for clicking on the object
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        //Right click always shows the upgrade detail display
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.instance.uiManager.ActivateUpgradeDetail(upgradeData);
        }

        //Left click removes the upgrade from the player deck
        if (eventData.button == PointerEventData.InputButton.Left && deckListUI.DeckEditMode)
        {
            //var updatedDeck = GameManager.instance.deckManager.RemoveUpgradeFromPlayerDeck(deckId.Value, upgradeData);
            //deckListUI.RefreshActiveDeckCardList(updatedDeck);
        }
    }
}
