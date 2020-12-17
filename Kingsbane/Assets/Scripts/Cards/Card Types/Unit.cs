using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card
{
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
    }

    public override void Play()
    {
        base.Play();
    }
}
