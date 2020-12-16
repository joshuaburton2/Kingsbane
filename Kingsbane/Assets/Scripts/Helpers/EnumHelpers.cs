using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class EnumHelpers
{
    public static string GetEnumDescription<T>(this T value) where T : IConvertible
    {
        var fi = value.GetType().GetField(value.ToString());

        return fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any()
            ? attributes.First().Description
            : value.ToString();
    }
}
