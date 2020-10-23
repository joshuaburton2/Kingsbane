using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyDeckListUI : MonoBehaviour
{
    bool isNPCList;

    [SerializeField]
    private GameObject deckListParent;
    [SerializeField]
    private GameObject deckListObjectPrefab;
    [SerializeField]
    private List<GameObject> deckListObjects;
    [SerializeField]
    private Button editDeckButton;
    [SerializeField]
    private TextMeshProUGUI titleText;

    public void RefreshDeckList(bool _isNPCList, string newTitle)
    {
        isNPCList = _isNPCList;
        titleText.text = newTitle;

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
}
