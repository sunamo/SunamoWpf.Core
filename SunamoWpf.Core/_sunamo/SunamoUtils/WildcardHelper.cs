#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class WildcardHelper
{
    internal static bool IsWildcard(string text)
    {
        return text.ToCharArray().Any(character => character == '?') || text.ToCharArray().Any(charToCompare => charToCompare == '*');
    }
}
