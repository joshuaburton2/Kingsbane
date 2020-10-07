using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// Script for handling the display of the card details
/// 
/// </summary>
public class CardDetailUI : MonoBehaviour
{
    [SerializeField]
    GameObject mainCardParent;
    [SerializeField]
    GameObject relatedCardArea;
    [SerializeField]
    Scrollbar relatedCardScrollBar;
    [SerializeField]
    GameObject relatedCardList;
    [SerializeField]
    TextMeshProUGUI tagsText;
    [SerializeField]
    TextMeshProUGUI synergiesText;

    /// <summary>
    /// 
    /// Initialise the Card Detail display
    /// 
    /// </summary>
    public void ShowCardDetails(CardData cardData)
    {
        //Reset all cards on the display
        GameManager.DestroyAllChildren(mainCardParent.transform);
        GameManager.DestroyAllChildren(relatedCardList.transform);

        //Creates the main card on the display
        GameObject mainCard = GameManager.instance.libraryManager.CreateCard(cardData, mainCardParent.transform);
        mainCard.name = $"Main Card- {cardData.Name}";

        //Add the tags and synergies to the display
        UpdateDetailText(cardData.Tags, tagsText);
        UpdateDetailText(cardData.Synergies, synergiesText);

        //Checks if the card has any related cards
        if (cardData.RelatedCards != null)
        {
            relatedCardArea.SetActive(true);

            foreach (var relatedCard in cardData.RelatedCards.OrderBy(x => x.Name))
            {
                //Initialises a parent of the related card to handle scaling of the card display in the grid display object
                GameObject relatedCardParent = Instantiate(new GameObject($"Related Card- {relatedCard.Name}", typeof(RectTransform)), relatedCardList.transform);
                GameManager.instance.libraryManager.CreateCard(relatedCard, relatedCardParent.transform);
            }
            //Resets the scrolling of the related card area
            relatedCardScrollBar.value = 0;
        }
        else
        {
            relatedCardArea.SetActive(false);
        }
    }

    /// <summary>
    /// 
    /// Concatonates a list of tags or synergies into a list of strings
    /// 
    /// </summary>
    private static void UpdateDetailText<T>(List<T> listToConnect, TextMeshProUGUI textObject)
    {
        string connectedList = string.Join(", ", listToConnect);
        textObject.text = $"{typeof(T)}: {connectedList}";
        textObject.text = textObject.text.Replace("CategoryEnums.", "");
    }
}
