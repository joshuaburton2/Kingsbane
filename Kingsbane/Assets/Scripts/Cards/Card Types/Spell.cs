using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Card
{
    public string SpellType { get; private set; }
    public int SpellRange { get; private set; }

    public override void Play()
    {
        base.Play();
    }
}
