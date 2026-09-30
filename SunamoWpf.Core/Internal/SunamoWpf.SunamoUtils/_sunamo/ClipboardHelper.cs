#define ASYNC
namespace SunamoWpf._sunamo;

internal class ClipboardHelper
{
    internal static void SetLines(List<string> lines)
    {
        SetText(string.Join("\n", lines));
    }
    internal static void SetText(string s)
    {
        ClipboardService.SetText(s);
    }
}