using CategoryEnums;
using System.Collections.Generic;

public class CardData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageLocation { get; set; }

    public int? ResourceDevotion { get; set; }
    public int? ResourceEnergy { get; set; }
    public int? ResourceGold { get; set; }
    public int? ResourceKnowledge { get; set; }
    public int? ResourceMana { get; set; }
    public int? ResourceWild { get; set; }
    public int? ResourceNeutral { get; set; }

    public string Text { get; set; }
    public string LoreText { get; set; }
    public string Notes { get; set; }

    public Sets Set { get; set; }
    public Classes.ClassList Class { get; set; }
    public Rarity Rarity { get; set; }
    public CardTypes CardType { get; set; }

    public List<Tags> Tags { get; set; }
    public List<Synergies> Synergies { get; set; }
    public List<CardData> RelatedCards { get; set; }
}
