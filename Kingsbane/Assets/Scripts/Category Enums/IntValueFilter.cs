using System;
using System.Collections.Generic;
using System.Linq;

namespace CategoryEnums
{
    public enum IntValueFilter
    {
        None,
        IsHighest,
        HigherThan,
        Equal,
        LowerThan,
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

