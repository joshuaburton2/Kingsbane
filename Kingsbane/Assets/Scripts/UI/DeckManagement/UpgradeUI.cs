using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField]
    private CampaignManagerUI campaignManagerUI;

    [Header("Object Prefabs")]
    [SerializeField]
    GameObject upgradeListObject;
    [SerializeField]
    GameObject upgradeDividerObject;

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

    [Header("Honour Points Fields")]
    [SerializeField]
    private GameObject honourPointsArea;
    [SerializeField]
    private TextMeshProUGUI currentCostText;
    [SerializeField]
    private TextMeshProUGUI deckHonourPointsText;
    [SerializeField]
    private Button addSelectedUpgradesButton;

    UpgradeData selectedUpgrade;
    bool selectedUpgradeToAdd;
    List<UpgradeData> upgradesToAdd;
    DeckData selectedDeck;
    DeckData newDeck;

    Dictionary<UpgradeData, int> upgradeCostTracker;

    /// <summary>
    /// 
    /// Initialise the upgrade UI when it is opened
    /// 
    /// </summary>
    public void InitUpgradeUI()
    {
        if (deckListUI != null && campaignManagerUI != null)
            throw new Exception("UI not initialised properly");

        upgradesToAdd = new List<UpgradeData>();
        //Gets the deck currently being edited it and copies it to a new instance of the deck
        if (deckListUI != null)
        {
            selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(deckListUI.DeckEditId.Value);
            honourPointsArea.SetActive(false);
        }
        else if (campaignManagerUI != null)
        {
            selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(campaignManagerUI.loadedDeck.Id.Value);
            honourPointsArea.SetActive(true);
            upgradeCostTracker = new Dictionary<UpgradeData, int>();
            RefreshHonourPoints();
        }

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
        var hideTierUpgrades = false;

        //Adds or removes the upgrade from the upgrade to add list depending on where the upgrade came from
        if (selectedUpgradeToAdd)
        {
            upgradesToAdd.Add(selectedUpgrade);
            newDeck.AddUpgrade(selectedUpgrade, false);

            if (campaignManagerUI != null)
            {
                var honourPoints = selectedUpgrade.GetHonourPointsCost(newDeck.CampaignTracker.CompletedSinceTierUpgrade);
                if (upgradeCostTracker.ContainsKey(selectedUpgrade))
                {
                    upgradeCostTracker[selectedUpgrade] += honourPoints;
                }
                else
                {
                    upgradeCostTracker.Add(selectedUpgrade, honourPoints);
                }
                RefreshHonourPoints();
            }
        }
        else
        {
            RemoveUpgradeFromAddList(selectedUpgrade);
        }

        hideTierUpgrades = campaignManagerUI != null && upgradesToAdd.Any(x => x.IsTierLevel);

        //Refresh the upgrade lists
        RefreshAvailableUpgrades(hideTierUpgrades);
        RefreshUpgradeList(upgradesToAddArea, false, new List<UpgradeData>(upgradesToAdd));

        //Empties the selected ugprade fields
        RefreshSelectedUpgrade();
    }

    private void RemoveUpgradePrerequisites(UpgradeData upgrade)
    {
        //Finds any upgrades in the upgrade to add list which are invalid since their prerequisite is removed
        foreach (var upgradeToAdd in upgradesToAdd.ToList())
        {
            foreach (var prerequisiteUpgrade in upgradeToAdd.UpgradePrerequisites)
            {
                if (prerequisiteUpgrade.Id == upgrade.Id)
                {
                    if (upgradesToAdd.Contains(upgradeToAdd))
                    {
                        RemoveUpgradeFromAddList(upgradeToAdd);
                    }
                }
            }
        }
    }

    private void RemoveUpgradeFromAddList(UpgradeData upgrade)
    {
        upgradesToAdd.Remove(upgrade);
        newDeck.RemoveUpgrade(upgrade);

        RemoveUpgradePrerequisites(upgrade);

        if (campaignManagerUI != null)
        {
            if (upgradesToAdd.Any(x => x.Id == upgrade.Id))
            {
                upgradeCostTracker[upgrade] -= upgrade.GetHonourPointsCost(newDeck.CampaignTracker.CompletedSinceTierUpgrade);
            }
            else
            {
                upgradeCostTracker.Remove(upgrade);
            }

            RefreshHonourPoints();
        }
    }

    /// <summary>
    /// 
    /// Refreshes the available upgrade list with the valid upgrades for the deck
    /// 
    /// </summary>
    private void RefreshAvailableUpgrades(bool hideTierUpgrades = false)
    {
        var upgradeList = GameManager.instance.upgradeManager.GetAvailableUpgrades(newDeck).Where(x => !hideTierUpgrades || hideTierUpgrades && !x.IsTierLevel).ToList();

        RefreshUpgradeList(availableUpgradesArea, true, upgradeList);
    }

    /// <summary>
    /// 
    /// Refreshes the upgrade list with a specific upgrade list
    /// 
    /// </summary>
    /// <param name="isToAdd">Is true if being added from the available upgrades. If false is already in the upgrades to add list</param>
    private void RefreshUpgradeList(GameObject listParent, bool isToAdd = true, List<UpgradeData> upgradeList = null)
    {
        GameManager.DestroyAllChildren(listParent);

        if (upgradeList != null)
        {
            if (deckListUI != null)
            {
                var removeUpgradeTags = new List<UpgradeTags>() { UpgradeTags.ReserveForces, UpgradeTags.ScoutLoot };
                upgradeList.RemoveAll(x => removeUpgradeTags.Contains(x.UpgradeTag));
            }

            //Initialise the resource section
            foreach (var resource in newDeck.DeckResources.OrderBy(x => x.GetEnumDescription()))
            {
                var resourceDividedList = upgradeList.Where(x => x.ResourcePrerequisites.Contains(resource)).ToList();
                if (resourceDividedList.Any())
                {
                    CreateDivider(resource.GetEnumDescription().ToUpper(), listParent);
                    RefreshDividedList(listParent, isToAdd, resourceDividedList, newDeck);
                    //Removes the resource upgrades from the list so only class and neutral upgrades are left
                    upgradeList.RemoveAll(x => resourceDividedList.Contains(x));
                }
            }

            //Initialise the class section
            var classDividedList = upgradeList.Where(x => x.ClassPrerequisites.Contains(newDeck.DeckClass)).ToList();
            if (classDividedList.Any())
            {
                CreateDivider(newDeck.DeckClass.GetEnumDescription().ToUpper(), listParent);
                RefreshDividedList(listParent, isToAdd, classDividedList, newDeck);
                //Removes the class upgrades from the list so only neutral upgrades are left
                upgradeList.RemoveAll(x => classDividedList.Contains(x));
            }

            //Initialise the neutral section
            if (upgradeList.Any())
            {
                CreateDivider("NEUTRAL", listParent);
                //As resource and class upgrades have been removed, only neutral upgrades are left
                RefreshDividedList(listParent, isToAdd, upgradeList, newDeck);
            }
        }
    }

    /// <summary>
    /// 
    /// Creates the upgrade divider in the list
    /// 
    /// </summary>
    private void CreateDivider(string dividerName, GameObject parent)
    {
        var divdiderObject = Instantiate(upgradeDividerObject, parent.transform);
        divdiderObject.GetComponent<UpgradeDividerObject>().InitDivider(dividerName);
        divdiderObject.gameObject.name = $"Divider: {dividerName}";
    }

    /// <summary>
    /// 
    /// Refresh the divided upgrade list
    /// 
    /// </summary>
    private void RefreshDividedList(GameObject listParent, bool isToAdd = true, List<UpgradeData> dividedUpgradeList = null, DeckData currentDeck = null)
    {
        //Loops through all the upgrades and creates the upgrade list objects in the list
        foreach (var upgrade in dividedUpgradeList.OrderBy(x => x.Name))
        {
            var newUpgradeObject = Instantiate(upgradeListObject, listParent.transform);
            var completedScenarios = campaignManagerUI != null && upgrade.IsTierLevel ? campaignManagerUI.loadedDeck.CampaignTracker.CompletedSinceTierUpgrade : 0;
            newUpgradeObject.GetComponent<UpgradeListObject>().InitUpgradeListObject(upgrade, this, currentDeck, isToAdd, completedScenarios);

            newUpgradeObject.name = $"Upgrade: {upgrade.Name}";
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
        if (deckListUI != null)
        {
            //Refreshes the active deck in the list with the deck information
            deckListUI.RefreshActiveDeckDetails(deckData);
        }
        if (campaignManagerUI != null)
        {
            campaignManagerUI.RefreshPlayerDetails();

            var numToReserveMultiplier = 2;
            var numToReserve = upgradesToAdd.Where(x => x.UpgradeTag == UpgradeTags.ReserveForces).Count() * numToReserveMultiplier;

            var numLootCards = upgradesToAdd.Where(x => x.UpgradeTag == UpgradeTags.ScoutLoot).Count();

            campaignManagerUI.RefreshPlayerDetails();

            if (numToReserve > 0)
            {
                campaignManagerUI.OpenReserveForces(numToReserve);
            }
            if (numLootCards > 0)
            {
                campaignManagerUI.OpenLootGenerator(numLootCards);
            }
        }

        //Empties the upgrade to add list
        RefreshUpgradeList(upgradesToAddArea);
        RefreshAvailableUpgrades();
        upgradesToAdd = new List<UpgradeData>();

        upgradeCostTracker = new Dictionary<UpgradeData, int>();
        RefreshHonourPoints();
    }

    private void RefreshHonourPoints()
    {
        if (campaignManagerUI != null)
        {
            currentCostText.text = upgradeCostTracker.Values.Sum().ToString();
            deckHonourPointsText.text = selectedDeck.CampaignTracker.HonourPoints.ToString();

            addSelectedUpgradesButton.interactable = upgradeCostTracker.Values.Sum() <= selectedDeck.CampaignTracker.HonourPoints;
        }
    }
}
