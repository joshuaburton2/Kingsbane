using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;
using System;
using System.Linq;

/// <summary>
/// 
/// Object for displaying key elements of a map
/// 
/// </summary>
public class MapKeyUI : MonoBehaviour
{
    private const int NUM_PLAYERS = 2;
    private class KeyDetails
    {
        public Color KeyColour { get; set; }
        public string KeyText { get; set; }
    }

    [SerializeField]
    private GameObject keyColourPrefab;
    [SerializeField]
    private GameObject keyColourParent;
    [SerializeField]
    private GameObject noKeyText;

    public MapGrid.MapFilters CurrentFilter { get; set; }

    /// <summary>
    /// 
    /// Refresh the key to display the correct elements
    /// 
    /// </summary>
    /// <param name="objectiveList">Only required if the key elements are for an objective map</param>
    public void RefreshKey(MapGrid.MapFilters keyType, List<Objective> objectiveList = null)
    {
        noKeyText.SetActive(false);
        GameManager.DestroyAllChildren(keyColourParent);
        CurrentFilter = keyType;

        //Constructs the key detail list based on the type of filter utilised. Key Detail requires a name and colour
        var keyDetailList = new List<KeyDetails>();
        switch (keyType)
        {
            case MapGrid.MapFilters.Terrain:
                foreach (var terrainKey in Enum.GetValues(typeof(TerrainTypes)).Cast<TerrainTypes>())
                {
                    keyDetailList.Add(new KeyDetails()
                    {
                        KeyColour = GameManager.instance.colourManager.GetTerrainColour(terrainKey),
                        KeyText = terrainKey.ToString(),
                    });
                }
                break;
            case MapGrid.MapFilters.Deployment:
                for (int i = 0; i < NUM_PLAYERS; i++)
                {
                    keyDetailList.Add(new KeyDetails()
                    {
                        KeyColour = GameManager.instance.colourManager.GetPlayerColour(i),
                        KeyText = $"Player {i + 1}",
                    });
                }
                break;
            case MapGrid.MapFilters.Objective:
                foreach (var objective in objectiveList)
                {
                    keyDetailList.Add(new KeyDetails()
                    {
                        KeyColour = objective.Color,
                        KeyText = objective.Name,
                    });
                }
                break;
            //Other cases have no key
            case MapGrid.MapFilters.Colour:
            default:
                noKeyText.SetActive(true);
                break;
        }

        //Create each element in the key
        foreach (var key in keyDetailList)
        {
            var keyObject = Instantiate(keyColourPrefab, keyColourParent.transform);
            keyObject.GetComponent<KeyColourObject>().RefreshKeyElement(key.KeyColour, key.KeyText);
        }
    }

    /// <summary>
    /// 
    /// Button click event for changing the map filter on the displayed grid
    /// 
    /// </summary>
    public void ChangeMapFilter(int mapFilterId)
    {
        var mapFilter = (MapGrid.MapFilters)mapFilterId;
        GameManager.instance.mapGrid.SwitchMapFilter(mapFilter);
        RefreshKey(mapFilter);
    }
}
