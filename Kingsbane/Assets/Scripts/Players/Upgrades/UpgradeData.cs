using System;
using System.Collections.Generic;
using CategoryEnums;
using UnityEngine.Rendering;

/// <summary>
/// 
/// Object for storing Upgrade Data
/// 
/// </summary>
public class UpgradeData
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public UpgradeImageTags ImageTag { get; set; }
    public string Text { get; set; }
    public string LoreText { get; set; }
    public int HonourPoints { get; set; }
    public bool IsRepeatable { get; set; }
    public bool NPCLocked { get; set; }
    public TierLevel TierLevel { get; set; }
    public List<CardResources> ResourcePrerequisites { get; set; }
    public List<Classes.ClassList> ClassPrerequisites { get; set; }
    public List<UpgradeData> UpgradePrerequisites { get; set; }
    public UpgradeTags UpgradeTag { get; set; }

    public UpgradeData()
    {
        Id = null;
    }

    /// <summary>
    /// 
    /// String for displaying if the card is repeatable
    /// 
    /// </summary>
    public string IsRepeatableString()
    {
        return IsRepeatable ? "Yes" : "No";
    }

    /// <summary>
    /// 
    /// String for displaying the prerequisites of the upgrades as a single string
    /// 
    /// </summary>
    public string PrerequisiteString()
    {
        var prerequisitesStrings = new List<string>();
        var prerequisiteString = "-";

        foreach (var classPrerequisite in ClassPrerequisites)
        {
            prerequisitesStrings.Add(classPrerequisite.ToString());
        }
        foreach (var resourcePrerequisite in ResourcePrerequisites)
        {
            prerequisitesStrings.Add(resourcePrerequisite.ToString());
        }
        foreach (var upgradePrerequisite in UpgradePrerequisites)
        {
            prerequisitesStrings.Add(upgradePrerequisite.Name);
        }

        if (prerequisitesStrings.Count != 0)
        {
            prerequisiteString = string.Join(", ", prerequisitesStrings);
        }

        return prerequisiteString;
    }
}
