using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckUpgradeObject : MonoBehaviour, IPointerClickHandler
{
    public int upgradeId;

    UpgradeData upgradeData;
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
    public void InitUpgradeObject(UpgradeData _upgradeData, int? _deckId = null)
    {
        upgradeId = _upgradeData.Id.Value;
        upgradeData = _upgradeData;
        //Needs to pass in the deck list UI to this object in order to know which deck is being edited
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
    }
}
