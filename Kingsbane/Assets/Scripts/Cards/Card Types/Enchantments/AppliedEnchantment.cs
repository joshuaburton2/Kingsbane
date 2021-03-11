public class AppliedEnchantment
{
    public UnitEnchantment Enchantment { get; set; }
    public bool IsApplied { get; set; }
    public bool IsActive { get; set; }

    public AppliedEnchantment()
    {
        Enchantment = null;
        IsApplied = false;
        IsActive = true;
    }
}
