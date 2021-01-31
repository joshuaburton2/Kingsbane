using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public enum ActiveEffectTypes
    {
        None,
        Deployment,
        Spell,
        Equip,
        UnitCommand,
        UnitForceMove,
        UnitUseSpeed,
        UnitMove,
        UnitAttack,
        UnitAbility,
    }

    public ActiveEffectTypes ActiveEffect { get; set; }
    public bool IsUILocked { get { return ActiveEffect != ActiveEffectTypes.None && ActiveEffect != ActiveEffectTypes.UnitCommand; } }
    public bool CancelEffect { get; set; }

    private readonly List<ActiveEffectTypes> CancelableEffects = new List<ActiveEffectTypes>()
    {
        ActiveEffectTypes.Deployment,
        ActiveEffectTypes.UnitMove,
        ActiveEffectTypes.UnitUseSpeed,
    };

    Card selectedCard;
    Unit selectedUnit;

    Cell previousCell;

    [SerializeField]
    private GameObject unitCounterPrefab;

    public void InitEffectManager()
    {
        CancelEffect = false;
        RefreshEffectManager();
    }

    public void CancelEffectManager()
    {
        if (CancelableEffects.Contains(ActiveEffect))
        {
            CancelEffect = true;
        }
        RefreshEffectManager();
    }

    public void RefreshEffectManager()
    {
        switch (ActiveEffect)
        {
            default:
                ActiveEffect = ActiveEffectTypes.None;

                selectedCard = null;
                selectedUnit = null;

                break;
            case ActiveEffectTypes.UnitForceMove:
            case ActiveEffectTypes.UnitAttack:
            case ActiveEffectTypes.UnitAbility:
                ActiveEffect = ActiveEffectTypes.UnitCommand;

                break;

            case ActiveEffectTypes.UnitMove:
                ActiveEffect = CancelEffect ? ActiveEffectTypes.UnitCommand : ActiveEffectTypes.UnitUseSpeed;
                CancelEffect = false;

                break;
            case ActiveEffectTypes.UnitUseSpeed:
                if (CancelEffect)
                {
                    MoveSelectedUnit(previousCell, true);
                    CancelEffect = false;
                }
                ActiveEffect = ActiveEffectTypes.UnitCommand;
                previousCell = null;

                break;
        }
    }

    public void PlayCard(Card card)
    {
        selectedCard = card;

        switch (card.Type)
        {
            case CategoryEnums.CardTypes.Unit:
                selectedUnit = (Unit)card;
                ActiveEffect = ActiveEffectTypes.Deployment;
                break;
            case CategoryEnums.CardTypes.Spell:
                ActiveEffect = ActiveEffectTypes.Spell;
                break;
            case CategoryEnums.CardTypes.Item:
                ActiveEffect = ActiveEffectTypes.Equip;
                break;
            case CategoryEnums.CardTypes.Default:
            default:
                break;
        }
    }

    public void SetSelectedUnitDeploy(Unit _selectedUnit)
    {
        selectedUnit = _selectedUnit;
        ActiveEffect = ActiveEffectTypes.Deployment;
    }

    public GameObject DeploySelectedUnit(Cell cell)
    {
        return CreateUnitCounter(selectedUnit, cell);
    }

    public GameObject CreateUnitCounter(Unit unit, Cell cell)
    {
        if (cell.occupantCounter == null)
        {
            var createdCounter = Instantiate(unitCounterPrefab, cell.backgroundImage.transform);

            var unitCounterScript = createdCounter.GetComponent<UnitCounter>();
            unitCounterScript.InitUnitCounter(unit, cell);
            unit.UnitCounter = unitCounterScript;
            if (!unit.Owner.DeployedUnits.Contains(unitCounterScript))
                unit.Owner.DeployedUnits.Add(unitCounterScript);
            cell.occupantCounter = createdCounter.GetComponent<UnitCounter>();

            if (selectedCard != null)
            {
                selectedCard.Play();
                GameManager.instance.uiManager.RefreshUI();
            }

            unitCounterScript.RefreshUnitCounter();
            RefreshEffectManager();

            return createdCounter;
        }
        else
        {
            return null;
        }
    }

    public void SetMoveUnitMode(Cell currentCell)
    {
        if (ActiveEffect == ActiveEffectTypes.UnitCommand)
        {
            ActiveEffect = ActiveEffectTypes.UnitMove;
            previousCell = currentCell;
        }
    }

    public void SetForceMoveUnitMode()
    {
        if (ActiveEffect == ActiveEffectTypes.UnitCommand)
        {
            ActiveEffect = ActiveEffectTypes.UnitForceMove;
        }
    }

    public void MoveSelectedUnit(Cell newCell, bool isCancel = false)
    {
        if (ActiveEffect == ActiveEffectTypes.UnitMove || ActiveEffect == ActiveEffectTypes.UnitForceMove || ActiveEffect == ActiveEffectTypes.UnitUseSpeed)
        {
            if (newCell.occupantCounter == null)
            {
                RemoveUnit(selectedUnit.UnitCounter);
                CreateUnitCounter(selectedUnit, newCell);
            }
        }
    }

    public void CastSpell(Cell targetCell)
    {
        if (selectedCard != null)
        {
            selectedCard.Play();
            GameManager.instance.uiManager.RefreshUI();
            RefreshEffectManager();
        }
    }

    public void EquipItem(Item itemToReplace)
    {
        if (selectedCard != null)
        {
            if (itemToReplace != null)
            {
                itemToReplace.DestroyItem();
            }

            selectedCard.Play();
            GameManager.instance.uiManager.RefreshUI();
            RefreshEffectManager();
        }
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

    public void SetSelectedUnitCommand(Unit _selectedUnit)
    {
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
        {
            selectedUnit = _selectedUnit;
        }
        ActiveEffect = ActiveEffectTypes.UnitCommand;
    }
}
