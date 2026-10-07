#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class NH
{
    internal static List<T> Sort<T>(params T[] items)
    {
        var result = new List<T>(items);
        result.Sort();
        return result;
    }
}
