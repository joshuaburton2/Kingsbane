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

    private bool isSelected;

    private GameObject displayObject;
    private CardDisplay cardDisplay;
    private UpgradeDisplay upgradeDisplay;

    private HandUI handUI;
    public int handIndex { get; private set; }

    private const float defaultScalingFactor = 0.20f;

    /// <summary>
    /// 
    /// Initialise the container object for a card
    /// 
    /// </summary>
    public void InitHandContainer <T>(
        HandUI _handUI,
        int _handIndex,
        T objectData,
        string containerName = "",
        float scalingFactor = defaultScalingFactor)
    {
        handUI = _handUI;
        handIndex = _handIndex;
        isSelected = false;

        buttonArea.SetActive(false);

        transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(cardSizex * scalingFactor, cardSizey * scalingFactor);

        var type = typeof(T);
        switch (type)
        {
            case Type _ when type == typeof(Card):
                var cardData = (CardData)(object)objectData;
                var newCardObj = GameManager.instance.libraryManager.CreateCardObject(cardData, gameObject.transform.parent, scalingFactor);
                newCardObj.name = containerName;

                //Sibling Index is set to 0 so that the click handler on card display doesn't interfere with the click handler on the container (which is only used when adding cards to a deck)
                newCardObj.transform.SetSiblingIndex(0);
                cardDisplay = newCardObj.GetComponent<CardDisplay>();
                displayObject = newCardObj;
                break;
            case Type _ when type == typeof(UpgradeData):
                var upgradeData = (UpgradeData)(object)objectData;
                var newUpgradeObj = GameManager.instance.upgradeManager.CreateUpgrade(upgradeData, gameObject.transform.parent, scaling: scalingFactor);
                newUpgradeObj.name = containerName;

                //Sibling Index is set to 0 so that the click handler on upgrade display doesn't interfere with the click handler on the container
                newUpgradeObj.transform.SetSiblingIndex(0);
                upgradeDisplay = newUpgradeObj.GetComponent<UpgradeDisplay>();
                displayObject = newUpgradeObj;
                break;
        }
    }

    public void SelectDisplay(bool toSelect)
    {
        if (isSelected || toSelect)
        {
            isSelected = toSelect;
            var transformVector = new Vector3(0, (toSelect ? 1 : -1) * ySelectionOffset);
            displayObject.transform.localPosition += transformVector;

            if (cardDisplay != null)
                buttonArea.SetActive(toSelect);

            if (toSelect)
                handUI.SelectDisplay(handIndex);
        }
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
            if (cardDisplay == null)
            {
                upgradeDisplay.DisplayUpgradeDetail();
            }
            else if (upgradeDisplay == null)
            {
                cardDisplay.DisplayCardDetail();
            }
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SelectDisplay(!isSelected);
        }
    }
}
