using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public enum ActiveEffectTypes
    {
        None,
        Deployment,
    }

    public ActiveEffectTypes ActiveEffect { get; set; }
    public bool IsUILocked { get { return ActiveEffect != ActiveEffectTypes.None; } }
    public bool CancelEffect { get; set; }

    Unit selectedUnit;

    [SerializeField]
    private GameObject unitCounterPrefab;

    private void Update()
    {
        if (IsUILocked)
        {
            if (Input.GetMouseButtonDown(1))
            {
                CancelEffect = true;
                RefreshEffectManager();
            }
        }
    }

    public void InitEffectManager()
    {
        CancelEffect = false;
        RefreshEffectManager();
    }

    public void RefreshEffectManager()
    {
        ActiveEffect = ActiveEffectTypes.None;
        selectedUnit = null;
    }

    public void PlayCard(Card card)
    {
        switch (card.Type)
        {
            case CategoryEnums.CardTypes.Unit:
                break;
            case CategoryEnums.CardTypes.Spell:
                break;
            case CategoryEnums.CardTypes.Item:
                break;
            case CategoryEnums.CardTypes.Default:
            default:
                break;
        }
    }

    public void DiscardCard(Card card)
    {
        card.Owner.DiscardFromHand(card);
        GameManager.instance.uiManager.RefreshGameplayUI();
    }

    public void SetSelectedUnit(Unit _selectedUnit)
    {
        selectedUnit = _selectedUnit;
        ActiveEffect = ActiveEffectTypes.Deployment;
    }

    public GameObject DeploySelectedUnit(Transform parent, Cell cell)
    {
        var deployedUnit = DeployUnit(selectedUnit, parent, cell);
        selectedUnit = null;
        return deployedUnit;
    }

    public GameObject DeployUnit(Unit unit, Transform parent, Cell cell)
    {
        var createdCounter = Instantiate(unitCounterPrefab, parent);

        var unitCounterScript = createdCounter.GetComponent<UnitCounter>();
        unitCounterScript.InitUnitCounter(unit, cell);
        unit.Owner.DeployedUnits.Add(unitCounterScript);
        RefreshEffectManager();

        return createdCounter;
    }

    public void RemoveAllPlayerUnits(Player player)
    {
        foreach (var unitCounter in player.DeployedUnits)
        {
            DestroyUnitCounter(unitCounter);
        }

        player.DeployedUnits.Clear();
    }

    public void RemoveUnit(UnitCounter unitCounter)
    {
        DestroyUnitCounter(unitCounter);
        unitCounter.Owner.DeployedUnits.Remove(unitCounter);
    }

    private void DestroyUnitCounter(UnitCounter unitCounter)
    {
        Destroy(unitCounter.gameObject);
        unitCounter.Cell.occupantCounter = null;
    }

    public void MulliganHand()
    {
        GameManager.instance.GetActivePlayer().DrawMulligan();
    }
}
