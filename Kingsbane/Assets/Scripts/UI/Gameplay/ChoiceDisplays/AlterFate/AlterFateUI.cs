using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private Button switchPageButton;

    private List<Card> HandCards { get; set; }
    private List<Card> DeckCards { get; set; }
    private List<bool> IsSwapped { get; set; }
    private int CardCount { get; set; }
    private int NumPages { get; set; }
    private List<int> NumPerPage { get; set; }

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
            CardCount = handCards.Count;

        HandCards = handCards;
        DeckCards = deckCards;

        IsSwapped = new List<bool>();
        for (int cardIndex = 0; cardIndex < CardCount; cardIndex++)
            IsSwapped.Add(false);

        CurrentPage = 0;

        RefreshCards();
    }

    public void RefreshCards()
    {
        SplitHandCards = new List<List<Card>>();
        SplitDeckCards = new List<List<Card>>();

        NumPages = CardCount / MAX_NUM_PER_PAGE;
        NumPages = CardCount % MAX_NUM_PER_PAGE > 0 ? NumPages + 1 : NumPages;
        switchPageButton.interactable = NumPages > 1;
        var baseNumPerPage = CardCount / NumPages;
        var excessCards = CardCount - baseNumPerPage * NumPages;

        var currentIndex = 0;
        for (int pageIndex = 0; pageIndex < NumPages; pageIndex++)
        {
            var handPageCard = new List<Card>();
            var deckPageCard = new List<Card>();
            for (int cardIndex = 0; cardIndex < baseNumPerPage; cardIndex++)
            {
                handPageCard.Add(HandCards[currentIndex]);
                deckPageCard.Add(DeckCards[currentIndex]);
                currentIndex++;
            }

            if (pageIndex < excessCards)
            {
                handPageCard.Add(HandCards[currentIndex]);
                deckPageCard.Add(DeckCards[currentIndex]);
                currentIndex++;
            }

            SplitHandCards.Add(handPageCard);
            SplitDeckCards.Add(deckPageCard);
        }

        RefreshCurrentPage();
    }

    public void SwitchPages()
    {
        CurrentPage = CurrentPage == 0 ? 1 : 0;

        RefreshCurrentPage();
    }

    public void RefreshCurrentPage()
    {
        GameManager.DestroyAllChildren(alterFateParent);

        for (int cardIndex = 0; cardIndex < SplitHandCards[CurrentPage].Count; cardIndex++)
        {
            var alterFateContainerObject = Instantiate(alterFateContainerPrefab, alterFateParent.transform);
            var alterFateContainer = alterFateContainerObject.GetComponentInChildren<AlterFateContainer>();
            alterFateContainer.InitCardContainer(this, SplitHandCards[CurrentPage][cardIndex], SplitDeckCards[CurrentPage][cardIndex]);
        }
    }

    public void SwapCard(Card handCard, Card deckCard)
    {
        var handIndex = HandCards.IndexOf(handCard);
        HandCards.Remove(handCard);
        HandCards.Insert(handIndex, deckCard);

        var deckIndex = DeckCards.IndexOf(deckCard);
        DeckCards.Remove(deckCard);
        DeckCards.Insert(deckIndex, handCard);

        IsSwapped[handIndex] = !IsSwapped[handIndex];

        RefreshCards();
    }

    public void ConfirmButton()
    {
        GameManager.instance.effectManager.AlterFate(HandCards, DeckCards, IsSwapped);
        gameObject.SetActive(false);
    }

    public void HideButton()
    {
        hideArea.SetActive(!hideArea.activeSelf);
        backgroundFade.SetActive(!backgroundFade.activeSelf);
    }
}
