using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitCounter : MonoBehaviour
{
    private Unit unit;

    [SerializeField]
    private Canvas canvas;
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

    public void InitUnitCounter(Unit _unit)
    {
        unit = _unit;
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        RefreshUnitCounter();
    }

    public void RefreshUnitCounter()
    {
        nameText.text = unit.CardName;
        attackText.text = unit.Attack.ToString();
        healthText.text = unit.Health.ToString();
        rangeText.text = unit.Range.ToString();
        speedText.text = unit.Speed.ToString();
    }
}
