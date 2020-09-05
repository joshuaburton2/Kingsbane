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
    private List<GameObject> deckListObjects;

    public void CreateNewDeck()
    {
        newDeckPage.SetActive(true);
        newDeckPage.GetComponent<NewDeckUI>().InitNewDeckPage();
    }
}
