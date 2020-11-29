using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandContainer : MonoBehaviour
{
    [SerializeField]
    float cardSizex;
    [SerializeField]
    float cardSizey;

    private CardDisplay cardDisplay;

    private const float defaultScalingFactor = 0.37f;

    /// <summary>
    /// 
    /// Initialise the container object
    /// 
    /// </summary>
    public void InitCardContainer(
        CardData cardData,
        string cardName = "",
        float scalingFactor = defaultScalingFactor)
    {
        transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(cardSizex * scalingFactor, cardSizey * scalingFactor);
        //Object is instantiated on the parent of this object in order to prevent conflicts with click handling
        var newCardObj = GameManager.instance.libraryManager.CreateCardObject(cardData, gameObject.transform.parent, scalingFactor);
        newCardObj.name = cardName;
        //Sibling Index is set to 1 so that the click handler on card display doesn't interfere with the click handler on the container (which is only used when adding cards to a deck)
        newCardObj.transform.SetSiblingIndex(1);
        cardDisplay = newCardObj.GetComponent<CardDisplay>();
    }
}
