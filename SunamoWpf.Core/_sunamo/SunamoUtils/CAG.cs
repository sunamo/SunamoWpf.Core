#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class CAG
{
    public static bool IsEqualToAnyElement<T>(T p, IList<T> list)
    {
        foreach (var item in list)
            if (EqualityComparer<T>.Default.Equals(p, item))
                return true;
        return false;
    }
    public static List<T> ToList<T>(params T[] t)
    {
        return t.ToList();
    }
}
