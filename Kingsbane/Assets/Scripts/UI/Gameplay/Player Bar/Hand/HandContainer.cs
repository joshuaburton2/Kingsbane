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
        
        //Direction Mod is used to determine which way to move the card when it is clicked- varies depending on if the bar is at the top or bottom of the screen
        var directionMod = CardMoveUpward ? 1 : -1;
        buttonArea.transform.localPosition *= directionMod;
        buttonArea.SetActive(false);

        //transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(cardSizex * scalingFactor, cardSizey * scalingFactor);

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

    /// <summary>
    /// 
    /// Selects the card in hand
    /// 
    /// </summary>
    public void SelectDisplay()
    {
        //Sets the card being selected to the opposite of its current state
        isSelected = !isSelected;

        //Moves the card in or out depending on its state
        MoveCard(isSelected);

        //Only shows the buttons if there is a card display object (not an upgrade display)
        if (CardDisplay != null)
            if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
                buttonArea.SetActive(isSelected);

        //If the card is being selected, updates all other cards in hand to minimise
        if (isSelected)
            HandUI.MinimiseNonSelectedCards(HandIndex);

        //Hides the hand count area based on whether the card is selected or not
        HandUI.HideHandCountArea(isSelected);
    }

    /// <summary>
    /// 
    /// Minimises the card. To be called on the other cards in the hand if they are not the one being selected
    /// 
    /// </summary>
    public void MinimiseDisplay()
    {
        //Only needs to be update if it is being selected
        if (isSelected)
        {
            isSelected = false;
            MoveCard(false);
        }
    }

    /// <summary>
    /// 
    /// Moves the card in or out depending on if it is being selected or not
    /// 
    /// </summary>
    /// <param name="toMoveOut">True if the card is being selected. False if the card is being deselected</param>
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

        //Left click selects the card in hand
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SelectDisplay();
        }
    }

    /// <summary>
    /// 
    /// Shows or hides the card with the card back
    /// 
    /// </summary>
    public void ShowCard(bool toShow)
    {
        //Minimises the card if it is already selected
        if (isSelected)
            MinimiseDisplay();

        //Shows or hides the card back
        cardBack.SetActive(!toShow);
    }
}
