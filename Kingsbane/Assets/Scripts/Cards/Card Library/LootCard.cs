using System;

[Serializable]
public class SaveLootCard
{
    public int CardId { get; set; }
    public int Weighting { get; set; }

    public LootCard ConvertToLootCard()
    {
        return new LootCard()
        {
            CardData = GameManager.instance.libraryManager.GetCard(CardId),
            Weighting = Weighting,
        };
    }
}

public class LootCard
{
    public CardData CardData { get; set; }
    public int Weighting { get; set; }

    public SaveLootCard ConvertToSaveLootCard()
    {
        return new SaveLootCard()
        {
            CardId = CardData.Id.Value,
            Weighting = Weighting,
        };
    }
}