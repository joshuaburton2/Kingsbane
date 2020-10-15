using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeListObject : MonoBehaviour
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
}
