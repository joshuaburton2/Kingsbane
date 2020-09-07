using System.Collections.Generic;
using System.Linq;

namespace CategoryEnums
{
    public class ClassData
    {
        public enum ClassDataFields
        {
            Playstyle,
            Strengths,
            Weaknesses,
            Description,
        }

        public Classes.ClassList ThisClass { get; internal set; }
        public string ClassName { get { return ThisClass.ToString(); } }
        public List<ClassResourceType> ClassResources { get; internal set; }
        public Dictionary<ClassDataFields, string> ClassDataStringList { get; internal set; }

        public ClassData(Classes.ClassList neededClass)
        {
            ThisClass = neededClass;
        }

        public string GetStringData(ClassData.ClassDataFields classDataField)
        {
            return ClassDataStringList[classDataField];
        }

        /// <summary>
        /// 
        /// Obtain the list of resources used by the class
        /// 
        /// </summary>
        public List<CardResources> GetClassResources()
        {
            var classResources = new List<CardResources>();

            foreach (var classResource in ClassResources)
            {
                classResources.Add(classResource.CardResource);
            }

            return classResources;
        }

        /// <summary>
        /// 
        /// Obtain either the dominant or secondary resource of the class
        /// 
        /// </summary>
        public CardResources GetResourceOfType(ClassResourceType.ResourceTypes resourceType)
        {
            return ClassResources.FirstOrDefault(x => x.ResourceType == resourceType).CardResource;
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
            Wildkin
        };

        public static ClassData GetClassData(ClassList neededClass)
        {
            return ClassDataList.FirstOrDefault(x => x.ThisClass == neededClass);
        }

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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
                    },
                    },
                //Abyssal       (Dominant:Devotion, Secondary:Mana)
                new ClassData(ClassList.Abyssal)
                {
                    ClassResources = new List<ClassResourceType>()
                    {
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Dominant, CardResource = CardResources.Devotion },
                        new ClassResourceType() { ResourceType = ClassResourceType.ResourceTypes.Secondary, CardResource = CardResources.Mana },
                    },
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
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
                    ClassDataStringList = new Dictionary<ClassData.ClassDataFields, string>()
                    {
                        { ClassData.ClassDataFields.Description, "" },
                        { ClassData.ClassDataFields.Playstyle, "" },
                        { ClassData.ClassDataFields.Strengths, "" },
                        { ClassData.ClassDataFields.Weaknesses, "" },
                    },
                    },
        };


    }
}
