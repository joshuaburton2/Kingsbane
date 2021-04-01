﻿using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public enum ActiveEffectTypes
    {
        None,
        Deployment,
        ForceDeployment,
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
    }

    public ActiveEffectTypes ActiveEffect { get; set; }
    public bool IsUILocked { get { return ActiveEffect != ActiveEffectTypes.None && ActiveEffect != ActiveEffectTypes.UnitCommand; } }
    public bool CancelEffect { get; set; }

    private readonly List<ActiveEffectTypes> NonCancelableEffects = new List<ActiveEffectTypes>()
    {
        ActiveEffectTypes.None,
        ActiveEffectTypes.UnitCommand,
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
    };

    private Card SelectedCard { get; set; }
    private Unit CommandUnit { get; set; }
    private List<Unit> DeployUnits { get; set; }
    private Item SelectedItem { get; set; }
    private Ability SelectedAbility { get; set; }
    private UnitEnchantment SelectedEnchantment { get; set; }
    private int? SelectedValue { get; set; }
    private bool? SelectedBoolean { get; set; }
    private string SelectedString { get; set; }
    private DeckPositions? SelectedDeckPosition { get; set; }
    private List<Keywords> SelectedKeywords { get; set; }
    private CardResources? SelectedResource { get; set; }

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
        if (!NonCancelableEffects.Contains(ActiveEffect))
        {
            CancelEffect = true;
            RefreshEffectManager();
        }
    }

    public void RefreshEffectManager(bool fullReset = false)
    {
        if (fullReset)
            ActiveEffect = ActiveEffectTypes.None;

        SelectedEnchantment = null;
        SelectedAbility = null;
        SelectedValue = null;
        SelectedBoolean = null;
        SelectedString = null;
        SelectedDeckPosition = null;
        SelectedKeywords = new List<Keywords>();
        SelectedResource = null;

        switch (ActiveEffect)
        {
            default:
                ActiveEffect = ActiveEffectTypes.None;

                SelectedCard = null;
                CommandUnit = null;
                DeployUnits = new List<Unit>();
                SelectedItem = null;

                break;
            case ActiveEffectTypes.Deployment:
            case ActiveEffectTypes.ForceDeployment:
                SelectedCard = null;
                CommandUnit = null;

                if (DeployUnits.Count == 0 || CancelEffect)
                {
                    ActiveEffect = ActiveEffectTypes.None;
                    GameManager.instance.uiManager.ShowMapKeyOfType();
                }
                break;
            case ActiveEffectTypes.Equip:
            case ActiveEffectTypes.ForceEquip:
                SelectedCard = null;
                CommandUnit = null;

                if (SelectedItem == null || CancelEffect)
                    ActiveEffect = ActiveEffectTypes.None;
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
                ActiveEffect = CancelEffect ? ActiveEffectTypes.UnitCommand : ActiveEffectTypes.UnitUseSpeed;
                CancelEffect = false;

                break;
            case ActiveEffectTypes.UnitDisengage:
                ActiveEffect = CancelEffect ? ActiveEffectTypes.UnitCommand : ActiveEffectTypes.UnitUseDisengageSpeed;
                CancelEffect = false;

                break;
            case ActiveEffectTypes.UnitUseSpeed:
            case ActiveEffectTypes.UnitUseDisengageSpeed:
                if (CancelEffect)
                {
                    MoveCommandUnit(PreviousCell);
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
                ActiveEffect = ActiveEffectTypes.Spell;
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
    }

    public void SetDeployUnits(List<Unit> _selectedUnits, bool isForced = false)
    {
        GameManager.instance.uiManager.ShowMapKeyOfType(MapGrid.MapFilters.Deployment);
        DeployUnits = _selectedUnits;
        ActiveEffect = isForced ? ActiveEffectTypes.ForceDeployment : ActiveEffectTypes.Deployment;
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
            return CreateUnitCounter(DeployUnits.FirstOrDefault(), cell);
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

            DeployUnits.Remove(unit);

            GameManager.instance.CheckWarden();

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
            GameManager.instance.uiManager.ShowMapKeyOfType(MapGrid.MapFilters.Terrain);
        }
    }

    public void SetDisengageUnitMode(Cell currentCell)
    {
        if (ActiveEffect == ActiveEffectTypes.UnitCommand)
        {
            ActiveEffect = ActiveEffectTypes.UnitDisengage;
            PreviousCell = currentCell;
            GameManager.instance.uiManager.ShowMapKeyOfType(MapGrid.MapFilters.Terrain);
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

    public void MoveCommandUnit(Cell newCell)
    {
        if (ActiveEffect == ActiveEffectTypes.UnitMove ||
            ActiveEffect == ActiveEffectTypes.UnitDisengage ||
            ActiveEffect == ActiveEffectTypes.UnitForceMove ||
            ActiveEffect == ActiveEffectTypes.UnitUseSpeed ||
            ActiveEffect == ActiveEffectTypes.UnitUseDisengageSpeed)
        {
            if (newCell.occupantCounter == null)
            {
                if (CommandUnit.CheckOccupancy(newCell) || ActiveEffect == ActiveEffectTypes.UnitForceMove)
                {
                    RemoveUnit(CommandUnit.UnitCounter);
                    CreateUnitCounter(CommandUnit, newCell, false);
                    GameManager.instance.uiManager.RefreshUI();
                }
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
            if (CommandUnit.Owner.Id != targetUnit.Owner.Id)
            {
                CommandUnit.TriggerAttack(targetUnit);
                RefreshEffectManager();
                GameManager.instance.uiManager.RefreshUI();
            }
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
        CommandUnit.UseAbility(SelectedAbility);
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

    public void EquipItem(Item itemToReplace, int itemAreaPlayerId)
    {
        if (SelectedItem != null)
        {
            if (SelectedItem.Owner.Id == itemAreaPlayerId)
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

        if (unitCounter.Unit == CommandUnit &&
            ActiveEffect != ActiveEffectTypes.UnitMove &&
            ActiveEffect != ActiveEffectTypes.UnitForceMove &&
            ActiveEffect != ActiveEffectTypes.UnitUseSpeed &&
            ActiveEffect != ActiveEffectTypes.UnitDisengage &&
            ActiveEffect != ActiveEffectTypes.UnitUseDisengageSpeed)
        {
            CommandUnit = null;
            GameManager.instance.uiManager.RefreshUI();
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

    public void SetCommandUnit(Unit _selectedUnit)
    {
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
        {
            CommandUnit = _selectedUnit;
        }
        ActiveEffect = ActiveEffectTypes.UnitCommand;
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
            unit.DamageUnit(GameManager.instance.GetActivePlayer(), SelectedValue.Value, SelectedKeywords);
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

    public void SetProtectedMode(int? protectedValue, bool isTemporary)
    {
        SelectedValue = protectedValue;
        SelectedBoolean = isTemporary;
        ActiveEffect = ActiveEffectTypes.Protected;
    }

    public void ProtectUnit(Unit unit)
    {
        unit.AddProtected(SelectedValue, SelectedBoolean.Value);
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

    public void SetModifyCostMode(int value, CardResources? resource)
    {
        ActiveEffect = ActiveEffectTypes.ModifyCost;

        SelectedValue = value;
        SelectedResource = resource;
    }

    public void ModifyCost(Card card)
    {
        var canModify = card.ModifyCost(SelectedValue.Value, SelectedResource);
        if (!canModify)
            Debug.Log("Cannot modify cost of card");
    }

    public void ModifyCostOfTargetCards(int value, CardTypes cardType, CardResources? resource)
    {
        var player = GameManager.instance.GetActivePlayer();

        foreach (var card in player.Hand.cardList.Where(x => x.Type == cardType))
            card.ModifyCost(value, resource);

        foreach (var card in player.Deck.cardList.Where(x => x.Type == cardType))
            card.ModifyCost(value, resource);

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

        CancelEffect = true;
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

        if (unit.Owner != newOwner && unit.Rarity != Rarity.Hero && unit.Rarity != Rarity.NPCHero)
        {
            unit.SwitchOwner(newOwner, SelectedBoolean.Value);
        }
    }
}
