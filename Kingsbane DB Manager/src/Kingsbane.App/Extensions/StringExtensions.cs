namespace Kingsbane.App.Extensions
{
    public static class StringExtensions
    {
        public static string ToNullableInt(this int? value)
        {
            return value.HasValue ? value.ToString() : "null";
        }

        public static string FixQuotes(this string value)
        {
            return (value ?? "").Replace("\"", "\"\"");
        }
    }
}
