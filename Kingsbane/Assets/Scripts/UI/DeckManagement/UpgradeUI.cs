using System.Collections.Generic;
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
    bool selectedUpgradeToAdd;
    List<UpgradeData> upgradesToAdd;
    DeckData selectedDeck;
    DeckData newDeck;

    public void InitUpgradeUI()
    {
        upgradesToAdd = new List<UpgradeData>();
        selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(deckListUI.DeckEditId.Value);
        newDeck = new DeckData(selectedDeck);

        RefreshAvailableUpgrades();
        RefreshUpgradeList(upgradesToAddArea);

        RefreshSelectedUpgrade();
    }

    private void RefreshSelectedUpgrade()
    {
        selectedUpgrade = new UpgradeData();
        selectedUpgradeToAdd = false;

        GameManager.DestroyAllChildren(upgradeDisplay);

        nameText.text = "-";
        honourPointsText.text = "-";
        isRepeatableText.text = "-";
        prerequisiteText.text = "-";

        addButton.interactable = false;
        UpdateSelectedUpgradeButtonText("-");
        cancelButton.interactable = false;
    }

    public void RefreshSelectedUpgrade(UpgradeData _selectedUpgrade, bool isToAdd)
    {
        if (!_selectedUpgrade.Id.HasValue)
        {
            RefreshSelectedUpgrade();
        }
        else
        {
            selectedUpgrade = _selectedUpgrade;
            selectedUpgradeToAdd = isToAdd;

            GameManager.DestroyAllChildren(upgradeDisplay);

            nameText.text = selectedUpgrade.Name;
            honourPointsText.text = selectedUpgrade.HonourPoints.ToString();
            isRepeatableText.text = selectedUpgrade.IsRepeatableString();
            prerequisiteText.text = selectedUpgrade.PrerequisiteString();

            addButton.interactable = true;
            cancelButton.interactable = true;

            if (isToAdd)
                UpdateSelectedUpgradeButtonText("Add");
            else
                UpdateSelectedUpgradeButtonText("Remove");

            GameManager.instance.upgradeManager.CreateUpgrade(selectedUpgrade, upgradeDisplay.transform, selectedDeck);
        }
    }

    public void UpdateSelectedUpgradeState()
    {
        if (selectedUpgradeToAdd)
        {
            upgradesToAdd.Add(selectedUpgrade);
            newDeck.AddUpgrade(selectedUpgrade);
        }
        else
        {
            upgradesToAdd.Remove(selectedUpgrade);
            newDeck.RemoveUpgrade(selectedUpgrade);
        }

        RefreshAvailableUpgrades();
        RefreshUpgradeList(upgradesToAddArea, false, upgradesToAdd, newDeck);

        RefreshSelectedUpgrade();
    }

    private void RefreshAvailableUpgrades()
    {
        var upgradeList = GameManager.instance.upgradeManager.GetAvailableUpgrades(newDeck);

        RefreshUpgradeList(availableUpgradesArea, true, upgradeList, newDeck);
    }

    private void RefreshUpgradeList(GameObject listParent, bool isToAdd = true, List<UpgradeData> upgradeList = null, DeckData currentDeck = null)
    {
        GameManager.DestroyAllChildren(listParent);        

        if (upgradeList != null)
        {
            foreach (var upgrade in upgradeList)
            {
                var newUpgradeObject = Instantiate(upgradeListObject, listParent.transform);
                newUpgradeObject.GetComponent<UpgradeListObject>().InitUpgradeListObject(upgrade, this, currentDeck, isToAdd);

                newUpgradeObject.name = $"Upgrade: {upgrade.Name}";
            }
        }
    }

    public void CancelSelectedUpgrade()
    {
        RefreshSelectedUpgrade();
    }

    private void UpdateSelectedUpgradeButtonText(string buttonText)
    {
        addButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonText;
    }

    public void AddSelectedUpgrades()
    {
        var deckData = GameManager.instance.deckManager.AddUpgradesToPlayerDeck(selectedDeck.Id.Value, upgradesToAdd);
        RefreshUpgradeList(upgradesToAddArea);
        deckListUI.RefreshActiveDeckCardList(deckData);
        upgradesToAdd = new List<UpgradeData>();
    }
}
