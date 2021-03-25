using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardChoiceUI : MonoBehaviour
{
    [SerializeField]
    private GameObject choiceParent;
    [SerializeField]
    private GameObject choiceContainerPrefab;
    [SerializeField]
    private GameObject hideArea;

    public void DisplayCardChoice(List<Card> cardList)
    {
        GameManager.DestroyAllChildren(choiceParent);

        foreach (var card in cardList)
        {
            var choiceContainerObject = Instantiate(choiceContainerPrefab, choiceParent.transform);
            var handContainer = choiceContainerObject.GetComponentInChildren<CardChoiceContainer>();
            handContainer.InitCardContainer(this, card);
        }
    }

    public void ChooseCard(Card card)
    {
        GameManager.instance.effectManager.ChooseEffect(card);
        gameObject.SetActive(false);
    }

    public void HideButton()
    {
        hideArea.SetActive(!hideArea.activeSelf);
    }
}
