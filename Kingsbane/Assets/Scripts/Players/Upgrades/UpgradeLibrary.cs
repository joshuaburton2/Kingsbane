﻿using System.Collections.Generic;
using CategoryEnums;

public class UpgradeLibrary
{
    public List<UpgradeData> UpgradeList { get; set; }

    public void InitUpgradeList()
    {
        UpgradeList = new List<UpgradeData>();

        var upgrade1 = new UpgradeData()
        {
            Id = 1,
            Name = "Hero Tier I",
            Text = @"Increase your hero’s tier to Tier One. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.HeroUpgrade,
        };

        var upgrade2 = new UpgradeData()
        {
            Id = 2,
            Name = "Hero Tier II",
            Text = @"Increase your hero’s tier to Tier Two. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.HeroUpgrade,
        };

        var upgrade3 = new UpgradeData()
        {
            Id = 3,
            Name = "Ability Tier I",
            Text = @"Increase your hero’s ability tier to Tier One. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.AbilityUpgrade,
        };

        var upgrade4 = new UpgradeData()
        {
            Id = 4,
            Name = "Ability Tier II",
            Text = @"Increase your hero’s ability tier to Tier Two. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.AbilityUpgrade,
        };

        var upgrade5 = new UpgradeData()
        {
            Id = 5,
            Name = "Devoted Followers Tier I",
            Text = @"Your <b>Prayer</b> effects gain an additional one Devotion. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade ",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Devotion,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade6 = new UpgradeData()
        {
            Id = 6,
            Name = "Devoted Followers Tier II",
            Text = @"Your <b>Prayer</b> effects gain an additional two Devotion. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Devotion,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade7 = new UpgradeData()
        {
            Id = 7,
            Name = "Lasting Prayers",
            Text = @"Increase your Lasting Prayer value by one Devotion for the next scenario",
            HonourPoints = 1,
            IsRepeatable = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Devotion,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.LastingPrayers,
        };

        var upgrade8 = new UpgradeData()
        {
            Id = 8,
            Name = "Strength of Arms Tier I",
            Text = @"Increase your base Energy gain to 5 per turn. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Energy,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade9 = new UpgradeData()
        {
            Id = 9,
            Name = "Strength of Arms Tier II",
            Text = @"Increase your base Energy gain to 7 per turn. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Energy,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade10 = new UpgradeData()
        {
            Id = 10,
            Name = "Battle Surges",
            Text = @"Gain an additional Surge",
            HonourPoints = 1,
            IsRepeatable = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Energy,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.BattleSurges,
        };

        var upgrade11 = new UpgradeData()
        {
            Id = 11,
            Name = "Claim Bounty Tier I",
            Text = @"Increase your <b>Bounty</b> value to 2 Gold. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Gold,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade12 = new UpgradeData()
        {
            Id = 12,
            Name = "Claim Bounty Tier II",
            Text = @"Increase your <b>Bounty</b> value to 3 Gold. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Gold,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade13 = new UpgradeData()
        {
            Id = 13,
            Name = "Emergency Reserves",
            Text = @"Gain 3 Gold",
            HonourPoints = 1,
            IsRepeatable = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Gold,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.EmergencyReserves,
        };

        var upgrade14 = new UpgradeData()
        {
            Id = 14,
            Name = "Well of Knowledge Tier I",
            Text = @"Increase your base Knowledge gain to 3. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Knowledge,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade15 = new UpgradeData()
        {
            Id = 15,
            Name = "Well of Knowledge Tier II",
            Text = @"Increase your base Knowledge gain to 4. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Knowledge,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade16 = new UpgradeData()
        {
            Id = 16,
            Name = "Stimulate Learning",
            Text = @"Reduce your Ignorance by 1",
            HonourPoints = 1,
            IsRepeatable = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Knowledge,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.StimulateLearning,
        };

        var upgrade17 = new UpgradeData()
        {
            Id = 17,
            Name = "Mana Reserves Tier I",
            Text = @"Increase your starting Mana to 16. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Mana,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade18 = new UpgradeData()
        {
            Id = 18,
            Name = "Mana Reserves Tier II",
            Text = @"Increase your starting Mana to 24. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Mana,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade19 = new UpgradeData()
        {
            Id = 19,
            Name = "Restore Power",
            Text = @"Reduce the amount you are Overloaded by 6",
            HonourPoints = 1,
            IsRepeatable = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Mana,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.RestorePower,
        };

        var upgrade20 = new UpgradeData()
        {
            Id = 20,
            Name = "Wild Growth Tier I",
            Text = @"Your Wild gain at the start of each turn is increased to 3. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Wild,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade21 = new UpgradeData()
        {
            Id = 21,
            Name = "Wild Growth Tier II",
            Text = @"Your Wild gain at the start of each turn is increased to 4. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 5,
            IsRepeatable = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Wild,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.ResourceUpgrade,
        };

        var upgrade22 = new UpgradeData()
        {
            Id = 22,
            Name = "Cycle of Nature",
            Text = @"<b>Cycle +5</b>",
            HonourPoints = 1,
            IsRepeatable = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Wild,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradeTag = UpgradeTags.CycleofNature,
        };

        upgrade6.UpgradePrerequisites = new List<UpgradeData> { upgrade5 };
        upgrade9.UpgradePrerequisites = new List<UpgradeData> { upgrade8 };
        upgrade12.UpgradePrerequisites = new List<UpgradeData> { upgrade11 };
        upgrade15.UpgradePrerequisites = new List<UpgradeData> { upgrade14 };
        upgrade18.UpgradePrerequisites = new List<UpgradeData> { upgrade17 };
        upgrade21.UpgradePrerequisites = new List<UpgradeData> { upgrade20 };
    }
}

namespace CategoryEnums
{
    public enum UpgradeTags
    {
        HeroUpgrade, AbilityUpgrade, ResourceUpgrade, LastingPrayers, BattleSurges, EmergencyReserves, StimulateLearning, RestorePower, CycleofNature
    }
}
