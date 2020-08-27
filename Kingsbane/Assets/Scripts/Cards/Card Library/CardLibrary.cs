﻿using System.Collections.Generic;
using CategoryEnums;

public class CardLibrary
{
    public List<CardData> CardList { get; private set; }

    public void InitLibrary()
    {
        CardList = new List<CardData>();

        var card2 = new UnitData()
        {
            Id = 2,
            Name = "Runeblade Tier1",
            ImageLocation = "Runeblade1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero</b>
<b>Arcane Bolt (2 Energy, 1 Action):</b> Deal 2 damage to a unit within range 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Runeblade, Tags.Ability },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Runeblade",
            Attack = 4,
            Health = 9,
            Range = 0,
            Speed = 4
        };
        CardList.Add(card2);

        var card4 = new SpellData()
        {
            Id = 4,
            Name = "Arcane Rush",
            ImageLocation = "Arcane_Rush",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 3,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Blade_Enchantment",

            ResourceDevotion = null,
            ResourceEnergy = 1,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 2,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Kalyan_Duelist",

            ResourceDevotion = null,
            ResourceEnergy = 3,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Swiftstrike
Kalyan Strike (1 Energy, 1 Action): Stun</b> an enemy unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Blademaster, Tags.Human, Tags.Ability, Tags.Swiftstrike, Tags.Stun },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Enchantment, Synergies.Melee, Synergies.Stun, Synergies.Mobility },
            UnitTag = "Human Blademaster",
            Attack = 2,
            Health = 2,
            Range = 0,
            Speed = 4
        };
        CardList.Add(card6);

        var card7 = new SpellData()
        {
            Id = 7,
            Name = "Kalyan Strike",
            ImageLocation = "Kalyan_Strike",

            ResourceDevotion = null,
            ResourceEnergy = 2,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

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
            Range = 2,
        };
        CardList.Add(card7);

        var card8 = new UnitData()
        {
            Id = 8,
            Name = "Kalyan Warrior",
            ImageLocation = "Kalyan_Warrior",

            ResourceDevotion = null,
            ResourceEnergy = 2,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Deals double damage to <b>Stunned</b> units.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Blademaster, Tags.Human, Tags.Stun },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Melee, Synergies.Stun },
            UnitTag = "Human Blademaster",
            Attack = 3,
            Health = 2,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card8);

        var card9 = new UnitData()
        {
            Id = 9,
            Name = "Rune Forger",
            ImageLocation = "Rune_Forger",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 3,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Empowered +1
Runesmith (1 Mana, 1 Action):</b> Give a friendly unit within Range 1 <b>Empowered +1</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Dwarven, Tags.Arcanist, Tags.Empowered },
            Synergies = new List<Synergies> { Synergies.Enchantment, Synergies.Empowered, Synergies.Melee },
            UnitTag = "Dwarven Arcanist",
            Attack = 3,
            Health = 4,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card9);

        var card10 = new SpellData()
        {
            Id = 10,
            Name = "Blade Dance",
            ImageLocation = "Blade_Dance",

            ResourceDevotion = null,
            ResourceEnergy = 7,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"The caster gains <b>Swiftstrike</b> and <b>Protected (Infinite)</b> until the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment, Tags.Swiftstrike, Tags.Protected },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Durable, Synergies.Protected, Synergies.BigSpells },
            SpellType = "Enchantment",
            Range = 0,
        };
        CardList.Add(card10);

        var card11 = new SpellData()
        {
            Id = 11,
            Name = "Feint",
            ImageLocation = "Feint",

            ResourceDevotion = null,
            ResourceEnergy = 4,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Magic_Dash",

            ResourceDevotion = null,
            ResourceEnergy = 3,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 3,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Blade_Twirl",

            ResourceDevotion = null,
            ResourceEnergy = 5,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

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
            Range = 5,
        };
        CardList.Add(card13);

        var card14 = new UnitData()
        {
            Id = 14,
            Name = "Swordcaster",
            ImageLocation = "Swordcaster",

            ResourceDevotion = null,
            ResourceEnergy = 2,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 2,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Conduit, Empowered +1
Sword Fling (2 Mana, 1 Action):</b> Deal damage equal to your <b>Empowered</b> value to a unit within range 2.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Runeblade, Tags.Ability, Tags.Empowered, Tags.Elven, Tags.Conduit },
            Synergies = new List<Synergies> { Synergies.Blademaster, Synergies.Empowered, Synergies.Melee },
            UnitTag = "Elven Runeblade",
            Attack = 3,
            Health = 3,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card14);

        var card15 = new UnitData()
        {
            Id = 15,
            Name = "Spectral Staff",
            ImageLocation = "Spectral_Staff",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 4,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon, Spellshield, Ethereal, Conduit, Empowered +2</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Empowered, Tags.Conduit, Tags.Summon, Tags.Spellshield, Tags.Ethereal, Tags.Arcane },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Antimagic, Synergies.Summon, Synergies.Midrange, Synergies.Ethereal },
            UnitTag = "Arcane Summon",
            Attack = 2,
            Health = 3,
            Range = 2,
            Speed = 3
        };
        CardList.Add(card15);

        var card16 = new UnitData()
        {
            Id = 16,
            Name = "Spectral Shield",
            ImageLocation = "Spectral_Shield",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 4,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon, Spellshield, Ethereal, Warden</b>
Whenever an adjacent ally takes damage, this unit takes it instead",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Spellshield, Tags.Ethereal, Tags.Arcane, Tags.Warden },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Durable, Synergies.Antimagic, Synergies.Summon, Synergies.Ethereal, Synergies.Defensive },
            UnitTag = "Arcane Summon",
            Attack = 0,
            Health = 12,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card16);

        var card17 = new UnitData()
        {
            Id = 17,
            Name = "Spectral Sword",
            ImageLocation = "Spectral_Sword",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 4,
            ResourceWild = null,
            ResourceNeutral = null,

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
            UnitTag = "Arcane Summon",
            Attack = 4,
            Health = 4,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card17);

        var card18 = new SpellData()
        {
            Id = 18,
            Name = "Warding Rune",
            ImageLocation = "Warding_Rune",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Retired_Blademaster",

            ResourceDevotion = null,
            ResourceEnergy = 5,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Deployment:</b> Use <b>Kalyan Training
Kalyan Training (3 Energy, 1 Action):</b> Give all other friendly melee units within Range 2 +2 Attack",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Blademaster, Tags.Human, Tags.Ability, Tags.Deployment },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Melee, Synergies.Deployment, Synergies.Swarm, Synergies.BigMinions },
            UnitTag = "Human Blademaster",
            Attack = 5,
            Health = 4,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card19);

        var card20 = new UnitData()
        {
            Id = 20,
            Name = "Mana Siphoner",
            ImageLocation = "Mana_Siphoner",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Conduit<b>
Whenever this unit kills an enemy unit, gain 3 Mana",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Runeblade, Tags.Elven, Tags.Conduit, Tags.ManaGain },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mana, Synergies.BigMinions },
            UnitTag = "Elven Runeblade",
            Attack = 5,
            Health = 7,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card20);

        var card21 = new ItemData()
        {
            Id = 21,
            Name = "Mirror Entity",
            ImageLocation = "Mirror_Entity",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Whenever your Hero is attacked, take no damage",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { },
            Synergies = new List<Synergies> { },
            ItemTag = "Conjured Image",
            Durability = 3,
        };
        CardList.Add(card21);

        var card24 = new SpellData()
        {
            Id = 24,
            Name = "Mirror Image",
            ImageLocation = "Mirror_Image",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Atarias",

            ResourceDevotion = null,
            ResourceEnergy = 9,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Swiftstrike</b>
This unit's <b>Swiftstrike</b> grants it two additional actions. It can use it's ability multiple times in a turn.
Whenever this attacks a <b>Stunned</b> unit, draw a card
<b>Kalyan Strike (1 Energy, 1 Action): Stun</b> an enemy unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Blademaster, Tags.Human, Tags.Ability, Tags.Swiftstrike },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Melee, Synergies.Stun, Synergies.Draw },
            UnitTag = "Human Blademaster",
            Attack = 7,
            Health = 5,
            Range = 0,
            Speed = 4
        };
        CardList.Add(card25);

        var card26 = new ItemData()
        {
            Id = 26,
            Name = "Nadalya, Sword of Stars",
            ImageLocation = "Nadalya",

            ResourceDevotion = null,
            ResourceEnergy = 5,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 8,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Your hero has <b>Overwhelm</b> and <b>Empowered +2</b>. Their attack is increased by your <b>Empowered</b> value.
Whenever your hero attacks and kills a unit, add three ""Magic Missile"" cards to your hand.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered, Tags.Magic, Tags.Sword, Tags.Overwhelm },
            Synergies = new List<Synergies> { Synergies.Energy, Synergies.Blademaster, Synergies.Empowered, Synergies.SmallSpells, Synergies.Mana, Synergies.Value, Synergies.Equip, Synergies.SplitDamage },
            ItemTag = "Magic Sword",
            Durability = 3,
        };
        CardList.Add(card26);

        var card27 = new SpellData()
        {
            Id = 27,
            Name = "Magic Missiles",
            ImageLocation = "Magic_Missiles",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 1,
            ResourceWild = null,
            ResourceNeutral = null,

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
            Name = "Runeblade Tier2",
            ImageLocation = "Runeblade2",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero</b>
<b>Arcane Bolt (2 Energy, 1 Action):</b> Deal 2 damage to a unit within range 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Runeblade, Tags.Ability },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Runeblade",
            Attack = 7,
            Health = 16,
            Range = 0,
            Speed = 4
        };
        CardList.Add(card28);

        var card29 = new UnitData()
        {
            Id = 29,
            Name = "Runeblade Tier3",
            ImageLocation = "Runeblade3",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero</b>
<b>Arcane Bolt (2 Energy, 1 Action):</b> Deal 2 damage to a unit within range 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Runeblade,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Runeblade, Tags.Ability },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Runeblade",
            Attack = 9,
            Health = 27,
            Range = 0,
            Speed = 5
        };
        CardList.Add(card29);

        var card30 = new UnitData()
        {
            Id = 30,
            Name = "Arcanist Tier1",
            ImageLocation = "Arcanist1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Arcane Knowledge (3 Knowledge, 1 Action):</b> Add a random playable spell to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Arcanist },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Arcanist",
            Attack = 4,
            Health = 5,
            Range = 3,
            Speed = 2
        };
        CardList.Add(card30);

        var card31 = new UnitData()
        {
            Id = 31,
            Name = "Arcanist Tier2",
            ImageLocation = "Arcanist2",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Arcane Knowledge (3 Knowledge, 1 Action):</b> Add a random playable spell to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Arcanist },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Arcanist",
            Attack = 6,
            Health = 11,
            Range = 3,
            Speed = 2
        };
        CardList.Add(card31);

        var card32 = new UnitData()
        {
            Id = 32,
            Name = "Arcanist Tier3",
            ImageLocation = "Arcanist3",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Arcane Knowledge (3 Knowledge, 1 Action):</b> Add a random playable spell to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Arcanist },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Arcanist",
            Attack = 7,
            Health = 20,
            Range = 4,
            Speed = 2
        };
        CardList.Add(card32);

        var card33 = new SpellData()
        {
            Id = 33,
            Name = "Arcane Spike",
            ImageLocation = "Arcane_Spike",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 2,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Deal 3 damage to a unit. If that kills it, return this card to your hand at the end of your turn.",
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
            ImageLocation = "Battlemage",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 4,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Conduit, Empowered +2
Magic Missiles (2 Mana, 1 Action):</b> Deal 2 damage randomly split among all enemies in an area of Cone 3",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Arcanist, Tags.Empowered, Tags.Conduit },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Melee, Synergies.Summon, Synergies.SplitDamage },
            UnitTag = "Human Arcanist",
            Attack = 4,
            Health = 3,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card34);

        var card35 = new UnitData()
        {
            Id = 35,
            Name = "Kelari Librarian",
            ImageLocation = "Kelari_Librarian",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 1,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Deployment:</b> Use <b>Studious Research.</b> This use doesn't reduce the number of <b>Inspiration</b> cards shuffled.
<b>Studious Research (1 Knowledge, 1 Action): Study (3)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Elven, Tags.Deployment, Tags.StudyGain, Tags.Scholar },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Deployment, Synergies.Study },
            UnitTag = "Elven Scholar",
            Attack = 1,
            Health = 3,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card35);

        var card36 = new SpellData()
        {
            Id = 36,
            Name = "InspirationArcanist",
            ImageLocation = "InspirationArcanist",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 0,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Cast When Drawn</b>
Increase your base Knowledge rate by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.StudyGain, Tags.CastWhenDrawn },
            Synergies = new List<Synergies> { },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card36);

        var card37 = new SpellData()
        {
            Id = 37,
            Name = "Power Investment",
            ImageLocation = "Power_Investment",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 2,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Spark_of_Power",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 3,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Arcane_Golem",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 5,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon, Warden</b>
After you cast a spell, gain +1 Attack, +1 Health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Arcane, Tags.Warden },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.SmallSpells, Synergies.Durable, Synergies.Summon, Synergies.Defensive },
            UnitTag = "Arcane Summon",
            Attack = 5,
            Health = 5,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card39);

        var card40 = new ItemData()
        {
            Id = 40,
            Name = "Counterspell",
            ImageLocation = "CounterspellItem",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 1,
            ResourceMana = 2,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Whenever an enemy casts a spell within range 3, prevent it from being cast and gain mana equal to its total cost",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.ManaGain, Tags.Equip },
            Synergies = new List<Synergies> { },
            ItemTag = "Conjured Spell",
            Durability = 1,
        };
        CardList.Add(card40);

        var card41 = new SpellData()
        {
            Id = 41,
            Name = "Counterspell",
            ImageLocation = "Counterspell",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 1,
            ResourceMana = 2,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Equip a ""Counterspell"" item. If you already have a ""Counterspell"" item equipped, instead increase its durability by 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Equip },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Antimagic, Synergies.Mana, Synergies.Defensive, Synergies.Equip },
            SpellType = "Equip",
            Range = 0,
        };
        CardList.Add(card41);

        var card42 = new SpellData()
        {
            Id = 42,
            Name = "Dispel Magic",
            ImageLocation = "Dispel_Magic",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 1,
            ResourceMana = 1,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Kelari_Astromancer",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 6,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Deployment: Divinate (2)
Stargaze (1 Action): Divinate (1)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Arcanist, Tags.Elven, Tags.Deployment, Tags.Divinate },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Deployment, Synergies.Study, Synergies.Prediction, Synergies.LongRange },
            UnitTag = "Elven Arcanist",
            Attack = 2,
            Health = 6,
            Range = 3,
            Speed = 2
        };
        CardList.Add(card43);

        var card44 = new SpellData()
        {
            Id = 44,
            Name = "Polymorph",
            ImageLocation = "Polymorph",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 3,
            ResourceMana = 3,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Transform a unit into a ""Pig""",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Transformation, Tags.SingleRemoval },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Control, Synergies.Antimagic, Synergies.Removal },
            SpellType = "Enchantment",
            Range = 3,
        };
        CardList.Add(card44);

        var card45 = new UnitData()
        {
            Id = 45,
            Name = "Pig",
            ImageLocation = "Pig",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Transformed, Tags.Beast },
            Synergies = new List<Synergies> { },
            UnitTag = "Transformed Beast",
            Attack = 1,
            Health = 1,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card45);

        var card46 = new UnitData()
        {
            Id = 46,
            Name = "Arcane Spirit",
            ImageLocation = "Arcane_Spirit",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 4,
            ResourceWild = null,
            ResourceNeutral = null,

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
            UnitTag = "Arcane Summon",
            Attack = 2,
            Health = 3,
            Range = 2,
            Speed = 3
        };
        CardList.Add(card46);

        var card47 = new UnitData()
        {
            Id = 47,
            Name = "Callardis Academic",
            ImageLocation = "Callardis_Academic",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 4,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Deployment: Study (4)</b>
Whenever your draw an <b>Inspiration</b> card, your Knowledge gain rate is increased by an additional point. ",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Deployment, Tags.StudyGain, Tags.Scholar },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Draw, Synergies.Deployment, Synergies.Value, Synergies.Study },
            UnitTag = "Human Scholar",
            Attack = 3,
            Health = 5,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card47);

        var card48 = new UnitData()
        {
            Id = 48,
            Name = "Callardis Conjurer",
            ImageLocation = "Callardis_Conjurer",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Tiles adjacent to this unit are part of your deployment zone",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Arcanist },
            Synergies = new List<Synergies> { Synergies.Mobility, Synergies.Midrange, Synergies.Deployment, Synergies.Vanguard, Synergies.Prepared },
            UnitTag = "Human Arcanist",
            Attack = 2,
            Health = 5,
            Range = 2,
            Speed = 3
        };
        CardList.Add(card48);

        var card49 = new SpellData()
        {
            Id = 49,
            Name = "Homing Bolt",
            ImageLocation = "Homing_Bolt",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 4,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Deal 3 damage to an enemy unit.If the spell kills it, deal 3 damage to another random enemy within range 2. Repeat until a unit doesn't die or there isn't another enemy unit to target",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Rare,
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
            ImageLocation = "Archmage_Staff",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 3,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Kelari_Spellguard",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 6,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Warden
Deployment</b> and <b>Last Rites:</b> Add a random playable spell to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Arcanist, Tags.Elven, Tags.Warden, Tags.Deployment, Tags.LastRites },
            Synergies = new List<Synergies> { Synergies.Deployment, Synergies.BigMinions, Synergies.Defensive, Synergies.Value, Synergies.Study, Synergies.ShortRange, Synergies.LastRites },
            UnitTag = "Elven Arcanist",
            Attack = 3,
            Health = 7,
            Range = 1,
            Speed = 2
        };
        CardList.Add(card51);

        var card52 = new SpellData()
        {
            Id = 52,
            Name = "Tome of Power",
            ImageLocation = "Tome_Of_Power",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 5,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Archmage_Tholas",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 8,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Conduit</b>
After you cast a spell, add a random playable spell to your hand and reduce its cost by (2)",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Arcanist, Tags.Conduit },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Draw, Synergies.Summon, Synergies.BigMinions, Synergies.Value, Synergies.Study },
            UnitTag = "Human Arcanist",
            Attack = 3,
            Health = 8,
            Range = 3,
            Speed = 2
        };
        CardList.Add(card53);

        var card54 = new SpellData()
        {
            Id = 54,
            Name = "Enlightenment",
            ImageLocation = "Enlightenment",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 7,
            ResourceMana = 5,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Creative_Mind",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 7,
            ResourceMana = 5,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Empowered +3</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered },
            Synergies = new List<Synergies> { },
            ItemTag = "Arcane Mind",
            Durability = 5,
        };
        CardList.Add(card55);

        var card56 = new ItemData()
        {
            Id = 56,
            Name = "Deep Mind",
            ImageLocation = "Deep_Mind",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 7,
            ResourceMana = 5,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Empowered +3</b>
When you select this form, draw 3 cards",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Draw, Tags.Empowered },
            Synergies = new List<Synergies> { },
            ItemTag = "Arcane Mind",
            Durability = 5,
        };
        CardList.Add(card56);

        var card57 = new ItemData()
        {
            Id = 57,
            Name = "Devastating Mind",
            ImageLocation = "Devastating_Mind",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 7,
            ResourceMana = 5,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Empowered +3</b>
Your hero's attack is increased by your <b>Empowered</b> value. Whenever your hero kills a unit, any excess damage is randomly split among all enemy units within Range 2 of the killed unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered },
            Synergies = new List<Synergies> { },
            ItemTag = "Arcane Mind",
            Durability = 5,
        };
        CardList.Add(card57);

        var card58 = new ItemData()
        {
            Id = 58,
            Name = "Protected Mind",
            ImageLocation = "Protected_Mind",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 7,
            ResourceMana = 5,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Empowered +3</b>
At the end of your turn, your hero gains <b>Protected (12).</b> Remove any <b>Protected</b> gained in this way at the start of your next turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered, Tags.Protected },
            Synergies = new List<Synergies> { },
            ItemTag = "Arcane Mind",
            Durability = 5,
        };
        CardList.Add(card58);

        var card59 = new ItemData()
        {
            Id = 59,
            Name = "Replicative Mind",
            ImageLocation = "Replicative_Mind",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = 7,
            ResourceMana = 5,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Empowered +3</b>
Whenever you cast a spell, cast it again on the same target",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Arcanist,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Empowered },
            Synergies = new List<Synergies> { },
            ItemTag = "Arcane Mind",
            Durability = 5,
        };
        CardList.Add(card59);

        var card60 = new UnitData()
        {
            Id = 60,
            Name = "Abyssal Tier1",
            ImageLocation = "Abyssal1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Conjure Voidling (3 Mana):</b> Deploy a Voidling adjacent to your hero",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Abyssal },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Abyssal",
            Attack = 3,
            Health = 7,
            Range = 3,
            Speed = 2
        };
        CardList.Add(card60);

        var card61 = new UnitData()
        {
            Id = 61,
            Name = "Abyssal Tier2",
            ImageLocation = "Abyssal2",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Conjure Voidling (3 Mana):</b> Deploy a Voidling adjacent to your hero",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Abyssal },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Abyssal",
            Attack = 4,
            Health = 15,
            Range = 3,
            Speed = 2
        };
        CardList.Add(card61);

        var card62 = new UnitData()
        {
            Id = 62,
            Name = "Abyssal Tier3",
            ImageLocation = "Abyssal3",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Conjure Voidling (3 Mana):</b> Deploy a Voidling adjacent to your hero",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Abyssal },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Abyssal",
            Attack = 5,
            Health = 26,
            Range = 3,
            Speed = 3
        };
        CardList.Add(card62);

        var card63 = new UnitData()
        {
            Id = 63,
            Name = "Voidling",
            ImageLocation = "Voidling",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 3,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon, Warden</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Warden, Tags.Void },
            Synergies = new List<Synergies> { },
            UnitTag = "Void Summon",
            Attack = 3,
            Health = 3,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card63);

        var card64 = new UnitData()
        {
            Id = 64,
            Name = "Abyss Imp",
            ImageLocation = "Abyss_Imp",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 1,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Deployment:</b> Discard a card
<b>Last Rites:</b> Shuffle an Abyss Imp into your deck. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Deployment, Tags.LastRites, Tags.Void, Tags.Abomination, Tags.Discard },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Draw, Synergies.Swarm, Synergies.LastRites, Synergies.Discard, Synergies.Void, Synergies.Sacrifice },
            UnitTag = "Void Abomination",
            Attack = 3,
            Health = 3,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card64);

        var card65 = new UnitData()
        {
            Id = 65,
            Name = "Abyssal Cultist",
            ImageLocation = "Abyssal_Cultist",

            ResourceDevotion = 2,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Shadowy Ritual (1 Action): Prayer +1</b>
Whenever this kills a unit, deploy a <b>Void Soul</b> in its place",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Abyssal, Tags.PrayerGain },
            Synergies = new List<Synergies> { Synergies.Midrange, Synergies.Swarm, Synergies.Void, Synergies.Sacrifice, Synergies.Prayer },
            UnitTag = "Human Abyssal",
            Attack = 2,
            Health = 1,
            Range = 2,
            Speed = 2
        };
        CardList.Add(card65);

        var card66 = new SpellData()
        {
            Id = 66,
            Name = "Bite",
            ImageLocation = "Bite",

            ResourceDevotion = 2,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 1,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Lifebond</b>
Deal 4 damage to a unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.Lifebond },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Control, Synergies.SingleDamage, Synergies.Restoration },
            SpellType = "Damage",
            Range = 1,
        };
        CardList.Add(card66);

        var card67 = new SpellData()
        {
            Id = 67,
            Name = "Dark Pact",
            ImageLocation = "Dark_Pact",

            ResourceDevotion = 3,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Void_Soul",

            ResourceDevotion = 1,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Ethereal</b>
Has +1 Attack, +1 Health for ever other friendly Void unit within Range 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ethereal, Tags.Void, Tags.Spirit },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Ethereal, Synergies.Swarm, Synergies.Void, Synergies.Sacrifice },
            UnitTag = "Void Spirit",
            Attack = 1,
            Health = 1,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card68);

        var card69 = new SpellData()
        {
            Id = 69,
            Name = "Void Touch",
            ImageLocation = "Void_Touch",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 4,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Give a friendly unit with <b>Summon</b> +4 Attack, +4 Health. Gain additional Attack and Health points equal to your <b>Empowered</b> value.
Deal damage to the caster equal to the additional points gained.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Enchantment },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Summon, Synergies.Restoration, Synergies.SelfDamage },
            SpellType = "Enchantment",
            Range = 1,
        };
        CardList.Add(card69);

        var card70 = new UnitData()
        {
            Id = 70,
            Name = "Abyssal Dreadspeaker",
            ImageLocation = "Abyssal_Dreadspeaker",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 4,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Conduit, Empowered +1</b>
Whenever you discard a card or a friendly unit dies within Range 2, draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Empowered, Tags.Conduit },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Summon, Synergies.Midrange, Synergies.Swarm, Synergies.Death, Synergies.Discard, Synergies.Sacrifice },
            UnitTag = "Human Abyssal",
            Attack = 2,
            Health = 3,
            Range = 2,
            Speed = 2
        };
        CardList.Add(card70);

        var card71 = new SpellData()
        {
            Id = 71,
            Name = "Blood Pact",
            ImageLocation = "Blood_Pact",

            ResourceDevotion = 2,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Destroy a friendly unit. Restore health equal to the destroyed unit's health to another unit. Draw a card",
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
            ImageLocation = "Dreadbolt",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 1,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Deal 4 damage to a unit. Deal an equal amount of damage to the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.SelfDamage },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.SingleDamage, Synergies.SelfDamage },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card72);

        var card73 = new UnitData()
        {
            Id = 73,
            Name = "Vampire Aristocrat",
            ImageLocation = "Vampire_Aristocrat",

            ResourceDevotion = 6,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Lifebond</b>
At the start of your turn, <b>Regenerate</b>
Whenever this unit takes damage, <b>Prayer +2</b> and draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Lifebond, Tags.Vampire, Tags.Noble, Tags.Regenerate },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Draw, Synergies.Durable, Synergies.BigMinions, Synergies.Prayer, Synergies.Restoration },
            UnitTag = "Vampire Noble",
            Attack = 5,
            Health = 5,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card73);

        var card74 = new UnitData()
        {
            Id = 74,
            Name = "Vampire Courtesan",
            ImageLocation = "Vampire_Courtesan",

            ResourceDevotion = 4,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Lifebond
Lifedrain (2 Devotion, 1 Action):</b> Deal 3 damage to a unit. Heal this unit for the amount of damage dealt",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Lifebond, Tags.Vampire, Tags.Noble },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.Durable, Synergies.SingleDamage, Synergies.Restoration },
            UnitTag = "Vampire Noble",
            Attack = 4,
            Health = 4,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card74);

        var card75 = new UnitData()
        {
            Id = 75,
            Name = "Abyss Knight",
            ImageLocation = "Abyss_Knight",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon, Warden</b>
Whenever you discard a card, gain Attack and Health equal to its total cost",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Warden, Tags.Void, Tags.Abomination },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Durable, Synergies.Summon, Synergies.Mana, Synergies.BigMinions, Synergies.Defensive, Synergies.Discard, Synergies.Void },
            UnitTag = "Void Summon",
            Attack = 5,
            Health = 7,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card75);

        var card76 = new UnitData()
        {
            Id = 76,
            Name = "Abyssal Summoner",
            ImageLocation = "Abyssal_Summoner",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 3,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Deployment:</b> You can <b>Summon</b> one additional unit for the rest of the scenario. Deal 3 damage to your hero",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Deployment, Tags.Abyssal, Tags.SelfDamage },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Summon, Synergies.Deployment, Synergies.ShortRange, Synergies.Restoration, Synergies.SelfDamage },
            UnitTag = "Human Abyssal",
            Attack = 3,
            Health = 3,
            Range = 1,
            Speed = 2
        };
        CardList.Add(card76);

        var card77 = new UnitData()
        {
            Id = 77,
            Name = "Eye of the Void",
            ImageLocation = "Eye_of_the_Void",

            ResourceDevotion = 3,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 5,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon, Flying</b>
Whenever this attacks and kills a unit, deploy a ""Void Soul"" in its place",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Void, Tags.Abomination, Tags.Flying },
            Synergies = new List<Synergies> { Synergies.Midrange, Synergies.Mana, Synergies.Swarm, Synergies.Void, Synergies.Sacrifice, Synergies.Flying },
            UnitTag = "Void Summon",
            Attack = 3,
            Health = 5,
            Range = 2,
            Speed = 2
        };
        CardList.Add(card77);

        var card78 = new UnitData()
        {
            Id = 78,
            Name = "Imp Mother",
            ImageLocation = "Imp_Mother",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon, Warden
Brood Spawn (2 Mana, 1 Action):</b> Discard a card. Deploy two Abyss Imps beside this unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Summon, Tags.Warden, Tags.Void, Tags.Discard },
            Synergies = new List<Synergies> { Synergies.Summon, Synergies.Mana, Synergies.Swarm, Synergies.BigMinions, Synergies.Defensive, Synergies.ShortRange, Synergies.Discard, Synergies.Void, Synergies.Sacrifice },
            UnitTag = "Void Summon",
            Attack = 3,
            Health = 9,
            Range = 1,
            Speed = 2
        };
        CardList.Add(card78);

        var card79 = new UnitData()
        {
            Id = 79,
            Name = "Abyssal Voidcaller",
            ImageLocation = "Abyssal_Voidcaller",

            ResourceDevotion = 4,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 5,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Deployment:</b> Use <b>Call of the Void
Call of the Void (2 Mana, 1 Action):</b> Add a random Void unit to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Deployment, Tags.Abyssal },
            Synergies = new List<Synergies> { Synergies.Mana, Synergies.Deployment, Synergies.Value, Synergies.LongRange, Synergies.Void },
            UnitTag = "Human Abyssal",
            Attack = 4,
            Health = 5,
            Range = 3,
            Speed = 2
        };
        CardList.Add(card79);

        var card80 = new UnitData()
        {
            Id = 80,
            Name = "Soul Consumer",
            ImageLocation = "Soul_Consumer",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 7,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Consume (1 Action):</b> Discard a card. Gain Mana equal to its total cost.
Whenever this kills a unit, return a random card you discarded this game to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.ManaGain, Tags.Void, Tags.Abomination, Tags.Discard },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Mana, Synergies.BigMinions, Synergies.Death, Synergies.Discard, Synergies.Void },
            UnitTag = "Void Abomination",
            Attack = 4,
            Health = 12,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card80);

        var card81 = new SpellData()
        {
            Id = 81,
            Name = "The Void Hungers",
            ImageLocation = "The_Void_Hungers",

            ResourceDevotion = 1,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 3,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Destroy a friendly unit. Deal damage to another unit equal to the destroyed unit's health",
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
            ImageLocation = "Abysslord_Marrex",

            ResourceDevotion = 5,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 7,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Deployment:</b> Use <b>Rally the Horde</b>
<b>Rally the Horde (2 Mana, 1 Action): Discard a card. Give all adjacent units Attack and Health equal to its total cost",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Deployment, Tags.Void, Tags.Discard, Tags.Noble },
            Synergies = new List<Synergies> { Synergies.Mana, Synergies.Swarm, Synergies.BigMinions, Synergies.Discard, Synergies.Void, Synergies.Prayer },
            UnitTag = "Void Noble",
            Attack = 8,
            Health = 11,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card82);

        var card83 = new SpellData()
        {
            Id = 83,
            Name = "Realm Convergence",
            ImageLocation = "Realm_Convergence",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"You can <b>Summon</b> three additional units and your <b>Summon</b> units cost (2) less for the rest of the scenario
Deal damage to your hero equal to half their remaining health",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Abyssal,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SelfDamage, Tags.PassiveSpell },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.BigSpells, Synergies.Summon, Synergies.Mana, Synergies.Restoration, Synergies.SelfDamage },
            SpellType = "Other",
            Range = 0,
        };
        CardList.Add(card83);

        var card84 = new UnitData()
        {
            Id = 84,
            Name = "Elementalist Tier1",
            ImageLocation = "Elementalist1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Elemental Power (3 Mana, 1 Action):</b> Gain <b>Empowered +2</b> until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Elementalist },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Elementalist",
            Attack = 5,
            Health = 5,
            Range = 2,
            Speed = 2
        };
        CardList.Add(card84);

        var card85 = new UnitData()
        {
            Id = 85,
            Name = "Elementalist Tier2",
            ImageLocation = "Elementalist2",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Elemental Power (3 Mana, 1 Action):</b> Gain <b>Empowered +2</b> until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Elementalist },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Elementalist",
            Attack = 7,
            Health = 11,
            Range = 2,
            Speed = 2
        };
        CardList.Add(card85);

        var card86 = new UnitData()
        {
            Id = 86,
            Name = "Elementalist Tier3",
            ImageLocation = "Elementalist3",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Elemental Power (3 Mana, 1 Action):</b> Gain <b>Empowered +2</b> until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Elementalist },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Elementalist",
            Attack = 9,
            Health = 20,
            Range = 2,
            Speed = 3
        };
        CardList.Add(card86);

        var card87 = new SpellData()
        {
            Id = 87,
            Name = "Fireball",
            ImageLocation = "Fireball",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 4,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Deal 3 damage to all units within an area of Radius 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.Fire },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.AreaDamage },
            SpellType = "Damage",
            Range = 4,
        };
        CardList.Add(card87);

        var card88 = new UnitData()
        {
            Id = 88,
            Name = "Goblin Blastmage",
            ImageLocation = "Goblin_Blastmage",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 3,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Empowered +1
FIREBLAST! (2 Mana, 1 Action):</b> Deal damage to all other units within Range 2 equal to your <b>Empowered</b> value",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Empowered, Tags.Elementalist, Tags.Fire, Tags.Goblin },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Midrange, Synergies.Goblin },
            UnitTag = "Goblin Elementalist",
            Attack = 1,
            Health = 2,
            Range = 2,
            Speed = 3
        };
        CardList.Add(card88);

        var card89 = new SpellData()
        {
            Id = 89,
            Name = "Ice Blast",
            ImageLocation = "Ice_Blast",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 2,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Deal 1 damage to a unit and <b>Stun</b> it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.SingleDamage, Tags.Water },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.Stun, Synergies.SingleDamage },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card89);

        var card90 = new SpellData()
        {
            Id = 90,
            Name = "Lightning Bolt",
            ImageLocation = "Lightning_Bolt",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 4,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Deal 3 damage to all units within an area of Line 6 from the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.Air },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.AreaDamage },
            SpellType = "Damage",
            Range = 0,
        };
        CardList.Add(card90);

        var card91 = new SpellData()
        {
            Id = 91,
            Name = "Mana Surge",
            ImageLocation = "Mana_Surge",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = 2,
            ResourceNeutral = null,

            Text = @"Increase your Mana by 3. Gain <b>Empowered +2</b> until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Empowered, Tags.ManaGain },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Mana },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card91);

        var card92 = new UnitData()
        {
            Id = 92,
            Name = "Wave Sorceror",
            ImageLocation = "Wave_Sorceror",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = 4,
            ResourceNeutral = null,

            Text = @"<b>Water Whip (2 Mana, 1 Action):</b> Choose a unit within Range 4. Deal 1 damage to it and pull it up to 1 tile closer. If the unit is hostile and adjacent to this unit, this unit attacks it.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Elven, Tags.Elementalist, Tags.Water, Tags.ForceMove },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Melee, Synergies.ForceMove },
            UnitTag = "Elven Elementalist",
            Attack = 3,
            Health = 6,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card92);

        var card93 = new UnitData()
        {
            Id = 93,
            Name = "Air Elemental",
            ImageLocation = "Air_Elemental",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon, Flying</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Flying, Tags.Air, Tags.Elemental },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Mobility, Synergies.Summon, Synergies.Mana, Synergies.BigMinions, Synergies.Flying },
            UnitTag = "Elemental Summon",
            Attack = 7,
            Health = 5,
            Range = 0,
            Speed = 4
        };
        CardList.Add(card93);

        var card94 = new UnitData()
        {
            Id = 94,
            Name = "Earth Elemental",
            ImageLocation = "Earth_Elemental",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon, Warden</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Warden, Tags.Elemental, Tags.Earth },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Summon, Synergies.Mana, Synergies.BigMinions, Synergies.Defensive },
            UnitTag = "Elemental Summon",
            Attack = 4,
            Health = 12,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card94);

        var card95 = new UnitData()
        {
            Id = 95,
            Name = "Fire Elemental",
            ImageLocation = "Fire_Elemental",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon Prepared</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Summon, Tags.Prepared, Tags.Fire, Tags.Elemental },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Summon, Synergies.Mana, Synergies.BigMinions, Synergies.Prepared },
            UnitTag = "Elemental Summon",
            Attack = 8,
            Health = 6,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card95);

        var card96 = new SpellData()
        {
            Id = 96,
            Name = "Tend the Elements",
            ImageLocation = "Tend_the_Elements",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = 3,
            ResourceNeutral = null,

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
            ImageLocation = "Water_Elemental",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Summon</b>
Whenever this unit deals damage to another unit, <b>Stun</b> it",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Stun, Tags.Summon, Tags.Water, Tags.Elemental },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Stun, Synergies.Summon, Synergies.Mana, Synergies.BigMinions },
            UnitTag = "Elemental Summon",
            Attack = 5,
            Health = 9,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card97);

        var card98 = new UnitData()
        {
            Id = 98,
            Name = "Earthbinder",
            ImageLocation = "Earthbinder",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 3,
            ResourceWild = 1,
            ResourceNeutral = null,

            Text = @"<b>Empowered +1
Earthspike (2 Mana, 1 Action):</b> Deal damage to all units in an area of Cone 3 equal to your <b>Empowered</b> value and <b>Root</b> them",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Dwarven, Tags.Empowered, Tags.Elementalist, Tags.Earth, Tags.Root },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Melee, Synergies.Root },
            UnitTag = "Dwarven Elementalist",
            Attack = 3,
            Health = 5,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card98);

        var card99 = new SpellData()
        {
            Id = 99,
            Name = "Elemental Rush",
            ImageLocation = "Elemental_Rush",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = 5,
            ResourceNeutral = null,

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
            ImageLocation = "Monk_of_the_Four_Winds",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = 6,
            ResourceNeutral = null,

            Text = @"<b>Deployment:</b> Use <b>Call of the Winds
Call of the Winds (3 Wild, 1 Action):</b> Draw a card. If it is a spell, reduce its cost by (3). <b>Cycle -3</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Draw, Tags.Deployment, Tags.Elementalist, Tags.Air, Tags.CycleMinus },
            Synergies = new List<Synergies> { Synergies.SmallSpells, Synergies.Mobility, Synergies.Draw, Synergies.BigSpells, Synergies.Deployment, Synergies.ShortRange, Synergies.Wild },
            UnitTag = "Human Elementalist",
            Attack = 3,
            Health = 3,
            Range = 1,
            Speed = 4
        };
        CardList.Add(card100);

        var card101 = new SpellData()
        {
            Id = 101,
            Name = "Pummel",
            ImageLocation = "Pummel",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = 2,
            ResourceNeutral = null,

            Text = @"Deal 3 damage to a unit. Move it up to 2 tiles away from the caster",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Rare,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage, Tags.ForceMove, Tags.Earth },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.SmallSpells, Synergies.SingleDamage, Synergies.ForceMove },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card101);

        var card102 = new SpellData()
        {
            Id = 102,
            Name = "Chain Lightning",
            ImageLocation = "Chain_Lightning",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 5,
            ResourceWild = 3,
            ResourceNeutral = null,

            Text = @"<b>Cycle -3</b>
Deal 6 damage to an enemy unit and 3 damage to all other enemy units within an area of Radius 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SplitDamage, Tags.Air, Tags.CycleMinus },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.BigSpells, Synergies.Mana },
            SpellType = "Damage",
            Range = 4,
        };
        CardList.Add(card102);

        var card103 = new SpellData()
        {
            Id = 103,
            Name = "Earthquake",
            ImageLocation = "Earthquake",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 6,
            ResourceWild = 8,
            ResourceNeutral = null,

            Text = @"Deal 4 damage to all units within an area of Radius 3 and increase the movement cost of all tiles in the area by 1 until the end of your next turn. At the start of your next turn, deal 4 damage to all units within the same area.",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.Earth },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.BigSpells, Synergies.AreaDamage, Synergies.Mana, Synergies.ForceMove, Synergies.Wild },
            SpellType = "Damage",
            Range = -1,
        };
        CardList.Add(card103);

        var card104 = new SpellData()
        {
            Id = 104,
            Name = "Wall of Fire",
            ImageLocation = "Wall_of_Fire",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 8,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Deal 5 damage to all units in an area of Wall 5. If any unit enters this area until the end of your next turn, they take 5 damage",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Epic,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.AreaDamage, Tags.Fire },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Control, Synergies.BigSpells, Synergies.Mana, Synergies.ForceMove },
            SpellType = "Damage",
            Range = 3,
        };
        CardList.Add(card104);

        var card105 = new UnitData()
        {
            Id = 105,
            Name = "Master Kybas",
            ImageLocation = "Master_Kybas",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 8,
            ResourceWild = 6,
            ResourceNeutral = null,

            Text = @"<b>Conduit, Cycle -6</b>
Reduce the cost of all spells generated by this unit to 0.
<b>Deployment:</b> Add all four of the basic Elemental Spells to your hand.
<b>Master of the Elements (2 Mana):</b> Add a basic Elemental Spell to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Human, Tags.Ability, Tags.Conduit, Tags.Deployment, Tags.Elementalist, Tags.Fire, Tags.Water, Tags.Air, Tags.Earth, Tags.CycleMinus },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Summon, Synergies.Mana, Synergies.Deployment, Synergies.BigMinions, Synergies.Value, Synergies.ShortRange, Synergies.Cycle, Synergies.Wild },
            UnitTag = "Human Elementalist",
            Attack = 5,
            Health = 5,
            Range = 1,
            Speed = 3
        };
        CardList.Add(card105);

        var card106 = new SpellData()
        {
            Id = 106,
            Name = "Tidal Wave",
            ImageLocation = "Tidal_Wave",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = 10,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"In an area of line 6 from the caster as well as both adjacent lines, deal 2 damage, <b>Stun</b> and push back 3 tiles all units in that area.
The damage of this spell is multiplied by your <b>Empowered</b> score instead of being added. The damage of this spell cannot be reduced below 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Elementalist,
            Rarity = Rarity.Legendary,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Stun, Tags.AreaDamage, Tags.Water, Tags.ForceMove },
            Synergies = new List<Synergies> { Synergies.Empowered, Synergies.Stun, Synergies.Control, Synergies.BigSpells, Synergies.AreaDamage, Synergies.Mana, Synergies.ForceMove },
            SpellType = "Damage",
            Range = 0,
        };
        CardList.Add(card106);

        var card107 = new UnitData()
        {
            Id = 107,
            Name = "Grovewatcher Tier1",
            ImageLocation = "Grovewatcher1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Plant Growth (2 Wild, 1 Action): Root</b> all enemy units in an area of Radius 2 within Range 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Root, Tags.Grovewatcher },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Grovewatcher",
            Attack = 2,
            Health = 11,
            Range = 2,
            Speed = 2
        };
        CardList.Add(card107);

        var card108 = new UnitData()
        {
            Id = 108,
            Name = "Grovewatcher Tier2",
            ImageLocation = "Grovewatcher2",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Plant Growth (2 Wild, 1 Action): Root</b> all enemy units in an area of Radius 2 within Range 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Root, Tags.Grovewatcher },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Grovewatcher",
            Attack = 2,
            Health = 19,
            Range = 3,
            Speed = 2
        };
        CardList.Add(card108);

        var card109 = new UnitData()
        {
            Id = 109,
            Name = "Grovewatcher Tier3",
            ImageLocation = "Grovewatcher3",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Plant Growth (2 Wild, 1 Action): Root</b> all enemy units in an area of Radius 2 within Range 2",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Root, Tags.Grovewatcher },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Grovewatcher",
            Attack = 3,
            Health = 28,
            Range = 4,
            Speed = 2
        };
        CardList.Add(card109);

        var card110 = new SpellData()
        {
            Id = 110,
            Name = "Grasping Vine",
            ImageLocation = "Grasping_Vine",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = 2,
            ResourceNeutral = null,

            Text = @"<b>Root</b> an enemy. Draw a card",
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
            ImageLocation = "Honour_the_Old_Gods",

            ResourceDevotion = 3,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Increase your Wild by 3. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Common,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.WildGain },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Wild },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card111);

        var card112 = new UnitData()
        {
            Id = 112,
            Name = "Sosthrim Druid",
            ImageLocation = "Sosthrim_Druid",

            ResourceDevotion = 2,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Whenever this attacks a unit <b>Root</b> it.
<b>Wild Ritual (1 Action): Prayer +1</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Ability, Tags.Elven, Tags.PrayerGain, Tags.Root, Tags.Grovewatcher },
            Synergies = new List<Synergies> { Synergies.Midrange, Synergies.Prayer, Synergies.Root },
            UnitTag = "Elven Grovewatcher",
            Attack = 1,
            Health = 3,
            Range = 2,
            Speed = 2
        };
        CardList.Add(card112);

        var card113 = new SpellData()
        {
            Id = 113,
            Name = "Juicy Fruit",
            ImageLocation = "Juicy_Fruit",

            ResourceDevotion = 0,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Sosthrim_Grovekeeper",

            ResourceDevotion = 4,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

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
            UnitTag = "Elven Grovewatcher",
            Attack = 3,
            Health = 6,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card114);

        var card115 = new UnitData()
        {
            Id = 115,
            Name = "Woodland Sprite",
            ImageLocation = "Woodland_Sprite",

            ResourceDevotion = 2,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = 3,
            ResourceNeutral = null,

            Text = @"<b>Lifebond, Spellshield</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Spellshield, Tags.Lifebond, Tags.Faerie, Tags.Soldier },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Antimagic, Synergies.Swarm, Synergies.Restoration, Synergies.Faerie },
            UnitTag = "Faerie Soldier",
            Attack = 3,
            Health = 3,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card115);

        var card116 = new UnitData()
        {
            Id = 116,
            Name = "Worldroot Sapling",
            ImageLocation = "Worldroot_Sapling",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = 1,
            ResourceNeutral = null,

            Text = @"At the start of each of your turns, gain 1 Wild",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Common,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Grovewatcher, Tags.WildGain, Tags.Treant },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Wild, Synergies.Treant },
            UnitTag = "Treant Grovewatcher",
            Attack = 0,
            Health = 5,
            Range = 0,
            Speed = 1
        };
        CardList.Add(card116);

        var card117 = new SpellData()
        {
            Id = 117,
            Name = "Earth Ritual",
            ImageLocation = "Earth_Ritual",

            ResourceDevotion = 2,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

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
            ImageLocation = "Faeries_Blessing",

            ResourceDevotion = 3,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Give a unit <b>Spellshield</b> and <b>Lifebond</b>",
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
            ImageLocation = "Patient_Harvest",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = 3,
            ResourceNeutral = null,

            Text = @"At the start of your next turn, gain 5 Wild and draw 2 cards",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.Draw, Tags.WildGain },
            Synergies = new List<Synergies> { Synergies.Draw, Synergies.Wild },
            SpellType = "Resource",
            Range = 0,
        };
        CardList.Add(card119);

        var card120 = new UnitData()
        {
            Id = 120,
            Name = "Sosthrim Harvester",
            ImageLocation = "Sosthrim Harvester",

            ResourceDevotion = 5,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Whenever a unit dies within Range 3, draw a card and <b>Prayer +2</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Grovewatcher,
            Rarity = Rarity.Uncommon,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Elven, Tags.PrayerGain, Tags.Grovewatcher },
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Swarm, Synergies.BigMinions, Synergies.Death, Synergies.Prayer },
            UnitTag = "Elven Grovewatcher",
            Attack = 4,
            Health = 8,
            Range = 0,
            Speed = 2
        };
        CardList.Add(card120);

        var card121 = new UnitData()
        {
            Id = 121,
            Name = "Agent Tier1",
            ImageLocation = "Agent1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Info Exchange (2 Gold, 1 Action):</b> Shuffle a card in your hand into your deck. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Agent },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Agent",
            Attack = 3,
            Health = 10,
            Range = 0,
            Speed = 4
        };
        CardList.Add(card121);

        var card122 = new UnitData()
        {
            Id = 122,
            Name = "Agent Tier2",
            ImageLocation = "Agent2",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Info Exchange (2 Gold, 1 Action):</b> Shuffle a card in your hand into your deck. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Agent },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Agent",
            Attack = 4,
            Health = 19,
            Range = 0,
            Speed = 4
        };
        CardList.Add(card122);

        var card123 = new UnitData()
        {
            Id = 123,
            Name = "Agent Tier3",
            ImageLocation = "Agent3",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Info Exchange (2 Gold, 1 Action):</b> Shuffle a card in your hand into your deck. Draw a card",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Agent,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Agent },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Agent",
            Attack = 6,
            Health = 25,
            Range = 1,
            Speed = 4
        };
        CardList.Add(card123);

        var card124 = new UnitData()
        {
            Id = 124,
            Name = "Captain Tier1",
            ImageLocation = "Captain1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Lead from the Front (3 Energy):</b> Equip a ""Battle Sword""",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Captain },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Captain",
            Attack = 5,
            Health = 10,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card124);

        var card125 = new ItemData()
        {
            Id = 125,
            Name = "Battle Sword",
            ImageLocation = "Battle_Sword",

            ResourceDevotion = null,
            ResourceEnergy = 2,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Whenever your hero attacks, gain +1 Attack and <b>Protected (1)</b> until the end of your turn",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Item,

            Tags = new List<Tags> { Tags.Protected, Tags.Sword, Tags.Metal },
            Synergies = new List<Synergies> { },
            ItemTag = "Metal Sword",
            Durability = 1,
        };
        CardList.Add(card125);

        var card126 = new UnitData()
        {
            Id = 126,
            Name = "Captain Tier2",
            ImageLocation = "Captain2",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Lead from the Front (3 Energy):</b> Equip a ""Battle Sword""",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Captain },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Captain",
            Attack = 5,
            Health = 20,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card126);

        var card127 = new UnitData()
        {
            Id = 127,
            Name = "Captain Tier3",
            ImageLocation = "Captain3",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Lead from the Front (3 Energy):</b> Equip a ""Battle Sword""",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Captain,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Captain },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Captain",
            Attack = 7,
            Health = 31,
            Range = 0,
            Speed = 4
        };
        CardList.Add(card127);

        var card128 = new UnitData()
        {
            Id = 128,
            Name = "Lifebringer Tier1",
            ImageLocation = "Lifebringer1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Healing Word (3 Devotion, 1 Action):</b> Restore 2 Health to a unit within range 1",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lifebringer,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Lifebringer },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Lifebringer",
            Attack = 1,
            Health = 12,
            Range = 1,
            Speed = 3
        };
        CardList.Add(card128);

        var card129 = new UnitData()
        {
            Id = 129,
            Name = "Lorekeeper Tier1",
            ImageLocation = "Lorekeeper1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Preserve Knowledge (3 Knowledge): Shuffle a copy of the next spell you cast into your deck",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Lorekeeper,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Lorekeeper },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Lorekeeper",
            Attack = 2,
            Health = 12,
            Range = 1,
            Speed = 2
        };
        CardList.Add(card129);

        var card130 = new UnitData()
        {
            Id = 130,
            Name = "Luminist Tier1",
            ImageLocation = "Luminist1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Foretell (2 Knowledge): Divinate 1</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Luminist,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Luminist },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Luminist",
            Attack = 2,
            Health = 9,
            Range = 2,
            Speed = 3
        };
        CardList.Add(card130);

        var card131 = new UnitData()
        {
            Id = 131,
            Name = "Mercenary Tier1",
            ImageLocation = "Mercenary1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Intimidate (3 Energy, 1 Action): Stun</b> an enemy unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Mercenary,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Mercenary },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Mercenary",
            Attack = 5,
            Health = 8,
            Range = 0,
            Speed = 4
        };
        CardList.Add(card131);

        var card132 = new UnitData()
        {
            Id = 132,
            Name = "Oathknight Tier1",
            ImageLocation = "Oathknight1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Holy Shield (3 Devotion, 1 Action): Give all friendly units within Range 1 of the hero <b>Protected (1)</b>",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Oathknight,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Oathknight },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Oathknight",
            Attack = 3,
            Health = 12,
            Range = 0,
            Speed = 3
        };
        CardList.Add(card132);

        var card133 = new UnitData()
        {
            Id = 133,
            Name = "Trickster Tier1",
            ImageLocation = "Trickster1",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = null,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"<b>Hero
Resupply (3 Gold):</b> Add a shiv to your hand",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Hero,
            CardType = CardTypes.Unit,

            Tags = new List<Tags> { Tags.Hero, Tags.Human, Tags.Ability, Tags.Trickster },
            Synergies = new List<Synergies> { },
            UnitTag = "Human Trickster",
            Attack = 6,
            Health = 7,
            Range = 0,
            Speed = 4
        };
        CardList.Add(card133);

        var card134 = new SpellData()
        {
            Id = 134,
            Name = "Shiv",
            ImageLocation = "Shiv",

            ResourceDevotion = null,
            ResourceEnergy = null,
            ResourceGold = 0,
            ResourceKnowledge = null,
            ResourceMana = null,
            ResourceWild = null,
            ResourceNeutral = null,

            Text = @"Deal 2 damage to a unit",
            LoreText = @"",
            Notes = @"",

            Set = Sets.Standard,
            Class = Classes.ClassList.Trickster,
            Rarity = Rarity.Uncollectable,
            CardType = CardTypes.Spell,

            Tags = new List<Tags> { Tags.SingleDamage },
            Synergies = new List<Synergies> { },
            SpellType = "Damage",
            Range = 1,
        };
        CardList.Add(card134);

        card24.RelatedCards = new List<CardData> { card21 };
        card26.RelatedCards = new List<CardData> { card27 };
        card35.RelatedCards = new List<CardData> { card36 };
        card37.RelatedCards = new List<CardData> { card36 };
        card41.RelatedCards = new List<CardData> { card40 };
        card44.RelatedCards = new List<CardData> { card45 };
        card47.RelatedCards = new List<CardData> { card36 };
        card54.RelatedCards = new List<CardData> { card55, card56, card57, card58, card59 };
        card60.RelatedCards = new List<CardData> { card63 };
        card61.RelatedCards = new List<CardData> { card63 };
        card62.RelatedCards = new List<CardData> { card63 };
        card65.RelatedCards = new List<CardData> { card68 };
        card77.RelatedCards = new List<CardData> { card68 };
        card78.RelatedCards = new List<CardData> { card64 };
        card105.RelatedCards = new List<CardData> { card87, card89, card90, card101 };
        card114.RelatedCards = new List<CardData> { card113 };
        card124.RelatedCards = new List<CardData> { card125 };
        card126.RelatedCards = new List<CardData> { card125 };
        card127.RelatedCards = new List<CardData> { card125 };
    }
}

namespace CategoryEnums
{
    public enum Tags
    {
        Blademaster, Hero, Human, Runeblade, Ability, EnergyGain, Enchantment, Swiftstrike, Stun, Draw, Dwarven, Arcanist, Empowered, Protected, AreaDamage, Elven, Conduit, Summon, Spellshield, Ethereal, Arcane, Warden, Prepared, Deployment, ManaGain, Equip, Magic, Sword, Overwhelm, SplitDamage, SingleDamage, StudyGain, Scholar, CastWhenDrawn, Spellbind, Divinate, Transformed, Beast, Transformation, SingleRemoval, Staff, LastRites, Abyssal, Void, Abomination, Discard, PrayerGain, Lifebond, Spirit, Sacrifice, SelfDamage, Vampire, Noble, Regenerate, Flying, PassiveSpell, Elemtalist, Elementalist, Fire, Goblin, Water, Air, ForceMove, Elemental, Earth, CyclePlus, Root, CycleMinus, ShortRange, Grovewatcher, WildGain, Faerie, Soldier, Treant, Agent, Captain, Metal, Lifebringer, Lorekeeper, Luminist, Mercenary, Oathknight, Trickster
    }

    public enum Synergies
    {
        Energy, Blademaster, Enchantment, Empowered, Melee, SmallSpells, Stun, Mobility, Control, Draw, Durable, Protected, BigSpells, AreaDamage, Antimagic, Summon, Midrange, Ethereal, Warden, Mana, Deployment, Swarm, BigMinions, Defensive, Value, Equip, SplitDamage, SingleDamage, Study, Prediction, LongRange, Removal, Vanguard, Prepared, Death, ShortRange, LastRites, Discard, Void, Sacrifice, Prayer, Restoration, SelfDamage, Flying, Goblin, ForceMove, Cycle, Root, Wild, Faerie, Treant
    }

    public enum Sets
    {
        Standard, Default
    }
}
