using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class HeroStatsUI : MonoBehaviour, IPointerClickHandler
{
    private Unit hero;

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
    private GameObject protectedArea;
    [SerializeField]
    private TextMeshProUGUI protectedText;
    [SerializeField]
    private TextMeshProUGUI rangeText;
    [SerializeField]
    private TextMeshProUGUI speedText;

    /// <summary>
    /// 
    /// Initialises the hero stat area
    /// 
    /// </summary>
    public void InitHeroStats(Unit _hero)
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
        attackText.text = hero.GetStat(Unit.StatTypes.Attack).ToString();
        attackText.color = GameManager.instance.colourManager.GetStatModColour(hero.HasBuffedAttack);

        healthText.text = hero.CurrentHealth.ToString();
        healthText.color = GameManager.instance.colourManager.GetStatModColour(hero.HealthStatus);

        rangeText.text = hero.GetStat(Unit.StatTypes.Range).ToString();
        rangeText.color = GameManager.instance.colourManager.GetStatModColour(hero.HasBuffedRange);

        protectedText.text = hero.TotalProtected.HasValue ? hero.TotalProtected.ToString() : "Inf";
        protectedArea.SetActive(!hero.TotalProtected.HasValue || hero.TotalProtected.Value > 0);

        speedText.text = $"{hero.RemainingSpeed}/{hero.GetStat(Unit.StatTypes.Speed)}";
        speedText.color = GameManager.instance.colourManager.GetStatModColour(hero.HasBuffedSpeed);
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
            GameManager.instance.uiManager.ActivateCardDetail(hero.CardData);
        }
    }
}
