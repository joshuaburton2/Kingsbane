using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeListObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    TextMeshProUGUI upgradeNameText;
    [SerializeField]
    TextMeshProUGUI honourPointsText;

    UpgradeData upgradeData;
    UpgradeUI upgradeUI;

    public void InitUpgradeListObject(UpgradeData _upgradeData, UpgradeUI _upgradeUI)
    {
        upgradeData = _upgradeData;
        upgradeUI = _upgradeUI;

        upgradeNameText.text = _upgradeData.Name;
        honourPointsText.text = _upgradeData.HonourPoints.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            upgradeUI.RefreshSelectedUpgrade(upgradeData);
        }
    }
}
