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

    public void RefreshDeckList()
    {
        RefreshDeckList(isNPCList, titleText.text);
    }

    public void RefreshDeckList(bool _isNPCList, string newTitle)
    {
        isNPCList = _isNPCList;
        titleText.text = newTitle;
        SelectedDeckId = null;

        //Unlocks the deck scrolling
        listScrollArea.vertical = true;

        List<DeckData> deckList;

        if (isNPCList)
        {
            deckList = GameManager.instance.deckManager.GetNPCDecks();
        }
        else
        {
            deckList = GameManager.instance.deckManager.PlayerDeckList;
        }

        //Clears the deck list of objects
        GameManager.DestroyAllChildren(deckListParent);
        deckListObjects.Clear();

        foreach (var deck in deckList)
        {
            var deckListObject = Instantiate(deckListObjectPrefab, deckListParent.transform);
            deckListObject.name = $"Deck: {deck.Name}";
            deckListObject.GetComponent<DeckListObject>().InitDeckListObject(deck, _lobbyDeckListUI: this);
            deckListObjects.Add(deckListObject);
        }
    }

    public void SelectDeck(int deckId, DeckData deckData)
    {
        //Sets the properties of the deck currently being edited
        SelectedDeckId = deckId;

        //Locks the deck scrolling
        listScrollArea.vertical = false;

        //Hides all deck objects in the deck list except the one being edited
        for (int deckIndex = 0; deckIndex < deckListObjects.Count; deckIndex++)
        {
            if (deckIndex != deckId)
            {
                deckListObjects[deckIndex].SetActive(false);
            }
        }

        //Return the selected deck to the lobby UI
        lobbyUI.SelectDeck(playerId, deckData);
    }
}
