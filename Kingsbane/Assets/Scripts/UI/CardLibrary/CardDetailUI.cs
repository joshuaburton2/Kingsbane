using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDetailUI : MonoBehaviour
{
    [SerializeField]
    GameObject mainCardParent;
    [SerializeField]
    GameObject relatedCardArea;
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
        mainCard.GetComponent<CardDisplay>().isClickable = false;

        UpdateDetailText(cardData.Tags, tagsText);
        UpdateDetailText(cardData.Synergies, synergiesText);

        if (cardData.RelatedCards != null)
        {
            relatedCardArea.SetActive(true);

            foreach (var relatedCard in cardData.RelatedCards)
            {
                GameObject relatedCardParent = Instantiate(new GameObject($"Related Card- {relatedCard.Name}", typeof(RectTransform)), relatedCardList.transform);
                GameManager.instance.libraryManager.CreateCard(relatedCard, relatedCardParent.transform);
            }
        }
        else
        {
            relatedCardArea.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
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
