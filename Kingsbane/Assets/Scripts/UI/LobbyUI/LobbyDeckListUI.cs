using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyDeckListUI : MonoBehaviour
{
    bool isNPCList;

    [SerializeField]
    int playerId;
    [SerializeField]
    private LobbyUI lobbyUI;
    [SerializeField]
    private GameObject deckListParent;
    [SerializeField]
    private GameObject deckListObjectPrefab;
    [SerializeField]
    private ScrollRect listScrollArea;
    [SerializeField]
    private List<GameObject> deckListObjects;
    [SerializeField]
    private Button editDeckButton;
    [SerializeField]
    private TextMeshProUGUI titleText;

    public int? SelectedDeckId { get; set; }
    public bool DeckSelected { get { return SelectedDeckId.HasValue; } }
    private DeckListObject activeDeckObject;

    /// <summary>
    /// 
    /// Refreshes the deck list wihtout requiring inputs and using the inputs already initialised
    /// 
    /// </summary>
    public void RefreshDeckList()
    {
        RefreshDeckList(isNPCList, titleText.text);
    }

    /// <summary>
    /// 
    /// Refreshes the deck list with new input values
    /// 
    /// </summary>
    public void RefreshDeckList(bool _isNPCList, string newTitle)
    {
        isNPCList = _isNPCList;
        titleText.text = newTitle;
        SelectedDeckId = null;

        //Unlocks the deck scrolling
        listScrollArea.vertical = true;

        List<DeckData> deckList;

        //Retrives the required deck list
        if (isNPCList)
        {
            deckList = GameManager.instance.deckManager.NPCDeckList;
        }
        else
        {
            deckList = GameManager.instance.deckManager.PlayerDeckList;
        }

        //Clears the deck list of objects
        GameManager.DestroyAllChildren(deckListParent);
        deckListObjects.Clear();

        //Creates each deck list object for each deck in the deck list
        foreach (var deck in deckList)
        {
            var deckListObject = Instantiate(deckListObjectPrefab, deckListParent.transform);
            deckListObject.name = $"Deck: {deck.Name}";
            deckListObject.GetComponent<DeckListObject>().InitDeckListObject(deck, _lobbyDeckListUI: this);
            deckListObjects.Add(deckListObject);
        }

        //Removes the deck selected
        lobbyUI.SelectDeck(playerId, null);
    }

    /// <summary>
    /// 
    /// Function call for selecing a deck for the player to play
    /// 
    /// </summary>
    public bool SelectDeck(int deckId, DeckData deckData)
    {
        //Return the selected deck to the lobby UI
        if (lobbyUI.SelectDeck(playerId, deckData))
        {
            //Sets the properties of the deck currently being edited
            SelectedDeckId = deckId;

            //Locks the deck scrolling
            listScrollArea.vertical = false;

            //Hides all deck objects in the deck list except the one being edited
            for (int deckIndex = 0; deckIndex < deckListObjects.Count; deckIndex++)
            {
                if (deckListObjects[deckIndex].GetComponent<DeckListObject>().deckData.Id != deckId)
                {
                    deckListObjects[deckIndex].SetActive(false);
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}
