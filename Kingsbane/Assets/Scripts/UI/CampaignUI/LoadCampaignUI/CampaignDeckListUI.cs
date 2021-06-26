using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CampaignDeckListUI : MonoBehaviour
{
    [SerializeField]
    private LoadCampaignUI loadCampaignUI;
    [SerializeField]
    private GameObject deckListParent;
    [SerializeField]
    private GameObject deckListObjectPrefab;
    [SerializeField]
    private ScrollRect listScrollArea;
    [SerializeField]
    private List<GameObject> deckListObjects;

    /// <summary>
    /// 
    /// Refreshes the deck list
    /// 
    /// </summary>
    public void RefreshDeckList()
    {
        //Unlocks the deck scrolling
        listScrollArea.vertical = true;

        var deckList = GameManager.instance.deckManager.GetPlayerDecks(true);

        //Clears the deck list of objects
        GameManager.DestroyAllChildren(deckListParent);
        deckListObjects.Clear();

        //Creates each deck list object for each deck in the deck list
        foreach (var deck in deckList)
        {
            var deckListObject = Instantiate(deckListObjectPrefab, deckListParent.transform);
            deckListObject.name = $"Deck: {deck.Name}";
            deckListObject.GetComponent<DeckListObject>().InitDeckListObject(deck, _campaignDeckListUI: this);
            deckListObjects.Add(deckListObject);
        }

        SelectDeck();
    }

    /// <summary>
    /// 
    /// Function call for selecing a deck for the player to play
    /// 
    /// </summary>
    public void SelectDeck(DeckData deckData = null)
    {
        loadCampaignUI.SelectDeck(deckData);

        foreach (var deckObject in deckListObjects)
        {
            var deckObjectScript = deckObject.GetComponent<DeckListObject>();
            if (deckData != null)
            {
                if (deckObjectScript.deckData.Id == deckData.Id)
                {
                    deckObjectScript.selectionIcon.SetActive(true);
                }
                else
                {
                    deckObjectScript.selectionIcon.SetActive(false);
                }
            }
            else
            {
                deckObjectScript.selectionIcon.SetActive(false);
            }
        }
    }
}
