using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card
{
    public UnitData UnitData { get { return cardData as UnitData; } }

    public int BaseAttack { get { return UnitData.Attack; } }
    public int BaseHealth { get { return UnitData.Health; } }
    public int BaseRange { get { return UnitData.Range; } }
    public int BaseSpeed { get { return UnitData.Speed; } }

    public int Attack { get; set; }
    public int Health { get; set; }
    public int Range { get; set; }
    public int Speed { get; set; }

    public string UnitTag { get { return UnitData.UnitTag; } }

    public List<AbilityData> Abilities { get { return UnitData.Abilities; } }

    public override void InitCard(CardData _cardData)
    {
        base.InitCard(_cardData);

        Attack = BaseAttack;
        Health = BaseHealth;
        Range = BaseRange;
        Speed = BaseSpeed;
    }

    public override void Play()
    {
        base.Play();
    }
}
