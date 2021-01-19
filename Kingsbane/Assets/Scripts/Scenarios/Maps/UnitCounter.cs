using CategoryEnums;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitCounter : MonoBehaviour
{
    public Unit unit;
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
    private Image statusIcon;

    public Player Owner { get { return unit.Owner; } }

    public void InitUnitCounter(Unit _unit, Cell _cell)
    {
        unit = _unit;
        Cell = _cell;
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (GameManager.instance.imageManager.IsDefaultImage(unit.CardArt))
        {
            nameArea.SetActive(true);
            nameText.text = unit.Name;
            unitImage.sprite = null;
        }
        else
        {
            nameArea.SetActive(false);
            unitImage.sprite = unit.CardArt;
        }
    }

    public void RefreshUnitCounter()
    {
        attackText.text = unit.Attack.ToString();
        attackText.color = GameManager.instance.colourManager.GetStatModColour(unit.HasBuffedAttack);

        healthText.text = unit.Health.ToString();
        healthText.color = GameManager.instance.colourManager.GetStatModColour(unit.UnitIsDamaged);

        rangeText.text = unit.Range.ToString();
        rangeText.color = GameManager.instance.colourManager.GetStatModColour(unit.HasBuffedAttack);

        speedText.text = $"{unit.RemainingSpeed}/{unit.Speed}";
        speedText.color = GameManager.instance.colourManager.GetStatModColour(unit.HasBuffedSpeed);

        statusIcon.color = GameManager.instance.colourManager.GetUnitStatusColour(unit.Status);
    }

    public void ShowCardDetail()
    {
        GameManager.instance.uiManager.ActivateCardDetail(unit.cardData);
    }
}
