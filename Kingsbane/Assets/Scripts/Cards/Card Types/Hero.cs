using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    public int ItemCapacity { get; set; }
    public List<Item> EquippedItems { get; set; }

    public override void InitCard(CardData _cardData, Player owner)
    {
        base.InitCard(_cardData, owner);

        ItemCapacity = owner.ItemCapacity;
        EquippedItems = new List<Item>();
    }

    public void EquipItem(Item item)
    {
        if (EquippedItems.Count < ItemCapacity)
        {
            EquippedItems.Add(item);
        }
    }

    public void DestroyItem(Item item)
    {
        EquippedItems.Remove(item);
        Owner.AddToGraveyard(item);
    }
}
