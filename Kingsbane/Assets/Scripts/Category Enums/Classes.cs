using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CategoryEnums
{
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

        public enum ResourceType
        {
            Dominant,
            Secondary
        }

        private class ClassResourceType
        {
            public ResourceType ResourceType { get; internal set; }
            public CardResources CardResource { get; internal set; }
        }

        private class ClassResource
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

        /// <summary>
        /// 
        /// List for storing all the resources used by the different classes
        /// 
        /// </summary>
        private static readonly List<ClassResource> defaultClassResources = new List<ClassResource>()
        {
            //Default
            new ClassResource() { ThisClass = ClassList.Default,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Neutral },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Neutral },
                } },    

            //Abyssal       (Devotion, Mana), Dominant Mana
            new ClassResource() { ThisClass = ClassList.Abyssal,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Mana },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Devotion },
                } },      

            //Agent         (Gold, Knowledge) Dominant Gold
            new ClassResource() { ThisClass = ClassList.Agent,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Gold },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Knowledge },
                } },     

            //Arcanist      (Knowledge, Mana) Dominant Knowledge
            new ClassResource() { ThisClass = ClassList.Arcanist,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Knowledge },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Mana },
                } },     

            //Captain       (Energy, Knowledge) Dominant Energy
            new ClassResource() { ThisClass = ClassList.Captain,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Energy },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Knowledge },
                } },   

            //Elementalist  (Mana, Wild) Dominant Mana
            new ClassResource() { ThisClass = ClassList.Elementalist,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Mana },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Wild },
                } },          

            //Grovewatcher  (Devotion, Wild) Dominant Wild
            new ClassResource() { ThisClass = ClassList.Grovewatcher,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Wild },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Devotion },
                } },      

            //Lifebringer   (Devotion, Gold) Dominant Devotion
            new ClassResource() { ThisClass = ClassList.Lifebringer,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Devotion },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Gold },
                } },      

            //Lorekeeper    (Devotion, Knowledge) Dominant Knowledge
            new ClassResource() { ThisClass = ClassList.Lorekeeper,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Knowledge },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Devotion },
                } }, 

            //Luminist      (Knowledge, Wild) Dominant Knowledge
            new ClassResource() { ThisClass = ClassList.Luminist,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Knowledge },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Wild },
                } },     

            //Mercenary     (Energy, Gold) Dominant Gold
            new ClassResource() { ThisClass = ClassList.Mercenary,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Gold },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Energy },
                } },        

            //Oathknight    (Devotion, Energy) Dominant Devotion
            new ClassResource() { ThisClass = ClassList.Oathknight,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Devotion },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Energy },
                } },    

            //Runeblade     (Energy, Mana) Dominant Energy
            new ClassResource() { ThisClass = ClassList.Runeblade,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Energy },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Mana },
                } },        

            //Trickster     (Gold, Mana) Dominant Gold
            new ClassResource() { ThisClass = ClassList.Trickster,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Gold },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Mana },
                } },          

            //Waystalker    (Gold, Wild) Dominant Wild
            new ClassResource() { ThisClass = ClassList.Waystalker,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Wild },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Gold },
                } },          

            //Wildkin       (Energy, Wild) Dominant Energy
            new ClassResource() { ThisClass = ClassList.Wildkin,
                ClassResources = new List<ClassResourceType>() {
                    new ClassResourceType() {ResourceType = ResourceType.Dominant, CardResource = CardResources.Energy },
                    new ClassResourceType() {ResourceType = ResourceType.Secondary, CardResource = CardResources.Wild },
                } }
        };

        /// <summary>
        /// 
        /// Obtain the list of resources used by a particular class
        /// 
        /// </summary>
        public static List<CardResources> GetClassResource(ClassList neededClass)
        {
            return defaultClassResources.FirstOrDefault(x => x.ThisClass == neededClass).GetClassResources();
        }

        /// <summary>
        /// 
        /// Obtain either the dominant or secondary resource of a particular class
        /// 
        /// </summary>
        public static CardResources GetResourceOfType(ClassList neededClass, ResourceType resourceType)
        {
            //First get the relevant class, then of the relevant resource type
            return defaultClassResources.FirstOrDefault(x => x.ThisClass == neededClass).ClassResources
                .FirstOrDefault(x => x.ResourceType == resourceType).CardResource;
        }
    }
}
