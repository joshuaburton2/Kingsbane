using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckCardObject : MonoBehaviour, IPointerClickHandler
{
    CardData cardData;

    [SerializeField]
    TextMeshProUGUI nameText;
    [SerializeField]
    TextMeshProUGUI typeText;
    [SerializeField]
    TextMeshProUGUI totalCostText;

    [SerializeField]
    Image rarityBorder;

    public void InitCardObject(CardData _cardData)
    {
        cardData = _cardData;

        nameText.text = cardData.Name;
        typeText.text = cardData.CardType.ToString();
        rarityBorder.color = GameManager.instance.colourManager.GetRarityColour(cardData.Rarity, cardData.Class);

        var totalCost = cardData.TotalResource;
        if (totalCost > 0)
        {
            totalCostText.text = "";
        }
        else
        {
            totalCost = -totalCost;
            totalCostText.text = totalCost.ToString();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.instance.uiManager.ActivateCardDetail(cardData);
        }
    }
}
