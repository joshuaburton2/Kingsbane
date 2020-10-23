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

    /// <summary>
    /// 
    /// Initialise the upgrade UI when it is opened
    /// 
    /// </summary>
    public void InitUpgradeUI()
    {
        upgradesToAdd = new List<UpgradeData>();
        //Gets the deck currently being edited it and copies it to a new instance of the deck
        selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(deckListUI.DeckEditId.Value);
        newDeck = new DeckData(selectedDeck);

        //Refreshes the available upgrades section
        RefreshAvailableUpgrades();
        //Refreshes the upgrade to add area with an empty list
        RefreshUpgradeList(upgradesToAddArea);

        //Refresh the selected upgrade with empty fields
        RefreshSelectedUpgrade();
    }

    /// <summary>
    /// 
    /// Refreshes the selected upgrade with empty fields
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Refreshes the selected upgrade with a specific upgrade information
    /// 
    /// </summary>
    public void RefreshSelectedUpgrade(UpgradeData _selectedUpgrade, bool isToAdd)
    {
        //If the upgrade has no id, then fills the selected upgrade with empty fields
        if (!_selectedUpgrade.Id.HasValue)
        {
            RefreshSelectedUpgrade();
        }
        else
        {
            //Set the fields speciifc to the selected upgrade
            selectedUpgrade = _selectedUpgrade;
            selectedUpgradeToAdd = isToAdd;

            GameManager.DestroyAllChildren(upgradeDisplay);

            nameText.text = selectedUpgrade.Name;
            honourPointsText.text = selectedUpgrade.HonourPoints.ToString();
            isRepeatableText.text = selectedUpgrade.IsRepeatableString();
            prerequisiteText.text = selectedUpgrade.PrerequisiteString();

            addButton.interactable = true;
            cancelButton.interactable = true;

            //The text on the button will adapt depending on where the upgrade was selected from
            if (isToAdd)
                UpdateSelectedUpgradeButtonText("Add");
            else
                UpdateSelectedUpgradeButtonText("Remove");

            //Creates the upgrade display in the upgrade display area
            GameManager.instance.upgradeManager.CreateUpgrade(selectedUpgrade, upgradeDisplay.transform, selectedDeck);
        }
    }

    /// <summary>
    /// 
    /// Button click event for when the add/remove button. Checks whether the selected upgrade is added or removed from the upgrades to add list
    /// 
    /// </summary>
    public void UpdateSelectedUpgradeState()
    {
        //Adds or removes the upgrade from the upgrade to add list depending on where the upgrade came from
        if (selectedUpgradeToAdd)
        {
            upgradesToAdd.Add(selectedUpgrade);
            newDeck.AddUpgrade(selectedUpgrade);
        }
        else
        {
            upgradesToAdd.Remove(selectedUpgrade);
            newDeck.RemoveUpgrade(selectedUpgrade);

            //Finds any upgrades in the upgrade to add list which are invalid since their prerequisite is removed
            var invalidUpgrades = new List<UpgradeData>();
            foreach (var upgradeToAdd in upgradesToAdd)
            {
                foreach (var prerequisiteUpgrade in upgradeToAdd.UpgradePrerequisites)
                {
                    if (prerequisiteUpgrade.Id == selectedUpgrade.Id)
                    {
                        invalidUpgrades.Add(upgradeToAdd);
                    }
                }
            }

            //Removes any invalid upgrades from the list
            foreach (var invalidUpgrade in invalidUpgrades)
            {
                upgradesToAdd.Remove(invalidUpgrade);
                newDeck.RemoveUpgrade(invalidUpgrade);
            }

        }

        //Refresh the upgrade lists
        RefreshAvailableUpgrades();
        RefreshUpgradeList(upgradesToAddArea, false, upgradesToAdd, newDeck);

        //Empties the selected ugprade fields
        RefreshSelectedUpgrade();
    }

    /// <summary>
    /// 
    /// Refreshes the available upgrade list with the valid upgrades for the deck
    /// 
    /// </summary>
    private void RefreshAvailableUpgrades()
    {
        var upgradeList = GameManager.instance.upgradeManager.GetAvailableUpgrades(newDeck);

        RefreshUpgradeList(availableUpgradesArea, true, upgradeList, newDeck);
    }

    /// <summary>
    /// 
    /// Refreshes the upgrade list with a specific upgrade list
    /// 
    /// </summary>
    /// <param name="isToAdd">Is true if being added from the available upgrades. If false is already in the upgrades to add list</param>
    private void RefreshUpgradeList(GameObject listParent, bool isToAdd = true, List<UpgradeData> upgradeList = null, DeckData currentDeck = null)
    {
        GameManager.DestroyAllChildren(listParent);        

        if (upgradeList != null)
        {
            //Loops through all the upgrades and creates the upgrade list objects in the list
            foreach (var upgrade in upgradeList)
            {
                var newUpgradeObject = Instantiate(upgradeListObject, listParent.transform);
                newUpgradeObject.GetComponent<UpgradeListObject>().InitUpgradeListObject(upgrade, this, currentDeck, isToAdd);

                newUpgradeObject.name = $"Upgrade: {upgrade.Name}";
            }
        }
    }

    /// <summary>
    /// 
    /// Button click event for cancelling the selection of a particular upgrade
    /// 
    /// </summary>
    public void CancelSelectedUpgrade()
    {
        RefreshSelectedUpgrade();
    }

    /// <summary>
    /// 
    /// Update the text on the add/remove button with the input string 
    /// 
    /// </summary>
    private void UpdateSelectedUpgradeButtonText(string buttonText)
    {
        addButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonText;
    }

    /// <summary>
    /// 
    /// Button click event for adding the upgrades in the to add list to the deck being edited
    /// 
    /// </summary>
    public void AddSelectedUpgrades()
    {
        var deckData = GameManager.instance.deckManager.AddUpgradesToPlayerDeck(selectedDeck.Id.Value, upgradesToAdd);
        //Refreshes the active deck in the list with the deck information
        deckListUI.RefreshActiveDeckDetails(deckData);
        //Empties the upgrade to add list
        RefreshUpgradeList(upgradesToAddArea);
        upgradesToAdd = new List<UpgradeData>();
    }
}
