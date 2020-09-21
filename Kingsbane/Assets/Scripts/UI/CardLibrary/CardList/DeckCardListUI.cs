using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckCardListUI : MonoBehaviour, IPointerClickHandler
{
    private DeckListUI deckListUI;
    private int? deckId;
    private List<CardData> deckCardList;

    [SerializeField]
    GameObject cardListArea;
    [SerializeField]
    List<GameObject> cardObjects;
    [SerializeField]
    GameObject cardTemplate;
    [SerializeField]
    TextMeshProUGUI cardCountText;

    public void RefreshCardList(DeckData _deckData = null, DeckListUI _deckListUI = null, int? _deckId = null)
    {
        deckListUI = _deckListUI;

        foreach (var item in cardObjects)
        {
            Destroy(item);
        }
        cardObjects.Clear();
        
        if (_deckData != null)
        {
            deckCardList = _deckData.CardList;
            deckId = _deckId;

            for (int cardIndex = 0; cardIndex < deckCardList.Count; cardIndex++)
            {
                var deckCardObject = Instantiate(cardTemplate, cardListArea.transform);
                var cardData = deckCardList[cardIndex];

                var numCopies = 1;

                for (int forwardCardIndex = cardIndex + 1; forwardCardIndex < deckCardList.Count; forwardCardIndex++)
                {
                    var forwardCardData = deckCardList[forwardCardIndex];
                    if (cardData.Id == forwardCardData.Id)
                    {
                        numCopies++;
                    }
                    else
                    {
                        break;
                    }
                }

                deckCardObject.GetComponent<DeckCardObject>().InitCardObject(cardData, deckListUI, numCopies, deckId);
                deckCardObject.name = $"Card- {cardData.Name}";
                cardObjects.Add(deckCardObject);

                cardIndex += numCopies - 1;
            }

            cardCountText.text = $"Cards: {_deckData.DeckCount}";
        }
    }

    /// <summary>
    /// 
    /// Used here to prevent the card list being able to be clicked on and closing the edit mode
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
