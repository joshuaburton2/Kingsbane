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

    /// <summary>
    /// 
    /// Initialises the Hero UI
    /// 
    /// </summary>
    public void InitHeroUI(Hero _hero)
    {
        Hero = _hero;

        heroStatUI.InitHeroStats(Hero);

        RefreshHeroUI();
    }

    /// <summary>
    /// 
    /// Refreshes the Hero UI
    /// 
    /// </summary>
    public void RefreshHeroUI()
    {
        heroStatUI.RefreshHeroStats();
        heroStatBackground.color = GameManager.instance.colourManager.GetClassColour(Hero.CardClass);

        equipCountText.text = $"Equipped Items: {Hero.EquippedItems.Count} / {Hero.ItemCapacity}";

        //Load in each item
        GameManager.DestroyAllChildren(itemListParent);
        for (int i = 0; i < Hero.ItemCapacity; i++)
        {
            var itemObject = Instantiate(itemListObject, itemListParent.transform);

            //If the index is less than the count, then it means there is an item slot to fill.
            //If greater than or equal to the count, then displays an empty item slot
            if (i < Hero.EquippedItems.Count)
                itemObject.GetComponent<ItemListObject>().RefreshItemObject(this, Hero.EquippedItems[i]);
            else
                itemObject.GetComponent<ItemListObject>().RefreshItemObject(this);
        }
    }
}
