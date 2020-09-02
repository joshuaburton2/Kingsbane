using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject cardDetailDisplay;

    public void ActivateCardDetail(CardData cardData)
    {
        cardDetailDisplay.SetActive(true);
        cardDetailDisplay.GetComponent<CardDetailUI>().ShowCardDetails(cardData);
    }
}
