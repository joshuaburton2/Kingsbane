using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroUI : MonoBehaviour
{
    public Hero Hero { get; private set; }
    public Player Player { get { return Hero.Owner; } }

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

    [Header("Player Stat Tracker Area Fields")]
    [SerializeField]
    private TextMeshProUGUI empoweredText;
    [SerializeField]
    private TextMeshProUGUI summonText;

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

    public void OverrideHero(Unit overrideUnit)
    {
        heroStatUI.InitHeroStats(overrideUnit);

        heroStatUI.RefreshHeroStats();
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

        empoweredText.text = Player.CurrentEmpowered >= 0 ? $"Empowered: +{Player.CurrentEmpowered}" : $"Empowered: {Player.CurrentEmpowered}";
        summonText.text = $"Summon: {Player.CurrentSummons}/{Player.SummonCapcity}";
    }

    /// <summary>
    /// 
    /// Button click event for increasing the player's empowered
    /// 
    /// </summary>
    public void IncreaseEmpowered()
    {
        Player.ModifyEmpowered(1);
        RefreshHeroUI();
    }

    /// <summary>
    /// 
    /// Button click event for decreasing the player's empowered
    /// 
    /// </summary>
    public void DecreaseEmpowered()
    {
        Player.ModifyEmpowered(-1);
        RefreshHeroUI();
    }

    /// <summary>
    /// 
    /// Button click event for increasing the player's summon capacity
    /// 
    /// </summary>
    public void IncreaseSummonCapacity()
    {
        Player.ModifySummonCapacity();
        RefreshHeroUI();
    }

    /// <summary>
    /// 
    /// Button click event for increasing the player's item capacity
    /// 
    /// </summary>
    public void IncreaseItemCapacity()
    {
        Player.ModifyItemCapacity();
        RefreshHeroUI();
    }
}
