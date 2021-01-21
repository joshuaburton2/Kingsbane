using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;

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

    public string UnitTag { get { return UnitData.UnitTag; } }

    public List<AbilityData> Abilities { get { return UnitData.Abilities; } }

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
            else if(GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            {
                Status = UnitStatuses.Start;

                RemainingSpeed = Speed;
                ActionsLeft = 1;
                AbilityUsesLeft = 1;
            }
        }
        else
        {
            Status = UnitStatuses.Enemy;
        }
    }
}
