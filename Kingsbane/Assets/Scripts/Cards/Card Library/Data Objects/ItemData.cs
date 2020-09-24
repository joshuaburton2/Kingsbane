using System;

/// <summary>
/// 
/// Object for storing unique data for item cards
/// 
/// </summary>
[Serializable]
public class ItemData : CardData
{
    public string ItemTag;

    public int Durability;
}
