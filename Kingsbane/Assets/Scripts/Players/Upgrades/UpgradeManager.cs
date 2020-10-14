using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{
    private UpgradeLibrary upgradeLibrary;

    private void Awake()
    {
        upgradeLibrary = new UpgradeLibrary();
        upgradeLibrary.InitUpgradeList();
    }

    /// <summary>
    /// 
    /// Gets an upgrade of a particular ID value
    /// 
    /// </summary>
    public UpgradeData GetUpgrade(int id)
    {
        return upgradeLibrary.UpgradeList.FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// 
    /// Gets the list of all the upgrades available to be purchased by a particular class (ignoring honour points)
    /// 
    /// </summary>
    public List<UpgradeData> GetAvailableUpgrades(DeckData deck)
    {
        var availableUpgrades = new List<UpgradeData>();

        //Loops through each upgrade and checks how many of the required conditions it meets for the deck
        foreach (var upgrade in upgradeLibrary.UpgradeList)
        {
            //numMetConditions tracks how many active conditions the upgrade has met
            var numMetConditions = 0;
            //numActiveConditions tracks how many conditions are required to be checked on the upgrade
            var numActiveConditions = 0;

            if (upgrade.ResourcePrerequisites.Count != 0)
            {
                numActiveConditions++;
                //If the deck utilises any of the required resources, then it meets the resource prerequisite (the deck is not required to meet all resource prerequisites)
                if (upgrade.ResourcePrerequisites.Intersect(deck.DeckResources).Any())
                {
                    numMetConditions++;
                }
            }

            if (upgrade.ClassPrerequisites.Count != 0)
            {
                numActiveConditions++;
                //If the deck's class is in the class prerequisite list for the upgrade, then it meets the class condition
                if (upgrade.ClassPrerequisites.Contains(deck.DeckClass))
                {
                    numMetConditions++;
                }
            }

            if (upgrade.UpgradePrerequisites.Count != 0)
            {
                numActiveConditions++;
                //If the upgrades the deck already has are all in the upgrade prerequisites for the upgrade, then the count of the intersection will equal 
                //the count of the upgrade prerequisite list. This is because any of the upgrades in the upgrade prerequisites will be removed in the intersection
                //if they are not in the deck
                if (upgrade.UpgradePrerequisites.Intersect(deck.UpgradeList).Count() == upgrade.UpgradePrerequisites.Count())
                {
                    numMetConditions++;
                }
            }


            //If all conditions are met by the upgrade
            if (numMetConditions == numActiveConditions)
            {
                availableUpgrades.Add(upgrade);
            }
        }

        return availableUpgrades;
    }
}
