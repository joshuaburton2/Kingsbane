using System;
using System.Collections.Generic;
using CategoryEnums;

/// <summary>
/// 
/// Object for storing Upgrade Data
/// 
/// </summary>
public class UpgradeData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public int HonourPoints { get; set; }
    public bool IsRepeatable { get; set; }
    public TierLevel TierLevel { get; set; }
    public List<CardResources> ResourcePrerequisites { get; set; }
    public List<Classes.ClassList> ClassPrerequisites { get; set; }
    public List<UpgradeData> UpgradePrerequisites { get; set; }
    public UpgradeTags UpgradeTag { get; set; }

    public UpgradeData()
    {
        Id = -1;
    }
}
