using System.Collections.Generic;

// Pregenerated code- do not edit
namespace CategoryEnums
{
    /// <summary>
    ///
    /// List of Keywords which can be applied to units
    ///
    /// </summary>
    public enum Keywords
    {
        Conduit,
        Deadly,
        Ethereal,
        Flying,
        Lifebond,
        Overwhelm,
        Prepared,
        Routing,
        Spellshield,
        Stalker,
        Stealth,
        Summon,
        Swiftstrike,
        Unleash,
        Vanguard,
        Warden,
        Piercing,
        SpecialSwiftstrike,
        Structure,
        Token,
    }

    public static class KeywordProperties
    {
        /// <summary>
        ///
        /// Gets the description of a given keyword
        ///
        /// </summary>
        public static string GetResoourceDescription(Keywords keyword)
        {
            KeywordDescriptions.TryGetValue(keyword, out string description);
            return description;
        }

        private static Dictionary<Keywords, string> KeywordDescriptions = new Dictionary<Keywords, string>()
        {
            { Keywords.Conduit, @"" },

            { Keywords.Deadly, @" " },

            { Keywords.Ethereal, @" " },

            { Keywords.Flying, @" " },

            { Keywords.Lifebond, @" " },

            { Keywords.Overwhelm, @" " },

            { Keywords.Prepared, @" " },

            { Keywords.Routing, @" " },

            { Keywords.Spellshield, @" " },

            { Keywords.Stalker, @" " },

            { Keywords.Stealth, @" " },

            { Keywords.Summon, @" " },

            { Keywords.Swiftstrike, @" " },

            { Keywords.Unleash, @" " },

            { Keywords.Vanguard, @" " },

            { Keywords.Warden, @" " },

            { Keywords.Piercing, @" " },

            { Keywords.SpecialSwiftstrike, @" " },

            { Keywords.Structure, @" " },

            { Keywords.Token, @" " },

        };
    }
}
