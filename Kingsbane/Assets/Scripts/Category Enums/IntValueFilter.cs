using System;
using System.Collections.Generic;
using System.Linq;

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
        public static bool CheckIntValueFilter(int intValue, List<int> valueList, Dictionary<IntValueFilter, int> intFilter)
        {
            if (intFilter.Count > 1)
            {
                var filterOption = intFilter.FirstOrDefault();

                if (filterOption.Key == IntValueFilter.HigherThan)
                    return intValue >= filterOption.Value;

                else if (filterOption.Key == IntValueFilter.Equal)
                    return intValue == filterOption.Value;

                else if (filterOption.Key == IntValueFilter.LowerThan)
                    return intValue <= filterOption.Value;

                else
                    throw new Exception("Not a valid filter type");

            }
            else
            {
                throw new Exception("Not a valid integer filter");
            }
        }
    }
}

