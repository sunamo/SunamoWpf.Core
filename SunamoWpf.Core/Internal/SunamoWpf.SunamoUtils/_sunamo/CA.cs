#define ASYNC
namespace SunamoWpf._sunamo;

internal class CA
{
    public static void Replace(List<string> files_in, string what, string forWhat)
    {
        for (var i = 0; i < files_in.Count; i++) files_in[i] = Replace(files_in[i], what, forWhat);
        //CAChangeContent.ChangeContent2(null, files_in, Replace, what, forWhat);
    }

    private static string Replace(string s, string from, string to)
    {
        return s.Replace(from, to);
    }

    public static List<string> Trim(List<string> l)
    {
        for (var i = 0; i < l.Count; i++) l[i] = l[i].Trim();
        return l;
    }
    public static void InitFillWith(List<string> datas, int pocet, string initWith = "")
    {
        InitFillWith<string>(datas, pocet, initWith);
    }

    public static void InitFillWith<T>(List<T> datas, int pocet, T initWith)
    {
        for (var i = 0; i < pocet; i++) datas.Add(initWith);
    }

    public static bool IsAllTheSame<T>(T ext, IList<T> p1)
    {
        for (var i = 0; i < p1.Count; i++)
            if (!EqualityComparer<T>.Default.Equals(p1[i], ext))
                return false;
        return true;
    }

    public static List<string> RemoveStringsEmpty(List<string> mySites)
    {
        for (int i = mySites.Count - 1; i >= 0; i--)
        {
            if (mySites[i] == string.Empty)
            {
                mySites.RemoveAt(i);
            }
        }
        return mySites;
    }

    public static List<bool> ToBool(List<int> numbers)
    {
        var b = new List<bool>(numbers.Count);
        foreach (var item in numbers) b.Add(item == 1 ? true : false);
        return b;
    }

    public static List<string> ToListString(params string[] v)
    {
        return v.ToList();
    }

    public static List<string> WithEndSlash(List<string> folders)
    {
        var list = folders;
        if (list == null) list = folders.ToList();
        for (var i = 0; i < list.Count; i++) list[i] = list[i].TrimEnd('\\') + "\\";
        return folders;
    }
}