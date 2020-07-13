using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Script for handling the generation of the map grid as well as for objects pathfinding through the map.
/// Should be called whenever a new level is loaded into
/// 
/// </summary>
public class MapGrid : MonoBehaviour
{
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

    public void Start()
    {
        rowList = new GameObject[numY];
        cellList = new GameObject[numY][];

        #region Row Initialisation
        //Initialise the rows to store each of the cells. This has no functional purpose but is for organisation within the scene
        for (int y = 0; y < numY; y++)
        {
            cellList[y] = new GameObject[numX];

            GameObject rowObject = new GameObject(string.Format("Row{0}", y));
            rowObject.transform.parent = transform;
            rowList[y] = rowObject;
        }
        #endregion

        #region Cell Instantiation
        //Set the first position to initialise (the bottom left of the grid)
        Vector3 currentPos = gridOrigin;

        //Calculate the x and y distances to offset the tiles in order for the hexes to tessalate
        //The y distance is the distance between the rows.
        //The x offset is the shift every second row has to be pushed to the right
        float xOffset = hexDistance / 2;
        float yOffset = hexDistance * (Mathf.Sqrt(3)) / 2;

        //Loop for instantiation each of the cells within the scene and add it to the list of all cells
        for (int y = 0; y < numY; y++)
        {
            for (int x = 0; x < numX; x++)
            {
                GameObject newCell = Instantiate(cellObject, currentPos, Quaternion.Euler(new Vector3(0, 0, 0)), rowList[y].transform);
                newCell.name = string.Format("Cell{0}.{1}", y, x);
                newCell.GetComponent<Cell>().gridIndex = new Vector2(y, x);

                cellList[y][x] = newCell;

                currentPos += new Vector3(hexDistance, 0, 0);
            }

            currentPos += new Vector3((-hexDistance * numX), yOffset, 0);
            currentPos.x = y % 2 == 0 ? currentPos.x + xOffset : currentPos.x - xOffset;
        }
        #endregion

        #region Cell Data Retrieval
        //Loop for setting the properties of each of the cells based on cell data of the particular level
        //Current data operated on is:
        // - adjacent cells
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
            }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// Retrieves the cell object from cell list based on its x and y coordinates in the grid
    /// 
    /// </summary>
    public GameObject GetCell(int x, int y)
    {
        return cellList[y][x];
    }
}
