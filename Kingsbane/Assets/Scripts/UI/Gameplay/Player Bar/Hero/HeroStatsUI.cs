using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class HeroStatsUI : MonoBehaviour, IPointerClickHandler
{
    private Hero hero;

    [SerializeField]
    private Image heroImage;
    [SerializeField]
    private GameObject nameArea;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI attackText;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private TextMeshProUGUI rangeText;
    [SerializeField]
    private TextMeshProUGUI speedText;

    /// <summary>
    /// 
    /// Initialises the hero stat area
    /// 
    /// </summary>
    public void InitHeroStats(Hero _hero)
    {
        hero = _hero;

        if (GameManager.instance.imageManager.IsDefaultImage(hero.CardArt))
        {
            nameArea.SetActive(true);
            nameText.text = hero.Name;
            heroImage.sprite = null;
        }
        else
        {
            nameArea.SetActive(false);
            heroImage.sprite = hero.CardArt;
        }
    }

    /// <summary>
    /// 
    /// Refreshes the hero stats
    /// 
    /// </summary>
    public void RefreshHeroStats()
    {
        attackText.text = hero.Attack.ToString();
        var attackStatType = hero.HasBuffedAttack ? Unit.UnitStatTypes.Buffed : Unit.UnitStatTypes.None;
        attackText.color = GameManager.instance.colourManager.GetUnitStatColour(attackStatType);

        healthText.text = hero.Health.ToString();
        var healthStatType = hero.UnitIsDamaged ? Unit.UnitStatTypes.Damaged : Unit.UnitStatTypes.None;
        attackText.color = GameManager.instance.colourManager.GetUnitStatColour(healthStatType);

        rangeText.text = hero.Range.ToString();
        var rangeStatType = hero.HasBuffedAttack ? Unit.UnitStatTypes.Buffed : Unit.UnitStatTypes.None;
        attackText.color = GameManager.instance.colourManager.GetUnitStatColour(rangeStatType);

        speedText.text = hero.Speed.ToString();
        var speedStatType = hero.HasBuffedAttack ? Unit.UnitStatTypes.Buffed : Unit.UnitStatTypes.None;
        attackText.color = GameManager.instance.colourManager.GetUnitStatColour(speedStatType);
    }

    /// <summary>
    /// 
    /// Click event for displaying the card detail display
    /// 
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameManager.instance.uiManager.ActivateCardDetail(hero.cardData);
        }
    }
}
