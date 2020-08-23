using System.Collections.Generic;
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
            Synergies = new List<Synergies> { Synergies.Melee, Synergies.Control, Synergies.Durable, Synergies.Antimagic, Synergies.Summon, Synergies.Ethereal, Synergies.Warden, Synergies.Defensive },
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
            ResourceMana = 0,
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

        card24.RelatedCards = new List<CardData> { card21 };
        card26.RelatedCards = new List<CardData> { card27 };
        card35.RelatedCards = new List<CardData> { card36 };
        card37.RelatedCards = new List<CardData> { card36 };
        card41.RelatedCards = new List<CardData> { card40 };
        card44.RelatedCards = new List<CardData> { card45 };
        card47.RelatedCards = new List<CardData> { card36 };
        card54.RelatedCards = new List<CardData> { card55, card56, card57, card58, card59 };
    }
}

namespace CategoryEnums
{
    public enum Tags
    {
        Blademaster, Hero, Human, Runeblade, Ability, EnergyGain, Enchantment, Swiftstrike, Stun, Draw, Dwarven, Arcanist, Empowered, Protected, AreaDamage, Elven, Conduit, Summon, Spellshield, Ethereal, Arcane, Warden, Prepared, Deployment, ManaGain, Equip, Magic, Sword, Overwhelm, SplitDamage, SingleDamage, StudyGain, Scholar, CastWhenDrawn, Spellbind, Divinate, Transformed, Beast, Transformation, SingleRemoval, Staff, LastRites
    }

    public enum Synergies
    {
        Energy, Blademaster, Enchantment, Empowered, Melee, SmallSpells, Stun, Mobility, Control, Draw, Durable, Protected, BigSpells, AreaDamage, Antimagic, Summon, Midrange, Ethereal, Warden, Mana, Deployment, Swarm, BigMinions, Defensive, Value, Equip, SplitDamage, SingleDamage, Study, Prediction, LongRange, Removal, Vanguard, Prepared, Death, ShortRange, LastRites
    }

    public enum Sets
    {
        Standard, Default
    }
}
