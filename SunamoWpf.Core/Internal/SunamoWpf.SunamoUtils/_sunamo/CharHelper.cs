#define ASYNC
namespace SunamoWpf._sunamo;

internal class CharHelper
{
    internal static string OnlyDigits(string v)
    {
        return OnlyAccepted(v, char.IsDigit);
    }
    internal static string OnlyAccepted(string v, Func<char, bool> isDigit, bool not = false)
    {
        var sb = new StringBuilder();
        var result = false;
        foreach (var item in v)
        {
            result = isDigit.Invoke(item);
            if (not) result = !result;
            if (result) sb.Append(item);
        }
        return sb.ToString();
    }
}