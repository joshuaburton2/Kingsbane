using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlterFateContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject handCardParent;
    [SerializeField]
    private GameObject deckCardParent;

    private AlterFateUI alterFateUI;
    private Card handCard;
    private Card deckCard;

    private const float defaultCardScaling = 0.24f;

    public void InitCardContainer(AlterFateUI _alterFateUI, Card _handCard, Card _deckCard)
    {
        alterFateUI = _alterFateUI;
        handCard = _handCard;
        deckCard = _deckCard;

        InitCardObject(handCard, handCardParent);
        InitCardObject(deckCard, deckCardParent);
    }

    public void InitCardObject(Card card, GameObject cardParent)
    {
        GameManager.DestroyAllChildren(cardParent);
        var cardObject = GameManager.instance.libraryManager.CreateCardObject(card, cardParent.transform, defaultCardScaling);
        cardObject.name = card.Name;
    }

    public void SwapButton()
    {
        alterFateUI.SwapCard(handCard, deckCard);
    }
}
