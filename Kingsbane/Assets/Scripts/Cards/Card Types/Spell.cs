using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Card
{
    public SpellData SpellData { get { return cardData as SpellData; } }

    public string SpellType { get { return SpellData.SpellType; } }
    public int SpellRange { get { return SpellData.Range; } }

    public override void Play()
    {
        base.Play();
    }
}
