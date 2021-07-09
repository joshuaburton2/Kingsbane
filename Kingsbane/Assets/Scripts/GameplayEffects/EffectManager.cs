﻿using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    /// <summary>
    /// 
    /// List of all effects which can be activated in the game
    /// 
    /// </summary>
    public enum ActiveEffectTypes
    {
        None,
        Deployment,
        ForceDeployment,
        SelectCaster,
        Spell,
        Equip,
        ForceEquip,
        UnitCommand,
        UnitForceMove,
        UnitUseSpeed,
        UnitMove,
        UnitUseDisengageSpeed,
        UnitDisengage,
        UnitAttack,
        UnitAbility,
        DealDamage,
        HealUnit,
        Protected,
        DestroyUnit,
        RemoveUnit,
        EnchantUnit,
        RootUnit,
        StunUnit,
        ModifyCost,
        Spellbind,
        RestoreEnchantment,
        GraveyardToHandChoice,
        GraveyardToDeployChoice,
        AddToHandChoice,
        AddToDeckChoice,
        AddToGraveyardChoice,
        DeployChoice,
        DrawChoice,
        Divinate,
        ItemEquipChoice,
        UnitCopyMode,
        MindControl,
        Recruit,
        SpycraftChoice,
        Madness,
        ReturnToHand,
        Redeploy,
        FortuneTellerChoice,
        AlterFateChoice,
        TileStatus,
        Transform,
        ImmuneUnit,
        IndestructibleUnit,
        Confiscate,
        SelectImprisonCaster,
        Imprison,
        SpymasterLurenSource,
    }

    public ActiveEffectTypes ActiveEffect { get; set; }
    public bool IsUILocked { get { return ActiveEffect != ActiveEffectTypes.None && ActiveEffect != ActiveEffectTypes.UnitCommand; } }
    public bool CancelEffect { get; set; }

    /// <summary>
    /// 
    /// List of effects which cannot be cancelled with a right click event
    /// 
    /// </summary>
    private readonly List<ActiveEffectTypes> NonCancelableEffects = new List<ActiveEffectTypes>()
    {
        ActiveEffectTypes.None,
        ActiveEffectTypes.ForceDeployment,
        ActiveEffectTypes.ForceEquip,
        ActiveEffectTypes.GraveyardToDeployChoice,
        ActiveEffectTypes.GraveyardToHandChoice,
        ActiveEffectTypes.AddToHandChoice,
        ActiveEffectTypes.AddToDeckChoice,
        ActiveEffectTypes.AddToGraveyardChoice,
        ActiveEffectTypes.DeployChoice,
        ActiveEffectTypes.DrawChoice,
        ActiveEffectTypes.ItemEquipChoice,
        ActiveEffectTypes.Divinate,
        ActiveEffectTypes.SpycraftChoice,
        ActiveEffectTypes.AlterFateChoice,
        ActiveEffectTypes.FortuneTellerChoice,
    };

    //Storage objects for the different effects
    private Card SelectedCard { get; set; }
    private Unit SelectedUnit { get; set; }
    private List<Unit> DeployUnits { get; set; }
    private CardData SelectedCardData { get; set; }
    private Item SelectedItem { get; set; }
    private Ability SelectedAbility { get; set; }
    private UnitEnchantment SelectedEnchantment { get; set; }
    private int? SelectedValue { get; set; }
    private AdjustCostObject SelectedAdjustCost { get; set; }
    private bool? SelectedBoolean { get; set; }
    private string SelectedString { get; set; }
    private DeckPositions? SelectedDeckPosition { get; set; }
    private List<Keywords> SelectedKeywords { get; set; }
    private TileStatuses SelectedTileStatus { get; set; }
    private List<Cell> TargetCells { get; set; }

    private Cell PreviousCell { get; set; }

    [SerializeField]
    private GameObject unitCounterPrefab;

    /// <summary>
    /// 
    /// Initialise the effect manager
    /// 
    /// </summary>
    public void InitEffectManager()
    {
        //Cancel effect is a variable for tracking whether an effect is cancelled. This is required for external detection
        //of the cancellation (such as in the effect bar). Cancel effect can also be reset outside of the effect manager as well once detection has been made externally
        CancelEffect = false;
        RefreshEffectManager();
    }

    /// <summary>
    /// 
    /// Cancel the effect manager, removing all active effects
    /// 
    /// </summary>
    public void CancelEffectManager()
    {
        //Certain effects cannot be cancelled through a right click event
        if (!NonCancelableEffects.Contains(ActiveEffect))
        {
            //If the cancelled effect is the unit command effect, then don't need cancel effect to be set to true
            if (ActiveEffect != ActiveEffectTypes.UnitCommand)
                CancelEffect = true;

            //Once cancelled, refreshing the effect maanger will determine what the new effect is
            RefreshEffectManager();
            GameManager.instance.mapGrid.ClearHighlights();
        }
    }

    /// <summary>
    /// 
    /// Refresh the effect manager, reseting relevant stored variables and moving the effect manager from one effect to another
    /// 
    /// </summary>
    /// <param name="fullReset">Full reset should only be true when entering or exiting the gameplay scene, or at the start of each turn, as at these points need to set back to default state</param>
    public void RefreshEffectManager(bool fullReset = false)
    {
        if (fullReset)
            ActiveEffect = ActiveEffectTypes.None;

        //Reset the common storage variables (i.e. these variables behaviour doesn't change with different effects)
        SelectedCardData = null;
        SelectedEnchantment = null;
        SelectedAbility = null;
        SelectedValue = null;
        SelectedBoolean = null;
        SelectedString = null;
        SelectedDeckPosition = null;
        SelectedKeywords = new List<Keywords>();
        SelectedAdjustCost = null;
        TargetCells = null;

        //Determines the behaviour of the refresh based on the current effect
        switch (ActiveEffect)
        {
            default:
                //Default case. Variables changed in here have their behaviour modified when refreshing from different effects
                ActiveEffect = ActiveEffectTypes.None;

                SelectedCard = null;
                //Hides the unit selector if it is active (which would be active from units being selected as the command unit or the caster)
                if (SelectedUnit != null && GameManager.instance.CurrentGamePhase != GameManager.GamePhases.Menu)
                    SelectedUnit.UnitCounter.ShowUnitSelector(false);
                SelectedUnit = null;
                DeployUnits = new List<Unit>();
                SelectedItem = null;

                break;
            case ActiveEffectTypes.Spell:
                //If casting a spell, and cancelling the effect, need to move back to select caster phase, allowing player to reselect a caster
                ActiveEffect = CancelEffect ? ActiveEffectTypes.SelectCaster : ActiveEffectTypes.None;
                CancelEffect = false;

                //Hides the unit selector icon from the caster which was previously selected, then resets the selected caster
                if (SelectedUnit != null)
                    if (SelectedUnit.UnitCounter != null)
                        SelectedUnit.UnitCounter.ShowUnitSelector(false);
                SelectedUnit = null;
                break;
            case ActiveEffectTypes.Deployment:
            case ActiveEffectTypes.ForceDeployment:
                //Resets the selected card and unit
                SelectedCard = null;
                SelectedUnit = null;

                //If there are no units left to deploy, or cancelling the effect, sets the active effect back to its based and hides the deployment details
                if (DeployUnits.Count == 0 || CancelEffect)
                {
                    ActiveEffect = ActiveEffectTypes.None;
                    GameManager.instance.uiManager.ShowCardDisplay();
                    GameManager.instance.uiManager.ShowMapKeyOfType();
                }
                //If there are units left in the list, continues with the effect and displays the next card in the list
                else
                {
                    GameManager.instance.uiManager.ShowCardDisplay(DeployUnits.FirstOrDefault());
                }
                break;
            case ActiveEffectTypes.Equip:
            case ActiveEffectTypes.ForceEquip:
                SelectedCard = null;

                if (SelectedItem == null || CancelEffect)
                {
                    ActiveEffect = ActiveEffectTypes.None;
                }
                break;
            case ActiveEffectTypes.UnitForceMove:
            case ActiveEffectTypes.UnitAttack:
            case ActiveEffectTypes.UnitAbility:
                if (ActiveEffect == ActiveEffectTypes.UnitForceMove)
                    GameManager.instance.uiManager.ShowMapKeyOfType();
                ActiveEffect = ActiveEffectTypes.UnitCommand;

                CancelEffect = false;
                break;
            case ActiveEffectTypes.UnitMove:
                ActiveEffect = ActiveEffectTypes.UnitCommand;

                CancelEffect = false;

                break;
            case ActiveEffectTypes.UnitDisengage:
                ActiveEffect = ActiveEffectTypes.UnitCommand;
                CancelEffect = false;

                break;
            case ActiveEffectTypes.UnitUseSpeed:
            case ActiveEffectTypes.UnitUseDisengageSpeed:
                if (CancelEffect)
                {
                    MoveCommandUnit(PreviousCell, false);
                    CancelEffect = false;
                }
                ActiveEffect = ActiveEffectTypes.UnitCommand;
                PreviousCell = null;

                GameManager.instance.uiManager.ShowMapKeyOfType();

                break;
        }
    }

    public void PlayCard(Card card)
    {
        SelectedCard = card;

        switch (card.Type)
        {
            case CardTypes.Unit:
                SetDeployUnit((Unit)card);
                break;
            case CardTypes.Spell:
                ActiveEffect = ActiveEffectTypes.SelectCaster;
                break;
            case CardTypes.Item:
                ActiveEffect = ActiveEffectTypes.Equip;
                SelectedItem = (Item)card;
                break;
            case CardTypes.Default:
            default:
                break;
        }
    }

    public void SetDeployUnit(Unit _selectedUnit, bool isForced = false)
    {
        GameManager.instance.uiManager.ShowMapKeyOfType(MapGrid.MapFilters.Deployment);
        DeployUnits = new List<Unit>() { _selectedUnit };
        ActiveEffect = isForced ? ActiveEffectTypes.ForceDeployment : ActiveEffectTypes.Deployment;

        GameManager.instance.uiManager.ShowCardDisplay(DeployUnits.FirstOrDefault());
    }

    public void SetDeployUnits(List<Unit> _selectedUnits, bool isForced = false)
    {
        GameManager.instance.uiManager.ShowMapKeyOfType(MapGrid.MapFilters.Deployment);
        DeployUnits = _selectedUnits;
        ActiveEffect = isForced ? ActiveEffectTypes.ForceDeployment : ActiveEffectTypes.Deployment;

        GameManager.instance.uiManager.ShowCardDisplay(DeployUnits.FirstOrDefault());
    }

    public void SetCopyMode(int numCopies = 1)
    {
        ActiveEffect = ActiveEffectTypes.UnitCopyMode;
        SelectedValue = numCopies;
    }

    public void SelectCopyUnit(Unit unit)
    {
        var copyUnits = new List<Unit>();
        for (int unitIndex = 0; unitIndex < SelectedValue; unitIndex++)
        {
            var unitCopy = (Unit)GameManager.instance.libraryManager.CreateCard(unit.CardData, unit.Owner);
            unitCopy.CopyCardStats(unit);
            copyUnits.Add(unitCopy);
        }
        SetDeployUnits(copyUnits);
    }

    public void SetItemEquip(Item _selectedItem, bool isForced = false)
    {
        SelectedItem = _selectedItem;
        ActiveEffect = isForced ? ActiveEffectTypes.ForceEquip : ActiveEffectTypes.Equip;
    }

    public GameObject DeployUnit(Cell cell)
    {
        if (DeployUnits.FirstOrDefault().CheckOccupancy(cell))
        {
            var unitObject = CreateUnitCounter(DeployUnits.FirstOrDefault(), cell);
            RefreshEffectManager();
            return unitObject;
        }
        else
            return null;
    }

    public GameObject CreateUnitCounter(Unit unit, Cell cell, bool isNew = true)
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

            if (isNew)
            {
                if (SelectedCard != null)
                {
                    SelectedCard.Play();
                }
                else
                {
                    unit.Deploy();
                }
                GameManager.instance.uiManager.RefreshUI();
            }

            if (unit.Owner.RedeployUnits.Contains(unit))
            {
                unit.Owner.RedeployUnits.Remove(unit);
                GameManager.instance.uiManager.RefreshUI();
            }

            cell.CheckTileStatusOnEntry(unit);

            DeployUnits.Remove(unit);

            GameManager.instance.CheckWarden();

            unitCounterScript.RefreshUnitCounter();

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
            SelectedBoolean = false;
            GameManager.instance.uiManager.ShowMapKeyOfType(MapGrid.MapFilters.Terrain);

            ShowMoveTiles(currentCell);
        }
    }

    public void SetDisengageUnitMode(Cell currentCell)
    {
        if (ActiveEffect == ActiveEffectTypes.UnitCommand)
        {
            ActiveEffect = ActiveEffectTypes.UnitDisengage;
            PreviousCell = currentCell;
            SelectedBoolean = true;
            GameManager.instance.uiManager.ShowMapKeyOfType(MapGrid.MapFilters.Terrain);

            ShowMoveTiles(currentCell);
        }
    }

    private void ShowMoveTiles(Cell currentCell)
    {
        var moveCells = currentCell.GetRadiusTiles(SelectedUnit.RemainingSpeed, Cell.RadiusTilesType.Unit, false);

        foreach (var cell in moveCells)
        {
            if (cell.occupantCounter == null)
                cell.SetHighlightColour(GameManager.instance.colourManager.highlightColour);
        }
    }

    public void SetForceMoveUnitMode()
    {
        if (ActiveEffect == ActiveEffectTypes.UnitCommand)
        {
            ActiveEffect = ActiveEffectTypes.UnitForceMove;
            GameManager.instance.uiManager.ShowMapKeyOfType(MapGrid.MapFilters.Terrain);
        }
    }

    public void MoveCommandUnit(Cell newCell, bool checkPath = true)
    {
        if (ActiveEffect == ActiveEffectTypes.UnitMove ||
            ActiveEffect == ActiveEffectTypes.UnitDisengage ||
            ActiveEffect == ActiveEffectTypes.UnitForceMove ||
            ActiveEffect == ActiveEffectTypes.UnitUseSpeed ||
            ActiveEffect == ActiveEffectTypes.UnitUseDisengageSpeed)
        {
            if (newCell.occupantCounter == null)
            {
                if (SelectedUnit.CheckOccupancy(newCell) || ActiveEffect == ActiveEffectTypes.UnitForceMove)
                {
                    var isValidPath = true;
                    if (checkPath)
                    {
                        var pathSearch = new AStarSearch(PreviousCell, newCell, SelectedUnit);
                        isValidPath = pathSearch.CheckMoveCost(SelectedUnit.RemainingSpeed, newCell);
                        if (isValidPath)
                            SelectedUnit.UseSpeed(pathSearch.costSoFar[newCell], SelectedBoolean.Value);
                    }

                    if (isValidPath)
                    {
                        RemoveUnitCounter(SelectedUnit.UnitCounter);
                        CreateUnitCounter(SelectedUnit, newCell, false);
                        SelectedUnit.UnitCounter.ShowUnitSelector(true);
                        RefreshEffectManager();
                        GameManager.instance.uiManager.RefreshUI();
                        GameManager.instance.mapGrid.ClearHighlights();
                    }
                }
            }
        }
    }

    public void SetAttackMode()
    {
        if (ActiveEffect == ActiveEffectTypes.UnitCommand)
        {
            var unitRange = SelectedUnit.GetStat(Unit.StatTypes.Range);
            if (unitRange == 0)
                unitRange = 1;

            var attackCells = SelectedUnit.UnitCounter.Cell.GetRadiusTiles(unitRange, Cell.RadiusTilesType.Attack);

            var validTargets = false;

            foreach (var cell in attackCells.ToList())
            {
                if (cell.occupantCounter != null && cell.occupantCounter.Unit.Status == Unit.UnitStatuses.Enemy)
                {
                    validTargets = true;
                    cell.SetHighlightColour(GameManager.instance.colourManager.highlightColour);
                }
            }

            if (validTargets)
            {
                ActiveEffect = ActiveEffectTypes.UnitAttack;
                TargetCells = attackCells;
            }
            else
            {

            }
        }
    }

    public void UseAttack(Unit targetUnit)
    {
        if (targetUnit != null)
        {
            //if (SelectedUnit.CanAttackTarget(targetUnit))
            //{
            SelectedUnit.TriggerAttack(targetUnit);
            RefreshEffectManager();
            GameManager.instance.uiManager.RefreshUI();
            GameManager.instance.mapGrid.ClearHighlights();
            //}
        }
    }

    public void SetUnitAbilityMode(Ability ability)
    {
        if (ActiveEffect == ActiveEffectTypes.UnitCommand)
        {
            ActiveEffect = ActiveEffectTypes.UnitAbility;
            SelectedAbility = ability;
        }
    }

    public void UseAbility()
    {
        SelectedUnit.UseAbility(SelectedAbility);
        RefreshEffectManager();
        GameManager.instance.uiManager.RefreshUI();
    }

    public void SelectCaster(Unit caster, bool requiresActiveCaster = true)
    {
        if (!requiresActiveCaster || caster.CanCastSpell)
        {
            if (((Spell)SelectedCard).SpellRange == 0)
            {
                TargetCells = null;
                CastSpell(caster.UnitCounter.Cell);
            }
            else
            {
                SelectedUnit = caster;
                ActiveEffect = ActiveEffectTypes.Spell;

                var spellCells = caster.UnitCounter.Cell.GetRadiusTiles(((Spell)SelectedCard).SpellRange, Cell.RadiusTilesType.Spell);

                foreach (var cell in spellCells)
                {
                    cell.SetHighlightColour(GameManager.instance.colourManager.highlightColour);
                }

                TargetCells = spellCells;

                if (SelectedUnit.UnitCounter != null)
                    SelectedUnit.UnitCounter.ShowUnitSelector(true);
            }

            caster.Unstealth();
        }
    }

    public void CastSpell(Cell targetCell)
    {
        if (SelectedCard != null)
        {
            if (TargetCells == null || TargetCells != null && TargetCells.Contains(targetCell))
            {
                //Need to account for caster (Selected Unit)
                SelectedCard.Play();
                GameManager.instance.uiManager.RefreshUI();
                RefreshEffectManager();
                GameManager.instance.mapGrid.ClearHighlights();
            }
        }
    }

    public void EquipItem(Item itemToReplace, int itemAreaPlayerId)
    {
        if (SelectedItem != null)
        {
            if (SelectedItem.Owner.Id == itemAreaPlayerId)
            {
                if (!SelectedItem.Owner.Hero.EquippedItems.Select(x => x.Id).Contains(SelectedItem.Id) || (itemToReplace != null && itemToReplace.Id == SelectedItem.Id))
                {
                    if (itemToReplace != null)
                    {
                        itemToReplace.DestroyItem();
                    }

                    if (SelectedCard != null)
                    {
                        SelectedCard.Play();
                    }
                    else
                    {
                        SelectedItem.Equip();
                    }

                    SelectedItem = null;
                    GameManager.instance.uiManager.RefreshUI();
                    RefreshEffectManager();
                }
            }
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

    public void RemoveUnitCounter(UnitCounter unitCounter)
    {
        DestroyUnitCounter(unitCounter);
        unitCounter.Owner.DeployedUnits.Remove(unitCounter);

        if (unitCounter.Unit == SelectedUnit && ActiveEffect == ActiveEffectTypes.DestroyUnit)
        {
            SelectedUnit = null;
            GameManager.instance.uiManager.RefreshUI();
        }
    }

    private void DestroyUnitCounter(UnitCounter unitCounter)
    {
        Destroy(unitCounter.gameObject);
        unitCounter.Cell.occupantCounter = null;
        unitCounter.Unit.UnitCounter = null;
    }

    public void MulliganHand()
    {
        GameManager.instance.GetPlayer().DrawMulligan();
    }

    public void SetCommandUnit(Unit _selectedUnit)
    {
        if (SelectedUnit != null)
            SelectedUnit.UnitCounter.ShowUnitSelector(false);
        SelectedUnit = _selectedUnit;
        ActiveEffect = ActiveEffectTypes.UnitCommand;
        _selectedUnit.UnitCounter.ShowUnitSelector(true);
    }

    public void SetDealDamageMode(int damageValue, List<Keywords> keywords)
    {
        SelectedValue = damageValue;
        SelectedKeywords = keywords;
        ActiveEffect = ActiveEffectTypes.DealDamage;
    }

    public void DealDamage(Unit unit)
    {
        if (SelectedValue.HasValue)
            unit.DamageUnit(GameManager.instance.GetPlayer(), SelectedValue.Value, SelectedKeywords);
        else
            throw new Exception("Damage value not set");
    }

    public void SetHealMode(int? healValue = null)
    {
        SelectedValue = healValue;
        ActiveEffect = ActiveEffectTypes.HealUnit;
    }

    public void HealUnit(Unit unit)
    {
        unit.HealUnit(SelectedValue);
    }

    public void SetProtectedMode(int protectedValue, bool isTemporary)
    {
        SelectedValue = protectedValue;
        SelectedBoolean = isTemporary;
        ActiveEffect = ActiveEffectTypes.Protected;
    }

    public void ProtectUnit(Unit unit)
    {
        unit.AddProtected(SelectedValue.Value, SelectedBoolean.Value);
    }

    public void SetDestroyUnitMode()
    {
        ActiveEffect = ActiveEffectTypes.DestroyUnit;
    }

    public void DestroyUnit(Unit unit)
    {
        unit.RemoveUnit(true);
    }

    public void SetRemoveUnitMode()
    {
        ActiveEffect = ActiveEffectTypes.RemoveUnit;
    }

    public void RemoveUnit(Unit unit)
    {
        unit.RemoveUnit();
    }

    public void SetEnchantUnitMode(UnitEnchantment unitEnchantment)
    {
        SelectedEnchantment = unitEnchantment;
        ActiveEffect = ActiveEffectTypes.EnchantUnit;
    }

    public void EnchantUnit(Unit unit)
    {
        unit.AddEnchantment(SelectedEnchantment);

        if (SelectedEnchantment.StatModifiers.Any(x => x.StatType == Unit.StatTypes.Empowered))
            GameManager.instance.uiManager.RefreshUI();
    }

    public void SetRootMode()
    {
        ActiveEffect = ActiveEffectTypes.RootUnit;
    }

    public void RootUnit(Unit unit)
    {
        unit.RootUnit();
    }

    public void SetStunMode()
    {
        ActiveEffect = ActiveEffectTypes.StunUnit;
    }

    public void StunUnit(Unit unit)
    {
        unit.StunUnit();
    }

    public void SetModifyCostMode(AdjustCostObject adjustCostObject)
    {
        ActiveEffect = ActiveEffectTypes.ModifyCost;
        SelectedAdjustCost = adjustCostObject;
    }

    public void ModifyCost(Card card)
    {
        var canModify = card.ModifyCost(SelectedAdjustCost);
        if (!canModify)
            Debug.Log("Cannot modify cost of card");
        else
            GameManager.instance.uiManager.RefreshUI();
    }

    public void ModifyCostOfTargetCards(AdjustCostObject adjustCostObject)
    {
        var player = GameManager.instance.GetPlayer();

        foreach (var card in player.Hand.List.Where(x => x.Type == adjustCostObject.TargetCardType))
            card.ModifyCost(adjustCostObject);

        foreach (var card in player.Deck.List.Where(x => x.Type == adjustCostObject.TargetCardType))
            card.ModifyCost(adjustCostObject);

        GameManager.instance.uiManager.RefreshUI();
    }

    public void SetSpellbindMode()
    {
        ActiveEffect = ActiveEffectTypes.Spellbind;
    }

    public void SpellbindUnit(Unit unit)
    {
        unit.Spellbind();
    }

    public void SetRestoreEnchantmentMode()
    {
        ActiveEffect = ActiveEffectTypes.RestoreEnchantment;
    }

    public void RestoreUnitEnchantments(Unit unit)
    {
        unit.RestoreEnchantments();
    }

    public void SetGraveyardToHandChoiceMode(List<Card> cards, bool isCopy, string createdBy)
    {
        ActiveEffect = ActiveEffectTypes.GraveyardToHandChoice;
        GameManager.instance.uiManager.ShowCardChoiceDisplay(cards);
        SelectedBoolean = isCopy;
        SelectedString = createdBy;
    }

    public void SetGraveyardToDeployChoiceMode(List<Card> cards)
    {
        ActiveEffect = ActiveEffectTypes.GraveyardToDeployChoice;
        GameManager.instance.uiManager.ShowCardChoiceDisplay(cards);
    }

    public void SetAddToHandChoiceMode(List<Card> cards, string createdBy)
    {
        ActiveEffect = ActiveEffectTypes.AddToHandChoice;
        GameManager.instance.uiManager.ShowCardChoiceDisplay(cards);
        SelectedString = createdBy;
    }

    public void SetAddToDeckChoiceMode(List<Card> cards, string createdBy, DeckPositions deckPosition)
    {
        ActiveEffect = ActiveEffectTypes.AddToDeckChoice;
        GameManager.instance.uiManager.ShowCardChoiceDisplay(cards);
        SelectedString = createdBy;
        SelectedDeckPosition = deckPosition;
    }

    public void SetAddToGraveyardChoiceMode(List<Card> cards, string createdBy)
    {
        ActiveEffect = ActiveEffectTypes.AddToGraveyardChoice;
        GameManager.instance.uiManager.ShowCardChoiceDisplay(cards);
        SelectedString = createdBy;
    }

    public void SetDeployChoiceMode(List<Card> cards, string createdBy)
    {
        ActiveEffect = ActiveEffectTypes.DeployChoice;
        GameManager.instance.uiManager.ShowCardChoiceDisplay(cards);
        SelectedString = createdBy;
    }

    public void SetItemChoiceMode(List<Card> cards, string createdBy)
    {
        ActiveEffect = ActiveEffectTypes.ItemEquipChoice;
        GameManager.instance.uiManager.ShowCardChoiceDisplay(cards);
        SelectedString = createdBy;
    }

    public void SetDrawChoiceMode(List<Card> cards)
    {
        ActiveEffect = ActiveEffectTypes.DrawChoice;
        GameManager.instance.uiManager.ShowCardChoiceDisplay(cards);
    }

    public void SetSpycraftChoiceMode(int numToChoose)
    {
        ActiveEffect = ActiveEffectTypes.SpycraftChoice;

        var inactivePlayer = GameManager.instance.GetPlayer(false);
        var spycraftCards = inactivePlayer.Hand.GetRandomCards(numToChoose);
        GameManager.instance.uiManager.ShowCardChoiceDisplay(spycraftCards);
    }

    public void SetFortuneTellerChoiceMode(List<Card> cards)
    {
        ActiveEffect = ActiveEffectTypes.FortuneTellerChoice;
        GameManager.instance.uiManager.ShowCardChoiceDisplay(cards);
    }

    public void ChooseEffect(Card card)
    {
        var player = card.Owner;

        Unit unit;

        switch (ActiveEffect)
        {
            case ActiveEffectTypes.GraveyardToHandChoice:
                if (SelectedBoolean.Value)
                {
                    card = GameManager.instance.libraryManager.CreateCard(card.CardData, player);
                    card.CreatedByName = SelectedString;
                }
                else
                {
                    player.Graveyard.RemoveCard(card);
                }

                player.AddToHand(card);

                break;
            case ActiveEffectTypes.GraveyardToDeployChoice:
                unit = (Unit)card;
                SetDeployUnit(unit, true);
                player.Graveyard.RemoveCard(card);
                break;
            case ActiveEffectTypes.AddToHandChoice:
                player.AddToHand(card, SelectedString);
                break;
            case ActiveEffectTypes.AddToDeckChoice:
                player.Deck.ShuffleIntoDeck(card, SelectedString, SelectedDeckPosition.Value);
                break;
            case ActiveEffectTypes.AddToGraveyardChoice:
                player.AddToGraveyard(card, SelectedString);
                break;
            case ActiveEffectTypes.DeployChoice:
                unit = (Unit)card;
                SetDeployUnit(unit, true);
                break;
            case ActiveEffectTypes.DrawChoice:
                player.Draw(card);
                break;
            case ActiveEffectTypes.ItemEquipChoice:
                SetItemEquip((Item)card, true);
                break;
            case ActiveEffectTypes.SpycraftChoice:
                player = GameManager.instance.GetPlayer();
                player.RecruitCard(card, true);
                break;
            case ActiveEffectTypes.FortuneTellerChoice:
                player = GameManager.instance.GetPlayer();
                player.FortuneTeller(card);
                break;
            default:
                throw new Exception("Not a valid phase to choose a card with.");
        }

        RefreshEffectManager();
        GameManager.instance.uiManager.RefreshUI();
    }

    public void SetDivinateMode(List<Card> cards, int playerId)
    {
        ActiveEffect = ActiveEffectTypes.Divinate;
        GameManager.instance.uiManager.ShowDivinateDisplay(cards);
        SelectedValue = playerId;
    }

    public void Divinate(List<Card> topCards, List<Card> bottomCards)
    {
        var player = GameManager.instance.GetPlayer(SelectedValue.Value);
        player.Divinate(topCards, bottomCards);

        RefreshEffectManager();
        GameManager.instance.uiManager.RefreshUI();
    }

    public void SetAlterFateMode(List<Card> handCards, List<Card> deckCards)
    {
        ActiveEffect = ActiveEffectTypes.AlterFateChoice;
        GameManager.instance.uiManager.ShowAlterFateDisplay(handCards, deckCards);
    }

    public void AlterFate(List<Card> handCards, List<Card> deckCards, List<bool> isSwapped)
    {
        var player = GameManager.instance.GetPlayer();
        player.AlterFate(handCards, deckCards, isSwapped);

        RefreshEffectManager();
        GameManager.instance.uiManager.RefreshUI();
    }

    public void SetMindControlMode(bool isActivePlayer, bool isTemporary)
    {
        ActiveEffect = ActiveEffectTypes.MindControl;
        SelectedBoolean = isTemporary;
        SelectedValue = GameManager.instance.GetPlayer(isActivePlayer).Id;
    }

    public void MindControlUnit(Unit unit)
    {
        var newOwner = GameManager.instance.GetPlayer(SelectedValue.Value);

        if (unit.Owner != newOwner && !unit.IsHero)
        {
            unit.SwitchOwner(newOwner, SelectedBoolean.Value);
        }
    }

    public void SetUnitRecruitMode()
    {
        ActiveEffect = ActiveEffectTypes.Recruit;
    }

    public void RecruitUnit(Unit unit)
    {
        var player = GameManager.instance.GetPlayer();

        if (unit.Owner.Id != player.Id && !unit.IsHero)
        {
            RemoveUnit(unit);
            unit.InitCard(unit.CardData, unit.Owner);
            player.RecruitCard(unit, false);
            GameManager.instance.uiManager.RefreshUI();
        }
    }

    public void RecruitTopOfDeck()
    {
        var inactivePlayer = GameManager.instance.GetPlayer(false);

        var topOfDeck = inactivePlayer.Deck.List.LastOrDefault();
        GameManager.instance.GetPlayer().RecruitCard(topOfDeck);
        GameManager.instance.uiManager.RefreshUI();
    }

    public void SetSpymasterLurenSourceMode(int numToRecruit)
    {
        var activePlayer = GameManager.instance.GetPlayer();

        if (activePlayer.UsedResources.Contains(CardResources.Gold))
        {
            ActiveEffect = ActiveEffectTypes.SpymasterLurenSource;

            SelectedValue = numToRecruit;
        }
    }

    public void SpymasterLurenEffect(Unit sourceUnit)
    {
        if (!sourceUnit.SpymasterLurenCards.Any() && !sourceUnit.IsHero)
        {
            var activePlayer = GameManager.instance.GetPlayer();
            var inActivePlayer = GameManager.instance.GetPlayer(false);

            if (activePlayer.UsedResources.Contains(CardResources.Gold))
            {
                var numToRecruit = Mathf.Min(activePlayer.Hand.CardsToFull, SelectedValue.Value);

                var recruitCards = inActivePlayer.Hand.GetRandomCards(numToRecruit);
                foreach (var recruitCard in recruitCards)
                {
                    var newCopy = GameManager.instance.libraryManager.CreateCard(recruitCard.CardData, recruitCard.Owner);
                    newCopy.CopyCardStats(recruitCard);
                    inActivePlayer.Hand.RemoveCard(recruitCard);
                    activePlayer.RecruitCard(newCopy, false);
                    newCopy.SpyMasterLurenCard = recruitCard;
                    newCopy.SpymasterLurenSource = sourceUnit;
                    sourceUnit.SpymasterLurenCards.Add(newCopy);
                }

                GameManager.instance.uiManager.RefreshUI();
            }

            RefreshEffectManager();
        }
    }

    public void ReturnLurenCards(Unit sourceUnit = null, Card playedCard = null)
    {
        var activePlayer = GameManager.instance.GetPlayer();
        var inActivePlayer = GameManager.instance.GetPlayer(false);

        if (sourceUnit == null && playedCard != null)
        {
            sourceUnit = playedCard.SpymasterLurenSource;
        }
        else if (sourceUnit == null)
        {
            throw new Exception("Cannot return Luren cards as inputs do not match");
        }

        var cardList = sourceUnit.SpymasterLurenCards;
        if (cardList.Any())
        {
            if (playedCard != null)
                cardList.Remove(playedCard);

            foreach (var card in cardList)
            {
                activePlayer.Hand.RemoveCard(card);
                inActivePlayer.AddToHand(card.SpyMasterLurenCard);
            }

            sourceUnit.SpymasterLurenCards = new List<Card>();
            GameManager.instance.uiManager.RefreshUI();
        }
        else
        {
            throw new Exception("No valid cards to return from the source unit");
        }
    }

    public void SetMadnessMode()
    {
        ActiveEffect = ActiveEffectTypes.Madness;
    }

    public void TriggerMadness(Unit unit)
    {
        unit.TriggerMadness();
    }

    public void SetReturnToHandMode()
    {
        ActiveEffect = ActiveEffectTypes.ReturnToHand;
    }

    public void ReturnToHand(Unit unit)
    {
        unit.ReturnToHand();
        GameManager.instance.uiManager.RefreshUI();
    }

    public void SetRedeployMode()
    {
        ActiveEffect = ActiveEffectTypes.Redeploy;
    }

    public void Redeploy(Unit unit)
    {
        unit.Redeploy();
    }

    public void SetTileStatusMode(TileStatuses tileStatus)
    {
        ActiveEffect = ActiveEffectTypes.TileStatus;
        SelectedTileStatus = tileStatus;
    }

    public void AddTileStatus(Cell cell)
    {
        var activePlayer = GameManager.instance.GetPlayer();
        cell.AddTileStatus(SelectedTileStatus, activePlayer.Id);
    }

    public bool SetTransformMode(string unitName, bool isPermanent)
    {
        SelectedCardData = GameManager.instance.libraryManager.GetCard(unitName);
        if (SelectedCardData == null)
            return false;

        ActiveEffect = ActiveEffectTypes.Transform;

        SelectedBoolean = isPermanent;

        return true;
    }

    public void TransformUnit(Cell currentCell, Unit unit)
    {
        if (!unit.HasStatusEffect(Unit.StatusEffects.Transformed))
        {
            if (!SelectedBoolean.Value || SelectedBoolean.Value && !unit.IsHero)
            {
                unit.RemoveUnit();

                var transformUnit = (Unit)GameManager.instance.libraryManager.CreateCard(SelectedCardData, unit.Owner);
                CreateUnitCounter(transformUnit, currentCell);
                var newFormCanAction = unit.CanAction && unit.RemainingSpeed == unit.GetStat(Unit.StatTypes.Speed);
                transformUnit.Transform(newFormCanAction, SelectedBoolean.Value ? null : unit);
            }
        }
    }

    public void SetImmuneMode()
    {
        ActiveEffect = ActiveEffectTypes.ImmuneUnit;
    }

    public void ImmuneUnit(Unit unit)
    {
        unit.ImmuneUnit();
    }

    public void SetIndestructibleMode()
    {
        ActiveEffect = ActiveEffectTypes.IndestructibleUnit;
    }

    public void IndestructibleUnit(Unit unit)
    {
        unit.IndestructibleUnit();
    }

    public void SetConfiscateMode()
    {
        ActiveEffect = ActiveEffectTypes.Confiscate;
    }

    public void Confiscate(Unit unit)
    {
        if (unit.Owner.IsActivePlayer)
        {
            var inactivePlayer = GameManager.instance.GetPlayer(false);
            var confiscateCard = inactivePlayer.Hand.GetRandomCard();

            unit.CaptureCard(confiscateCard);

            RefreshEffectManager();
            GameManager.instance.uiManager.RefreshUI();
        }
    }

    public void SetImprisonMode()
    {
        ActiveEffect = ActiveEffectTypes.SelectImprisonCaster;
    }

    public void SetImprisonCaster(Unit unit)
    {
        if (unit.Owner.IsActivePlayer)
        {
            ActiveEffect = ActiveEffectTypes.Imprison;

            SelectedUnit = unit;
            SelectedUnit.UnitCounter.ShowUnitSelector(true);
        }
    }

    public void Imprison(Unit unit)
    {
        if (!unit.Owner.IsActivePlayer)
        {
            if (!unit.IsHero)
            {
                SelectedUnit.CaptureCard(imprisonedUnit: unit);

                RefreshEffectManager();
                GameManager.instance.uiManager.RefreshUI();
            }
        }
    }

    public bool AddPassive(Passive passive, int? playerId = null)
    {
        var activePlayer = GameManager.instance.GetPlayer(playerId);

        var success = activePlayer.AddPassive(passive);
        GameManager.instance.uiManager.RefreshUI();

        return success;
    }
}
