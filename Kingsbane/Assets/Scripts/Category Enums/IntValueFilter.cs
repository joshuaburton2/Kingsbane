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
        /// <summary>
        /// 
        /// Determines whether a number compared to another number meets a certain condition
        /// 
        /// </summary>
        /// <param name="intValue">The value to compare to</param>
        /// <param name="intFilter">The description of the comparison. The key is the type of comparison. the int is the value to compare with</param>
        public static bool CheckIntValueFilter(int intValue, KeyValuePair<IntValueFilter, int?> intFilter)
        {
            if (intFilter.Key == IntValueFilter.HigherThan)
                return intValue >= intFilter.Value;

            else if (intFilter.Key == IntValueFilter.Equal)
                return intValue == intFilter.Value;

            else if (intFilter.Key == IntValueFilter.LowerThan)
                return intValue <= intFilter.Value;

            else if (intFilter.Key == IntValueFilter.Highest)
            {
                //Note that the value for is highest is the current highest value.
                //If null value, returns true
                if (intFilter.Value.HasValue)
                    return intValue >= intFilter.Value;
                else
                    return true;
            }

            else if (intFilter.Key == IntValueFilter.Lowest)
            {
                //Note that the value for is lowest is the current lowest value.
                //If null value, returns true
                if (intFilter.Value.HasValue)
                    return intValue <= intFilter.Value;
                else
                    return true;
            }
            

            else
                throw new Exception("Not a valid filter type");
        }
    }
}

