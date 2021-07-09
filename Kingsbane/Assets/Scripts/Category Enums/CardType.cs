using System.ComponentModel;

namespace CategoryEnums
{
    /// <summary>
    /// 
    /// The different types of cards in the game
    /// 
    /// </summary>
    public enum CardTypes
    {
        [Description("Default")]
        Default,
        [Description("Unit")]
        Unit,
        [Description("Spell")]
        Spell,
        [Description("Item")]
        Item
    }
}
