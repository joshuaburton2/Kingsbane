using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// Script for handling the library UI
/// 
/// </summary>
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
    private TMP_Dropdown classplayableDropdown;
    [SerializeField]
    private TMP_Dropdown cardTypeDropdown;
    [SerializeField]
    private TMP_Dropdown rarityDropdown;
    [SerializeField]
    private TMP_Dropdown setDropdown;

    [Header("Other Objects")]
    [SerializeField]
    DeckListUI deckListUI;

    public bool isLoaded = false;
    private CardFilter activeFilter;

    private const string DEFAULT_DROPDOWN_STRING = "All";

    public void LibraryInitialisation()
    {
        InitGrid();
        InitDropdowns();
    }

    /// <summary>
    /// 
    /// Initialise the card grid
    /// 
    /// </summary>
    private void InitGrid()
    {
        GameManager.DestroyAllChildren(rowParent);

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
        GeneralUIExtensions.InitDropdownOfType(classplayableDropdown, new List<Classes.ClassList> { Classes.ClassList.Default }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(cardTypeDropdown, new List<CardTypes>() { CardTypes.Default }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(rarityDropdown, new List<Rarity>() { Rarity.Default, Rarity.Hero, Rarity.NPCHero, Rarity.Uncollectable, Rarity.Deleted }, DEFAULT_DROPDOWN_STRING);
        GeneralUIExtensions.InitDropdownOfType(setDropdown, new List<Sets>() { Sets.Default }, DEFAULT_DROPDOWN_STRING);
    }

    /// <summary>
    /// 
    /// Initialise the tabs in the library
    /// 
    /// </summary>
    private void InitTabs()
    {
        //Destory all current tabs
        GameManager.DestroyAllChildren(tabParent);
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
            leftButton.SetActive(false);
            rightButton.SetActive(false);
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
        //Get the cards from the selected tabs
        pageList = tabList[selectedTabIndex].TabCardList;

        //Gets the count of the number of pages that will be present in the tab (round up the number of cards divided by 
        tabPageCount = (int)Math.Ceiling((float)pageList.Count / CardsPerPage);
        pageListSplit = new List<List<CardData>>();

        //Ending page index is the index of the next card following the last card on a page in the page list
        //Initialily set to 0 to set up the starting page index
        var endingPageIndex = 0;

        //Loops through each of the pages in the tab
        for (int pageIndex = 0; pageIndex < tabPageCount; pageIndex++)
        {
            //Starting page index is the index of the first card on a page in the page list
            //Sets the starting page index to be the 
            var startingPageIndex = endingPageIndex;

            pageListSplit.Add(new List<CardData>());

            //if the page is not the last page in the tab, then page has the maximum number of cards per page, so increases ending index by that much
            if (pageIndex < tabPageCount - 1)
            {
                endingPageIndex += CardsPerPage;
            }
            else
            {
                //Determine how many cards are on the last page (this will be remainder of the division)
                var cardsOnLastPage = pageList.Count % CardsPerPage;
                //If the remainder is 0, this means taht the last page is full, and as such, increases the index to account for a full page
                if (cardsOnLastPage == 0)
                {
                    endingPageIndex += CardsPerPage;
                }
                else
                {
                    //If last page is not full, then increases index by the number of cards on the page
                    endingPageIndex += cardsOnLastPage;
                }
            }

            //Loops through the card list between the starting and ending page index and adds them to the next current pages card list
            for (int cardIndex = startingPageIndex; cardIndex < endingPageIndex; cardIndex++)
            {
                pageListSplit[pageIndex].Add(pageList[cardIndex]);
            }
        }

        //Changes the colour of the currently selected tab
        tabList[selectedTabIndex].UpdateTabColour(true);
    }

    /// <summary>
    /// 
    /// Refreshes the card grid with the currently selected page and tab cards
    /// 
    /// </summary>
    private void RefreshGrid()
    {
        var currentRow = 0;
        var currentColumn = 0;

        DestroyGridCards();

        //Loops through each card in the current page
        foreach (var card in pageListSplit[pageIndex])
        {
            //Initialise the card container
            var cardContainer = Instantiate(cardContainerPrefab, gridRows[currentRow].transform);
            cardContainer.name = $"Container {currentRow}.{currentColumn}- {card.Name}";
            var cardLibaryContainer = cardContainer.GetComponentInChildren<CardLibraryContainer>();
            var cardName = $"Card{currentRow}.{currentColumn}- {card.Name}";
            cardLibaryContainer.InitCardContainer(card, deckListUI, cardName: cardName);

            //Once a card is created, moves to the next column
            currentColumn++;

            //If just passed the last column, moves into the next row and resets the columns
            if (currentColumn == numColumns)
            {
                currentRow++;
                currentColumn = 0;
            }
        }

        //Conditions checking if the left or right button in the library need to be deactivated
        //If there is only one tab and only one page in that tab, then both buttons are turned off
        if (minTab == maxTab && tabPageCount == 1)
        {
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        }
        //If in the minimum tab and in the first page of the tab, then disabled left button
        else if (selectedTabIndex == minTab && pageIndex == 0)
        {
            leftButton.SetActive(false);
            rightButton.SetActive(true);
        }
        //If in the last tab and in the last page of that tab, disables the right button
        else if (selectedTabIndex == maxTab && pageIndex == tabPageCount - 1)
        {
            leftButton.SetActive(true);
            rightButton.SetActive(false);
        }
        //Conditions for any other page
        else
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }
    }

    /// <summary>
    /// 
    /// Destroy all the cards in the grid
    /// 
    /// </summary>
    private void DestroyGridCards()
    {
        foreach (GameObject row in gridRows)
        {
            GameManager.DestroyAllChildren(row);
        }
    }

    /// <summary>
    /// 
    /// Button click function for switching pages
    /// 
    /// </summary>
    public void SwitchPage(int libraryDirection)
    {
        //Library direction will either be 1 for moving right and -1 for moving left in the library
        if (libraryDirection != 1 || libraryDirection != -1)
        {
            //Change the page index by the library direction
            pageIndex += libraryDirection;

            //If the page index goes outside of the range of the tabs pages, moves into the next tab
            if (pageIndex == -1 || pageIndex == tabPageCount)
            {
                //Sets the inactive colour on the current tab, moves to the next tab and then sets the activated colour
                tabList[selectedTabIndex].UpdateTabColour(false);
                selectedTabIndex += libraryDirection;
                tabList[selectedTabIndex].UpdateTabColour(true);
                //Loads the new tab card list
                LoadTabList();
                //Determines if the new tab was moved into the from the left or the right. If right, index will be the lowest page index in the tab
                //If left, index will be the highest page index in the tab
                pageIndex = libraryDirection == 1 ? 0 : tabPageCount - 1;
            }

            RefreshGrid();
        }
        else
        {
            throw new Exception("Not a valid direction input");
        }
    }

    /// <summary>
    /// 
    /// Function for clicking on a library tab
    /// 
    /// </summary>
    public void SelectTab(int newTabIndex)
    {
        //Sets the inactive colour on the current tab, moves to the next tab and then sets the activated colour
        tabList[selectedTabIndex].UpdateTabColour(false);
        selectedTabIndex = newTabIndex;
        tabList[selectedTabIndex].UpdateTabColour(true);
        //Clicking on a new tab will always move page index to the default
        pageIndex = 0;
        //Reload the cards in the tab, and refresh
        LoadTabList();
        RefreshGrid();
    }

    /// <summary>
    /// 
    /// Button function for switching the type of tab filter
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Sets the text to display the active tab filter
    /// 
    /// </summary>
    private void SwitchTabText()
    {
        var text = "Current: " + tabFilter.ToString();
        tabFilterText.text = text;
    }

    /// <summary>
    /// 
    /// Button click function for applying the current filter setting
    /// 
    /// </summary>
    public void ApplyFilter()
    {
        //Checks if the filter already is already allowing uncollectable cards
        var includeUncollectables = activeFilter.RaritiyFilter.Contains(Rarity.Uncollectable);

        //Creates a new filter object
        activeFilter = new CardFilter();

        //Updates the new filters with the carry over properties of the old filter
        UpdateUncollectableStatus(includeUncollectables);

        //Sets the uncollectable button to be turned on by default
        uncollectableText.transform.parent.GetComponent<Button>().interactable = true;

        //Updates the filter with the selected properties
        activeFilter.SearchString = searchStringInput.text;
        activeFilter = ApplyDropdownFilter<Classes.ClassList>(classplayableDropdown, activeFilter);
        activeFilter = ApplyDropdownFilter<CardTypes>(cardTypeDropdown, activeFilter);
        activeFilter = ApplyDropdownFilter<Rarity>(rarityDropdown, activeFilter);
        activeFilter = ApplyDropdownFilter<Sets>(setDropdown, activeFilter);

        //Recreate the tabs
        InitTabs();
    }

    /// <summary>
    /// 
    /// Apply the filter for a dropdown of a particular type
    /// 
    /// </summary>
    private CardFilter ApplyDropdownFilter<T>(TMP_Dropdown dropdown, CardFilter activeFilter)
    {
        //If the text is All, do not need to apply the filter
        if (dropdown.captionText.text != DEFAULT_DROPDOWN_STRING)
        {
            //Parses the selected value into the enum
            var selectedField = (T)Enum.Parse(typeof(T), dropdown.captionText.text);
            var type = typeof(T);

            //Sets the filter to include the selected option based on the type of dropdown
            switch (type)
            {
                case Type _ when type == typeof(Classes.ClassList):
                    activeFilter.ClassPlayableFilter = (Classes.ClassList)(object)selectedField;
                    break;
                case Type _ when type == typeof(CardTypes):
                    activeFilter.CardTypeFilter = new List<CardTypes>() { (CardTypes)(object)selectedField };
                    break;
                case Type _ when type == typeof(Rarity):
                    activeFilter.RaritiyFilter = new List<Rarity>() { (Rarity)(object)selectedField };
                    //If there is a rarity filter, prevents uncollectable cards from being readded to the filter
                    if (activeFilter.RaritiyFilter.Contains(Rarity.Uncollectable))
                    {
                        UpdateUncollectableStatus(false);
                    }
                    uncollectableText.transform.parent.GetComponent<Button>().interactable = false;
                    break;
                case Type _ when type == typeof(Sets):
                    activeFilter.SetFilter = new List<Sets>() { (Sets)(object)selectedField };
                    break;
            }
        }

        return activeFilter;
    }

    /// <summary>
    /// 
    /// Applies the filter to filter out cards which are not available to the given class
    /// 
    /// </summary>
    /// <param name="classAbailabilityFilter"></param>
    public void ApplyClassPlayableFilter(Classes.ClassList classAbailabilityFilter = Classes.ClassList.Default)
    {
        activeFilter.ClassPlayableFilter = classAbailabilityFilter;

        if (classAbailabilityFilter != Classes.ClassList.Default)
        {
            classplayableDropdown.value = classplayableDropdown.options.FindIndex(x => x.text == classAbailabilityFilter.ToString());
            classplayableDropdown.interactable = false;
        }
        else
        {
            classplayableDropdown.value = 0;
            classplayableDropdown.interactable = true;
        }

        InitTabs();
    }

    /// <summary>
    /// 
    /// Button click function to filter in or out uncollectable cards
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Updates the filter to either include or not include uncollectable cards
    /// 
    /// </summary>
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
