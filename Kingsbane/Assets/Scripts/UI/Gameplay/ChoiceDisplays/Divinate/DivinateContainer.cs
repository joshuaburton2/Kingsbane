using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DivinateContainer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject cardParent;
    [SerializeField]
    private Button leftButton;
    [SerializeField]
    private Button rightButton;
    [SerializeField]
    private Button toTopButton;
    [SerializeField]
    private Button toBottomButton;

    private DivinateUI divinateUI;
    private CardDisplay cardDisplay;

    private const float defaultCardScaling = 0.23f;

    public void InitCardContainer(DivinateUI _divinateUI, Card card, bool isTop, bool isEnd)
    {
        divinateUI = _divinateUI;

        var newCardObject = GameManager.instance.libraryManager.CreateCardObject(card, cardParent.transform, defaultCardScaling);
        newCardObject.name = card.Name;
        gameObject.name = $"Container- {card.Name}";

        newCardObject.transform.SetSiblingIndex(0);
        cardDisplay = newCardObject.GetComponent<CardDisplay>();

        if (isTop)
        {
            toTopButton.gameObject.SetActive(false);
            toBottomButton.gameObject.SetActive(true);
            if (isEnd)
                leftButton.gameObject.SetActive(false);
        }
        else
        {
            toTopButton.gameObject.SetActive(true);
            toBottomButton.gameObject.SetActive(false);
            if (isEnd)
                rightButton.gameObject.SetActive(false);
        }
    }

    public void ShiftLeft()
    {
        divinateUI.ShiftCard(cardDisplay.card, false);
    }

    public void ShiftRight()
    {
        divinateUI.ShiftCard(cardDisplay.card, true);
    }

    public void PlaceOnTop()
    {
        divinateUI.MoveCard(cardDisplay.card, false);
    }

    public void PlaceOnBottom()
    {
        divinateUI.MoveCard(cardDisplay.card, true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            cardDisplay.DisplayCardDetail();
        }
    }
}
