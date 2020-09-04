using CategoryEnums;

namespace Assets.Scripts.Category_Enums
{
    public enum TierLevel
    {
        Tier1,
        Tier2,
        Tier3
    }

    public class HeroTier
    {
        public Classes.ClassList heroClass;
        public TierLevel tierLevel;
    }
}
