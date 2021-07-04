using System.Collections.Generic;
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
            ImageTag = UpgradeImageTags.Hero_1,
            Text = @"Increase your hero’s tier to Tier One. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your hero’s tier to Tier One. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.HeroUpgrade,
        };
        UpgradeList.Add(upgrade1);

        var upgrade2 = new UpgradeData()
        {
            Id = 2,
            Name = "Hero Tier II",
            ImageTag = UpgradeImageTags.Hero_II,
            Text = @"Increase your hero’s tier to Tier Two. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your hero’s tier to Tier Two. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.HeroUpgrade,
        };
        UpgradeList.Add(upgrade2);

        var upgrade3 = new UpgradeData()
        {
            Id = 3,
            Name = "Ability Tier I",
            ImageTag = UpgradeImageTags.Ability_I,
            Text = @"Increase your hero’s ability tier to Tier One. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your hero’s ability tier to Tier One. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.AbilityUpgrade,
        };
        UpgradeList.Add(upgrade3);

        var upgrade4 = new UpgradeData()
        {
            Id = 4,
            Name = "Ability Tier II",
            ImageTag = UpgradeImageTags.Ability_II,
            Text = @"Increase your hero’s ability tier to Tier Two. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your hero’s ability tier to Tier Two. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.AbilityUpgrade,
        };
        UpgradeList.Add(upgrade4);

        var upgrade5 = new UpgradeData()
        {
            Id = 5,
            Name = "Devoted Followers Tier I",
            ImageTag = UpgradeImageTags.Devoted_Followers_I,
            Text = @"Your <b>Prayer</b> effects gain an additional one Devotion. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade ",
            LoreText = @"Your <b>Prayer</b> effects gain an additional one Devotion. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade ",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Devotion,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.DevotedFollowers,
        };
        UpgradeList.Add(upgrade5);

        var upgrade6 = new UpgradeData()
        {
            Id = 6,
            Name = "Devoted Followers Tier II",
            ImageTag = UpgradeImageTags.Devoted_Followers_II,
            Text = @"Your <b>Prayer</b> effects gain an additional two Devotion. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Your <b>Prayer</b> effects gain an additional two Devotion. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Devotion,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.DevotedFollowers,
        };
        UpgradeList.Add(upgrade6);

        var upgrade7 = new UpgradeData()
        {
            Id = 7,
            Name = "Lasting Prayers",
            ImageTag = UpgradeImageTags.Lasting_Prayers,
            Text = @"Increase your Lasting Prayer value by one Devotion for the next scenario",
            LoreText = @"Increase your Lasting Prayer value by one Devotion for the next scenario",
            HonourPoints = 1,
            IsRepeatable = true,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Devotion,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.LastingPrayers,
        };
        UpgradeList.Add(upgrade7);

        var upgrade8 = new UpgradeData()
        {
            Id = 8,
            Name = "Strength of Arms Tier I",
            ImageTag = UpgradeImageTags.Strength_of_Arms_I,
            Text = @"Increase your base Energy gain to 5 per turn. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your base Energy gain to 5 per turn. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Energy,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.StrengthofArms,
        };
        UpgradeList.Add(upgrade8);

        var upgrade9 = new UpgradeData()
        {
            Id = 9,
            Name = "Strength of Arms Tier II",
            ImageTag = UpgradeImageTags.Strength_of_Arms_II,
            Text = @"Increase your base Energy gain to 7 per turn. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your base Energy gain to 7 per turn. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Energy,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.StrengthofArms,
        };
        UpgradeList.Add(upgrade9);

        var upgrade10 = new UpgradeData()
        {
            Id = 10,
            Name = "Battle Surges",
            ImageTag = UpgradeImageTags.Battle_Surges,
            Text = @"Gain an additional Surge",
            LoreText = @"Gain an additional Surge",
            HonourPoints = 1,
            IsRepeatable = true,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Energy,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.BattleSurges,
        };
        UpgradeList.Add(upgrade10);

        var upgrade11 = new UpgradeData()
        {
            Id = 11,
            Name = "Claim Bounty Tier I",
            ImageTag = UpgradeImageTags.Claim_Bounty_I,
            Text = @"Increase your <b>Bounty</b> value to 2 Gold. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your <b>Bounty</b> value to 2 Gold. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Gold,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ClaimBounty,
        };
        UpgradeList.Add(upgrade11);

        var upgrade12 = new UpgradeData()
        {
            Id = 12,
            Name = "Claim Bounty Tier II",
            ImageTag = UpgradeImageTags.Claim_Bounty_II,
            Text = @"Increase your <b>Bounty</b> value to 3 Gold. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your <b>Bounty</b> value to 3 Gold. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Gold,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ClaimBounty,
        };
        UpgradeList.Add(upgrade12);

        var upgrade13 = new UpgradeData()
        {
            Id = 13,
            Name = "Emergency Reserves",
            ImageTag = UpgradeImageTags.Emergency_Reserves,
            Text = @"Gain 3 Gold",
            LoreText = @"Gain 3 Gold",
            HonourPoints = 1,
            IsRepeatable = true,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Gold,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.EmergencyReserves,
        };
        UpgradeList.Add(upgrade13);

        var upgrade14 = new UpgradeData()
        {
            Id = 14,
            Name = "Well of Knowledge Tier I",
            ImageTag = UpgradeImageTags.Well_of_Knowledge_I,
            Text = @"Increase your base Knowledge gain to 3. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your base Knowledge gain to 3. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Knowledge,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.WellofKnowledge,
        };
        UpgradeList.Add(upgrade14);

        var upgrade15 = new UpgradeData()
        {
            Id = 15,
            Name = "Well of Knowledge Tier II",
            ImageTag = UpgradeImageTags.Well_of_Knowledge_II,
            Text = @"Increase your base Knowledge gain to 4. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your base Knowledge gain to 4. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Knowledge,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.WellofKnowledge,
        };
        UpgradeList.Add(upgrade15);

        var upgrade16 = new UpgradeData()
        {
            Id = 16,
            Name = "Stimulate Learning",
            ImageTag = UpgradeImageTags.Stimulate_Learning,
            Text = @"Reduce your Ignorance by 1",
            LoreText = @"Reduce your Ignorance by 1",
            HonourPoints = 1,
            IsRepeatable = true,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Knowledge,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.StimulateLearning,
        };
        UpgradeList.Add(upgrade16);

        var upgrade17 = new UpgradeData()
        {
            Id = 17,
            Name = "Mana Reserves Tier I",
            ImageTag = UpgradeImageTags.Mana_Reserves_I,
            Text = @"Increase your starting Mana to 16. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your starting Mana to 16. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Mana,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ManaReserves,
        };
        UpgradeList.Add(upgrade17);

        var upgrade18 = new UpgradeData()
        {
            Id = 18,
            Name = "Mana Reserves Tier II",
            ImageTag = UpgradeImageTags.Mana_Reserves_II,
            Text = @"Increase your starting Mana to 24. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Increase your starting Mana to 24. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Mana,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ManaReserves,
        };
        UpgradeList.Add(upgrade18);

        var upgrade19 = new UpgradeData()
        {
            Id = 19,
            Name = "Restore Power",
            ImageTag = UpgradeImageTags.Restore_Power,
            Text = @"Reduce the amount you are Overloaded by 6",
            LoreText = @"Reduce the amount you are Overloaded by 6",
            HonourPoints = 1,
            IsRepeatable = true,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Mana,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.RestorePower,
        };
        UpgradeList.Add(upgrade19);

        var upgrade20 = new UpgradeData()
        {
            Id = 20,
            Name = "Wild Growth Tier I",
            ImageTag = UpgradeImageTags.Wild_Growth_I,
            Text = @"Your Wild gain at the start of each turn is increased to 3. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Your Wild gain at the start of each turn is increased to 3. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier1,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Wild,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.WildGrowth,
        };
        UpgradeList.Add(upgrade20);

        var upgrade21 = new UpgradeData()
        {
            Id = 21,
            Name = "Wild Growth Tier II",
            ImageTag = UpgradeImageTags.Wild_Growth_II,
            Text = @"Your Wild gain at the start of each turn is increased to 4. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            LoreText = @"Your Wild gain at the start of each turn is increased to 4. Costs one less Honour Point per scenario won since purchasing a Hero, Ability or Resource Tier upgrade",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Tier2,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Wild,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.WildGrowth,
        };
        UpgradeList.Add(upgrade21);

        var upgrade22 = new UpgradeData()
        {
            Id = 22,
            Name = "Cycle of Nature",
            ImageTag = UpgradeImageTags.Cycle_of_Nature,
            Text = @"<b>Cycle +5</b>",
            LoreText = @"<b>Cycle +5</b>",
            HonourPoints = 1,
            IsRepeatable = true,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Wild,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.CycleofNature,
        };
        UpgradeList.Add(upgrade22);

        var upgrade23 = new UpgradeData()
        {
            Id = 23,
            Name = "Supply Lines",
            ImageTag = UpgradeImageTags.Supply_Lines,
            Text = @"At the start of each scenario, draw 2 cards",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.SupplyLines,
        };
        UpgradeList.Add(upgrade23);

        var upgrade24 = new UpgradeData()
        {
            Id = 24,
            Name = "Death Defiant",
            ImageTag = UpgradeImageTags.Death_Defiant,
            Text = @"The next time your hero dies, they instead redeploy with half health. Only one of these upgrades can be purcahsed at a time",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = true,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.DeathDefiant,
        };
        UpgradeList.Add(upgrade24);

        var upgrade25 = new UpgradeData()
        {
            Id = 25,
            Name = "Spellstone Amulet",
            ImageTag = UpgradeImageTags.Spellstone_Amulet,
            Text = @"Your spells cost (1) less, but not less than (1)",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.SpellstoneAmulet,
        };
        UpgradeList.Add(upgrade25);

        var upgrade26 = new UpgradeData()
        {
            Id = 26,
            Name = "Ornate Spellstone Amulet",
            ImageTag = UpgradeImageTags.Ornate_Spellstone_Amulet,
            Text = @"Your spells cost (2) less, but not less than (1). This replaces Spellstone Amulet",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.OrnateSpellstoneAmulet,
        };
        UpgradeList.Add(upgrade26);

        var upgrade27 = new UpgradeData()
        {
            Id = 27,
            Name = "Efficient Quartermasters",
            ImageTag = UpgradeImageTags.Efficient_Quartermasters,
            Text = @"Your units cost (1) less, but not less than (1)",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.EfficientQuartermasters,
        };
        UpgradeList.Add(upgrade27);

        var upgrade28 = new UpgradeData()
        {
            Id = 28,
            Name = "Expert Quartermasters",
            ImageTag = UpgradeImageTags.Expert_Quartermasters,
            Text = @"Your units cost (2) less, but not less than (1). This replaces Efficient Quartermasters",
            LoreText = @"Your units cost (2) less, but not less than (1). This replaces Efficient Quartermasters",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ExpertQuartermasters,
        };
        UpgradeList.Add(upgrade28);

        var upgrade29 = new UpgradeData()
        {
            Id = 29,
            Name = "Stand Alone",
            ImageTag = UpgradeImageTags.Stand_Alone,
            Text = @"Your hero has <b>Prepared</b>",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.StandAlone,
        };
        UpgradeList.Add(upgrade29);

        var upgrade30 = new UpgradeData()
        {
            Id = 30,
            Name = "Import Craftsmen",
            ImageTag = UpgradeImageTags.Import_Craftsmen,
            Text = @"Your items cost (1) less but not less than (1)",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ImportCraftsmen,
        };
        UpgradeList.Add(upgrade30);

        var upgrade31 = new UpgradeData()
        {
            Id = 31,
            Name = "Import Master Craftsmen",
            ImageTag = UpgradeImageTags.Import_Master_Craftsmen,
            Text = @"Your items cost (2) less but not less than (1)",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ImportMasterCraftsmen,
        };
        UpgradeList.Add(upgrade31);

        var upgrade32 = new UpgradeData()
        {
            Id = 32,
            Name = "Honour Through Battle",
            ImageTag = UpgradeImageTags.Honour_Through_Battle,
            Text = @"Whenever you complete a scenario, you gain an additional honour point",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.HonourThroughBattle,
        };
        UpgradeList.Add(upgrade32);

        var upgrade33 = new UpgradeData()
        {
            Id = 33,
            Name = "Strength in Honour",
            ImageTag = UpgradeImageTags.Strength_in_Honour,
            Text = @"Whenever you complete a scenario, you gain an additional three honour points. This replaces Honour Through Battle",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.StrengthinHonour,
        };
        UpgradeList.Add(upgrade33);

        var upgrade34 = new UpgradeData()
        {
            Id = 34,
            Name = "Reserve Forces",
            ImageTag = UpgradeImageTags.Reserve_Forces,
            Text = @"Remove two cards permanently from your deck",
            LoreText = @"Remove two cards permanently from your deck",
            HonourPoints = 2,
            IsRepeatable = true,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ReserveForces,
        };
        UpgradeList.Add(upgrade34);

        var upgrade35 = new UpgradeData()
        {
            Id = 35,
            Name = "Golden Chalice",
            ImageTag = UpgradeImageTags.Golden_Chalice,
            Text = @"Whenever you give a friendly unit Attack, Health or <b>Protected</b> from a card, double the values given",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Devotion,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.GoldenChalice,
        };
        UpgradeList.Add(upgrade35);

        var upgrade36 = new UpgradeData()
        {
            Id = 36,
            Name = "Mithril Chalice",
            ImageTag = UpgradeImageTags.Mithril_Chalice,
            Text = @"Whenever you give a friendly unit Attack, Health or <b>Protected</b> from a card, triple the values given. Replaces Golden Chalice",
            LoreText = @"Whenever you give a friendly unit Attack, Health or <b>Protected</b> from a card, triple the values given. Replaces Golden Chalice",
            HonourPoints = 5,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Devotion,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.MithrilChalice,
        };
        UpgradeList.Add(upgrade36);

        var upgrade37 = new UpgradeData()
        {
            Id = 37,
            Name = "Divine Protection",
            ImageTag = UpgradeImageTags.Divine_Protection,
            Text = @"Whenever your hero is healed, any excess healing is converted to <b>Protected</b>",
            LoreText = @"Whenever your hero is healed, any excess healing is converted to <b>Protected</b>",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Devotion,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.DivineProtection,
        };
        UpgradeList.Add(upgrade37);

        var upgrade38 = new UpgradeData()
        {
            Id = 38,
            Name = "Weapon Master",
            ImageTag = UpgradeImageTags.Weapon_Master,
            Text = @"You can equip an additional item (2 total)",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Energy,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.WeaponMaster,
        };
        UpgradeList.Add(upgrade38);

        var upgrade39 = new UpgradeData()
        {
            Id = 39,
            Name = "Weapon Virtuoso",
            ImageTag = UpgradeImageTags.Weapon_Virtuoso,
            Text = @"You can equip an additional item (3 total)",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Energy,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.WeaponVirtuoso,
        };
        UpgradeList.Add(upgrade39);

        var upgrade40 = new UpgradeData()
        {
            Id = 40,
            Name = "Wound Resistant",
            ImageTag = UpgradeImageTags.Wound_Resistant,
            Text = @"At the start of each of your turns, your hero is healed by your base Energy gain",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Energy,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.WoundResistant,
        };
        UpgradeList.Add(upgrade40);

        var upgrade41 = new UpgradeData()
        {
            Id = 41,
            Name = "Better Hires",
            ImageTag = UpgradeImageTags.Better_Hires,
            Text = @"Your units have +1 Attack, +1 Health",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Gold,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.BetterHires,
        };
        UpgradeList.Add(upgrade41);

        var upgrade42 = new UpgradeData()
        {
            Id = 42,
            Name = "The Best Hires",
            ImageTag = UpgradeImageTags.The_Best_Hires,
            Text = @"Your units have +2 Attack, +2 Health. This replaces Better Hires",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Gold,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.TheBestHires,
        };
        UpgradeList.Add(upgrade42);

        var upgrade43 = new UpgradeData()
        {
            Id = 43,
            Name = "Monetary Motivation",
            ImageTag = UpgradeImageTags.Monetary_Motivation,
            Text = @"Your <b>Deployment</b> effects trigger twice",
            LoreText = @"Your <b>Deployment</b> effects trigger twice",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Gold,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.MonetaryMotivation,
        };
        UpgradeList.Add(upgrade43);

        var upgrade44 = new UpgradeData()
        {
            Id = 44,
            Name = "Breadth of Knowledge",
            ImageTag = UpgradeImageTags.Breadth_of_Knowledge,
            Text = @"At the start of each scenario, shuffle 2 Inspiration cards into your deck",
            LoreText = @"At the start of each scenario, shuffle 2 Inspiration cards into your deck",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Knowledge,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.BreadthofKnowledge,
        };
        UpgradeList.Add(upgrade44);

        var upgrade45 = new UpgradeData()
        {
            Id = 45,
            Name = "Ultimate Knowledge",
            ImageTag = UpgradeImageTags.Ultimate_Knowledge,
            Text = @"At the start of each scenario, shuffle 4 Inspiration cards into your deck. This replaces Breadth of Knowledge",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Knowledge,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.UltimateKnowledge,
        };
        UpgradeList.Add(upgrade45);

        var upgrade46 = new UpgradeData()
        {
            Id = 46,
            Name = "Potent Foretelling",
            ImageTag = UpgradeImageTags.Potent_Foretelling,
            Text = @"The first time you <b>Divinate</b> on a turn from a card, draw as many cards as you <b>Divinated</b>",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Knowledge,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.PotentForetelling,
        };
        UpgradeList.Add(upgrade46);

        var upgrade47 = new UpgradeData()
        {
            Id = 47,
            Name = "Circlet of Power",
            ImageTag = UpgradeImageTags.Circlet_of_Power,
            Text = @"You have the <b>Passive: Empowered +1</b>",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Mana,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.CircletofPower,
        };
        UpgradeList.Add(upgrade47);

        var upgrade48 = new UpgradeData()
        {
            Id = 48,
            Name = "Crown of the Arcane",
            ImageTag = UpgradeImageTags.Crown_of_the_Arcane,
            Text = @"You have the <b>Passive: Empowered +3.</b>This replaces Circlet of Power",
            LoreText = @"You have the <b>Passive: Empowered +3.</b>This replaces Circlet of Power",
            HonourPoints = 5,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Mana,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.CrownoftheArcane,
        };
        UpgradeList.Add(upgrade48);

        var upgrade49 = new UpgradeData()
        {
            Id = 49,
            Name = "Summoner's Rod",
            ImageTag = UpgradeImageTags.Summoners_Rod,
            Text = @"Your <b>Summon</b> units have +4 Attack, +4 Health",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Mana,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.SummonersRod,
        };
        UpgradeList.Add(upgrade49);

        var upgrade50 = new UpgradeData()
        {
            Id = 50,
            Name = "Feral Nature",
            ImageTag = UpgradeImageTags.Feral_Nature,
            Text = @"Whenever your units gain Attack and Health from <b>Unleash</b>, the stats they gain are doubled",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Wild,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.FeralNature,
        };
        UpgradeList.Add(upgrade50);

        var upgrade51 = new UpgradeData()
        {
            Id = 51,
            Name = "Heart of the Wild",
            ImageTag = UpgradeImageTags.Heart_of_the_Wild,
            Text = @"Your units that have a total cost of (5) or more cost (2) less, but not less than (5)",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Wild,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.HeartoftheWild,
        };
        UpgradeList.Add(upgrade51);

        var upgrade52 = new UpgradeData()
        {
            Id = 52,
            Name = "Restored Heart of the Wild",
            ImageTag = UpgradeImageTags.Restored_Heart_of_the_Wild,
            Text = @"Your units that have a total cost of (5) or more cost (4) less, but not less than (5). This replaces Heart of the Wild",
            LoreText = @"Your units that have a total cost of (5) or more cost (4) less, but not less than (5). This replaces Heart of the Wild",
            HonourPoints = 5,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
                CardResources.Wild,
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.RestoredHeartoftheWild,
        };
        UpgradeList.Add(upgrade52);

        var upgrade53 = new UpgradeData()
        {
            Id = 53,
            Name = "Void Portal",
            ImageTag = UpgradeImageTags.Void_Portal,
            Text = @"Your base <b>Summon</b> capacity is increased to 2",
            LoreText = @"Your base <b>Summon</b> capacity is increased to 2",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Abyssal,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.VoidPortal,
        };
        UpgradeList.Add(upgrade53);

        var upgrade54 = new UpgradeData()
        {
            Id = 54,
            Name = "Convergant Void Portal",
            ImageTag = UpgradeImageTags.Convergant_Void_Portal,
            Text = @"Your base <b>Summon</b> capacity is increased to 3. This replaces Void Portal",
            LoreText = @"Your base <b>Summon</b> capacity is increased to 3. This replaces Void Portal",
            HonourPoints = 5,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Abyssal,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ConvergantVoidPortal,
        };
        UpgradeList.Add(upgrade54);

        var upgrade55 = new UpgradeData()
        {
            Id = 55,
            Name = "Soul Sacrifice",
            ImageTag = UpgradeImageTags.Soul_Sacrifice,
            Text = @"After you <b>Discard</b> a card, restore health to your hero equal to it's total cost",
            LoreText = @"After you <b>Discard</b> a card, restore health to your hero equal to it's total cost",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Abyssal,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.SoulSacrifice,
        };
        UpgradeList.Add(upgrade55);

        var upgrade56 = new UpgradeData()
        {
            Id = 56,
            Name = "Thief's Gloves",
            ImageTag = UpgradeImageTags.Theifs_Gloves,
            Text = @"Whenever you <b>Recruit</b> a card, add an extra copy to your hand",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Agent,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ThiefsGloves,
        };
        UpgradeList.Add(upgrade56);

        var upgrade57 = new UpgradeData()
        {
            Id = 57,
            Name = "Thief's Tools",
            ImageTag = UpgradeImageTags.Thiefs_Tools,
            Text = @"Whenever you <b>Recruit</b> a card, add two extra copies to your hand. Replaces Thief's Gloves",
            LoreText = @"Whenever you <b>Recruit</b> a card, add two extra copies to your hand. Replaces Thief's Gloves",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Agent,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ThiefsTools,
        };
        UpgradeList.Add(upgrade57);

        var upgrade58 = new UpgradeData()
        {
            Id = 58,
            Name = "Shadow Meld",
            ImageTag = UpgradeImageTags.Shadow_Meld,
            Text = @"At the end of each of your turns, if your hero has not attacked, give them <b>Stealth</b> until the start of your next turn",
            LoreText = @"At the end of each of your turns, if your hero has not attacked, used an ability or cast a spell, give them <b>Stealth</b> until the start of your next turn",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Agent,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ShadowMeld,
        };
        UpgradeList.Add(upgrade58);

        var upgrade59 = new UpgradeData()
        {
            Id = 59,
            Name = "Replicative Spellbook",
            ImageTag = UpgradeImageTags.Replicative_Spellbook,
            Text = @"After you cast the first spell on your turn, add a new copy to your hand",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Arcanist,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ReplicativeSpellbook,
        };
        UpgradeList.Add(upgrade59);

        var upgrade60 = new UpgradeData()
        {
            Id = 60,
            Name = "Staff of Ages",
            ImageTag = UpgradeImageTags.Staff_of_Ages,
            Text = @"The leftmost spell in your hand costs (2) less",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Arcanist,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.StaffofAges,
        };
        UpgradeList.Add(upgrade60);

        var upgrade61 = new UpgradeData()
        {
            Id = 61,
            Name = "Staff of Time",
            ImageTag = UpgradeImageTags.Staff_of_Time,
            Text = @"The leftmost spell in your hand costs (4) less. This replaces Staff of Ages",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Arcanist,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.StaffofTime,
        };
        UpgradeList.Add(upgrade61);

        var upgrade62 = new UpgradeData()
        {
            Id = 62,
            Name = "Art of War",
            ImageTag = UpgradeImageTags.Art_of_War,
            Text = @"Whenever you use a Choice effect, you are able to Choose a second time",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Captain,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ArtofWar,
        };
        UpgradeList.Add(upgrade62);

        var upgrade63 = new UpgradeData()
        {
            Id = 63,
            Name = "Prepared Forces",
            ImageTag = UpgradeImageTags.Prepared_Forces,
            Text = @"The first minion without <b>Prepared</b> you play each turn has <b>Prepared</b>",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Captain,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.PreparedForces,
        };
        UpgradeList.Add(upgrade63);

        var upgrade64 = new UpgradeData()
        {
            Id = 64,
            Name = "Organised Forces",
            ImageTag = UpgradeImageTags.Organised_Forces,
            Text = @"Your minions without <b>Prepared</b> have <b>Prepared.</b> This replaces Prepared Forces",
            LoreText = @"",
            HonourPoints = 5,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Captain,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.OrganisedForces,
        };
        UpgradeList.Add(upgrade64);

        var upgrade65 = new UpgradeData()
        {
            Id = 65,
            Name = "Orb of the Elements",
            ImageTag = UpgradeImageTags.Orb_of_the_Elements,
            Text = @"At the start of each turn, add a random basic elemental spell to your hand",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Elementalist,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.OrboftheElements,
        };
        UpgradeList.Add(upgrade65);

        var upgrade66 = new UpgradeData()
        {
            Id = 66,
            Name = "Elemental Well",
            ImageTag = UpgradeImageTags.Elemental_Well,
            Text = @"At the start of each of your turns, add a random basic elemental spell to your hand and reduce its cost to 0. This replaces Orb of the Elements",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Elementalist,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ElementalWell,
        };
        UpgradeList.Add(upgrade66);

        var upgrade67 = new UpgradeData()
        {
            Id = 67,
            Name = "Magi's Fury",
            ImageTag = UpgradeImageTags.Magis_Fury,
            Text = @"The first time each scenario your hero dies, they are restored to 1 Health, gain <b>Protected (10), +3 Empowered</b> and you draw 3 cards. Your hero is destroyed at the end of your next turn",
            LoreText = @"",
            HonourPoints = 5,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Elementalist,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.MagisFury,
        };
        UpgradeList.Add(upgrade67);

        var upgrade68 = new UpgradeData()
        {
            Id = 68,
            Name = "Constricting Nature",
            ImageTag = UpgradeImageTags.Constricting_Nature,
            Text = @"Whenever you <b>Root</b> an already <b>Rooted</b> unit, deal 2 damage to it",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Grovewatcher,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ConstrictingNature,
        };
        UpgradeList.Add(upgrade68);

        var upgrade69 = new UpgradeData()
        {
            Id = 69,
            Name = "Nature's Thorns",
            ImageTag = UpgradeImageTags.Natures_Thorns,
            Text = @"Whenever you <b>Root</b> an already <b>Rooted</b> unit, deal 4 damage to it. This replaces Constricting Nature",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Grovewatcher,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.NaturesThorns,
        };
        UpgradeList.Add(upgrade69);

        var upgrade70 = new UpgradeData()
        {
            Id = 70,
            Name = "Faerie's Shroud",
            ImageTag = UpgradeImageTags.Faeries_Shroud,
            Text = @"You can target friendly Faerie units with spells",
            LoreText = @"You can target friendly Faerie units with spells",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Grovewatcher,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.FaeriesShroud,
        };
        UpgradeList.Add(upgrade70);

        var upgrade71 = new UpgradeData()
        {
            Id = 71,
            Name = "Restorative Blessing",
            ImageTag = UpgradeImageTags.Restorative_Blessing,
            Text = @"At the start of each of your turns, restore 2 health to all friendly units",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Lifebringer,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.RestorativeBlessing,
        };
        UpgradeList.Add(upgrade71);

        var upgrade72 = new UpgradeData()
        {
            Id = 72,
            Name = "Holy Blessing",
            ImageTag = UpgradeImageTags.Holy_Blessing,
            Text = @"At the start of each of your turns, restore 4 health to all friendly units. This replaes Restorative Blessing",
            LoreText = @"At the start of each of your turns, restore 4 health to all friendly units. This replaes Restorative Blessing",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Lifebringer,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.HolyBlessing,
        };
        UpgradeList.Add(upgrade72);

        var upgrade73 = new UpgradeData()
        {
            Id = 73,
            Name = "Shadow Crystal",
            ImageTag = UpgradeImageTags.Shadow_Crystal,
            Text = @"Your healing effects deal damage to enemy units",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Lifebringer,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ShadowCrystal,
        };
        UpgradeList.Add(upgrade73);

        var upgrade74 = new UpgradeData()
        {
            Id = 74,
            Name = "Sorted Collection",
            ImageTag = UpgradeImageTags.Sorted_Collection,
            Text = @"At the start of each turn, <b>Divinate (1)</b>",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Lorekeeper,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.SortedCollection,
        };
        UpgradeList.Add(upgrade74);

        var upgrade75 = new UpgradeData()
        {
            Id = 75,
            Name = "Ordered Collection",
            ImageTag = UpgradeImageTags.Ordered_Collection,
            Text = @"At the start of each turn, <b>Divinate (2)</b> and you draw an additional card. This replaces Sorted Collection",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Lorekeeper,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.OrderedCollection,
        };
        UpgradeList.Add(upgrade75);

        var upgrade76 = new UpgradeData()
        {
            Id = 76,
            Name = "Categorizing Algorithm",
            ImageTag = UpgradeImageTags.Categorizing_Algorithm,
            Text = @"The first time on a turn you shuffle a card into your deck, shuffle an additional copy. Reduce both card's cost by (2)",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Lorekeeper,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.CategorizingAlgorithm,
        };
        UpgradeList.Add(upgrade76);

        var upgrade77 = new UpgradeData()
        {
            Id = 77,
            Name = "Moonlit Vial",
            ImageTag = UpgradeImageTags.Moonlit_Vial,
            Text = @"Whenever you <b>Divinate,</b> from a card, your hero gains <b>Protected</b> equal to the <b>Divinate</b> value",
            LoreText = @"Whenever you <b>Divinate,</b> your hero gains <b>Protected</b> equal to the <b>Divinate</b> value",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Luminist,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.MoonlitVial,
        };
        UpgradeList.Add(upgrade77);

        var upgrade78 = new UpgradeData()
        {
            Id = 78,
            Name = "Moongraced Phial",
            ImageTag = UpgradeImageTags.Moongraced_Phial,
            Text = @"Whenever you <b>Divinate,</b> from a card, all friendly units gain <b>Protected</b> equal to the <b>Divinate</b> value, and your hero gains double. This replaces Moonlit Vial",
            LoreText = @"Whenever you <b>Divinate,</b> all friendly units gain <b>Protected</b> equal to the <b>Divinate</b> value, and your hero gains double. This replaces Moonlit Vial",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Luminist,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.MoongracedPhial,
        };
        UpgradeList.Add(upgrade78);

        var upgrade79 = new UpgradeData()
        {
            Id = 79,
            Name = "Star's Wrath",
            ImageTag = UpgradeImageTags.Stars_Wrath,
            Text = @"Your spells deal double damage to undamaged units",
            LoreText = @"",
            HonourPoints = 5,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Luminist,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.StarsWrath,
        };
        UpgradeList.Add(upgrade79);

        var upgrade80 = new UpgradeData()
        {
            Id = 80,
            Name = "Obligatory Contracts",
            ImageTag = UpgradeImageTags.Obligatory_Contracts,
            Text = @"Your Hirelings have +1 Attack, +1 Health",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Mercenary,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ObligatoryContracts,
        };
        UpgradeList.Add(upgrade80);

        var upgrade81 = new UpgradeData()
        {
            Id = 81,
            Name = "Binding Contracts",
            ImageTag = UpgradeImageTags.Binding_Contracts,
            Text = @"Your Hirelings have +2 Attack, +2 Health. This replaces Obligatory Contracts",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Mercenary,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.BindingContracts,
        };
        UpgradeList.Add(upgrade81);

        var upgrade82 = new UpgradeData()
        {
            Id = 82,
            Name = "Gather Cowards",
            ImageTag = UpgradeImageTags.Gather_Cowards,
            Text = @"Whenever a friendly unit <b>Routs,</b> a random friendly minion within range 2 gains its Attack and Health",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Mercenary,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.GatherCowards,
        };
        UpgradeList.Add(upgrade82);

        var upgrade83 = new UpgradeData()
        {
            Id = 83,
            Name = "Hallowed Scriptures",
            ImageTag = UpgradeImageTags.Hallowed_Scriptures,
            Text = @"Whenever you cast a spell on friendly units, add a new copy of the spell to your hand that <b>Discards</b> at the end of your turn",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Oathknight,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.HallowedScriptures,
        };
        UpgradeList.Add(upgrade83);

        var upgrade84 = new UpgradeData()
        {
            Id = 84,
            Name = "Angelic Ascension",
            ImageTag = UpgradeImageTags.Angelic_Ascension,
            Text = @"Your <b>Flying</b> units cost (2) less",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Oathknight,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.AngelicAscension,
        };
        UpgradeList.Add(upgrade84);

        var upgrade85 = new UpgradeData()
        {
            Id = 85,
            Name = "Heavenly Ascension",
            ImageTag = UpgradeImageTags.Heavenly_Ascension,
            Text = @"Your <b>Flying</b> units cost (4) less. This replaces Angelic Ascension",
            LoreText = @"",
            HonourPoints = 5,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Oathknight,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.HeavenlyAscension,
        };
        UpgradeList.Add(upgrade85);

        var upgrade86 = new UpgradeData()
        {
            Id = 86,
            Name = "Mana Shield",
            ImageTag = UpgradeImageTags.Mana_Shield,
            Text = @"After you cast a spell for the first time on a turn, the caster gains <b>Protected</b> equal to the total cost of the spell until the start of your next turn",
            LoreText = @"",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Runeblade,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ManaShield,
        };
        UpgradeList.Add(upgrade86);

        var upgrade87 = new UpgradeData()
        {
            Id = 87,
            Name = "Mana-Rune Shield",
            ImageTag = UpgradeImageTags.ManaRune_Shield,
            Text = @"After you cast a spell, the caster gains <b>Protected</b> equal to the total cost of the spell. This replaces Mana Shield",
            LoreText = @"After you cast a spell for the first time on a turn, the caster gains <b>Protected</b> equal to the total cost of the spell. This replaces Mana Shield",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Runeblade,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ManaRuneShield,
        };
        UpgradeList.Add(upgrade87);

        var upgrade88 = new UpgradeData()
        {
            Id = 88,
            Name = "Swift Blades",
            ImageTag = UpgradeImageTags.Swift_Blades,
            Text = @"The first time on each turn that your units kill a unit, they gain an action",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Runeblade,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.SwiftBlades,
        };
        UpgradeList.Add(upgrade88);

        var upgrade89 = new UpgradeData()
        {
            Id = 89,
            Name = "Jagged Edges",
            ImageTag = UpgradeImageTags.Jagged_Edges,
            Text = @"Your Shivs deal 1 extra damage",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Trickster,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.JaggedEdges,
        };
        UpgradeList.Add(upgrade89);

        var upgrade90 = new UpgradeData()
        {
            Id = 90,
            Name = "Serrated Edges",
            ImageTag = UpgradeImageTags.Serrated_Edges,
            Text = @"Your Shivs deal 2 extra damage and prevent the target from being healed until the end of their next turn. This replaces Jagged Edges",
            LoreText = @"Your Shivs deal 2 extra damage and prevent the target from being healed until the end of their next turn. This replaces Jagged Edges",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Trickster,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.SerratedEdges,
        };
        UpgradeList.Add(upgrade90);

        var upgrade91 = new UpgradeData()
        {
            Id = 91,
            Name = "Ghost Cloak",
            ImageTag = UpgradeImageTags.Ghost_Cloak,
            Text = @"Your hero has <b>Ethereal</b>",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Trickster,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.GhostCloak,
        };
        UpgradeList.Add(upgrade91);

        var upgrade92 = new UpgradeData()
        {
            Id = 92,
            Name = "Returning Quiver",
            ImageTag = UpgradeImageTags.Returning_Quiver,
            Text = @"Whenever you cast a shot spell, it has a 50% chance to return to your hand at the start of your next turn",
            LoreText = @"Whenever you cast a shot spell, it has a 50$ chance to return to your hand at the start of your next turn",
            HonourPoints = 2,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Waystalker,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ReturningQuiver,
        };
        UpgradeList.Add(upgrade92);

        var upgrade93 = new UpgradeData()
        {
            Id = 93,
            Name = "Never-Ending Quiver",
            ImageTag = UpgradeImageTags.NeverEnding_Quiver,
            Text = @"Whenever you cast a shot spell, it will return to your hand at the start of your next turn",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Waystalker,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.NeverEndingQuiver,
        };
        UpgradeList.Add(upgrade93);

        var upgrade94 = new UpgradeData()
        {
            Id = 94,
            Name = "Beastial Fury",
            ImageTag = UpgradeImageTags.Beastial_Fury,
            Text = @"Your beasts without <b>Unleash</b> have <b>Unleash.</b> Those with <b>Unleash</b> have <b>Prepared</b>",
            LoreText = @"",
            HonourPoints = 5,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Waystalker,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.BeastialFury,
        };
        UpgradeList.Add(upgrade94);

        var upgrade95 = new UpgradeData()
        {
            Id = 95,
            Name = "Pain-Driven Warriors",
            ImageTag = UpgradeImageTags.PainDriven_Warriors,
            Text = @"After a friendly unit takes damage and survives, restore 1 health to it",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Wildkin,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.PainDrivenWarriors,
        };
        UpgradeList.Add(upgrade95);

        var upgrade96 = new UpgradeData()
        {
            Id = 96,
            Name = "Undying Elites",
            ImageTag = UpgradeImageTags.Undying_Elites,
            Text = @"After a friendly unit takes damage and survives, restore 2 health to it. This replaces Pain-Driven Warriors",
            LoreText = @"",
            HonourPoints = 3,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Wildkin,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.UndyingElites,
        };
        UpgradeList.Add(upgrade96);

        var upgrade97 = new UpgradeData()
        {
            Id = 97,
            Name = "Shapeshifter's Mask",
            ImageTag = UpgradeImageTags.Shapeshifters_Mask,
            Text = @"After your <b>Transformed</b> units return to their original form, restore 5 health to them",
            LoreText = @"",
            HonourPoints = 4,
            IsRepeatable = false,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
                Classes.ClassList.Wildkin,
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ShapeshiftersMask,
        };
        UpgradeList.Add(upgrade97);

        var upgrade98 = new UpgradeData()
        {
            Id = 98,
            Name = "Elder's Protection",
            ImageTag = UpgradeImageTags.Elders_Protection,
            Text = @"Whenever you grant a unit <b>Protected</b>, give an additional <b>(1) Protected</b>",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.EldersProtection,
        };
        UpgradeList.Add(upgrade98);

        var upgrade99 = new UpgradeData()
        {
            Id = 99,
            Name = "Legion's Finest",
            ImageTag = UpgradeImageTags.Legions_Finest,
            Text = @"Your Soldier and Captain units have +1 Attack, +1 Health",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.LegionsFinest,
        };
        UpgradeList.Add(upgrade99);

        var upgrade100 = new UpgradeData()
        {
            Id = 100,
            Name = "From the Shadows",
            ImageTag = UpgradeImageTags.From_the_Shadows,
            Text = @"While your units are <b>Stealthed</b>, they have +2 Attack",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.FromtheShadows,
        };
        UpgradeList.Add(upgrade100);

        var upgrade101 = new UpgradeData()
        {
            Id = 101,
            Name = "Dark Woods",
            ImageTag = UpgradeImageTags.Dark_Woods,
            Text = @"At the end of your turn, give a random, friendly, non-<b>Stealth</b> unit that is in a difficult terrain tile <b>Stealth</b>",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.DarkWoods,
        };
        UpgradeList.Add(upgrade101);

        var upgrade102 = new UpgradeData()
        {
            Id = 102,
            Name = "Corrupting Power",
            ImageTag = UpgradeImageTags.Corrupting_Power,
            Text = @"Your hero is <b>Indestructible</b>, unless something can override your powers",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.CorruptingPower,
        };
        UpgradeList.Add(upgrade102);

        var upgrade103 = new UpgradeData()
        {
            Id = 103,
            Name = "Void Swarm",
            ImageTag = UpgradeImageTags.Void_Swarm,
            Text = @"After you <b>Discard</b> a card, you can choose to <b>Summon</b> a Voidling adjacent to your hero. Set its Attack and Health equal to the total cost of the card",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.VoidSwarm,
        };
        UpgradeList.Add(upgrade103);

        var upgrade104 = new UpgradeData()
        {
            Id = 104,
            Name = "Boon of Mogris",
            ImageTag = UpgradeImageTags.Boon_of_Mogris,
            Text = @"Your units with <b>Conduit</b> have +3 Health",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.BoonofMogris,
        };
        UpgradeList.Add(upgrade104);

        var upgrade105 = new UpgradeData()
        {
            Id = 105,
            Name = "Curse of the Barrows",
            ImageTag = UpgradeImageTags.Curse_of_the_Barrows,
            Text = @"Whenever an enemy unit dies on your turn, deploy a Cursed Shade in its place under your control",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.CurseoftheBarrows,
        };
        UpgradeList.Add(upgrade105);

        var upgrade106 = new UpgradeData()
        {
            Id = 106,
            Name = "Army of Shadows",
            ImageTag = UpgradeImageTags.Army_of_Shadows,
            Text = @"Increase your <b>Summon</b> capacity to 3 at the start of the scenario",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ArmyofShadows,
        };
        UpgradeList.Add(upgrade106);

        var upgrade107 = new UpgradeData()
        {
            Id = 107,
            Name = "Burning Trees",
            ImageTag = UpgradeImageTags.Burning_Trees,
            Text = @"Whenever an enemy unit enters or starts its turn in a tile adjacent to a friendly Treant unit, deal 3 damage to it.",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.BurningTrees,
        };
        UpgradeList.Add(upgrade107);

        var upgrade108 = new UpgradeData()
        {
            Id = 108,
            Name = "Cursed in Undeath",
            ImageTag = UpgradeImageTags.Cursed_in_Undeath,
            Text = @"Whenever your hero dies, they are redeployed instead with their max health permanently halved. If their max health goes below 7, they die permanently instead",
            LoreText = @"Whenever your hero dies, they are redeployed instead with their max health permanently halved. If their max health goes below 7, they die permanently instead",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.CursedinUndeath,
        };
        UpgradeList.Add(upgrade108);

        var upgrade109 = new UpgradeData()
        {
            Id = 109,
            Name = "Dragonslayer's Quiver",
            ImageTag = UpgradeImageTags.Dragonslayers_Quiver,
            Text = @"Whenever you generate a shot spell, you create an additional random shot spell",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.DragonslayersQuiver,
        };
        UpgradeList.Add(upgrade109);

        var upgrade110 = new UpgradeData()
        {
            Id = 110,
            Name = "Bow of Shadows",
            ImageTag = UpgradeImageTags.Bow_of_Shadows,
            Text = @"Your hero's attacks also hit a random enemy unit adjacent to the target. Your shot effects apply to both units",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.BowofShadows,
        };
        UpgradeList.Add(upgrade110);

        var upgrade111 = new UpgradeData()
        {
            Id = 111,
            Name = "Master of the Forge",
            ImageTag = UpgradeImageTags.Master_of_the_Forge,
            Text = @"Increase your item capacity to 2. Your items have +3 Durability",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.MasteroftheForge,
        };
        UpgradeList.Add(upgrade111);

        var upgrade112 = new UpgradeData()
        {
            Id = 112,
            Name = "Adaptive Armour",
            ImageTag = UpgradeImageTags.Adaptive_Armour,
            Text = @"At the start of your turn, if your units have less <b>Protected</b> than your <b>Empowered</b> value, increase their <b>Protected</b> to your <b>Empowered</b> value",
            LoreText = @"",
            HonourPoints = 0,
            IsRepeatable = false,
            NPCLocked = true,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.AdaptiveArmour,
        };
        UpgradeList.Add(upgrade112);

        var upgrade113 = new UpgradeData()
        {
            Id = 113,
            Name = "Scout Loot",
            ImageTag = UpgradeImageTags.Scout_Loot,
            Text = @"Serach for 3 new cards through the loot generator",
            LoreText = @"Serach for 3 new cards through the loot generator",
            HonourPoints = 2,
            IsRepeatable = true,
            NPCLocked = false,
            TierLevel = TierLevel.Default,
            ResourcePrerequisites = new List<CardResources>()
            {
            },
            ClassPrerequisites = new List<Classes.ClassList>()
            {
            },
            UpgradePrerequisites = new List<UpgradeData>(),
            UpgradeTag = UpgradeTags.ScoutLoot,
        };
        UpgradeList.Add(upgrade113);

        upgrade2.UpgradePrerequisites = new List<UpgradeData> { upgrade1 };
        upgrade4.UpgradePrerequisites = new List<UpgradeData> { upgrade3 };
        upgrade6.UpgradePrerequisites = new List<UpgradeData> { upgrade5 };
        upgrade9.UpgradePrerequisites = new List<UpgradeData> { upgrade8 };
        upgrade12.UpgradePrerequisites = new List<UpgradeData> { upgrade11 };
        upgrade15.UpgradePrerequisites = new List<UpgradeData> { upgrade14 };
        upgrade18.UpgradePrerequisites = new List<UpgradeData> { upgrade17 };
        upgrade21.UpgradePrerequisites = new List<UpgradeData> { upgrade20 };
        upgrade26.UpgradePrerequisites = new List<UpgradeData> { upgrade25 };
        upgrade28.UpgradePrerequisites = new List<UpgradeData> { upgrade27 };
        upgrade31.UpgradePrerequisites = new List<UpgradeData> { upgrade30 };
        upgrade33.UpgradePrerequisites = new List<UpgradeData> { upgrade32 };
        upgrade36.UpgradePrerequisites = new List<UpgradeData> { upgrade35 };
        upgrade39.UpgradePrerequisites = new List<UpgradeData> { upgrade38 };
        upgrade42.UpgradePrerequisites = new List<UpgradeData> { upgrade41 };
        upgrade45.UpgradePrerequisites = new List<UpgradeData> { upgrade44 };
        upgrade48.UpgradePrerequisites = new List<UpgradeData> { upgrade47 };
        upgrade52.UpgradePrerequisites = new List<UpgradeData> { upgrade51 };
        upgrade54.UpgradePrerequisites = new List<UpgradeData> { upgrade53 };
        upgrade57.UpgradePrerequisites = new List<UpgradeData> { upgrade56 };
        upgrade61.UpgradePrerequisites = new List<UpgradeData> { upgrade60 };
        upgrade64.UpgradePrerequisites = new List<UpgradeData> { upgrade63 };
        upgrade66.UpgradePrerequisites = new List<UpgradeData> { upgrade65 };
        upgrade69.UpgradePrerequisites = new List<UpgradeData> { upgrade68 };
        upgrade72.UpgradePrerequisites = new List<UpgradeData> { upgrade71 };
        upgrade75.UpgradePrerequisites = new List<UpgradeData> { upgrade74 };
        upgrade78.UpgradePrerequisites = new List<UpgradeData> { upgrade77 };
        upgrade81.UpgradePrerequisites = new List<UpgradeData> { upgrade80 };
        upgrade85.UpgradePrerequisites = new List<UpgradeData> { upgrade84 };
        upgrade87.UpgradePrerequisites = new List<UpgradeData> { upgrade86 };
        upgrade90.UpgradePrerequisites = new List<UpgradeData> { upgrade89 };
        upgrade93.UpgradePrerequisites = new List<UpgradeData> { upgrade92 };
        upgrade96.UpgradePrerequisites = new List<UpgradeData> { upgrade95 };
    }
}

namespace CategoryEnums
{
    public enum UpgradeTags
    {
        HeroUpgrade, AbilityUpgrade, DevotedFollowers, LastingPrayers, StrengthofArms, BattleSurges, ClaimBounty, EmergencyReserves, WellofKnowledge, StimulateLearning, ManaReserves, RestorePower, WildGrowth, CycleofNature, SupplyLines, DeathDefiant, SpellstoneAmulet, OrnateSpellstoneAmulet, EfficientQuartermasters, ExpertQuartermasters, StandAlone, ImportCraftsmen, ImportMasterCraftsmen, HonourThroughBattle, StrengthinHonour, ReserveForces, GoldenChalice, MithrilChalice, DivineProtection, WeaponMaster, WeaponVirtuoso, WoundResistant, BetterHires, TheBestHires, MonetaryMotivation, BreadthofKnowledge, UltimateKnowledge, PotentForetelling, CircletofPower, CrownoftheArcane, SummonersRod, FeralNature, HeartoftheWild, RestoredHeartoftheWild, VoidPortal, ConvergantVoidPortal, SoulSacrifice, ThiefsGloves, ThiefsTools, ShadowMeld, ReplicativeSpellbook, StaffofAges, StaffofTime, ArtofWar, PreparedForces, OrganisedForces, OrboftheElements, ElementalWell, MagisFury, ConstrictingNature, NaturesThorns, FaeriesShroud, RestorativeBlessing, HolyBlessing, ShadowCrystal, SortedCollection, OrderedCollection, CategorizingAlgorithm, MoonlitVial, MoongracedPhial, StarsWrath, ObligatoryContracts, BindingContracts, GatherCowards, HallowedScriptures, AngelicAscension, HeavenlyAscension, ManaShield, ManaRuneShield, SwiftBlades, JaggedEdges, SerratedEdges, GhostCloak, ReturningQuiver, NeverEndingQuiver, BeastialFury, PainDrivenWarriors, UndyingElites, ShapeshiftersMask, EldersProtection, LegionsFinest, FromtheShadows, DarkWoods, CorruptingPower, VoidSwarm, BoonofMogris, CurseoftheBarrows, ArmyofShadows, BurningTrees, CursedinUndeath, DragonslayersQuiver, BowofShadows, MasteroftheForge, AdaptiveArmour, ScoutLoot
    }

    public enum UpgradeImageTags
    {
        Hero_1, Hero_II, Ability_I, Ability_II, Devoted_Followers_I, Devoted_Followers_II, Lasting_Prayers, Strength_of_Arms_I, Strength_of_Arms_II, Battle_Surges, Claim_Bounty_I, Claim_Bounty_II, Emergency_Reserves, Well_of_Knowledge_I, Well_of_Knowledge_II, Stimulate_Learning, Mana_Reserves_I, Mana_Reserves_II, Restore_Power, Wild_Growth_I, Wild_Growth_II, Cycle_of_Nature, Supply_Lines, Death_Defiant, Spellstone_Amulet, Ornate_Spellstone_Amulet, Efficient_Quartermasters, Expert_Quartermasters, Stand_Alone, Import_Craftsmen, Import_Master_Craftsmen, Honour_Through_Battle, Strength_in_Honour, Reserve_Forces, Golden_Chalice, Mithril_Chalice, Divine_Protection, Weapon_Master, Weapon_Virtuoso, Wound_Resistant, Better_Hires, The_Best_Hires, Monetary_Motivation, Breadth_of_Knowledge, Ultimate_Knowledge, Potent_Foretelling, Circlet_of_Power, Crown_of_the_Arcane, Summoners_Rod, Feral_Nature, Heart_of_the_Wild, Restored_Heart_of_the_Wild, Void_Portal, Convergant_Void_Portal, Soul_Sacrifice, Theifs_Gloves, Thiefs_Tools, Shadow_Meld, Replicative_Spellbook, Staff_of_Ages, Staff_of_Time, Art_of_War, Prepared_Forces, Organised_Forces, Orb_of_the_Elements, Elemental_Well, Magis_Fury, Constricting_Nature, Natures_Thorns, Faeries_Shroud, Restorative_Blessing, Holy_Blessing, Shadow_Crystal, Sorted_Collection, Ordered_Collection, Categorizing_Algorithm, Moonlit_Vial, Moongraced_Phial, Stars_Wrath, Obligatory_Contracts, Binding_Contracts, Gather_Cowards, Hallowed_Scriptures, Angelic_Ascension, Heavenly_Ascension, Mana_Shield, ManaRune_Shield, Swift_Blades, Jagged_Edges, Serrated_Edges, Ghost_Cloak, Returning_Quiver, NeverEnding_Quiver, Beastial_Fury, PainDriven_Warriors, Undying_Elites, Shapeshifters_Mask, Elders_Protection, Legions_Finest, From_the_Shadows, Dark_Woods, Corrupting_Power, Void_Swarm, Boon_of_Mogris, Curse_of_the_Barrows, Army_of_Shadows, Burning_Trees, Cursed_in_Undeath, Dragonslayers_Quiver, Bow_of_Shadows, Master_of_the_Forge, Adaptive_Armour, Scout_Loot
    }
}
