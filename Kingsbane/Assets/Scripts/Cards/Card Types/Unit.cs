using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;
using System;
using System.Linq;

public class Unit : Card
{
    public enum UnitStatuses //The possible statuses of the unit
    {
        Start, //Status for start of turn
        Preparing, //Status for just played
        Middle, //Status for still actions, movement or abilities to use
        Finished, //Status for all actions spent
        Enemy, //Status for enemy cards
    }

    public UnitData UnitData { get { return cardData as UnitData; } }

    public int DefaultAttack { get { return UnitData.Attack; } }
    public int DefaultHealth { get { return UnitData.Health; } }
    public int DefaultRange { get { return UnitData.Range; } }
    public int DefaultSpeed { get { return UnitData.Speed; } }

    public int BaseAttack { get; set; }
    public int BaseHealth { get; set; }
    public int BaseRange { get; set; }
    public int BaseSpeed { get; set; }

    public int Attack { get; set; }
    public int Health { get; set; }
    public int Range { get; set; }
    public int Speed { get; set; }


    public StatModTypes HasBuffedAttack { get { return Attack > BaseAttack ? StatModTypes.Buffed : StatModTypes.None; } }
    public StatModTypes UnitIsDamaged { get { return Health < BaseHealth ? StatModTypes.Damaged : StatModTypes.None; } }
    public StatModTypes HasBuffedRange { get { return Range > BaseRange ? StatModTypes.Buffed : StatModTypes.None; } }
    public StatModTypes HasBuffedSpeed { get { return Speed > BaseSpeed ? StatModTypes.Buffed : StatModTypes.None; } }

    public UnitStatuses Status { get; set; }
    public int RemainingSpeed { get; set; }
    public int ActionsLeft { get; set; }
    public int AbilityUsesLeft { get; set; }
    public bool CanMove { get { return ActionsLeft > 0 && RemainingSpeed > 0; } }
    public bool CanAction { get { return ActionsLeft > 0; } }

    public string UnitTag { get { return UnitData.UnitTag; } }

    public List<AbilityData> Abilities { get { return UnitData.Abilities; } }

    public UnitCounter UnitCounter { get; set; }

    public override void InitCard(CardData _cardData, Player owner)
    {
        base.InitCard(_cardData, owner);

        BaseAttack = DefaultAttack;
        BaseHealth = DefaultHealth;
        BaseRange = DefaultRange;
        BaseSpeed = DefaultSpeed;

        Attack = DefaultAttack;
        Health = DefaultHealth;
        Range = DefaultRange;
        Speed = DefaultSpeed;

        Status = UnitStatuses.Preparing;
    }

    public override void Play()
    {
        base.Play();

        Status = UnitStatuses.Preparing;
    }

    public void StartOfTurn(bool isActive)
    {
        if (isActive)
        {
            if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Mulligan)
            {
                Status = UnitStatuses.Preparing;

                RemainingSpeed = 0;
                ActionsLeft = 0;
                AbilityUsesLeft = 0;
            }
            else if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            {
                if (GameManager.instance.CurrentRound != 1)
                {
                    Status = UnitStatuses.Start;

                    RemainingSpeed = Speed;
                    ActionsLeft = 1;
                    AbilityUsesLeft = 1;
                }
                else
                {
                    Status = UnitStatuses.Preparing;
                }
            }
        }
        else
        {
            Status = UnitStatuses.Enemy;
        }
    }

    public void UseSpeed(int usedSpeed)
    {
        if (usedSpeed == 0)
        {
            throw new Exception("Cannot Use 0 Speed");
        }
        else
        {
            RemainingSpeed -= usedSpeed;
            Status = UnitStatuses.Middle;

            UnitCounter.RefreshUnitCounter();
            GameManager.instance.effectManager.RefreshEffectManager();
        }
    }

    public void ModifyActions(int value)
    {
        ActionsLeft += value;
        if (ActionsLeft == 0)
            Status = UnitStatuses.Finished;
        else if(value <= 0)
            Status = UnitStatuses.Middle;

        UnitCounter.RefreshUnitCounter();
    }

    public void TriggerAttack(Unit targetUnit)
    {
        ModifyActions(-1);

        targetUnit.DamageUnit(Attack);
        if (Range == 0)
            DamageUnit(targetUnit.Attack);

        UnitCounter.RefreshUnitCounter();
        targetUnit.UnitCounter.RefreshUnitCounter();
    }

    public void DamageUnit(int damageValue)
    {
        Health -= damageValue;

        if (Health <= 0)
        {
            DestroyUnit();
        }
    }

    public void DestroyUnit()
    {
        GameManager.instance.effectManager.RemoveUnit(UnitCounter);
        Owner.AddToGraveyard(this);

        UnitCounter.Cell.gameplayUI.RefreshPlayerBar(Owner.Id);
    }

    public bool CanUseAbility(AbilityData ability)
    {
        var canSpendResources = Resource.CanSpendResources(Owner, ability.Resources);
        var canSpendAction = ability.CostsAction ? CanAction : true;
        var canUseability = AbilityUsesLeft > 0;

        return canSpendResources && canSpendAction && canUseability;
    }

    public void ModifyAbilities(int value)
    {
        AbilityUsesLeft += value;
    }

    public void UseAbility(AbilityData ability)
    {
        Owner.ModifyResources(ability.Resources.Select(x => new Resource(x.ResourceType, x.Value * -1)).ToList());

        ModifyAbilities(-1);
        ModifyActions(ability.CostsAction ? -1 : 0);

        UnitCounter.RefreshUnitCounter();
    }
}
