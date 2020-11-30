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

    private CardDisplay cardDisplay;
    private UpgradeDisplay upgradeDisplay;

    private const float defaultScalingFactor = 0.20f;

    /// <summary>
    /// 
    /// Initialise the container object for a card
    /// 
    /// </summary>
    public void InitHandContainer(
        CardData cardData = null,
        UpgradeData upgradeData = null,
        string containerName = "",
        float scalingFactor = defaultScalingFactor)
    {
        transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(cardSizex * scalingFactor, cardSizey * scalingFactor);
        //Object is instantiated on the parent of this object in order to prevent conflicts with click handling
        if (cardData == null)
        {
            var newUpgradeObj = GameManager.instance.upgradeManager.CreateUpgrade(upgradeData, gameObject.transform.parent, scaling: scalingFactor);
            newUpgradeObj.name = containerName;
            cardDisplay = newUpgradeObj.GetComponent<CardDisplay>();
        }
        else if(upgradeData == null)
        {
            var newCardObj = GameManager.instance.libraryManager.CreateCardObject(cardData, gameObject.transform.parent, scalingFactor);
            newCardObj.name = containerName;
            cardDisplay = newCardObj.GetComponent<CardDisplay>();
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
    }
}
