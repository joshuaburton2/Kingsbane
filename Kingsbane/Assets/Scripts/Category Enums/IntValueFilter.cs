using System.Collections.Generic;

namespace CategoryEnums
{
    public enum IntValueFilter
    {
        IsHighest,
        HigherThan,
        Equal,
        LowerThan,
        IsLowest,
    }

    public static class IntValueFilterer
    {
        public static void CheckIntValueFilter(int intValue, Dictionary<IntValueFilter, int> intFilter)
        {

        }
    }
}

