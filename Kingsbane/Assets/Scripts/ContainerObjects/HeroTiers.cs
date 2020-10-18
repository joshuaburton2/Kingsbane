using System.Collections.Generic;
using System.Linq;
using System;

namespace CategoryEnums
{
    [Serializable]
    public class HeroTier
    {
        public Classes.ClassList HeroClass { get; set; }
        public TierLevel TierLevel { get; set; }

        public HeroTier()
        {
            HeroClass = Classes.ClassList.Default;
            TierLevel = TierLevel.Default;
        }

        /// <summary>
        /// 
        /// Dictionary for converting Tier level tag to a tier level
        /// 
        /// </summary>
        private static Dictionary<Tags, TierLevel> TierConversion = new Dictionary<Tags, TierLevel>
        {
            { Tags.HeroTierZero, TierLevel.Tier0 },
            { Tags.HeroTierOne, TierLevel.Tier1 },
            { Tags.HeroTierTwo, TierLevel.Tier2 },
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
            return ((HeroTier)obj).HeroClass == HeroClass && ((HeroTier)obj).TierLevel == TierLevel;
        }

        /// <summary>
        /// 
        /// Used for comparing Hero Tiers when used as dictionary key
        /// 
        /// </summary>
        public override int GetHashCode()
        {
            return HeroClass.GetHashCode() + TierLevel.GetHashCode();
        }

        /// <summary>
        /// 
        /// Determines which hero tier the hero card is. Each hero card should have a valid Tier Level tag
        /// 
        /// </summary>
        public static TierLevel ConvertTierLevel (UnitData card)
        {
            if (card.Rarity == Rarity.Hero)
            {
                Tags heroTierTag = card.Tags.FirstOrDefault(x => x == Tags.HeroTierZero || x == Tags.HeroTierOne || x == Tags.HeroTierTwo);
                //If one of the tier level tags doesn't exist, it will obtain the default tag
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
