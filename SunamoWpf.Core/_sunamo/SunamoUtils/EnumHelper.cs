#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class EnumHelper
{
    public static List<T> GetValues<T>(bool IncludeNope, bool IncludeShared)
        where T : struct
    {
        var type = typeof(T);
        var values = Enum.GetValues(type).Cast<T>().ToList();
        T nope;
        if (!IncludeNope)
            if (Enum.TryParse("Nope", out nope))
                values.Remove(nope);

        if (!IncludeShared)
        {
            if (type.Name == "MySites")
            {
                if (Enum.TryParse("Shared", out nope)) values.Remove(nope);
            }
            else
            {
                if (Enum.TryParse("Sha", out nope)) values.Remove(nope);
            }
        }

        if (Enum.TryParse("None", out nope)) values.Remove(nope);

        return values;
    }

    public static T Parse<T>(string web, T _def, bool returnDefIfNull = false)
       where T : struct
    {
        if (returnDefIfNull) return _def;
        T result;
        if (Enum.TryParse(web, true, out result)) return result;

        return _def;
    }
}
