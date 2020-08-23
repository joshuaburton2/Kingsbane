using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Card
{
    public ItemData itemData { get { return cardData as ItemData; } }

    public string ItemTag { get { return itemData.ItemTag; } }
    public int Durability { get { return itemData.Durability; } }

    public override void Play()
    {
        base.Play();
    }
}
