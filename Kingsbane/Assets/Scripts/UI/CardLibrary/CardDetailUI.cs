using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void ShowCardDetails(CardData cardData)
    {
        DestroyAllChildren(mainCardParent.transform);
        DestroyAllChildren(relatedCardList.transform);

        GameObject mainCard = GameManager.instance.libraryManager.CreateCard(cardData, mainCardParent.transform);
        mainCard.name = $"Main Card- {cardData.Name}";

        UpdateDetailText(cardData.Tags, tagsText);
        UpdateDetailText(cardData.Synergies, synergiesText);

        if (cardData.RelatedCards != null)
        {
            relatedCardArea.SetActive(true);

            foreach (var relatedCard in cardData.RelatedCards.OrderBy(x => x.Name))
            {
                GameObject relatedCardParent = Instantiate(new GameObject($"Related Card- {relatedCard.Name}", typeof(RectTransform)), relatedCardList.transform);
                GameManager.instance.libraryManager.CreateCard(relatedCard, relatedCardParent.transform);
            }
            relatedCardScrollBar.value = 0;
        }
        else
        {
            relatedCardArea.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        GameManager.instance.uiManager.ClosePanel(gameObject);
    }

    private void DestroyAllChildren(Transform transform)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private static void UpdateDetailText<T>(List<T> listToConnect, TextMeshProUGUI textObject)
    {
        string connectedList = string.Join(", ", listToConnect);
        textObject.text = $"{typeof(T)}: {connectedList}";
        textObject.text = textObject.text.Replace("CategoryEnums.", "");
    }
}
