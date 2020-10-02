using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LibraryTab : MonoBehaviour, IPointerClickHandler
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

    public void InitLibraryTab<T>(int _tabIndex, List<CardData> _tabCardList, LibraryUI _libraryUI, T iconType)
    {
        libraryUI = _libraryUI;
        tabIndex = _tabIndex;
        TabCardList = _tabCardList.ToList();

        gameObject.GetComponent<Image>().color = unselectedTabColour;
        tabImage.sprite = GameManager.instance.iconManager.GetIcon(iconType);
    }

    public void UpdateTabColour(bool isNewTab)
    {
        Color tabColour;

        if (isNewTab)
            tabColour = selectedTabColour;
        else
            tabColour = unselectedTabColour;

        gameObject.GetComponent<Image>().color = tabColour;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            libraryUI.SelectTab(tabIndex);
        }
    }
}
