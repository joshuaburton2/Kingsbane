using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitCounter : MonoBehaviour
{
    public Unit Unit { get; set; }
    public Cell Cell { get; set; }

    [SerializeField]
    private Canvas canvas;

    [Header("Unit Identifiers")]
    [SerializeField]
    private GameObject nameArea;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private Image unitImage;

    [Header("Unit Properties")]
    [SerializeField]
    private TextMeshProUGUI attackText;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private TextMeshProUGUI rangeText;
    [SerializeField]
    private TextMeshProUGUI speedText;
    [SerializeField]
    private GameObject protectedArea;
    [SerializeField]
    private TextMeshProUGUI protectedText;
    [SerializeField]
    private Image statusIcon;

    public Player Owner { get { return Unit.Owner; } }

    public void InitUnitCounter(Unit _unit, Cell _cell)
    {
        Unit = _unit;
        Cell = _cell;

        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (GameManager.instance.imageManager.IsDefaultImage(Unit.CardArt))
        {
            nameArea.SetActive(true);
            nameText.text = Unit.Name;
            unitImage.sprite = null;
        }
        else
        {
            nameArea.SetActive(false);
            unitImage.sprite = Unit.CardArt;
        }

        RefreshUnitCounter();
    }

    public void RefreshUnitCounter()
    {
        attackText.text = Unit.Attack.ToString();
        attackText.color = GameManager.instance.colourManager.GetStatModColour(Unit.HasBuffedAttack);

        healthText.text = Unit.Health.ToString();
        healthText.color = GameManager.instance.colourManager.GetStatModColour(Unit.UnitIsDamaged);

        rangeText.text = Unit.Range.ToString();
        rangeText.color = GameManager.instance.colourManager.GetStatModColour(Unit.HasBuffedAttack);

        speedText.text = $"{Unit.RemainingSpeed}/{Unit.Speed}";
        speedText.color = GameManager.instance.colourManager.GetStatModColour(Unit.HasBuffedSpeed);

        protectedText.text = Unit.TotalProtected.HasValue ? Unit.TotalProtected.ToString() : "Inf";
        protectedArea.SetActive(!Unit.TotalProtected.HasValue || Unit.TotalProtected.Value > 0);

        statusIcon.color = GameManager.instance.colourManager.GetUnitStatusColour(Unit.Status);

        if (Unit.Rarity == Rarity.Hero || Unit.Rarity == Rarity.NPCHero)
        {
            GameManager.instance.uiManager.RefreshHeroStats = GameManager.instance.NumPlayers;
        }
    }

    public void ShowCardDetail()
    {
        GameManager.instance.uiManager.ActivateCardDetail(Unit.cardData);
    }
}
