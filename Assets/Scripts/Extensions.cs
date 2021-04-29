using System;
using System.Text.RegularExpressions;

public static class Extensions
{
    public static string[] SplitCamelCase(this string source) => Regex.Split(source, @"(?<!^)(?=[A-Z])");

    public static string ToReadableString(this Overcoming overcoming)
    {
        return string.Join(" ", overcoming.ToString().SplitCamelCase());
    }

    public static string ToReadableString(this Quirk quirk)
    {
        return string.Join(" ", quirk.ToString().SplitCamelCase());
    }
}