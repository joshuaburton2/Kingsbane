using CategoryEnums;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 
/// Object for storing the rarity border colour for a class's hero
/// 
/// </summary>
[System.Serializable]
public class ClassColour
{
    public Classes.ClassList Class;
    public Color classColour;
}


/// <summary>
/// 
/// Object for storing the rarity border colour based on the rarity of the card
/// 
/// </summary>
[System.Serializable]
public class RarityColour
{
    public Rarity Rarity;
    public Color rarityColour;
}

public class ColourManager : MonoBehaviour
{
    [Header("Border Colours")]
    [SerializeField]
    List<RarityColour> rarityColours;

    [Header("Hero Border Colours")]
    [SerializeField]
    private List<ClassColour> classColours;

    /// <summary>
    /// 
    /// Obtain a particular rarities colour
    /// 
    /// </summary>
    public Color GetRarityColour(Rarity neededRarity, Classes.ClassList neededClass)
    {
        var rarityColour = new Color();
        if (neededRarity == Rarity.Hero || neededRarity == Rarity.NPCHero)
        {
            rarityColour = GetClassColour(neededClass);
        }
        else
        {
            rarityColour = rarityColours.FirstOrDefault(x => x.Rarity == neededRarity).rarityColour;
            if (rarityColour == null)
            {
                rarityColour = new Color();
            }
        }
        
        return rarityColour;
    }

    /// <summary>
    /// 
    /// Obtain a particular classes colour
    /// 
    /// </summary>
    public Color GetClassColour(Classes.ClassList neededClass)
    {
        var classColour = new Color();
        classColour = classColours.FirstOrDefault(x => x.Class == neededClass).classColour;
        if (classColour == null)
        {
            classColour = new Color();
        }
        return classColour;
    }
}