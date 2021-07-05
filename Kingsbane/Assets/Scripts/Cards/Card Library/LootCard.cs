using System;

/// <summary>
/// 
/// Save object for storing loot card properties. Required as cannot save Carddata on Loot Card object
/// 
/// </summary>
[Serializable]
public class SaveLootCard
{
    public int CardId { get; set; }
    public int Weighting { get; set; }

    /// <summary>
    /// 
    /// Convers the object to a loot card object
    /// 
    /// </summary>
    /// <returns></returns>
    public LootCard ConvertToLootCard()
    {
        return new LootCard()
        {
            CardData = GameManager.instance.libraryManager.GetCard(CardId),
            Weighting = Weighting,
        };
    }
}

/// <summary>
/// 
/// Object for storing loot card properties
/// 
/// </summary>
public class LootCard
{
    public CardData CardData { get; set; }
    public int Weighting { get; set; }

    /// <summary>
    /// 
    /// Converts the object to a loot card object which can be saved
    /// 
    /// </summary>
    /// <returns></returns>
    public SaveLootCard ConvertToSaveLootCard()
    {
        return new SaveLootCard()
        {
            CardId = CardData.Id.Value,
            Weighting = Weighting,
        };
    }
}