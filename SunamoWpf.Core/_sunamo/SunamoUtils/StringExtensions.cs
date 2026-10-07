#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal static class StringExtensions
{
    internal static string RemoveInvisibleChars(this string input)
    {
        int[] charsToRemove = [8205];
        return new string(input.ToCharArray()
            .Where(character => !charsToRemove.Contains(character))
            .ToArray());
    }
}
