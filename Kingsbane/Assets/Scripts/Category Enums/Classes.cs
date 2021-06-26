using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

namespace CategoryEnums
{
    public class ClassResources
    {
        public Classes.ClassList thisClass;
        internal List<CardResources> resources;

        public ClassResources(Classes.ClassList _thisClass)
        {
            thisClass = _thisClass;
            resources = Classes.GetClassData(_thisClass).GetClassResources();
        }

        /// <summary>
        /// 
        /// Used for comparing Class Resources when used as dictionary key
        /// 
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ClassResources))
                return false;

            //Note: don't need to compare resources since they are dependent upon the class of the object
            return ((ClassResources)obj).thisClass == thisClass;
        }

        /// <summary>
        /// 
        /// Used for comparing Class Resources when used as dictionary key
        /// 
        /// </summary>
        public override int GetHashCode()
        {
            return thisClass.GetHashCode();
        }
    }

    public class ClassResourceType
    {
        public enum ResourceTypes
        {
            Dominant,
            Secondary
        }

        public ResourceTypes ResourceType { get; internal set; }
        public CardResources CardResource { get; internal set; }
    }

    public static class Classes
    {
        public const int NUM_CLASSES = 16; //This will always be equal to the number of actual classes plus one
        public enum ClassList
        {
            Default,
            Abyssal,
            Agent,
            Arcanist,
            Captain,
            Elementalist,
            Grovewatcher,
            Lifebringer,
            Lorekeeper,
            Luminist,
            Mercenary,
            Oathknight,
            Runeblade,
            Trickster,
            Waystalker,
            Wildkin,
            Token,
        };

        /// <summary>
        /// 
        /// Retrive the data of a particular class
        /// 
        /// </summary>
        public static ClassData GetClassData(ClassList neededClass)
        {
            return ClassDataList.FirstOrDefault(x => x.ThisClass == neededClass);
        }

        /// <summary>
        /// 
        /// Retrive the data of a particular class based on the utilised resources
        /// 
        /// </summary>
        public static ClassData GetClassData(List<CardResources> classResources)
        {
            if (classResources.Count != 2)
                throw new Exception("Not a valid number of resources provided");

            return ClassDataList.FirstOrDefault(x => x.ClassResources.Select(y => y.CardResource).All(classResources.Contains));
        }

        /// <summary>
        /// 
        /// List of the default class data. Pregenerated code
        /// 
        /// </summary>
        internal static List<ClassData> ClassDataList = new List<ClassData>()
        {
                //Default       (Dominant:Neutral, Secondary:Neutral)
                new ClassData(ClassList.Default)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Neutral },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Neutral },
                    },
                    IsPlayable = false,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "-" },
                        { ClassData.ClassDataFields.Strengths, "-" },
                        { ClassData.ClassDataFields.Weaknesses, "-" },
                    },
                },
                //Abyssal       (Dominant:Mana, Secondary:Devotion)
                new ClassData(ClassList.Abyssal)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Mana },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Devotion },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 16,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Abyssal,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                67,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 34,
                            Name = "Test",
                            DeckClass = ClassList.Abyssal,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                50,
                                50,
                                64,
                                65,
                                66,
                                67,
                                71,
                                72,
                                73,
                                74,
                                75,
                                75,
                                76,
                                77,
                                82,
                            },
                            UpgradeIdList = new List<int>()
                            {
                                1,
                                2,
                            },
                            HeroCardID = 1326,
                            InitialHandSize = 5,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerMana(10, 2),
                                new PlayerDevotion(2, 10),
                            },
                        },
                        new DeckSaveData()
                        {
                            Id = 35,
                            Name = "Dark Summoner",
                            DeckClass = ClassList.Abyssal,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                64,
                                65,
                                67,
                                69,
                                75,
                                76,
                                182,
                                205,
                                240,
                                321,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 36,
                            Name = "Void Swarm",
                            DeckClass = ClassList.Abyssal,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                48,
                                64,
                                67,
                                70,
                                77,
                                78,
                                120,
                                160,
                                205,
                                207,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 37,
                            Name = "Blooddrinkers",
                            DeckClass = ClassList.Abyssal,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                9,
                                66,
                                71,
                                72,
                                73,
                                74,
                                117,
                                159,
                                168,
                                236,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 89,
                            Name = "Shadowy Burial Deck",
                            DeckClass = ClassList.Abyssal,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                24,
                                24,
                                66,
                                66,
                                69,
                                69,
                                69,
                                72,
                                72,
                                81,
                                81,
                                83,
                                165,
                                165,
                                165,
                                168,
                                168,
                                205,
                                205,
                                229,
                                229,
                                235,
                                236,
                                236,
                                240,
                                240,
                                240,
                                240,
                                240,
                                245,
                                245,
                            },
                            UpgradeIdList = new List<int>()
                            {
                                105,
                                106,
                            },
                            HeroCardID = 1416,
                            InitialHandSize = 4,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerMana(18, 0),
                                new PlayerDevotion(0, 2),
                            },
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "The Abyssal are descendants of humans who long ago tried to harness the power of the Abyss, an expansive void filled with ancient creatures who’s only goal is to wipe out or conquer all living things. The process backfired on these people and the energy twisted them and all their descendants into monsters. Shunned by society, the Abyssal lived at the fringes of civilization, scrapping for work wherever they could find it. But while they lost their societal status, their transformation gave them a unique bond with the creatures of the Abyss, giving them the ability to use their powers and summon them to their side; however unlike their ancestors, the Abyssal of today understand that there is always a price for this power, and many are eager to pay it in exchange, whether that be their loyalty to these creatures, their health, their minions or their soul. While most Abyssal turn down dark paths due to their social isolation, some seek to aid others so that they may redeem their people in the eyes of others and undo the damage their ancestors did long ago. " },
                        { ClassData.ClassDataFields.Playstyle, "Aggressive to Mid-range" },
                        { ClassData.ClassDataFields.Strengths, "Powerful damage spells, strong but cheap minions, decent healing for hero, constant protection from a familiar" },
                        { ClassData.ClassDataFields.Weaknesses, "Non-resource costs (discard, hero health, sacrifices), slow units, limited direct removal" },
                    },
                },
                //Agent       (Dominant:Gold, Secondary:Knowledge)
                new ClassData(ClassList.Agent)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Gold },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Knowledge },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 17,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Agent,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                1383,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 38,
                            Name = "Spies and Infiltrators",
                            DeckClass = ClassList.Agent,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                190,
                                230,
                                261,
                                1381,
                                1383,
                                1384,
                                1385,
                                1388,
                                1390,
                                1394,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 39,
                            Name = "Deadly Assassins",
                            DeckClass = ClassList.Agent,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                183,
                                227,
                                232,
                                249,
                                1360,
                                1361,
                                1382,
                                1386,
                                1389,
                                1392,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 40,
                            Name = "Into the Shadows",
                            DeckClass = ClassList.Agent,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                241,
                                1328,
                                1360,
                                1382,
                                1384,
                                1387,
                                1389,
                                1391,
                                1393,
                                1395,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "While the utilisation of subterfuge is not something many would boast about, many understand its necessity to maintain order. That is where the Agents of Rudelia come into play. Masters of subtlety and spycraft, the Agent utilises their knowledge and understanding of the enemy against them, stealing and destroying their cards. While much more professional than other roguish types, the Agent isn’t against utilising underhanded tactics to gain an advantage, or hiring those who do. The Agent’s goal is not to win through force, but to control and manipulate the situation to gain the ultimate advantage before going in for the kill." },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range to Control" },
                        { ClassData.ClassDataFields.Strengths, "Excellent removal tools, manipulation of enemy decks, good value generation" },
                        { ClassData.ClassDataFields.Weaknesses, "Limited and weak minions, limited escape tools" },
                    },
                },
                //Arcanist       (Dominant:Knowledge, Secondary:Mana)
                new ClassData(ClassList.Arcanist)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Knowledge },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Mana },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 18,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Arcanist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                37,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 41,
                            Name = "Knowledge is Power",
                            DeckClass = ClassList.Arcanist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                35,
                                37,
                                38,
                                43,
                                47,
                                51,
                                190,
                                261,
                                265,
                                1328,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 42,
                            Name = "Magical Destruction",
                            DeckClass = ClassList.Arcanist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                15,
                                20,
                                27,
                                33,
                                34,
                                35,
                                38,
                                39,
                                90,
                                236,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 43,
                            Name = "Arcane Master",
                            DeckClass = ClassList.Arcanist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                33,
                                35,
                                37,
                                41,
                                42,
                                44,
                                46,
                                51,
                                229,
                                1336,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 93,
                            Name = "Forbidden Ritual Deck",
                            DeckClass = ClassList.Arcanist,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                20,
                                20,
                                20,
                                34,
                                34,
                                35,
                                35,
                                35,
                                37,
                                37,
                                37,
                                38,
                                38,
                                41,
                                41,
                                41,
                                42,
                                42,
                                48,
                                48,
                                49,
                                49,
                                51,
                                51,
                                51,
                                52,
                                52,
                                52,
                                54,
                                54,
                                64,
                                64,
                                64,
                                69,
                                69,
                                69,
                                70,
                                70,
                                75,
                                75,
                                75,
                                76,
                                76,
                                76,
                                77,
                                77,
                                77,
                                78,
                                78,
                                78,
                                80,
                                80,
                                82,
                                82,
                                83,
                                83,
                                87,
                                87,
                                183,
                                183,
                                183,
                                192,
                                192,
                                196,
                                236,
                                236,
                                240,
                                240,
                                245,
                                245,
                                321,
                                321,
                                321,
                                1328,
                                1328,
                                1334,
                                1334,
                                1345,
                                1345,
                                1351,
                            },
                            UpgradeIdList = new List<int>()
                            {
                                102,
                                103,
                                104,
                            },
                            HeroCardID = 1420,
                            InitialHandSize = 6,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerKnowledge(3, 0),
                                new PlayerMana(30, 0),
                            },
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Arcanists are arcane spellcasters who seek to understand and control the strange energies of magic that suffuse the world. Through patience and study, the Arcanist believes they can become masters of the arcane and the most powerful spellcasters in the world. Their allies are those who seek a fraction of such knowledge and will serve their masters in exchange for such power. While the Arcanist is a valuable on the field for their immense magical power, they are also extremely vulnerable to their foe, and those who are able to get in close quarters with the Arcanist will find them quite easy prey; the issue is getting close enough before being worn down by the arcane magic the Arcanist wields. " },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range" },
                        { ClassData.ClassDataFields.Strengths, "Strong chip damage spells, good value generation, good ranged units" },
                        { ClassData.ClassDataFields.Weaknesses, "Limited defensive tools, no healing, slow units" },
                    },
                },
                //Captain       (Dominant:Energy, Secondary:Knowledge)
                new ClassData(ClassList.Captain)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Energy },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Knowledge },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 19,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Captain,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                250,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 44,
                            Name = "Master Swordsman",
                            DeckClass = ClassList.Captain,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                7,
                                11,
                                13,
                                250,
                                259,
                                262,
                                264,
                                266,
                                336,
                                1333,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 45,
                            Name = "Ultimate Tactician",
                            DeckClass = ClassList.Captain,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                206,
                                212,
                                249,
                                254,
                                260,
                                261,
                                263,
                                265,
                                335,
                                1391,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 46,
                            Name = "We Are Legion",
                            DeckClass = ClassList.Captain,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                209,
                                249,
                                250,
                                252,
                                253,
                                254,
                                255,
                                267,
                                329,
                                1331,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 83,
                            Name = "Test 2",
                            DeckClass = ClassList.Captain,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                249,
                                252,
                                253,
                                254,
                                255,
                                260,
                                263,
                                267,
                                273,
                            },
                            UpgradeIdList = new List<int>()
                            {
                            },
                            HeroCardID = 1326,
                            InitialHandSize = 3,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerEnergy(10, 2),
                                new PlayerKnowledge(10, 2),
                            },
                        },
                        new DeckSaveData()
                        {
                            Id = 86,
                            Name = "Settler Invasion Deck",
                            DeckClass = ClassList.Captain,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                11,
                                206,
                                206,
                                209,
                                209,
                                212,
                                212,
                                215,
                                249,
                                249,
                                250,
                                250,
                                252,
                                252,
                                252,
                                254,
                                254,
                                254,
                                254,
                                255,
                                255,
                                259,
                                260,
                                262,
                                262,
                                263,
                                263,
                                266,
                                268,
                                269,
                                270,
                            },
                            UpgradeIdList = new List<int>()
                            {
                                99,
                            },
                            HeroCardID = 1413,
                            InitialHandSize = 4,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerEnergy(4, 3),
                                new PlayerKnowledge(2, 0),
                            },
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Battle-worn and experienced, the Captains or Rudellia are master tacticians who have studied the battlefield and learned how to control it and their foe to gain the upper hand. Beyond their skills in tactics, Captains are also skilled warriors, peerless in their mastery of the blade and are able to stand toe to toe with any who dare face them. Their armies are the most professional in Rudellia, with skills wide and varied to suit any situation. While this versatility is useful, it does mean that they are not particularly focused on any particular strategy. The Captain looks to find the weakness of the enemy and change their strategy on the fly to counter it as best they can. " },
                        { ClassData.ClassDataFields.Playstyle, "Versatile" },
                        { ClassData.ClassDataFields.Strengths, "Strong unit base and hero, versatile units (choose mechanics), ability to manipulate the battlefield, wide buffs" },
                        { ClassData.ClassDataFields.Weaknesses, "Limited damage or removal spells, versatility makes units quite unfocused" },
                    },
                },
                //Elementalist       (Dominant:Mana, Secondary:Wild)
                new ClassData(ClassList.Elementalist)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Mana },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Wild },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 20,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Elementalist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                91,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 47,
                            Name = "Elemental Fury",
                            DeckClass = ClassList.Elementalist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                20,
                                34,
                                87,
                                88,
                                90,
                                91,
                                93,
                                95,
                                99,
                                1329,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 48,
                            Name = "Push and Pull",
                            DeckClass = ClassList.Elementalist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                9,
                                89,
                                92,
                                94,
                                97,
                                98,
                                101,
                                110,
                                140,
                                229,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 49,
                            Name = "Restore Balance",
                            DeckClass = ClassList.Elementalist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                9,
                                33,
                                46,
                                90,
                                91,
                                96,
                                100,
                                236,
                                1329,
                                1344,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 92,
                            Name = "Into the Flames Deck",
                            DeckClass = ClassList.Elementalist,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                9,
                                9,
                                9,
                                16,
                                16,
                                18,
                                18,
                                20,
                                20,
                                34,
                                34,
                                50,
                                50,
                                50,
                                87,
                                87,
                                87,
                                87,
                                88,
                                88,
                                91,
                                91,
                                91,
                                94,
                                94,
                                95,
                                95,
                                96,
                                96,
                                98,
                                98,
                                98,
                                99,
                                99,
                                101,
                                101,
                                101,
                                103,
                                103,
                                104,
                                104,
                                104,
                                110,
                                110,
                                119,
                                119,
                                140,
                                140,
                                298,
                                298,
                            },
                            UpgradeIdList = new List<int>()
                            {
                                111,
                                112,
                            },
                            HeroCardID = 1419,
                            InitialHandSize = 5,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerMana(24, 0),
                                new PlayerWild(3, 10),
                            },
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Elementalists are masters of the four elements; air, earth, fire and water. They seek to utilise the explosive power of the elements against their foe, assaulting them with strong area of effect spells to prevent them from gaining the upper hand. By connecting with the wild magics of the world, they look to empower and enhance their spells in order to gain the upper hand. However their physical form is quite weak and it would not take much to overwhelm and eliminate them. As such, they have the ability to summon powerful elemental spirits to protect them, each mirroring themselves after one of the four elements. The Elementalist seeks to eliminate their foe quickly and prevent them from gaining the upper hand, for fear that they will be overwhelmed." },
                        { ClassData.ClassDataFields.Playstyle, "Aggressive" },
                        { ClassData.ClassDataFields.Strengths, "High damage area of effect spells, good empowered synergies, spell cost reductions, Manipulation of enemy positions" },
                        { ClassData.ClassDataFields.Weaknesses, "Vulnerable hero, limited units, weak single target damage" },
                    },
                },
                //Grovewatcher       (Dominant:Wild, Secondary:Devotion)
                new ClassData(ClassList.Grovewatcher)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Wild },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Devotion },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 21,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Grovewatcher,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                111,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 50,
                            Name = "Treant Wardens",
                            DeckClass = ClassList.Grovewatcher,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                96,
                                111,
                                114,
                                116,
                                119,
                                138,
                                141,
                                145,
                                165,
                                1341,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 51,
                            Name = "Faerie Warriors",
                            DeckClass = ClassList.Grovewatcher,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                115,
                                117,
                                118,
                                120,
                                139,
                                170,
                                201,
                                203,
                                205,
                                1363,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 52,
                            Name = "Deep Woodland",
                            DeckClass = ClassList.Grovewatcher,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                89,
                                101,
                                110,
                                111,
                                112,
                                114,
                                139,
                                140,
                                168,
                                188,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 90,
                            Name = "Tree Inferno",
                            DeckClass = ClassList.Grovewatcher,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                96,
                                96,
                                101,
                                101,
                                110,
                                110,
                                111,
                                111,
                                112,
                                112,
                                114,
                                114,
                                116,
                                116,
                                118,
                                118,
                                119,
                                119,
                                138,
                                138,
                                138,
                                141,
                                141,
                                142,
                                142,
                                144,
                                144,
                                144,
                                145,
                                145,
                                145,
                                147,
                                165,
                                165,
                                165,
                                182,
                                182,
                                205,
                                205,
                                205,
                                1341,
                                1341,
                            },
                            UpgradeIdList = new List<int>()
                            {
                                107,
                            },
                            HeroCardID = 1417,
                            InitialHandSize = 4,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerWild(3, 18),
                                new PlayerDevotion(0, 2),
                            },
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Grovewatchers are the wardens of the natural world; they seek a balance of nature and will do anything they can to protect such a balance. Their faith in the old gods gives them their strength, providing them with control over powerful spirits of natures such as faeries and the mysterious treants of the Worldroot. Their powers also provide them with spells to control and slow the enemy, bringing them in pace with the Grovewatchers. For while strong, they are a slow and patient group, and their foes will seek to use that against them, crushing the Grovewatcher before they are able to respond. But do not take this as complacency on the Grovewatchers part; for when that which they protect is disturbed, they will fight as fiercely as any soldier." },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range to Control" },
                        { ClassData.ClassDataFields.Strengths, "Strong resource growth and card draw, powerful units, tools to slow the enemy, ability to continually play powerful units" },
                        { ClassData.ClassDataFields.Weaknesses, "Limited early game presence, very expensive units, relies on trades for removal" },
                    },
                },
                //Lifebringer       (Dominant:Devotion, Secondary:Gold)
                new ClassData(ClassList.Lifebringer)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Devotion },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Gold },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 22,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Lifebringer,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                156,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 53,
                            Name = "Healers and Priests",
                            DeckClass = ClassList.Lifebringer,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                117,
                                118,
                                156,
                                157,
                                159,
                                160,
                                163,
                                166,
                                170,
                                208,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 54,
                            Name = "Master Alchemist",
                            DeckClass = ClassList.Lifebringer,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                114,
                                158,
                                164,
                                168,
                                232,
                                322,
                                328,
                                334,
                                1381,
                                1386,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 55,
                            Name = "Golden Army",
                            DeckClass = ClassList.Lifebringer,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                120,
                                156,
                                159,
                                161,
                                162,
                                165,
                                167,
                                169,
                                201,
                                205,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Lifebringers are the healers and priests who wander the lands of Rudelia, tending to the sick and wounded. They seek to spread the light of the gods and restore hope to a world wrought with peril. Their conviction to their faith and morals provides them with their strength, giving them powerful healing spells and abilities in order to keep their units alive. They are also skilled in alchemy, using their various potions to aid their allies and hinder their foes. But their reliance on aid and defence means that they have limited means of proactively dealing with their foe, relying instead upon their armies to protect them and their healing to recover. Lifebringers desire peace for all living things, but understand that there must be those willing to fight to defend that peace, or else it will all be for naught. " },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range to Control" },
                        { ClassData.ClassDataFields.Strengths, "Excellent healing, multiple high health minions, resurrection effects, good comeback tools" },
                        { ClassData.ClassDataFields.Weaknesses, "Situational removal, low damage output, no card draw" },
                    },
                },
                //Lorekeeper       (Dominant:Knowledge, Secondary:Devotion)
                new ClassData(ClassList.Lorekeeper)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Knowledge },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Devotion },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 23,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Lorekeeper,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                179,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 56,
                            Name = "Lore Preservation",
                            DeckClass = ClassList.Lorekeeper,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                38,
                                51,
                                165,
                                179,
                                184,
                                189,
                                190,
                                193,
                                1389,
                                1391,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 57,
                            Name = "Spreading Madness",
                            DeckClass = ClassList.Lorekeeper,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                35,
                                65,
                                73,
                                74,
                                168,
                                180,
                                183,
                                185,
                                186,
                                191,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 58,
                            Name = "Pacifist Protectors",
                            DeckClass = ClassList.Lorekeeper,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                114,
                                117,
                                157,
                                170,
                                181,
                                182,
                                185,
                                187,
                                188,
                                208,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Devoted to learning and preserving knowledge of the world, Lorekeepers are those devoted to such tasks, travelling the world to learn as much as they can and returning it to be recorded in their mighty vaults. While many see Lorekeepers as little more than librarians or scholars, they have a much more important task; preventing those who would use powerful knowledge to harm others. As such, they use the knowledge they have gathered to take to the field, battling against those who would misuse knowledge for their own gain. While not a strict faith, Lorekeepers almost consider their task a divine duty, and they will take to it in earnest. However they have very few strong fighters, relying on their powerful spells to contest with the enemies best fighters, while the few fighters they have contest the field. The Lorekeeper works to turn the enemy’s strength against them, utilising all their knowledge, both powerful and maddening, to fend off their foes." },
                        { ClassData.ClassDataFields.Playstyle, "Control" },
                        { ClassData.ClassDataFields.Strengths, "Excellent value generation, good high end removal, tools to slow enemy plays, good tutored draws" },
                        { ClassData.ClassDataFields.Weaknesses, "No area of effect damage spells, limited high end units" },
                    },
                },
                //Luminist       (Dominant:Knowledge, Secondary:Wild)
                new ClassData(ClassList.Luminist)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Knowledge },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Wild },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 24,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Luminist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                1332,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 59,
                            Name = "Fire of the Stars",
                            DeckClass = ClassList.Luminist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                35,
                                51,
                                89,
                                92,
                                99,
                                101,
                                1329,
                                1337,
                                1339,
                                1344,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 60,
                            Name = "Mystic Predictions",
                            DeckClass = ClassList.Luminist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                38,
                                43,
                                183,
                                190,
                                261,
                                1328,
                                1332,
                                1333,
                                1338,
                                1342,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 61,
                            Name = "Protection of the Moon",
                            DeckClass = ClassList.Luminist,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                92,
                                304,
                                1330,
                                1331,
                                1332,
                                1333,
                                1336,
                                1341,
                                1343,
                                1359,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 85,
                            Name = "Prove Your Worth! Deck",
                            DeckClass = ClassList.Luminist,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                38,
                                92,
                                92,
                                101,
                                101,
                                119,
                                183,
                                183,
                                295,
                                301,
                                304,
                                304,
                                1328,
                                1331,
                                1331,
                                1333,
                                1333,
                                1341,
                                1341,
                                1349,
                                1359,
                                1359,
                            },
                            UpgradeIdList = new List<int>()
                            {
                                98,
                            },
                            HeroCardID = 1412,
                            InitialHandSize = 3,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerKnowledge(2, 0),
                                new PlayerWild(2, 15),
                            },
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Fortune-tellers and mystics, Luminists are powerful spellweavers who utilise the energies of the moon and stars, providing them with visions of the future and powerful spells of light. Luminists are famous storytellers and they are often seen on the roadside trading stories with groups who encounter them wandering through the wilds. While they are normally a peaceful group, when innocents are in peril they will be quickly roused to aid them, turning their magic against the enemy. With this magic, they are able to learn more about the enemy deck and their own, foretelling what is to come, while devastating them with their spells. They are followed by the mystical elves, who’s bond with the night sky allows them to tap into the luminist’s power. However, they are not the strongest of fighters and rely on the power of the night sky to protect them. The Luminist uses their knowledge of the enemy to modify their strategy, while using their powers of the night sky to control and eliminate the enemy." },
                        { ClassData.ClassDataFields.Playstyle, "Control" },
                        { ClassData.ClassDataFields.Strengths, "Good deck manipulation and knowledge tools, Strong damage and removal spells/abilities, damage avoidance, lots of spellbind" },
                        { ClassData.ClassDataFields.Weaknesses, "Units have low stats (rely on abilities), resource intensive" },
                    },
                },
                //Mercenary       (Dominant:Gold, Secondary:Energy)
                new ClassData(ClassList.Mercenary)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Gold },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Energy },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 25,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Mercenary,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                326,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 62,
                            Name = "Cowardly Horde",
                            DeckClass = ClassList.Mercenary,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                161,
                                322,
                                324,
                                325,
                                328,
                                329,
                                331,
                                333,
                                334,
                                1381,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 63,
                            Name = "Expert Hires",
                            DeckClass = ClassList.Mercenary,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                209,
                                227,
                                253,
                                254,
                                255,
                                322,
                                323,
                                326,
                                329,
                                337,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 64,
                            Name = "Deadly Contractor",
                            DeckClass = ClassList.Mercenary,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                230,
                                259,
                                289,
                                326,
                                327,
                                328,
                                330,
                                336,
                                1367,
                                1386,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "The Mercenaries of Rudelia are cutthroat soldiers who will do anything for a bit of coin. Ruthless and intimidating, these mercenaries charge quickly into battle, aiming to overwhelm the enemy and gain control of the board with their horde of units. With one of the strongest melee heroes in the land, the mercenary will find this an easy task. However, despite their strong numbers, their soldiers are not willing to die for the cause and if under significant stress, may just run from the field. Their numbers also make them vulnerable to large area damage and their melee forces can easily be outranged by archers and casters. The Mercenary’s goal is to force the fight to the enemy, charging across the field and overwhelming the foe with numbers before they have time to respond." },
                        { ClassData.ClassDataFields.Playstyle, "Aggressive to Mid-range" },
                        { ClassData.ClassDataFields.Strengths, "Many and fast units, strong hero, Under-cost minions for their stats" },
                        { ClassData.ClassDataFields.Weaknesses, "Limited range, routing units, vulnerable to area of effect damage" },
                    },
                },
                //Oathknight       (Dominant:Devotion, Secondary:Energy)
                new ClassData(ClassList.Oathknight)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Devotion },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Energy },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 26,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Oathknight,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                204,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 65,
                            Name = "Angelic Army",
                            DeckClass = ClassList.Oathknight,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                117,
                                159,
                                165,
                                170,
                                182,
                                201,
                                203,
                                208,
                                209,
                                213,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 66,
                            Name = "Warrior of Light",
                            DeckClass = ClassList.Oathknight,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                157,
                                205,
                                206,
                                207,
                                212,
                                214,
                                215,
                                216,
                                259,
                                262,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 68,
                            Name = "Divine Might",
                            DeckClass = ClassList.Oathknight,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                117,
                                118,
                                157,
                                182,
                                203,
                                204,
                                205,
                                207,
                                210,
                                211,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Oathknights are powerful knights who are empowered by divine oaths. Utterly devoted to their oath, Oathknights will stop at nothing to ensure that it is fulfilled, whether it be to protect the innocent, heal the lands or seek revenge on those who wrong them or their allies. Those who follow the Oathknight into battle are powerful knights in their own right who are also devoted to a righteous cause. If an Oathknight’s devotion is strong enough, they may even be able to seek aid of the mighty angels, who fly into battle with righteous fury. Their strength also allows them to enchant their allies, providing them with the strength to stand toe-to-toe with the most powerful of enemies. Despite their purity and strength, the Oathknight finds it difficult to contend with those at range and they have no way to deal with large enemies without using their own units strength. The Oathknight is a powerful minion-based class with the goal of keeping their units alive with healing and enchantments in order to control the battlefield. " },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range" },
                        { ClassData.ClassDataFields.Strengths, "Strong units, flying units, well defended hero, multiple buff enchantments" },
                        { ClassData.ClassDataFields.Weaknesses, "Situational range, no hard removal" },
                    },
                },
                //Runeblade       (Dominant:Energy, Secondary:Mana)
                new ClassData(ClassList.Runeblade)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Energy },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Mana },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 27,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Runeblade,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                4,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 69,
                            Name = "Kalyan Blademasters",
                            DeckClass = ClassList.Runeblade,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                4,
                                6,
                                7,
                                8,
                                11,
                                13,
                                97,
                                262,
                                327,
                                335,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 70,
                            Name = "Runic Power",
                            DeckClass = ClassList.Runeblade,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                5,
                                9,
                                12,
                                14,
                                15,
                                17,
                                18,
                                20,
                                27,
                                34,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 71,
                            Name = "Arcane Steel",
                            DeckClass = ClassList.Runeblade,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                4,
                                5,
                                7,
                                11,
                                12,
                                13,
                                16,
                                18,
                                229,
                                259,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 88,
                            Name = "The Last Stand Deck",
                            DeckClass = ClassList.Runeblade,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                4,
                                4,
                                5,
                                5,
                                10,
                                13,
                                20,
                                20,
                                20,
                                34,
                                34,
                                48,
                                48,
                                64,
                                64,
                                64,
                                69,
                                69,
                                70,
                                70,
                                75,
                                75,
                                76,
                                76,
                                77,
                                77,
                                78,
                                78,
                                80,
                                80,
                                83,
                                87,
                                87,
                                255,
                                255,
                                262,
                                262,
                                289,
                                289,
                                296,
                                296,
                                296,
                                297,
                                297,
                                300,
                                300,
                                321,
                                321,
                                329,
                                329,
                                335,
                                335,
                            },
                            UpgradeIdList = new List<int>()
                            {
                                102,
                                103,
                                104,
                            },
                            HeroCardID = 1415,
                            InitialHandSize = 5,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerEnergy(4, 3),
                                new PlayerMana(20, 0),
                            },
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Long ago, the dwarves discovered techniques to use powerful magic runes in order to enchant and empower their weapons. These techniques were highly secretive and only a few were ever taught how to make these weapons, let alone utilise them. Those who do however, are known as Runeblades. Runeblades are skilled blademasters who have learned to use the power of their arcane runes to blend the arcane with the blade. This arcane power allows them to greatly improve their attack power while also protecting them from harm and allowing them to manoeuvre quickly around the battlefield. However their focus on the blade makes them quite melee oriented, and requires them to make aggressive use of their hero and units into order to be effective. They also have few ways of generating value or drawing cards, as such meaning that if they are held off in their initial wave, they are unable to come back into the fight. Runeblades are very aggressive fighters who look to burn down the enemy quickly and efficiently, using their arcane and blade skills to protect them from harm and overwhelm the enemy." },
                        { ClassData.ClassDataFields.Playstyle, "Aggressive" },
                        { ClassData.ClassDataFields.Strengths, "High attack units, multiple enchantments for casters, Good manoeuvrability" },
                        { ClassData.ClassDataFields.Weaknesses, "Requires aggressive use of hero, limited card draw, limited range" },
                    },
                },
                //Trickster       (Dominant:Gold, Secondary:Mana)
                new ClassData(ClassList.Trickster)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Gold },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Mana },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 28,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Trickster,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                231,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 72,
                            Name = "Backstabbers",
                            DeckClass = ClassList.Trickster,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                20,
                                33,
                                34,
                                228,
                                231,
                                232,
                                234,
                                235,
                                236,
                                238,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 73,
                            Name = "Shadows and Death",
                            DeckClass = ClassList.Trickster,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                158,
                                227,
                                228,
                                229,
                                233,
                                235,
                                239,
                                240,
                                1360,
                                1386,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 74,
                            Name = "Own the Streets",
                            DeckClass = ClassList.Trickster,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                227,
                                230,
                                231,
                                234,
                                237,
                                241,
                                328,
                                1367,
                                1385,
                                1394,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 87,
                            Name = "Traitors in our Midst Deck",
                            DeckClass = ClassList.Trickster,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                24,
                                227,
                                227,
                                228,
                                228,
                                229,
                                229,
                                231,
                                231,
                                233,
                                233,
                                234,
                                234,
                                235,
                                239,
                                240,
                                240,
                                243,
                                243,
                                1360,
                                1374,
                                1374,
                                1376,
                                1386,
                                1386,
                            },
                            UpgradeIdList = new List<int>()
                            {
                                100,
                                101,
                            },
                            HeroCardID = 1414,
                            InitialHandSize = 4,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerGold(16, 1),
                                new PlayerMana(20, 0),
                            },
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Tricksters are roguish types who have learned how to use arcane powers in order to become masters of stealth and subterfuge. Lurking in the shadowy underworld, the Trickster looks for any opportunity to make a profit, no matter what the work may entail. The goal of the Trickster is to find their quarry, eliminate them and then quickly leave without anyone the wiser. This provides them with many strong and quick answers to the enemy tactics as well as excellent tools to avoid and outmanoeuvre the enemy. However, their focus on swiftness means they are quite vulnerable and their aggressive units struggle to hold onto a position for long before being destroyed. However, their strong damage and removal spells allow them to assault the enemy from relative safety, giving the hero the opportunity to come back into the game if they lose their forces. The Trickster are masters of the underworld, providing them with efficient means of destroying and escaping from the enemy. With the shadows on their side, nothing will be able to stop the Trickster." },
                        { ClassData.ClassDataFields.Playstyle, "Aggressive to midrange" },
                        { ClassData.ClassDataFields.Strengths, "Fast units, good escape tools, strong direct damage spells, some removal" },
                        { ClassData.ClassDataFields.Weaknesses, "Vulnerable hero, weak board control from units" },
                    },
                },
                //Waystalker       (Dominant:Wild, Secondary:Gold)
                new ClassData(ClassList.Waystalker)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Wild },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Gold },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 29,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Waystalker,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                1362,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 75,
                            Name = "Animal Companions",
                            DeckClass = ClassList.Waystalker,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                158,
                                163,
                                304,
                                1359,
                                1362,
                                1364,
                                1366,
                                1368,
                                1370,
                                1371,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 76,
                            Name = "Woodland Protector",
                            DeckClass = ClassList.Waystalker,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                110,
                                138,
                                141,
                                304,
                                1329,
                                1359,
                                1360,
                                1362,
                                1363,
                                1374,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 77,
                            Name = "Elite Ranger",
                            DeckClass = ClassList.Waystalker,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                158,
                                164,
                                227,
                                1360,
                                1361,
                                1362,
                                1365,
                                1367,
                                1369,
                                1373,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 91,
                            Name = "The Dragon's Grave Deck",
                            DeckClass = ClassList.Waystalker,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                89,
                                89,
                                101,
                                101,
                                110,
                                110,
                                304,
                                304,
                                1329,
                                1329,
                                1330,
                                1330,
                                1359,
                                1359,
                                1359,
                                1359,
                                1360,
                                1360,
                                1361,
                                1361,
                                1361,
                                1362,
                                1362,
                                1362,
                                1365,
                                1365,
                                1365,
                                1369,
                                1369,
                                1371,
                                1371,
                                1371,
                                1373,
                                1373,
                                1375,
                                1375,
                                1377,
                                1377,
                                1378,
                                1378,
                            },
                            UpgradeIdList = new List<int>()
                            {
                                108,
                                109,
                                110,
                            },
                            HeroCardID = 1418,
                            InitialHandSize = 4,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerWild(3, 12),
                                new PlayerGold(16, 2),
                            },
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "Waystalkers are hunters and rangers who live on the fringes of society; protecting those within from the terrors of the wild. Master bowman, the Waystalkers field some of the best ranged units in Rudelia. Their connection with the wild also allows them to call upon powerful beasts, who they use to protect their rangers and hold back the foe. Their units are also extremely quick and not hindered by the terrain they pass through, for they are masters of travelling through the wilds. However if they are not careful to protect themselves, the Waystalker can be eliminated quite quickly. They also have few large units to support them in the late game, relying on quantity over quality. However, their early units are meant to be protected and aggressive enough that this doesn’t become an issue. The Waystalker fields a well rounded army, with a good mix of ranged and melee units to support them as they look to whither down the enemy with their ferocious beasts and devastating arrows." },
                        { ClassData.ClassDataFields.Playstyle, "Mid-range" },
                        { ClassData.ClassDataFields.Strengths, "Enhancements to hero attacks, strong early to mid-game beast units, fast ranged hero, fast units" },
                        { ClassData.ClassDataFields.Weaknesses, "Low-health hero, few late-game units" },
                    },
                },
                //Wildkin       (Dominant:Energy, Secondary:Wild)
                new ClassData(ClassList.Wildkin)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Energy },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Wild },
                    },
                    IsPlayable = true,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                        new DeckSaveData()
                        {
                            Id = 30,
                            Name = "Empty Deck",
                            DeckClass = ClassList.Wildkin,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                299,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 78,
                            Name = "Unleash the Beast",
                            DeckClass = ClassList.Wildkin,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                289,
                                295,
                                299,
                                302,
                                303,
                                304,
                                311,
                                335,
                                336,
                                1359,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 79,
                            Name = "Endless Rage",
                            DeckClass = ClassList.Wildkin,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                6,
                                209,
                                289,
                                296,
                                297,
                                299,
                                300,
                                302,
                                309,
                                336,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 80,
                            Name = "Death Defiant",
                            DeckClass = ClassList.Wildkin,
                            IsNPCDeck = false,
                            CardIdList = new List<int>()
                            {
                                89,
                                140,
                                295,
                                298,
                                300,
                                301,
                                307,
                                327,
                                1330,
                                1341,
                            },
                            UpgradeIdList = new List<int>(),
                        },
                        new DeckSaveData()
                        {
                            Id = 84,
                            Name = "Caravan Ambush Deck",
                            DeckClass = ClassList.Wildkin,
                            IsNPCDeck = true,
                            CardIdList = new List<int>()
                            {
                                289,
                                289,
                                300,
                                303,
                                315,
                                327,
                                336,
                                336,
                                1359,
                                1359,
                                1359,
                                1364,
                                1364,
                                1368,
                                1368,
                            },
                            UpgradeIdList = new List<int>()
                            {
                            },
                            HeroCardID = 1411,
                            InitialHandSize = 3,
                            PlayerResources = new List<PlayerResource>()
                            {
                                new PlayerEnergy(3, 2),
                                new PlayerWild(2, 12),
                            },
                        },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "The Wildkin are fierce barbarians from the cold wastes in the north of Rudellia. Wildkin have been isolated from society for so long that many see them as little more than animals- and they are not far from the truth. For the Wildkin have learned the art of shapechanging, becoming wild beasts who overwhelm their foes with their mighty strength. Their rage is fearsome to behold and few would stand before the onslaught of a Wildkin. Despite their ferocity however, they are an isolated breed and few would follow them into battle- those who do being other Wildkin. They also struggle with resource generation and it is common to see a Wildkin burn themselves out with their rage. However their durability allows them to come back from the brink and many have made the mistake of thinking they defeated a Wildkin, right before the raged Wildkin charged into the fray again. The Wildkin is a highly versatile class, with the ability to last well into the late game, but also can use their hero and units aggressively in order to command the field." },
                        { ClassData.ClassDataFields.Playstyle, "Versatile" },
                        { ClassData.ClassDataFields.Strengths, "Very durable hero, can take upon powerful beastly aspects, strong but few units, self-damage synergies" },
                        { ClassData.ClassDataFields.Weaknesses, "Weak board presence, weak resource generation and card draw" },
                    },
                },
                //Token       (Dominant:Neutral, Secondary:Neutral)
                new ClassData(ClassList.Token)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Neutral },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Neutral },
                    },
                    IsPlayable = false,
                    DeckTemplates = new List<DeckSaveData>()
                    {
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "NOT PLAYABLE" },
                        { ClassData.ClassDataFields.Playstyle, "NOT PLAYABLE" },
                        { ClassData.ClassDataFields.Strengths, "NOT PLAYABLE" },
                        { ClassData.ClassDataFields.Weaknesses, "NOT PLAYABLE" },
                    },
                },
        };
    }
}
