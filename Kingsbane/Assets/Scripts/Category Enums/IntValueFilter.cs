using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace CategoryEnums
{
    public enum IntValueFilter
    {
        None,
        [Description("Highest")]
        Highest,
        [Description("Higher Than")]
        HigherThan,
        [Description("Equal")]
        Equal,
        [Description("Lower Than")]
        LowerThan,
        [Description("Lowest")]
        Lowest,
    }

    public static class IntValueFilterer
    {
        public static bool CheckIntValueFilter(int intValue, KeyValuePair<IntValueFilter, int?> intFilter)
        {
            if (intFilter.Key == IntValueFilter.HigherThan)
                return intValue >= intFilter.Value;

            else if (intFilter.Key == IntValueFilter.Equal)
                return intValue == intFilter.Value;

            else if (intFilter.Key == IntValueFilter.LowerThan)
                return intValue <= intFilter.Value;

            else if (intFilter.Key == IntValueFilter.Highest)
                return true;

            else if (intFilter.Key == IntValueFilter.Lowest)
                return true;

            else
                throw new Exception("Not a valid filter type");
        }
    }
}

