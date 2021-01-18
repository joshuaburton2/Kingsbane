using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandContainer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    float cardSizex;
    [SerializeField]
    float cardSizey;
    [SerializeField]
    float ySelectionOffset;
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private CanvasGroup buttonGroup;
    [SerializeField]
    private GameObject cardParent;
    [SerializeField]
    private GameObject cardBack;
    [SerializeField]
    private GameObject cardMarker;

    private bool isSelected;
    private bool isHidden;

    private GameObject DisplayObject { get; set; }
    private CardDisplay CardDisplay { get; set; }
    private Card Card { get { return CardDisplay.card; } }
    private UpgradeDisplay UpgradeDisplay { get; set; }
    private bool CardMoveUpward { get; set; }

    private HandUI HandUI { get; set; }
    private GameplayUI GameplayUI { get; set; }
    public int HandIndex { get; private set; }
    public int PlayerIndex { get; private set; }

    private const float defaultScalingFactor = 0.20f;

    private void Update()
    {
        buttonGroup.interactable = !GameManager.instance.effectManager.IsUILocked;
    }

    /// <summary>
    /// 
    /// Initialise the container object for a card
    /// 
    /// </summary>
    public void InitHandContainer<T>(
        HandUI _handUI,
        GameplayUI gameplayUI,
        int _handIndex,
        int playerIndex,
        T objectData,
        bool showCard,
        string containerName = "",
        float scalingFactor = defaultScalingFactor,
        bool cardMoveUpward = true)
    {
        HandUI = _handUI;
        GameplayUI = gameplayUI;
        HandIndex = _handIndex;
        PlayerIndex = playerIndex;
        isSelected = false;
        CardMoveUpward = cardMoveUpward;

        //Direction Mod is used to determine which way to move the card when it is clicked- varies depending on if the bar is at the top or bottom of the screen
        var directionMod = CardMoveUpward ? 1 : -1;
        buttonGroup.gameObject.transform.localPosition *= directionMod;
        buttonGroup.gameObject.SetActive(false);

        //transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(cardSizex * scalingFactor, cardSizey * scalingFactor);

        var type = typeof(T);
        switch (type)
        {
            case Type _ when type == typeof(Card):
                var cardData = (Card)(object)objectData;
                var newCardObj = GameManager.instance.libraryManager.CreateCardObject(cardData, cardParent.transform, scalingFactor);
                newCardObj.name = containerName;

                //Sibling Index is set to 1 so that it is set in the correct order of the marker and the back
                newCardObj.transform.SetSiblingIndex(1);
                CardDisplay = newCardObj.GetComponent<CardDisplay>();
                DisplayObject = newCardObj;
                break;
            case Type _ when type == typeof(UpgradeData):
                var upgradeData = (UpgradeData)(object)objectData;
                var newUpgradeObj = GameManager.instance.upgradeManager.CreateUpgrade(upgradeData, cardParent.transform, scaling: scalingFactor);
                newUpgradeObj.name = containerName;

                //Sibling Index is set to 1 so that it is set in the correct order of the marker and the back
                newUpgradeObj.transform.SetSiblingIndex(1);
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
                buttonGroup.gameObject.SetActive(isSelected);

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
            buttonGroup.gameObject.SetActive(false);
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
        cardParent.transform.localPosition += transformVector;
        transform.localPosition += transformVector;
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

        //Left click selects the card in hand. Can't click cards if UI locked
        if (eventData.button == PointerEventData.InputButton.Left && !GameManager.instance.effectManager.IsUILocked && !isHidden)
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
        //Shows or hides the card marker if its playable. It also must not be hidden and it must be in the gameplay phase
        cardMarker.SetActive(
            toShow && 
            CardDisplay != null &&
            GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay && 
            Card.IsPlayable()
            );
        //Locks the play button in case the card isn't playable
        playButton.interactable = CardDisplay != null && Card.IsPlayable();

        isHidden = !toShow;
    }

    /// <summary>
    /// 
    /// Button click event for playing the card
    /// 
    /// </summary>
    public void PlayButton()
    {
        GameManager.instance.effectManager.PlayCard(Card);
        GameplayUI.ShowCardDisplay(Card);
    }

    /// <summary>
    /// 
    /// Button click event for discarding the card
    /// 
    /// </summary>
    public void DiscardButton()
    {
        Card.Discard();
        GameplayUI.RefreshPlayerBar(PlayerIndex);
    }
}
