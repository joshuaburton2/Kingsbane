using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField]
    GameObject availableUpgradesArea;
    [SerializeField]
    GameObject upgradesToAddArea;
    [SerializeField]
    DeckListUI deckListUI;

    [Header("Object Prefabs")]
    [SerializeField]
    GameObject upgradeListObject;

    [Header("DetailsFields")]
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    GameObject upgradeDisplay;
    [SerializeField]
    TextMeshProUGUI honourPointsText;
    [SerializeField]
    TextMeshProUGUI isRepeatableText;
    [SerializeField]
    TextMeshProUGUI prerequisiteText;
    [SerializeField]
    Button addButton;
    [SerializeField]
    Button cancelButton;

    UpgradeData selectedUpgrade;

    public void InitUpgradeUI()
    {
        GameManager.DestroyAllChildren(upgradesToAddArea.transform);
        GameManager.DestroyAllChildren(availableUpgradesArea.transform);

        var selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(deckListUI.DeckEditId.Value);
        var availableUpgrades = GameManager.instance.upgradeManager.GetAvailableUpgrades(selectedDeck);

        foreach (var upgrade in availableUpgrades)
        {
            var newUpgradeObject = Instantiate(upgradeListObject, availableUpgradesArea.transform);
            newUpgradeObject.GetComponent<UpgradeListObject>().InitUpgradeListObject(upgrade, this, selectedDeck);

            newUpgradeObject.name = $"Upgrade: {upgrade.Name}";
        }

        RefreshSelectedUpgrade(new UpgradeData());
    }

    public void RefreshSelectedUpgrade(UpgradeData _selectedUpgrade)
    {
        selectedUpgrade = _selectedUpgrade;

        GameManager.DestroyAllChildren(upgradeDisplay.transform);

        if (!selectedUpgrade.Id.HasValue)
        {
            nameText.text = "-";
            honourPointsText.text = "-";
            isRepeatableText.text = "-";
            prerequisiteText.text = "-";
        }
        else
        {
            nameText.text = selectedUpgrade.Name;
            honourPointsText.text = selectedUpgrade.HonourPoints.ToString();
            isRepeatableText.text = selectedUpgrade.IsRepeatableString();
            prerequisiteText.text = selectedUpgrade.PrerequisiteString();

            var currentDeck = GameManager.instance.deckManager.GetPlayerDeck(deckListUI.DeckEditId.Value);
            GameManager.instance.upgradeManager.CreateUpgrade(selectedUpgrade, upgradeDisplay.transform, currentDeck);
        }
    }

    public void AddSelectedUpgrade()
    {

    }

    public void CancelSelectedUpgrade()
    {

    }
}
