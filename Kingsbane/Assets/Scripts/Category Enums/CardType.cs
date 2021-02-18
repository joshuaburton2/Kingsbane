using System.ComponentModel;

namespace CategoryEnums
{
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
