using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandUI : MonoBehaviour
{
    [Header("Hand Objects")]
    [SerializeField]
    private GameObject handList;
    [SerializeField]
    private GameObject handContainerPrefab;
    [SerializeField]
    private float scalingFactor;
    [SerializeField]
    private bool cardMoveUpward; //True is the cards in hand move upward when clicked. False for downward
    [SerializeField]
    private GameObject scrollAreaMask;
    [SerializeField]
    private GridLayoutGroup handGridLayout;
    [Header("Hand Count Objects")]
    [SerializeField]
    private TextMeshProUGUI handCountText;
    [SerializeField]
    private CanvasGroup handCountArea;
    [SerializeField]
    private float handCountHideAlpha;

    private List<HandContainer> containerList;

    private GameplayUI gameplayUI;

    private bool handMinimised;

    private void Update()
    {
        if (GameManager.instance.effectManager.IsUILocked && !handMinimised)
            MinimiseAllCards();

        if (Input.GetMouseButtonDown(1))
        {
            if (GameManager.instance.uiManager.OverGameplayArea)
            {
                MinimiseAllCards();
            }
        }
    }

    /// <summary>
    /// 
    /// Displays the hand list. Can input either a Card or UpgradeData list
    /// 
    /// </summary>
    public void DisplayHandList<T>(GameplayUI _gameplayUI, List<T> handList, bool showHand, int playerIndex) where T : class
    {
        gameplayUI = _gameplayUI;

        handMinimised = true;

        containerList = new List<HandContainer>();
        GameManager.DestroyAllChildren(this.handList);

        int index = 0;
        foreach (var handObject in handList)
        {
            //Creates the hand object and script
            var handContainerObject = Instantiate(handContainerPrefab, this.handList.transform);
            var handContainer = handContainerObject.GetComponentInChildren<HandContainer>();
            containerList.Add(handContainer);

            var type = typeof(T);
            string objectName;
            //Determines the type of list input (card or upgradeData)
            switch (type)
            {
                case Type _ when type == typeof(Card):
                    var card = (Card)(object)handObject;

                    objectName = card.Name;
                    break;
                case Type _ when type == typeof(UpgradeData):
                    var upgrade = (UpgradeData)(object)handObject;

                    objectName = upgrade.Name;
                    break;
                default:
                    throw new Exception("Not a valid list type");
            }

            //Sets the properties of the object
            handContainerObject.name = $"Container- {objectName}";
            handContainer.InitHandContainer(this, _gameplayUI, index, playerIndex, handObject, showHand, objectName, scalingFactor, cardMoveUpward);

            index++;
        }

        //Sets the hand count text
        handCountText.text = $"Cards in Hand: {handList.Count}";
        UpdateHandObjects(false);
    }

    /// <summary>
    /// 
    /// Minimises all the cards to their base position
    /// 
    /// </summary>
    public void MinimiseAllCards()
    {
        foreach (var container in containerList)
            container.MinimiseDisplay();

        UpdateHandObjects(false);

        handMinimised = true;
    }

    /// <summary>
    /// 
    /// Minimises all the non selected cards
    /// 
    /// </summary>
    public void MinimiseNonSelectedCards(int selectedIndex)
    {
        foreach (var container in containerList)
            if (selectedIndex != container.HandIndex)
                container.MinimiseDisplay();

        gameplayUI.CancelEffects();

        handMinimised = false;
    }

    /// <summary>
    /// 
    /// Updates the hand when a card is selected
    /// 
    /// </summary>
    public void UpdateHandObjects(bool cardSelected)
    {
        handCountArea.alpha = cardSelected ? handCountHideAlpha : 1.0f;

        //Shifts the hand area mask to prevent it blocking the map. Might be a better way of doing this but leave be for now
        //Odd how the padding is not required to be changed for the top player bar, but wasn't able to determine why
        if (cardMoveUpward)
        {
            scrollAreaMask.GetComponent<RectTransform>().SetTop(cardSelected ? -150 : 0);
            handGridLayout.padding.top = cardSelected ? 155 : 5;
        }
        else
        {
            scrollAreaMask.GetComponent<RectTransform>().SetBottom(cardSelected ? -150 : 0);
        }
    }
}
