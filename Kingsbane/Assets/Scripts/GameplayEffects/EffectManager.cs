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

    private Card SelectedCard { get; set; }
    private Unit SelectedUnit { get; set; }
    private AbilityData SelectedAbility { get; set; }

    private Cell PreviousCell { get; set; }

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

                SelectedCard = null;
                SelectedUnit = null;

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
                    MoveSelectedUnit(PreviousCell, true);
                    CancelEffect = false;
                }
                ActiveEffect = ActiveEffectTypes.UnitCommand;
                PreviousCell = null;

                break;
        }
    }

    public void PlayCard(Card card)
    {
        SelectedCard = card;

        switch (card.Type)
        {
            case CategoryEnums.CardTypes.Unit:
                SelectedUnit = (Unit)card;
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
        SelectedUnit = _selectedUnit;
        ActiveEffect = ActiveEffectTypes.Deployment;
    }

    public GameObject DeploySelectedUnit(Cell cell)
    {
        return CreateUnitCounter(SelectedUnit, cell);
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

            if (SelectedCard != null)
            {
                SelectedCard.Play();
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
            PreviousCell = currentCell;
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
                RemoveUnit(SelectedUnit.UnitCounter);
                CreateUnitCounter(SelectedUnit, newCell);
            }
        }
    }

    public void SetAttackMode()
    {
        if (ActiveEffect == ActiveEffectTypes.UnitCommand)
        {
            ActiveEffect = ActiveEffectTypes.UnitAttack;
        }
    }

    public void UseAttack(Unit targetUnit)
    {
        if (targetUnit != null)
        {
            if (SelectedUnit.Owner.Id != targetUnit.Owner.Id)
            {
                SelectedUnit.TriggerAttack(targetUnit);
                RefreshEffectManager();
                GameManager.instance.uiManager.RefreshUI();
            }
        }
    }

    public void SetUnitAbilityMode(AbilityData abilityData)
    {
        if (ActiveEffect == ActiveEffectTypes.UnitCommand)
        {
            ActiveEffect = ActiveEffectTypes.UnitAbility;
            SelectedAbility = abilityData;
        }
    }

    public void UseAbility()
    {
        SelectedUnit.UseAbility(SelectedAbility);
        RefreshEffectManager();
        GameManager.instance.uiManager.RefreshUI();
    }

    public void CastSpell(Cell targetCell)
    {
        if (SelectedCard != null)
        {
            SelectedCard.Play();
            GameManager.instance.uiManager.RefreshUI();
            RefreshEffectManager();
        }
    }

    public void EquipItem(Item itemToReplace)
    {
        if (SelectedCard != null)
        {
            if (itemToReplace != null)
            {
                itemToReplace.DestroyItem();
            }

            SelectedCard.Play();
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

        if (unitCounter.Unit == SelectedUnit && ActiveEffect == ActiveEffectTypes.UnitAttack)
        {
            SelectedUnit = null;
        }
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
            SelectedUnit = _selectedUnit;
        }
        ActiveEffect = ActiveEffectTypes.UnitCommand;
    }
}
