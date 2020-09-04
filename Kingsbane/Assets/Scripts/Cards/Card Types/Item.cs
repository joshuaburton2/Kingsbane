using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Card
{
    public ItemData ItemData { get { return cardData as ItemData; } }

    public string ItemTag { get { return ItemData.ItemTag; } }
    public int Durability { get { return ItemData.Durability; } }

    public override void Play()
    {
        base.Play();
    }
}
