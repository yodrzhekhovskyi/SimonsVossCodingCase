using System.Text.RegularExpressions;

namespace SimonsVossCodingCase.Services.Extensions;

public static class StringExtensions
{
    public static string RemoveWhiteSpaces(this string value) => Regex.Replace(value, @"\s", "");
}
