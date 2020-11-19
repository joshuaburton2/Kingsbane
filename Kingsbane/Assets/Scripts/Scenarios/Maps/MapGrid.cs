using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

/// <summary>
/// 
/// Script for handling the generation of the map grid as well as for objects pathfinding through the map.
/// Should be called whenever a new level is loaded into
/// 
/// </summary>
public class MapGrid : MonoBehaviour
{
    public enum MapFilters
    {
        Colour,
        Terrain,
        Deployment,
        Objective,
    }

    private GameObject[] rowList;
    private GameObject[][] cellList;

    [SerializeField]
    private GameObject cellObject;

    [SerializeField]
    //Number of cells in the x direction
    private int numX = 10;
    [SerializeField]
    //Number of cells in the y direction
    private int numY = 10;

    [SerializeField]
    //The position for the first cell (bottom left in the grid) to be instantiated
    private Vector3 gridOrigin;

    [SerializeField]
    //Distance between the centres of the hexes in the x direction
    private float hexDistance = 10.0f;

    [SerializeField]
    private float scalingFactor = 1.0f;

    private Vector3 baseCellScale;

    private MapFilters activeMapFilter;

    private void Start()
    {
        baseCellScale = cellObject.transform.localScale;
        activeMapFilter = MapFilters.Colour;
    }

    [ContextMenu("Refresh Grid")]
    public void RefreshGrid(Map mapData, int scenarioId)
    {
        var scaledHexDistance = hexDistance * scalingFactor;

        rowList = new GameObject[numY];
        cellList = new GameObject[numY][];

        GameManager.DestroyAllChildren(gameObject);

        #region Row Initialisation
        //Initialise the rows to store each of the cells. This has no functional purpose but is for organisation within the scene
        for (int y = 0; y < numY; y++)
        {
            cellList[y] = new GameObject[numX];

            GameObject rowObject = new GameObject(string.Format("Row{0}", y));
            rowObject.transform.parent = transform;
            rowObject.transform.localPosition = new Vector3();
            rowList[y] = rowObject;
        }
        #endregion

        #region Cell Instantiation
        //Set the first position to initialise (the top left of the grid)
        Vector3 currentPos = gridOrigin * scalingFactor;

        //Calculate the x and y distances to offset the tiles in order for the hexes to tessalate
        //The y distance is the distance between the rows.
        //The x offset is the shift every second row has to be pushed to the right
        float xOffset = scaledHexDistance / 2;
        float yOffset = scaledHexDistance * (Mathf.Sqrt(3)) / 2;

        //Loop for instantiation each of the cells within the scene and add it to the list of all cells
        for (int y = 0; y < numY; y++)
        {
            for (int x = 0; x < numX; x++)
            {
                GameObject newCell = Instantiate(cellObject, new Vector3(), Quaternion.Euler(new Vector3(0, 0, 0)), rowList[y].transform);
                newCell.transform.localPosition = currentPos;
                newCell.name = string.Format("Cell{0}.{1}", y, x);
                newCell.transform.localScale = baseCellScale * scalingFactor;
                newCell.GetComponent<Cell>().gridIndex = new Vector2(y, x);

                cellList[y][x] = newCell;

                currentPos += new Vector3(scaledHexDistance, 0, 0);
            }

            //Once the row has finished being initialised, resets the x pos to the start of the row and then moves the y position to the next row
            currentPos += new Vector3(-scaledHexDistance * numX, -yOffset, 0);
            //Shifts the row back or forth depending on whether in an odd or even row
            currentPos.x = y % 2 == 0 ? currentPos.x + xOffset : currentPos.x - xOffset;
        }
        #endregion

        #region Cell Data Retrieval
        //Loop for setting the properties of each of the cells based on cell data of the particular level
        //Current data operated on is:
        // - adjacent cells
        // - terrain type
        // - deployment eligibility (basic)
        // - objectives

        //Gets the required scenario
        var selectedScenario = mapData.Scenarios.FirstOrDefault(x => x.Id == scenarioId);

        for (int y = 0; y < numY; y++)
        {
            for (int x = 0; x < numX; x++)
            {
                Cell cell = GetCell(x, y).GetComponent<Cell>();
                cell.adjCell = new List<GameObject>();

                #region Adjacent Cell Handling
                //Add cells above the current cell. Does not consider the top row
                if (y != numY - 1)
                {
                    //All cells will be adjacent to the cell in the above row which has the same index as them
                    cell.adjCell.Add(GetCell(x, y + 1));

                    //If on an odd row and not in the right hand column, an adjacent cell above this one will have an x index of one greater
                    if (y % 2 == 1 && x != numX - 1)
                    {
                        cell.adjCell.Add(GetCell(x + 1, y + 1));
                    }
                    //If on an even row and not in the left hand column, an adjacent cell above this one will have an x index of one less
                    if (y % 2 == 0 && x != 0)
                    {
                        cell.adjCell.Add(GetCell(x - 1, y + 1));
                    }
                }

                //Add cell to the right of the current cell. Does not consider the right hand column
                if (x != numX - 1)
                {
                    cell.adjCell.Add(GetCell(x + 1, y));
                }

                if (y != 0)
                {
                    //All cells will be adjacent to the cell in the below row which has the same index as them
                    cell.adjCell.Add(GetCell(x, y - 1));

                    //If on an odd row and not in the right hand column, an adjacent cell below this one will have an x index of one greater
                    if (y % 2 == 1 && x != numX - 1)
                    {
                        cell.adjCell.Add(GetCell(x + 1, y - 1));
                    }
                    //If on an even row and not in the left hand column, an adjacent cell below this one will have an x index of one less
                    if (y % 2 == 0 && x != 0)
                    {
                        cell.adjCell.Add(GetCell(x - 1, y - 1));
                    }
                }

                //Add cell to the left of the current cell. Does not consider the left hand column
                if (x != 0)
                {
                    cell.adjCell.Add(GetCell(x - 1, y));
                }

                #endregion

                cell.terrainType = mapData.TerrainMap[y][x];
                cell.playerDeploymentId = selectedScenario.DeploymentMap[y][x];

                var objectiveId = selectedScenario.ObjectivesMap[y][x];
                cell.objective = selectedScenario.Objectives.FirstOrDefault(i => i.Id == objectiveId);
            }
        }
        #endregion

        SwitchMapFilter(activeMapFilter);
    }

    /// <summary>
    /// 
    /// Retrieves the cell object from cell list based on its x and y coordinates in the grid
    /// 
    /// </summary>
    private GameObject GetCell(int x, int y)
    {
        return cellList[y][x];
    }

    public void SwitchMapFilter(MapFilters filterType)
    {
        activeMapFilter = filterType;

        for (int y = 0; y < numY; y++)
        {
            for (int x = 0; x < numX; x++)
            {
                Cell cell = GetCell(x, y).GetComponent<Cell>();

                switch (filterType)
                {
                    case MapFilters.Terrain:
                        var terrainColour = GameManager.instance.colourManager.GetTerrainColour(cell.terrainType);
                        cell.SetBackgroundColour(terrainColour, true);
                        break;
                    case MapFilters.Deployment:
                        if (cell.playerDeploymentId.HasValue)
                        {
                            var deploymentColour = GameManager.instance.colourManager.GetPlayerColour(cell.playerDeploymentId.Value);
                            cell.SetBackgroundColour(deploymentColour, true);
                        }
                        else
                        {
                            cell.HideBackground();
                        }
                        break;
                    case MapFilters.Objective:
                        if (cell.objective != null)
                        {
                            cell.SetBackgroundColour(cell.objective.Color, true);
                        }
                        else
                        {
                            cell.HideBackground();
                        }
                        break;
                    default:
                    case MapFilters.Colour:
                        cell.HideBackground();
                        break;
                }
            }
        }
    }
}
