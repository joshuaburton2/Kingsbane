using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public bool isUILocked;

    Unit selectedUnit;

    [SerializeField]
    private GameObject unitCounter;

    public void InitEffectManager()
    {
        isUILocked = false;
        selectedUnit = null;
    }

    public void SetSelectedUnit(Unit _selectedUnit)
    {
        selectedUnit = _selectedUnit;
        isUILocked = true;
    }

    public GameObject DeploySelectedUnit(Transform parent)
    {
        return DeployUnit(selectedUnit, parent);
    }

    public GameObject DeployUnit (Unit unit, Transform parent)
    {
        var createdCounter = Instantiate(unitCounter, parent);

        var unitCounterScript = createdCounter.GetComponent<UnitCounter>();
        unitCounterScript.InitUnitCounter(unit);
        unit.Owner.DeployedUnits.Add(unitCounterScript);

        return createdCounter;
    }
}
