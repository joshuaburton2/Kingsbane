using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Card
{
    public ItemData ItemData { get { return CardData as ItemData; } }

    public string ItemTag { get { return ItemData.ItemTag; } }
    public int Durability { get { return ItemData.Durability; } }
    public int CurrentDurability { get; set; }
    public bool IsEquipped { get { return Owner.Hero.EquippedItems.Contains(this); } }
    public string ItemNotes { get; set; }

    public override void InitCard(CardData _cardData, Player owner)
    {
        base.InitCard(_cardData, owner);

        CurrentDurability = Durability;
    }

    /// <summary>
    /// 
    /// Plays the item from your hand
    /// 
    /// </summary>
    public override void Play()
    {
        base.Play();

        Equip();
    }

    /// <summary>
    /// 
    /// Equips the item to the player's hero
    /// 
    /// </summary>
    public void Equip()
    {
        Owner.Hero.EquipItem(this);

        ItemNotes = "";
    }

    /// <summary>
    /// 
    /// Modifies the equipped items durability
    /// 
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public bool ModifyDurability(int modifier)
    {
        CurrentDurability += modifier;

        if (CurrentDurability <= 0)
        {
            DestroyItem();
            return true;
        }

        return false;
    }

    /// <summary>
    /// 
    /// Edits an items durability, either by modifying or setting it. To be used when item is not equipped
    /// 
    /// </summary>
    /// <param name="durabilityChange"></param>
    public void EditDurability(KeyValuePair<StatModifierTypes, int> durabilityChange)
    {
        if (!IsEquipped)
        {
            var durabilityValue = durabilityChange.Value;

            switch (durabilityChange.Key)
            {
                case StatModifierTypes.Modify:
                    //Cannot modify durability below 0
                    if (CurrentDurability + durabilityValue <= 0)
                        CurrentDurability = 1;
                    else
                        ModifyDurability(durabilityValue);
                    break;
                case StatModifierTypes.Set:
                    //Cannot set durability below 0
                    if (durabilityValue <= 0)
                        durabilityValue = 1;
                    CurrentDurability = durabilityValue;
                    break;
                default:
                    throw new Exception("Not a valid stat modifier type");
            }
        }
        else
        {
            throw new Exception("Cannot edit durability of an equipped item");
        }
    }

    /// <summary>
    /// 
    /// Destroys an equipped item
    /// 
    /// </summary>
    public void DestroyItem()
    {
        Owner.Hero.DestroyItem(this);
        ItemNotes = "";
    }
}
