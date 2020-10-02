using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class LibraryUI : MonoBehaviour
{
    private enum TabTypes
    {
        Classes,
        Resources
    }

    [Header("Grid Settings")]
    [SerializeField]
    private GameObject rowParent;
    private List<GameObject> gridRows;
    [SerializeField]
    private GameObject rowPrefab;
    [SerializeField]
    private GameObject cardContainerPrefab;
    [SerializeField]
    private int numColumns = 4;
    [SerializeField]
    private int numRows = 2;
    [SerializeField]
    private TabTypes tabFilter = TabTypes.Classes;
    [SerializeField]
    private GameObject leftButton;
    [SerializeField]
    private GameObject rightButton;
    [SerializeField]
    private GameObject noResultsText;

    List<CardData> pageList;
    List<List<CardData>> pageListSplit;
    private int CardsPerPage { get { return numColumns * numRows; } }
    private int pageIndex;
    private int selectedTabIndex;
    private int tabPageCount;

    [Header("Tab Settings")]
    [SerializeField]
    private GameObject tabParent;
    [SerializeField]
    private GameObject tabPrefab;
    [SerializeField]
    private List<LibraryTab> tabList;
    private int minTab;
    private int maxTab;

    [Header("Filter Settings")]
    [SerializeField]
    private TextMeshProUGUI tabFilterText;
    [SerializeField]
    private TMP_InputField searchStringInput;
    [SerializeField]
    private TextMeshProUGUI uncollectableText;
    [SerializeField]
    private TMP_Dropdown cardTypeDropdown;
    [SerializeField]
    private TMP_Dropdown rarityDropdown;
    [SerializeField]
    private TMP_Dropdown setDropdown;

    private CardFilter activeFilter;

    [Header("Other Objects")]
    [SerializeField]
    DeckListUI deckListUI;

    private void Start()
    {
        InitGrid();
        InitDropdowns();
    }

    /// <summary>
    /// 
    /// Initialise the card grid. Should only be called on start
    /// 
    /// </summary>
    private void InitGrid()
    {
        GameManager.DestroyAllChildren(rowParent.transform);

        //Initialise the row objects in the grid. Row parent has a vertical layout group. Row has a horizontal layout group
        //Reason for using these instead of grid layout group was for the purpose of object scaling, but also for easier control
        //of size of grid. Could refactor if required but either way works well
        gridRows = new List<GameObject>();
        for (int row = 0; row < numRows; row++)
        {
            gridRows.Add(Instantiate(rowPrefab, rowParent.transform));
            gridRows[row].name = $"Row{row + 1}";
        }

        activeFilter = new CardFilter();
        SwitchTabText();

        InitTabs();
    }

    /// <summary>
    /// 
    /// Initialises the filter dropdowns with their particular options
    /// 
    /// </summary>
    private void InitDropdowns()
    {
        InitDropdownOfType(cardTypeDropdown, new List<CardTypes>() { CardTypes.Default });
        InitDropdownOfType(rarityDropdown, new List<Rarity>() { Rarity.Default, Rarity.Hero, Rarity.NPCHero, Rarity.Uncollectable });
        InitDropdownOfType(setDropdown, new List<Sets>() { Sets.Default });
    }

    /// <summary>
    /// 
    /// Initialise a given dropdowns options using an enum of type T. Removes a given set of values from the enum as options
    /// 
    /// </summary>
    private void InitDropdownOfType<T>(TMP_Dropdown dropdown, List<T> removedList)
    {
        //Get the string values of the enum
        var dropDownNames = Enum.GetNames(typeof(T)).ToList();
        //Removes the necessary values from the list
        foreach (var removeItem in removedList)
        {
            var removeString = removeItem.ToString();
            dropDownNames.Remove(removeString);
        }
        //Add the options to the dropdown box
        dropdown.AddOptions(dropDownNames);
    }

    /// <summary>
    /// 
    /// Initialise the tabs in the library
    /// 
    /// </summary>
    private void InitTabs()
    {
        //Destory all current tabs
        GameManager.DestroyAllChildren(tabParent.transform);
        tabList = new List<LibraryTab>();

        //Load the tabs of the given tab type
        switch (tabFilter)
        {
            case TabTypes.Classes:
                LoadTabsofType<Classes.ClassList>();
                break;
            case TabTypes.Resources:
                LoadTabsofType<CardResources>();
                break;
        }

        //Set the minimum and maximum tab index to check if the player is inside the active tabs
        minTab = 0;
        maxTab = tabList.Count - 1;

        //Checks if there are any cards in the list to display
        if (tabList.Count != 0)
        {
            noResultsText.SetActive(false);
            ResetGrid();
        }
        else
        {
            noResultsText.SetActive(true);
            DestroyGridCards();
        }
    }

    /// <summary>
    /// 
    /// Load and initalise the tabs of the required tab type (Classes or Resources)
    /// 
    /// </summary>
    private void LoadTabsofType<T>() where T : Enum
    {
        //Index is used for tracking the index of the tab in the list
        var index = 0;

        //Loops through each of the possible tabs
        foreach (var type in Enum.GetValues(typeof(T)))
        {
            //Gets the list of cards which would appear in the current tab, and starts initialising the tab if there are cards in the tab
            List<CardData> tabCardList = GameManager.instance.libraryManager.GetDictionaryList((T)type, activeFilter);
            if (tabCardList.Count != 0)
            {
                //Creates the tab object
                var newTab = Instantiate(tabPrefab, tabParent.transform);
                newTab.name = $"Tab{index}- {(T)type}";

                //Initialise the tab properties
                var libraryTab = newTab.GetComponent<LibraryTab>();
                libraryTab.InitLibraryTab(index, tabCardList, this, (T)type);
                tabList.Add(libraryTab);

                //Increases the index
                index++;
            }
        }
    }

    /// <summary>
    /// 
    /// Resets the grid back to its default state
    /// 
    /// </summary>
    private void ResetGrid()
    {
        pageIndex = 0;
        selectedTabIndex = minTab;
        
        LoadTabList();
        RefreshGrid();
    }

    /// <summary>
    /// 
    /// Loads the cards in the currently selected tab into the page list
    /// 
    /// </summary>
    private void LoadTabList()
    {
        pageList = tabList[selectedTabIndex].TabCardList;

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

        tabList[selectedTabIndex].UpdateTabColour(true);
    }

    private void RefreshGrid()
    {
        var currentRow = 0;
        var currentColumn = 0;

        DestroyGridCards();

        foreach (var card in pageListSplit[pageIndex])
        {
            var cardContainer = Instantiate(cardContainerPrefab, gridRows[currentRow].transform);
            cardContainer.name = $"Container {currentRow}.{currentColumn}- {card.Name}";
            var cardLibaryContainer = cardContainer.GetComponentInChildren<CardLibraryContainer>();
            var cardName = $"Card{currentRow}.{currentColumn}- {card.Name}";
            cardLibaryContainer.InitCardContainer(card, deckListUI, cardName);

            currentColumn++;

            if (currentColumn == numColumns)
            {
                currentRow++;
                currentColumn = 0;
            }
        }

        if (minTab == maxTab && tabPageCount == 1)
        {
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        }
        else if (selectedTabIndex == minTab && pageIndex == 0)
        {
            leftButton.SetActive(false);
            rightButton.SetActive(true);
        }
        else if (selectedTabIndex == maxTab && pageIndex == tabPageCount - 1)
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

    private void DestroyGridCards()
    {
        foreach (GameObject row in gridRows)
        {
            GameManager.DestroyAllChildren(row.transform);
        }
    }

    public void SwitchPage(int libraryDirection)
    {
        pageIndex += libraryDirection;

        if (pageIndex == -1 || pageIndex == tabPageCount)
        {
            tabList[selectedTabIndex].UpdateTabColour(false);
            selectedTabIndex += libraryDirection;
            tabList[selectedTabIndex].UpdateTabColour(true);
            LoadTabList();
            pageIndex = libraryDirection == 1 ? 0 : tabPageCount - 1;
        }

        RefreshGrid();
    }

    public void SelectTab(int newTabIndex)
    {
        tabList[selectedTabIndex].UpdateTabColour(false);
        selectedTabIndex = newTabIndex;
        tabList[selectedTabIndex].UpdateTabColour(true);
        pageIndex = 0;
        LoadTabList();
        RefreshGrid();
    }

    public void SwitchTabType()
    {
        switch (tabFilter)
        {
            case TabTypes.Classes:
                tabFilter = TabTypes.Resources;
                SwitchTabText();
                break;
            case TabTypes.Resources:
                tabFilter = TabTypes.Classes;
                SwitchTabText();
                break;
        }

        InitTabs();
    }

    private void SwitchTabText()
    {
        var text = "Current: " + tabFilter.ToString();
        tabFilterText.text = text;
    }

    public void ApplyFilter()
    {
        var includeUncollectables = activeFilter.RaritiyFilter.Contains(Rarity.Uncollectable);
        var resourceFilter = activeFilter.ClassPlayableFilter;

        activeFilter = new CardFilter();

        if (includeUncollectables)
        {
            UpdateUncollectableStatus(true);
        }

        activeFilter.SearchString = searchStringInput.text;
        activeFilter.ClassPlayableFilter = resourceFilter;

        uncollectableText.transform.parent.GetComponent<Button>().interactable = true;

        activeFilter = ApplyDropdownFilter<CardTypes>(cardTypeDropdown, activeFilter);
        activeFilter = ApplyDropdownFilter<Rarity>(rarityDropdown, activeFilter);
        activeFilter = ApplyDropdownFilter<Sets>(setDropdown, activeFilter);

        InitTabs();
    }

    private CardFilter ApplyDropdownFilter<T>(TMP_Dropdown dropdown, CardFilter activeFilter)
    {
        if (dropdown.captionText.text != "All")
        {
            var selectedCardType = (T)Enum.Parse(typeof(T), dropdown.captionText.text);
            var type = typeof(T);

            switch (type)
            {
                case Type _ when type == typeof(CardTypes):
                    activeFilter.CardTypeFilter = new List<CardTypes>() { (CardTypes)(object)selectedCardType };
                    break;
                case Type _ when type == typeof(Rarity):
                    activeFilter.RaritiyFilter = new List<Rarity>() { (Rarity)(object)selectedCardType };
                    if (activeFilter.RaritiyFilter.Contains(Rarity.Uncollectable))
                    {
                        UpdateUncollectableStatus(false);
                    }
                    uncollectableText.transform.parent.GetComponent<Button>().interactable = false;
                    break;
                case Type _ when type == typeof(Sets):
                    activeFilter.SetFilter = new List<Sets>() { (Sets)(object)selectedCardType };
                    break;
            }            
        }

        return activeFilter;
    }

    public void FilterUncollectables()
    {
        if (!activeFilter.RaritiyFilter.Contains(Rarity.Uncollectable))
        {
            uncollectableText.text = "Hide Uncollectable Cards";
            UpdateUncollectableStatus(true);
        }
        else
        {
            uncollectableText.text = "Show Uncollectable Cards";
            UpdateUncollectableStatus(false);
        }

        InitTabs();
    }

    public void ApplyClassPlayableFilter(Classes.ClassList classAbailabilityFilter)
    {
        activeFilter.ClassPlayableFilter = classAbailabilityFilter;

        InitTabs();
    }

    private void UpdateUncollectableStatus(bool isAdded)
    {
        if (isAdded)
        {
            activeFilter.RaritiyFilter.Add(Rarity.Uncollectable);
            activeFilter.RaritiyFilter.Add(Rarity.Hero);
        }
        else
        {
            activeFilter.RaritiyFilter.Remove(Rarity.Uncollectable);
            activeFilter.RaritiyFilter.Remove(Rarity.Hero);
        }
    }
}
