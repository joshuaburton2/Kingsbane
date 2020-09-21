using Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckCardObject : MonoBehaviour, IPointerClickHandler
{
    CardData cardData;
    private DeckListUI deckListUI;
    private int? deckId;

    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI cardCountText;
    [SerializeField]
    TextMeshProUGUI typeText;
    [SerializeField]
    TextMeshProUGUI totalCostText;

    [SerializeField]
    Image rarityBorder;

    public void InitCardObject(CardData _cardData, DeckListUI _deckListUI, int numCards, int? _deckId = null)
    {
        cardData = _cardData;
        deckListUI = _deckListUI;
        deckId = _deckId;

        nameText.text = cardData.Name;
        typeText.text = cardData.CardType.ToString();
        cardCountText.text = cardData.IsHero ? "Hero" : $"x{numCards}";
        rarityBorder.color = GameManager.instance.colourManager.GetRarityColour(cardData.Rarity, cardData.Class);

        //var resourceCost = cardData.TotalResource;
        //if (resourceCost > 0)
        //{
        //    totalCostText.text = "";
        //}
        //else
        //{
        //    resourceCost = -resourceCost;

        //}

        totalCostText.text = StringHelpers.GenerateResourceText(cardData.GetResources);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.instance.uiManager.ActivateCardDetail(cardData);
        }

        if (eventData.button == PointerEventData.InputButton.Left && deckListUI.DeckEditMode)
        {
            var updatedDeck = GameManager.instance.deckManager.RemoveFromPlayerDeck(deckId.Value, cardData);
            deckListUI.activeDeckCardList.RefreshCardList(updatedDeck, deckListUI, deckId.Value);
        }
    }
}
