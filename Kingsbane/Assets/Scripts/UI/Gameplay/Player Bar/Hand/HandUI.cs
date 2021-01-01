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

    public void DisplayHandList<T>(List<T> handList, bool showHand)
    {
        containerList = new List<HandContainer>();
        GameManager.DestroyAllChildren(this.handList);

        int index = 0;
        foreach (var handObject in handList)
        {
            var upgradeContainer = Instantiate(handContainerPrefab, this.handList.transform);

            var handContainer = upgradeContainer.GetComponentInChildren<HandContainer>();
            containerList.Add(handContainer);

            var type = typeof(T);
            string objectName;
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
                    objectName = "";
                    break;
            }
            upgradeContainer.name = $"Container- {objectName}";
            var displayName = $"Name- {objectName}";
            handContainer.InitHandContainer(this, index, handObject, showHand, objectName, scalingFactor, cardMoveUpward);

            index++;
        }

        handCountText.text = $"Cards in Hand: {handList.Count}";
    }

    public void SelectDisplay(int selectedIndex)
    {
        foreach (var container in containerList)
        {
            if (selectedIndex != container.HandIndex)
            {
                container.SelectDisplay(false, false);
            }
        }
    }

    public void HideHandArea(bool toHide)
    {
        handCountArea.alpha = toHide ? handCountHideAlpha : 1.0f;
    }

    public void ShowHand(bool toShow)
    {
        foreach (var cardContainer in containerList)
        {
            cardContainer.ShowCard(!toShow);
        }
    }
}
