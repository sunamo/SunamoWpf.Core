#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class NH
{
    internal static List<T> Sort<T>(params T[] t)
    {
        var c = new List<T>(t);
        c.Sort();
        return c;
    }
}
