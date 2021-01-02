using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    [Header("Hand Count Objects")]
    [SerializeField]
    private TextMeshProUGUI handCountText;
    [SerializeField]
    private CanvasGroup handCountArea;
    [SerializeField]
    private float handCountHideAlpha;

    private List<HandContainer> containerList;

    /// <summary>
    /// 
    /// Displays the hand list. Can input either a Card or UpgradeData list
    /// 
    /// </summary>
    public void DisplayHandList<T>(List<T> handList, bool showHand) where T : class
    {
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
            handContainer.InitHandContainer(this, index, handObject, showHand, objectName, scalingFactor, cardMoveUpward);

            index++;
        }

        //Sets the hand count text
        handCountText.text = $"Cards in Hand: {handList.Count}";
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
    }

    /// <summary>
    /// 
    /// Hides the hand count area to prevent card blocking
    /// 
    /// </summary>
    public void HideHandCountArea(bool toHide)
    {
        handCountArea.alpha = toHide ? handCountHideAlpha : 1.0f;
    }
}
