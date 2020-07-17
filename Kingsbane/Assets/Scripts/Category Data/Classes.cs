using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Classes
{
    public enum ClassList
    { 
        Default, Abyssal, Agent, Arcanist, Captain, Elementalist, Grovewatcher,
        Lifebringer, Lorekeeper, Luminist, Mercenary, Oathknight, Runeblade,
        Trickster, Waystalker, Wildkin
    };

    /// <summary>
    /// 
    /// List for storing all the resources used by the different classes
    /// 
    /// </summary>
    private static Resources.ResourceList[][] classResources = new Resources.ResourceList[][]
    {
        new Resources.ResourceList[] { Resources.ResourceList.Neutral, Resources.ResourceList.Neutral },    //Default
        new Resources.ResourceList[] { Resources.ResourceList.Devotion, Resources.ResourceList.Mana },      //Abyssal       (Devotion, Mana)
        new Resources.ResourceList[] { Resources.ResourceList.Gold, Resources.ResourceList.Knowledge },     //Agent         (Gold, Knowledge)
        new Resources.ResourceList[] { Resources.ResourceList.Knowledge, Resources.ResourceList.Mana },     //Arcanist      (Knowledge, Mana)
        new Resources.ResourceList[] { Resources.ResourceList.Energy, Resources.ResourceList.Knowledge },   //Captain       (Energy, Knowledge)
        new Resources.ResourceList[] { Resources.ResourceList.Mana, Resources.ResourceList.Wild },          //Elementalist  (Mana, Wild)
        new Resources.ResourceList[] { Resources.ResourceList.Devotion, Resources.ResourceList.Wild },      //Grovewatcher  (Devotion, Wild)
        new Resources.ResourceList[] { Resources.ResourceList.Devotion, Resources.ResourceList.Gold },      //Lifebringer   (Devotion, Gold)
        new Resources.ResourceList[] { Resources.ResourceList.Devotion, Resources.ResourceList.Knowledge }, //Lorekeeper    (Devotion, Knowledge)
        new Resources.ResourceList[] { Resources.ResourceList.Knowledge, Resources.ResourceList.Wild },     //Luminist      (Knowledge, Wild)
        new Resources.ResourceList[] { Resources.ResourceList.Energy, Resources.ResourceList.Gold },        //Mercenary     (Energy, Gold)
        new Resources.ResourceList[] { Resources.ResourceList.Devotion, Resources.ResourceList.Energy },    //Oathknight    (Devotion, Energy)
        new Resources.ResourceList[] { Resources.ResourceList.Energy, Resources.ResourceList.Mana },        //Runeblade     (Energy, Mana)
        new Resources.ResourceList[] { Resources.ResourceList.Gold, Resources.ResourceList.Mana },          //Trickster     (Gold, Mana)
        new Resources.ResourceList[] { Resources.ResourceList.Gold, Resources.ResourceList.Wild },          //Waystalker    (Gold, Wild)
        new Resources.ResourceList[] { Resources.ResourceList.Energy, Resources.ResourceList.Wild }         //Wildkin       (Energy, Wild)
    };

    /// <summary>
    /// 
    /// Obtain the list of resources used by a particular class
    /// 
    /// </summary>
    public static Resources.ResourceList[] GetClassResource (ClassList neededClass)
    {
        return classResources[(int)neededClass];
    }
}
