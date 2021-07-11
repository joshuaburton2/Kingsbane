/// <summary>
/// 
/// Object for storing an enchantment after it has been applied to a unit
/// 
/// </summary>
public class AppliedEnchantment
{
    public UnitEnchantment Enchantment { get; set; }
    public EnchantmentStatus EnchantmentStatus { get; set; }
    //Tracker for determining if the enchantment has been applied already
    public bool IsApplied { get; set; }
    //Tracker for determining if the enchantment is active (i.e. if it has been spellbound)
    public bool IsActive { get; set; }

    public AppliedEnchantment(UnitEnchantment enchantment)
    {
        Enchantment = enchantment;
        EnchantmentStatus = Enchantment.BaseStatus;
        IsApplied = false;
        IsActive = true;
    }
}
