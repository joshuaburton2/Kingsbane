using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// Script for handling an object detailing an upgrade in an upgrade list
/// 
/// </summary>
public class UpgradeListObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    TextMeshProUGUI upgradeNameText;
    [SerializeField]
    TextMeshProUGUI honourPointsText;

    UpgradeData upgradeData;
    UpgradeUI upgradeUI;
    DeckData currentDeck;
    bool isToAdd;

    /// <summary>
    /// 
    /// Initialise the upgrade list object. Updates the text properties of the object
    /// 
    /// </summary>
    public void InitUpgradeListObject(UpgradeData _upgradeData, UpgradeUI _upgradeUI, DeckData _currentDeck, bool _isToAdd)
    {
        upgradeData = _upgradeData;
        upgradeUI = _upgradeUI;
        currentDeck = _currentDeck;
        isToAdd = _isToAdd;

        upgradeNameText.text = _upgradeData.Name;
        honourPointsText.text = _upgradeData.HonourPoints.ToString();
    }

    /// <summary>
    /// 
    /// Click event for the upgrade list object
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            upgradeUI.RefreshSelectedUpgrade(upgradeData, isToAdd);
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.instance.uiManager.ActivateUpgradeDetail(upgradeData, currentDeck);
        }
    }
}
