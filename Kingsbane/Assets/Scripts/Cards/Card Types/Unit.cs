using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Card
{
    public int Attack { get; private set; }
    public int Health { get; private set; }
    public int Range { get; private set; }
    public int Speed { get; private set; }

    public string UnitTag { get; private set; }

    public override void Play()
    {

    }
}
