using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCardListUI : MonoBehaviour
{
    public DeckData deckData;

    [SerializeField]
    GameObject cardListArea;
    [SerializeField]
    List<GameObject> cardObjects;
    [SerializeField]
    GameObject cardTemplate;

    public void RefreshCardList(DeckData _deckData = null)
    {
        foreach (var item in cardObjects)
        {
            Destroy(item);
        }
        cardObjects.Clear();
        
        if (_deckData != null)
        {
            this.deckData = _deckData;

            foreach (var card in this.deckData.CardList)
            {
                var deckCardObject = Instantiate(cardTemplate, cardListArea.transform);
                deckCardObject.GetComponent<DeckCardObject>().InitCardObject(card);
                deckCardObject.name = $"Card- {card.Name}";
                cardObjects.Add(deckCardObject);
            }
        }
    }
}
