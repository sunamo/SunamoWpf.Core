#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class BTS
{
    ///// <summary>
    /////     Usage: Usage: Exceptions.ArrayElementContainsUnallowedStrings->SH.ContainsAny
    ///// <typeparam name="T"></typeparam>
    ///// <param name="c"></param>
    ///// <param name="isChar"></param>
    ///// <returns></returns>
    //public static T CastToByT<T>(string c, bool isChar)
    //{
    //    return isChar ? (T)(dynamic)c.First() : (T)(dynamic)c;
    //}
    public static string Replace(ref string id, bool replaceCommaForDot)
    {
        if (replaceCommaForDot) id = id.Replace(",", ".");
        return id;
    }
    /// <summary>
    ///     Check for null in A2
    /// </summary>
    /// <param name="tag2"></param>
    /// <param name="tag"></param>
    public static bool CompareAsObjectAndString(object tag2, object tag)
    {
        var same = false;
        if (tag2 != null)
        {
            if (tag == tag2)
                same = true;
            else if (tag.ToString() == tag2.ToString()) same = true;
        }
        return same;
    }
    public static string ToString<T>(T t)
    {
        return t.ToString();
    }
    /// <summary>
    ///     POkud bude A1 nevyparsovatelné, vrátí int.MinValue
    ///     Replace spaces
    /// </summary>
    /// <param name="entry"></param>
    public static int ParseInt(string entry)
    {
        var lastInt2 = 0;
        if (int.TryParse(entry.Replace(" ", string.Empty), out lastInt2)) return lastInt2;
        return int.MinValue;
    }
    public static int? ParseInt(string entry, int? _default)
    {
        var lastInt2 = 0;
        if (int.TryParse(entry, out lastInt2)) return lastInt2;
        return _default;
    }
    /// <summary>
    ///     If has value true, return true. Otherwise return false
    /// </summary>
    /// <param name="t"></param>
    public static bool GetValueOfNullable(bool? t)
    {
        if (t.HasValue) return t.Value;
        return false;
    }
    public static int BoolToInt(bool v)
    {
        return Convert.ToInt32(v);
    }
    public static int ParseInt(string entry, bool mustBeAllNumbers)
    {
        int d;
        if (!int.TryParse(entry, out d))
            if (mustBeAllNumbers)
                return int.MinValue;
        return d;
    }
    public static int ParseInt(string entry, int _default)
    {
        //entry = SH.FromSpace160To32(entry);
        entry = entry.Replace(" ", string.Empty);
        //var ch = entry[3];
        var lastInt2 = 0;
        if (int.TryParse(entry, out lastInt2)) return lastInt2;
        return _default;
    }
    private const string Yes = "Yes";
    private const string Ano = "Ano";
    private const string One = "1";
    /// <summary>
    ///     G bool repr. A1. Pro Yes true, JF.
    /// </summary>
    /// <param name="s"></param>
    public static bool StringToBool(string s)
    {
        if (s == Yes || s == bool.TrueString || s == One || s == Ano) return true;
        return false;
    }
}
