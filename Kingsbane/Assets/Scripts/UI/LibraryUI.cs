using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryUI : MonoBehaviour
{
    [Header("Grid Settings")]
    [SerializeField]
    private GameObject rowParent;
    private List<GameObject> gridRows;
    [SerializeField]
    private GameObject rowPrefab;
    [SerializeField]
    private int numColumns = 4;
    [SerializeField]
    private int numRows = 2;
    [SerializeField]
    private CardOrdering tabFilter;

    List<List<CardData>> pageList;
    private int CardsPerPage { get { return numColumns * numRows; } }
    private int pageIndex;
    private int tabIndex;
    private int cardCount;

    [Header("Tab Settings")]
    [SerializeField]
    private GameObject tabParent;
    private List<GameObject> tabs;

    private void Start()
    {
        InitGrid();
    }

    private void InitGrid()
    {
        foreach (Transform child in rowParent.transform)
        {
            Destroy(child.gameObject);
        }

        gridRows = new List<GameObject>();
        for (int row = 0; row < numRows; row++)
        {
            gridRows.Add(Instantiate(rowPrefab, rowParent.transform));
            gridRows[row].name = $"Row{row + 1}";
        }

        ResetGrid();
    }

    private void ResetGrid()
    {
        pageIndex = 0;
        tabIndex = 0;

        foreach (GameObject row in gridRows)
        {
            foreach (Transform child in row.transform)
            {
                Destroy(child.gameObject);
            }
        }

        pageList = GameManager.instance.libraryManager.GetAllCardsSplit(tabFilter);

        RefreshGrid();
    }

    private void RefreshGrid()
    {
        var tabList = pageList[tabIndex];

        var startCardIndex = pageIndex * CardsPerPage;

        var currentRow = 0;
        var currentColumn = 0;

        for (int cardIndex = startCardIndex; cardIndex < CardsPerPage + startCardIndex; cardIndex++)
        {
            var currentCard = tabList[cardIndex];
            var newCardObj = GameManager.instance.libraryManager.CreateCard(currentCard, gridRows[currentRow].transform);
            newCardObj.name = $"Card{currentRow}.{currentColumn}- {currentCard.Name}";

            currentColumn++;

            if(currentColumn == numColumns)
            {
                currentRow++;
                currentColumn = 0;
            }
        }
    }
}
