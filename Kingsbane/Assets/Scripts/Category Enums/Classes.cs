using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.XR.WSA.Input;

namespace CategoryEnums
{

    public static class Classes
    {
        public enum ClassDataFields
        {
            Playstyle,
            Strengths,
            Weaknesses,
            Description,
        }

        public class ClassData
        {
            public ClassList ThisClass { get; internal set; }
            public string ClassName { get { return ThisClass.ToString(); } }
            public ClassResource ClassResources { get; internal set; }
            public Dictionary<ClassDataFields, string> ClassDataStringList { get; internal set; }

            public string GetStringData(ClassDataFields classDataField)
            {
                return ClassDataStringList[classDataField];
            }

            public ClassData(ClassList neededClass)
            {
                ThisClass = neededClass;
            }
        }

        public class ClassResourceType
        {
            public ResourceType ResourceType { get; internal set; }
            public CardResources CardResource { get; internal set; }
        }

        public class ClassResource
        {
            public ClassList ThisClass { get; internal set; }
            public List<ClassResourceType> ClassResources { get; internal set; }

            public List<CardResources> GetClassResources()
            {
                var classResources = new List<CardResources>();

                foreach (var classResource in ClassResources)
                {
                    classResources.Add(classResource.CardResource);
                }

                return classResources;
            }
        }

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
            Wildkin
        };

        public enum ResourceType
        {
            Dominant,
            Secondary
        }

        /// <summary>
        /// 
        /// Obtain the list of resources used by a particular class
        /// 
        /// </summary>
        public static List<CardResources> GetClassResource(ClassList neededClass)
        {
            return ClassDataList.defaultClassResources.FirstOrDefault(x => x.ThisClass == neededClass).GetClassResources();
        }

        /// <summary>
        /// 
        /// Obtain either the dominant or secondary resource of a particular class
        /// 
        /// </summary>
        public static CardResources GetResourceOfType(ClassList neededClass, ResourceType resourceType)
        {
            //First get the relevant class, then of the relevant resource type
            return ClassDataList.FirstOrDefault(x => x.ThisClass == neededClass).ClassResources
                .FirstOrDefault(x => x.ResourceType == resourceType).CardResource;
        }

        internal static List<ClassData> ClassDataList = new List<ClassData>()
        {
            //Default
            new ClassData(ClassList.Default) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Default,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Neutral },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Neutral },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "-" },
                    { ClassDataFields.Strengths, "-" },
                    { ClassDataFields.Weaknesses, "-" },
            } },

            //Abyssal       (Devotion, Mana), Dominant Mana
            new ClassData(ClassList.Abyssal) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Abyssal,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Mana },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Devotion },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Agent         (Gold, Knowledge) Dominant Gold
            new ClassData(ClassList.Agent) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Agent,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Gold },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Knowledge },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Arcanist      (Knowledge, Mana) Dominant Knowledge
            new ClassData(ClassList.Arcanist) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Arcanist,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Knowledge },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Mana },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Captain       (Energy, Knowledge) Dominant Energy
            new ClassData(ClassList.Captain) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Captain,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Energy },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Knowledge },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Elementalist  (Mana, Wild) Dominant Mana
            new ClassData(ClassList.Elementalist) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Elementalist,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Mana },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Wild },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Grovewatcher  (Devotion, Wild) Dominant Wild
            new ClassData(ClassList.Grovewatcher) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Grovewatcher,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Wild },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Devotion },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Lifebringer   (Devotion, Gold) Dominant Devotion
            new ClassData(ClassList.Lifebringer) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Lifebringer,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Devotion },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Gold },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Lorekeeper    (Devotion, Knowledge) Dominant Knowledge
            new ClassData(ClassList.Lorekeeper) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Lorekeeper,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Knowledge },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Devotion },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Luminist      (Knowledge, Wild) Dominant Knowledge
            new ClassData(ClassList.Luminist) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Luminist,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Knowledge },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Wild },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Mercenary     (Energy, Gold) Dominant Gold
            new ClassData(ClassList.Mercenary) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Mercenary,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Gold },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Energy },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Oathknight     (Devotion, Energy) Dominant Devotion
            new ClassData(ClassList.Oathknight) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Oathknight,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Devotion },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Energy },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Runeblade     (Energy, Mana) Dominant Energy
            new ClassData(ClassList.Runeblade) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Runeblade,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Energy },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Mana },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Trickster     (Gold, Mana) Dominant Gold
            new ClassData(ClassList.Trickster) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Trickster,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Gold },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Mana },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Waystalker    (Gold, Wild) Dominant Wild
            new ClassData(ClassList.Waystalker) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Waystalker,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Wild },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Gold },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },

            //Wildkin       (Energy, Wild) Dominant Energy
            new ClassData(ClassList.Wildkin) {
                ClassResources = new ClassResource() { ThisClass = ClassList.Wildkin,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Energy },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Wild },
                } },
                ClassDataStringList = new Dictionary<ClassDataFields, string>() {
                    { ClassDataFields.Description, "" },
                    { ClassDataFields.Playstyle, "" },
                    { ClassDataFields.Strengths, "" },
                    { ClassDataFields.Weaknesses, "" },
            } },
        };
    }
}
