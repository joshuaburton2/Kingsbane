using CategoryEnums;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public static Dictionary<Tags, TierLevel> TierConversion = new Dictionary<Tags, TierLevel>
        {
            { Tags.HeroTierOne, TierLevel.Tier1 },
            { Tags.HeroTierTwo, TierLevel.Tier2 },
            { Tags.HeroTierThree, TierLevel.Tier3 },
        };

        public static TierLevel ConvertTierLevel (CardData card)
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
