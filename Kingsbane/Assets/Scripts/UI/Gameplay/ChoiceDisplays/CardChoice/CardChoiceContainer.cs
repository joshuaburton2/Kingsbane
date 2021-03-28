using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardChoiceContainer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject cardParent;

    private CardChoiceUI cardChoiceUI;
    private CardDisplay cardDisplay;

    private const float defaultCardScaling = 0.3f;

    public void InitCardContainer(CardChoiceUI _cardChoiceUI, Card card)
    {
        cardChoiceUI = _cardChoiceUI;

        var newCardObject = GameManager.instance.libraryManager.CreateCardObject(card, cardParent.transform, defaultCardScaling);
        newCardObject.name = card.Name;
        gameObject.name = $"Container- {card.Name}";

        newCardObject.transform.SetSiblingIndex(0);
        cardDisplay = newCardObject.GetComponent<CardDisplay>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            cardDisplay.DisplayCardDetail();
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            cardChoiceUI.ChooseCard(cardDisplay.card);
        }
    }
}
