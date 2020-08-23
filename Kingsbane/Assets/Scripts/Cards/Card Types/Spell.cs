using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Card
{
    public SpellData spellData { get { return cardData as SpellData; } }

    public string SpellType { get { return spellData.SpellType; } }
    public int SpellRange { get { return spellData.Range; } }

    public override void Play()
    {
        base.Play();
    }
}
