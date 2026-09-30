#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal static class SF
{
    public const string replaceForSeparatorString = "_";
    private static readonly SerializeContentArgs s_contentArgs = new();
    public static string dDeli = "|";
    static SF()
    {
        s_contentArgs.separatorString = "|";
    }
    public static string separatorString
    {
        get => s_contentArgs.separatorString;
        set => s_contentArgs.separatorString = value;
    }
    /// <summary>
    ///     In inner array is elements, in outer lines.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    //public static List<List<string>> GetAllElementsFile(string file)
    //{
    //    string firstLine = null;
    //    return GetAllElementsFile(file, ref firstLine);
    //}
    public static List<string> RemoveComments(List<string> tf)
    {
        //CA.RemoveStringsEmpty2(tf);
        tf = tf.Where(d => !string.IsNullOrWhiteSpace(d)).ToList();
        // Nevím vůbec co toto má znamenat ael nedává mi to smysl
        // Příště dopsat komentář pokud budu odkomentovávat
        //if (tf.Count > 0)
        //{
        //    if (tf[0].StartsWith("#"))
        //    {
        //        return tf[0];
        //    }
        //}
        //CA.RemoveStartingWith("#", tf);
        tf = tf.Where(d => !d.StartsWith("#")).ToList();
        return tf;
    }
    public static List<List<string>> GetAllElementsFile(string file/*, ref string firstCommentLine*/,
        string oddelovaciZnak = "|")
    {

        var (header, rows) = GetAllElementsFileAdvanced(file, oddelovaciZnak);

        //firstCommentLine = rows.FirstOrDefault(d => d.)

        if (header.Count > 0) rows.Insert(0, header);
        return rows;
    }
    /// <summary>
    ///     Without last |
    ///     DateTime is format with DTHelperEn.ToString
    /// </summary>
    /// <param name="o"></param>
    /// <param name="separator"></param>
    public static string PrepareToSerialization2(IList<string> o)
    {
        return PrepareToSerializationWorker(o, true, dDeli);
    }
    ///// <summary>
    ///// Return without last
    ///// DateTime is serialize always in english format
    ///// Opposite method: DTHelperEn.ToString<>DTHelperEn.ParseDateTimeUSA
    ///// </summary>
    ///// <param name="pr"></param>
    //public static string PrepareToSerialization2(params string[] pr)
    //{
    //    var ts = new List<string>(pr);
    //    return PrepareToSerializationWorker(ts, true, separatorString);
    //}
    /// <summary>
    ///     Return without last
    ///     If need to combine string and IList, lets use CA.Join
    /// </summary>
    /// <param name="o"></param>
    public static string PrepareToSerializationExplicit2(IList<string> o, string separator = "|")
    {
        return PrepareToSerializationWorker(o, true, separator);
    }
    public static
#if ASYNC
        async Task<List<List<string>>>
#else
 List<List<string>>
#endif
        AppendAllText(string path, string line)
    {
        var content = (await
                File.ReadAllLinesAsync(path).ConfigureAwait(false)).ToList();
        CA.Trim(content);
        //content += Environment.NewLine + line + Environment.NewLine;
        content.Add(line);
        var vr = GetAllElementsLines(content);
#if ASYNC
        await
#endif
            File.WriteAllLinesAsync(path, content).ConfigureAwait(false);
        return vr;
    }
    private static List<List<string>> GetAllElementsLines(List<string> lines)
    {
        string firstLine = null;
        return GetAllElementsLines(lines, ref firstLine);
    }
    private static List<List<string>> GetAllElementsLines(List<string> lines, ref string firstLIne)
    {
        lines = RemoveComments(lines);
        var vr = new List<List<string>>();

        firstLIne = lines[0];

        foreach (var var in lines)
            if (!string.IsNullOrWhiteSpace(var))
                vr.Add(GetAllElementsLine(var));
        return vr;
    }
    ///// <summary>
    ///// Return without last
    ///// DateTime is serialize always in english format
    ///// Opposite method: DTHelperEn.ToString<>DTHelperEn.ParseDateTimeUSA
    ///// </summary>
    ///// <param name="pr"></param>
    //public static string PrepareToSerialization2(params string[] pr)
    //{
    //    var ts = new List<string>(pr);
    //    return PrepareToSerializationWorker(ts, true, separatorString);
    //}
    /// <summary>
    ///     DateTime is format with DTHelperEn.ToString
    /// </summary>
    /// <param name="o"></param>
    /// <param name="removeLast"></param>
    /// <param name="separator"></param>
    private static string PrepareToSerializationWorker(IList<string> o, bool removeLast, string separator)
    {
        var list = o.ToList();
        if (separator == replaceForSeparatorString)
            throw new Exception("replaceForSeparatorString is the same as separator");
        CA.Replace(list, separator, replaceForSeparatorString);
        CA.Replace(list, Environment.NewLine, "");
        CA.Trim(list);
        var vr = string.Join(separator, list);
        if (removeLast)
            if (vr.Length > 0)
                return vr.Substring(0, vr.Length - 1);
        return vr;
    }
    /// <summary>
    ///     Get all elements from A1
    ///     A2 byl object ale dal jsem ho jako string
    ///     nemůžu to dávat jako object protože SHSplit.Split musí být typový. Např. když mám allWhiteChars který je List
    ///     <object> a po přenesení do params string[] mi vytvoří new string[]{}
    /// </summary>
    /// <param name="var"></param>
    public static List<string> GetAllElementsLine(string var, string oddelovaciZnak = null)
    {
        if (oddelovaciZnak == null) oddelovaciZnak = "|";
        // Musí tu být none, protože pak když někde nic nebylo, tak mi to je nevrátilo a progran vyhodil IndexOutOfRangeException
        return SHSplit.Split(var, oddelovaciZnak);
    }
    /// <summary>
    ///     In result A1 is not
    /// </summary>
    /// <param name="file"></param>
    /// <param name="hlavicka"></param>
    /// <param name="oddelovaciZnak"></param>
    public static (List<string> header, List<List<string>> rows)
        GetAllElementsFileAdvanced(string file,
            string oddelovaciZnak = "|")
    {
        if (oddelovaciZnak == null) oddelovaciZnak = "|";
        var hlavicka = new List<string>();
        var oz = oddelovaciZnak;
        var vr = new List<List<string>>();
        // Sync protože mám v deklaraci out
        var lines = File.ReadAllLines(file).ToList();
        CA.Trim(lines);
        if (lines.Count > 0)
        {
            hlavicka = GetAllElementsLine(lines[0], oddelovaciZnak);
            var musiByt = lines[0].Split(new[] { oz }, StringSplitOptions.None).Length - 1;
            //int nalezeno = 0;
            var jedenRadek = new StringBuilder();
            for (var i = 1; i < lines.Count; i++)
            {
                if (lines[i].Trim().Length == 0) continue;
                //nalezeno += SH.OccurencesOfStringIn(lines[i], oz);
                jedenRadek.AppendLine(lines[i]);
                //if (nalezeno == musiByt)
                //{
                //nalezeno = 0;
                var columns = GetAllElementsLine(jedenRadek.ToString(), oddelovaciZnak);
                CA.Trim(columns);
                jedenRadek.Clear();
                vr.Add(columns);
                //}
            }
        }
        return (hlavicka, vr);
    }
}
