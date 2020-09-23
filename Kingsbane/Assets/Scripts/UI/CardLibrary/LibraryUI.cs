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

        tabFilter = TabTypes.Classes;
        activeFilter = new CardFilter();
        SwitchTabText();

        InitTabs();
    }

    private void InitDropdowns()
    {
        InitDropdown(cardTypeDropdown, new List<CardTypes>() { CardTypes.Default });
        InitDropdown(rarityDropdown, new List<Rarity>() { Rarity.Default, Rarity.Hero, Rarity.NPCHero, Rarity.Uncollectable });
        InitDropdown(setDropdown, new List<Sets>() { Sets.Default });
    }

    private void InitDropdown<T>(TMP_Dropdown dropdown, List<T> removedList)
    {
        var dropDownNames = Enum.GetNames(typeof(T)).ToList();
        foreach (var removeItem in removedList)
        {
            var removeString = removeItem.ToString();
            dropDownNames.Remove(removeString);
        }
        dropdown.AddOptions(dropDownNames);
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

    private void LoadTabsofType<T>() where T : Enum
    {
        var index = 0;

        foreach (var type in Enum.GetValues(typeof(T)))
        {
            List<CardData> tabCardList = GameManager.instance.libraryManager.GetDictionaryList((T)type, activeFilter);
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

        DestroyGridCards();

        foreach (var card in pageListSplit[pageIndex])
        {
            var cardContainer = Instantiate(cardContainerPrefab, gridRows[currentRow].transform);
            cardContainer.name = $"Container {currentRow}.{currentColumn}- {card.Name}";
            var cardLibaryContainer = cardContainer.GetComponentInChildren<CardLibraryContainer>();
            var cardName = $"Card{currentRow}.{currentColumn}- {card.Name}";
            cardLibaryContainer.InitCardContainer(card, deckListUI, 0.37f, cardName);

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
        else if (tabIndex == minTab && pageIndex == 0)
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

    private void DestroyGridCards()
    {
        foreach (GameObject row in gridRows)
        {
            foreach (Transform child in row.transform)
            {
                Destroy(child.gameObject);
            }
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
