using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckListUI : MonoBehaviour
{
    [SerializeField]
    private LibraryUI libraryUI;
    [SerializeField]
    private GameObject newDeckPage;
    [SerializeField]
    private GameObject deckListParent;
    [SerializeField]
    private GameObject deckListObjectPrefab;
    [SerializeField]
    private List<GameObject> deckListObjects;

    public int? DeckEditId { get; set; }
    public bool DeckEditMode { get { return DeckEditId.HasValue; } }
    public DeckCardListUI activeDeckCardList;

    private void Start()
    {
        newDeckPage.SetActive(false);
        RefreshDeckList();
    }

    public void CreateNewDeck()
    {
        DeckEditId = null;
        newDeckPage.SetActive(true);
        newDeckPage.GetComponent<NewDeckUI>().InitNewDeckPage();
    }

    public void ResetDecks()
    {
        GameManager.instance.deckManager.ResetDecks();
        DeckEditId = null;
        RefreshDeckList(true);
    }

    public void RefreshDeckList(bool resourceFilter = false)
    {
        DeckEditId = null;
        if (resourceFilter)
        {
            libraryUI.ApplyClassPlayableFilter(Classes.ClassList.Default);
        }

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

    public void EditDeck(int deckId, DeckCardListUI deckCardListUI)
    {
        DeckEditId = deckId;
        activeDeckCardList = deckCardListUI;

        var selectedDeck = deckListObjects[deckId].GetComponent<DeckListObject>().deckData;
        libraryUI.ApplyClassPlayableFilter(selectedDeck.DeckClass);

        for (int deckIndex = 0; deckIndex < deckListObjects.Count; deckIndex++)
        {
            if (deckIndex != deckId)
            {
                deckListObjects[deckIndex].SetActive(false);
            }
        }
    }
}
