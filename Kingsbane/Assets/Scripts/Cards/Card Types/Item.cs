using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Card
{
    public ItemData ItemData { get { return cardData as ItemData; } }

    public string ItemTag { get { return ItemData.ItemTag; } }
    public int Durability { get { return ItemData.Durability; } }
    public int CurrentDurability { get; set; }

    public override void InitCard(CardData _cardData, Player owner)
    {
        base.InitCard(_cardData, owner);

        CurrentDurability = Durability;
    }

    public override void Play()
    {
        base.Play();

        Equip();
    }

    public void Equip()
    {
        Owner.Hero.EquipItem(this);
    }

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

    public void EditDurability(KeyValuePair<StatModifierTypes, int> durabilityChange)
    {
        var durabilityValue = durabilityChange.Value;

        switch (durabilityChange.Key)
        {
            case StatModifierTypes.Modify:

                if (CurrentDurability + durabilityValue <= 0)
                    CurrentDurability = 1;
                else
                    ModifyDurability(durabilityValue);
                break;
            case StatModifierTypes.Set:
                if (durabilityValue <= 0)
                    durabilityValue = 1;
                CurrentDurability = durabilityValue;
                break;
            default:
                throw new Exception("Not a valid stat modifier type");
        }
    }

    public void DestroyItem()
    {
        Owner.Hero.DestroyItem(this);
    }
}
