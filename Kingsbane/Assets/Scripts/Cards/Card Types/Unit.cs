using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card
{
    public UnitData UnitData { get { return cardData as UnitData; } }

    public int Attack { get { return UnitData.Attack; } }
    public int Health { get { return UnitData.Health; } }
    public int Range { get { return UnitData.Range; } }
    public int Speed { get { return UnitData.Speed; } }

    public string UnitTag { get { return UnitData.UnitTag; } }

    public List<AbilityData> Abilities { get { return UnitData.Abilities; } }

    public override void Play()
    {
        base.Play();
    }
}
