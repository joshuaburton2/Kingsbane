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
        public bool IsPlayable { get; internal set; }
        public List<DeckSaveData> DeckTemplates { get; internal set; }
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
}
