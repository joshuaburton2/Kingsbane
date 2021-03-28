using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DivinateUI : MonoBehaviour
{
    [SerializeField]
    private GameObject topDeckParent;
    [SerializeField]
    private GameObject bottomDeckParent;
    [SerializeField]
    private GameObject divinateContainerPrefab;
    [SerializeField]
    private GameObject hideArea;
    [SerializeField]
    private GameObject backgroundFade;

    private List<Card> topCards;
    private List<Card> bottomCards;

    public void DisplayDivinate(List<Card> cards)
    {
        backgroundFade.SetActive(true);

        topCards = new List<Card>(cards);
        //Since the top cards are being pulled from the bottom of the deck and need to order left to right, reverses the list
        topCards.Reverse();
        bottomCards = new List<Card>();
        RefreshAllCards();
    }

    private void RefreshAllCards()
    {
        RefreshCardList(topCards, topDeckParent, true);
        RefreshCardList(bottomCards, bottomDeckParent, false);
    }

    private void RefreshCardList(List<Card> cards, GameObject cardParent, bool isTop)
    {
        GameManager.DestroyAllChildren(cardParent);
        foreach (var card in cards)
        {
            var choiceContainerObject = Instantiate(divinateContainerPrefab, cardParent.transform);
            var divinateContainer = choiceContainerObject.GetComponentInChildren<DivinateContainer>();
            var isEnd = (isTop && cards.FirstOrDefault() == card) || (!isTop && cards.LastOrDefault() == card);
            divinateContainer.InitCardContainer(this, card, isTop, isEnd);
        }
    }

    public void ShiftCard(Card card, bool moveRight)
    {
        if (moveRight)
        {
            if (topCards.LastOrDefault() == card)
            {
                topCards.Remove(card);
                bottomCards.Insert(0, card);
            }
            else
            {
                if (topCards.Contains(card))
                {
                    var currentIndex = topCards.IndexOf(card);
                    topCards.Remove(card);
                    topCards.Insert(currentIndex + 1, card);
                }
                if (bottomCards.Contains(card))
                {
                    var currentIndex = bottomCards.IndexOf(card);
                    bottomCards.Remove(card);
                    bottomCards.Insert(currentIndex + 1, card);
                }
            }
        }

        if (!moveRight)
        {
            if (bottomCards.FirstOrDefault() == card)
            {
                bottomCards.Remove(card);
                topCards.Add(card);
            }
            else
            {
                if (topCards.Contains(card))
                {
                    var currentIndex = topCards.IndexOf(card);
                    topCards.Remove(card);
                    topCards.Insert(currentIndex - 1, card);
                }
                if (bottomCards.Contains(card))
                {
                    var currentIndex = bottomCards.IndexOf(card);
                    bottomCards.Remove(card);
                    bottomCards.Insert(currentIndex - 1, card);
                }
            }
        }
        RefreshAllCards();
    }

    public void MoveCard(Card card, bool toBottom)
    {
        if (toBottom)
        {
            topCards.Remove(card);
            bottomCards.Add(card);
        }
        else
        {
            bottomCards.Remove(card);
            topCards.Insert(0, card);
        }
        RefreshAllCards();
    }

    public void ConfirmButton()
    {
        GameManager.instance.effectManager.Divinate(topCards, bottomCards);
        gameObject.SetActive(false);
    }

    public void HideButton()
    {
        hideArea.SetActive(!hideArea.activeSelf);
        backgroundFade.SetActive(!backgroundFade.activeSelf);
    }
}
