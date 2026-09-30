#define ASYNC
namespace SunamoWpf._sunamo;

internal class DTHelper
{
    internal static string AppendToFrontOnlyTime(string defin)
    {
        DateTime dt = DateTime.Now;
        return dt.Hour.ToString("D2") + ":" + dt.Minute.ToString("D2") + ":" + dt.Second.ToString("D2") + ":" + dt.Millisecond.ToString("D3") + "" + defin;
    }
}