using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckListUI : MonoBehaviour
{
    [SerializeField]
    private GameObject newDeckPage;
    [SerializeField]
    private GameObject deckListParent;
    [SerializeField]
    private GameObject deckListObjectPrefab;
    [SerializeField]
    private List<GameObject> deckListObjects;

    private void Start()
    {
        newDeckPage.SetActive(false);
        RefreshDeckList();
    }

    public void CreateNewDeck()
    {
        newDeckPage.SetActive(true);
        newDeckPage.GetComponent<NewDeckUI>().InitNewDeckPage();
    }

    public void ResetDecks()
    {
        GameManager.instance.deckManager.ResetDecks();
        GameManager.instance.uiManager.DeckEditId = null;
        RefreshDeckList();
    }

    public void RefreshDeckList()
    {
        GameManager.instance.uiManager.DeckEditId = null;

        foreach (Transform child in deckListParent.transform)
        {
            Destroy(child.gameObject);
        }
        deckListObjects.Clear();

        var deckList = GameManager.instance.deckManager.PlayerDeckList;
        foreach (var deck in deckList)
        {
            var deckListObject = Instantiate(deckListObjectPrefab, deckListParent.transform);
            deckListObject.name = $"Deck: {deck.Name}";
            deckListObject.GetComponent<DeckListObject>().InitDeckListObject(deck, this);
            deckListObjects.Add(deckListObject);
        }
    }

    public void EditDeck(int deckId)
    {
        GameManager.instance.uiManager.DeckEditId = deckId;
        var selectedDeck = deckListObjects[deckId];

        for (int deckIndex = 0; deckIndex < deckListObjects.Count; deckIndex++)
        {
            if (deckIndex != deckId)
            {
                deckListObjects[deckIndex].SetActive(false);
            }
        }
    }
}
