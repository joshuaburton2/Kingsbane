using System.Collections.Generic;
using CategoryEnums;

public class CardLibrary
{
    public List<CardData> CardList { get; private set; }
    public List<AbilityData> AbilityList { get; private set; }

    public void InitLibrary()
    {
        CardList = new List<CardData>();
        AbilityList = new List<AbilityData>();

        var ability5 = new AbilityData()
        {
            Id = 5,
            Name = "Arcane Bolt",
            Text = @"Deal 2 damage to a unit within range 1",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability5);

        var ability6 = new AbilityData()
        {
            Id = 6,
            Name = "Kalyan Strike",
            Text = @"<b>Stun</b> an adjacent enemy unit",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability6);

        var ability7 = new AbilityData()
        {
            Id = 7,
            Name = "Runesmith",
            Text = @"Give a friendly unit within Range 1 <b>Empowered +1</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability7);

        var ability8 = new AbilityData()
        {
            Id = 8,
            Name = "Sword Fling",
            Text = @"Deal damage equal to your <b>Empowered</b> value to a unit within Range 2",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability8);

        var ability9 = new AbilityData()
        {
            Id = 9,
            Name = "Kalyan Training",
            Text = @"Give all other friendly melee units within Range 2 +2 Attack",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability9);

        var ability10 = new AbilityData()
        {
            Id = 10,
            Name = "Kalyan Strike",
            Text = @"<b>Stun</b> an adjacent enemy unit",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability10);

        var ability11 = new AbilityData()
        {
            Id = 11,
            Name = "Arcane Bolt",
            Text = @"Deal 4 damage to a unit within range 2",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability11);

        var ability12 = new AbilityData()
        {
            Id = 12,
            Name = "Arcane Bolt",
            Text = @"Deal 6 damage to a unit within Range 2",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability12);

        var ability13 = new AbilityData()
        {
            Id = 13,
            Name = "Arcane Knowledge",
            Text = @"Add a random playable spell to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability13);

        var ability14 = new AbilityData()
        {
            Id = 14,
            Name = "Arcane Knowledge",
            Text = @"Add a random playable spell to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability14);

        var ability15 = new AbilityData()
        {
            Id = 15,
            Name = "Arcane Knowledge",
            Text = @"Add 2 random playable spells to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability15);

        var ability16 = new AbilityData()
        {
            Id = 16,
            Name = "Conjure Voidling",
            Text = @"<b>Summon</b> a Voidling adjacent to your hero",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability16);

        var ability17 = new AbilityData()
        {
            Id = 17,
            Name = "Conjure Voidling",
            Text = @"<b>Summon</b> a Voidling adjacent to your hero. Give it +1 Attack, +1 Health",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability17);

        var ability18 = new AbilityData()
        {
            Id = 18,
            Name = "Conjure Voidling",
            Text = @"<b>Summon</b> a Voidling adjacent to your hero. Give it +2 Attack, +2 Health and <b>Spellshield</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability18);

        var ability21 = new AbilityData()
        {
            Id = 21,
            Name = "Info Exchange",
            Text = @"Shuffle a card in your hand into your deck. Draw a card",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability21);

        var ability22 = new AbilityData()
        {
            Id = 22,
            Name = "Info Exchange",
            Text = @"Shuffle a card in your hand into your deck. Draw a card",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability22);

        var ability23 = new AbilityData()
        {
            Id = 23,
            Name = "Info Exchange",
            Text = @"Shuffle two copies of a card in your hand into your deck. Draw a card",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability23);

        var ability24 = new AbilityData()
        {
            Id = 24,
            Name = "Lead from the Front",
            Text = @"Equip a ""Battle Gear"" item",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability24);

        var ability25 = new AbilityData()
        {
            Id = 25,
            Name = "Lead from the Front",
            Text = @"Equip a ""Battle Gear"" item. If you already have one equipped, increase the Attack and <b>Protected</b> value gained on the Gear by +1",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability25);

        var ability26 = new AbilityData()
        {
            Id = 26,
            Name = "Lead from the Front",
            Text = @"Equip a ""Battle Gear"" item. If you already have one equipped, increase the Attack and <b>Protected</b> value gained on the Gear by +2",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability26);

        var ability27 = new AbilityData()
        {
            Id = 27,
            Name = "Elemental Power",
            Text = @"Gain <b>Empowered +1</b> until the end of your turn",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability27);

        var ability28 = new AbilityData()
        {
            Id = 28,
            Name = "Elemental Power",
            Text = @"Gain <b>Empowered +2</b> until the end of your turn",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability28);

        var ability29 = new AbilityData()
        {
            Id = 29,
            Name = "Elemental Power",
            Text = @"Gain <b>Empowered +3</b> until the end of your turn",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability29);

        var ability30 = new AbilityData()
        {
            Id = 30,
            Name = "Plant Growth",
            Text = @"<b>Root</b> an enemy unit within Range 2",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability30);

        var ability31 = new AbilityData()
        {
            Id = 31,
            Name = "Plant Growth",
            Text = @"<b>Root</b> all enemy units in an area of Radius 2 within Range 2",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability31);

        var ability32 = new AbilityData()
        {
            Id = 32,
            Name = "Plant Growth",
            Text = @"<b>Root</b> all enemy units in an area of Radius 2 within Range 4",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability32);

        var ability33 = new AbilityData()
        {
            Id = 33,
            Name = "Healing Word",
            Text = @"Restore 2 Health to a unit within Range 1",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability33);

        var ability34 = new AbilityData()
        {
            Id = 34,
            Name = "Healing Word",
            Text = @"Restore 2 Health to a unit within Range 2",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability34);

        var ability35 = new AbilityData()
        {
            Id = 35,
            Name = "Healing Word",
            Text = @"Restore 4 Health to a unit within Range 3",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability35);

        var ability36 = new AbilityData()
        {
            Id = 36,
            Name = "Preserve Knowledge",
            Text = @"Shuffle a copy of the next spell you cast this turn into your  deck",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability36);

        var ability37 = new AbilityData()
        {
            Id = 37,
            Name = "Preserve Knowledge",
            Text = @"Shuffle a copy of the next spell you cast this turn into your deck",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability37);

        var ability38 = new AbilityData()
        {
            Id = 38,
            Name = "Preserve Knowledge",
            Text = @"Shuffle two copies of the next spell you cast this turn into your deck",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability38);

        var ability39 = new AbilityData()
        {
            Id = 39,
            Name = "Foretell",
            Text = @"<b>Divinate 1</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability39);

        var ability40 = new AbilityData()
        {
            Id = 40,
            Name = "Foretell",
            Text = @"<b>Divinate 2</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability40);

        var ability41 = new AbilityData()
        {
            Id = 41,
            Name = "Foretell",
            Text = @"<b>Divinate 3</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), },

            CostsAction = false,
        };
        AbilityList.Add(ability41);

        var ability43 = new AbilityData()
        {
            Id = 43,
            Name = "Enlist Hireling",
            Text = @"Deploy a random ""Hireling"" unit adjacent to your hero",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability43);

        var ability44 = new AbilityData()
        {
            Id = 44,
            Name = "Enlist Hireling",
            Text = @"Deploy a ""Hireling"" unit of your choice adjacent to your hero",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability44);

        var ability51 = new AbilityData()
        {
            Id = 51,
            Name = "Enlist Hireling",
            Text = @"Deploy a random ""Hireling"" adjacent to your hero",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability51);

        var ability52 = new AbilityData()
        {
            Id = 52,
            Name = "Holy Shield",
            Text = @"Give all friendly units within Range 1 of the hero <b>Protected (1)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability52);

        var ability53 = new AbilityData()
        {
            Id = 53,
            Name = "Holy Shield",
            Text = @"Give all friendly units within Range 1 of the hero <b>Protected (2)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability53);

        var ability54 = new AbilityData()
        {
            Id = 54,
            Name = "Holy Shield",
            Text = @"Give all friendly units within Range 2 of the hero <b>Protected (3)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability54);

        var ability55 = new AbilityData()
        {
            Id = 55,
            Name = "Resupply",
            Text = @"Add a ""Shiv"" card to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability55);

        var ability56 = new AbilityData()
        {
            Id = 56,
            Name = "Resupply",
            Text = @"Add two ""Shiv"" cards to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability56);

        var ability57 = new AbilityData()
        {
            Id = 57,
            Name = "Resupply",
            Text = @"Add three ""Shiv"" cards to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability57);

        var ability58 = new AbilityData()
        {
            Id = 58,
            Name = "Hound Training",
            Text = @"Deploy two ""Trained Hounds"" beside your hero",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability58);

        var ability59 = new AbilityData()
        {
            Id = 59,
            Name = "Hound Training",
            Text = @"Deploy two ""Trained Hounds"" beside your hero. Give them +1 Attack",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability59);

        var ability60 = new AbilityData()
        {
            Id = 60,
            Name = "Hound Training",
            Text = @"Deploy two ""Trained Hounds"" beside your hero. Give them +2 Attack",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability60);

        var ability61 = new AbilityData()
        {
            Id = 61,
            Name = "Enrage",
            Text = @"Give your hero +2 Attack until the end of your turn and <b>Protected (1)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability61);

        var ability62 = new AbilityData()
        {
            Id = 62,
            Name = "Enrage",
            Text = @"Your hero gains +3 Attack until the end of your turn and <b>Protected (2)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability62);

        var ability63 = new AbilityData()
        {
            Id = 63,
            Name = "Enrage",
            Text = @"Your hero gains +4 Attack until the end of your turn and <b>Protected (3)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability63);

        var ability64 = new AbilityData()
        {
            Id = 64,
            Name = "Magic Missiles",
            Text = @"Deal 3 damage randomly split among all enemies in an area of Cone 3",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability64);

        var ability65 = new AbilityData()
        {
            Id = 65,
            Name = "Studious Research",
            Text = @"<b>Study (3)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability65);

        var ability66 = new AbilityData()
        {
            Id = 66,
            Name = "Stargaze",
            Text = @"<b>Divinate 1</b>",

            Resources = new List<Resource>() { },

            CostsAction = true,
        };
        AbilityList.Add(ability66);

        var ability67 = new AbilityData()
        {
            Id = 67,
            Name = "Lifedrain",
            Text = @"Deal 3 damage to an adjacent unit. Heal this unit for the amount of damage dealt",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability67);

        var ability68 = new AbilityData()
        {
            Id = 68,
            Name = "Brood Spawn",
            Text = @"<b>Discard</b> a card. Deploy two Abyss Imps beside this unit",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability68);

        var ability69 = new AbilityData()
        {
            Id = 69,
            Name = "Call of the Void",
            Text = @"Add a random Void unit to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability69);

        var ability70 = new AbilityData()
        {
            Id = 70,
            Name = "Consume",
            Text = @"<b>Discard</b> a card. Gain mana equal to its total cost",

            Resources = new List<Resource>() { },

            CostsAction = true,
        };
        AbilityList.Add(ability70);

        var ability71 = new AbilityData()
        {
            Id = 71,
            Name = "For the Void",
            Text = @"<b>Discard</b> a card. Give all adjacent Void units Attack and Health equal to its total cost",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability71);

        var ability72 = new AbilityData()
        {
            Id = 72,
            Name = "Surveillance",
            Text = @"<b>Study (3).</b> Shuffle an additional <b>Inspiration</b> card for each adjacent enemy unit",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability72);

        var ability73 = new AbilityData()
        {
            Id = 73,
            Name = "Triage",
            Text = @"Restore 2 Health to a unit",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability73);

        var ability74 = new AbilityData()
        {
            Id = 74,
            Name = "Confiscate",
            Text = @"Remove a random card from your opponents hand",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), },

            CostsAction = true,
        };
        AbilityList.Add(ability74);

        var ability75 = new AbilityData()
        {
            Id = 75,
            Name = "Imprison",
            Text = @"Remove an enemy minion from the battlefield",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), },

            CostsAction = true,
        };
        AbilityList.Add(ability75);

        var ability76 = new AbilityData()
        {
            Id = 76,
            Name = "Call to Arms",
            Text = @"Deploy two ""Goldland Loyalists"" adjacent to this unit or give all friendly units within Range 2 +2 Attack, +2 Health",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), },

            CostsAction = true,
        };
        AbilityList.Add(ability76);

        var ability77 = new AbilityData()
        {
            Id = 77,
            Name = "FIREBLAST!",
            Text = @"Deal damage to all other units within Range 2 equal to your <b>Empowered</b> value",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability77);

        var ability78 = new AbilityData()
        {
            Id = 78,
            Name = "Earthspike",
            Text = @"Deal damage to all units in an area of Cone 3 equal to your <b>Empowered</b> value and <b>Root</b> them",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability78);

        var ability79 = new AbilityData()
        {
            Id = 79,
            Name = "Call of the Winds",
            Text = @"Draw a card. If it is a spell, reduce its cost by (3). <b>Cycle -3</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability79);

        var ability80 = new AbilityData()
        {
            Id = 80,
            Name = "Water Whip",
            Text = @"Choose a unit within Range 4. Deal 1 damage to it and pull it up to 1 tile closer. If the unit is hostile and adjacent to this unit, this unit attacks it",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability80);

        var ability81 = new AbilityData()
        {
            Id = 81,
            Name = "Master of the Elements",
            Text = @"Add a random basic Elemental Spell to your hand. <b>Cycle -2</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability81);

        var ability82 = new AbilityData()
        {
            Id = 82,
            Name = "Wild Ritual",
            Text = @"<b>Prayer +1</b>",

            Resources = new List<Resource>() { },

            CostsAction = true,
        };
        AbilityList.Add(ability82);

        var ability83 = new AbilityData()
        {
            Id = 83,
            Name = "Faerie Charm",
            Text = @"Gain control of an enemy minion within Range 2 until the end of your turn",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), new Resource(CardResources.Wild, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability83);

        var ability84 = new AbilityData()
        {
            Id = 84,
            Name = "Holy Ritual",
            Text = @"<b>Prayer +1</b>",

            Resources = new List<Resource>() { },

            CostsAction = true,
        };
        AbilityList.Add(ability84);

        var ability85 = new AbilityData()
        {
            Id = 85,
            Name = "Soothe Wounds",
            Text = @"Restore 3 Health to a unit within Range 1",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability85);

        var ability86 = new AbilityData()
        {
            Id = 86,
            Name = "Collect Dues",
            Text = @"Gain 2 Gold for every adjacent friendly unit",

            Resources = new List<Resource>() { },

            CostsAction = true,
        };
        AbilityList.Add(ability86);

        var ability87 = new AbilityData()
        {
            Id = 87,
            Name = "Potion Sale",
            Text = @"Add a random potion card to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability87);

        var ability88 = new AbilityData()
        {
            Id = 88,
            Name = "Call the Host",
            Text = @"Deploy a ""Golden Host"" unit adjacent to this unit",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 3), new Resource(CardResources.Gold, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability88);

        var ability89 = new AbilityData()
        {
            Id = 89,
            Name = "Meditative Ritual",
            Text = @"<b>Prayer +1</b>",

            Resources = new List<Resource>() { },

            CostsAction = true,
        };
        AbilityList.Add(ability89);

        var ability90 = new AbilityData()
        {
            Id = 90,
            Name = "Submit Collection",
            Text = @"<b>Study (3).</b> One of the <b>Inspiration</b> cards shuffled is placed on the top of your deck",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability90);

        var ability91 = new AbilityData()
        {
            Id = 91,
            Name = "Search Archives",
            Text = @"Draw an <b>Inspiration</b> card from your deck",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability91);

        var ability92 = new AbilityData()
        {
            Id = 92,
            Name = "Deep Exposure",
            Text = @"Deal <b>Piercing</b> damage to a unit within Range 3 equal to its attack.",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), new Resource(CardResources.Knowledge, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability92);

        var ability93 = new AbilityData()
        {
            Id = 93,
            Name = "Pull Record",
            Text = @"Draw a spell which did not start in your deck",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability93);

        var ability94 = new AbilityData()
        {
            Id = 94,
            Name = "Heavenly Ritual",
            Text = @"<b>Prayer +1</b>",

            Resources = new List<Resource>() { },

            CostsAction = true,
        };
        AbilityList.Add(ability94);

        var ability95 = new AbilityData()
        {
            Id = 95,
            Name = "Fetch Gear",
            Text = @"Draw a card",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability95);

        var ability96 = new AbilityData()
        {
            Id = 96,
            Name = "Hefty Bribe",
            Text = @"<b>Recruit</b> an enemy minion within Range 5 that has a total cost of (5) or less",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), },

            CostsAction = true,
        };
        AbilityList.Add(ability96);

        var ability97 = new AbilityData()
        {
            Id = 97,
            Name = "Run Messages",
            Text = @"Draw a card for every 2 tiles moved this turn",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability97);

        var ability98 = new AbilityData()
        {
            Id = 98,
            Name = "Smuggle",
            Text = @"Return a friendly minion to your hand, or redeploy your hero",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability98);

        var ability99 = new AbilityData()
        {
            Id = 99,
            Name = "Shadowy Ritual",
            Text = @"<b>Prayer +1</b>",

            Resources = new List<Resource>() { },

            CostsAction = true,
        };
        AbilityList.Add(ability99);

        var ability100 = new AbilityData()
        {
            Id = 100,
            Name = "Grey Blood",
            Text = @"<b>Regenerate, Cycle -3</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability100);

        var ability101 = new AbilityData()
        {
            Id = 101,
            Name = "Shapechange",
            Text = @"<b>Transform</b> this unit into a Hulking Beast. <b>Cycle -3</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability101);

        var ability102 = new AbilityData()
        {
            Id = 102,
            Name = "Roar",
            Text = @"<b>Stun</b> an enemy unit within Range 2",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability102);

        var ability103 = new AbilityData()
        {
            Id = 103,
            Name = "Caw",
            Text = @"Reduce the attack of all adjacent enemy units by 3 until the start of your next turn",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability103);

        var ability104 = new AbilityData()
        {
            Id = 104,
            Name = "Leap",
            Text = @"Jump to an empty tile within Range 3, then melee attack a random adjacent enemy unit",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability104);

        var ability105 = new AbilityData()
        {
            Id = 105,
            Name = "Rush",
            Text = @"Gain <b>Unleash</b> until the end of your turn",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability105);

        var ability106 = new AbilityData()
        {
            Id = 106,
            Name = "Spirit Walk",
            Text = @"<b>Regenerate. Cycle -3</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability106);

        var ability107 = new AbilityData()
        {
            Id = 107,
            Name = "Brawler",
            Text = @"Add a random Brawl card to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability107);

        var ability108 = new AbilityData()
        {
            Id = 108,
            Name = "Feast",
            Text = @"Restore 2 Health to all friendly adjacent units",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability108);

        var ability109 = new AbilityData()
        {
            Id = 109,
            Name = "Seduce",
            Text = @"<b>Recruit</b> an adjacent enemy unit that has a total cost of (3) or less or restore 5 health to a friendly unit",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability109);

        var ability110 = new AbilityData()
        {
            Id = 110,
            Name = "Secret Techniques",
            Text = @"Add a random playable spell that costs just Energy to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability110);

        var ability111 = new AbilityData()
        {
            Id = 111,
            Name = "Warcry",
            Text = @"Give all adjacent friendly Goblin units +2 Attack until the end of your turn",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability111);

        var ability1108 = new AbilityData()
        {
            Id = 1108,
            Name = "Rally the Horde",
            Text = @"Deploy 2 Goblin Hordes beside this unit",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1108);

        var ability1109 = new AbilityData()
        {
            Id = 1109,
            Name = "Enlistment",
            Text = @"Add a Hireling of your choice to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability1109);

        var ability1110 = new AbilityData()
        {
            Id = 1110,
            Name = "Glimpse",
            Text = @"Look at the top 3 cards of your deck. Choose which one to place on top of your deck",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability1110);

        var ability1111 = new AbilityData()
        {
            Id = 1111,
            Name = "Trade Tales",
            Text = @"<b>Divinate (1)</b> and give an adjacent friendlly unit <b>Protected (2)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = false,
        };
        AbilityList.Add(ability1111);

        var ability1112 = new AbilityData()
        {
            Id = 1112,
            Name = "Exchange Stories",
            Text = @"<b>Study (3).</b> The <b>Study</b> value of this effect cannot be reduced below 1",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability1112);

        var ability1114 = new AbilityData()
        {
            Id = 1114,
            Name = "Starcall",
            Text = @"This units next attack this turn also deals 2 damage to all adjacent units",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability1114);

        var ability1115 = new AbilityData()
        {
            Id = 1115,
            Name = "Moondrain",
            Text = @"<b>Spellbind</b> a unit within Range 3. Deal damage to the unit equal to the nmber of enchantments removed. This unit gains any attack and health statistics removed",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1115);

        var ability1116 = new AbilityData()
        {
            Id = 1116,
            Name = "Prophecy",
            Text = @"Choose to experience a vision of the Past, Present or Future",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1116);

        var ability1117 = new AbilityData()
        {
            Id = 1117,
            Name = "Conjure Mirror",
            Text = @"Deploy a ""Mirror Aspect"" with stats equal to this unit adjacent. Destroy any ""Mirror Aspects"" previously created by this unit. <b>Cycle -2</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1117);

        var ability1118 = new AbilityData()
        {
            Id = 1118,
            Name = "Scouting Mission",
            Text = @"<b>Divinate (1)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability1118);

        var ability1119 = new AbilityData()
        {
            Id = 1119,
            Name = "Deep Study",
            Text = @"<b>Divinate (1)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability1119);

        var ability1120 = new AbilityData()
        {
            Id = 1120,
            Name = "War Training",
            Text = @"Give all beasts in your hand +1 Attack, +1 Health",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability1120);

        var ability1121 = new AbilityData()
        {
            Id = 1121,
            Name = "Craft Arrows",
            Text = @"Choose one of three random shot spells to add to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability1121);

        var ability1122 = new AbilityData()
        {
            Id = 1122,
            Name = "Blood Leap",
            Text = @"Choose a damaged enemy unit within range 2. Move this unit directly to a tile adjacent and attack the target",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability1122);

        var ability1123 = new AbilityData()
        {
            Id = 1123,
            Name = "Devour",
            Text = @"Destroy an adjacent minion with less attack than this. This ability activates <b>Unleash. Cycle -2</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1123);

        var ability1124 = new AbilityData()
        {
            Id = 1124,
            Name = "Infiltration",
            Text = @"<b>Study (3)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), },

            CostsAction = true,
        };
        AbilityList.Add(ability1124);

        var ability1125 = new AbilityData()
        {
            Id = 1125,
            Name = "Disappear",
            Text = @"Gain <b>Stealth</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability1125);

        var ability1126 = new AbilityData()
        {
            Id = 1126,
            Name = "Make Arrangements",
            Text = @"Shuffle a card in your hand into your deck, then draw it",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1126);

        var ability1127 = new AbilityData()
        {
            Id = 1127,
            Name = "Spycraft",
            Text = @"Look at 3 cards in your opponent's hand. Choose to <b>Recruit</b> a copy of one of them",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1127);

        var ability1128 = new AbilityData()
        {
            Id = 1128,
            Name = "Repair",
            Text = @"Restore 2 Health to this unit",

            Resources = new List<Resource>() { },

            CostsAction = true,
        };
        AbilityList.Add(ability1128);

        var ability1129 = new AbilityData()
        {
            Id = 1129,
            Name = "Flame Breath",
            Text = @"Deal 2 damage to all units in area of Cone 3",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1129);

        var ability1130 = new AbilityData()
        {
            Id = 1130,
            Name = "Call of the Wild",
            Text = @"Draw a beast from your deck and give it +1 Attack, +1 Health",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            CostsAction = false,
        };
        AbilityList.Add(ability1130);

        var ability1131 = new AbilityData()
        {
            Id = 1131,
            Name = "Elder's Wisdom",
            Text = @"<b>Divinate (1)</b> and give a friendly unit within range 1 <b>Protected (2)</b>",

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability1131);

        var ability1132 = new AbilityData()
        {
            Id = 1132,
            Name = "Legion's Aid",
            Text = @"Deploy a Legionnaire unit adjacent to this unit",

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability1132);

        var ability1133 = new AbilityData()
        {
            Id = 1133,
            Name = "Sap",
            Text = @"<b>Redeploy</b> an adjacent unit, then gain <b>Stealth</b> until the start of your next turn",

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1133);

        var ability1134 = new AbilityData()
        {
            Id = 1134,
            Name = "Fist of Mogris",
            Text = @"<b>Discard</b> a card and choose an area of Radius 2. At the start of your next turn, deal damage equal to the cards total cost",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1134);

        var ability1135 = new AbilityData()
        {
            Id = 1135,
            Name = "Soul Pact",
            Text = @"Return a random card in your <b>Discard</b> pool to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1135);

        var ability1136 = new AbilityData()
        {
            Id = 1136,
            Name = "Shadowdrain",
            Text = @"Deal 4 <b>Lifebond</b> damage to an adjacent unit and reduce its speed by 1 until the start of your next turn",

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1136);

        var ability1137 = new AbilityData()
        {
            Id = 1137,
            Name = "Flame Tempest",
            Text = @"Deal 2 damage to all units in an area of Radius 2 within range 3. If the unit is a friendly Treant, restore 2 health instead",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1137);

        var ability1138 = new AbilityData()
        {
            Id = 1138,
            Name = "Dragon's Curse",
            Text = @"Deal 1 damage randomly split among all enemy units. Upgrades after each use",

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            CostsAction = true,
        };
        AbilityList.Add(ability1138);

        var ability1139 = new AbilityData()
        {
            Id = 1139,
            Name = "Hammer of Sithrimus",
            Text = @"Deal 3 damage and <b>Root</b> all units in area of Radius 2 centred on this unit",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1139);

        var ability1140 = new AbilityData()
        {
            Id = 1140,
            Name = "Se'Carr's Chosen",
            Text = @"<b>Discard</b> a card to deploy a Tentacle of Se'Carr within range 5. Set its attack equal to the total cost of the <b>Discarded</b> card.",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = false,
        };
        AbilityList.Add(ability1140);

        var ability1141 = new AbilityData()
        {
            Id = 1141,
            Name = "Soul Pact",
            Text = @"Return a random card in your <b>Discard</b> pool to your hand",

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            CostsAction = true,
        };
        AbilityList.Add(ability1141);

        var card2 = new UnitData()
        {
            Id = 2,
            Name = "Runeblade",
            ImageTag = CardImageTags.Runeblade1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Runeblade, Tags.Ability, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Runeblade,
            },
            Attack = 4,
            Health = 14,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability5 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card2);

        var card4 = new SpellData()
        {
            Id = 4,
            Name = "Arcane Rush",
            ImageTag = CardImageTags.Arcane_Rush,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 0), new Resource(CardResources.Mana, 3), },

            Text = @"Gain 4 Energy and give the caster +2 Attack until the end of your next turn.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.EnergyGain, Tags.Enchantment },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Enchantment },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card4);

        var card5 = new SpellData()
        {
            Id = 5,
            Name = "Blade Enchantment",
            ImageTag = CardImageTags.Blade_Enchantment,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 1), new Resource(CardResources.Mana, 2), },

            Text = @"Give a melee unit +3 Attack. Improved by your <b>Empowered</b> value.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Enchantment, Synergies.Empowered, Synergies.Melee, Synergies.SmallSpells },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card5);

        var card6 = new UnitData()
        {
            Id = 6,
            Name = "Kalyan Duelist",
            ImageTag = CardImageTags.Kalyan_Duelist,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"<b>Swiftstrike</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Blademaster, Tags.Human, Tags.Ability, Tags.Swiftstrike, Tags.Stun },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Enchantment, Synergies.Melee, Synergies.Stun, Synergies.Mobility },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Blademaster,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability6 },

            Keywords = new List<Keywords>() { Keywords.Swiftstrike },
        };
        CardList.Add(card6);

        var card7 = new SpellData()
        {
            Id = 7,
            Name = "Kalyan Strike",
            ImageTag = CardImageTags.Kalyan_Strike,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"<b>Stun</b> an enemy unit. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.Draw },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Stun, Synergies.Control, Synergies.Draw },
            SpellType = "Enchantment",
            Range = 1,
        };
        CardList.Add(card7);

        var card8 = new UnitData()
        {
            Id = 8,
            Name = "Kalyan Warrior",
            ImageTag = CardImageTags.Kalyan_Warrior,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"Deals double damage to <b>Stunned</b> units.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Blademaster, Tags.Human, Tags.Stun },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Melee, Synergies.Stun },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Blademaster,
            },
            Attack = 3,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card8);

        var card9 = new UnitData()
        {
            Id = 9,
            Name = "Rune Forger",
            ImageTag = CardImageTags.Rune_Forger,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            Text = @"<b>Empowered +1, Protected (3)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Dwarven, Tags.Arcanist, Tags.Empowered, Tags.Protected },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Empowered, Synergies.Melee, Synergies.Protected },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Dwarven,
                UnitTags.Arcanist,
            },
            Attack = 3,
            Health = 2,
            Protected = 3,
            Range = 0,
            Speed = 2,
            Empowered = 1,

            Abilities = new List<AbilityData>() { ability7 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card9);

        var card10 = new SpellData()
        {
            Id = 10,
            Name = "Blade Dance",
            ImageTag = CardImageTags.Blade_Dance,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 7), },

            Text = @"The caster gains <b>Swiftstrike</b> and <b>Immune</b> until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Swiftstrike, Tags.Immune },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Durable, Synergies.BigSpells, Synergies.Defensive },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card10);

        var card11 = new SpellData()
        {
            Id = 11,
            Name = "Feint",
            ImageTag = CardImageTags.Feint,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), },

            Text = @"The caster deals attack damage to an enemy and then moves 1 tile directly away from the target unit. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Empowered, Synergies.Mobility, Synergies.Control, Synergies.Defensive },
            SpellType = "Damage",
            Range = 1,
        };
        CardList.Add(card11);

        var card12 = new SpellData()
        {
            Id = 12,
            Name = "Magic Dash",
            ImageTag = CardImageTags.Magic_Dash,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), new Resource(CardResources.Mana, 3), },

            Text = @"Teleport the caster to an empty tile. Deal damage equal to the caster's attack to all enemies in between",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Empowered, Synergies.Mobility },
            SpellType = "Damage",
            Range = 4,
        };
        CardList.Add(card12);

        var card13 = new SpellData()
        {
            Id = 13,
            Name = "Blade Twirl",
            ImageTag = CardImageTags.Blade_Twirl,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 5), },

            Text = @"Deal damage equal to the caster's attack to all adjacent units",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Empowered, Synergies.Control, Synergies.BigSpells, Synergies.AreaDamage },
            SpellType = "Damage",
            Range = 0,
        };
        CardList.Add(card13);

        var card14 = new UnitData()
        {
            Id = 14,
            Name = "Swordcaster",
            ImageTag = CardImageTags.Swordcaster,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), new Resource(CardResources.Mana, 2), },

            Text = @"<b>Conduit, Empowered +1, Protected (4)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Runeblade, Tags.Ability, Tags.Dwarven, Tags.Empowered, Tags.Protected, Tags.Conduit },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Empowered, Synergies.Melee, Synergies.Protected },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Dwarven,
                UnitTags.Runeblade,
            },
            Attack = 3,
            Health = 1,
            Protected = 4,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability8 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card14);

        var card15 = new UnitData()
        {
            Id = 15,
            Name = "Spectral Staff",
            ImageTag = CardImageTags.Spectral_Staff,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 4), },

            Text = @"<b>Summon, Spellshield, Ethereal, Conduit, Empowered +2</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Empowered, Tags.Conduit, Tags.Summon, Tags.Spellshield, Tags.Ethereal, Tags.Arcane },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Antimagic, Synergies.Summon, Synergies.Midrange, Synergies.Ethereal },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Arcane,
                UnitTags.Summon,
            },
            Attack = 2,
            Health = 3,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 2,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Ethereal, Keywords.Spellshield, Keywords.Summon },
        };
        CardList.Add(card15);

        var card16 = new UnitData()
        {
            Id = 16,
            Name = "Spectral Shield",
            ImageTag = CardImageTags.Spectral_Shield,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 4), },

            Text = @"<b>Summon, Spellshield, Ethereal, Warden, Protected (9)</b>
Whenever an adjacent ally takes damage, this unit takes it instead",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Protected, Tags.Summon, Tags.Spellshield, Tags.Ethereal, Tags.Arcane, Tags.Warden },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Durable, Synergies.Protected, Synergies.Antimagic, Synergies.Summon, Synergies.Ethereal, Synergies.Defensive },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Arcane,
                UnitTags.Summon,
            },
            Attack = 0,
            Health = 6,
            Protected = 9,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Ethereal, Keywords.Spellshield, Keywords.Summon, Keywords.Warden },
        };
        CardList.Add(card16);

        var card17 = new UnitData()
        {
            Id = 17,
            Name = "Spectral Sword",
            ImageTag = CardImageTags.Spectral_Sword,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 4), },

            Text = @"<b>Summon, Spellshield, Ethereal, Prepared</b>
This units attack is increased by your <b>Empowered</b> value",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Spellshield, Tags.Ethereal, Tags.Arcane, Tags.Prepared },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Empowered, Synergies.Melee, Synergies.Antimagic, Synergies.Summon, Synergies.Ethereal },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Arcane,
                UnitTags.Summon,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Ethereal, Keywords.Prepared, Keywords.Spellshield, Keywords.Summon },
        };
        CardList.Add(card17);

        var card18 = new SpellData()
        {
            Id = 18,
            Name = "Warding Rune",
            ImageTag = CardImageTags.Warding_Rune,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"The caster gains <b>Protected (6)</b> until the start of your next turn. Until then, whenever the caster takes damage while still <b>Protected</b>, deal damage to all adjacent units equal to the amount of <b>Protected</b> removed",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Protected, Tags.AreaDamage },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Durable, Synergies.Protected, Synergies.BigSpells, Synergies.AreaDamage, Synergies.Mana, Synergies.Defensive },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card18);

        var card19 = new UnitData()
        {
            Id = 19,
            Name = "Retired Blademaster",
            ImageTag = CardImageTags.Retired_Blademaster,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 5), },

            Text = @"<b>Deployment:</b> Use <b>Kalyan Training</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Blademaster, Tags.Human, Tags.Ability, Tags.Deployment },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Melee, Synergies.Deployment, Synergies.Swarm, Synergies.BigMinions },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Blademaster,
            },
            Attack = 5,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability9 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card19);

        var card20 = new UnitData()
        {
            Id = 20,
            Name = "Mana Siphoner",
            ImageTag = CardImageTags.Mana_Siphoner,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"<b>Conduit, Protected (7)</b>
Whenever this unit kills an enemy unit, gain 3 Mana",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Runeblade, Tags.Dwarven, Tags.Protected, Tags.Conduit, Tags.ManaGain },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Protected, Synergies.Mana, Synergies.BigMinions },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Dwarven,
                UnitTags.Runeblade,
            },
            Attack = 5,
            Health = 3,
            Protected = 7,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card20);

        var card21 = new ItemData()
        {
            Id = 21,
            Name = "Mirror Entity",
            ImageTag = CardImageTags.Mirror_Entity,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"Whenever your Hero is attacked, they take no damage",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Equip, Tags.Conjured, Tags.Image },
            Synergies = new List<Synergies> { },
            ItemTag = "Conjured Image",
            Durability = 3,
        };
        CardList.Add(card21);

        var card24 = new SpellData()
        {
            Id = 24,
            Name = "Mirror Image",
            ImageTag = CardImageTags.Mirror_Image,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"Equip your hero with a ""Mirror Entity"" item. Increase Durability of the item by your <b>Empowered</b> value",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Equip },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Durable, Synergies.BigSpells, Synergies.Mana, Synergies.Defensive, Synergies.Equip },
            SpellType = "Equipment",
            Range = 0,
        };
        CardList.Add(card24);

        var card25 = new UnitData()
        {
            Id = 25,
            Name = "Atarias, Blade of the Kalyan",
            ImageTag = CardImageTags.Atarias_Blade_of_the_Kalyan,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 9), },

            Text = @"<b>Swiftstrike</b>
This unit's <b>Swiftstrike</b> grants it two additional actions. It can use it's ability multiple times in a turn.
Whenever this attacks a <b>Stunned</b> unit, draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Blademaster, Tags.Human, Tags.Ability, Tags.Swiftstrike },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Melee, Synergies.Stun, Synergies.Draw },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Blademaster,
            },
            Attack = 7,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability10 },

            Keywords = new List<Keywords>() { Keywords.SpecialSwiftstrike },
        };
        CardList.Add(card25);

        var card26 = new ItemData()
        {
            Id = 26,
            Name = "Nadalya, Sword of Stars",
            ImageTag = CardImageTags.Nadalya_Sword_of_Stars,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 5), new Resource(CardResources.Mana, 8), },

            Text = @"Your hero has <b>Overwhelm</b> and <b>Empowered +2</b>. Their attack is increased by your <b>Empowered</b> value.
Whenever your hero attacks and kills a unit, add three ""Magic Missile"" cards to your hand.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered, Tags.Equip, Tags.Magic, Tags.Sword, Tags.Overwhelm },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Empowered, Synergies.SmallSpells, Synergies.Mana, Synergies.Value, Synergies.Equip, Synergies.SplitDamage },
            ItemTag = "Magic Sword",
            Durability = 3,
        };
        CardList.Add(card26);

        var card27 = new SpellData()
        {
            Id = 27,
            Name = "Magic Missiles",
            ImageTag = CardImageTags.Magic_Missiles,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 1), },

            Text = @"Deal 3 damage randomly split among enemies within an area of cone 3",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SplitDamage },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.SplitDamage },
            SpellType = "Damage",
            Range = 0,
        };
        CardList.Add(card27);

        var card28 = new UnitData()
        {
            Id = 28,
            Name = "Runeblade Duelist",
            ImageTag = CardImageTags.Runeblade2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Runeblade, Tags.Ability, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Runeblade,
            },
            Attack = 7,
            Health = 21,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability11 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card28);

        var card29 = new UnitData()
        {
            Id = 29,
            Name = "Runeblade Blademaster",
            ImageTag = CardImageTags.Runeblade3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Runeblade, Tags.Ability, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Runeblade,
            },
            Attack = 9,
            Health = 27,
            Protected = 0,
            Range = 0,
            Speed = 5,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability12 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card29);

        var card30 = new UnitData()
        {
            Id = 30,
            Name = "Arcanist",
            ImageTag = CardImageTags.Arcanist1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Arcanist, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Arcanist,
            },
            Attack = 4,
            Health = 10,
            Protected = 0,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability13 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card30);

        var card31 = new UnitData()
        {
            Id = 31,
            Name = "Arcanist Magician",
            ImageTag = CardImageTags.Arcanist2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Arcanist, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Arcanist,
            },
            Attack = 6,
            Health = 16,
            Protected = 0,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability14 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card31);

        var card32 = new UnitData()
        {
            Id = 32,
            Name = "Arcanist Archmage",
            ImageTag = CardImageTags.Arcanist3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Arcanist, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Arcanist,
            },
            Attack = 7,
            Health = 20,
            Protected = 0,
            Range = 4,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability15 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card32);

        var card33 = new SpellData()
        {
            Id = 33,
            Name = "Arcane Spike",
            ImageTag = CardImageTags.Arcane_Spike,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            Text = @"Deal 3 damage to a unit. If that kills it, return this card from the Graveyard to your hand at the end of your turn.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Value, Synergies.SplitDamage, Synergies.SingleDamage },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card33);

        var card34 = new UnitData()
        {
            Id = 34,
            Name = "Battlemage",
            ImageTag = CardImageTags.Battlemage,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 4), },

            Text = @"<b>Conduit, Empowered +2</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Arcanist, Tags.Empowered, Tags.Conduit },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Melee, Synergies.Summon, Synergies.SplitDamage },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Arcanist,
            },
            Attack = 4,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 2,

            Abilities = new List<AbilityData>() { ability64 },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card34);

        var card35 = new UnitData()
        {
            Id = 35,
            Name = "Kelari Librarian",
            ImageTag = CardImageTags.Kelari_Librarian,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            Text = @"<b>Deployment:</b> Use <b>Studious Research.</b> This use doesn't increase your <b>Stagnation</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Elven, Tags.Deployment, Tags.StudyGain, Tags.Scholar },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Deployment, Synergies.Study },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Scholar,
            },
            Attack = 1,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability65 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card35);

        var card36 = new SpellData()
        {
            Id = 36,
            Name = "Magical Inspiration",
            ImageTag = CardImageTags.Magical_Inspiration,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), },

            Text = @"<b>Cast When Drawn</b>
Increase your base Knowledge rate by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.StudyGain, Tags.CastWhenDrawn, Tags.Inspiration },
            Synergies = new List<Synergies> { },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card36);

        var card37 = new SpellData()
        {
            Id = 37,
            Name = "Power Investment",
            ImageTag = CardImageTags.Power_Investment,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), new Resource(CardResources.Mana, 3), },

            Text = @"<b>Study (4)</b>
Add a random playable spell to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.StudyGain },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Value, Synergies.Study },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card37);

        var card38 = new SpellData()
        {
            Id = 38,
            Name = "Spark of Power",
            ImageTag = CardImageTags.Spark_of_Power,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            Text = @"Draw 2 cards",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Draw },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card38);

        var card39 = new UnitData()
        {
            Id = 39,
            Name = "Arcane Golem",
            ImageTag = CardImageTags.Arcane_Golem,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 5), },

            Text = @"<b>Summon, Warden</b>
After you cast a spell, gain +1 Attack, +1 Health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Arcane, Tags.Warden },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.SmallSpells, Synergies.Durable, Synergies.Summon, Synergies.Defensive },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Arcane,
                UnitTags.Summon,
            },
            Attack = 5,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Summon, Keywords.Warden },
        };
        CardList.Add(card39);

        var card40 = new ItemData()
        {
            Id = 40,
            Name = "Counterspell",
            ImageTag = CardImageTags.Counterspell_Item,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), new Resource(CardResources.Mana, 2), },

            Text = @"Whenever an enemy casts a spell within range 3, prevent it from being cast and gain mana equal to its total cost",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.ManaGain, Tags.Equip, Tags.Conjured, Tags.Spell },
            Synergies = new List<Synergies> { },
            ItemTag = "Conjured Spell",
            Durability = 1,
        };
        CardList.Add(card40);

        var card41 = new SpellData()
        {
            Id = 41,
            Name = "Counterspell",
            ImageTag = CardImageTags.Counterspell,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), new Resource(CardResources.Mana, 2), },

            Text = @"Equip a ""Counterspell"" item. If you already have a ""Counterspell"" item equipped, instead increase its durability by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.ManaGain, Tags.Equip },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Antimagic, Synergies.Mana, Synergies.Defensive, Synergies.Equip },
            SpellType = "Equip",
            Range = 0,
        };
        CardList.Add(card41);

        var card42 = new SpellData()
        {
            Id = 42,
            Name = "Dispel Magic",
            ImageTag = CardImageTags.Dispel_Magic,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 1), new Resource(CardResources.Mana, 1), },

            Text = @"<b>Spellbind</b> a unit. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.Spellbind },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Draw, Synergies.Antimagic },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card42);

        var card43 = new UnitData()
        {
            Id = 43,
            Name = "Kelari Astromancer",
            ImageTag = CardImageTags.Kelari_Astromancer,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 6), },

            Text = @"<b>Deployment: Divinate (2)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Arcanist, Tags.Elven, Tags.Deployment, Tags.Divinate },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Deployment, Synergies.Study, Synergies.Prediction, Synergies.LongRange },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Arcanist,
            },
            Attack = 2,
            Health = 6,
            Protected = 0,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability66 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card43);

        var card44 = new SpellData()
        {
            Id = 44,
            Name = "Polymorph",
            ImageTag = CardImageTags.Polymorph,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), new Resource(CardResources.Mana, 3), },

            Text = @"<b>Transform</b> a minion into a ""Pig""",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleRemoval, Tags.Transform },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Antimagic, Synergies.Removal },
            SpellType = "Enchantment",
            Range = 3,
        };
        CardList.Add(card44);

        var card45 = new UnitData()
        {
            Id = 45,
            Name = "Pig",
            ImageTag = CardImageTags.Pig,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 0), },

            Text = @"",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Transformed, Tags.Beast },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Transformed,
                UnitTags.Beast,
            },
            Attack = 1,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card45);

        var card46 = new UnitData()
        {
            Id = 46,
            Name = "Arcane Spirit",
            ImageTag = CardImageTags.Arcane_Spirit,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 4), },

            Text = @"<b>Summon, Conduit</b>
The Mana cost of your spells is reduced by (2)",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Conduit, Tags.Summon, Tags.Arcane },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Draw, Synergies.BigSpells, Synergies.Summon, Synergies.Midrange },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Arcane,
                UnitTags.Summon,
            },
            Attack = 2,
            Health = 3,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Summon },
        };
        CardList.Add(card46);

        var card47 = new UnitData()
        {
            Id = 47,
            Name = "Callardis Academic",
            ImageTag = CardImageTags.Callardis_Academic,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            Text = @"<b>Deployment: Study (4)</b>
Whenever your draw an <b>Inspiration</b> card, your Knowledge gain rate is increased by an additional point. ",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Deployment, Tags.StudyGain, Tags.Scholar },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Draw, Synergies.Deployment, Synergies.Value, Synergies.Study },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Scholar,
            },
            Attack = 3,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card47);

        var card48 = new UnitData()
        {
            Id = 48,
            Name = "Callardis Conjurer",
            ImageTag = CardImageTags.Callardis_Conjurer,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"Tiles adjacent to this unit are part of your deployment zone",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Arcanist },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Midrange, Synergies.Deployment, Synergies.Vanguard, Synergies.Prepared },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Arcanist,
            },
            Attack = 2,
            Health = 5,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card48);

        var card49 = new SpellData()
        {
            Id = 49,
            Name = "Homing Bolt",
            ImageTag = CardImageTags.Homing_Bolt,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 4), },

            Text = @"Deal 2 damage to an enemy unit. If the spell kills it, deal 2 damage to another random enemy within range 2. Repeat until a unit doesn't die or there isn't another enemy unit to target",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SplitDamage, Tags.SingleDamage },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.Value, Synergies.SplitDamage, Synergies.SingleDamage, Synergies.Death },
            SpellType = "Damage",
            Range = 4,
        };
        CardList.Add(card49);

        var card50 = new ItemData()
        {
            Id = 50,
            Name = "Archmage Staff",
            ImageTag = CardImageTags.Archmage_Staff,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            Text = @"Whenever you cast a spell, gain <b>Empowered +1</b> until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered, Tags.Magic, Tags.Staff },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Draw, Synergies.Equip },
            ItemTag = "Magic Staff",
            Durability = 5,
        };
        CardList.Add(card50);

        var card51 = new UnitData()
        {
            Id = 51,
            Name = "Kelari Spellguard",
            ImageTag = CardImageTags.Kelari_Spellguard,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 6), },

            Text = @"<b>Warden
Deployment</b> and <b>Last Rites:</b> Add a random playable spell to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Arcanist, Tags.Elven, Tags.Warden, Tags.Deployment, Tags.LastRites },
            Synergies = new List<Synergies> { Synergies.Deployment, Synergies.BigMinions, Synergies.Defensive, Synergies.Value, Synergies.Study, Synergies.ShortRange, Synergies.LastRites },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Arcanist,
            },
            Attack = 3,
            Health = 7,
            Protected = 0,
            Range = 1,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Warden },
        };
        CardList.Add(card51);

        var card52 = new SpellData()
        {
            Id = 52,
            Name = "Tome of Power",
            ImageTag = CardImageTags.Tome_Of_Power,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 5), },

            Text = @"Add three random playable spells to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { Synergies.BigSpells, Synergies.Value, Synergies.Study },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card52);

        var card53 = new UnitData()
        {
            Id = 53,
            Name = "Archmage Tholas",
            ImageTag = CardImageTags.Archmage_Tholas,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 8), },

            Text = @"<b>Conduit
Deployment: Divinate (2)</b>
After you cast a spell, add a random playable spell to your hand and reduce its cost by (2)",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Arcanist, Tags.Conduit, Tags.Divinate },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Draw, Synergies.Summon, Synergies.BigMinions, Synergies.Value, Synergies.Study, Synergies.Prediction },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Arcanist,
            },
            Attack = 3,
            Health = 8,
            Protected = 0,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card53);

        var card54 = new SpellData()
        {
            Id = 54,
            Name = "Enlightenment",
            ImageTag = CardImageTags.Enlightenment,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 7), new Resource(CardResources.Mana, 5), },

            Text = @"Choose the form of a “Mind” item to equip. At the start of each of your turns, choose a different form to change the item into and lose one Durability. The activated effects of the “Mind” items do not reduce Durability. If you already have a “Mind” item equipped, destroy it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Equip },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.Draw, Synergies.BigSpells, Synergies.Mana, Synergies.Value, Synergies.Equip, Synergies.SplitDamage, Synergies.Study },
            SpellType = "Equip",
            Range = 0,
        };
        CardList.Add(card54);

        var card55 = new ItemData()
        {
            Id = 55,
            Name = "Creative Mind",
            ImageTag = CardImageTags.Creative_Mind,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 7), new Resource(CardResources.Mana, 5), },

            Text = @"<b>Empowered +3</b>
The cost of spells which did not start in your deck is reduced by (3)",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered, Tags.Equip, Tags.MindItem },
            Synergies = new List<Synergies> { },
            ItemTag = "Arcane Mind",
            Durability = 5,
        };
        CardList.Add(card55);

        var card56 = new ItemData()
        {
            Id = 56,
            Name = "Deep Mind",
            ImageTag = CardImageTags.Deep_Mind,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 7), new Resource(CardResources.Mana, 5), },

            Text = @"<b>Empowered +3</b>
When you select this form, draw 3 cards",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Draw, Tags.Empowered, Tags.Equip, Tags.MindItem },
            Synergies = new List<Synergies> { },
            ItemTag = "Arcane Mind",
            Durability = 5,
        };
        CardList.Add(card56);

        var card57 = new ItemData()
        {
            Id = 57,
            Name = "Devastating Mind",
            ImageTag = CardImageTags.Devastating_Mind,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 7), new Resource(CardResources.Mana, 5), },

            Text = @"<b>Empowered +3</b>
Your hero's attack is increased by your <b>Empowered</b> value. Whenever your hero kills a unit, any excess damage is randomly split among all enemy units within Range 2 of the killed unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered, Tags.Equip, Tags.MindItem },
            Synergies = new List<Synergies> { },
            ItemTag = "Arcane Mind",
            Durability = 5,
        };
        CardList.Add(card57);

        var card58 = new ItemData()
        {
            Id = 58,
            Name = "Protected Mind",
            ImageTag = CardImageTags.Protected_Mind,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 7), new Resource(CardResources.Mana, 5), },

            Text = @"<b>Empowered +3</b>
At the end of your turn, your hero gains <b>Protected (12).</b> Remove any <b>Protected</b> gained in this way at the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered, Tags.Protected, Tags.Equip, Tags.MindItem },
            Synergies = new List<Synergies> { },
            ItemTag = "Arcane Mind",
            Durability = 5,
        };
        CardList.Add(card58);

        var card59 = new ItemData()
        {
            Id = 59,
            Name = "Replicative Mind",
            ImageTag = CardImageTags.Replicative_Mind,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 7), new Resource(CardResources.Mana, 5), },

            Text = @"<b>Empowered +3</b>
After you cast the first spell on your turn, cast it again on the same target",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered, Tags.Equip, Tags.MindItem },
            Synergies = new List<Synergies> { },
            ItemTag = "Arcane Mind",
            Durability = 5,
        };
        CardList.Add(card59);

        var card60 = new UnitData()
        {
            Id = 60,
            Name = "Abyssal",
            ImageTag = CardImageTags.Abyssal1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Abyssal, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Abyssal,
            },
            Attack = 3,
            Health = 12,
            Protected = 0,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability16 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card60);

        var card61 = new UnitData()
        {
            Id = 61,
            Name = "Abyssal Warlock",
            ImageTag = CardImageTags.Abyssal2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Abyssal, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Abyssal,
            },
            Attack = 4,
            Health = 20,
            Protected = 0,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability17 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card61);

        var card62 = new UnitData()
        {
            Id = 62,
            Name = "Abyssal Voidlord",
            ImageTag = CardImageTags.Abyssal3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Abyssal, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Abyssal,
            },
            Attack = 5,
            Health = 26,
            Protected = 0,
            Range = 3,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability18 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card62);

        var card63 = new UnitData()
        {
            Id = 63,
            Name = "Voidling",
            ImageTag = CardImageTags.Voidling,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            Text = @"<b>Summon, Warden</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Warden, Tags.Void },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Void,
                UnitTags.Summon,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Summon, Keywords.Warden },
        };
        CardList.Add(card63);

        var card64 = new UnitData()
        {
            Id = 64,
            Name = "Abyss Imp",
            ImageTag = CardImageTags.Abyss_Imp,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 1), },

            Text = @"<b>Deployment: Discard</b> a card
<b>Last Rites:</b> Shuffle an Abyss Imp into your deck. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Deployment, Tags.LastRites, Tags.Void, Tags.Abomination, Tags.Discard },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Draw, Synergies.Swarm, Synergies.LastRites, Synergies.Discard, Synergies.Void, Synergies.Sacrifice },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Void,
                UnitTags.Abomination,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card64);

        var card65 = new UnitData()
        {
            Id = 65,
            Name = "Abyssal Cultist",
            ImageTag = CardImageTags.Abyssal_Cultist,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"<b>Conduit</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Conduit, Tags.Abyssal, Tags.PrayerGain },
            Synergies = new List<Synergies> { Synergies.Summon, Synergies.Midrange, Synergies.Prayer },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Abyssal,
            },
            Attack = 2,
            Health = 1,
            Protected = 0,
            Range = 2,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability99 },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card65);

        var card66 = new SpellData()
        {
            Id = 66,
            Name = "Bite",
            ImageTag = CardImageTags.Bite,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), new Resource(CardResources.Mana, 1), },

            Text = @"<b>Lifebond, Piercing</b>
Deal 4 damage to a unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.Lifebond, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Control, Synergies.SingleDamage, Synergies.Restoration, Synergies.Piercing },
            SpellType = "Damage",
            Range = 1,
        };
        CardList.Add(card66);

        var card67 = new SpellData()
        {
            Id = 67,
            Name = "Dark Pact",
            ImageTag = CardImageTags.Dark_Pact,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 3), new Resource(CardResources.Mana, 0), },

            Text = @"Increase your mana by 4. Add a random Void unit to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.ManaGain },
            Synergies = new List<Synergies> { Synergies.Mana, Synergies.Value, Synergies.Void },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card67);

        var card68 = new UnitData()
        {
            Id = 68,
            Name = "Void Soul",
            ImageTag = CardImageTags.Void_Soul,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 1), },

            Text = @"<b>Ethereal</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ethereal, Tags.Void, Tags.Spirit },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Void,
                UnitTags.Spirit,
            },
            Attack = 1,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Ethereal },
        };
        CardList.Add(card68);

        var card69 = new SpellData()
        {
            Id = 69,
            Name = "Void Touch",
            ImageTag = CardImageTags.Void_Touch,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 4), },

            Text = @"Give a friendly unit with <b>Summon</b> +4 Attack, +4 Health. Gain additional Attack and Health points equal to your <b>Empowered</b> value.
Deal <b>Piercing</b> damage to the caster equal to the additional points gained.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Summon, Synergies.Restoration, Synergies.SelfDamage },
            SpellType = "Enchantment",
            Range = 1,
        };
        CardList.Add(card69);

        var card70 = new UnitData()
        {
            Id = 70,
            Name = "Abyssal Dreadspeaker",
            ImageTag = CardImageTags.Abyssal_Dreadspeaker,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 4), },

            Text = @"<b>Conduit, Empowered +1</b>
Whenever you <b>Discard</b> a card or a friendly unit dies within Range 2, draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Empowered, Tags.Conduit },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Summon, Synergies.Midrange, Synergies.Swarm, Synergies.Death, Synergies.Discard, Synergies.Sacrifice },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Abyssal,
            },
            Attack = 2,
            Health = 3,
            Protected = 0,
            Range = 2,
            Speed = 2,
            Empowered = 1,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card70);

        var card71 = new SpellData()
        {
            Id = 71,
            Name = "Blood Pact",
            ImageTag = CardImageTags.Blood_Pact,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"Destroy a friendly minion. Restore health equal to the destroyed unit's health to another unit. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.Sacrifice },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Draw, Synergies.Durable, Synergies.Sacrifice, Synergies.Restoration },
            SpellType = "Restoration",
            Range = 2,
        };
        CardList.Add(card71);

        var card72 = new SpellData()
        {
            Id = 72,
            Name = "Dreadbolt",
            ImageTag = CardImageTags.Dreadbolt,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 1), },

            Text = @"Deal 4 damage to a unit. Deal an equal amount of <b>Piercing</b> damage to the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.SelfDamage, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.SingleDamage, Synergies.SelfDamage },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card72);

        var card73 = new UnitData()
        {
            Id = 73,
            Name = "Vampire Aristocrat",
            ImageTag = CardImageTags.Vampire_Aristocrat,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 6), },

            Text = @"<b>Lifebond, Piercing</b>
At the start of your turn, <b>Regenerate</b>
Whenever this unit takes damage, <b>Prayer +2</b> and draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.PrayerGain, Tags.Lifebond, Tags.Vampire, Tags.Noble, Tags.Regenerate, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Draw, Synergies.Durable, Synergies.BigMinions, Synergies.Prayer, Synergies.Restoration, Synergies.Piercing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Vampire,
                UnitTags.Noble,
            },
            Attack = 5,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Lifebond, Keywords.Piercing },
        };
        CardList.Add(card73);

        var card74 = new UnitData()
        {
            Id = 74,
            Name = "Vampire Courtesan",
            ImageTag = CardImageTags.Vampire_Courtesan,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), },

            Text = @"<b>Lifebond, Piercing</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Lifebond, Tags.Vampire, Tags.Noble, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.Durable, Synergies.SingleDamage, Synergies.Restoration, Synergies.Piercing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Vampire,
                UnitTags.Noble,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability67 },

            Keywords = new List<Keywords>() { Keywords.Lifebond, Keywords.Piercing },
        };
        CardList.Add(card74);

        var card75 = new UnitData()
        {
            Id = 75,
            Name = "Abyss Knight",
            ImageTag = CardImageTags.Abyss_Knight,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"<b>Summon, Warden, Protected (4)</b>
Whenever you <b>Discard</b> a card, gain Attack and Health equal to its total cost",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Protected, Tags.Summon, Tags.Warden, Tags.Void, Tags.Abomination },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Durable, Synergies.Protected, Synergies.Summon, Synergies.Mana, Synergies.BigMinions, Synergies.Defensive, Synergies.Discard, Synergies.Void },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Void,
                UnitTags.Summon,
            },
            Attack = 5,
            Health = 5,
            Protected = 4,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Summon, Keywords.Warden },
        };
        CardList.Add(card75);

        var card76 = new UnitData()
        {
            Id = 76,
            Name = "Abyssal Summoner",
            ImageTag = CardImageTags.Abyssal_Summoner,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            Text = @"<b>Conduit
Deployment:</b> Gain the <b>Passive:</b> ""You can <b>Summon</b> one additional unit for the rest of the scenario."" Deal 3 <b>Piercing</b> damage to your hero",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Conduit, Tags.Deployment, Tags.Abyssal, Tags.SelfDamage, Tags.Passive, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Summon, Synergies.Deployment, Synergies.ShortRange, Synergies.Restoration, Synergies.SelfDamage },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Abyssal,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 1,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card76);

        var card77 = new UnitData()
        {
            Id = 77,
            Name = "Eye of the Void",
            ImageTag = CardImageTags.Eye_of_the_Void,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"<b>Summon, Flying</b>
Whenever this attacks and kills a unit, deploy a ""Void Soul"" in its place. Give it +1 Attack, +1 Health for every other Void unit you control",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Void, Tags.Abomination, Tags.Flying },
            Synergies = new List<Synergies> { Synergies.Midrange, Synergies.Ethereal, Synergies.Mana, Synergies.Swarm, Synergies.Void, Synergies.Sacrifice, Synergies.Flying },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Void,
                UnitTags.Summon,
            },
            Attack = 3,
            Health = 5,
            Protected = 0,
            Range = 2,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Flying, Keywords.Summon },
        };
        CardList.Add(card77);

        var card78 = new UnitData()
        {
            Id = 78,
            Name = "Imp Matron",
            ImageTag = CardImageTags.Imp_Matron,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"<b>Summon, Warden</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Summon, Tags.Warden, Tags.Void, Tags.Discard },
            Synergies = new List<Synergies> { Synergies.Summon, Synergies.Mana, Synergies.Swarm, Synergies.BigMinions, Synergies.Defensive, Synergies.ShortRange, Synergies.Discard, Synergies.Void, Synergies.Sacrifice },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Void,
                UnitTags.Summon,
            },
            Attack = 3,
            Health = 9,
            Protected = 0,
            Range = 1,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability68 },

            Keywords = new List<Keywords>() { Keywords.Summon, Keywords.Warden },
        };
        CardList.Add(card78);

        var card79 = new UnitData()
        {
            Id = 79,
            Name = "Abyssal Voidcaller",
            ImageTag = CardImageTags.Abyssal_Voidcaller,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), new Resource(CardResources.Mana, 5), },

            Text = @"<b>Deployment:</b> Use <b>Call of the Void</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Abyssal },
            Synergies = new List<Synergies> { Synergies.Mana, Synergies.Deployment, Synergies.Value, Synergies.LongRange, Synergies.Void },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Abyssal,
            },
            Attack = 4,
            Health = 5,
            Protected = 0,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability69 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card79);

        var card80 = new UnitData()
        {
            Id = 80,
            Name = "Soul Consumer",
            ImageTag = CardImageTags.Soul_Consumer,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 7), },

            Text = @"Whenever this kills a unit, return a random card in your <b>Discard</b> pool to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.ManaGain, Tags.Void, Tags.Abomination, Tags.Discard },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Mana, Synergies.BigMinions, Synergies.Death, Synergies.Discard, Synergies.Void },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Void,
                UnitTags.Abomination,
            },
            Attack = 4,
            Health = 12,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability70 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card80);

        var card81 = new SpellData()
        {
            Id = 81,
            Name = "The Void Hungers",
            ImageTag = CardImageTags.The_Void_Hungers,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), new Resource(CardResources.Mana, 3), },

            Text = @"Destroy a friendly minion. Deal damage to another unit equal to the destroyed unit's health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.Sacrifice },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.BigMinions, Synergies.SingleDamage, Synergies.Sacrifice },
            SpellType = "Damage",
            Range = 4,
        };
        CardList.Add(card81);

        var card82 = new UnitData()
        {
            Id = 82,
            Name = "Abysslord Marrex",
            ImageTag = CardImageTags.Abysslord_Marrex,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 5), new Resource(CardResources.Mana, 7), },

            Text = @"<b>Deployment:</b> Use <b>For the Void</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Deployment, Tags.Void, Tags.Discard, Tags.Noble },
            Synergies = new List<Synergies> { Synergies.Mana, Synergies.Swarm, Synergies.BigMinions, Synergies.Discard, Synergies.Void, Synergies.Prayer },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Void,
                UnitTags.Noble,
            },
            Attack = 8,
            Health = 11,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability71 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card82);

        var card83 = new SpellData()
        {
            Id = 83,
            Name = "Realm Convergence",
            ImageTag = CardImageTags.Realm_Convergence,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"Gain the <b>Passive:</b> ""You can <b>Summon</b> three additional units and your <b>Summon</b> units cost (2) less for the rest of the scenario.""
Deal <b>Piercing</b> damage to your hero equal to half their remaining health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SelfDamage, Tags.Passive, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.BigSpells, Synergies.Summon, Synergies.Mana, Synergies.Restoration, Synergies.SelfDamage },
            SpellType = "Other",
            Range = 0,
        };
        CardList.Add(card83);

        var card84 = new UnitData()
        {
            Id = 84,
            Name = "Elementalist",
            ImageTag = CardImageTags.Elementalist1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Elementalist, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Elementalist,
            },
            Attack = 5,
            Health = 10,
            Protected = 0,
            Range = 2,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability27 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card84);

        var card85 = new UnitData()
        {
            Id = 85,
            Name = "Elementalist Shaman",
            ImageTag = CardImageTags.Elementalist2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Elementalist, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Elementalist,
            },
            Attack = 7,
            Health = 16,
            Protected = 0,
            Range = 2,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability28 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card85);

        var card86 = new UnitData()
        {
            Id = 86,
            Name = "Elementalist Elder",
            ImageTag = CardImageTags.Elementalist3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Elementalist, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Elementalist,
            },
            Attack = 9,
            Health = 20,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability29 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card86);

        var card87 = new SpellData()
        {
            Id = 87,
            Name = "Fireball",
            ImageTag = CardImageTags.Fireball,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 4), },

            Text = @"Deal 3 damage to all units within an area of Radius 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.Fire, Tags.BasicElemental },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.AreaDamage, Synergies.Fire },
            SpellType = "Damage",
            Range = 4,
        };
        CardList.Add(card87);

        var card88 = new UnitData()
        {
            Id = 88,
            Name = "Goblin Blastmage",
            ImageTag = CardImageTags.Goblin_Blastmage,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            Text = @"<b>Empowered +1</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Empowered, Tags.Elementalist, Tags.Fire, Tags.Goblin },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Midrange, Synergies.Goblin, Synergies.Fire },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Goblin,
                UnitTags.Elementalist,
            },
            Attack = 1,
            Health = 2,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 1,

            Abilities = new List<AbilityData>() { ability77 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card88);

        var card89 = new SpellData()
        {
            Id = 89,
            Name = "Ice Blast",
            ImageTag = CardImageTags.Ice_Blast,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            Text = @"Deal 2 damage to a unit and <b>Stun</b> it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.SingleDamage, Tags.Water, Tags.BasicElemental },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Stun, Synergies.SingleDamage, Synergies.Water },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card89);

        var card90 = new SpellData()
        {
            Id = 90,
            Name = "Lightning Bolt",
            ImageTag = CardImageTags.Lightning_Bolt,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 4), },

            Text = @"Deal 3 damage to all units within an area of Line 6 from the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.Air, Tags.BasicElemental },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.AreaDamage, Synergies.Air },
            SpellType = "Damage",
            Range = 0,
        };
        CardList.Add(card90);

        var card91 = new SpellData()
        {
            Id = 91,
            Name = "Mana Surge",
            ImageTag = CardImageTags.Mana_Surge,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 0), new Resource(CardResources.Wild, 2), },

            Text = @"Increase your Mana by 3. Gain <b>Empowered +2</b> until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Empowered, Tags.ManaGain },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Mana },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card91);

        var card92 = new UnitData()
        {
            Id = 92,
            Name = "Wave Sorceror",
            ImageTag = CardImageTags.Wave_Sorceror,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 4), },

            Text = @"<b>Unleash</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Elven, Tags.Elementalist, Tags.Water, Tags.ForceMove },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Melee, Synergies.ForceMove, Synergies.Water },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Elementalist,
            },
            Attack = 3,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability80 },

            Keywords = new List<Keywords>() { Keywords.Unleash },
        };
        CardList.Add(card92);

        var card93 = new UnitData()
        {
            Id = 93,
            Name = "Air Elemental",
            ImageTag = CardImageTags.Air_Elemental,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"<b>Summon, Flying</b>
Whenever this unit takes damage from a friendly Air spell or unit, it heals for the damage amount instead",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Flying, Tags.Air, Tags.Elemental },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Summon, Synergies.Mana, Synergies.BigMinions, Synergies.Flying, Synergies.Air },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elemental,
                UnitTags.Summon,
            },
            Attack = 7,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Flying, Keywords.Summon },
        };
        CardList.Add(card93);

        var card94 = new UnitData()
        {
            Id = 94,
            Name = "Earth Elemental",
            ImageTag = CardImageTags.Earth_Elemental,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"<b>Summon, Warden</b>
Whenever this unit takes damage from a friendly Earth spell or unit, it heals for the damage amount instead",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Warden, Tags.Elemental, Tags.Earth },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Summon, Synergies.Mana, Synergies.BigMinions, Synergies.Defensive, Synergies.Earth },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elemental,
                UnitTags.Summon,
            },
            Attack = 4,
            Health = 12,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Summon, Keywords.Warden },
        };
        CardList.Add(card94);

        var card95 = new UnitData()
        {
            Id = 95,
            Name = "Fire Elemental",
            ImageTag = CardImageTags.Fire_Elemental,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"<b>Summon Prepared</b>
Whenever this unit takes damage from a friendly Fire spell or unit, it heals for the damage amount instead",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Prepared, Tags.Fire, Tags.Elemental },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Summon, Synergies.Mana, Synergies.BigMinions, Synergies.Prepared, Synergies.Fire },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elemental,
                UnitTags.Summon,
            },
            Attack = 8,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Prepared, Keywords.Summon },
        };
        CardList.Add(card95);

        var card96 = new SpellData()
        {
            Id = 96,
            Name = "Tend the Elements",
            ImageTag = CardImageTags.Tend_the_Elements,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            Text = @"<b>Cycle +3</b>
Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.CyclePlus },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Cycle },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card96);

        var card97 = new UnitData()
        {
            Id = 97,
            Name = "Water Elemental",
            ImageTag = CardImageTags.Water_Elemental,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), },

            Text = @"<b>Summon</b>
Whenever this unit deals damage to another unit, <b>Stun</b> it.
Whenever this unit takes damage from a friendly Water spell or unit, it heals for the damage amount instead",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Stun, Tags.Summon, Tags.Water, Tags.Elemental },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Stun, Synergies.Summon, Synergies.Mana, Synergies.BigMinions, Synergies.Water },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elemental,
                UnitTags.Summon,
            },
            Attack = 5,
            Health = 9,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Summon },
        };
        CardList.Add(card97);

        var card98 = new UnitData()
        {
            Id = 98,
            Name = "Earthbinder",
            ImageTag = CardImageTags.Earthbinder,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), new Resource(CardResources.Wild, 1), },

            Text = @"<b>Empowered +1</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Dwarven, Tags.Empowered, Tags.Elementalist, Tags.Earth, Tags.Root },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Melee, Synergies.Root, Synergies.Earth },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Dwarven,
                UnitTags.Elementalist,
            },
            Attack = 3,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 1,

            Abilities = new List<AbilityData>() { ability78 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card98);

        var card99 = new SpellData()
        {
            Id = 99,
            Name = "Elemental Rush",
            ImageTag = CardImageTags.Elemental_Rush,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 5), },

            Text = @"Draw a card. Reduce the cost of all spells in your hand and deck by (2) <b>Cycle -5</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.CycleMinus },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Draw, Synergies.BigSpells, Synergies.Cycle, Synergies.Wild },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card99);

        var card100 = new UnitData()
        {
            Id = 100,
            Name = "Monk of the Four Winds",
            ImageTag = CardImageTags.Monk_of_the_Four_Winds,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 6), },

            Text = @"<b>Deployment:</b> Use <b>Call of the Winds</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Draw, Tags.Deployment, Tags.Elementalist, Tags.Air, Tags.CycleMinus },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Mobility, Synergies.Draw, Synergies.BigSpells, Synergies.Deployment, Synergies.ShortRange, Synergies.Wild, Synergies.Air },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Elementalist,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 1,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability79 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card100);

        var card101 = new SpellData()
        {
            Id = 101,
            Name = "Pummel",
            ImageTag = CardImageTags.Pummel,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            Text = @"Deal 3 damage to a unit. Move it up to 2 tiles away from the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.ForceMove, Tags.Earth, Tags.BasicElemental },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.SingleDamage, Synergies.ForceMove, Synergies.Earth },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card101);

        var card102 = new SpellData()
        {
            Id = 102,
            Name = "Hurricane",
            ImageTag = CardImageTags.Hurricane,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 5), new Resource(CardResources.Wild, 3), },

            Text = @"Choose an area of Radius 2. Deal 4 damage to all units on the outer ring and push them in a line 2 tiles directly away from the centre of the area. If they impact any obstacle terrain, deal an additional 2 damage to them",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.Air, Tags.ForceMove },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.BigSpells, Synergies.AreaDamage, Synergies.Mana, Synergies.ForceMove, Synergies.Air },
            SpellType = "Damage",
            Range = 4,
        };
        CardList.Add(card102);

        var card103 = new SpellData()
        {
            Id = 103,
            Name = "Earthquake",
            ImageTag = CardImageTags.Earthquake,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 6), new Resource(CardResources.Wild, 8), },

            Text = @"Deal 4 damage to all units within an area of Radius 3 and increase the movement cost of all tiles in the area by 1 until the end of your next turn. At the start of your next turn, deal 4 damage to all units within the same area.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.Earth },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.BigSpells, Synergies.AreaDamage, Synergies.Mana, Synergies.ForceMove, Synergies.Wild, Synergies.Earth },
            SpellType = "Damage",
            Range = 5,
        };
        CardList.Add(card103);

        var card104 = new SpellData()
        {
            Id = 104,
            Name = "Wall of Fire",
            ImageTag = CardImageTags.Wall_of_Fire,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 8), },

            Text = @"Deal 5 damage to all units in an area of Wall 5. If any unit enters this area until the end of your next turn, they take 5 damage",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.Fire },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.BigSpells, Synergies.Mana, Synergies.ForceMove, Synergies.Fire },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card104);

        var card105 = new UnitData()
        {
            Id = 105,
            Name = "Master Kybas",
            ImageTag = CardImageTags.Master_Kybas,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 8), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Conduit, Cycle -6</b>
Reduce the cost of all spells generated by this unit to 0.
<b>Deployment:</b> Add all four of the basic Elemental Spells to your hand.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Conduit, Tags.Deployment, Tags.Elementalist, Tags.Fire, Tags.Water, Tags.Air, Tags.Earth, Tags.CycleMinus },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Summon, Synergies.Mana, Synergies.Deployment, Synergies.BigMinions, Synergies.Value, Synergies.ShortRange, Synergies.Cycle, Synergies.Wild, Synergies.Fire, Synergies.Water, Synergies.Air, Synergies.Earth },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Elementalist,
            },
            Attack = 5,
            Health = 5,
            Protected = 0,
            Range = 1,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability81 },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card105);

        var card106 = new SpellData()
        {
            Id = 106,
            Name = "Tidal Wave",
            ImageTag = CardImageTags.Tidal_Wave,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 10), },

            Text = @"In an area of line 6 from the caster as well as both adjacent lines, deal 2 damage, <b>Stun</b> and push back 3 tiles all units in that area.
The damage of this spell is multiplied by your <b>Empowered</b> score instead of being added. The damage of this spell cannot be reduced below 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.AreaDamage, Tags.Water, Tags.ForceMove },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Stun, Synergies.Control, Synergies.BigSpells, Synergies.AreaDamage, Synergies.Mana, Synergies.ForceMove, Synergies.Water },
            SpellType = "Damage",
            Range = 0,
        };
        CardList.Add(card106);

        var card107 = new UnitData()
        {
            Id = 107,
            Name = "Grovewatcher",
            ImageTag = CardImageTags.Grovewatcher1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Root, Tags.Grovewatcher, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Grovewatcher,
            },
            Attack = 2,
            Health = 16,
            Protected = 0,
            Range = 2,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability30 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card107);

        var card108 = new UnitData()
        {
            Id = 108,
            Name = "Grovewatcher Woodwalker",
            ImageTag = CardImageTags.Grovewatcher2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Root, Tags.Grovewatcher, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Grovewatcher,
            },
            Attack = 3,
            Health = 24,
            Protected = 0,
            Range = 2,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability31 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card108);

        var card109 = new UnitData()
        {
            Id = 109,
            Name = "Grovewatcher Archdruid",
            ImageTag = CardImageTags.Grovewatcher3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Root, Tags.Grovewatcher, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Grovewatcher,
            },
            Attack = 4,
            Health = 30,
            Protected = 0,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability32 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card109);

        var card110 = new SpellData()
        {
            Id = 110,
            Name = "Grasping Vine",
            ImageTag = CardImageTags.Grasping_Vine,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            Text = @"<b>Root</b> an enemy unit. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.Root },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Draw, Synergies.Root },
            SpellType = "Enchantment",
            Range = 3,
        };
        CardList.Add(card110);

        var card111 = new SpellData()
        {
            Id = 111,
            Name = "Honour the Old Gods",
            ImageTag = CardImageTags.Honour_the_Old_Gods,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 3), new Resource(CardResources.Wild, 0), },

            Text = @"Increase your Wild by 3 and <b>Cycle +3</b>. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.CyclePlus, Tags.WildGain },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Wild },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card111);

        var card112 = new UnitData()
        {
            Id = 112,
            Name = "Sosthrim Druid",
            ImageTag = CardImageTags.Sosthrim_Druid,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"Whenever this attacks a unit <b>Root</b> it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Elven, Tags.PrayerGain, Tags.Root, Tags.Grovewatcher },
            Synergies = new List<Synergies> { Synergies.Midrange, Synergies.Prayer, Synergies.Root },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Grovewatcher,
            },
            Attack = 1,
            Health = 3,
            Protected = 0,
            Range = 2,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability82 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card112);

        var card113 = new SpellData()
        {
            Id = 113,
            Name = "Juicy Fruit",
            ImageTag = CardImageTags.Juicy_Fruit,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 0), },

            Text = @"Restore 5 Health to a unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { },
            SpellType = "Restoration",
            Range = 2,
        };
        CardList.Add(card113);

        var card114 = new UnitData()
        {
            Id = 114,
            Name = "Sosthrim Grovekeeper",
            ImageTag = CardImageTags.Sosthrim_Grovekeeper,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), },

            Text = @"<b>Deployment:</b> Shuffle 5 ""Juicy Fruit"" cards into your deck. 
At the end of each of your turns, draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Draw, Tags.Elven, Tags.Deployment, Tags.Grovewatcher },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Draw, Synergies.Deployment, Synergies.Value, Synergies.Restoration },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Grovewatcher,
            },
            Attack = 3,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card114);

        var card115 = new UnitData()
        {
            Id = 115,
            Name = "Woodland Sprite",
            ImageTag = CardImageTags.Woodland_Sprite,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), new Resource(CardResources.Wild, 3), },

            Text = @"<b>Lifebond, Spellshield</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Spellshield, Tags.Lifebond, Tags.Faerie, Tags.Soldier },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Antimagic, Synergies.Swarm, Synergies.Restoration, Synergies.Faerie },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Faerie,
                UnitTags.Soldier,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Lifebond, Keywords.Spellshield },
        };
        CardList.Add(card115);

        var card116 = new UnitData()
        {
            Id = 116,
            Name = "Worldroot Sapling",
            ImageTag = CardImageTags.Worldroot_Sapling,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 1), },

            Text = @"<b>Cycle -3</b>
At the start of each of your turns, gain 2 Wild",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Grovewatcher, Tags.WildGain, Tags.Treant },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Wild, Synergies.Treant },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Treant,
                UnitTags.Grovewatcher,
            },
            Attack = 0,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 1,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card116);

        var card117 = new SpellData()
        {
            Id = 117,
            Name = "Earth Ritual",
            ImageTag = CardImageTags.Earth_Ritual,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"Give a unit and the caster +3 Health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.SmallSpells, Synergies.Control },
            SpellType = "Enchantment",
            Range = 3,
        };
        CardList.Add(card117);

        var card118 = new SpellData()
        {
            Id = 118,
            Name = "Faerie's Blessing",
            ImageTag = CardImageTags.Faeries_Blessing,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"Give a minion <b>Spellshield</b> and <b>Lifebond</b> until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Spellshield, Tags.Lifebond },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Control, Synergies.Antimagic, Synergies.Restoration },
            SpellType = "Enchantment",
            Range = 3,
        };
        CardList.Add(card118);

        var card119 = new SpellData()
        {
            Id = 119,
            Name = "Patient Harvest",
            ImageTag = CardImageTags.Patient_Harvest,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            Text = @"At the start of your next turn, gain 4 Wild, <b>Cycle +4</b> and draw 2 cards",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.CyclePlus, Tags.WildGain },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Cycle, Synergies.Wild },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card119);

        var card120 = new UnitData()
        {
            Id = 120,
            Name = "Sosthrim Harvester",
            ImageTag = CardImageTags.Sosthrim_Harvester,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 5), },

            Text = @"Whenever a unit dies within Range 3, draw a card and <b>Prayer +2</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Elven, Tags.PrayerGain, Tags.Grovewatcher },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Swarm, Synergies.BigMinions, Synergies.Death, Synergies.Prayer },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Grovewatcher,
            },
            Attack = 4,
            Health = 8,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card120);

        var card121 = new UnitData()
        {
            Id = 121,
            Name = "Agent",
            ImageTag = CardImageTags.Agent1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Agent, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 3,
            Health = 15,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability21 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card121);

        var card122 = new UnitData()
        {
            Id = 122,
            Name = "Agent Infiltrator",
            ImageTag = CardImageTags.Agent2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Agent, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 4,
            Health = 24,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability22 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card122);

        var card123 = new UnitData()
        {
            Id = 123,
            Name = "Agent Spymaster",
            ImageTag = CardImageTags.Agent3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Agent, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 6,
            Health = 25,
            Protected = 0,
            Range = 1,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability23 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card123);

        var card124 = new UnitData()
        {
            Id = 124,
            Name = "Captain",
            ImageTag = CardImageTags.Captain1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Captain, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Captain,
            },
            Attack = 5,
            Health = 15,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability24 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card124);

        var card125 = new ItemData()
        {
            Id = 125,
            Name = "Battle Gear",
            ImageTag = CardImageTags.Battle_Gear,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"Whenever your hero attacks, gain +1 Attack  until the end of your turn and <b>Protected (1)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Protected, Tags.Sword, Tags.Metal },
            Synergies = new List<Synergies> { },
            ItemTag = "Metal Sword",
            Durability = 2,
        };
        CardList.Add(card125);

        var card126 = new UnitData()
        {
            Id = 126,
            Name = "Captain Champion",
            ImageTag = CardImageTags.Captain2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Captain, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Captain,
            },
            Attack = 5,
            Health = 25,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability25 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card126);

        var card127 = new UnitData()
        {
            Id = 127,
            Name = "Captain General",
            ImageTag = CardImageTags.Captain3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Captain, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Captain,
            },
            Attack = 7,
            Health = 31,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability26 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card127);

        var card128 = new UnitData()
        {
            Id = 128,
            Name = "Lifebringer",
            ImageTag = CardImageTags.Lifebringer1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Lifebringer, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lifebringer,
            },
            Attack = 1,
            Health = 17,
            Protected = 0,
            Range = 1,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability33 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card128);

        var card129 = new UnitData()
        {
            Id = 129,
            Name = "Lorekeeper",
            ImageTag = CardImageTags.Lorekeeper1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Lorekeeper, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lorekeeper,
            },
            Attack = 2,
            Health = 17,
            Protected = 0,
            Range = 1,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability36 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card129);

        var card130 = new UnitData()
        {
            Id = 130,
            Name = "Luminist",
            ImageTag = CardImageTags.Luminist1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Luminist, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Luminist,
            },
            Attack = 2,
            Health = 14,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability39 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card130);

        var card131 = new UnitData()
        {
            Id = 131,
            Name = "Mercenary",
            ImageTag = CardImageTags.Mercenary1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Mercenary, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 5,
            Health = 13,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability51 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card131);

        var card132 = new UnitData()
        {
            Id = 132,
            Name = "Oathknight",
            ImageTag = CardImageTags.Oathknight1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Oathknight, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Oathknight,
            },
            Attack = 3,
            Health = 17,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability52 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card132);

        var card133 = new UnitData()
        {
            Id = 133,
            Name = "Trickster",
            ImageTag = CardImageTags.Trickster1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Trickster, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Trickster,
            },
            Attack = 6,
            Health = 12,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability55 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card133);

        var card134 = new SpellData()
        {
            Id = 134,
            Name = "Shiv",
            ImageTag = CardImageTags.Shiv,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 0), },

            Text = @"<b>Piercing</b>
Deal 1 damage to a unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Piercing },
            SpellType = "Damage",
            Range = 1,
        };
        CardList.Add(card134);

        var card135 = new UnitData()
        {
            Id = 135,
            Name = "Waystalker",
            ImageTag = CardImageTags.Waystalker1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Waystalker, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Waystalker,
            },
            Attack = 2,
            Health = 10,
            Protected = 0,
            Range = 3,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability58 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card135);

        var card136 = new UnitData()
        {
            Id = 136,
            Name = "Trained Hound",
            ImageTag = CardImageTags.Trained_Hound,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 1), },

            Text = @"<b>Prepared</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Prepared, Tags.Beast, Tags.Trained },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Trained,
                UnitTags.Beast,
            },
            Attack = 1,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Prepared },
        };
        CardList.Add(card136);

        var card137 = new UnitData()
        {
            Id = 137,
            Name = "Wildkin",
            ImageTag = CardImageTags.Wildkin1,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Wildkin, Tags.HeroTierZero },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Wildkin,
            },
            Attack = 2,
            Health = 18,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability61 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card137);

        var card138 = new UnitData()
        {
            Id = 138,
            Name = "Worldroot Defender",
            ImageTag = CardImageTags.Worldroot_Defender,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            Text = @"<b>Warden, Unleash</b>
Whenever this unit deals damage, <b>Cycle</b> for the same amount",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Warden, Tags.CyclePlus, Tags.Soldier, Tags.Treant },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Durable, Synergies.Defensive, Synergies.Cycle, Synergies.Treant },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Treant,
                UnitTags.Soldier,
            },
            Attack = 2,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Unleash, Keywords.Warden },
        };
        CardList.Add(card138);

        var card139 = new SpellData()
        {
            Id = 139,
            Name = "Faerie Guile",
            ImageTag = CardImageTags.Faerie_Guile,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 3), new Resource(CardResources.Wild, 2), },

            Text = @"Gain control of an enemy minion until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.MindControl },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Removal },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card139);

        var card140 = new ItemData()
        {
            Id = 140,
            Name = "Spined Carapace",
            ImageTag = CardImageTags.Spined_Carapace,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 4), },

            Text = @"<b>Deployment:</b> Give your hero <b>Protected (6)</b>
Whenever an enemy is rooted or melee attacks your hero, deal 3 damage to it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Protected, Tags.Equip, Tags.Natural, Tags.Armour },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.Protected, Synergies.Defensive, Synergies.Equip, Synergies.Root },
            ItemTag = "Natural Armour",
            Durability = 4,
        };
        CardList.Add(card140);

        var card141 = new ItemData()
        {
            Id = 141,
            Name = "Treeheart Censer",
            ImageTag = CardImageTags.Treeheart_Censer,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 6), },

            Text = @"Whenever a friendly unit dies wthin Range 3, shuffle a copy of it into your deck and <b>Cycle -2</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Equip, Tags.CycleMinus, Tags.Natural, Tags.Trinket },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.BigMinions, Synergies.Value, Synergies.Equip, Synergies.Death, Synergies.Cycle, Synergies.Wild },
            ItemTag = "Natural Trinket",
            Durability = 5,
        };
        CardList.Add(card141);

        var card142 = new UnitData()
        {
            Id = 142,
            Name = "Worldroot Dreamer",
            ImageTag = CardImageTags.Worldroot_Dreamer,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 7), },

            Text = @"<b>Cycle -7</b>
At the end of your turn, reduce the Wild cost of a random card in your hand by (6)",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Deployment, Tags.CycleMinus, Tags.Grovewatcher, Tags.Treant },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.BigSpells, Synergies.BigMinions, Synergies.Cycle, Synergies.Wild, Synergies.Treant },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Treant,
                UnitTags.Grovewatcher,
            },
            Attack = 4,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card142);

        var card143 = new UnitData()
        {
            Id = 143,
            Name = "Faerie Harbinger",
            ImageTag = CardImageTags.Faerie_Harbringer,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 5), new Resource(CardResources.Wild, 4), },

            Text = @"<b>Lifebond, Spellshield
Deployment:</b> Shuffle 3 ""Woodland Sprites"" into your deck. Give them +2 Attack, +2 Health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Spellshield, Tags.Deployment, Tags.Lifebond, Tags.Faerie, Tags.Soldier },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Melee, Synergies.Control, Synergies.Draw, Synergies.Deployment, Synergies.Swarm, Synergies.BigMinions, Synergies.Value, Synergies.Prayer, Synergies.Restoration, Synergies.Faerie },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Faerie,
                UnitTags.Soldier,
            },
            Attack = 6,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Lifebond, Keywords.Spellshield },
        };
        CardList.Add(card143);

        var card144 = new SpellData()
        {
            Id = 144,
            Name = "Recycling",
            ImageTag = CardImageTags.Recycling,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 8), },

            Text = @"Deploy three random Treant minions in your Graveyard adjacent to the caster. <b>Cycle -6</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.CycleMinus, Tags.Resurrection },
            Synergies = new List<Synergies> { Synergies.BigSpells, Synergies.BigMinions, Synergies.Value, Synergies.Cycle, Synergies.Wild, Synergies.Treant },
            SpellType = "Deployment",
            Range = 0,
        };
        CardList.Add(card144);

        var card145 = new UnitData()
        {
            Id = 145,
            Name = "Worldroot Ancient",
            ImageTag = CardImageTags.Worldroot_Ancient,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 9), },

            Text = @"<b>Unleash, Warden, Cycle -6</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Warden, Tags.CycleMinus, Tags.Grovewatcher, Tags.Treant, Tags.Unleash },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Durable, Synergies.Defensive, Synergies.Cycle, Synergies.Treant, Synergies.Unleash },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Treant,
                UnitTags.Grovewatcher,
            },
            Attack = 9,
            Health = 9,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Unleash, Keywords.Warden },
        };
        CardList.Add(card145);

        var card146 = new UnitData()
        {
            Id = 146,
            Name = "Queen Aedellaei",
            ImageTag = CardImageTags.Queen_Aedellaei,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 6), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Lifebond, Spellshield</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Spellshield, Tags.Lifebond, Tags.Noble, Tags.Faerie },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Antimagic, Synergies.BigMinions, Synergies.Prayer, Synergies.Restoration, Synergies.Wild, Synergies.Faerie },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Faerie,
                UnitTags.Noble,
            },
            Attack = 7,
            Health = 9,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability83 },

            Keywords = new List<Keywords>() { Keywords.Lifebond, Keywords.Spellshield },
        };
        CardList.Add(card146);

        var card147 = new UnitData()
        {
            Id = 147,
            Name = "Naharr, the Worldroot",
            ImageTag = CardImageTags.Naharr_the_Worldroot,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 12), },

            Text = @"<b>Unleash, Warden, Cycle -9
Last Rites:</b> Shuffle a copy of this unit back into your deck. It keeps any enchantments gained from <b>Unleash</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Warden, Tags.LastRites, Tags.CycleMinus, Tags.Grovewatcher, Tags.Treant, Tags.Unleash },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Durable, Synergies.BigMinions, Synergies.Defensive, Synergies.Value, Synergies.LastRites, Synergies.Cycle, Synergies.Wild, Synergies.Treant, Synergies.Unleash },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Treant,
                UnitTags.Grovewatcher,
            },
            Attack = 12,
            Health = 12,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Unleash, Keywords.Warden },
        };
        CardList.Add(card147);

        var card148 = new UnitData()
        {
            Id = 148,
            Name = "Lifebringer Cleric",
            ImageTag = CardImageTags.Lifebringer2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Lifebringer, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lifebringer,
            },
            Attack = 2,
            Health = 25,
            Protected = 0,
            Range = 1,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability34 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card148);

        var card149 = new UnitData()
        {
            Id = 149,
            Name = "Lifebringer Archpriest",
            ImageTag = CardImageTags.Lifebringer3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Lifebringer, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lifebringer,
            },
            Attack = 3,
            Health = 32,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability35 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card149);

        var card150 = new SpellData()
        {
            Id = 150,
            Name = "Potion of Confusion",
            ImageTag = CardImageTags.Potion_of_Confusion,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 0), },

            Text = @"Swap a minions attack and health until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Potion },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card150);

        var card151 = new SpellData()
        {
            Id = 151,
            Name = "Potion of Decay",
            ImageTag = CardImageTags.Potion_of_Decay,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 0), },

            Text = @"Reduce a units attack by 3 until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Potion },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card151);

        var card152 = new SpellData()
        {
            Id = 152,
            Name = "Potion of Frost",
            ImageTag = CardImageTags.Potion_of_Frost,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 0), },

            Text = @"<b>Stun</b> a unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.Potion },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card152);

        var card153 = new SpellData()
        {
            Id = 153,
            Name = "Potion of Healing",
            ImageTag = CardImageTags.Potion_of_Healing,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 0), },

            Text = @"Restore 3 Health to a unit. Any excess healing increases the units attack by that amount until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Potion },
            Synergies = new List<Synergies> { },
            SpellType = "Restoration",
            Range = 2,
        };
        CardList.Add(card153);

        var card154 = new SpellData()
        {
            Id = 154,
            Name = "Potion of Shadows",
            ImageTag = CardImageTags.Potion_of_Shadows,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 0), },

            Text = @"Give a unit <b>Stealth</b> until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Potion, Tags.Stealth },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card154);

        var card155 = new SpellData()
        {
            Id = 155,
            Name = "Potion of Speed",
            ImageTag = CardImageTags.Potion_of_Speed,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 0), },

            Text = @"Give a unit +2 Speed until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Potion },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card155);

        var card156 = new SpellData()
        {
            Id = 156,
            Name = "Divine Ritual",
            ImageTag = CardImageTags.Divine_Ritual,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 0), new Resource(CardResources.Gold, 3), },

            Text = @"<b>Prayer +2</b>
Give the caster +3 Health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.PrayerGain },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Control, Synergies.Durable, Synergies.Prayer },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card156);

        var card157 = new SpellData()
        {
            Id = 157,
            Name = "Lay on Hands",
            ImageTag = CardImageTags.Lay_on_Hands,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), },

            Text = @"Restore 5 Health to a unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.SmallSpells, Synergies.Control, Synergies.Restoration },
            SpellType = "Restoration",
            Range = 1,
        };
        CardList.Add(card157);

        var card158 = new SpellData()
        {
            Id = 158,
            Name = "Quick Alchemy",
            ImageTag = CardImageTags.Quick_Alchemy,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), },

            Text = @"Add a random potion card to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.Stealth },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Value, Synergies.Potions },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card158);

        var card159 = new UnitData()
        {
            Id = 159,
            Name = "Sorena Cleric",
            ImageTag = CardImageTags.Sorena_Cleric,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"<b>Lifebond</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.PrayerGain, Tags.Lifebond, Tags.Lifebringer },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Prayer, Synergies.Restoration },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lifebringer,
            },
            Attack = 3,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability84 },

            Keywords = new List<Keywords>() { Keywords.Lifebond },
        };
        CardList.Add(card159);

        var card160 = new UnitData()
        {
            Id = 160,
            Name = "Tending Priest",
            ImageTag = CardImageTags.Tending_Priest,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 3), },

            Text = @"<b>Deployment:</b> Use <b>Soothe Wounds</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Lifebringer },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Deployment, Synergies.Restoration },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lifebringer,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability85 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card160);

        var card161 = new UnitData()
        {
            Id = 161,
            Name = "Tithe Collector",
            ImageTag = CardImageTags.Tithe_Collector,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"<b>Routing</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Noble, Tags.GoldGain, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Swarm, Synergies.Gold, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Noble,
            },
            Attack = 2,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability86 },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card161);

        var card162 = new UnitData()
        {
            Id = 162,
            Name = "Golden Host",
            ImageTag = CardImageTags.Golden_Host,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 3), new Resource(CardResources.Gold, 2), },

            Text = @"<b>Warden</b>
Has +1 Attack and +1 Health for each other friendly ""Golden Host"" within Range 2. Whenever a friendly ""Golden Host"" dies within Range 2, <b>Regenerate</b>
<b>Last Rites:</b> Shuffle an additional copy of this unit into your Graveyard",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Warden, Tags.Regenerate, Tags.Soldier, Tags.GoldenHost },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Melee, Synergies.Durable, Synergies.Swarm, Synergies.Defensive, Synergies.Resurrection, Synergies.GoldenHost },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Soldier,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Warden },
        };
        CardList.Add(card162);

        var card163 = new SpellData()
        {
            Id = 163,
            Name = "Offer Alms",
            ImageTag = CardImageTags.Offer_Alms,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), },

            Text = @"<b>Regenerate</b> a friendly minion",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Regenerate },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Durable, Synergies.Restoration },
            SpellType = "Restoration",
            Range = 2,
        };
        CardList.Add(card163);

        var card164 = new UnitData()
        {
            Id = 164,
            Name = "Potion Seller",
            ImageTag = CardImageTags.Potion_Seller,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), },

            Text = @"<b>Routing
Deployment:</b> Use <b>Potion Sale</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Stun, Tags.Deployment, Tags.Stealth, Tags.Merchant, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.SmallSpells, Synergies.Deployment, Synergies.Value, Synergies.Potions, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Merchant,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability87 },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card164);

        var card165 = new SpellData()
        {
            Id = 165,
            Name = "Return Soul",
            ImageTag = CardImageTags.Return_Soul,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"Deploy a random minion in your Graveyard adjacent to the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Resurrection },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.BigMinions, Synergies.Value, Synergies.Resurrection },
            SpellType = "Deployment",
            Range = 0,
        };
        CardList.Add(card165);

        var card166 = new UnitData()
        {
            Id = 166,
            Name = "Sorena High Priest",
            ImageTag = CardImageTags.Sorena_High_Priest,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 6), },

            Text = @"<b>Conduit, Lifebond</b>
Whenever this unit or your hero is healed, <b>Prayer +3.</b> All your healing is doubled",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Conduit, Tags.PrayerGain, Tags.Lifebond, Tags.Lifebringer },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Durable, Synergies.Midrange, Synergies.BigMinions, Synergies.Prayer, Synergies.Restoration },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lifebringer,
            },
            Attack = 2,
            Health = 5,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Lifebond },
        };
        CardList.Add(card166);

        var card167 = new ItemData()
        {
            Id = 167,
            Name = "Amulet of Divinity",
            ImageTag = CardImageTags.Amulet_of_Divinity,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 5), new Resource(CardResources.Gold, 2), },

            Text = @"Whenever a friendly unit dies within Range 2 of your hero, store its soul. 
<b>Last Rites:</b> Redeploy the stored units",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.LastRites, Tags.Resurrection, Tags.Holy, Tags.Amulet },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.BigMinions, Synergies.Value, Synergies.Prayer, Synergies.Resurrection },
            ItemTag = "Holy Amulet",
            Durability = 3,
        };
        CardList.Add(card167);

        var card168 = new SpellData()
        {
            Id = 168,
            Name = "Binding Circle",
            ImageTag = CardImageTags.Binding_Circle,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"<b>Spellbind</b> then <b>Root</b> a unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Spellbind, Tags.Root },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Antimagic, Synergies.Root },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card168);

        var card169 = new UnitData()
        {
            Id = 169,
            Name = "Golden Lifebinder",
            ImageTag = CardImageTags.Golden_Lifebinder,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), new Resource(CardResources.Gold, 3), },

            Text = @"<b>Deployment:</b> Choose one of three different random units in your Graveyard to deploy adjacent to this unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Deployment, Tags.Lifebringer, Tags.Resurrection },
            Synergies = new List<Synergies> { Synergies.Deployment, Synergies.BigMinions, Synergies.ShortRange, Synergies.Resurrection, Synergies.GoldenHost },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lifebringer,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 1,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card169);

        var card170 = new SpellData()
        {
            Id = 170,
            Name = "Sanctuary",
            ImageTag = CardImageTags.Sanctuary,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), },

            Text = @"Restore 4 Health to all friendly units in an area of Radius 2 from the caster. Until the start of your next turn, whenever an ally enters the area for the first time on a turn, restore 2 Health to it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Durable, Synergies.Defensive, Synergies.Restoration },
            SpellType = "Restoration",
            Range = 4,
        };
        CardList.Add(card170);

        var card171 = new UnitData()
        {
            Id = 171,
            Name = "Defender of Sorena",
            ImageTag = CardImageTags.Defender_of_Sorena,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 7), },

            Text = @"<b>Lifebond, Warden</b>
Deal 1 damage to any enemy unit which damages friendly units within Range 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Warden, Tags.Lifebond, Tags.Lifebringer },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Melee, Synergies.Control, Synergies.Swarm, Synergies.BigMinions, Synergies.Defensive, Synergies.Prayer, Synergies.Restoration, Synergies.Retribution },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lifebringer,
            },
            Attack = 2,
            Health = 10,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Lifebond, Keywords.Warden },
        };
        CardList.Add(card171);

        var card172 = new UnitData()
        {
            Id = 172,
            Name = "Golden Hostcaller",
            ImageTag = CardImageTags.Golden_Hostcaller,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 8), new Resource(CardResources.Gold, 4), },

            Text = @"<b>Conduit
Deployment:</b> Deploy 2 Golden Hosts beside this unit.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Conduit, Tags.Deployment, Tags.Soldier, Tags.GoldenHost },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.BigMinions, Synergies.Prayer, Synergies.Resurrection, Synergies.GoldenHost },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Soldier,
            },
            Attack = 4,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability88 },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card172);

        var card173 = new ItemData()
        {
            Id = 173,
            Name = "Potion Satchel",
            ImageTag = CardImageTags.Potion_Satchel,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), },

            Text = @"Whenever you add a potion card to your hand, add another copy of it to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Stun, Tags.Stealth, Tags.Alchemy, Tags.Bag },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Value, Synergies.Potions },
            ItemTag = "Alchemy Bag",
            Durability = 4,
        };
        CardList.Add(card173);

        var card174 = new SpellData()
        {
            Id = 174,
            Name = "Divine Intervention",
            ImageTag = CardImageTags.Divine_Intervention,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 30), },

            Text = @"Costs (1) Devotion less for each point your units have been healed since the last ""Divine Intervention"" was played.
Give the caster <b>Protected (10).</b> Destroy all enemy minions adjacent to the caster. Draw 3 cards",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.Protected },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Durable, Synergies.BigSpells, Synergies.Defensive, Synergies.Removal, Synergies.Prayer, Synergies.Restoration, Synergies.Retribution },
            SpellType = "Removal",
            Range = 0,
        };
        CardList.Add(card174);

        var card175 = new UnitData()
        {
            Id = 175,
            Name = "Tythelia, Lady of Gold",
            ImageTag = CardImageTags.Tythelia_Lady_of_Gold,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 8), new Resource(CardResources.Gold, 6), },

            Text = @"<b>Warden
Deployment:</b> Deploy two random units in your Graveyard besides this one. Whenever one of them dies, <b>Regenerate</b> this unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Warden, Tags.Deployment, Tags.Noble, Tags.Regenerate, Tags.GoldenHost },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Durable, Synergies.Deployment, Synergies.BigMinions, Synergies.Defensive, Synergies.Prayer, Synergies.Gold, Synergies.Resurrection, Synergies.GoldenHost },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Noble,
            },
            Attack = 8,
            Health = 8,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Warden },
        };
        CardList.Add(card175);

        var card176 = new UnitData()
        {
            Id = 176,
            Name = "Lorekeeper Keymaster",
            ImageTag = CardImageTags.Lorekeeper2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Lorekeeper, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lorekeeper,
            },
            Attack = 3,
            Health = 25,
            Protected = 0,
            Range = 1,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability37 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card176);

        var card177 = new UnitData()
        {
            Id = 177,
            Name = "Lorekeeper Vaultwarden",
            ImageTag = CardImageTags.Lorekeeper3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Lorekeeper, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lorekeeper,
            },
            Attack = 4,
            Health = 32,
            Protected = 0,
            Range = 2,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability38 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card177);

        var card178 = new SpellData()
        {
            Id = 178,
            Name = "Recorded Inspiration",
            ImageTag = CardImageTags.Recorded_Inspiration,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), },

            Text = @"<b>Cast When Drawn</b>
Increase your base Knowledge rate by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.StudyGain, Tags.CastWhenDrawn, Tags.Inspiration },
            Synergies = new List<Synergies> { },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card178);

        var card179 = new SpellData()
        {
            Id = 179,
            Name = "Dedicated Preservation",
            ImageTag = CardImageTags.Dedicated_Preservation,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), new Resource(CardResources.Knowledge, 0), },

            Text = @"<b>Study (4).</b> Shuffle a copy of a spell in your hand into your deck",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.StudyGain },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.BigSpells, Synergies.Value, Synergies.Study, Synergies.Preservation, Synergies.Exchanges },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card179);

        var card180 = new SpellData()
        {
            Id = 180,
            Name = "Mind Collapse",
            ImageTag = CardImageTags.Mind_Collapse,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), new Resource(CardResources.Knowledge, 2), },

            Text = @"<b>Lifebond, Piercing</b>
Deal damage to a unit equal to its attack",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Lifebond, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Control, Synergies.Removal, Synergies.Restoration, Synergies.Equalize, Synergies.Madness, Synergies.Piercing },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card180);

        var card181 = new UnitData()
        {
            Id = 181,
            Name = "Oldari Acolyte",
            ImageTag = CardImageTags.Oldari_Acolyte,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"Whenever this attacks a unit, reduce its attack by 2 until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.PrayerGain, Tags.Lorekeeper },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Prayer, Synergies.Pacify },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lorekeeper,
            },
            Attack = 1,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability89 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card181);

        var card182 = new SpellData()
        {
            Id = 182,
            Name = "Ring the Bells",
            ImageTag = CardImageTags.Ring_the_Bells,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"Draw a minion from your deck. Give it +2 Attack, +2 Health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Draw, Synergies.Swarm, Synergies.BigMinions },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card182);

        var card183 = new SpellData()
        {
            Id = 183,
            Name = "Subdue",
            ImageTag = CardImageTags.Subdue,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            Text = @"Destroy a minion with 4 or more attack",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleRemoval },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Removal },
            SpellType = "Removal",
            Range = 3,
        };
        CardList.Add(card183);

        var card184 = new UnitData()
        {
            Id = 184,
            Name = "Vault Collector",
            ImageTag = CardImageTags.Vault_Collector,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            Text = @"<b>Deployment:</b> Use <b>Submit Collection</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Dwarven, Tags.Deployment, Tags.StudyGain, Tags.Lorekeeper },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.Study },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Dwarven,
                UnitTags.Lorekeeper,
            },
            Attack = 2,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability90 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card184);

        var card185 = new SpellData()
        {
            Id = 185,
            Name = "Equalize",
            ImageTag = CardImageTags.Equalize,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), },

            Text = @"Set a minions Health equal to its attack",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Equalize, Synergies.Pacify },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card185);

        var card186 = new SpellData()
        {
            Id = 186,
            Name = "Maddening Knowledge",
            ImageTag = CardImageTags.Maddening_Knowledge,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), new Resource(CardResources.Knowledge, 2), },

            Text = @"Force a minion to melee attack a random adjacent unit. It loses its next action",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Removal, Synergies.Madness },
            SpellType = "Enchantment",
            Range = 3,
        };
        CardList.Add(card186);

        var card187 = new UnitData()
        {
            Id = 187,
            Name = "Oldari Spellweaver",
            ImageTag = CardImageTags.Oldari_Spellweaver,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), },

            Text = @"<b>Spellshield</b>
After a unit casts a spell within Range 2, <b>Prayer +2</b>.
Whenever this attacks a unit, reduce its attack by 3 until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Spellshield, Tags.PrayerGain, Tags.Lorekeeper },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.BigSpells, Synergies.Antimagic, Synergies.ShortRange, Synergies.Prayer, Synergies.Pacify },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Lorekeeper,
            },
            Attack = 1,
            Health = 4,
            Protected = 0,
            Range = 1,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Spellshield },
        };
        CardList.Add(card187);

        var card188 = new SpellData()
        {
            Id = 188,
            Name = "Pacify",
            ImageTag = CardImageTags.Pacify,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), },

            Text = @"Reduce a units attack by 3 until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Pacify },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card188);

        var card189 = new UnitData()
        {
            Id = 189,
            Name = "Vault Archivist",
            ImageTag = CardImageTags.Vault_Archivist,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 4), },

            Text = @"<b>Deployment: Study (4)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Dwarven, Tags.Deployment, Tags.StudyGain, Tags.Lorekeeper },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Deployment, Synergies.Study },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Dwarven,
                UnitTags.Lorekeeper,
            },
            Attack = 4,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability91 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card189);

        var card190 = new ItemData()
        {
            Id = 190,
            Name = "Book of Records",
            ImageTag = CardImageTags.Book_of_Records,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            Text = @"<b>Deployment: Divinate (2)</b>
After you cast a spell, shuffle a copy of it into your deck",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Magic, Tags.Tome },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.BigSpells, Synergies.Value, Synergies.Equip, Synergies.Preservation, Synergies.Exchanges },
            ItemTag = "Magic Tome",
            Durability = 5,
        };
        CardList.Add(card190);

        var card191 = new UnitData()
        {
            Id = 191,
            Name = "Deep Priest",
            ImageTag = CardImageTags.Deep_Priest,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 5), new Resource(CardResources.Knowledge, 3), },

            Text = @"<b>Lifebond
Deployment:</b> Choose a minion. Swap this units attack and Health with it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Deployment, Tags.Divinate, Tags.Lifebond, Tags.Lorekeeper, Tags.Dragonkin },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Antimagic, Synergies.Deployment, Synergies.Prediction, Synergies.Prayer, Synergies.Restoration, Synergies.Equalize, Synergies.Pacify },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Dragonkin,
                UnitTags.Lorekeeper,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1119 },

            Keywords = new List<Keywords>() { Keywords.Lifebond },
        };
        CardList.Add(card191);

        var card192 = new SpellData()
        {
            Id = 192,
            Name = "Prevent Repetiton",
            ImageTag = CardImageTags.Prevent_Repetition,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 6), },

            Text = @"<b>Divinate (3)</b>
Draw 3 cards",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.Divinate },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.BigSpells, Synergies.Study, Synergies.Prediction },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card192);

        var card193 = new UnitData()
        {
            Id = 193,
            Name = "Vault Catalyst",
            ImageTag = CardImageTags.Vault_Catalyst,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 4), },

            Text = @"<b>Conduit</b>
After you cast a spell, draw a spell of the same total cost from your deck",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Draw, Tags.Dwarven, Tags.Conduit, Tags.Lorekeeper },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Draw, Synergies.BigSpells, Synergies.ShortRange, Synergies.Preservation },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Dwarven,
                UnitTags.Lorekeeper,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 1,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card193);

        var card194 = new ItemData()
        {
            Id = 194,
            Name = "Book of Madness",
            ImageTag = CardImageTags.Book_of_Madness,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), new Resource(CardResources.Knowledge, 5), },

            Text = @"Your hero has +2 range.
After your hero attacks a unit, the target melee attacks a random adjacent unit and loses it next action.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Magic, Tags.Tome },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Defensive, Synergies.Equip, Synergies.Study, Synergies.Madness },
            ItemTag = "Magic Tome",
            Durability = 4,
        };
        CardList.Add(card194);

        var card195 = new SpellData()
        {
            Id = 195,
            Name = "Deep Conversion",
            ImageTag = CardImageTags.Deep_Conversion,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 3), new Resource(CardResources.Knowledge, 7), },

            Text = @"Gain control of an enemy minion",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.MindControl },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.BigSpells, Synergies.Study, Synergies.Removal, Synergies.Madness },
            SpellType = "Enchantment",
            Range = 1,
        };
        CardList.Add(card195);

        var card196 = new SpellData()
        {
            Id = 196,
            Name = "Repress",
            ImageTag = CardImageTags.Repress,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 5), },

            Text = @"Destroy all minions with 4 or more attack in an area of Radius 3",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaRemoval },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.BigSpells, Synergies.Study, Synergies.Removal },
            SpellType = "Removal",
            Range = 3,
        };
        CardList.Add(card196);

        var card197 = new UnitData()
        {
            Id = 197,
            Name = "Corthax, Keeper of the Deeps",
            ImageTag = CardImageTags.Corthax_Keeper_of_the_Deeps,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 6), new Resource(CardResources.Knowledge, 7), },

            Text = @"<b>Lifebond</b>
<b>Last Rites:</b>Use <b>Deep Exposure</b> on all units within Range 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.LastRites, Tags.Lifebond, Tags.Lorekeeper, Tags.Dragonkin, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.Study, Synergies.Removal, Synergies.Prayer, Synergies.Restoration, Synergies.Retribution, Synergies.Equalize, Synergies.Piercing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Dragonkin,
                UnitTags.Lorekeeper,
            },
            Attack = 5,
            Health = 8,
            Protected = 0,
            Range = 1,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability92 },

            Keywords = new List<Keywords>() { Keywords.Lifebond },
        };
        CardList.Add(card197);

        var card198 = new UnitData()
        {
            Id = 198,
            Name = "Grand Archivist Nurosi",
            ImageTag = CardImageTags.Grand_Archivist_Nurosi,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 8), },

            Text = @"<b>Conduit</b>
<b>Deployment:</b> Shuffle a copy of all spells in your hand into your deck.
Whenever you shuffle a card into your deck, reduce its cost by (4)",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Dwarven, Tags.Conduit, Tags.Deployment, Tags.Lorekeeper },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.SmallSpells, Synergies.Draw, Synergies.BigSpells, Synergies.Deployment, Synergies.BigMinions, Synergies.Value, Synergies.Study, Synergies.Preservation, Synergies.Exchanges },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Dwarven,
                UnitTags.Lorekeeper,
            },
            Attack = 7,
            Health = 7,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability93 },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card198);

        var card199 = new UnitData()
        {
            Id = 199,
            Name = "Oathknight Guardian",
            ImageTag = CardImageTags.Oathknight2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Oathknight, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Oathknight,
            },
            Attack = 4,
            Health = 26,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability53 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card199);

        var card200 = new UnitData()
        {
            Id = 200,
            Name = "Oathknight Sentinel",
            ImageTag = CardImageTags.Oathknight3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Oathknight, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Oathknight,
            },
            Attack = 5,
            Health = 35,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability54 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card200);

        var card201 = new SpellData()
        {
            Id = 201,
            Name = "Aid From Above",
            ImageTag = CardImageTags.Aid_From_Above,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 6), },

            Text = @"Deploy two ""Angel of Protection"" units beside the caster. Give the caster <b>Protected (4)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Protected, Tags.Warden, Tags.Lifebond, Tags.Flying },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Protected, Synergies.BigSpells, Synergies.Swarm, Synergies.Defensive, Synergies.Prayer, Synergies.Restoration, Synergies.Flying, Synergies.Angels },
            SpellType = "Deployment",
            Range = 0,
        };
        CardList.Add(card201);

        var card202 = new UnitData()
        {
            Id = 202,
            Name = "Angel of Protection",
            ImageTag = CardImageTags.Angel_of_Protection,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 3), },

            Text = @"<b>Warden, Flying, Lifebond, Protected (2)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Protected, Tags.Warden, Tags.Lifebond, Tags.Flying, Tags.Oathknight, Tags.Angel },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Angel,
                UnitTags.Oathknight,
            },
            Attack = 2,
            Health = 2,
            Protected = 2,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Flying, Keywords.Lifebond, Keywords.Warden },
        };
        CardList.Add(card202);

        var card203 = new UnitData()
        {
            Id = 203,
            Name = "Angel of Devotion",
            ImageTag = CardImageTags.Angel_of_Devotion,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 2), },

            Text = @"<b>Flying</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.PrayerGain, Tags.Flying, Tags.Oathknight, Tags.Angel },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Prayer, Synergies.Flying, Synergies.Angels },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Angel,
                UnitTags.Oathknight,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability94 },

            Keywords = new List<Keywords>() { Keywords.Flying },
        };
        CardList.Add(card203);

        var card204 = new SpellData()
        {
            Id = 204,
            Name = "Battle Prayer",
            ImageTag = CardImageTags.Battle_Prayer,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 0), new Resource(CardResources.Energy, 3), },

            Text = @"<b>Prayer +2.</b> Give the caster <b>Protected (3)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Protected, Tags.PrayerGain },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Durable, Synergies.Protected, Synergies.Prayer },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card204);

        var card205 = new SpellData()
        {
            Id = 205,
            Name = "Divine Strength",
            ImageTag = CardImageTags.Divine_Strength,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), },

            Text = @"Give a unit +4 Attack, +4 Health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Durable },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card205);

        var card206 = new UnitData()
        {
            Id = 206,
            Name = "Eager Squire",
            ImageTag = CardImageTags.Eager_Squire,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"<b>Prepared</b>
At the start of each turn, if this unit is adjacent to your hero, gain +1 Attack, +1 Health.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Enchantment, Tags.Draw, Tags.Prepared, Tags.Knight },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Melee, Synergies.Draw, Synergies.Durable, Synergies.Swarm, Synergies.Prepared },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Knight,
            },
            Attack = 1,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability95 },

            Keywords = new List<Keywords>() { Keywords.Prepared },
        };
        CardList.Add(card206);

        var card207 = new SpellData()
        {
            Id = 207,
            Name = "Shield of Faith",
            ImageTag = CardImageTags.Shield_of_Faith,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 1), },

            Text = @"Give a unit <b>Protected (3).</b> Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Draw, Tags.Protected },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.SmallSpells, Synergies.Draw, Synergies.Durable, Synergies.Protected },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card207);

        var card208 = new UnitData()
        {
            Id = 208,
            Name = "Angel of Purity",
            ImageTag = CardImageTags.Angel_of_Purity,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 5), },

            Text = @"<b>Flying, Lifebond
Lifebond</b> healing from this unit heals this unit as well as your hero",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Lifebond, Tags.Flying, Tags.Oathknight, Tags.Angel },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Durable, Synergies.BigMinions, Synergies.Prayer, Synergies.Restoration, Synergies.Flying, Synergies.Angels },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Angel,
                UnitTags.Oathknight,
            },
            Attack = 3,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Flying, Keywords.Lifebond },
        };
        CardList.Add(card208);

        var card209 = new SpellData()
        {
            Id = 209,
            Name = "Bravery",
            ImageTag = CardImageTags.Bravery,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"The caster gains <b>Overwhelm</b> until the end of your turn. If the caster kills a unit before the end of your turn, give all friendly units within Range 2 +2 Attack and +2 Health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Overwhelm },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Enchantment, Synergies.Swarm, Synergies.Overwhelm },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card209);

        var card210 = new UnitData()
        {
            Id = 210,
            Name = "Oathspeaker",
            ImageTag = CardImageTags.Oathspeaker,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), new Resource(CardResources.Energy, 2), },

            Text = @"<b>Deployment:</b> Draw an Oath from your deck. If you don't have an Oath in your deck, add a random Oath card to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Draw, Tags.Oathknight },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Draw, Synergies.Value, Synergies.Oaths },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Oathknight,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card210);

        var card211 = new UnitData()
        {
            Id = 211,
            Name = "Shield of Goldland",
            ImageTag = CardImageTags.Shield_of_Goldland,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), },

            Text = @"<b>Warden, Protected (2)</b>
At the end of your turn, <b>Prayer +2</b> for each adjacent enemy unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Protected, Tags.Warden, Tags.PrayerGain, Tags.Knight },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Control, Synergies.Protected, Synergies.Defensive, Synergies.Prayer },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Knight,
            },
            Attack = 2,
            Health = 4,
            Protected = 2,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Warden },
        };
        CardList.Add(card211);

        var card212 = new UnitData()
        {
            Id = 212,
            Name = "Warhorse",
            ImageTag = CardImageTags.Warhorse,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"<b>Prepared</b>
Gain +1 Attack for each tile moved this turn until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Prepared, Tags.Beast, Tags.Steed },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Melee, Synergies.Mobility, Synergies.Prepared, Synergies.Mounted },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Beast,
                UnitTags.Steed,
            },
            Attack = 1,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Prepared },
        };
        CardList.Add(card212);

        var card213 = new UnitData()
        {
            Id = 213,
            Name = "Angel of Judgement",
            ImageTag = CardImageTags.Angel_of_Judgement,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 7), },

            Text = @"<b>Flying, Vanguard
Deployment:</b> Choose an adjacent unit. Deal damage to it equal to the number of angels in your Graveyard",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Deployment, Tags.Flying, Tags.Oathknight, Tags.Angel, Tags.Vanguard },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Deployment, Synergies.Vanguard, Synergies.Prayer, Synergies.Flying, Synergies.Retribution, Synergies.Angels },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Angel,
                UnitTags.Oathknight,
            },
            Attack = 5,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Flying, Keywords.Vanguard },
        };
        CardList.Add(card213);

        var card214 = new SpellData()
        {
            Id = 214,
            Name = "Consecrate",
            ImageTag = CardImageTags.Consecrate,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), },

            Text = @"Deal 2 damage to all enemy units within an area of Radius 2 from the caster. Until the start of your next turn, whenever an enemy unit enters these tiles for the first time on a turn, deal 2 damage to it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.AreaDamage, Synergies.Defensive },
            SpellType = "Damage",
            Range = 0,
        };
        CardList.Add(card214);

        var card215 = new SpellData()
        {
            Id = 215,
            Name = "Mount Up",
            ImageTag = CardImageTags.Mount_Up,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"Choose a friendly Steed unit. The casters speed is increased up to that unit's speed and gains any text effect on it as an Enchantment until the end of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.SmallSpells, Synergies.Mobility, Synergies.Mounted },
            SpellType = "Enchantment",
            Range = 1,
        };
        CardList.Add(card215);

        var card216 = new UnitData()
        {
            Id = 216,
            Name = "Pegasus",
            ImageTag = CardImageTags.Pegasus,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 3), new Resource(CardResources.Energy, 4), },

            Text = @"<b>Prepared, Flying</b>
Whenever this unit moves from Airborne to Landed, gain +4 Attack and <b>Overwhelm</b> until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Prepared, Tags.Overwhelm, Tags.Flying, Tags.Steed, Tags.Mythic },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Enchantment, Synergies.Melee, Synergies.Mobility, Synergies.Flying, Synergies.Mounted },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Mythic,
                UnitTags.Steed,
            },
            Attack = 1,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 5,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Flying, Keywords.Prepared },
        };
        CardList.Add(card216);

        var card217 = new SpellData()
        {
            Id = 217,
            Name = "Oath of Protection",
            ImageTag = CardImageTags.Oath_of_Protection,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 7), new Resource(CardResources.Energy, 4), },

            Text = @"Equip an ""Oath of Protection"" item. Destroy any other Oath item you have equipped",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Protected, Tags.Spellshield, Tags.Warden, Tags.Equip, Tags.Oath },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Durable, Synergies.Protected, Synergies.BigSpells, Synergies.Antimagic, Synergies.Defensive, Synergies.Equip, Synergies.Prayer, Synergies.Oaths },
            SpellType = "Equip",
            Range = 0,
        };
        CardList.Add(card217);

        var card218 = new ItemData()
        {
            Id = 218,
            Name = "Oath of Protection",
            ImageTag = CardImageTags.Oath_of_Protection_Item,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 7), new Resource(CardResources.Energy, 4), },

            Text = @"When this is equipped and at the start of each turn, your hero gains the following enchantments which end at the start of your next turn: <b>Warden.</b> At the start of your turn, gain <b>Protected (5).</b> All adjacent friendly units gain <b>Spellshield</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Protected, Tags.Spellshield, Tags.Warden, Tags.Oath, Tags.Conjured },
            Synergies = new List<Synergies> { },
            ItemTag = "Conjured Oath",
            Durability = 4,
        };
        CardList.Add(card218);

        var card219 = new SpellData()
        {
            Id = 219,
            Name = "Oath of Restoration",
            ImageTag = CardImageTags.Oath_of_Restoration,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 5), new Resource(CardResources.Energy, 3), },

            Text = @"Equip an ""Oath of Restoration"" item. Destroy any other Oath items you have equipped",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Equip, Tags.Lifebond, Tags.Oath },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Durable, Synergies.BigSpells, Synergies.Equip, Synergies.Prayer, Synergies.Restoration, Synergies.Oaths },
            SpellType = "Equip",
            Range = 0,
        };
        CardList.Add(card219);

        var card220 = new ItemData()
        {
            Id = 220,
            Name = "Oath of Restoration",
            ImageTag = CardImageTags.Oath_of_Restoration_Item,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 5), new Resource(CardResources.Energy, 3), },

            Text = @"When this is equipped and at the start of your each turn your hero gains the following enchantments which end at the start of your next turn: <b>Lifebond.</b> Whenever this unit is healed, heal all other friendly units within Range 2 for the same amount",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Equip, Tags.Lifebond, Tags.Oath, Tags.Conjured },
            Synergies = new List<Synergies> { },
            ItemTag = "Conjured Oath",
            Durability = 5,
        };
        CardList.Add(card220);

        var card221 = new SpellData()
        {
            Id = 221,
            Name = "Oath of Retribution",
            ImageTag = CardImageTags.Oath_of_Retribution,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), new Resource(CardResources.Energy, 6), },

            Text = @"Equip an ""Oath of Retribution"" item. Destroy any other Oath items you have equipped",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Swiftstrike, Tags.Draw, Tags.Equip, Tags.Overwhelm, Tags.Oath },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Enchantment, Synergies.Draw, Synergies.BigSpells, Synergies.Retribution, Synergies.Angels, Synergies.Oaths },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card221);

        var card222 = new ItemData()
        {
            Id = 222,
            Name = "Oath of Retribution",
            ImageTag = CardImageTags.Oath_of_Retribution_Item,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 4), new Resource(CardResources.Energy, 6), },

            Text = @"When this is equipped and at the start of each turn your hero gains the following enchantments which end at the start of your next turn: <b>Overwhelm</b> and <b>Swiftstrike.</b> Whenever this unit attacks an enemy, temporarily increase their attack by the number of angels in your Graveyard. Whenever this unit attacks and kills an enemy, draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Swiftstrike, Tags.Draw, Tags.Overwhelm, Tags.Oath, Tags.Conjured },
            Synergies = new List<Synergies> { },
            ItemTag = "Conjured Oath",
            Durability = 3,
        };
        CardList.Add(card222);

        var card223 = new UnitData()
        {
            Id = 223,
            Name = "Ethelia, Chosen of the Light",
            ImageTag = CardImageTags.Ethelia_Chosen_of_the_Light,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 15), },

            Text = @"<b>Flying, Lifebond, Vanguard</b>
Costs (1) Devotion less for every Angel in your Graveyard.
<b>Deployment:</b> Deal damage to all adjacent enemy units equal to the number of Angels in your Graveyard",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Lifebond, Tags.Flying, Tags.Oathknight, Tags.Angel, Tags.Vanguard },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Deployment, Synergies.Swarm, Synergies.BigMinions, Synergies.Vanguard, Synergies.ShortRange, Synergies.Flying, Synergies.Retribution, Synergies.Angels },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Angel,
                UnitTags.Oathknight,
            },
            Attack = 6,
            Health = 8,
            Protected = 0,
            Range = 1,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Flying, Keywords.Lifebond, Keywords.Vanguard },
        };
        CardList.Add(card223);

        var card224 = new UnitData()
        {
            Id = 224,
            Name = "Lord Seldoras Kerhall",
            ImageTag = CardImageTags.Lord_Seldoras_Kerhall,

            Resources = new List<Resource>() { new Resource(CardResources.Devotion, 5), new Resource(CardResources.Energy, 3), },

            Text = @"<b>Conduit, Protected (6)</b>
Whenever your hero recieves an enchantment on your turn, this unit recieves it as well",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Protected, Tags.Conduit, Tags.Oathknight },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Durable, Synergies.Protected, Synergies.BigMinions, Synergies.Prayer, Synergies.Oaths },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Oathknight,
            },
            Attack = 5,
            Health = 5,
            Protected = 6,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card224);

        var card225 = new UnitData()
        {
            Id = 225,
            Name = "Trickster Shadow",
            ImageTag = CardImageTags.Trickster2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Trickster, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Trickster,
            },
            Attack = 8,
            Health = 20,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability56 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card225);

        var card226 = new UnitData()
        {
            Id = 226,
            Name = "Trickster Wraith",
            ImageTag = CardImageTags.Trickster3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Trickster, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Trickster,
            },
            Attack = 8,
            Health = 21,
            Protected = 0,
            Range = 1,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability57 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card226);

        var card227 = new UnitData()
        {
            Id = 227,
            Name = "Bounty Hunter",
            ImageTag = CardImageTags.Bounty_Hunter,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"<b>Vanguard, Stalker, Routing</b>
Whenever an enemy unit dies within Range 2, double their <b>Bounty</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.GoldGain, Tags.Vanguard, Tags.Rogue, Tags.Stalker, Tags.Bounty, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Removal, Synergies.Vanguard, Synergies.Death, Synergies.Gold, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Rogue,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Routing, Keywords.Stalker, Keywords.Vanguard },
        };
        CardList.Add(card227);

        var card228 = new UnitData()
        {
            Id = 228,
            Name = "Deathsworn Infiltrator",
            ImageTag = CardImageTags.Deathsworn_Infiltrator,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), new Resource(CardResources.Mana, 2), },

            Text = @"<b>Vanguard, Empowered +2, Piercing
Deployment:</b> Deal damage to an adjacent unit equal to your <b>Empowered</b> value",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Empowered, Tags.Deployment, Tags.SingleDamage, Tags.Trickster, Tags.Vanguard, Tags.Shadowborn, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Melee, Synergies.Deployment, Synergies.Vanguard, Synergies.Piercing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Shadowborn,
                UnitTags.Trickster,
            },
            Attack = 3,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 2,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Vanguard, Keywords.Piercing },
        };
        CardList.Add(card228);

        var card229 = new SpellData()
        {
            Id = 229,
            Name = "Flash",
            ImageTag = CardImageTags.Flash,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 2), },

            Text = @"Teleport the caster to an empty tile. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Mobility, Synergies.Draw, Synergies.Vanguard, Synergies.Escape },
            SpellType = "Other",
            Range = 3,
        };
        CardList.Add(card229);

        var card230 = new UnitData()
        {
            Id = 230,
            Name = "Shady Recruiter",
            ImageTag = CardImageTags.Shady_Recruiter,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 5), },

            Text = @"<b>Deployment:</b> Use <b>Hefty Bribe</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Rogue, Tags.Recruit },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.BigMinions, Synergies.Value, Synergies.Removal, Synergies.Gold, Synergies.Recruit },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Rogue,
            },
            Attack = 3,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability96 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card230);

        var card231 = new SpellData()
        {
            Id = 231,
            Name = "Street Tricks",
            ImageTag = CardImageTags.Street_Tricks,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 0), new Resource(CardResources.Mana, 3), },

            Text = @"Gain 2 Gold. Add 2 Shivs to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.GoldGain, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Value, Synergies.Gold, Synergies.Shivs, Synergies.Piercing },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card231);

        var card232 = new UnitData()
        {
            Id = 232,
            Name = "Underbelly Cutthroat",
            ImageTag = CardImageTags.Underbelly_Cutthroat,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), },

            Text = @"<b>Conduit, Routing
Deployment:</b> Add 2 Shivs to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Conduit, Tags.Deployment, Tags.SingleDamage, Tags.Rogue, Tags.Ratfolk, Tags.Routing, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Melee, Synergies.SmallSpells, Synergies.Deployment, Synergies.Value, Synergies.Shivs, Synergies.Routing, Synergies.Piercing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Ratfolk,
                UnitTags.Rogue,
            },
            Attack = 4,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Routing },
        };
        CardList.Add(card232);

        var card233 = new UnitData()
        {
            Id = 233,
            Name = "Deathsworn Assassin",
            ImageTag = CardImageTags.Deathsworn_Assassin,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), new Resource(CardResources.Mana, 2), },

            Text = @"<b>Deadly, Stalker, Stealth
Deployment:</b> Give an enemy unit an additional <b>Bounty</b> of 3 Gold",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Deployment, Tags.Trickster, Tags.GoldGain, Tags.Stalker, Tags.Bounty, Tags.Shadowborn, Tags.Deadly },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Deployment, Synergies.Removal, Synergies.Gold, Synergies.Shadows },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Shadowborn,
                UnitTags.Trickster,
            },
            Attack = 2,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Deadly, Keywords.Stalker, Keywords.Stealth },
        };
        CardList.Add(card233);

        var card234 = new SpellData()
        {
            Id = 234,
            Name = "Eliminate",
            ImageTag = CardImageTags.Eliminate,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), new Resource(CardResources.Mana, 4), },

            Text = @"Deal 8 damage to a unit. If this spell kills the unit, gain additional <b>Bounty</b> equal to any excess damage",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.GoldGain, Tags.Bounty },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SingleDamage, Synergies.Removal, Synergies.Gold },
            SpellType = "Damage",
            Range = 1,
        };
        CardList.Add(card234);

        var card235 = new SpellData()
        {
            Id = 235,
            Name = "Fade",
            ImageTag = CardImageTags.Fade,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 1), },

            Text = @"Redeploy the caster or return a friendly minion to your hand. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Redeploy },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Mobility, Synergies.Draw, Synergies.Deployment, Synergies.Vanguard, Synergies.Escape },
            SpellType = "Other",
            Range = 2,
        };
        CardList.Add(card235);

        var card236 = new SpellData()
        {
            Id = 236,
            Name = "Soul Blade",
            ImageTag = CardImageTags.Soul_Blade,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            Text = @"<b>Piercing
Spellbind</b> and deal 4 damage to a unit. If this kills it, draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.Spellbind },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Draw, Synergies.Antimagic },
            SpellType = "Damage",
            Range = 1,
        };
        CardList.Add(card236);

        var card237 = new UnitData()
        {
            Id = 237,
            Name = "Underbelly Runner",
            ImageTag = CardImageTags.Underbelly_Runner,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), },

            Text = @"<b>Stalker, Routing</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Draw, Tags.Rogue, Tags.Stalker, Tags.Ratfolk, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Draw, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Ratfolk,
                UnitTags.Rogue,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability97 },

            Keywords = new List<Keywords>() { Keywords.Routing, Keywords.Stalker },
        };
        CardList.Add(card237);

        var card238 = new SpellData()
        {
            Id = 238,
            Name = "Blade Flurry",
            ImageTag = CardImageTags.Blade_Flurry,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), },

            Text = @"<b>Discard</b> all shivs in your hand. Deal 1 damage to all other units within Range 1 of the caster for each shiv <b>Discarded</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.Discard },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Draw, Synergies.AreaDamage, Synergies.Defensive, Synergies.Shivs },
            SpellType = "Damage",
            Range = 0,
        };
        CardList.Add(card238);

        var card239 = new ItemData()
        {
            Id = 239,
            Name = "Enchanted Dagger",
            ImageTag = CardImageTags.Enchanted_Dagger,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), new Resource(CardResources.Mana, 2), },

            Text = @"Whenever your hero attacks, give them <b>Deadly</b> and <b>Piercing</b> for that attack",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Equip, Tags.Magic, Tags.Deadly, Tags.Dagger, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Equip, Synergies.Removal, Synergies.Piercing },
            ItemTag = "Magic Dagger",
            Durability = 4,
        };
        CardList.Add(card239);

        var card240 = new UnitData()
        {
            Id = 240,
            Name = "Shade Hunter",
            ImageTag = CardImageTags.Shade_Hunter,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 5), },

            Text = @"<b>Summon, Stealth, Ethereal, Piercing</b>
Whenever this attacks a unit, if the target has no adjacent allies, it takes double damage",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Ethereal, Tags.Stealth, Tags.Shadow, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Summon, Synergies.Ethereal, Synergies.Mana, Synergies.BigMinions, Synergies.Shadows, Synergies.Piercing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Shadow,
                UnitTags.Summon,
            },
            Attack = 4,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Ethereal, Keywords.Stealth, Keywords.Summon, Keywords.Piercing },
        };
        CardList.Add(card240);

        var card241 = new UnitData()
        {
            Id = 241,
            Name = "Underbelly Smuggler",
            ImageTag = CardImageTags.Underbelly_Smuggler,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), },

            Text = @"<b>Routing
Deployment:</b> Use <b>Smuggle</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Deployment, Tags.Rogue, Tags.Ratfolk, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Deployment, Synergies.Escape, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Ratfolk,
                UnitTags.Rogue,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability98 },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card241);

        var card242 = new UnitData()
        {
            Id = 242,
            Name = "Convincin' Thug",
            ImageTag = CardImageTags.Convincin_Thug,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), },

            Text = @"<b>Warden</b>
Whenever this attacks a unit, if it would kill it, <b>Recruit</b> it instead",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Warden, Tags.Recruit, Tags.Ogre, Tags.Brigand },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Defensive, Synergies.Value, Synergies.Removal, Synergies.Recruit },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Ogre,
                UnitTags.Brigand,
            },
            Attack = 4,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Warden },
        };
        CardList.Add(card242);

        var card243 = new UnitData()
        {
            Id = 243,
            Name = "Deathsworn Cursebringer",
            ImageTag = CardImageTags.Deathsworn_Cursebringer,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 5), new Resource(CardResources.Mana, 3), },

            Text = @"<b>Conduit</b>
After this unit kills an enemy, deploy a ""Cursed Shade"" in its place",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Conduit, Tags.Ethereal, Tags.Trickster, Tags.Stealth, Tags.Shadowborn, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Ethereal, Synergies.BigMinions, Synergies.Value, Synergies.Vanguard, Synergies.Gold, Synergies.Shadows, Synergies.Piercing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Shadowborn,
                UnitTags.Trickster,
            },
            Attack = 6,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card243);

        var card244 = new UnitData()
        {
            Id = 244,
            Name = "Cursed Shade",
            ImageTag = CardImageTags.Cursed_Shade,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            Text = @"<b>Ethereal, Stealth</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ethereal, Tags.Abomination, Tags.Stealth, Tags.Shadow },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Shadow,
                UnitTags.Abomination,
            },
            Attack = 4,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Ethereal, Keywords.Stealth },
        };
        CardList.Add(card244);

        var card245 = new UnitData()
        {
            Id = 245,
            Name = "Soulthief Shade",
            ImageTag = CardImageTags.Soulthief_Shade,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 8), },

            Text = @"<b>Ethereal, Summon, Stealth, Piercing</b>
After this attacks and kills a unit, <b>Regenerate</b> and gain <b>Stealth</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Ethereal, Tags.Regenerate, Tags.Stealth, Tags.Shadow, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Durable, Synergies.Summon, Synergies.Ethereal, Synergies.Mana, Synergies.BigMinions, Synergies.Shadows, Synergies.Piercing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Shadow,
                UnitTags.Summon,
            },
            Attack = 8,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Ethereal, Keywords.Stealth, Keywords.Summon },
        };
        CardList.Add(card245);

        var card246 = new UnitData()
        {
            Id = 246,
            Name = "King Toll of the Underbelly",
            ImageTag = CardImageTags.King_Toll_of_the_Underbelly,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 8), },

            Text = @"<b>Deployment: Recruit</b> 3 enemy minions within Range 5. Give them <b>Routing</b>
Whenever you <b>Recruit</b> a card, reduce its cost by 3 Gold, but not less than 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Rogue, Tags.Recruit, Tags.Ratfolk },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.BigMinions, Synergies.Value, Synergies.Removal, Synergies.Gold, Synergies.Recruit, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Ratfolk,
                UnitTags.Rogue,
            },
            Attack = 5,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card246);

        var card247 = new UnitData()
        {
            Id = 247,
            Name = "The Faceless One",
            ImageTag = CardImageTags.The_Faceless_One,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), new Resource(CardResources.Mana, 3), },

            Text = @"<b>Conduit, Vanguard, Stalker
Last Rites:</b> If killed by a minion, destroy it and return this unit to your hand with stats equal to the destroyed minion",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Conduit, Tags.LastRites, Tags.Vanguard, Tags.Stalker },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Durable, Synergies.Value, Synergies.Removal, Synergies.Vanguard, Synergies.Retribution },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Shadowborn,
                UnitTags.Trickster,
            },
            Attack = 4,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Stalker, Keywords.Vanguard },
        };
        CardList.Add(card247);

        var card248 = new SpellData()
        {
            Id = 248,
            Name = "Battle Inspiration",
            ImageTag = CardImageTags.Battle_Inspiration,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), },

            Text = @"<b>Cast When Drawn</b>
Increase your base Knowledge rate by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.StudyGain, Tags.CastWhenDrawn, Tags.Inspiration },
            Synergies = new List<Synergies> { },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card248);

        var card249 = new UnitData()
        {
            Id = 249,
            Name = "Battlefield Surveyor",
            ImageTag = CardImageTags.Battlefield_Surveyor,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            Text = @"<b>Deployment:</b> Use <b>Surveillance</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.StudyGain, Tags.Scout },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Draw, Synergies.Deployment, Synergies.Study },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Scout,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability72 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card249);

        var card250 = new SpellData()
        {
            Id = 250,
            Name = "Execute Plan",
            ImageTag = CardImageTags.Execute_Plan,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 0), new Resource(CardResources.Knowledge, 2), },

            Text = @"Gain 4 Energy until the end of your turn. Deploy a ""Man at Arms"" unit adjacent to the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.EnergyGain },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.SmallSpells, Synergies.Swarm, Synergies.Overwhelm },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card250);

        var card251 = new UnitData()
        {
            Id = 251,
            Name = "Man at Arms",
            ImageTag = CardImageTags.Man_at_Arms,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"<b>Overwhelm</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Overwhelm, Tags.Soldier },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Soldier,
            },
            Attack = 3,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Overwhelm },
        };
        CardList.Add(card251);

        var card252 = new UnitData()
        {
            Id = 252,
            Name = "Field Medic",
            ImageTag = CardImageTags.Field_Medic,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), new Resource(CardResources.Knowledge, 1), },

            Text = @"<b>Deployment</b> Gain either <b>Vanguard</b> or increase <b>Triage</b> healing by 2. Use <b>Triage</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Soldier, Tags.Vanguard, Tags.Choice },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.Vanguard, Synergies.Restoration, Synergies.Choices },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Soldier,
            },
            Attack = 1,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability73 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card252);

        var card253 = new UnitData()
        {
            Id = 253,
            Name = "Goldland Knight",
            ImageTag = CardImageTags.Goldland_Knight,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"<b>Prepared
Deployment:</b> Gain either <b>Overwhelm</b> or <b>Protected (3)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Protected, Tags.Prepared, Tags.Deployment, Tags.Overwhelm, Tags.Knight, Tags.Choice },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Melee, Synergies.Mobility, Synergies.Protected, Synergies.Swarm, Synergies.Prepared, Synergies.Overwhelm, Synergies.Choices },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Knight,
            },
            Attack = 3,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Prepared },
        };
        CardList.Add(card253);

        var card254 = new UnitData()
        {
            Id = 254,
            Name = "Legionnaire",
            ImageTag = CardImageTags.Legionnaire,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"<b>Warden
Deployment:</b> Gain either +2 Attack or +2 Health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Warden, Tags.Deployment, Tags.Soldier, Tags.Choice },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Melee, Synergies.Swarm, Synergies.Defensive, Synergies.Choices },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Soldier,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Warden },
        };
        CardList.Add(card254);

        var card255 = new SpellData()
        {
            Id = 255,
            Name = "Rally!",
            ImageTag = CardImageTags.Rally,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), },

            Text = @"Grant all friendly units in Range 2 of the caster +2 Attack, +2 Health or Deploy 2 ""Man at Arms"" units adjacent to the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Choice },
            Synergies = new List<Synergies> { Synergies.Swarm, Synergies.Overwhelm, Synergies.Choices },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card255);

        var card256 = new ItemData()
        {
            Id = 256,
            Name = "Aggressive Stance",
            ImageTag = CardImageTags.Aggressive_Stance,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"Whenever your hero attacks, gain +4 Attack until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Equip, Tags.Battle, Tags.Stance },
            Synergies = new List<Synergies> { },
            ItemTag = "Battle Stance",
            Durability = 2,
        };
        CardList.Add(card256);

        var card257 = new ItemData()
        {
            Id = 257,
            Name = "Defensive Stance",
            ImageTag = CardImageTags.Defensive_Stance,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            Text = @"Whenever your hero attacks, gain <b>Protected (4)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Protected, Tags.Equip, Tags.Battle, Tags.Stance },
            Synergies = new List<Synergies> { },
            ItemTag = "Battle Stance",
            Durability = 2,
        };
        CardList.Add(card257);

        var card258 = new ItemData()
        {
            Id = 258,
            Name = "Stable Stance",
            ImageTag = CardImageTags.Stable_Stance,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"Whenever your hero attacks, gain 1 Energy until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.EnergyGain, Tags.Equip, Tags.Battle, Tags.Stance },
            Synergies = new List<Synergies> { },
            ItemTag = "Battle Stance",
            Durability = 2,
        };
        CardList.Add(card258);

        var card259 = new SpellData()
        {
            Id = 259,
            Name = "Battle Stance",
            ImageTag = CardImageTags.Battle_Stance,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"Choose a form of ""Battle Stance"" to equip. Destroy any other ""Battle Stance"" item you have equipped. If this replaces a ""Battle Gear"" item you add its effect to the ""Battle Stance"" item and increase the Durability of the stance by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.EnergyGain, Tags.Protected, Tags.Equip, Tags.Choice },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.SmallSpells, Synergies.Durable, Synergies.Protected, Synergies.Equip, Synergies.Choices, Synergies.Swordsman },
            SpellType = "Equip",
            Range = 0,
        };
        CardList.Add(card259);

        var card260 = new UnitData()
        {
            Id = 260,
            Name = "Field Commander",
            ImageTag = CardImageTags.Field_Commander,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 4), },

            Text = @"<b>Conduit
Deployment: Study (4)</b>
Whenever this unit attacks and kills an enemy, draw an <b>Inspiration</b> card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Draw, Tags.Conduit, Tags.Deployment, Tags.StudyGain, Tags.Captain },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Draw, Synergies.Deployment, Synergies.Study },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Captain,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card260);

        var card261 = new SpellData()
        {
            Id = 261,
            Name = "Forward Planning",
            ImageTag = CardImageTags.Forward_Planning,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            Text = @"<b>Divinate (2)</b>
Reduce the cost of the the top two cards in your deck by (2)",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Divinate },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.BigSpells, Synergies.BigMinions, Synergies.Prediction },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card261);

        var card262 = new SpellData()
        {
            Id = 262,
            Name = "Perfect Strike",
            ImageTag = CardImageTags.Perfect_Strike,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"The caster attacks a target unit. If the target is killed, either draw a card or gain <b>Protected (5)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.Protected, Tags.Choice },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.SmallSpells, Synergies.Draw, Synergies.Durable, Synergies.Protected },
            SpellType = "Damage",
            Range = 1,
        };
        CardList.Add(card262);

        var card263 = new UnitData()
        {
            Id = 263,
            Name = "Scout Regiment",
            ImageTag = CardImageTags.Scout_Regiment,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Knowledge, 2), },

            Text = @"<b>Stalker</b>
Can target <b>Stealth</b> units
<b>Deployment:</b> Gain either +1 Range or +1 Speed",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Deployment, Tags.Divinate, Tags.Stalker, Tags.Choice },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Midrange, Synergies.Deployment, Synergies.Prediction, Synergies.Choices },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Scout,
            },
            Attack = 2,
            Health = 3,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1118 },

            Keywords = new List<Keywords>() { Keywords.Stalker },
        };
        CardList.Add(card263);

        var card264 = new SpellData()
        {
            Id = 264,
            Name = "Battle Repair",
            ImageTag = CardImageTags.Battle_Repair,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"Give an equipped item +2 Durability. If you do not have an item equipped, equip a ""Battle Gear"" item",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Equip },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Equip, Synergies.Swordsman },
            SpellType = "Other",
            Range = 0,
        };
        CardList.Add(card264);

        var card265 = new ItemData()
        {
            Id = 265,
            Name = "Commander's Logbook",
            ImageTag = CardImageTags.Commanders_Logbook,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            Text = @"Whenever your hero attacks and kills a unit, <b>Divinate (1)</b> and draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Equip, Tags.Divinate, Tags.Wartorn, Tags.Book },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Draw, Synergies.Prediction },
            ItemTag = "Wartorn Book",
            Durability = 3,
        };
        CardList.Add(card265);

        var card266 = new ItemData()
        {
            Id = 266,
            Name = "Hardened Shield",
            ImageTag = CardImageTags.Hardened_Shield,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), },

            Text = @"Whenever your hero is attacked, gain <b>Protected (4)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Protected, Tags.Equip, Tags.Metal, Tags.Shield },
            Synergies = new List<Synergies> { Synergies.Durable, Synergies.Defensive, Synergies.Equip },
            ItemTag = "Metal Shield",
            Durability = 4,
        };
        CardList.Add(card266);

        var card267 = new ItemData()
        {
            Id = 267,
            Name = "Rallying Flag",
            ImageTag = CardImageTags.Rallying_Flag,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 5), },

            Text = @"Tiles adjacent to your hero are part of your deployment zone. Whenever you deploy a unit there, lose 1 Durability",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Equip, Tags.Wartorn, Tags.Flag },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Equip, Synergies.Vanguard },
            ItemTag = "Wartorn Flag",
            Durability = 5,
        };
        CardList.Add(card267);

        var card268 = new UnitData()
        {
            Id = 268,
            Name = "Ballista",
            ImageTag = CardImageTags.Ballista,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Knowledge, 7), },

            Text = @"<b>Deployment:</b> Grant either +2 Attack, +1 Range or attacks hit enemy units adjacent to the target.
This unit can target through obstacle terrain",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Deployment, Tags.Choice, Tags.Siege, Tags.Construct },
            Synergies = new List<Synergies> { Synergies.AreaDamage, Synergies.Deployment, Synergies.BigMinions, Synergies.Study, Synergies.LongRange },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Siege,
                UnitTags.Construct,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 4,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card268);

        var card269 = new UnitData()
        {
            Id = 269,
            Name = "Captain of the Guard",
            ImageTag = CardImageTags.Captain_of_the_Guard,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 5), new Resource(CardResources.Knowledge, 4), },

            Text = @"<b>Warden, Protected (4)
Deployment:</b> Choose either to use <b>Confiscate</b> or <b>Imprison</b>
<b>Last Rites:</b> Return all removed cards and redeploy all removed units",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Protected, Tags.Warden, Tags.Deployment, Tags.Captain, Tags.Choice },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Melee, Synergies.Control, Synergies.Protected, Synergies.Deployment, Synergies.BigMinions, Synergies.Defensive, Synergies.Removal },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Captain,
            },
            Attack = 5,
            Health = 4,
            Protected = 4,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability74, ability75 },

            Keywords = new List<Keywords>() { Keywords.Warden },
        };
        CardList.Add(card269);

        var card270 = new SpellData()
        {
            Id = 270,
            Name = "Survey",
            ImageTag = CardImageTags.Survey,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 5), },

            Text = @"Choose an area of Radius 2. Draw a card for each enemy unit in the area. Your units ignore difficult terrain and <b>Warden</b> effects in the area until the start of your next turn. Remove <b>Stealth</b> from enemy units in the area",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.Warden, Tags.Stealth },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Draw, Synergies.BigSpells },
            SpellType = "Other",
            Range = 3,
        };
        CardList.Add(card270);

        var card271 = new UnitData()
        {
            Id = 271,
            Name = "Tessara, Lady of Goldland",
            ImageTag = CardImageTags.Tessara_Lady_of_Goldland,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 8), },

            Text = @"<b>Vanguard, Protected (3)
Deployment:</b> Use <b>Call to Arms</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Protected, Tags.Warden, Tags.Deployment, Tags.Noble, Tags.Vanguard, Tags.Choice },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Melee, Synergies.Mobility, Synergies.Protected, Synergies.Deployment, Synergies.Swarm, Synergies.BigMinions, Synergies.Defensive, Synergies.Vanguard, Synergies.Overwhelm, Synergies.Choices },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Noble,
            },
            Attack = 5,
            Health = 5,
            Protected = 3,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability76 },

            Keywords = new List<Keywords>() { Keywords.Vanguard },
        };
        CardList.Add(card271);

        var card272 = new UnitData()
        {
            Id = 272,
            Name = "Goldland Loyalist",
            ImageTag = CardImageTags.Goldland_Loyalist,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"<b>Warden</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Warden, Tags.Soldier },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Soldier,
            },
            Attack = 2,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Warden },
        };
        CardList.Add(card272);

        var card273 = new UnitData()
        {
            Id = 273,
            Name = "Supreme Commander Tythas",
            ImageTag = CardImageTags.Supreme_Commander_Tythas,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 5), new Resource(CardResources.Knowledge, 3), },

            Text = @"<b>Conduit, Prepared, Warden, Protected (5)</b>
Tiles adjacent to this unit are part of your deployment zone. The first time each turn you play a unit in these tiles, grant it either <b>Prepared</b> or <b>Protected (4)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Protected, Tags.Conduit, Tags.Warden, Tags.Prepared, Tags.Captain, Tags.Choice },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Melee, Synergies.Protected, Synergies.BigMinions, Synergies.Defensive, Synergies.Vanguard, Synergies.Prepared, Synergies.Choices },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Captain,
            },
            Attack = 4,
            Health = 4,
            Protected = 5,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Prepared, Keywords.Warden },
        };
        CardList.Add(card273);

        var card274 = new UnitData()
        {
            Id = 274,
            Name = "Luminist Starcaller",
            ImageTag = CardImageTags.Luminist2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Divinate, Tags.Luminist, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Luminist,
            },
            Attack = 3,
            Health = 22,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability40 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card274);

        var card275 = new UnitData()
        {
            Id = 275,
            Name = "Luminist Moonsinger",
            ImageTag = CardImageTags.Luminist3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Divinate, Tags.Luminist, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Luminist,
            },
            Attack = 4,
            Health = 28,
            Protected = 0,
            Range = 3,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability41 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card275);

        var card276 = new UnitData()
        {
            Id = 276,
            Name = "Mercenary Boss",
            ImageTag = CardImageTags.Mercenary2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Mercenary, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 6,
            Health = 22,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability43 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card276);

        var card277 = new UnitData()
        {
            Id = 277,
            Name = "Mercenary Warlord",
            ImageTag = CardImageTags.Mercenary3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Mercenary, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 8,
            Health = 28,
            Protected = 0,
            Range = 0,
            Speed = 5,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability44 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card277);

        var card279 = new UnitData()
        {
            Id = 279,
            Name = "Waystalker Ranger",
            ImageTag = CardImageTags.Waystalker2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Waystalker, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Waystalker,
            },
            Attack = 4,
            Health = 16,
            Protected = 0,
            Range = 3,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability59 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card279);

        var card280 = new UnitData()
        {
            Id = 280,
            Name = "Waystalker Wildwalker",
            ImageTag = CardImageTags.Waystalker3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Waystalker, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Waystalker,
            },
            Attack = 5,
            Health = 20,
            Protected = 0,
            Range = 4,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability60 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card280);

        var card281 = new UnitData()
        {
            Id = 281,
            Name = "Wildkin Shapechanger",
            ImageTag = CardImageTags.Wildkin2,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Wildkin, Tags.HeroTierOne },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Wildkin,
            },
            Attack = 3,
            Health = 27,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability62 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card281);

        var card282 = new UnitData()
        {
            Id = 282,
            Name = "Wildkin Berserker",
            ImageTag = CardImageTags.Wildkin3,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Wildkin, Tags.HeroTierTwo },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Wildkin,
            },
            Attack = 4,
            Health = 34,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability63 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card282);

        var card285 = new UnitData()
        {
            Id = 285,
            Name = "Tough Hireling",
            ImageTag = CardImageTags.Tough_Hireling,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"<b>Warden</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Warden, Tags.Mercenary, Tags.Hireling },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Warden },
        };
        CardList.Add(card285);

        var card286 = new UnitData()
        {
            Id = 286,
            Name = "Persuasive Hireling",
            ImageTag = CardImageTags.Persuasive_Hireling,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"Whenever this attacks, gain Gold equal to attack",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Mercenary, Tags.GoldGain, Tags.Hireling },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card286);

        var card287 = new UnitData()
        {
            Id = 287,
            Name = "Shady Hireling",
            ImageTag = CardImageTags.Shady_Hireling,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"<b>Stealth</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Mercenary, Tags.Stealth, Tags.Hireling },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Stealth },
        };
        CardList.Add(card287);

        var card288 = new UnitData()
        {
            Id = 288,
            Name = "Eager Hireling",
            ImageTag = CardImageTags.Eager_Hireling,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"<b>Prepared</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Prepared, Tags.Mercenary, Tags.Hireling },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Prepared },
        };
        CardList.Add(card288);

        var card289 = new SpellData()
        {
            Id = 289,
            Name = "Furious Brawl",
            ImageTag = CardImageTags.Furious_Brawl,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 0), },

            Text = @"Add a random Brawl card to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.SmallSpells, Synergies.Mobility, Synergies.Value, Synergies.Discard, Synergies.Brawler },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card289);

        var card290 = new SpellData()
        {
            Id = 290,
            Name = "Brawl: Grab",
            ImageTag = CardImageTags.Brawl_Grab,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"Choose an enemy unit in range. Move it in a line to a tile adjacent to the the caster, then attack it.
If this spell kills an enemy unit, add a random Brawl card to your hand. <b>Discard</b> this card at the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Discard, Tags.Brawl },
            Synergies = new List<Synergies> { },
            SpellType = "Other",
            Range = 2,
        };
        CardList.Add(card290);

        var card291 = new SpellData()
        {
            Id = 291,
            Name = "Brawl: Leap",
            ImageTag = CardImageTags.Brawl_Leap,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"Jump to an empty tile in range. Deal 2 damage to all adjacent units and the caster.
If this spell kills an enemy unit, add a random Brawl card to your hand. <b>Discard</b> this card at the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Discard, Tags.Brawl },
            Synergies = new List<Synergies> { },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card291);

        var card292 = new SpellData()
        {
            Id = 292,
            Name = "Brawl: Shove",
            ImageTag = CardImageTags.Brawl_Shove,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"Deal 3 damage to a unit and move it up to 1 tile away from the caster. If it impacts an obstacle, deal an additional 3 damage.
If this spell kills an enemy unit, add a random Brawl card to your hand. <b>Discard</b> this card at the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Discard, Tags.Brawl },
            Synergies = new List<Synergies> { },
            SpellType = "Other",
            Range = 1,
        };
        CardList.Add(card292);

        var card293 = new SpellData()
        {
            Id = 293,
            Name = "Brawl: Toss",
            ImageTag = CardImageTags.Brawl_Toss,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"Choose a friendly unit. Throw it to an empty tile within range 3. It attacks a random adjacent unit. 
If this spell kills an enemy unit, add a random different Brawl card to your hand. <b>Discard</b> this card at the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Deleted,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Discard, Tags.Brawl },
            Synergies = new List<Synergies> { },
            SpellType = "Damage",
            Range = 1,
        };
        CardList.Add(card293);

        var card294 = new SpellData()
        {
            Id = 294,
            Name = "Brawl: Whirlwind",
            ImageTag = CardImageTags.Brawl_Whirlwind,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"Deal 2 damage to all units adjacent to your hero. Heal the caster for the amount of damage dealt.
If this spell kills an enemy unit, add a random Brawl card to your hand. <b>Discard</b> this card at the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Discard, Tags.Brawl },
            Synergies = new List<Synergies> { },
            SpellType = "Damage",
            Range = 0,
        };
        CardList.Add(card294);

        var card295 = new UnitData()
        {
            Id = 295,
            Name = "Greywalker",
            ImageTag = CardImageTags.Greywalker,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 4), },

            Text = @"<b>Stalker</b>
Whenever this unit takes damage, <b>Cycle</b> for the same amount",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.CyclePlus, Tags.Wildkin, Tags.Stalker },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Cycle },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Wildkin,
            },
            Attack = 2,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Stalker },
        };
        CardList.Add(card295);

        var card296 = new UnitData()
        {
            Id = 296,
            Name = "Othtaal Axeman",
            ImageTag = CardImageTags.Othtal_Axeman,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"<b>Overwhelm, Swiftstrike</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Swiftstrike, Tags.Overwhelm, Tags.Orc, Tags.Barbarian },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Melee, Synergies.Swarm },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Orc,
                UnitTags.Barbarian,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Overwhelm, Keywords.Swiftstrike },
        };
        CardList.Add(card296);

        var card297 = new UnitData()
        {
            Id = 297,
            Name = "Othtaal Berserker",
            ImageTag = CardImageTags.Othtal_Berserker,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 5), },

            Text = @"<b>Overwhelm</b>
Whenever this unit takes damage, gain +2 Attack",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Overwhelm, Tags.Orc, Tags.Barbarian },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Melee, Synergies.BigMinions, Synergies.Restoration, Synergies.SelfDamage },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Orc,
                UnitTags.Barbarian,
            },
            Attack = 3,
            Health = 7,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Overwhelm },
        };
        CardList.Add(card297);

        var card298 = new ItemData()
        {
            Id = 298,
            Name = "Spirit Totem",
            ImageTag = CardImageTags.Spirit_Totem,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            Text = @"After your hero takes damage on your turn, restore 4 health to them",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Common,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Natural, Tags.Talisman },
            Synergies = new List<Synergies> { Synergies.Durable, Synergies.Equip, Synergies.Restoration, Synergies.SelfDamage },
            ItemTag = "Natural Talisman",
            Durability = 4,
        };
        CardList.Add(card298);

        var card299 = new SpellData()
        {
            Id = 299,
            Name = "Wild Fury",
            ImageTag = CardImageTags.Wild_Fury,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 0), new Resource(CardResources.Wild, 2), },

            Text = @"Gain 4 Energy and give the caster +2 Speed until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.EnergyGain },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.SmallSpells, Synergies.Mobility, Synergies.Brawler },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card299);

        var card300 = new SpellData()
        {
            Id = 300,
            Name = "Blood Bond",
            ImageTag = CardImageTags.Blood_Bond,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"Choose a friendly unit. Deal 1 damage to it and the caster. While both the target and the caster are alive, they both have +3 Attack and you gain 1 additional Energy at the start of each turn. If the caster casts this spell again, remove any previous Blood Bond effects they have cast",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.EnergyGain },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Enchantment, Synergies.Control, Synergies.Durable, Synergies.SelfDamage },
            SpellType = "Other",
            Range = 2,
        };
        CardList.Add(card300);

        var card301 = new UnitData()
        {
            Id = 301,
            Name = "Grey Shaman",
            ImageTag = CardImageTags.Grey_Shaman,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 6), },

            Text = @"<b>Conduit</b>
Whenever this unit takes damage, heal your hero for the same amount.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Conduit, Tags.Regenerate, Tags.CycleMinus, Tags.Wildkin },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Durable, Synergies.BigMinions, Synergies.Restoration, Synergies.SelfDamage, Synergies.Cycle, Synergies.Wild },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Wildkin,
            },
            Attack = 4,
            Health = 7,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability100 },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card301);

        var card302 = new SpellData()
        {
            Id = 302,
            Name = "Rampage",
            ImageTag = CardImageTags.Rampage,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 5), },

            Text = @"The caster melee attacks all adjacent units in a random order. If the caster kills a unit, restore 3 health to the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.BigSpells, Synergies.Restoration, Synergies.SelfDamage, Synergies.Brawler },
            SpellType = "Other",
            Range = 0,
        };
        CardList.Add(card302);

        var card303 = new ItemData()
        {
            Id = 303,
            Name = "Serrated Claws",
            ImageTag = CardImageTags.Serrated_Claws,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"Whenever your hero attacks and damages a unit, prevent it from being healed until the start of your next turn. Your hero has <b>Swiftstrike</b> and <b>Piercing</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Swiftstrike },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Equip, Synergies.Brawler },
            ItemTag = "Natural Augment",
            Durability = 4,
        };
        CardList.Add(card303);

        var card304 = new UnitData()
        {
            Id = 304,
            Name = "Shapechanger",
            ImageTag = CardImageTags.Shapechanger,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 4), },

            Text = @"Reduce the <b>Cycle</b> and Wild cost of ""Shapechange"" by this units missing health.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Warden, Tags.CycleMinus, Tags.Wildkin, Tags.Transform },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Durable, Synergies.Cycle, Synergies.Brawler, Synergies.Shapeshifters },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Wildkin,
            },
            Attack = 4,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability101 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card304);

        var card305 = new UnitData()
        {
            Id = 305,
            Name = "Hulking Beast",
            ImageTag = CardImageTags.Hulking_Beast,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 5), },

            Text = @"<b>Warden
Last Rites: Transform</b> this unit back to its original form",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Warden, Tags.Transformed, Tags.Beast, Tags.LastRites, Tags.Transform },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Transformed,
                UnitTags.Beast,
            },
            Attack = 6,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Warden },
        };
        CardList.Add(card305);

        var card306 = new UnitData()
        {
            Id = 306,
            Name = "Bear Aspect",
            ImageTag = CardImageTags.Bear_Aspect,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Warden, Hero</b>
Whenever this attacks and kills a unit, <b>Regenerate.</b> Any healing applied to this unit also applies to the original form of your hero.
<b>Last Rites: Transform</b> this unit back into your hero",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Ability, Tags.Stun, Tags.Warden, Tags.Transformed, Tags.Beast, Tags.LastRites, Tags.Regenerate, Tags.Transform },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Transformed,
                UnitTags.Beast,
            },
            Attack = 4,
            Health = 10,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability102 },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Warden },
        };
        CardList.Add(card306);

        var card307 = new SpellData()
        {
            Id = 307,
            Name = "Aspect of the Bear",
            ImageTag = CardImageTags.Aspect_of_the_Bear,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Transform</b> your hero into a ""Bear Aspect"" if they are not already <b>Transformed</b>. This unit is considered your hero until it returns to its original form. <b>Cycle -4</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Ability, Tags.Stun, Tags.Warden, Tags.LastRites, Tags.Regenerate, Tags.CycleMinus, Tags.Transform, Tags.Aspect },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Stun, Synergies.Control, Synergies.Durable, Synergies.BigSpells, Synergies.Defensive, Synergies.Restoration, Synergies.Cycle, Synergies.Wild, Synergies.Shapeshifters, Synergies.Aspects },
            SpellType = "Other",
            Range = 0,
        };
        CardList.Add(card307);

        var card308 = new UnitData()
        {
            Id = 308,
            Name = "Eagle Aspect",
            ImageTag = CardImageTags.Eagle_Aspect,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Flying, Hero</b>
Whenever this unit takes damage, gain +2 Attack.
<b>Last Rites: Transform</b> this unit back into your hero",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Ability, Tags.Transformed, Tags.Beast, Tags.LastRites, Tags.Flying },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Transformed,
                UnitTags.Beast,
            },
            Attack = 5,
            Health = 8,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability103 },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Flying },
        };
        CardList.Add(card308);

        var card309 = new SpellData()
        {
            Id = 309,
            Name = "Aspect of the Eagle",
            ImageTag = CardImageTags.Aspect_of_the_Eagle,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Transform</b> your hero into an ""Eagle Aspect"" if they are not already <b>Transformed</b>. This unit is considered your hero until it returns to its original form. <b>Cycle -4</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Ability, Tags.LastRites, Tags.Flying, Tags.CycleMinus, Tags.Transform, Tags.Aspect },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Durable, Synergies.BigSpells, Synergies.SelfDamage, Synergies.Flying, Synergies.Cycle, Synergies.Wild, Synergies.Pacify, Synergies.Shapeshifters, Synergies.Aspects },
            SpellType = "Other",
            Range = 0,
        };
        CardList.Add(card309);

        var card310 = new UnitData()
        {
            Id = 310,
            Name = "Sabretooth Aspect",
            ImageTag = CardImageTags.Sabretooth_Aspect,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Overwhelm, Hero</b>
Whenever this attacks and kills a unit, draw a card.
<b>Last Rites: Transform</b> this unit back into your hero.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Draw, Tags.Overwhelm, Tags.Transformed, Tags.Beast, Tags.LastRites },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Transformed,
                UnitTags.Beast,
            },
            Attack = 9,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability104 },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Overwhelm },
        };
        CardList.Add(card310);

        var card311 = new SpellData()
        {
            Id = 311,
            Name = "Aspect of the Sabretooth",
            ImageTag = CardImageTags.Aspect_of_the_Sabretooth,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Transform</b> your hero into a ""Sabretooth Aspect"" if they are not already <b>Transformed</b>. This unit is considered your hero until it returns to its original form. <b>Cycle -4</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Ability, Tags.Draw, Tags.Overwhelm, Tags.LastRites, Tags.CycleMinus, Tags.Transform, Tags.Aspect },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Melee, Synergies.Mobility, Synergies.Draw, Synergies.Durable, Synergies.BigSpells, Synergies.Cycle, Synergies.Wild, Synergies.Brawler, Synergies.Shapeshifters },
            SpellType = "Other",
            Range = 0,
        };
        CardList.Add(card311);

        var card312 = new UnitData()
        {
            Id = 312,
            Name = "Wolf Aspect",
            ImageTag = CardImageTags.Wolf_Aspect,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Stalker, Hero</b>
Other friendly units within Range 2 have extra attack equal to attack gained from <b>Unleash.
Last Rites: Transform</b> this unit back into your hero.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Transformed, Tags.Beast, Tags.LastRites, Tags.Unleash, Tags.Stalker },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Transformed,
                UnitTags.Beast,
            },
            Attack = 6,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability105 },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Stalker },
        };
        CardList.Add(card312);

        var card313 = new SpellData()
        {
            Id = 313,
            Name = "Aspect of the Wolf",
            ImageTag = CardImageTags.Aspect_of_the_Wolf,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Transform</b> your hero into a ""Wolf Aspect"" if they are not already <b>Transformed</b>. This unit is considred your hero until it returns to its original form. <b>Cycle -4</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Ability, Tags.LastRites, Tags.CycleMinus, Tags.Unleash, Tags.Stalker, Tags.Transform, Tags.Aspect },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Melee, Synergies.Mobility, Synergies.Durable, Synergies.BigSpells, Synergies.Swarm, Synergies.Cycle, Synergies.Wild, Synergies.Shapeshifters },
            SpellType = "Other",
            Range = 0,
        };
        CardList.Add(card313);

        var card314 = new UnitData()
        {
            Id = 314,
            Name = "Raging Beast",
            ImageTag = CardImageTags.Raging_Beast,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), new Resource(CardResources.Wild, 3), },

            Text = @"<b>Unleash
Last Rites: Transform</b> back into this unit's original form. Any enchantments gained from <b>Unleash</b> apply to this and the original form",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Transformed, Tags.Beast, Tags.LastRites, Tags.Unleash, Tags.Transform },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Transformed,
                UnitTags.Beast,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Unleash },
        };
        CardList.Add(card314);

        var card315 = new SpellData()
        {
            Id = 315,
            Name = "Beastial Fury",
            ImageTag = CardImageTags.Beastial_Fury,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), new Resource(CardResources.Wild, 3), },

            Text = @"<b>Transform</b> a friendly minion that is not already <b>Transformed</b> into a ""Raging Beast""",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.LastRites, Tags.Unleash, Tags.Transform },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Melee, Synergies.Durable, Synergies.Shapeshifters },
            SpellType = "Other",
            Range = 2,
        };
        CardList.Add(card315);

        var card316 = new SpellData()
        {
            Id = 316,
            Name = "Cold Fury",
            ImageTag = CardImageTags.Cold_Fury,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 7), },

            Text = @"<b>Stun</b> all adjacent enemy units. Give the caster <b>Unleash</b> until the end of your turn. If the caster attacks and kills one of the <b>Stunned</b> units, deal damage to all other <b>Stunned</b> units equal to the excess damage",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.Unleash },
            Synergies = new List<Synergies> { Synergies.Stun, Synergies.Control, Synergies.Durable, Synergies.SelfDamage, Synergies.Brawler },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card316);

        var card317 = new UnitData()
        {
            Id = 317,
            Name = "Othtaal Undying",
            ImageTag = CardImageTags.Othtal_Undying,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 8), },

            Text = @"<b>Prepared, Swiftstrike
Last Rites:</b> Restore this unit to one health and refresh its actions. It cannot drop below one health until the end of your turn, at which point, it dies",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Swiftstrike, Tags.Prepared, Tags.LastRites, Tags.Orc, Tags.Barbarian },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Melee, Synergies.Durable, Synergies.BigMinions, Synergies.Prepared, Synergies.Brawler },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Orc,
                UnitTags.Barbarian,
            },
            Attack = 6,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Prepared, Keywords.Swiftstrike },
        };
        CardList.Add(card317);

        var card318 = new UnitData()
        {
            Id = 318,
            Name = "The Great Spirit",
            ImageTag = CardImageTags.The_Great_Spirit,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 6), new Resource(CardResources.Wild, 8), },

            Text = @"<b>Unleash, Ethereal
Last Rites: Transform</b> back into its original form. Any enchantments gained from <b>Unleash</b> apply to the original form",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ethereal, Tags.Transformed, Tags.LastRites, Tags.Spirit, Tags.Unleash, Tags.Transform },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Transformed,
                UnitTags.Spirit,
            },
            Attack = 8,
            Health = 8,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Ethereal, Keywords.Unleash },
        };
        CardList.Add(card318);

        var card319 = new UnitData()
        {
            Id = 319,
            Name = "Spirit Walker Bragas",
            ImageTag = CardImageTags.Spirit_Walker_Bragas,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 6), new Resource(CardResources.Wild, 8), },

            Text = @"<b>Conduit, Unleash
Last Rites:</b> If this unit has attacked and killed a unit, <b>Transform</b> into ""The Great Spirit"". Any enchantments gained from <b>Unleash</b> apply to the new form.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Conduit, Tags.LastRites, Tags.Regenerate, Tags.CycleMinus, Tags.Wildkin, Tags.Unleash, Tags.Transform },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Melee, Synergies.Durable, Synergies.Ethereal, Synergies.BigMinions, Synergies.Cycle, Synergies.Wild, Synergies.Brawler, Synergies.Shapeshifters },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Wildkin,
            },
            Attack = 5,
            Health = 9,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability106 },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Unleash },
        };
        CardList.Add(card319);

        var card320 = new UnitData()
        {
            Id = 320,
            Name = "Warchief Aghazir",
            ImageTag = CardImageTags.Warchief_Aghazir,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 5), },

            Text = @"<b>Swiftstrike, Conduit, Warden</b>
Whenever a friendly unit within Range 2 takes damage, gain +2 Attack.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Swiftstrike, Tags.Conduit, Tags.Warden, Tags.Orc, Tags.Barbarian },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Melee, Synergies.BigMinions, Synergies.Defensive, Synergies.Value, Synergies.SelfDamage, Synergies.Brawler },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Orc,
                UnitTags.Barbarian,
            },
            Attack = 4,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability107 },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Swiftstrike, Keywords.Warden },
        };
        CardList.Add(card320);

        var card321 = new SpellData()
        {
            Id = 321,
            Name = "Ray of Consumption",
            ImageTag = CardImageTags.Ray_of_Consumption,

            Resources = new List<Resource>() { new Resource(CardResources.Mana, 3), },

            Text = @"<b>Discard</b> a card to deal damage to a unit equal to the card's total cost. If this spell kills a unit, return a random card in your <b>Discard</b> pool to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.Discard },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Control, Synergies.Value, Synergies.SingleDamage, Synergies.Discard },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card321);

        var card322 = new UnitData()
        {
            Id = 322,
            Name = "Camp Cook",
            ImageTag = CardImageTags.Camp_Cook,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"<b>Routing
Deployment:</b> Use <b>Feast</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Deployment, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.Swarm, Synergies.Restoration, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 2,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability108 },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card322);

        var card323 = new ItemData()
        {
            Id = 323,
            Name = "Deceptive Contract",
            ImageTag = CardImageTags.Deceptive_Contract,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 1), new Resource(CardResources.Gold, 3), },

            Text = @"Whenever you deploy a Hireling, add a copy of it to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Common,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Wartorn, Tags.Scroll },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Value, Synergies.Equip, Synergies.Hireling },
            ItemTag = "Wartorn Scroll",
            Durability = 3,
        };
        CardList.Add(card323);

        var card324 = new UnitData()
        {
            Id = 324,
            Name = "Goblin Looter",
            ImageTag = CardImageTags.Goblin_Looter,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"<b>Routing</b>
Whenever this attacks a unit, draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Draw, Tags.Goblin, Tags.Brigand, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Draw, Synergies.Swarm, Synergies.Goblin, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Goblin,
                UnitTags.Brigand,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card324);

        var card325 = new UnitData()
        {
            Id = 325,
            Name = "Opportunistic Warband",
            ImageTag = CardImageTags.Opportunistic_Warband,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), },

            Text = @"<b>Routing, Vanguard</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Mercenary, Tags.Vanguard, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Swarm, Synergies.Vanguard, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 4,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Routing, Keywords.Vanguard },
        };
        CardList.Add(card325);

        var card326 = new SpellData()
        {
            Id = 326,
            Name = "Persuasive Techniques",
            ImageTag = CardImageTags.Persuasive_Techniques,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), new Resource(CardResources.Gold, 0), },

            Text = @"Gain 3 Gold. Choose a Hireling to deploy adjacent to the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.GoldGain },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.SmallSpells, Synergies.Swarm, Synergies.Gold, Synergies.Hireling },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card326);

        var card327 = new SpellData()
        {
            Id = 327,
            Name = "Sucker Punch",
            ImageTag = CardImageTags.Sucker_Punch,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), },

            Text = @"<b>Stun</b> a unit and push it in a line 1 tile away from the caster. If it impacts an obstacle, attack it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.ForceMove },
            Synergies = new List<Synergies> { Synergies.Stun, Synergies.Control, Synergies.ForceMove, Synergies.Brawler },
            SpellType = "Enchantment, Other",
            Range = 1,
        };
        CardList.Add(card327);

        var card328 = new UnitData()
        {
            Id = 328,
            Name = "Camp Follower",
            ImageTag = CardImageTags.Camp_Follower,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"<b>Routing
Deployment:</b> Use <b>Seduce</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Mercenary, Tags.Recruit, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Deployment, Synergies.Removal, Synergies.Restoration, Synergies.Recruit, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability109 },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card328);

        var card329 = new SpellData()
        {
            Id = 329,
            Name = "CHARGE!",
            ImageTag = CardImageTags.Charge,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), },

            Text = @"Give all adjacent friendly melee units +2 Attack and <b>Prepared</b> until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Prepared },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Swarm, Synergies.Vanguard, Synergies.Prepared },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card329);

        var card330 = new SpellData()
        {
            Id = 330,
            Name = "Intimidate",
            ImageTag = CardImageTags.Intimidate,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 4), new Resource(CardResources.Gold, 2), },

            Text = @"<b>Stun</b> a unit. Gain Gold equal to its remaining health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.GoldGain },
            Synergies = new List<Synergies> { Synergies.Stun, Synergies.Control, Synergies.Gold },
            SpellType = "Enchantment, Resource",
            Range = 1,
        };
        CardList.Add(card330);

        var card331 = new UnitData()
        {
            Id = 331,
            Name = "Mounted Raiders",
            ImageTag = CardImageTags.Mounted_Raiders,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 5), },

            Text = @"<b>Routing, Prepared</b>
Whenever this attacks and kills a unit, double their <b>Bounty</b> and draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Draw, Tags.Prepared, Tags.GoldGain, Tags.Brigand, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Draw, Synergies.BigMinions, Synergies.Prepared, Synergies.Gold, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Brigand,
            },
            Attack = 6,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Prepared, Keywords.Routing },
        };
        CardList.Add(card331);

        var card332 = new UnitData()
        {
            Id = 332,
            Name = "Goblin Horde",
            ImageTag = CardImageTags.Goblin_Horde,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), },

            Text = @"",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Goblin, Tags.Brigand },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Goblin,
                UnitTags.Brigand,
            },
            Attack = 1,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card332);

        var card333 = new SpellData()
        {
            Id = 333,
            Name = "The Green Horde",
            ImageTag = CardImageTags.The_Green_Horde,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), },

            Text = @"Deploy 4 Goblin Horde units adjacent to the caster. This spell can be cast by any Goblin Warlord units",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Swarm, Synergies.Vanguard, Synergies.Goblin },
            SpellType = "Deployment",
            Range = 0,
        };
        CardList.Add(card333);

        var card334 = new UnitData()
        {
            Id = 334,
            Name = "Combat Insurer",
            ImageTag = CardImageTags.Combat_Insurer,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 5), },

            Text = @"After a friendly unit <b>Routs</b>, gain 3 Gold and draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Draw, Tags.Mercenary, Tags.GoldGain },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.BigMinions, Synergies.Value, Synergies.Gold, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 3,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card334);

        var card335 = new UnitData()
        {
            Id = 335,
            Name = "Disgraced Veteran",
            ImageTag = CardImageTags.Disgraced_Veteran,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 6), },

            Text = @"<b>Deployment:</b> Use <b>Secret Techniques</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Mercenary },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.SmallSpells, Synergies.BigSpells, Synergies.Deployment, Synergies.BigMinions, Synergies.Value },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 5,
            Health = 7,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability110 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card335);

        var card336 = new SpellData()
        {
            Id = 336,
            Name = "Pin",
            ImageTag = CardImageTags.Pin,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), },

            Text = @"<b>Root</b> a unit and prevent it from attacking or using abilities on any unit other than the caster until the end of their next turn or until the caster moves",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Root },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Durable, Synergies.Brawler },
            SpellType = "Enchantment",
            Range = 1,
        };
        CardList.Add(card336);

        var card337 = new SpellData()
        {
            Id = 337,
            Name = "Motivate Rifraf",
            ImageTag = CardImageTags.Motivate_Rifraf,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 2), new Resource(CardResources.Gold, 2), },

            Text = @"Give a friendly Hireling +4 Attack, +4 Health and <b>Routing</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.SmallSpells, Synergies.Durable, Synergies.Routing, Synergies.Hireling },
            SpellType = "Enchantment",
            Range = 2,
        };
        CardList.Add(card337);

        var card338 = new SpellData()
        {
            Id = 338,
            Name = "Gather Forces",
            ImageTag = CardImageTags.Gather_Forces,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), new Resource(CardResources.Gold, 5), },

            Text = @"Deploy two random Hirelings beside the caster. Gain the <b>Passive:</b> ""Your Hirelings have +1 Attack and +1 Health for the rest of the scenario""",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Passive },
            Synergies = new List<Synergies> { Synergies.Durable, Synergies.Swarm, Synergies.Hireling },
            SpellType = "Deployment",
            Range = 0,
        };
        CardList.Add(card338);

        var card339 = new UnitData()
        {
            Id = 339,
            Name = "Goblin Boss",
            ImageTag = CardImageTags.Goblin_Boss,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), },

            Text = @"<b>Routing
Deployment:</b> Deploy two Goblin Hordes beside this unit.
Whenever this unit is attacked, gain <b>Protected</b> equal to the number of adjacent friendly Goblins.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Protected, Tags.Deployment, Tags.Goblin, Tags.Routing, Tags.Warlord },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Protected, Synergies.Deployment, Synergies.Swarm, Synergies.Defensive, Synergies.Goblin, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Goblin,
                UnitTags.Warlord,
            },
            Attack = 3,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability111 },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card339);

        var card340 = new ItemData()
        {
            Id = 340,
            Name = "Headhunter's Axe",
            ImageTag = CardImageTags.Headhunters_Axe,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 6), },

            Text = @"Your hero has <b>Overwhelm</b>. Whenever your hero attacks, they also attack another random adjacent enemy unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Overwhelm, Tags.Metal, Tags.Axe },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Equip, Synergies.Brawler },
            ItemTag = "Metal Axe",
            Durability = 3,
        };
        CardList.Add(card340);

        var card1322 = new UnitData()
        {
            Id = 1322,
            Name = "Head Gobbo Mazgix",
            ImageTag = CardImageTags.Head_Gobbo_Mazgix,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 6), },

            Text = @"<b>Routing
Deployment:</b> Use <b>Rally the Horde</b>
Your other goblins within Range 3 have <b>Prepared</b> and +2 Attack.
Whenever this unit is attacked, gain <b>Protected</b> equal to the number of adjacent friendly Goblins.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Protected, Tags.Deployment, Tags.Goblin, Tags.Routing, Tags.Warlord },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Protected, Synergies.Swarm, Synergies.Defensive, Synergies.Prepared, Synergies.Goblin, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Goblin,
                UnitTags.Warlord,
            },
            Attack = 5,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1108 },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card1322);

        var card1323 = new UnitData()
        {
            Id = 1323,
            Name = "Ragged Lord Allos",
            ImageTag = CardImageTags.Ragged_Lord_Allos,

            Resources = new List<Resource>() { new Resource(CardResources.Energy, 3), new Resource(CardResources.Gold, 4), },

            Text = @"<b>Deployment:</b> Add one of each type of Hireling to your hand.
You can deploy Hirelings adjacent to this unit, including from abilities or spells.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Mercenary },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.Value, Synergies.Vanguard, Synergies.Hireling },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Mercenary,
            },
            Attack = 5,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1109 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1323);

        var card1326 = new UnitData()
        {
            Id = 1326,
            Name = "Test NPC Hero",
            ImageTag = CardImageTags.Test_NPC_Hero,

            Resources = new List<Resource>() { },

            Text = @"",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Test,
            },
            Attack = 1,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 1,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1326);

        var card1327 = new SpellData()
        {
            Id = 1327,
            Name = "Luminous Inspiration",
            ImageTag = CardImageTags.Luminous_Inspiration,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), },

            Text = @"<b>Cast When Drawn</b>
Increase your base Knowledge rate by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.StudyGain, Tags.CastWhenDrawn, Tags.Inspiration },
            Synergies = new List<Synergies> { },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1327);

        var card1328 = new UnitData()
        {
            Id = 1328,
            Name = "Fortune Teller",
            ImageTag = CardImageTags.Fortune_Teller,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            Text = @"<b>Deployment</b> Use <b>Glimpse</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Luminist },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Deployment, Synergies.Prediction },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Luminist,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1110 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1328);

        var card1329 = new SpellData()
        {
            Id = 1329,
            Name = "Moonbeam",
            ImageTag = CardImageTags.Moonbeam,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 1), },

            Text = @"Deal 2 damage to a unit. This can target units which are blocked by cover",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.SingleDamage },
            SpellType = "Damage",
            Range = 4,
        };
        CardList.Add(card1329);

        var card1330 = new SpellData()
        {
            Id = 1330,
            Name = "Moonpool Walk",
            ImageTag = CardImageTags.Moonpool_Walk,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            Text = @"<b>Cycle +3</b>
Give the caster <b>Protected (3)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Protected, Tags.CyclePlus },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.SmallSpells, Synergies.Protected, Synergies.Cycle },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1330);

        var card1331 = new UnitData()
        {
            Id = 1331,
            Name = "Roadside Wanderer",
            ImageTag = CardImageTags.Roadside_Wanderer,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            Text = @"<b>Vanguard
Deployment:</b> Use <b>Trade Tales</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Protected, Tags.Deployment, Tags.Divinate, Tags.Vanguard, Tags.Wanderer },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Melee, Synergies.Mobility, Synergies.Protected, Synergies.Deployment, Synergies.Prediction, Synergies.Vanguard },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Wanderer,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1111 },

            Keywords = new List<Keywords>() { Keywords.Vanguard },
        };
        CardList.Add(card1331);

        var card1332 = new SpellData()
        {
            Id = 1332,
            Name = "Moonlight Premonition",
            ImageTag = CardImageTags.Moonlight_Premonition,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), new Resource(CardResources.Wild, 2), },

            Text = @"<b>Study (4)
Divinate (2)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.StudyGain, Tags.Divinate },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Draw, Synergies.Study, Synergies.Prediction },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1332);

        var card1333 = new UnitData()
        {
            Id = 1333,
            Name = "Wandering Storyteller",
            ImageTag = CardImageTags.Wandering_Storyteller,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            Text = @"<b>Deployment:</b> Use <b>Exchange Stories</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.StudyGain, Tags.Wanderer },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Draw, Synergies.Deployment, Synergies.Study },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Wanderer,
            },
            Attack = 1,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1112 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1333);

        var card1334 = new UnitData()
        {
            Id = 1334,
            Name = "Aedeline Mystic",
            ImageTag = CardImageTags.Aedeline_Mystic,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            Text = @"<b>Conduit, Protected (2)
Deployment: Study (4)</b>
Whenever you activate a <b>Study</b> effect, shuffle an additional Inspiration card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Protected, Tags.Elven, Tags.Conduit, Tags.Deployment, Tags.StudyGain, Tags.Luminist },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Protected, Synergies.Summon, Synergies.Midrange, Synergies.Deployment, Synergies.Study },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Luminist,
            },
            Attack = 1,
            Health = 3,
            Protected = 2,
            Range = 2,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card1334);

        var card1336 = new SpellData()
        {
            Id = 1336,
            Name = "Moondrain",
            ImageTag = CardImageTags.Moondrain,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            Text = @"<b>Spellbind</b> a unit. Deal damage to the unit equal to number of enchantments removed. The caster gains any attack and health statistics removed",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.Spellbind },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Empowered, Synergies.SmallSpells, Synergies.Durable, Synergies.Antimagic },
            SpellType = "Enchantment",
            Range = 3,
        };
        CardList.Add(card1336);

        var card1337 = new UnitData()
        {
            Id = 1337,
            Name = "Starcaller",
            ImageTag = CardImageTags.Starcaller,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 6), new Resource(CardResources.Wild, 3), },

            Text = @"<b>Conduit, Protected (3)</b>
Whenever this unit deals damage, it gains <b>Protected</b> equal to any excess damage dealt.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Protected, Tags.Elven, Tags.Conduit, Tags.Luminist },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Durable, Synergies.AreaDamage, Synergies.Summon, Synergies.BigMinions, Synergies.Study, Synergies.LongRange },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Luminist,
            },
            Attack = 4,
            Health = 2,
            Protected = 3,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1114 },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card1337);

        var card1338 = new SpellData()
        {
            Id = 1338,
            Name = "Meditative Vision",
            ImageTag = CardImageTags.Meditative_Vision,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), new Resource(CardResources.Wild, 1), },

            Text = @"<b>Divinate (1)</b>
Restore health to the caster equal to twice the number of spells in your hand.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Divinate },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.BigSpells, Synergies.Value, Synergies.Prediction, Synergies.Restoration },
            SpellType = "Restoration",
            Range = 0,
        };
        CardList.Add(card1338);

        var card1339 = new SpellData()
        {
            Id = 1339,
            Name = "Starfire",
            ImageTag = CardImageTags.Starfire,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 5), new Resource(CardResources.Wild, 2), },

            Text = @"Deal 3 damage to all units in an area of Radius 3. Prevent them from using abilities or casting spells until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.BigSpells, Synergies.AreaDamage, Synergies.Antimagic, Synergies.Study },
            SpellType = "Damage",
            Range = 4,
        };
        CardList.Add(card1339);

        var card1340 = new UnitData()
        {
            Id = 1340,
            Name = "Mirror Aspect",
            ImageTag = CardImageTags.Mirror_Aspect,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 4), },

            Text = @"<b>Ethereal</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ethereal, Tags.Mirrored, Tags.Entity },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Mirrored,
                UnitTags.Entity,
            },
            Attack = 1,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1340);

        var card1341 = new SpellData()
        {
            Id = 1341,
            Name = "Aspect Mirror",
            ImageTag = CardImageTags.Aspect_Mirror,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 4), },

            Text = @"<b> Cycle -3</b>
Choose a friendly minion and deploy a ""Mirror Aspect"" with equal stats adjacent to it.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.CycleMinus },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.BigMinions, Synergies.Cycle },
            SpellType = "Deployment",
            Range = 2,
        };
        CardList.Add(card1341);

        var card1342 = new SpellData()
        {
            Id = 1342,
            Name = "Mirror on the Pool",
            ImageTag = CardImageTags.Mirror_on_the_Pool,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 4), new Resource(CardResources.Wild, 3), },

            Text = @"<b>Cycle -3</b>
Add a copy of all spells in your hand to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.CycleMinus },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.BigSpells, Synergies.Value, Synergies.Cycle },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1342);

        var card1343 = new UnitData()
        {
            Id = 1343,
            Name = "Moonweaver",
            ImageTag = CardImageTags.Moonweaver,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 4), },

            Text = @"<b>Deployment:</b> Use <b>Moondrain</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Elven, Tags.Deployment, Tags.Spellbind, Tags.Luminist },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Empowered, Synergies.Melee, Synergies.Durable, Synergies.Antimagic, Synergies.Deployment },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Luminist,
            },
            Attack = 4,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1115 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1343);

        var card1344 = new UnitData()
        {
            Id = 1344,
            Name = "Pool Watcher",
            ImageTag = CardImageTags.Pool_Watcher,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 7), },

            Text = @"<b>Conduit, Warden, Unleash, Protected (4)</b>
This unit's <b>Unleash</b> is activated whenever this kills a unit with a spell
",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Protected, Tags.Elven, Tags.Conduit, Tags.Warden, Tags.Luminist, Tags.Unleash },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Melee, Synergies.SmallSpells, Synergies.Durable, Synergies.Protected, Synergies.BigSpells, Synergies.Summon, Synergies.BigMinions, Synergies.Defensive, Synergies.Wild },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Luminist,
            },
            Attack = 6,
            Health = 7,
            Protected = 4,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Unleash, Keywords.Warden },
        };
        CardList.Add(card1344);

        var card1345 = new UnitData()
        {
            Id = 1345,
            Name = "Aedeline Oracle",
            ImageTag = CardImageTags.Aedeline_Oracle,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 8), },

            Text = @"<b>Conduit, Protected (5)
Deployment:</b> Use <b>Prophecy</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Protected, Tags.Elven, Tags.Conduit, Tags.Deployment, Tags.Luminist },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Protected, Synergies.BigSpells, Synergies.Summon, Synergies.Deployment, Synergies.BigMinions, Synergies.Value, Synergies.Study, Synergies.LongRange },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Luminist,
            },
            Attack = 4,
            Health = 3,
            Protected = 5,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1116 },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card1345);

        var card1346 = new SpellData()
        {
            Id = 1346,
            Name = "Vision of the Past",
            ImageTag = CardImageTags.Vision_of_the_Past,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), },

            Text = @"Add a copy of a random spell in your Graveyard to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1346);

        var card1347 = new SpellData()
        {
            Id = 1347,
            Name = "Vision of the Present",
            ImageTag = CardImageTags.Vision_of_the_Present,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), },

            Text = @"Add a copy of a random spell in your hand to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1347);

        var card1348 = new SpellData()
        {
            Id = 1348,
            Name = "Vision of the Future",
            ImageTag = CardImageTags.Vision_of_the_Future,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), },

            Text = @"Add a copy of a random spell in your deck to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1348);

        var card1349 = new SpellData()
        {
            Id = 1349,
            Name = "Lunar Eclipse",
            ImageTag = CardImageTags.Lunar_Eclipse,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 4), new Resource(CardResources.Wild, 8), },

            Text = @"<b>Cycle -4</b>
Until the start of your next turn gain, ""<b>Passive:</b> Whenever a friendly unit with <b>Protected</b> takes damage, they take 1 damage instead"". 
Give all friendly units <b>Protected (3).</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Protected, Tags.CycleMinus, Tags.Passive },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Durable, Synergies.Protected, Synergies.BigSpells, Synergies.Defensive, Synergies.Cycle, Synergies.Wild },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card1349);

        var card1350 = new SpellData()
        {
            Id = 1350,
            Name = "Solar Eclipse",
            ImageTag = CardImageTags.Solar_Eclipse,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 4), new Resource(CardResources.Wild, 8), },

            Text = @"<b>Cycle -4</b>
Until the start of your next turn gain ""<b>Passive:</b> All your spells and abilities deal double damage"".
Deal 3 damage to all enemy units",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.CycleMinus },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.BigSpells, Synergies.AreaDamage, Synergies.Wild },
            SpellType = "Damage",
            Range = 0,
        };
        CardList.Add(card1350);

        var card1351 = new SpellData()
        {
            Id = 1351,
            Name = "Alter Fate",
            ImageTag = CardImageTags.Alter_Fate,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 5), },

            Text = @"Look at the top number of cards in your deck equal to the number of cards in your hand. Choose whether to swap each card in your deck with a card in your hand. Shuffle the cards not put in your hand back into your deck.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.BigSpells, Synergies.Value, Synergies.Study, Synergies.Prediction },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1351);

        var card1352 = new UnitData()
        {
            Id = 1352,
            Name = "Sothyn, Moonpool Warden",
            ImageTag = CardImageTags.Sothyn_Moonpool_Warden,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 4), new Resource(CardResources.Wild, 6), },

            Text = @"<b>Warden, Unleash, Protected (4)</b>
Has +1 Attack, +1 Health for each spell in your hand. <b>Unleash</b> is activated on this unit whenever a ""Mirror Aspect"" created by this unit attacks and kills a unit.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Protected, Tags.Elven, Tags.Warden, Tags.CycleMinus, Tags.Luminist, Tags.Unleash },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Melee, Synergies.Durable, Synergies.Protected, Synergies.BigMinions, Synergies.Defensive, Synergies.Value, Synergies.Cycle, Synergies.Wild },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Luminist,
            },
            Attack = 5,
            Health = 5,
            Protected = 4,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1117 },

            Keywords = new List<Keywords>() { Keywords.Unleash, Keywords.Warden },
        };
        CardList.Add(card1352);

        var card1353 = new SpellData()
        {
            Id = 1353,
            Name = "Arcane Shot",
            ImageTag = CardImageTags.Arcane_Shot,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), new Resource(CardResources.Wild, 1), },

            Text = @"Your hero's next attack this turn <b>Spellbinds</b> the target",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Spellbind, Tags.Shot },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card1353);

        var card1354 = new SpellData()
        {
            Id = 1354,
            Name = "Blood Shot",
            ImageTag = CardImageTags.Blood_Shot,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), new Resource(CardResources.Wild, 1), },

            Text = @"Your hero's next attack this turn causes the target to take double damage from beast attacks until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Shot },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card1354);

        var card1355 = new SpellData()
        {
            Id = 1355,
            Name = "Explosive Shot",
            ImageTag = CardImageTags.Explosive_Shot,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), new Resource(CardResources.Wild, 1), },

            Text = @"Your hero's next attack this turn also damages all units adjacent to the target",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.AreaDamage, Tags.Shot },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card1355);

        var card1356 = new SpellData()
        {
            Id = 1356,
            Name = "Stunning Shot",
            ImageTag = CardImageTags.Stunning_Shot,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), new Resource(CardResources.Wild, 1), },

            Text = @"Your hero's next attack this turn <b>Stuns</b> the target",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Stun, Tags.Shot },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card1356);

        var card1357 = new SpellData()
        {
            Id = 1357,
            Name = "Tracking Shot",
            ImageTag = CardImageTags.Tracking_Shot,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), new Resource(CardResources.Wild, 1), },

            Text = @"Your hero's next attack this turn has +4 Range",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Shot },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card1357);

        var card1358 = new SpellData()
        {
            Id = 1358,
            Name = "Venom Shot",
            ImageTag = CardImageTags.Venom_Shot,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), new Resource(CardResources.Wild, 1), },

            Text = @"Your hero's next attck this turn is <b>Piercing,</b> deals +3 damage and prevents the target from being healed until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Piercing, Tags.Shot },
            Synergies = new List<Synergies> { },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card1358);

        var card1359 = new UnitData()
        {
            Id = 1359,
            Name = "Bear Guardian",
            ImageTag = CardImageTags.Bear_Guardian,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            Text = @"<b>Warden, Unleash</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Warden, Tags.Beast, Tags.Trained, Tags.Unleash },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Durable, Synergies.Defensive, Synergies.Beasts },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Trained,
                UnitTags.Beast,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Unleash, Keywords.Warden },
        };
        CardList.Add(card1359);

        var card1360 = new ItemData()
        {
            Id = 1360,
            Name = "Gilded Bow",
            ImageTag = CardImageTags.Gilded_Bow,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"Your hero has +2 Range. Whenever they attack, reduce this items durability",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Common,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Equip, Tags.Ornate, Tags.Bow },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Control, Synergies.Defensive, Synergies.Equip, Synergies.Archery },
            ItemTag = "Ornate Bow",
            Durability = 3,
        };
        CardList.Add(card1360);

        var card1361 = new SpellData()
        {
            Id = 1361,
            Name = "Hunter's Mark",
            ImageTag = CardImageTags.Hunters_Mark,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), },

            Text = @"Give an enemy unit, ""This unit takes double damage from attacks from your hero or units with <b>Conduit</b>"" until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Control, Synergies.Defensive, Synergies.Removal, Synergies.Archery },
            SpellType = "Enchantment",
            Range = 4,
        };
        CardList.Add(card1361);

        var card1362 = new SpellData()
        {
            Id = 1362,
            Name = "Predator's Instinct",
            ImageTag = CardImageTags.Predators_Instinct,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), new Resource(CardResources.Wild, 0), },

            Text = @"Gain 2 Wild and <b>Cycle +2.</b> Give the caster +2 range until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.WildGain },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Control, Synergies.Defensive, Synergies.Wild, Synergies.Archery },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1362);

        var card1363 = new UnitData()
        {
            Id = 1363,
            Name = "Seeking Hawk",
            ImageTag = CardImageTags.Seeking_Hawk,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 4), },

            Text = @"<b>Flying</b>
Whenever this attacks and kills a unit, draw a card and <b>Cycle +3</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Draw, Tags.Beast, Tags.Flying, Tags.CyclePlus, Tags.Trained },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Draw, Synergies.Flying, Synergies.Cycle, Synergies.Beasts },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Trained,
                UnitTags.Beast,
            },
            Attack = 4,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Flying },
        };
        CardList.Add(card1363);

        var card1364 = new UnitData()
        {
            Id = 1364,
            Name = "War Dog",
            ImageTag = CardImageTags.War_Dog,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            Text = @"<b>Prepared
Deployment:</b> Deploy a copy of this unit adjacent to it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Prepared, Tags.Deployment, Tags.Beast, Tags.Trained },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Deployment, Synergies.Swarm, Synergies.Prepared, Synergies.Beasts },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Trained,
                UnitTags.Beast,
            },
            Attack = 1,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Prepared },
        };
        CardList.Add(card1364);

        var card1365 = new SpellData()
        {
            Id = 1365,
            Name = "Loaded Quiver",
            ImageTag = CardImageTags.Loaded_Quiver,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), new Resource(CardResources.Wild, 1), },

            Text = @"Add a random Shot spell to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.AreaDamage, Tags.Spellbind },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Defensive, Synergies.Value, Synergies.Archery },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1365);

        var card1366 = new ItemData()
        {
            Id = 1366,
            Name = "Meat Bundle",
            ImageTag = CardImageTags.Meat_Bundle,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 4), },

            Text = @"Whenever you play a beast, give it +2 Attack, +2 Health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Equip, Tags.Wartorn, Tags.Satchel },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Swarm, Synergies.Equip, Synergies.Beasts },
            ItemTag = "Wartorn Satchel",
            Durability = 4,
        };
        CardList.Add(card1366);

        var card1367 = new SpellData()
        {
            Id = 1367,
            Name = "Mercy Offering",
            ImageTag = CardImageTags.Mercy_Offering,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), },

            Text = @"<b>Recruit</b> an enemy minion with less than or equal health than the caster's attack",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Recruit },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Removal, Synergies.Recruit },
            SpellType = "Removal",
            Range = 2,
        };
        CardList.Add(card1367);

        var card1368 = new UnitData()
        {
            Id = 1368,
            Name = "Pack Leader",
            ImageTag = CardImageTags.Pack_Leader,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 3), },

            Text = @"<b>Stalker</b>
Friendly beasts in range 2 have +1 Attack. Whenever a beast in range kills an enemy, increase this extra attack by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Beast, Tags.Stalker, Tags.Feral },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Swarm, Synergies.Death, Synergies.Beasts },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Feral,
                UnitTags.Beast,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Stalker },
        };
        CardList.Add(card1368);

        var card1369 = new SpellData()
        {
            Id = 1369,
            Name = "Rapid Fire",
            ImageTag = CardImageTags.Rapid_Fire,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), new Resource(CardResources.Wild, 3), },

            Text = @"The caster gains 2 additional actions this turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Control, Synergies.Defensive, Synergies.Removal, Synergies.Archery },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card1369);

        var card1370 = new UnitData()
        {
            Id = 1370,
            Name = "Beast Trainer",
            ImageTag = CardImageTags.Beast_Trainer,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 5), },

            Text = @"<b>Deployment:</b> Use <b>War Training</b>
Whenever a beast dies within Range 2, draw a card.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Draw, Tags.Deployment, Tags.Beastmaster },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Deployment, Synergies.Swarm, Synergies.ShortRange, Synergies.Beasts },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Beastmaster,
            },
            Attack = 3,
            Health = 4,
            Protected = 0,
            Range = 1,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1120 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1370);

        var card1371 = new UnitData()
        {
            Id = 1371,
            Name = "Brood Mother",
            ImageTag = CardImageTags.Brood_Mother,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 6), },

            Text = @"<b>Stealth, Unleash
Deployment</b> and <b>Last Rites:</b> Deploy two ""Spiderlings"" with attack and health equal to this unit's attack in front of this unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Deployment, Tags.Beast, Tags.LastRites, Tags.Unleash, Tags.Stealth, Tags.Feral },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Durable, Synergies.Deployment, Synergies.Swarm, Synergies.LastRites, Synergies.Wild, Synergies.Shadows, Synergies.Beasts },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Feral,
                UnitTags.Beast,
            },
            Attack = 2,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Stealth, Keywords.Unleash },
        };
        CardList.Add(card1371);

        var card1372 = new UnitData()
        {
            Id = 1372,
            Name = "Spiderling",
            ImageTag = CardImageTags.Spiderling,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 2), },

            Text = @"<b>Stealth</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Beast, Tags.Stealth, Tags.Feral },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Feral,
                UnitTags.Beast,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1372);

        var card1373 = new UnitData()
        {
            Id = 1373,
            Name = "Nakari Bowyer",
            ImageTag = CardImageTags.Nakari_Bowyer,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), new Resource(CardResources.Wild, 2), },

            Text = @"<b>Routing
Deployment:</b> Use <b>Craft Arrows</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Stun, Tags.AreaDamage, Tags.Elven, Tags.Deployment, Tags.Spellbind, Tags.Routing, Tags.Craftsman },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Deployment, Synergies.Defensive, Synergies.Value, Synergies.Routing, Synergies.Archery },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Craftsman,
            },
            Attack = 4,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1121 },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card1373);

        var card1374 = new UnitData()
        {
            Id = 1374,
            Name = "Woodland Guide",
            ImageTag = CardImageTags.Woodland_Guide,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), },

            Text = @"<b>Routing, Stalker</b>
Difficult terrain tiles in range 2 do not require additional movement for friendly units",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Waystalker, Tags.Stalker, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Midrange, Synergies.Swarm, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Waystalker,
            },
            Attack = 2,
            Health = 3,
            Protected = 0,
            Range = 2,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Routing, Keywords.Stalker },
        };
        CardList.Add(card1374);

        var card1375 = new UnitData()
        {
            Id = 1375,
            Name = "Blood Wolf",
            ImageTag = CardImageTags.Blood_Wolf,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 5), },

            Text = @"<b>Unleash, Stalker, Cycle -5</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Beast, Tags.CycleMinus, Tags.Unleash, Tags.Stalker, Tags.Feral },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Durable, Synergies.BigMinions, Synergies.Cycle, Synergies.Wild, Synergies.Beasts },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Feral,
                UnitTags.Beast,
            },
            Attack = 6,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1122 },

            Keywords = new List<Keywords>() { Keywords.Stalker, Keywords.Unleash },
        };
        CardList.Add(card1375);

        var card1376 = new UnitData()
        {
            Id = 1376,
            Name = "Monster Hunter",
            ImageTag = CardImageTags.Monster_Hunter,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 6), },

            Text = @"<b>Stalker
Deployment:</b> Choose an enemy minion. Gain the <b>Passive:</b> ""Whenever an enemy minion dies which shares any unit tags with the target, double their bounty""",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Deployment, Tags.Waystalker, Tags.GoldGain, Tags.Stalker, Tags.Passive },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Midrange, Synergies.Deployment, Synergies.BigMinions, Synergies.Gold },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Waystalker,
            },
            Attack = 4,
            Health = 3,
            Protected = 0,
            Range = 2,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Stalker },
        };
        CardList.Add(card1376);

        var card1377 = new UnitData()
        {
            Id = 1377,
            Name = "Nakari Ranger",
            ImageTag = CardImageTags.Nakari_Ranger,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), new Resource(CardResources.Wild, 7), },

            Text = @"<b>Conduit, Stalker</b>
Whenever you cast a shot spell, it affects this unit's next attack as well as your hero",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Elven, Tags.Conduit, Tags.Waystalker, Tags.Stalker },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Control, Synergies.BigMinions, Synergies.Defensive, Synergies.Wild, Synergies.Archery },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elven,
                UnitTags.Waystalker,
            },
            Attack = 3,
            Health = 5,
            Protected = 0,
            Range = 3,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Stalker },
        };
        CardList.Add(card1377);

        var card1378 = new UnitData()
        {
            Id = 1378,
            Name = "Lokthar, The Untamed",
            ImageTag = CardImageTags.Lokthar_the_Untamed,

            Resources = new List<Resource>() { new Resource(CardResources.Wild, 4), },

            Text = @"<b>Stalker, Unleash, Cycle -4</b>
Whenever a beast dies within Range 2, <b>Regenerate.</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Regenerate, Tags.CycleMinus, Tags.Unleash, Tags.Stalker },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Durable, Synergies.Swarm, Synergies.BigMinions, Synergies.Removal, Synergies.Cycle, Synergies.Beasts },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Feral,
                UnitTags.Beast,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1123 },

            Keywords = new List<Keywords>() { Keywords.Stalker, Keywords.Unleash },
        };
        CardList.Add(card1378);

        var card1379 = new ItemData()
        {
            Id = 1379,
            Name = "Selynthe, Bow of the Nakari",
            ImageTag = CardImageTags.Selynthe_Bow_of_the_Nakari,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 5), new Resource(CardResources.Wild, 3), },

            Text = @"<b>Cycle -3
Deployment:</b> Choose a shot spell in your hand and <b>Discard</b> it.
Whenever your hero attacks, the effect of the chosen shot applies to it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Deployment, Tags.Equip, Tags.Magic, Tags.Discard, Tags.CycleMinus, Tags.Bow },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Deployment, Synergies.Defensive, Synergies.Equip, Synergies.Discard, Synergies.Gold, Synergies.Archery },
            ItemTag = "Magic Bow",
            Durability = 3,
        };
        CardList.Add(card1379);

        var card1380 = new SpellData()
        {
            Id = 1380,
            Name = "Cunning Inspiration",
            ImageTag = CardImageTags.Cunning_Inspiration,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 0), },

            Text = @"<b>Cast when Drawn</b>
Increase your base Knowledge rate by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.StudyGain, Tags.CastWhenDrawn, Tags.Inspiration },
            Synergies = new List<Synergies> { },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1380);

        var card1381 = new UnitData()
        {
            Id = 1381,
            Name = "Corrupt Guildmaster",
            ImageTag = CardImageTags.Corrupt_Guidlmaster,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), },

            Text = @"<b>Routing
Deployment:</b> Gain 3 Gold
<b>Last Rites:</b> Lose 3 Gold",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Deployment, Tags.LastRites, Tags.GoldGain, Tags.Merchant, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.LastRites, Synergies.Gold, Synergies.Routing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Merchant,
            },
            Attack = 4,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card1381);

        var card1382 = new UnitData()
        {
            Id = 1382,
            Name = "Dark Blade",
            ImageTag = CardImageTags.Dark_Blade,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), new Resource(CardResources.Knowledge, 1), },

            Text = @"<b>Conduit, Stealth, Piercing</b>
The first spell this unit casts each turn does not break <b>Stealth</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Conduit, Tags.Agent, Tags.Stealth, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.SmallSpells, Synergies.Mobility, Synergies.BigSpells, Synergies.Shadows, Synergies.Piercing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 3,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Stealth, Keywords.Piercing },
        };
        CardList.Add(card1382);

        var card1383 = new SpellData()
        {
            Id = 1383,
            Name = "Extortion",
            ImageTag = CardImageTags.Extortion,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 0), new Resource(CardResources.Knowledge, 2), },

            Text = @"Gain 3 Gold. <b>Recruit</b> a copy of the top card of your opponent's deck",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.GoldGain, Tags.Recruit },
            Synergies = new List<Synergies> { Synergies.Value, Synergies.Gold, Synergies.Recruit, Synergies.Spies },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1383);

        var card1384 = new UnitData()
        {
            Id = 1384,
            Name = "Medlar Spy",
            ImageTag = CardImageTags.Medlar_Spy,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            Text = @"<b>Deployment:</b> Use <b>Infiltration</b>
Whenever you draw this card, reduce your <b>Stagnation</b> by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.StudyGain, Tags.Agent },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Draw, Synergies.Deployment, Synergies.Study, Synergies.Exchanges },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 3,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1124 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1384);

        var card1385 = new UnitData()
        {
            Id = 1385,
            Name = "Pickpocket",
            ImageTag = CardImageTags.Pickpocket,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"<b>Stealth</b>
Whenever this attacks an enemy unit, <b>Recruit</b> a copy of the top card of your opponent's deck",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Agent, Tags.Stealth, Tags.Recruit },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Recruit, Synergies.Shadows, Synergies.Spies },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 2,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Stealth },
        };
        CardList.Add(card1385);

        var card1386 = new UnitData()
        {
            Id = 1386,
            Name = "Shadowy Assassin",
            ImageTag = CardImageTags.Shadowy_Assassin,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 1), },

            Text = @"<b>Deadly, Stealth</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Agent, Tags.Stealth, Tags.Deadly },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Removal, Synergies.Shadows },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 1,
            Health = 1,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Deadly, Keywords.Stealth },
        };
        CardList.Add(card1386);

        var card1387 = new UnitData()
        {
            Id = 1387,
            Name = "Efficient Bookkeeper",
            ImageTag = CardImageTags.Efficient_Bookkeeper,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 4), },

            Text = @"<b>Deployment: Study (4)</b>
After you draw an <b>Inspiration</b> card, shuffle another back into your deck",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Deployment, Tags.StudyGain, Tags.Agent },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Draw, Synergies.Deployment, Synergies.Study, Synergies.Exchanges },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 5,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1387);

        var card1388 = new ItemData()
        {
            Id = 1388,
            Name = "Pickpocket's Knife",
            ImageTag = CardImageTags.Pickpockets_Knife,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"After your hero attacks a unit, gain 2 Gold",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Equip, Tags.GoldGain, Tags.Dagger, Tags.Hidden },
            Synergies = new List<Synergies> { Synergies.Equip, Synergies.Gold },
            ItemTag = "Hidden Dagger",
            Durability = 3,
        };
        CardList.Add(card1388);

        var card1389 = new SpellData()
        {
            Id = 1389,
            Name = "Planned Removal",
            ImageTag = CardImageTags.Planned_Removal,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 5), },

            Text = @"Destroy an enemy minion. Whenever you shuffle this card into your deck, reduce its cost by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleRemoval },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.BigSpells, Synergies.Study, Synergies.Removal, Synergies.Exchanges },
            SpellType = "Removal",
            Range = 2,
        };
        CardList.Add(card1389);

        var card1390 = new SpellData()
        {
            Id = 1390,
            Name = "Spycraft",
            ImageTag = CardImageTags.Spycraft,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), },

            Text = @"Look at three random cards from your opponent's hand. Choose to <b>Recruit</b> a copy of one of them",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Recruit },
            Synergies = new List<Synergies> { Synergies.Value, Synergies.Recruit, Synergies.Spies },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card1390);

        var card1391 = new SpellData()
        {
            Id = 1391,
            Name = "The Right Tool",
            ImageTag = CardImageTags.The_Right_Tool,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 2), },

            Text = @"Shuffle your hand into your deck, then draw that many cards",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Exchanges },
            SpellType = "Draw",
            Range = 0,
        };
        CardList.Add(card1391);

        var card1392 = new SpellData()
        {
            Id = 1392,
            Name = "Assassination Contract",
            ImageTag = CardImageTags.Assassination_Contract,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), new Resource(CardResources.Knowledge, 2), },

            Text = @"Destroy an enemy minion. Multiply its <b>Bounty</b> by 2. Whenever you shuffle this card into your deck, increase the multiplier by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleRemoval, Tags.GoldGain },
            Synergies = new List<Synergies> { Synergies.Control, Synergies.Draw, Synergies.Removal, Synergies.Gold, Synergies.Exchanges },
            SpellType = "Removal",
            Range = 2,
        };
        CardList.Add(card1392);

        var card1393 = new ItemData()
        {
            Id = 1393,
            Name = "Laundering Record",
            ImageTag = CardImageTags.Laundering_Record,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 3), },

            Text = @"After you draw the first card on your turn, choose whether to shuffle it back into your deck and draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Draw, Tags.Equip, Tags.Scroll, Tags.Shady },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Equip, Synergies.Exchanges },
            ItemTag = "Shady Scroll",
            Durability = 4,
        };
        CardList.Add(card1393);

        var card1394 = new UnitData()
        {
            Id = 1394,
            Name = "Master Thief",
            ImageTag = CardImageTags.Master_Thief,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 3), },

            Text = @"<b>Conduit, Stealth</b>
After you <b>Recruit</b> a card, gain +1 Attack, +1 Health.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Conduit, Tags.Agent, Tags.Stealth, Tags.Recruit },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.SmallSpells, Synergies.Mobility, Synergies.BigSpells, Synergies.Recruit, Synergies.Shadows, Synergies.Spies },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 2,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1125 },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Stealth },
        };
        CardList.Add(card1394);

        var card1395 = new UnitData()
        {
            Id = 1395,
            Name = "Medlar Saboteur",
            ImageTag = CardImageTags.Medlar_Saboteur,

            Resources = new List<Resource>() { new Resource(CardResources.Knowledge, 4), },

            Text = @"<b>Deployment:</b> Your opponent's spells cost (3) more on their next turn.
Whenever you draw this card, <b>Divinate (1)</b> the enemy deck",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Deployment, Tags.Divinate, Tags.Agent },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Draw, Synergies.Deployment, Synergies.Study, Synergies.Prediction, Synergies.Spies, Synergies.Exchanges },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 5,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1395);

        var card1396 = new UnitData()
        {
            Id = 1396,
            Name = "Medlar Fence",
            ImageTag = CardImageTags.Medlar_Fence,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 6), new Resource(CardResources.Knowledge, 3), },

            Text = @"<b>Routing
Deployment:</b> Use <b>Make Arrangements</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Agent, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.BigMinions, Synergies.Gold, Synergies.Routing, Synergies.Exchanges },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 5,
            Health = 9,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1126 },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card1396);

        var card1397 = new UnitData()
        {
            Id = 1397,
            Name = "Hidden Informant",
            ImageTag = CardImageTags.Hidden_Informant,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), },

            Text = @"<b>Routing
Deployment:</b> Reduce the gold cost of cards you <b>Recruited</b> in your hand by (1)",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Agent, Tags.Recruit, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.Recruit, Synergies.Spies },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 4,
            Health = 5,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card1397);

        var card1398 = new UnitData()
        {
            Id = 1398,
            Name = "Shadowblade",
            ImageTag = CardImageTags.Shadowblade,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 4), new Resource(CardResources.Knowledge, 2), },

            Text = @"Whenever you draw this, it gains a new one of the following keywords at random for the rest of the scenario: <b>Conduit, Deadly, Ethereal, Piercing, Stealth</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Conduit, Tags.Ethereal, Tags.Agent, Tags.Stealth, Tags.Deadly, Tags.Piercing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Control, Synergies.Draw, Synergies.Ethereal, Synergies.Removal, Synergies.Gold, Synergies.Shadows, Synergies.Exchanges, Synergies.Piercing },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 3,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1398);

        var card1399 = new UnitData()
        {
            Id = 1399,
            Name = "Omaris, Lord of Shadows",
            ImageTag = CardImageTags.Omaris_Lord_of_Shadows,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 2), new Resource(CardResources.Knowledge, 3), },

            Text = @"<b>Routing</b>
Whenever you shuffle this card into your deck, give it +2 Attack, +2 Health.
If this unit <b>Routs</b> shuffle a new copy of it back into your deck",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Agent, Tags.Routing },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Draw, Synergies.Value, Synergies.Routing, Synergies.Exchanges },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 2,
            Health = 2,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Routing },
        };
        CardList.Add(card1399);

        var card1400 = new UnitData()
        {
            Id = 1400,
            Name = "Spymaster Luren",
            ImageTag = CardImageTags.Spymaster_Luren,

            Resources = new List<Resource>() { new Resource(CardResources.Gold, 7), },

            Text = @"<b>Conduit
Deployment: Recruit</b> 3 random cards from your opponent's hand. After you play any of them or when Luren leaves the battlefield, return the remaining cards to their hand and restore their previous cost.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Conduit, Tags.Deployment, Tags.Agent, Tags.Recruit },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Deployment, Synergies.BigMinions, Synergies.Gold, Synergies.Recruit, Synergies.Spies },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Agent,
            },
            Attack = 4,
            Health = 4,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1127 },

            Keywords = new List<Keywords>() { Keywords.Conduit },
        };
        CardList.Add(card1400);

        var card1402 = new UnitData()
        {
            Id = 1402,
            Name = "Caravan",
            ImageTag = CardImageTags.Caravan,

            Resources = new List<Resource>() { },

            Text = @"<b>Token</b>
This unit's speed cannot increase above 0",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Token,
            Rarity = Rarity.Token,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Structure, Tags.Cloth, Tags.Caravan, Tags.Token },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Cloth,
                UnitTags.Caravan,
            },
            Attack = 0,
            Health = 8,
            Protected = 0,
            Range = 0,
            Speed = 0,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Token },
        };
        CardList.Add(card1402);

        var card1403 = new UnitData()
        {
            Id = 1403,
            Name = "Wooden Wall",
            ImageTag = CardImageTags.Wooden_Wall,

            Resources = new List<Resource>() { },

            Text = @"<b>Token, Structure</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Token,
            Rarity = Rarity.Token,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Wooden, Tags.Structure, Tags.Token },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Wooden,
                UnitTags.Structure,
            },
            Attack = 0,
            Health = 12,
            Protected = 0,
            Range = 0,
            Speed = 0,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Structure, Keywords.Token },
        };
        CardList.Add(card1403);

        var card1404 = new UnitData()
        {
            Id = 1404,
            Name = "Wooden Tower",
            ImageTag = CardImageTags.Wooden_Tower,

            Resources = new List<Resource>() { },

            Text = @"<b>Token, Structure</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Token,
            Rarity = Rarity.Token,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Structure, Tags.Token },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Wooden,
                UnitTags.Structure,
            },
            Attack = 2,
            Health = 15,
            Protected = 0,
            Range = 3,
            Speed = 0,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1404);

        var card1405 = new UnitData()
        {
            Id = 1405,
            Name = "Wooden Gate",
            ImageTag = CardImageTags.Wooden_Gate,

            Resources = new List<Resource>() { },

            Text = @"<b>Token, Structure, Protected (5)</b>
Friendly units can move through this tile",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Token,
            Rarity = Rarity.Token,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Wooden, Tags.Structure, Tags.Token },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Wooden,
                UnitTags.Structure,
            },
            Attack = 0,
            Health = 10,
            Protected = 5,
            Range = 0,
            Speed = 0,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1128 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1405);

        var card1406 = new UnitData()
        {
            Id = 1406,
            Name = "Palisade Wall",
            ImageTag = CardImageTags.Palisade_Wall,

            Resources = new List<Resource>() { },

            Text = @"<b>Token, Structure</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Token,
            Rarity = Rarity.Token,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Wooden, Tags.Structure, Tags.Token },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Wooden,
                UnitTags.Structure,
            },
            Attack = 0,
            Health = 6,
            Protected = 0,
            Range = 0,
            Speed = 0,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1406);

        var card1407 = new UnitData()
        {
            Id = 1407,
            Name = "Druidic Pillar",
            ImageTag = CardImageTags.Druidic_Pillar,

            Resources = new List<Resource>() { },

            Text = @"<b>Token, Structure
Indestructible</b> to all damage except from rule effects",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Token,
            Rarity = Rarity.Token,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Structure, Tags.Token, Tags.Stone },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Stone,
                UnitTags.Structure,
            },
            Attack = 0,
            Health = 3,
            Protected = 0,
            Range = 0,
            Speed = 0,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { Keywords.Structure, Keywords.Token },
        };
        CardList.Add(card1407);

        var card1408 = new UnitData()
        {
            Id = 1408,
            Name = "Forge Guardian",
            ImageTag = CardImageTags.Forge_Guardian,

            Resources = new List<Resource>() { },

            Text = @"<b>Token, Conduit, Warden</b>
Whenever this unit takes damage from friendly Fire units or spells, they are healed for the same amount instead.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Token,
            Rarity = Rarity.Token,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Conduit, Tags.Warden, Tags.Fire, Tags.Elemental, Tags.Craftsman, Tags.Token },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elemental,
                UnitTags.Craftsman,
            },
            Attack = 4,
            Health = 16,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1129 },

            Keywords = new List<Keywords>() { Keywords.Conduit, Keywords.Warden, Keywords.Token },
        };
        CardList.Add(card1408);

        var card1409 = new UnitData()
        {
            Id = 1409,
            Name = "Tentacle of Se'Carr",
            ImageTag = CardImageTags.Tentacle_of_SeCarr,

            Resources = new List<Resource>() { },

            Text = @"<b>Token, Prepared</b>
After this attacks a unit, <b>Root</b> it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Token,
            Rarity = Rarity.Token,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Prepared, Tags.Void, Tags.Abomination, Tags.Token },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Void,
                UnitTags.Abomination,
            },
            Attack = 0,
            Health = 2,
            Protected = 0,
            Range = 1,
            Speed = 0,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1409);

        var card1410 = new UnitData()
        {
            Id = 1410,
            Name = "Ritual Pillar",
            ImageTag = CardImageTags.Ritual_Pillar,

            Resources = new List<Resource>() { },

            Text = @"<b>Token, Structure
Last Rites:</b> Deal 5 damage to all adjacent non-Void units",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Token,
            Rarity = Rarity.Token,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Void, Tags.Abomination, Tags.Structure, Tags.Token },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Void,
                UnitTags.Structure,
            },
            Attack = 0,
            Health = 10,
            Protected = 0,
            Range = 0,
            Speed = 0,
            Empowered = 0,

            Abilities = new List<AbilityData>() { },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1410);

        var card1411 = new UnitData()
        {
            Id = 1411,
            Name = "Curoz the Savage",
            ImageTag = CardImageTags.Curoz_the_Savage,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Wildkin,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Ability, Tags.Beast, Tags.Wildkin },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Beast,
                UnitTags.Wildkin,
            },
            Attack = 4,
            Health = 16,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1130 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1411);

        var card1412 = new UnitData()
        {
            Id = 1412,
            Name = "Elder Keren",
            ImageTag = CardImageTags.Elder_Keren,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Luminist },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Luminist,
            },
            Attack = 2,
            Health = 21,
            Protected = 0,
            Range = 2,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1131 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1412);

        var card1413 = new UnitData()
        {
            Id = 1413,
            Name = "Lord Durros",
            ImageTag = CardImageTags.Lord_Durros,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Captain },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Captain,
            },
            Attack = 5,
            Health = 20,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1132 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1413);

        var card1414 = new UnitData()
        {
            Id = 1414,
            Name = "Kolvar the Shadow",
            ImageTag = CardImageTags.Kolvar_the_Shadow,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero, Stealth</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Ability, Tags.Trickster, Tags.Stealth, Tags.Orc },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Orc,
                UnitTags.Trickster,
            },
            Attack = 3,
            Health = 21,
            Protected = 0,
            Range = 1,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1133 },

            Keywords = new List<Keywords>() { Keywords.Stealth },
        };
        CardList.Add(card1414);

        var card1415 = new UnitData()
        {
            Id = 1415,
            Name = "Warlord Mogris",
            ImageTag = CardImageTags.Warlord_Mogris,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Ability, Tags.Discard, Tags.Orc, Tags.Voidlord },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Orc,
                UnitTags.Voidlord,
            },
            Attack = 8,
            Health = 42,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1134, ability1135 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1415);

        var card1416 = new UnitData()
        {
            Id = 1416,
            Name = "The Wraith King",
            ImageTag = CardImageTags.The_Wraith_King,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero, Ethereal</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Ability, Tags.Ethereal, Tags.Abomination, Tags.Lifebond, Tags.Shadow },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Shadow,
                UnitTags.Abomination,
            },
            Attack = 7,
            Health = 28,
            Protected = 0,
            Range = 0,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1136 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1416);

        var card1417 = new UnitData()
        {
            Id = 1417,
            Name = "Brukarn Vulkor",
            ImageTag = CardImageTags.Brukarn_Vulkor,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Grovewatcher },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Human,
                UnitTags.Grovewatcher,
            },
            Attack = 3,
            Health = 52,
            Protected = 0,
            Range = 3,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1137 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1417);

        var card1418 = new UnitData()
        {
            Id = 1418,
            Name = "Ceyarn, the Cursed Dragonslayer",
            ImageTag = CardImageTags.Ceyarn_the_Cursed_Dragonslayer,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Waystalker,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Ability, Tags.Waystalker, Tags.Undead },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Undead,
                UnitTags.Waystalker,
            },
            Attack = 3,
            Health = 28,
            Protected = 0,
            Range = 3,
            Speed = 4,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1138 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1418);

        var card1419 = new UnitData()
        {
            Id = 1419,
            Name = "Forgemaster Xeron",
            ImageTag = CardImageTags.Forgemaster_Xeron,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>
Whenever this unit takes damage from friendly Fire units or spells, they are healed for the same amount instead.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Ability, Tags.Fire, Tags.Elemental, Tags.Craftsman },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Elemental,
                UnitTags.Craftsman,
            },
            Attack = 8,
            Health = 54,
            Protected = 0,
            Range = 0,
            Speed = 2,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1139 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1419);

        var card1420 = new UnitData()
        {
            Id = 1420,
            Name = "Mogris the Corrupted",
            ImageTag = CardImageTags.Mogris_the_Corrupted,

            Resources = new List<Resource>() { },

            Text = @"<b>Hero</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.NPCHero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Ability, Tags.Orc, Tags.Voidlord },
            Synergies = new List<Synergies> { },
            UnitTag = new List<UnitTags>()
            {
                UnitTags.Orc,
                UnitTags.Voidlord,
            },
            Attack = 8,
            Health = 72,
            Protected = 0,
            Range = 0,
            Speed = 3,
            Empowered = 0,

            Abilities = new List<AbilityData>() { ability1140, ability1141 },

            Keywords = new List<Keywords>() { },
        };
        CardList.Add(card1420);

        card24.RelatedCards = new List<CardData> { card21 };
        card26.RelatedCards = new List<CardData> { card27 };
        card35.RelatedCards = new List<CardData> { card36 };
        card37.RelatedCards = new List<CardData> { card36 };
        card41.RelatedCards = new List<CardData> { card40 };
        card44.RelatedCards = new List<CardData> { card45 };
        card47.RelatedCards = new List<CardData> { card36 };
        card54.RelatedCards = new List<CardData> { card55, card56, card57, card58, card59 };
        card55.RelatedCards = new List<CardData> { card56, card57, card58, card59 };
        card56.RelatedCards = new List<CardData> { card55, card57, card58, card59 };
        card57.RelatedCards = new List<CardData> { card55, card56, card58, card59 };
        card58.RelatedCards = new List<CardData> { card55, card56, card57, card59 };
        card59.RelatedCards = new List<CardData> { card55, card56, card57, card58 };
        card60.RelatedCards = new List<CardData> { card63 };
        card61.RelatedCards = new List<CardData> { card63 };
        card62.RelatedCards = new List<CardData> { card63 };
        card77.RelatedCards = new List<CardData> { card68 };
        card78.RelatedCards = new List<CardData> { card64 };
        card105.RelatedCards = new List<CardData> { card87, card89, card90, card101 };
        card114.RelatedCards = new List<CardData> { card113 };
        card124.RelatedCards = new List<CardData> { card125 };
        card126.RelatedCards = new List<CardData> { card125 };
        card127.RelatedCards = new List<CardData> { card125 };
        card131.RelatedCards = new List<CardData> { card285, card286, card287, card288 };
        card135.RelatedCards = new List<CardData> { card136 };
        card143.RelatedCards = new List<CardData> { card115 };
        card158.RelatedCards = new List<CardData> { card150, card151, card152, card153, card154, card155 };
        card164.RelatedCards = new List<CardData> { card150, card151, card152, card153, card154, card155 };
        card172.RelatedCards = new List<CardData> { card162 };
        card173.RelatedCards = new List<CardData> { card150, card151, card152, card153, card154, card155 };
        card179.RelatedCards = new List<CardData> { card178 };
        card184.RelatedCards = new List<CardData> { card178 };
        card201.RelatedCards = new List<CardData> { card202 };
        card210.RelatedCards = new List<CardData> { card217, card219, card221 };
        card217.RelatedCards = new List<CardData> { card218 };
        card219.RelatedCards = new List<CardData> { card220 };
        card221.RelatedCards = new List<CardData> { card222 };
        card225.RelatedCards = new List<CardData> { card134 };
        card226.RelatedCards = new List<CardData> { card134 };
        card231.RelatedCards = new List<CardData> { card134 };
        card232.RelatedCards = new List<CardData> { card134 };
        card238.RelatedCards = new List<CardData> { card134 };
        card243.RelatedCards = new List<CardData> { card244 };
        card249.RelatedCards = new List<CardData> { card248 };
        card250.RelatedCards = new List<CardData> { card251 };
        card255.RelatedCards = new List<CardData> { card251 };
        card259.RelatedCards = new List<CardData> { card256, card257, card258 };
        card260.RelatedCards = new List<CardData> { card248 };
        card264.RelatedCards = new List<CardData> { card125 };
        card271.RelatedCards = new List<CardData> { card272 };
        card276.RelatedCards = new List<CardData> { card285, card286, card287, card288 };
        card277.RelatedCards = new List<CardData> { card285, card286, card287, card288 };
        card279.RelatedCards = new List<CardData> { card136 };
        card280.RelatedCards = new List<CardData> { card136 };
        card289.RelatedCards = new List<CardData> { card290, card291, card292, card294 };
        card290.RelatedCards = new List<CardData> { card291, card292, card294 };
        card291.RelatedCards = new List<CardData> { card290, card292, card294 };
        card292.RelatedCards = new List<CardData> { card290, card291, card294 };
        card293.RelatedCards = new List<CardData> { card290, card291, card292, card294 };
        card294.RelatedCards = new List<CardData> { card290, card291, card292 };
        card304.RelatedCards = new List<CardData> { card305 };
        card307.RelatedCards = new List<CardData> { card306 };
        card309.RelatedCards = new List<CardData> { card308 };
        card311.RelatedCards = new List<CardData> { card310 };
        card313.RelatedCards = new List<CardData> { card312 };
        card315.RelatedCards = new List<CardData> { card314 };
        card319.RelatedCards = new List<CardData> { card318 };
        card320.RelatedCards = new List<CardData> { card290, card291, card292, card294 };
        card323.RelatedCards = new List<CardData> { card285, card286, card287, card288 };
        card326.RelatedCards = new List<CardData> { card285, card286, card287, card288 };
        card333.RelatedCards = new List<CardData> { card332 };
        card337.RelatedCards = new List<CardData> { card285, card286, card287, card288 };
        card338.RelatedCards = new List<CardData> { card285, card286, card287, card288 };
        card339.RelatedCards = new List<CardData> { card332 };
        card1322.RelatedCards = new List<CardData> { card332 };
        card1323.RelatedCards = new List<CardData> { card285, card286, card287, card288 };
        card1332.RelatedCards = new List<CardData> { card1327 };
        card1333.RelatedCards = new List<CardData> { card1327 };
        card1334.RelatedCards = new List<CardData> { card1327 };
        card1341.RelatedCards = new List<CardData> { card1340 };
        card1345.RelatedCards = new List<CardData> { card1346, card1347, card1348 };
        card1352.RelatedCards = new List<CardData> { card1340 };
        card1365.RelatedCards = new List<CardData> { card1353, card1354, card1355, card1356, card1357, card1358 };
        card1371.RelatedCards = new List<CardData> { card1372 };
        card1373.RelatedCards = new List<CardData> { card1353, card1354, card1355, card1356, card1357, card1358 };
        card1384.RelatedCards = new List<CardData> { card1380 };
        card1387.RelatedCards = new List<CardData> { card1380 };
        card1413.RelatedCards = new List<CardData> { card254 };
        card1420.RelatedCards = new List<CardData> { card1409 };
    }
}

namespace CategoryEnums
{
    public enum Tags
    {
        Default, Blademaster, Hero, Human, Runeblade, Ability, EnergyGain, Enchantment, Swiftstrike, Stun, Draw, Dwarven, Arcanist, Empowered, Protected, AreaDamage, Elven, Conduit, Summon, Spellshield, Ethereal, Arcane, Warden, Prepared, Deployment, ManaGain, Equip, Magic, Sword, Overwhelm, SplitDamage, SingleDamage, StudyGain, Scholar, CastWhenDrawn, Spellbind, Divinate, Transformed, Beast, Transformation, SingleRemoval, Staff, LastRites, Abyssal, Void, Abomination, Discard, PrayerGain, Lifebond, Spirit, Sacrifice, SelfDamage, Vampire, Noble, Regenerate, Flying, PassiveSpell, Elemtalist, Elementalist, Fire, Goblin, Water, Air, ForceMove, Elemental, Earth, CyclePlus, Root, CycleMinus, ShortRange, Grovewatcher, WildGain, Faerie, Soldier, Treant, Agent, Captain, Metal, Lifebringer, Lorekeeper, Luminist, Mercenary, Oathknight, Trickster, Waystalker, Trained, Wildkin, MindControl, Natural, Armour, Trinket, Resurrection, Unleash, Potion, Stealth, GoldGain, GoldenHost, Merchant, Holy, Amulet, Alchemy, Bag, Equalize, Tome, Dragonkin, AreaRemoval, Angel, Knight, Steed, Vanguard, Mythic, Oath, Conjured, Image, Spell, Rogue, Stalker, Bounty, Shadowborn, Recruit, Deadly, Redeploy, Dagger, Shadow, Ogre, Brigand, Scout, Choice, Battle, Stance, Wartorn, Book, Shield, Flag, Siege, Construct, HeroTierZero, HeroTierOne, HeroTierTwo, Hireling, Transform, Brawl, Orc, Barbarian, Talisman, Aspect, Ratfolk, Passive, Routing, Scroll, Warlord, Axe, Wanderer, Mirrored, Entity, Inspiration, Ornate, Bow, Satchel, Feral, Beastmaster, Craftsman, Hidden, Shady, BasicElemental, Piercing, MindItem, Immune, Shot, Wooden, Structure, Cloth, Caravan, Token, Stone, Voidlord, Undead
    }

    public enum Synergies
    {
        Default, Energy, Blademaster, Enchantment, Empowered, Melee, SmallSpells, Stun, Mobility, Control, Draw, Durable, Protected, BigSpells, AreaDamage, Antimagic, Summon, Midrange, Ethereal, Warden, Mana, Deployment, Swarm, BigMinions, Defensive, Value, Equip, SplitDamage, SingleDamage, Study, Prediction, LongRange, Removal, Vanguard, Prepared, Death, ShortRange, LastRites, Discard, Void, Sacrifice, Prayer, Restoration, SelfDamage, Flying, Goblin, ForceMove, Cycle, Root, Wild, Faerie, Treant, Unleash, Potions, Gold, Golden, Resurrection, GoldenHost, Retribution, Shuffle, Preservation, Equalize, Madness, Pacify, Angels, Overwhelm, Oaths, Mounted, Escape, Recruit, Shivs, Shadows, Choices, Swordsman, Brawler, Shapeshifters, Aspects, Routing, Hireling, Beasts, Archery, Spies, Exchanges, Fire, Water, Air, Earth, Piercing
    }

    public enum Sets
    {
        Standard, Default
    }

    public enum CardImageTags
    {
        Default, Abyss_Imp, Abyss_Knight, Abyssal_Cultist, Abyssal_Dreadspeaker, Abyssal_Summoner, Abyssal_Voidcaller, Abyssal1, Abyssal2, Abyssal3, Abysslord_Marrex, Aedeline_Mystic, Aedeline_Oracle, Agent1, Agent2, Agent3, Aggressive_Stance, Aid_From_Above, Air_Elemental, Alter_Fate, Amulet_of_Divinity, Angel_of_Devotion, Angel_of_Judgement, Angel_of_Protection, Angel_of_Purity, Arcane_Golem, Arcane_Rush, Arcane_Shot, Arcane_Spike, Arcane_Spirit, Arcanist1, Arcanist2, Arcanist3, Archmage_Staff, Archmage_Tholas, Aspect_Mirror, Aspect_of_the_Bear, Aspect_of_the_Eagle, Aspect_of_the_Sabretooth, Aspect_of_the_Wolf, Assassination_Contract, Atarias_Blade_of_the_Kalyan, Ballista, Battle_Gear, Battle_Inspiration, Battle_Prayer, Battle_Repair, Battle_Stance, Battlefield_Surveyor, Battlemage, Bear_Aspect, Bear_Guardian, Beast_Trainer, Beastial_Fury, Binding_Circle, Bite, Blade_Dance, Blade_Enchantment, Blade_Flurry, Blade_Twirl, Blood_Bond, Blood_Pact, Blood_Shot, Blood_Wolf, Book_of_Madness, Book_of_Records, Bounty_Hunter, Bravery, Brawl_Grab, Brawl_Leap, Brawl_Shove, Brawl_Toss, Brawl_Whirlwind, Brood_Mother, Brukarn_Vulkor, Callardis_Academic, Callardis_Conjurer, Camp_Cook, Camp_Follower, Captain_of_the_Guard, Captain1, Captain2, Captain3, Caravan, Ceyarn_the_Cursed_Dragonslayer, Charge, Cold_Fury, Combat_Insurer, Commanders_Logbook, Consecrate, Convincin_Thug, Corrupt_Guidlmaster, Corthax_Keeper_of_the_Deeps, Counterspell, Counterspell_Item, Creative_Mind, Cunning_Inspiration, Curoz_the_Savage, Cursed_Shade, Dark_Blade, Dark_Pact, Deathsworn_Assassin, Deathsworn_Cursebringer, Deathsworn_Infiltrator, Deceptive_Contract, Dedicated_Preservation, Deep_Conversion, Deep_Mind, Deep_Priest, Defender_of_Sorena, Defensive_Stance, Devastating_Mind, Disgraced_Veteran, Dispel_Magic, Divine_Intervention, Divine_Ritual, Divine_Strength, Dreadbolt, Druidic_Pillar, Eager_Hireling, Eager_Squire, Eagle_Aspect, Earth_Elemental, Earth_Ritual, Earthbinder, Earthquake, Efficient_Bookkeeper, Elder_Keren, Elemental_Rush, Elementalist1, Elementalist2, Elementalist3, Eliminate, Enchanted_Dagger, Enlightenment, Equalize, Ethelia_Chosen_of_the_Light, Execute_Plan, Explosive_Shot, Extortion, Eye_of_the_Void, Fade, Faerie_Guile, Faerie_Harbringer, Faeries_Blessing, Feint, Field_Commander, Field_Medic, Fire_Elemental, Fireball, Flash, Forge_Guardian, Forgemaster_Xeron, Fortune_Teller, Forward_Planning, Furious_Brawl, Gather_Forces, Gilded_Bow, Goblin_Blastmage, Goblin_Boss, Goblin_Horde, Goblin_Looter, Golden_Host, Golden_Hostcaller, Golden_Lifebinder, Goldland_Knight, Goldland_Loyalist, Grand_Archivist_Nurosi, Grasping_Vine, Grey_Shaman, Greywalker, Grovewatcher1, Grovewatcher2, Grovewatcher3, Hardened_Shield, Head_Gobbo_Mazgix, Headhunters_Axe, Hidden_Informant, Homing_Bolt, Honour_the_Old_Gods, Hulking_Beast, Hunters_Mark, Hurricane, Ice_Blast, Imp_Matron, Intimidate, Juicy_Fruit, Kalyan_Duelist, Kalyan_Strike, Kalyan_Warrior, Kelari_Astromancer, Kelari_Librarian, Kelari_Spellguard, King_Toll_of_the_Underbelly, Kolvar_the_Shadow, Laundering_Record, Lay_on_Hands, Legionnaire, Lifebringer1, Lifebringer2, Lifebringer3, Lightning_Bolt, Loaded_Quiver, Lokthar_the_Untamed, Lord_Durros, Lord_Seldoras_Kerhall, Lorekeeper1, Lorekeeper2, Lorekeeper3, Luminist1, Luminist2, Luminist3, Luminous_Inspiration, Lunar_Eclipse, Maddening_Knowledge, Magic_Dash, Magic_Missiles, Magical_Inspiration, Man_at_Arms, Mana_Siphoner, Mana_Surge, Master_Kybas, Master_Thief, Meat_Bundle, Meditative_Vision, Medlar_Fence, Medlar_Saboteur, Medlar_Spy, Mercenary1, Mercenary2, Mercenary3, Mercy_Offering, Mind_Collapse, Mirror_Aspect, Mirror_Entity, Mirror_Image, Mirror_on_the_Pool, Mogris_the_Corrupted, Monk_of_the_Four_Winds, Monster_Hunter, Moonbeam, Moondrain, Moonlight_Premonition, Moonpool_Walk, Moonweaver, Motivate_Rifraf, Mount_Up, Mounted_Raiders, Nadalya_Sword_of_Stars, Naharr_the_Worldroot, Nakari_Bowyer, Nakari_Ranger, Oath_of_Protection, Oath_of_Protection_Item, Oath_of_Restoration, Oath_of_Restoration_Item, Oath_of_Retribution, Oath_of_Retribution_Item, Oathknight1, Oathknight2, Oathknight3, Oathspeaker, Offer_Alms, Oldari_Acolyte, Oldari_Spellweaver, Omaris_Lord_of_Shadows, Opportunistic_Warband, Othtal_Axeman, Othtal_Berserker, Othtal_Undying, Pacify, Pack_Leader, Palisade_Wall, Patient_Harvest, Pegasus, Perfect_Strike, Persuasive_Hireling, Persuasive_Techniques, Pickpocket, Pickpockets_Knife, Pig, Pin, Planned_Removal, Polymorph, Pool_Watcher, Potion_of_Confusion, Potion_of_Decay, Potion_of_Frost, Potion_of_Healing, Potion_of_Shadows, Potion_of_Speed, Potion_Satchel, Potion_Seller, Power_Investment, Predators_Instinct, Prevent_Repetition, Protected_Mind, Pummel, Queen_Aedellaei, Quick_Alchemy, Ragged_Lord_Allos, Raging_Beast, Rally, Rallying_Flag, Rampage, Rapid_Fire, Ray_of_Consumption, Realm_Convergence, Recorded_Inspiration, Recycling, Replicative_Mind, Repress, Retired_Blademaster, Return_Soul, Ring_the_Bells, Ritual_Pillar, Roadside_Wanderer, Rune_Forger, Runeblade1, Runeblade2, Runeblade3, Sabretooth_Aspect, Sanctuary, Scout_Regiment, Seeking_Hawk, Selynthe_Bow_of_the_Nakari, Serrated_Claws, Shade_Hunter, Shadowblade, Shadowy_Assassin, Shady_Hireling, Shady_Recruiter, Shapechanger, Shield_of_Faith, Shield_of_Goldland, Shiv, Solar_Eclipse, Sorena_Cleric, Sorena_High_Priest, Sosthrim_Druid, Sosthrim_Grovekeeper, Sosthrim_Harvester, Sothyn_Moonpool_Warden, Soul_Blade, Soul_Consumer, Soulthief_Shade, Spark_of_Power, Spectral_Shield, Spectral_Staff, Spectral_Sword, Spiderling, Spined_Carapace, Spirit_Totem, Spirit_Walker_Bragas, Spycraft, Spymaster_Luren, Stable_Stance, Starcaller, Starfire, Street_Tricks, Stunning_Shot, Subdue, Sucker_Punch, Supreme_Commander_Tythas, Survey, Swordcaster, Tend_the_Elements, Tending_Priest, Tentacle_of_SeCarr, Tessara_Lady_of_Goldland, Test_NPC_Hero, The_Faceless_One, The_Great_Spirit, The_Green_Horde, The_Right_Tool, The_Void_Hungers, The_Wraith_King, Tidal_Wave, Tithe_Collector, Tome_Of_Power, Tough_Hireling, Tracking_Shot, Trained_Hound, Treeheart_Censer, Trickster1, Trickster2, Trickster3, Tythelia_Lady_of_Gold, Underbelly_Cutthroat, Underbelly_Runner, Underbelly_Smuggler, Vampire_Aristocrat, Vampire_Courtesan, Vault_Archivist, Vault_Catalyst, Vault_Collector, Venom_Shot, Vision_of_the_Future, Vision_of_the_Past, Vision_of_the_Present, Void_Soul, Void_Touch, Voidling, Wall_of_Fire, Wandering_Storyteller, War_Dog, Warchief_Aghazir, Warding_Rune, Warhorse, Warlord_Mogris, Water_Elemental, Wave_Sorceror, Waystalker1, Waystalker2, Waystalker3, Wild_Fury, Wildkin1, Wildkin2, Wildkin3, Wolf_Aspect, Wooden_Gate, Wooden_Tower, Wooden_Wall, Woodland_Guide, Woodland_Sprite, Worldroot_Ancient, Worldroot_Defender, Worldroot_Dreamer, Worldroot_Sapling
    }

    public enum UnitTags
    {
        Default, Human, Runeblade, Blademaster, Dwarven, Arcanist, Arcane, Summon, Elven, Scholar, Transformed, Beast, Abyssal, Void, Abomination, Spirit, Vampire, Noble, Elementalist, Goblin, Elemental, Grovewatcher, Faerie, Soldier, Treant, Agent, Captain, Lifebringer, Lorekeeper, Luminist, Mercenary, Oathknight, Trickster, Waystalker, Trained, Wildkin, Merchant, Dragonkin, Angel, Knight, Steed, Mythic, Rogue, Shadowborn, Ratfolk, Shadow, Ogre, Brigand, Scout, Siege, Construct, Orc, Barbarian, Warlord, Test, Wanderer, Mirrored, Entity, Feral, Beastmaster, Craftsman, Cloth, Caravan, Wooden, Structure, Stone, Voidlord, Undead
    }
}
