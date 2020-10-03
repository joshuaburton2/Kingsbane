using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Overall manager for the UI
/// 
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cardDetailDisplay;

    private void Start()
    {
        cardDetailDisplay.SetActive(false);
    }

    /// <summary>
    /// 
    /// Activates the card detail display
    /// 
    /// </summary>
    public void ActivateCardDetail(CardData cardData)
    {
        cardDetailDisplay.SetActive(true);
        cardDetailDisplay.GetComponent<CardDetailUI>().ShowCardDetails(cardData);
    }

    /// <summary>
    /// 
    /// General function for closing a panel
    /// 
    /// </summary>
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
