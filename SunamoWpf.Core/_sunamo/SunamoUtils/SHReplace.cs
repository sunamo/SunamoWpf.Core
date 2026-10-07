#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class SHReplace
{
    internal static string ReplaceFirstOccurences(string text, string what, string zaCo)
    {
        var index = text.IndexOf(what);
        if (index != -1)
        {
            text = ReplaceOnce(text, what, zaCo);
            text = text.Insert(index, zaCo);
        }

        return text;
    }

    internal static string ReplaceOnceIfStartedWith(string what, string replaceWhat, string zaCo, out bool replaced)
    {
        replaced = false;
        if (what.StartsWith(replaceWhat))
        {
            replaced = true;
            return ReplaceOnce(what, replaceWhat, zaCo);
        }
        return what;
    }

    internal static string ReplaceOnce(string input, string what, string zaco)
    {
        if (what == "") return input;
        var pos = input.IndexOf(what);
        if (pos == -1) return input;
        return input.Substring(0, pos) + zaco + input.Substring(pos + what.Length);
    }
}
