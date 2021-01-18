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
    public void RefreshHeroStats(Hero _hero)
    {
        attackText.text = hero.Attack.ToString();
        healthText.text = hero.Health.ToString();
        rangeText.text = hero.Range.ToString();
        speedText.text = hero.Speed.ToString();
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
