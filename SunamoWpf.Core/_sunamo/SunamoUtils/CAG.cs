#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class CAG
{
    public static bool IsEqualToAnyElement<T>(T value, IList<T> list)
    {
        foreach (var item in list)
            if (EqualityComparer<T>.Default.Equals(value, item))
                return true;
        return false;
    }
    public static List<T> ToList<T>(params T[] items)
    {
        return items.ToList();
    }
}
