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

    public ActiveEffectTypes activeEffect { get; set; }
    public bool isUILocked { get { return activeEffect != ActiveEffectTypes.None; } }
    public bool CancelEffect { get; set; }

    Unit selectedUnit;

    [SerializeField]
    private GameObject unitCounterPrefab;

    private void Update()
    {
        if (isUILocked)
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

    private void RefreshEffectManager()
    {
        activeEffect = ActiveEffectTypes.None;
        selectedUnit = null;
    }

    public void SetSelectedUnit(Unit _selectedUnit)
    {
        selectedUnit = _selectedUnit;
        activeEffect = ActiveEffectTypes.Deployment;
    }

    public GameObject DeploySelectedUnit(Transform parent, Cell cell)
    {
        var deployedUnit = DeployUnit(selectedUnit, parent, cell);
        selectedUnit = null;
        return deployedUnit;
    }

    public GameObject DeployUnit (Unit unit, Transform parent, Cell cell)
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
