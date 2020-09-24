using System;

/// <summary>
/// 
/// Object for storing unique data for spell cards
/// 
/// </summary>
[Serializable]
public class SpellData : CardData
{
    public string SpellType { get; set; }
    public int Range { get; set; }
}
