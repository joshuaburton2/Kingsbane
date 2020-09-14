using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cardDetailDisplay;

    private void Start()
    {
        cardDetailDisplay.SetActive(false);
    }

    public void ActivateCardDetail(CardData cardData)
    {
        cardDetailDisplay.SetActive(true);
        cardDetailDisplay.GetComponent<CardDetailUI>().ShowCardDetails(cardData);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
