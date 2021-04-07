using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterFateUI : MonoBehaviour
{
    [SerializeField]
    private GameObject alterFateParent;
    [SerializeField]
    private GameObject alterFateContainerPrefab;
    [SerializeField]
    private GameObject hideArea;
    [SerializeField]
    private GameObject backgroundFade;

    private List<Card> HandCards { get; set; }
    private List<Card> DeckCards { get; set; }
    private int CardCount { get; set; }
    private int NumPages { get; set; }
    private int NumPerPage { get; set; }

    private List<List<Card>> SplitHandCards { get; set; }
    private List<List<Card>> SplitDeckCards { get; set; }

    private int CurrentPage { get; set; }

    private const int MAX_NUM_PER_PAGE = 5;

    public void DisplayAlterFate(List<Card> handCards, List<Card> deckCards)
    {
        GameManager.DestroyAllChildren(alterFateParent);
        backgroundFade.SetActive(true);

        if (handCards.Count != deckCards.Count)
            throw new Exception("Cannot Alter Fate with lists of different length");
        else
            CardCount = HandCards.Count;

        HandCards = handCards;
        DeckCards = deckCards;

        CurrentPage = 0;

        RefreshCards();
    }

    public void RefreshCards()
    {
        SplitHandCards = new List<List<Card>>();
        SplitDeckCards = new List<List<Card>>();

        NumPages = CardCount / MAX_NUM_PER_PAGE;
        NumPerPage = CardCount / NumPages;

        for (int pageIndex = 0; pageIndex < NumPages; pageIndex++)
        {
            
        }
    }

    public void SwitchPages()
    {
        CurrentPage = CurrentPage == 0 ? 1 : 0;

        RefreshCurrentPage();
    }

    public void RefreshCurrentPage()
    {

    }

    public void SwapCard(Card handCard, Card deckCard)
    {


        RefreshCards();
    }

    public void ConfirmButton()
    {

    }

    public void HideButton()
    {
        hideArea.SetActive(!hideArea.activeSelf);
        backgroundFade.SetActive(!backgroundFade.activeSelf);
    }
}
