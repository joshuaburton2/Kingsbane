using CategoryEnums;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

/// <summary>
/// 
/// Object for storing the resource colours
/// 
/// </summary>
[Serializable]
public class ResourceColour
{
    public CardResources Resource;
    public Color resourceColour;
}

/// <summary>
/// 
/// Object for storing the class colours
/// 
/// </summary>
[Serializable]
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
[Serializable]
public class RarityColour
{
    public Rarity Rarity;
    public Color rarityColour;
}

/// <summary>
/// 
/// Object for storing the terrain colour based on the game map
/// 
/// </summary>
[Serializable]
public class TerrainColour
{
    public TerrainTypes terrainType;
    public Color terrainColour;
}

/// <summary>
/// 
/// Object for storing the colour of a player index on the game map
/// 
/// </summary>
[Serializable]
public class PlayerColour
{
    public int playerIndex;
    public Color playerColour;
}

/// <summary>
/// 
/// Object for storing the colour of a unit stat on their counter
/// 
/// </summary>
[Serializable]
public class StatColours
{
    public Unit.UnitStatTypes unitStat;
    public Color statColour;
}

public class ColourManager : MonoBehaviour
{
    [Header("Border Colours")]
    [SerializeField]
    List<RarityColour> rarityColours;

    [Header("Resource Colours")]
    [SerializeField]
    private List<ResourceColour> resourceColours;

    [Header("Class Colours")]
    [SerializeField]
    private List<ClassColour> classColours;

    [Header("Map Colours")]
    [SerializeField]
    private List<TerrainColour> terrainColours;
    [SerializeField]
    private List<PlayerColour> playerColours;

    [Header("Unit Stat Colours")]
    [SerializeField]
    private List<StatColours> statColours;

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
    /// Obtain a particular resource colour
    /// 
    /// </summary>
    public Color GetResourceColour(CardResources neededResource)
    {
        var resourceColour = new Color();
        resourceColour = resourceColours.FirstOrDefault(x => x.Resource == neededResource).resourceColour;
        if (resourceColour == null)
        {
            resourceColour = new Color();
        }
        return resourceColour;
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

    /// <summary>
    /// 
    /// Obtain a particular terrain colour
    /// 
    /// </summary>
    public Color GetTerrainColour(TerrainTypes neededTerrain)
    {
        var terrainColour = new Color();
        terrainColour = terrainColours.FirstOrDefault(x => x.terrainType == neededTerrain).terrainColour;
        if (terrainColour == null)
        {
            terrainColour = new Color();
        }
        return terrainColour;
    }

    /// <summary>
    /// 
    /// Obtain a particular player colour
    /// 
    /// </summary>
    public Color GetPlayerColour(int neededPlayer)
    {
        var playerColour = new Color();
        playerColour = playerColours.FirstOrDefault(x => x.playerIndex == neededPlayer).playerColour;
        if (playerColour == null)
        {
            playerColour = new Color();
        }
        return playerColour;
    }

    /// <summary>
    /// 
    /// Obtain a particular unit stat colour 
    /// 
    /// </summary>
    public Color GetUnitStatColour(Unit.UnitStatTypes unitStatType)
    {
        var unitStatColour = new Color();
        unitStatColour = statColours.FirstOrDefault(x => x.unitStat == unitStatType).statColour;
        if (unitStatColour == null)
        {
            unitStatColour = new Color();
        }
        return unitStatColour;
    }
}