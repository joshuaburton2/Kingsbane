using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandContainer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    float cardSizex;
    [SerializeField]
    float cardSizey;
    [SerializeField]
    float ySelectionOffset;
    [SerializeField]
    private GameObject buttonArea;
    [SerializeField]
    private GameObject cardBack;

    private bool isSelected;

    private GameObject DisplayObject { get; set; }
    private CardDisplay CardDisplay { get; set; }
    private UpgradeDisplay UpgradeDisplay { get; set; }
    private bool CardMoveUpward { get; set; }

    private HandUI HandUI { get; set; }
    public int HandIndex { get; private set; }

    private const float defaultScalingFactor = 0.20f;



    /// <summary>
    /// 
    /// Initialise the container object for a card
    /// 
    /// </summary>
    public void InitHandContainer<T>(
        HandUI _handUI,
        int _handIndex,
        T objectData,
        bool showCard,
        string containerName = "",
        float scalingFactor = defaultScalingFactor,
        bool cardMoveUpward = true)
    {
        HandUI = _handUI;
        HandIndex = _handIndex;
        isSelected = false;
        CardMoveUpward = cardMoveUpward;

        var directionMod = CardMoveUpward ? 1 : -1;
        buttonArea.transform.localPosition *= directionMod;
        buttonArea.SetActive(false);

        transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(cardSizex * scalingFactor, cardSizey * scalingFactor);

        var type = typeof(T);
        switch (type)
        {
            case Type _ when type == typeof(Card):
                var cardData = (Card)(object)objectData;
                var newCardObj = GameManager.instance.libraryManager.CreateCardObject(cardData, gameObject.transform.parent, scalingFactor);
                newCardObj.name = containerName;

                //Sibling Index is set to 0 so that the click handler on card display doesn't interfere with the click handler on the container (which is only used when adding cards to a deck)
                newCardObj.transform.SetSiblingIndex(0);
                CardDisplay = newCardObj.GetComponent<CardDisplay>();
                DisplayObject = newCardObj;
                break;
            case Type _ when type == typeof(UpgradeData):
                var upgradeData = (UpgradeData)(object)objectData;
                var newUpgradeObj = GameManager.instance.upgradeManager.CreateUpgrade(upgradeData, gameObject.transform.parent, scaling: scalingFactor);
                newUpgradeObj.name = containerName;

                //Sibling Index is set to 0 so that the click handler on upgrade display doesn't interfere with the click handler on the container
                newUpgradeObj.transform.SetSiblingIndex(0);
                UpgradeDisplay = newUpgradeObj.GetComponent<UpgradeDisplay>();
                DisplayObject = newUpgradeObj;
                break;
        }

        ShowCard(showCard);
    }

    public void SelectDisplay(bool toSelect)
    {
        if (isSelected || toSelect)
        {
            isSelected = toSelect;
            MoveCard(toSelect);

            if (CardDisplay != null)
                if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
                    buttonArea.SetActive(toSelect);

            if (toSelect)
                HandUI.SelectDisplay(HandIndex);
        }
    }

    private void MoveCard(bool toMoveOut)
    {
        var directionMod = CardMoveUpward ? 1 : -1;
        var transformVector = new Vector3(0, (toMoveOut ? 1 : -1) * ySelectionOffset * directionMod);
        DisplayObject.transform.localPosition += transformVector;
    }

    /// <summary>
    /// 
    /// Function handler for click events
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        //Right clicking on a card always shows the detail display
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (CardDisplay == null)
            {
                UpgradeDisplay.DisplayUpgradeDetail();
            }
            else if (UpgradeDisplay == null)
            {
                CardDisplay.DisplayCardDetail();
            }
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SelectDisplay(!isSelected);
        }
    }

    public void ShowCard(bool toShow)
    {
        if (isSelected)
            MoveCard(false);

        cardBack.SetActive(!toShow);
    }
}
