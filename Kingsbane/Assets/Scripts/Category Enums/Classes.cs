using System.Collections;
using System.Collections.Generic;
using CategoryEnums;

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

        /// <summary>
        /// 
        /// List for storing all the resources used by the different classes
        /// 
        /// </summary>
        private static CardResources[][] classResources = new CardResources[][]
        {
            new CardResources[] { CardResources.Neutral, CardResources.Neutral },    //Default
            new CardResources[] { CardResources.Devotion, CardResources.Mana },      //Abyssal       (Devotion, Mana)
            new CardResources[] { CardResources.Gold, CardResources.Knowledge },     //Agent         (Gold, Knowledge)
            new CardResources[] { CardResources.Knowledge, CardResources.Mana },     //Arcanist      (Knowledge, Mana)
            new CardResources[] { CardResources.Energy, CardResources.Knowledge },   //Captain       (Energy, Knowledge)
            new CardResources[] { CardResources.Mana, CardResources.Wild },          //Elementalist  (Mana, Wild)
            new CardResources[] { CardResources.Devotion, CardResources.Wild },      //Grovewatcher  (Devotion, Wild)
            new CardResources[] { CardResources.Devotion, CardResources.Gold },      //Lifebringer   (Devotion, Gold)
            new CardResources[] { CardResources.Devotion, CardResources.Knowledge }, //Lorekeeper    (Devotion, Knowledge)
            new CardResources[] { CardResources.Knowledge, CardResources.Wild },     //Luminist      (Knowledge, Wild)
            new CardResources[] { CardResources.Energy, CardResources.Gold },        //Mercenary     (Energy, Gold)
            new CardResources[] { CardResources.Devotion, CardResources.Energy },    //Oathknight    (Devotion, Energy)
            new CardResources[] { CardResources.Energy, CardResources.Mana },        //Runeblade     (Energy, Mana)
            new CardResources[] { CardResources.Gold, CardResources.Mana },          //Trickster     (Gold, Mana)
            new CardResources[] { CardResources.Gold, CardResources.Wild },          //Waystalker    (Gold, Wild)
            new CardResources[] { CardResources.Energy, CardResources.Wild }         //Wildkin       (Energy, Wild)
        };

        /// <summary>
        /// 
        /// Obtain the list of resources used by a particular class
        /// 
        /// </summary>
        public static CardResources[] GetClassResource(ClassList neededClass)
        {
            return classResources[(int)neededClass];
        }
    }
}
