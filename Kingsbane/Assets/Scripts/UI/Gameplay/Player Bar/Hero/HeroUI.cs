using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroUI : MonoBehaviour
{
    private Hero Hero { get; set; }

    [SerializeField]
    private HeroStatsUI heroStatUI;
    [SerializeField]
    private Image heroStatBackground;
    [SerializeField]
    private TextMeshProUGUI equipCountText;
    [SerializeField]
    private GameObject itemListParent;
    [SerializeField]
    private GameObject itemListObject;

    public void InitHeroUI(Hero _hero)
    {
        Hero = _hero;

        heroStatUI.InitHeroStats(Hero);

        RefreshHeroUI();
    }

    public void RefreshHeroUI()
    {
        heroStatUI.RefreshHeroStats(Hero);
        heroStatBackground.color = GameManager.instance.colourManager.GetClassColour(Hero.CardClass);

        equipCountText.text = $"Equipped Items: {Hero.EquippedItems.Count} / {Hero.ItemCapacity}";

        GameManager.DestroyAllChildren(itemListParent);
        for (int i = 0; i < Hero.ItemCapacity; i++)
        {
            var itemObject = Instantiate(itemListObject, itemListParent.transform);

            if (i < Hero.EquippedItems.Count)
                itemObject.GetComponent<ItemListObject>().RefreshItemObject(this, Hero.EquippedItems[i]);
            else
                itemObject.GetComponent<ItemListObject>().RefreshItemObject(this);
        }
    }
}
