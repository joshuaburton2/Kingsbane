using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Card
{
    public string ItemTag { get; private set; }
    public int Durability { get; private set; }

    public override void Play()
    {
        base.Play();
    }
}
