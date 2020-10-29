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
    [SerializeField]
    float mainCardScaling;

    /// <summary>
    /// 
    /// Initialise the Card Detail display
    /// 
    /// </summary>
    public void ShowCardDetails(CardData cardData)
    {
        //Reset all cards on the display
        GameManager.DestroyAllChildren(mainCardParent);
        GameManager.DestroyAllChildren(relatedCardList);

        //Creates the main card on the display
        GameObject mainCard = GameManager.instance.libraryManager.CreateCardObject(cardData, mainCardParent.transform, mainCardScaling);
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
                GameObject relatedCardParent = new GameObject($"Related Card- {relatedCard.Name}", typeof(RectTransform));
                relatedCardParent.transform.parent = relatedCardList.transform;
                //Unsure why this happens, but parent scales to a strange scaling. Following line resets this
                relatedCardParent.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                GameManager.instance.libraryManager.CreateCardObject(relatedCard, relatedCardParent.transform);
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
