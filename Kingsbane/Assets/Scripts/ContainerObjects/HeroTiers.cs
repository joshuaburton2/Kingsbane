using System.Collections.Generic;
using System.Linq;
using System;

namespace CategoryEnums
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

        private static Dictionary<Tags, TierLevel> TierConversion = new Dictionary<Tags, TierLevel>
        {
            { Tags.HeroTierOne, TierLevel.Tier1 },
            { Tags.HeroTierTwo, TierLevel.Tier2 },
            { Tags.HeroTierThree, TierLevel.Tier3 },
        };

        /// <summary>
        /// 
        /// Used for comparing Hero Tiers when used as dictionary key
        /// 
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is HeroTier)) 
                return false;
            return ((HeroTier)obj).heroClass == heroClass && ((HeroTier)obj).tierLevel == tierLevel;
        }

        /// <summary>
        /// 
        /// Used for comparing Hero Tiers when used as dictionary key
        /// 
        /// </summary>
        public override int GetHashCode()
        {
            return heroClass.GetHashCode() + tierLevel.GetHashCode();
        }

        public static TierLevel ConvertTierLevel (UnitData card)
        {
            if (card.Rarity == Rarity.Hero)
            {
                Tags heroTierTag = card.Tags.FirstOrDefault(x => x == Tags.HeroTierOne || x == Tags.HeroTierTwo || x == Tags.HeroTierThree);
                if (heroTierTag == Tags.Default)
                    throw new Exception("Card does not have a valid Tier Level");

                return TierConversion[heroTierTag];
            }
            else
            {
                throw new Exception("Card is not a hero");
            }
        }
    }
}
