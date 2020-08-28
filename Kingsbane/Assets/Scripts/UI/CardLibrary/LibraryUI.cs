using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LibraryUI : MonoBehaviour
{
    private enum TabTypes
    {
        Classes,
        Resources
    }

    [System.Serializable]
    private class LibraryTab
    {
        public int tabIndex;
        public string tabName;
        public List<CardData> tabCardList;
        public GameObject tabObject;
    }

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
    private TabTypes tabFilter;
    [SerializeField]
    private GameObject leftButton;
    [SerializeField]
    private GameObject rightButton;

    List<CardData> pageList;
    List<List<CardData>> pageListSplit;
    private int CardsPerPage { get { return numColumns * numRows; } }
    private int pageIndex;
    private int tabIndex;
    private int tabPageCount;

    [Header("Tab Settings")]
    [SerializeField]
    private GameObject tabParent;
    [SerializeField]
    private GameObject tabPrefab;
    [SerializeField]
    private List<LibraryTab> tabList;
    [SerializeField]
    private Color selectedTabColour = new Color (1f, 1f, 1f);
    [SerializeField]
    private Color unselectedTabColour = new Color (0.5f, 0.5f, 0.5f);
    private int minTab;
    private int maxTab;

    private readonly CardFilter defaultFilter = new CardFilter();

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

        InitTabs();
        ResetGrid();
    }

    private void InitTabs()
    {
        foreach (var tab in tabList)
            Destroy(tab.tabObject);

        tabList = new List<LibraryTab>();

        switch (tabFilter)
        {
            case TabTypes.Classes:
                LoadTabsofType<Classes.ClassList>();
                break;
            case TabTypes.Resources:
                LoadTabsofType<CardResources>();
                break;
        }

        minTab = 0;
        maxTab = tabList.Count - 1;
    }

    private void LoadTabsofType<T>() where T : Enum
    {
        var index = 0;

        foreach (var type in Enum.GetValues(typeof(T)))
        {
            List<CardData> tabCardList = GameManager.instance.libraryManager.GetDictionaryList((T)type, defaultFilter);
            if (tabCardList.Count != 0)
            {
                var libraryTab = new LibraryTab();

                var newTab = Instantiate(tabPrefab, tabParent.transform);
                var newTabButton = newTab.GetComponent<Button>();
                var clickIndex = index;
                newTabButton.onClick.AddListener( () => { SelectTab(clickIndex); });
                index++;

                libraryTab.tabIndex = (int)type;
                libraryTab.tabCardList = tabCardList;
                libraryTab.tabName = ((T)type).ToString();
                newTab.name = $"Tab{libraryTab.tabIndex}- {libraryTab.tabName}";
                libraryTab.tabObject = newTab;

                newTab.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite =
                    GameManager.instance.iconManager.getIcon((T)type);

                tabList.Add(libraryTab);
            }
        }
    }

    private void ResetGrid()
    {
        pageIndex = 0;
        tabIndex = minTab;
        
        LoadTabList();
        RefreshGrid();
    }

    private void LoadTabList()
    {
        pageList = GetTabList();

        tabPageCount = (int)Math.Ceiling((float)pageList.Count / CardsPerPage);
        pageListSplit = new List<List<CardData>>();

        var endingPageIndex = 0;

        for (int pageIndex = 0; pageIndex < tabPageCount; pageIndex++)
        {
            var startingPageIndex = endingPageIndex;

            pageListSplit.Add(new List<CardData>());

            if (pageIndex < tabPageCount - 1 || (pageIndex == tabPageCount - 1 && pageList.Count % CardsPerPage == 0))
                endingPageIndex += CardsPerPage;
            else
                endingPageIndex += pageList.Count % CardsPerPage;

            for (int cardIndex = startingPageIndex; cardIndex < endingPageIndex; cardIndex++)
            {
                pageListSplit[pageIndex].Add(pageList[cardIndex]);
            }
        }

        UpdateTabColour(true);
    }

    private List<CardData> GetTabList()
    {
        var currentTab = tabList[tabIndex];
        return currentTab.tabCardList;
    }

    private void RefreshGrid()
    {
        var currentRow = 0;
        var currentColumn = 0;

        foreach (GameObject row in gridRows)
        {
            foreach (Transform child in row.transform)
            {
                Destroy(child.gameObject);
            }
        }

        foreach (var card in pageListSplit[pageIndex])
        {
            var newCardObj = GameManager.instance.libraryManager.CreateCard(card, gridRows[currentRow].transform);
            newCardObj.name = $"Card{currentRow}.{currentColumn}- {card.Name}";

            currentColumn++;

            if (currentColumn == numColumns)
            {
                currentRow++;
                currentColumn = 0;
            }
        }

        if (tabIndex == minTab && pageIndex == 0)
        {
            leftButton.SetActive(false);
            rightButton.SetActive(true);
        }
        else if (tabIndex == maxTab && pageIndex == tabPageCount - 1)
        {
            leftButton.SetActive(true);
            rightButton.SetActive(false);
        }
        else
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }

        
    }

    public void SwitchPage(int libraryDirection)
    {
        pageIndex += libraryDirection;

        if (pageIndex == -1 || pageIndex == tabPageCount)
        {
            UpdateTabColour(false);
            tabIndex += libraryDirection;
            UpdateTabColour(true);
            LoadTabList();
            pageIndex = libraryDirection == 1 ? 0 : tabPageCount - 1;
        }

        RefreshGrid();
    }

    public void SelectTab(int newTabIndex)
    {
        UpdateTabColour(false);
        tabIndex = newTabIndex;
        UpdateTabColour(true);
        pageIndex = 0;
        LoadTabList();
        RefreshGrid();
    }

    public void UpdateTabColour(bool isNewTab)
    {
        Color tabColour;

        if (isNewTab)
            tabColour = selectedTabColour;
        else
            tabColour = unselectedTabColour;

        tabList[tabIndex].tabObject.GetComponent<Image>().color = tabColour;
    }

    public void SwitchTabType()
    {
        switch (tabFilter)
        {
            case TabTypes.Classes:
                tabFilter = TabTypes.Resources;
                break;
            case TabTypes.Resources:
                tabFilter = TabTypes.Classes;
                break;
        }

        InitTabs();
        ResetGrid();
    }
}
