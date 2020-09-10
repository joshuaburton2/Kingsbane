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

    private void Start()
    {
        newDeckPage.SetActive(false);
    }

    public void CreateNewDeck()
    {
        newDeckPage.SetActive(true);
        newDeckPage.GetComponent<NewDeckUI>().InitNewDeckPage();
    }
}
