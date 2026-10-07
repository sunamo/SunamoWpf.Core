#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class SHSplit
{
    public static List<string> SplitByWhiteSpaces(string text, bool removeEmpty = false)
    {
        WhitespaceCharService whitespaceChar = new();
        whitespaceChar.ConvertWhiteSpaceCodesToChars();

        if (whitespaceChar == null)
        {
            ThrowEx.Custom($"whitespaceChar.whiteSpaceChars is not initialized"); ;
        }

        text = text.RemoveInvisibleChars();
        List<string> result = null;
        if (removeEmpty)
        {
            //r = s.Split(AllChars.whiteSpaceChars.ToArray()).ToList();
            result = SplitChar(text, whitespaceChar.whiteSpaceChars.ToArray()).ToList();
        }
        else
            //r = s.Split(AllChars.whiteSpaceChars.ToArray(), StringSplitOptions.None).ToList();
            result = SplitNone(text, whitespaceChar.whiteSpaceChars.ConvertAll(item => item.ToString()).ToArray()).ToList();
        return result;
    }

    public static List<string> SplitChar(string parametry, params char[] deli)
    {
        return Split(StringSplitOptions.RemoveEmptyEntries, parametry,
            deli.ToList().ConvertAll(item => item.ToString()).ConvertAll(itemText => itemText.ToString()).ToArray());
    }

    public static List<string> Split(string text, params string[] newLine)
    {
        return text.Split(newLine, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public static List<string> Split(StringSplitOptions stringSplitOptions, string text, params string[] deli)
    {
        if (deli == null || deli.Count() == 0) throw new Exception("NoDelimiterDetermined");
        //var ie = CA.OneElementCollectionToMulti(deli);
        //var deli3 = new List<string>IEnumerable2(ie);
        var result = text.Split(deli, stringSplitOptions).ToList();
        CA.Trim(result);
        if (stringSplitOptions == StringSplitOptions.RemoveEmptyEntries)
            result = result.Where(line => line.Trim() != string.Empty).ToList();

        return result;
    }

    public static List<string> SplitNone(string text, params string[] newLine)
    {
        return text.Split(newLine, StringSplitOptions.None).ToList();
    }
}
