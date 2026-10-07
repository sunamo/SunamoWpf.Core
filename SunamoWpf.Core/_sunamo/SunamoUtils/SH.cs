#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class SH
{
    private static bool IsInFirstXCharsTheseLetters(string text, int length, params char[] letters)
    {
        for (var index = 0; index < length; index++)
            foreach (var item in letters)
                if (text[index] == item)
                    return true;
        return false;
    }

    private static string ShortForLettersCount(string text, int p_2, out bool pridatTriTecky)
    {
        pridatTriTecky = false;
        // Vše tu funguje výborně
        text = text.Trim();
        var length = text.Length;
        var jeDelsiA1 = p_2 <= length;

        if (jeDelsiA1)
        {
            if (IsInFirstXCharsTheseLetters(text, p_2, ' '))
            {
                var dexMezery = 0;
                var working = text; //p.Substring(p.Length - zkratitO);
                var length2 = working.Length;

                var napocitano = 0;
                for (var index = 0; index < length2; index++)
                {
                    napocitano++;

                    if (working[index] == ' ')
                    {
                        if (napocitano >= p_2) break;

                        dexMezery = index;
                    }
                }

                working = working.Substring(0, dexMezery + 1);
                if (working.Trim() != "") pridatTriTecky = true;
                //d = d ;
                return working;
                //}
            }

            pridatTriTecky = true;
            return text.Substring(0, p_2);
        }

        return text;
    }

    public static string ShortForLettersCount(string text, int p_2)
    {
        var pridatTriTecky = false;
        return ShortForLettersCount(text, p_2, out pridatTriTecky);
    }

    public static bool Contains(string fileFullPath, string key)
    {
        return fileFullPath.Contains(key);
    }
    public static int CountLines(string text)
    {
        return Regex.Matches(text, Environment.NewLine).Count;
    }
    public static string DetectNewline(string text)
    {
        if (text.Contains("\r\n")) return "\r\n";
        return "\n";
    }

    public static string GetLastPartByString(string input, string returnFromString)
    {
        var dex = input.LastIndexOf(returnFromString);
        if (dex == -1) return input;
        var start = dex + returnFromString.Length;
        if (start < input.Length) return input.Substring(start);
        return input;
    }

    public static string ListToString(object value, string delimiter = null)
    {
        if (value == null) return "(null)";

        string text;
        var valueType = value.GetType();

        if (value is IList && valueType != Types.tString && valueType != Types.tStringBuilder &&
            !(value is IList<char>))
        {
            if (delimiter == null) delimiter = Environment.NewLine;

            var enumerable = value; //CA.ToListStringIEnumerable2((IList)value);
            // I dont know why is needed SHReplace.Replace delimiterS(,) for space
            // This setting remove , before RoutedEventArgs etc.
            //CA.SHReplace.Replace(enumerable, delimiterS, "");
            text = string.Join(delimiter, enumerable);
        }
        //else if (valueType == Types.tDateTime)
        //{
        //    //DTHelperEn.ToString(
        //    text = ((DateTime)value).ToLongTimeString();
        //}
        else
        {
            text = value.ToString();
        }

        return text;
    }

    public static string PostfixIfNotEmpty(string text, string postfix)
    {
        if (text.Length != 0)
            if (!text.EndsWith(postfix))
                return text + postfix;
        return text;
    }

    public static string PrefixIfNotStartedWith(string item, string http, bool skipWhitespaces = false)
    {
        string whitespaces = string.Empty;

        if (skipWhitespaces)
        {
            whitespaces = WhiteSpaceFromStart(item);
            item = item.Substring(whitespaces.Length);
        }

        if (!item.StartsWith(http))
        {
            return whitespaces + http + item;
        }

        return whitespaces + item;
    }

    public static string WhiteSpaceFromStart(string text)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var item in text)
        {
            if (char.IsWhiteSpace(item))
            {
                stringBuilder.Append(item);
            }
            else
            {
                break;
            }
        }
        return stringBuilder.ToString();
    }

    public static bool RemovePrefix(ref string text, string prefix)
    {
        if (text.StartsWith(prefix))
        {
            text = text.Substring(prefix.Length);
            return true;
        }
        return false;
    }

    public static string TextAfter(string item, string after)
    {
        var dex = item.IndexOf(after);
        if (dex != -1) return item.Substring(dex + after.Length);
        return string.Empty;
    }
}
