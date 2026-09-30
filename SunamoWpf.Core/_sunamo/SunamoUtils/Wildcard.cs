#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class Wildcard
{
    internal static string WildcardToRegex(string pattern)
    {
        return "^" + Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
    }
}
