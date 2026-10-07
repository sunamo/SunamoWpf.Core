#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class DTHelper
{
    internal static string AppendToFrontOnlyTime(string defin)
    {
        DateTime dateTime = DateTime.Now;
        return dateTime.Hour.ToString("D2") + ":" + dateTime.Minute.ToString("D2") + ":" + dateTime.Second.ToString("D2") + ":" + dateTime.Millisecond.ToString("D3") + "" + defin;
    }
}
