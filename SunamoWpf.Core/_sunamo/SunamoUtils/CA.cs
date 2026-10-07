#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class CA
{
    public static void Replace(List<string> files_in, string what, string forWhat)
    {
        for (var index = 0; index < files_in.Count; index++) files_in[index] = Replace(files_in[index], what, forWhat);
        //CAChangeContent.ChangeContent2(null, files_in, Replace, what, forWhat);
    }

    private static string Replace(string value, string from, string replacement)
    {
        return value.Replace(from, replacement);
    }

    public static List<string> Trim(List<string> items)
    {
        for (var index = 0; index < items.Count; index++) items[index] = items[index].Trim();
        return items;
    }

    public static bool IsAllTheSame<T>(T ext, IList<T> items)
    {
        for (var index = 0; index < items.Count; index++)
            if (!EqualityComparer<T>.Default.Equals(items[index], ext))
                return false;
        return true;
    }

    public static List<string> RemoveStringsEmpty(List<string> mySites)
    {
        for (int index = mySites.Count - 1; index >= 0; index--)
        {
            if (mySites[index] == string.Empty)
            {
                mySites.RemoveAt(index);
            }
        }
        return mySites;
    }

    public static List<bool> ToBool(List<int> numbers)
    {
        var result = new List<bool>(numbers.Count);
        foreach (var item in numbers) result.Add(item == 1 ? true : false);
        return result;
    }

    public static List<string> ToListString(params string[] values)
    {
        return values.ToList();
    }

    public static List<string> WithEndSlash(List<string> folders)
    {
        var list = folders;
        if (list == null) list = folders.ToList();
        for (var index = 0; index < list.Count; index++) list[index] = list[index].TrimEnd('\\') + "\\";
        return folders;
    }
}
