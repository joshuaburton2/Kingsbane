using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeDisplay : MonoBehaviour, IPointerClickHandler
{
    UpgradeData upgradeData;

    [Header("Main Card Objects")]
    [SerializeField]
    private TextMeshProUGUI upgradeName;
    [SerializeField]
    private TextMeshProUGUI upgradePrerequisites;
    [SerializeField]
    private TextMeshProUGUI honourPoints;
    [SerializeField]
    private TextMeshProUGUI isRepeatable;
    [SerializeField]
    private TextMeshProUGUI upgradeText;
    [SerializeField]
    private Image upgradeImage;

    public void InitDisplay(UpgradeData _upgradeData)
    {
        upgradeData = _upgradeData;

        upgradeName.text = upgradeData.Name;
        upgradePrerequisites.text = $"Prerequisites: {upgradeData.PrerequisiteString()}";
        honourPoints.text = $"Honour: {upgradeData.HonourPoints}";
        isRepeatable.text = $"Repeatable: {upgradeData.IsRepeatableString()}";
        upgradeText.text = upgradeData.Text;
    }

    /// <summary>
    /// 
    /// Event for clicking on upgrade object
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.instance.uiManager.ActivateUpgradeDetail(upgradeData);
        }
    }
}
