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
        
        RefreshUnitCounter();
    }

    public void RefreshUnitCounter()
    {
        attackText.text = unit.Attack.ToString();
        var attackStatType = unit.HasBuffedAttack ? Unit.UnitStatTypes.Buffed : Unit.UnitStatTypes.None;
        attackText.color = GameManager.instance.colourManager.GetUnitStatColour(attackStatType);

        healthText.text = unit.Health.ToString();
        var healthStatType = unit.UnitIsDamaged ? Unit.UnitStatTypes.Damaged : Unit.UnitStatTypes.None;
        attackText.color = GameManager.instance.colourManager.GetUnitStatColour(healthStatType);

        rangeText.text = unit.Range.ToString();
        var rangeStatType = unit.HasBuffedAttack ? Unit.UnitStatTypes.Buffed : Unit.UnitStatTypes.None;
        attackText.color = GameManager.instance.colourManager.GetUnitStatColour(rangeStatType);

        speedText.text = unit.Speed.ToString();
        var speedStatType = unit.HasBuffedAttack ? Unit.UnitStatTypes.Buffed : Unit.UnitStatTypes.None;
        attackText.color = GameManager.instance.colourManager.GetUnitStatColour(speedStatType);

    }

    public void ShowCardDetail()
    {
        GameManager.instance.uiManager.ActivateCardDetail(unit.cardData);
    }
}
