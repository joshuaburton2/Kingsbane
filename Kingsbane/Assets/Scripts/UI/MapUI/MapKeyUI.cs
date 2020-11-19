using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;
using System;
using System.Linq;

public class MapKeyUI : MonoBehaviour
{
    private class KeyDetails
    {
        public Color keyColour { get; set; }
        public string keyText { get; set; }
    }

    [SerializeField]
    private GameObject keyColourPrefab;
    [SerializeField]
    private GameObject keyColourParent;
    [SerializeField]
    private GameObject noKeyText;

    public void RefreshKey(MapGrid.MapFilters keyType, List<Objective> objectiveList = null)
    {
        noKeyText.SetActive(false);
        GameManager.DestroyAllChildren(keyColourParent);

        var keyDetailList = new List<KeyDetails>();

        switch (keyType)
        {
            case MapGrid.MapFilters.Terrain:
                foreach (var terrainKey in Enum.GetValues(typeof(TerrainTypes)).Cast<TerrainTypes>())
                {
                    keyDetailList.Add(new KeyDetails()
                    {
                        keyColour = GameManager.instance.colourManager.GetTerrainColour(terrainKey),
                        keyText = terrainKey.ToString(),
                    });
                }
                break;
            case MapGrid.MapFilters.Deployment:
                for (int i = 0; i < 2; i++)
                {
                    keyDetailList.Add(new KeyDetails()
                    {
                        keyColour = GameManager.instance.colourManager.GetPlayerColour(i),
                        keyText = $"Player {i + 1}",
                    });
                }
                break;
            case MapGrid.MapFilters.Objective:
                foreach (var objective in objectiveList)
                {
                    keyDetailList.Add(new KeyDetails()
                    {
                        keyColour = objective.Color,
                        keyText = objective.Name,
                    });
                }
                break;
            case MapGrid.MapFilters.Colour:
            default:
                noKeyText.SetActive(true);
                break;
        }

        foreach (var key in keyDetailList)
        {
            var keyObject = Instantiate(keyColourPrefab, keyColourParent.transform);
            keyObject.GetComponent<KeyColourObject>().RefreshKeyElement(key.keyColour, key.keyText);
        }
    }
}
