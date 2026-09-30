#define ASYNC
namespace SunamoWpf._sunamo;

internal class BTS
{
    //        #region  from BTSShared64.cs
    public static int lastInt = -1;
    public static long lastLong = -1;
    public static float lastFloat = -1;
    public static double lastDouble = -1;
    private static Type type = typeof(BTS);
    public static byte lastByte = 255;
    public static bool lastBool;
    public static DateTime lastDateTime = DateTime.MinValue;
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
    public static bool IsFloat(string id, bool replace = false)
    {
        if (id == null) return false;
        Replace(ref id, replace);
        return float.TryParse(id.Replace(",", "."), out lastFloat);
    }
    public static bool IsDouble(string id, bool replace = false)
    {
        if (id == null) return false;
        Replace(ref id, replace);
        return double.TryParse(id.Replace(",", "."), out lastDouble);
    }
    /// <summary>
    ///     Usage: Exceptions.IsInt
    /// </summary>
    /// <param name="id"></param>
    /// <param name="excIfIsFloat"></param>
    /// <param name="replaceCommaForDot"></param>
    /// <returns></returns>
    public static bool IsInt(string id, bool excIfIsFloat = false, bool replaceCommaForDot = false)
    {
        if (id == null) return false;
        id = id.Replace(" ", "");
        Replace(ref id, replaceCommaForDot);
        var vr = int.TryParse(id, out lastInt);
        if (!vr)
            if (IsFloat(id))
                if (excIfIsFloat)
                    throw new Exception(id + " is float but is calling IsInt");
        return vr;
    }
    public static bool IsLong(string id, bool excIfIsDouble = false, bool replaceCommaForDot = false)
    {
        if (id == null) return false;
        id = id.Replace(" ", ""); //SHReplace.ReplaceAll4(, "", " ");
        Replace(ref id, replaceCommaForDot);
        var vr = long.TryParse(id, out lastLong);
        if (!vr)
            if (IsDouble(id))
                if (excIfIsDouble)
                    throw new Exception(id + " is float but is calling IsInt");
        return vr;
    }
    //        #endregion
    public static int FromHex(string hexValue)
    {
        return int.Parse(hexValue, NumberStyles.HexNumber);
    }
    public static Stream StreamFromString(string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
    public static string StringFromStream(Stream stream)
    {
        var reader = new StreamReader(stream);
        var text = reader.ReadToEnd();
        return text;
    }
    #region Parse*
    public static bool TryParseBool(string trim)
    {
        return bool.TryParse(trim, out lastBool);
    }
    #endregion
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
    /// <summary>
    ///     G zda  prvky A2 - Ax jsou hodnoty A1.
    /// </summary>
    /// <param name="hodnota"></param>
    /// <param name="paramy"></param>
    public static bool IsAllEquals(bool hodnota, params bool[] paramy)
    {
        for (var i = 0; i < paramy.Length; i++)
            if (hodnota != paramy[i])
                return false;
        return true;
    }
    /// <param name="od"></param>
    /// <param name="to"></param>
    /// <param name="value"></param>
    public static bool IsInRange(int od, int to, int value)
    {
        if (value == 100)
        {
        }
        // Zde jsem měl opačně znaménka, teď už by to mělo být správně
        return od <= value && to >= value;
    }
    public static bool Is(bool binFp, bool n)
    {
        if (n) return !binFp;
        return binFp;
    }
    public static List<string> GetOnlyNonNullValues(params string[] args)
    {
        var vr = new List<string>();
        for (var i = 0; i < args.Length; i++)
        {
            var text = args[i];
            object hodnota = args[++i];
            if (hodnota != null)
            {
                vr.Add(text);
                vr.Add(hodnota.ToString());
            }
        }
        return vr;
    }
    #region Get*ValueForType
    public static object GetMaxValueForType(Type id)
    {
        if (id == typeof(byte))
            return byte.MaxValue;
        if (id == typeof(decimal))
            return decimal.MaxValue;
        if (id == typeof(double))
            return double.MaxValue;
        if (id == typeof(short))
            return short.MaxValue;
        if (id == typeof(int))
            return int.MaxValue;
        if (id == typeof(long))
            return long.MaxValue;
        if (id == typeof(float))
            return float.MaxValue;
        if (id == typeof(sbyte))
            return sbyte.MaxValue;
        if (id == typeof(ushort))
            return ushort.MaxValue;
        if (id == typeof(uint))
            return uint.MaxValue;
        if (id == typeof(ulong)) return ulong.MaxValue;
        throw new Exception("Nepovolen\u00FD nehodnotov\u00FD typ v metod\u011B GetMaxValueForType");
    }
    #endregion
    public static List<byte> ClearEndingsBytes(List<byte> plainTextBytes)
    {
        var bytes = new List<byte>();
        var pridavat = false;
        for (var i = plainTextBytes.Count - 1; i >= 0; i--)
            if (!pridavat && plainTextBytes[i] != 0)
            {
                pridavat = true;
                var pridat = plainTextBytes[i];
                bytes.Insert(0, pridat);
            }
            else if (pridavat)
            {
                var pridat = plainTextBytes[i];
                bytes.Insert(0, pridat);
            }
        if (bytes.Count == 0)
        {
            for (var i = 0; i < plainTextBytes.Count; i++) plainTextBytes[i] = 0;
            return plainTextBytes;
        }
        return bytes;
    }
    public static int? ParseIntNull(string v)
    {
        if (int.TryParse(v, out lastInt)) return lastInt;
        return null;
    }
    public static string ToString<T>(T t)
    {
        return t.ToString();
    }
    /// <summary>
    ///     return Func<string, T1> or null
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <returns></returns>
    public static object MethodForParse<T1>()
    {
        var t = typeof(T1);
        #region Same seria as in DefaultValueForTypeT
        #region MyRegion
        if (t == Types.tString) return new Func<string, string>(ToString);
        if (t == Types.tBool) return new Func<string, bool>(bool.Parse);
        #endregion
        #region Signed numbers
        if (t == Types.tFloat) return new Func<string, float>(float.Parse);
        if (t == Types.tDouble) return new Func<string, double>(double.Parse);
        if (t == typeof(int)) return new Func<string, int>(int.Parse);
        if (t == Types.tLong) return new Func<string, long>(long.Parse);
        if (t == Types.tShort) return new Func<string, short>(short.Parse);
        if (t == Types.tDecimal) return new Func<string, decimal>(decimal.Parse);
        if (t == Types.tSbyte) return new Func<string, sbyte>(sbyte.Parse);
        #endregion
        #region Unsigned numbers
        if (t == Types.tByte) return new Func<string, byte>(byte.Parse);
        if (t == Types.tUshort) return new Func<string, ushort>(ushort.Parse);
        if (t == Types.tUint) return new Func<string, uint>(uint.Parse);
        if (t == Types.tUlong) return new Func<string, ulong>(ulong.Parse);
        #endregion
        if (t == Types.tDateTime) return new Func<string, DateTime>(DateTime.Parse);
        if (t == Types.tGuid) return new Func<string, Guid>(Guid.Parse);
        if (t == Types.tChar) return new Func<string, char>(s => s[0]);
        #endregion
        return null;
    }
    public static bool IsDateTime(string dt)
    {
        if (dt == null) return false;
        return DateTime.TryParse(dt, out lastDateTime);
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
    public static bool IsBool(string trim)
    {
        if (trim == null) return false;
        return bool.TryParse(trim, out lastBool);
    }
    public static byte ParseByte(string entry)
    {
        byte lastInt2 = 0;
        if (byte.TryParse(entry, out lastInt2)) return lastInt2;
        return byte.MinValue;
    }
    public static short ParseShort(string entry)
    {
        return ParseShort(entry, short.MinValue);
    }
    public static short ParseShort(string entry, short defVal)
    {
        short lastInt2 = 0;
        if (short.TryParse(entry, out lastInt2)) return lastInt2;
        return defVal;
    }
    public static int? ParseInt(string entry, int? _default)
    {
        var lastInt2 = 0;
        if (int.TryParse(entry, out lastInt2)) return lastInt2;
        return _default;
    }
    public static string BoolToStringEn(bool p, bool lower = false)
    {
        string vr = null;
        if (p)
            vr = "Yes";
        else
            vr = "No";
        if (lower)
        {
            return vr.ToLower();
        }
        return vr;
    }
    public static object GetMinValueForType(Type idt)
    {
        if (idt == typeof(byte))
            return 1;
        if (idt == typeof(short))
            return short.MinValue;
        if (idt == typeof(int))
            return int.MinValue;
        if (idt == typeof(long))
            return long.MinValue;
        if (idt == typeof(sbyte))
            return sbyte.MinValue;
        if (idt == typeof(ushort))
            return ushort.MinValue;
        if (idt == typeof(uint))
            return uint.MinValue;
        if (idt == typeof(ulong)) return ulong.MinValue;
        throw new Exception("Nepovolen\u00FD nehodnotov\u00FD typ v metod\u011B GetMinValueForType");
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Invert(bool b, bool really)
    {
        if (really) return !b;
        return b;
    }
    #region For easy copy from BTSShared64.cs
    public static T CastToByT<T>(string c, bool isChar)
    {
        if (isChar)
            return (T)(dynamic)c.First();
        return (T)(dynamic)c;
    }
    //private static string Replace(ref string id, bool replace)
    //{
    //    return se.BTS.Replace(ref id, replace);
    //}
    //public static bool IsFloat(string id, bool replace = false)
    //{
    //    return se.BTS.IsFloat(id, replace);
    //}
    //public static bool IsInt(string id, bool excIfIsFloat = false, bool replace = false)
    //{
    //    return se.BTS.IsInt(id, excIfIsFloat, replace);
    //}
    #endregion
    #region TryParse*
    /// <summary>
    ///     For parsing from serialized file use DTHelperEn
    /// </summary>
    /// <param name="v"></param>
    /// <param name="ciForParse"></param>
    /// <param name="defaultValue"></param>
    public static DateTime TryParseDateTime(string v, CultureInfo ciForParse, DateTime defaultValue)
    {
        var vr = defaultValue;
        if (DateTime.TryParse(v, ciForParse, DateTimeStyles.None, out vr)) return vr;
        return defaultValue;
    }
    public static uint lastUint;
    public static bool TryParseUint(string entry)
    {
        // Pokud bude A1 null, výsledek bude false
        return uint.TryParse(entry, out lastUint);
    }
    public static bool TryParseDateTime(string entry)
    {
        if (DateTime.TryParse(entry, out lastDateTime)) return true;
        return false;
    }
    public static byte TryParseByte(string p1, byte _def)
    {
        var vr = _def;
        if (byte.TryParse(p1, out vr)) return vr;
        return _def;
    }
    /// <summary>
    ///     Vrací vyparsovanou hodnotu pokud se podaří vyparsovat, jinak A2
    /// </summary>
    /// <param name="p"></param>
    /// <param name="_default"></param>
    public static bool TryParseBool(string p, bool _default)
    {
        var vr = _default;
        if (bool.TryParse(p, out vr)) return vr;
        return _default;
    }
    public static int TryParseIntCheckNull(string entry, int def)
    {
        var lastInt = 0;
        if (entry == null) return lastInt;
        if (int.TryParse(entry, out lastInt)) return lastInt;
        return def;
    }
    public static int TryParseInt(string entry, int def)
    {
        return TryParseInt(entry, def, false);
    }
    public static int TryParseInt(string entry, int def, bool throwEx)
    {
        var lastInt = 0;
        if (int.TryParse(entry, out lastInt)) return lastInt;
        if (throwEx) ThrowEx.NotInt(entry, null);
        return def;
    }
    #endregion
    #region int <> bool
    public static int BoolToInt(bool v)
    {
        return Convert.ToInt32(v);
    }
    /// <summary>
    ///     0 - false, all other - 1
    /// </summary>
    /// <param name="v"></param>
    public static bool IntToBool(int v)
    {
        return Convert.ToBoolean(v);
    }
    #endregion
    #region Parse*
    public static float ParseFloat(string ratingS)
    {
        var vr = float.MinValue;
        ratingS = ratingS.Replace(',', '.');
        if (float.TryParse(ratingS, out vr)) return vr;
        return vr;
    }
    /// <summary>
    ///     Vrátí false v případě že se nepodaří vyparsovat
    /// </summary>
    /// <param name="displayAnchors"></param>
    public static bool ParseBool(string displayAnchors)
    {
        var vr = false;
        if (bool.TryParse(displayAnchors, out vr)) return vr;
        return false;
    }
    /// <summary>
    ///     Vrátí A2 v případě že se nepodaří vyparsovat
    /// </summary>
    /// <param name="displayAnchors"></param>
    public static bool ParseBool(string displayAnchors, bool def)
    {
        var vr = false;
        if (bool.TryParse(displayAnchors, out vr)) return vr;
        return def;
    }
    public static int ParseInt(string entry, bool mustBeAllNumbers)
    {
        int d;
        if (!int.TryParse(entry, out d))
            if (mustBeAllNumbers)
                return int.MinValue;
        return d;
    }
    public static double ParseDouble(string entry, double _default)
    {
        //entry = SH.FromSpace160To32(entry);
        entry = entry.Replace(" ", string.Empty);
        //var ch = entry[3];
        double lastDouble2 = 0;
        if (double.TryParse(entry, out lastDouble2)) return lastDouble2;
        return _default;
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
    public static byte ParseByte(string entry, byte def)
    {
        byte lastInt2 = 0;
        if (byte.TryParse(entry, out lastInt2)) return lastInt2;
        return def;
    }
    #endregion
    #region Is*
    public static bool IsByte(string f)
    {
        if (f == null) return false;
        return byte.TryParse(f, out lastByte);
    }
    public static bool IsByte(string id, out byte b)
    {
        if (id == null)
        {
            b = 0;
            return false;
        }
        //byte b2 = 0;
        var vr = byte.TryParse(id, out b);
        //b = b2;
        return vr;
    }
    #endregion
    #region *To*
    /// <summary>
    ///     0 - false, all other - 1
    /// </summary>
    /// <param name="v"></param>
    public static bool IntToBool(object v)
    {
        var s = v.ToString().Trim();
        if (s == string.Empty) return false;
        return Convert.ToBoolean(int.Parse(s));
    }
    private const string Yes = "Yes";
    private const string No = "No";
    private const string Ano = "Ano";
    private const string Ne = "Ne";
    private const string One = "1";
    private const string Zero = "0";
    /// <summary>
    ///     G bool repr. A1. Pro Yes true, JF.
    /// </summary>
    /// <param name="s"></param>
    public static bool StringToBool(string s)
    {
        if (s == Yes || s == bool.TrueString || s == One || s == Ano) return true;
        return false;
    }
    /// <summary>
    ///     G str rep. pro A1 - Ano/Ne
    /// </summary>
    /// <param name="v"></param>
    public static string BoolToString(bool p)
    {
        if (p) return Ano;
        return Ne;
    }

    #endregion
    #region byte[] <> string
    public static List<byte> ConvertFromUtf8ToBytes(string vstup)
    {
        return Encoding.UTF8.GetBytes(vstup).ToList();
    }
    public static string ConvertFromBytesToUtf8(List<byte> bajty)
    {
        //NH.RemoveEndingZeroPadding(bajty);
        return Encoding.UTF8.GetString(bajty.ToArray());
    }
    public static bool FalseOrNull(object get)
    {
        return get == null || get.ToString() == false.ToString();
    }
    #endregion
    #region Casting between array - cant commented because it wasnt visible between
    public static List<string> CastArrayObjectToString(object[] args)
    {
        var vr = new List<string>(args.Length);
        //CA.InitFillWith(vr, args.Length);
        for (var i = 0; i < args.Length; i++) vr[i] = args[i].ToString();
        return vr;
    }
    public static List<string> CastArrayIntToString(int[] args)
    {
        var vr = new List<string>(args.Length);
        for (var i = 0; i < args.Length; i++) vr[i] = args[i].ToString();
        return vr;
    }
    #endregion
    #region Castint to Array - commented, its in used only List
    //public static int[] CastArrayStringToInt(List<string> plemena)
    //    {
    //        int[] vr = new int[plemena.Length];
    //        for (int i = 0; i < plemena.Length; i++)
    //        {
    //            vr[i] = int.Parse(plemena[i]);
    //        }
    //        return vr;
    //    }
    //    public static short[] CastArrayStringToShort(List<string> plemena)
    //    {
    //        short[] vr = new short[plemena.Count];
    //        for (int i = 0; i < plemena.Count; i++)
    //        {
    //            vr[i] = short.Parse(plemena[i]);
    //        }
    //        return vr;
    //    }
    //    public static List<string> CastArrayObjectToString(string[] args)
    //    {
    //        List<string> vr = new string[args.Length];
    //        for (int i = 0; i < args.Length; i++)
    //        {
    //            vr[i] = args[i].ToString();
    //        }
    //        return vr;
    //    }
    //public static List<string> CastArrayIntToString(int[] args)
    //    {
    //        List<string> vr = new string[args.Length];
    //        for (int i = 0; i < args.Length; i++)
    //        {
    //            vr[i] = args[i].ToString();
    //        }
    //        return vr;
    //    }
    #endregion
    #region Casting to List
    public static List<int> CastToIntList<U>(IList<U> d)
    {
        return CAToNumber.ToNumber(int.Parse, d);
    }
    /// <summary>
    ///     Pokud se cokoliv nepodaří přetypovat, vyhodí výjimku
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    /// <param name="p"></param>
    public static List<int> CastCollectionStringToInt(IList<string> p)
    {
        return CAToNumber.ToNumber(int.Parse, p);
    }
    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name="input"></param>
    public static void RemoveNotNumber(IList input)
    {
        for (var i = input.Count - 1; i >= 0; i--)
            if (!double.TryParse(input[i].ToString(), out var _))
                input.RemoveAt(i);
    }
    /// <summary>
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    /// <param name="n"></param>
    public static List<int> CastCollectionShortToInt(List<short> n)
    {
        var vr = new List<int>();
        for (var i = 0; i < n.Count; i++) vr.Add(n[i]);
        return vr;
    }
    public static List<short> CastCollectionIntToShort(List<int> n)
    {
        var vr = new List<short>(n.Count);
        for (var i = 0; i < n.Count; i++) vr.Add((short)n[i]);
        return vr;
    }
    /// <summary>
    ///     Before use you can call RemoveNotNumber to avoid raise exception
    /// </summary>
    public static List<int> CastListShortToListInt(List<short> n)
    {
        return CastCollectionShortToInt(n);
    }
    #endregion
    #region MakeUpTo*NumbersToZero
    public static object MakeUpTo3NumbersToZero(int p)
    {
        var d = p.ToString().Length;
        if (d == 1)
            return "0" + p;
        if (d == 2) return "00" + p;
        return p;
    }
    public static object MakeUpTo2NumbersToZero(int p)
    {
        if (p.ToString().Length == 1) return "0" + p;
        return p;
    }
    #endregion
    #region Ostatní
    /// <summary>
    ///     Rok nezkracuje, počítá se standardním 4 místným
    ///     Produkuje formát standardní s metodou DateTime.ToString()
    /// </summary>
    /// <param name="dateTime"></param>
    public static string SameLenghtAllDateTimes(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return day + "." + month + "." + year + " " + hour + ":" +
               minutes + ":" + seconds; // +":" + miliseconds;
    }
    public static string SameLenghtAllDates(DateTime dateTime)
    {
        var year = dateTime.Year.ToString();
        var month = dateTime.Month.ToString("D2");
        var day = dateTime.Day.ToString("D2");
        return
            day + "." + month + "." +
            year; // +"" + hour + ":" + minutes + ":" + seconds;// +":" + miliseconds;
    }
    public static string SameLenghtAllTimes(DateTime dateTime)
    {
        var hour = dateTime.Hour.ToString("D2");
        var minutes = dateTime.Minute.ToString("D2");
        var seconds = dateTime.Second.ToString("D2");
        return hour + ":" + minutes + ":" + seconds; // +":" + miliseconds;
    }
    public static string UsaDateTimeToString(DateTime d)
    {
        return d.Month + "/" + d.Day + "/" + d.Year + " " + d.Hour +
               ":" + d.Minute + ":" + d.Second; // +":" + miliseconds;
    }
    public static bool EqualDateWithoutTime(DateTime dt1, DateTime dt2)
    {
        if (dt1.Day == dt2.Day && dt1.Month == dt2.Month && dt1.Year == dt2.Year) return true;
        return false;
    }
    #endregion
    #region GetNumberedList*
    /// <param name="from"></param>
    /// <param name="max"></param>
    /// <param name="postfix"></param>
    public static string[] GetNumberedListFromTo(int from, int max)
    {
        max++;
        var vr = new List<string>();
        for (var i = from; i < max; i++) vr.Add(i.ToString());
        return vr.ToArray();
    }
    public static List<string> GetNumberedListFromTo(int p, int max, string postfix = ". ")
    {
        max++;
        max += p;
        var vr = new List<string>();
        for (var i = p; i < max; i++) vr.Add(i + postfix);
        return vr;
    }
    private static List<string> GetNumberedListFromToList(int p, int indexOdNext)
    {
        var vr = new List<string>();
        var o = GetNumberedListFromTo(p, indexOdNext);
        foreach (object item in o) vr.Add(item.ToString());
        return vr;
    }
    #endregion
}