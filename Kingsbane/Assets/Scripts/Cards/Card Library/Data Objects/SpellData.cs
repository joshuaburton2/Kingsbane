using System;

[Serializable]
public class SpellData : CardData
{
    public string SpellType { get; set; }
    public int Range { get; set; }
}
