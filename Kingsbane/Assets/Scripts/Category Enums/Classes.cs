using System.Collections.Generic;
using System.Linq;

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

        private class ClassResource
        {
            public ClassList thisClass;
            public List<CardResources> classResources;
        }

        /// <summary>
        /// 
        /// List for storing all the resources used by the different classes
        /// 
        /// </summary>
        private static readonly List<ClassResource> classResources = new List<ClassResource>()
        {
            new ClassResource() { thisClass = ClassList.Default, 
                classResources = new List<CardResources>() { CardResources.Neutral, CardResources.Neutral } },    //Default
            new ClassResource() { thisClass = ClassList.Abyssal, 
                classResources = new List<CardResources>() { CardResources.Devotion, CardResources.Mana } },      //Abyssal       (Devotion, Mana)
            new ClassResource() { thisClass = ClassList.Agent, 
                classResources = new List<CardResources>() { CardResources.Gold, CardResources.Knowledge } },     //Agent         (Gold, Knowledge)
            new ClassResource() { thisClass = ClassList.Arcanist, 
                classResources = new List<CardResources>() { CardResources.Knowledge, CardResources.Mana } },     //Arcanist      (Knowledge, Mana)
            new ClassResource() { thisClass = ClassList.Captain, 
                classResources = new List<CardResources>() { CardResources.Energy, CardResources.Knowledge } },   //Captain       (Energy, Knowledge)
            new ClassResource() { thisClass = ClassList.Elementalist, 
                classResources = new List<CardResources>() { CardResources.Mana, CardResources.Wild } },          //Elementalist  (Mana, Wild)
            new ClassResource() { thisClass = ClassList.Grovewatcher, 
                classResources = new List<CardResources>() { CardResources.Devotion, CardResources.Wild } },      //Grovewatcher  (Devotion, Wild)
            new ClassResource() { thisClass = ClassList.Lifebringer, 
                classResources = new List<CardResources>() { CardResources.Devotion, CardResources.Gold } },      //Lifebringer   (Devotion, Gold)
            new ClassResource() { thisClass = ClassList.Lorekeeper, 
                classResources = new List<CardResources>() { CardResources.Devotion, CardResources.Knowledge } }, //Lorekeeper    (Devotion, Knowledge)
            new ClassResource() { thisClass = ClassList.Luminist, 
                classResources = new List<CardResources>() { CardResources.Knowledge, CardResources.Wild } },     //Luminist      (Knowledge, Wild)
            new ClassResource() { thisClass = ClassList.Mercenary, 
                classResources = new List<CardResources>() { CardResources.Energy, CardResources.Gold } },        //Mercenary     (Energy, Gold)
            new ClassResource() { thisClass = ClassList.Oathknight, 
                classResources = new List<CardResources>() { CardResources.Devotion, CardResources.Energy } },    //Oathknight    (Devotion, Energy)
            new ClassResource() { thisClass = ClassList.Runeblade, 
                classResources = new List<CardResources>() { CardResources.Energy, CardResources.Mana } },        //Runeblade     (Energy, Mana)
            new ClassResource() { thisClass = ClassList.Trickster, 
                classResources = new List<CardResources>() { CardResources.Gold, CardResources.Mana } },          //Trickster     (Gold, Mana)
            new ClassResource() { thisClass = ClassList.Waystalker, 
                classResources = new List<CardResources>() { CardResources.Gold, CardResources.Wild } },          //Waystalker    (Gold, Wild)
            new ClassResource() { thisClass = ClassList.Wildkin, 
                classResources = new List<CardResources>() { CardResources.Energy, CardResources.Wild } }         //Wildkin       (Energy, Wild)
        };

        /// <summary>
        /// 
        /// Obtain the list of resources used by a particular class
        /// 
        /// </summary>
        public static List<CardResources> GetClassResource(ClassList neededClass)
        {
            return classResources.FirstOrDefault(x => x.thisClass == neededClass).classResources;
        }
    }
}
