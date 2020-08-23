using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card
{
    public UnitData unitData { get { return cardData as UnitData; } }

    public int Attack { get { return unitData.Attack; } }
    public int Health { get { return unitData.Health; } }
    public int Range { get { return unitData.Range; } }
    public int Speed { get { return unitData.Speed; } }

    public string UnitTag { get { return unitData.UnitTag; } }

    public override void Play()
    {
        base.Play();
    }
}
