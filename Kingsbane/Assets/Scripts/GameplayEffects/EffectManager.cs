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
    private GameObject unitCounter;

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

    public GameObject DeploySelectedUnit(Transform parent)
    {
        var deployedUnit = DeployUnit(selectedUnit, parent);
        selectedUnit = null;
        return deployedUnit;
    }

    public GameObject DeployUnit (Unit unit, Transform parent)
    {
        var createdCounter = Instantiate(unitCounter, parent);

        var unitCounterScript = createdCounter.GetComponent<UnitCounter>();
        unitCounterScript.InitUnitCounter(unit);
        unit.Owner.DeployedUnits.Add(unitCounterScript);
        RefreshEffectManager();

        return createdCounter;
    }
}
