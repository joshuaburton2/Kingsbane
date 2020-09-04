using System.Collections.Generic;

public class UnitData : CardData
{
    public string UnitTag { get; set; }

    public int Attack { get; set; }
    public int Health { get; set; }
    public int Range { get; set; }
    public int Speed { get; set; }

    public List<AbilityData> Abilities { get; set; }
}
