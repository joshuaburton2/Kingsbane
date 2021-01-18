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

    public void DestroyItem()
    {
        Owner.Hero.DestroyItem(this);
    }
}
