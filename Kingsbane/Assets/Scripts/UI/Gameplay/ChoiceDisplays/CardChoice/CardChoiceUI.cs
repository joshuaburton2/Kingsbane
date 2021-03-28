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
    [SerializeField]
    private GameObject backgroundFade;

    public void DisplayCardChoice(List<Card> cardList)
    {
        GameManager.DestroyAllChildren(choiceParent);
        backgroundFade.SetActive(true);

        foreach (var card in cardList)
        {
            var choiceContainerObject = Instantiate(choiceContainerPrefab, choiceParent.transform);
            var choiceContainer = choiceContainerObject.GetComponentInChildren<CardChoiceContainer>();
            choiceContainer.InitCardContainer(this, card);
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
        backgroundFade.SetActive(!backgroundFade.activeSelf);
    }
}
