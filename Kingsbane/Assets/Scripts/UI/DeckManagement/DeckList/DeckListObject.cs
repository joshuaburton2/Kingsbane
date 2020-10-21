﻿using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// 
/// Object for handling a deck UI object in a deck list
/// 
/// </summary>
public class DeckListObject : MonoBehaviour, IPointerClickHandler
{
    private int deckId;
    private DeckListUI deckListUI;

    public DeckData deckData;

    [Header("Main Properties")]
    [SerializeField]
    Image classBorder;
    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI classText;
    [SerializeField]
    GameObject deckDetailsArea;

    [Header("Card List Properties")]
    [SerializeField]
    DeckCardListUI deckCardList;

    [Header("Resource Properties")]
    [SerializeField]
    GameObject deckResourcesParent;
    [SerializeField]
    GameObject deckResourcePrefab;
    List<DeckResourceDetailUI> deckResourceObjects;

    /// <summary>
    /// 
    /// Initialise the deck object. Updates the text properties of the object
    /// 
    /// </summary>
    public void InitDeckListObject(DeckData _deckData, DeckListUI _deckListUI)
    {
        //Need to pass in the deck list UI to handle certain click interactions on this object
        deckListUI = _deckListUI;
        deckData = _deckData;

        deckId = deckData.Id.Value;
        nameText.text = deckData.Name;
        classBorder.color = GameManager.instance.colourManager.GetClassColour(deckData.DeckClass);
        classText.text = deckData.DeckClass.ToString();

        deckCardList.RefreshCardList(deckData, deckListUI);

        deckResourceObjects = new List<DeckResourceDetailUI>();
        foreach (var resource in deckData.PlayerResources)
        {
            var deckResourceObject = Instantiate(deckResourcePrefab, deckResourcesParent.transform);
            var deckResourceScript = deckResourceObject.GetComponent<DeckResourceDetailUI>();
            deckResourceScript.InitDeckResourceDetail(resource);
            deckResourceObjects.Add(deckResourceScript);
        }
        
        deckDetailsArea.SetActive(false);
    }

    /// <summary>
    /// 
    /// Refreshes the deck details of the object
    /// 
    /// </summary>
    public void RefreshDeckDetails(DeckData deckData, DeckListUI deckListUI)
    {
        deckCardList.RefreshCardList(deckData, deckListUI);
        foreach (var deckResourceObject in deckResourceObjects)  
        {
            deckResourceObject.RefreshResourceProperties();
        }
    }

    /// <summary>
    /// 
    /// Click handler for the object
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //If there is a deck currently being edited, refreshes the deck list (which will close the card list panel for this object)
            if (deckListUI.DeckEditMode)
            {
                deckListUI.RefreshDeckList();
            }
            //If not, sets the deck list UI into edit mode and opens the card list panel on this object
            else
            {
                deckListUI.EditDeck(deckId, deckData.DeckClass, this);
                deckDetailsArea.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// 
    /// Function for deleting the deck
    /// 
    /// </summary>
    public void DeleteDeck()
    {
        GameManager.instance.deckManager.DeletePlayerDeck(deckData);
        deckListUI.RefreshDeckList();
    }
}