#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class CharHelper
{
    internal static string OnlyDigits(string value)
    {
        return OnlyAccepted(value, char.IsDigit);
    }
    internal static string OnlyAccepted(string value, Func<char, bool> isDigit, bool not = false)
    {
        var stringBuilder = new StringBuilder();
        var result = false;
        foreach (var item in value)
        {
            result = isDigit.Invoke(item);
            if (not) result = !result;
            if (result) stringBuilder.Append(item);
        }
        return stringBuilder.ToString();
    }
}
