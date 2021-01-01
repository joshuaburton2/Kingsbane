using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 
/// Script for handling the tabs in the library screen
/// 
/// </summary>
public class LibraryTab : MonoBehaviour
{
    [SerializeField]
    private Image tabImage;
    [SerializeField]
    private Color selectedTabColour = new Color(1f, 1f, 1f);
    [SerializeField]
    private Color unselectedTabColour = new Color(0.5f, 0.5f, 0.5f);

    private LibraryUI libraryUI;
    public int tabIndex;
    public List<CardData> TabCardList { get; set; }

    /// <summary>
    /// 
    /// Initialise the library tab
    /// 
    /// </summary>
    /// <param name="_tabIndex">The index of the tab in the tab list</param>
    /// <param name="iconType">The type of icon that the tab is required to have</param>
    public void InitLibraryTab<T>(int _tabIndex, List<CardData> _tabCardList, LibraryUI _libraryUI, T iconType)
    {
        libraryUI = _libraryUI;
        tabIndex = _tabIndex;
        TabCardList = _tabCardList.ToList();

        gameObject.GetComponent<Image>().color = unselectedTabColour;
        tabImage.sprite = GameManager.instance.iconManager.GetIcon(iconType);
    }

    /// <summary>
    /// 
    /// Updates the colour of the border of the tab based on whether it is selected or not
    /// 
    /// </summary>
    public void UpdateTabColour(bool isNewTab)
    {
        Color tabColour;

        if (isNewTab)
            tabColour = selectedTabColour;
        else
            tabColour = unselectedTabColour;

        gameObject.GetComponent<Image>().color = tabColour;
    }

    /// <summary>
    /// 
    /// Button click event for selecting the tab
    /// 
    /// </summary>
    public void SelectTab()
    {
        libraryUI.SelectTab(tabIndex);
    }
}
