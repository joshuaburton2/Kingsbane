using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CategoryEnums
{
    public enum IntValueFilter
    {
        None,
        [Description("Highest")]
        IsHighest,
        [Description("Higher Than")]
        HigherThan,
        [Description("Equal")]
        Equal,
        [Description("Lower Than")]
        LowerThan,
        [Description("Lowest")]
        IsLowest,
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

            else if (intFilter.Key == IntValueFilter.IsHighest)
                return true;

            else if (intFilter.Key == IntValueFilter.IsLowest)
                return true;

            else
                throw new Exception("Not a valid filter type");
        }
    }
}

