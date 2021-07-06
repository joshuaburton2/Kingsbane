using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    public int ItemCapacity { get; set; }
    public List<Item> EquippedItems { get; set; }
    public bool? ActiveMagisFury { get; set; }

    public override void InitCard(CardData _cardData, Player owner)
    {
        base.InitCard(_cardData, owner);

        ItemCapacity = owner.ItemCapacity;
        EquippedItems = new List<Item>();
    }

    /// <summary>
    /// 
    /// Equips the given item to the hero
    /// 
    /// </summary>
    /// <param name="item"></param>
    public void EquipItem(Item item)
    {
        if (EquippedItems.Count < ItemCapacity)
        {
            EquippedItems.Add(item);
        }
        else
        {
            throw new Exception("Too many items equipped");
        }
    }

    /// <summary>
    /// 
    /// Destroys an item already equipped to the hero
    /// 
    /// </summary>
    public void DestroyItem(Item item)
    {
        if (EquippedItems.Contains(item))
        {
            EquippedItems.Remove(item);
            Owner.AddToGraveyard(item);
        }
        else
        {
            throw new Exception("Item to be destroyed is not currently equipped");
        }
    }
}
