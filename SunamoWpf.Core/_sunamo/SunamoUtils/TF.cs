#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class TF
{
    public static
#if ASYNC
        async Task
#else
void
#endif
        AppendAllText(string content, string sf)
    {
#if ASYNC
        await
#endif
            File.AppendAllTextAsync(sf, content).ConfigureAwait(false);
    }

    public static async Task<string?> ReadAllText(string f)
    {
        return await File.ReadAllTextAsync(f).ConfigureAwait(false);
    }

    public static async Task WriteAllLines(string item2, List<string> l)
    {
        await File.WriteAllLinesAsync(item2, l).ConfigureAwait(false);
    }

    public static async Task WriteAllText(string csProj, string c)
    {
        await File.WriteAllTextAsync(csProj, c).ConfigureAwait(false);
    }
}
