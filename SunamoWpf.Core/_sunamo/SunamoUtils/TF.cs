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
        AppendAllText(string content, string path)
    {
#if ASYNC
        await
#endif
            File.AppendAllTextAsync(path, content).ConfigureAwait(false);
    }

    public static async Task<string?> ReadAllText(string path)
    {
        return await File.ReadAllTextAsync(path).ConfigureAwait(false);
    }

    public static async Task WriteAllLines(string item2, List<string> lines)
    {
        await File.WriteAllLinesAsync(item2, lines).ConfigureAwait(false);
    }

    public static async Task WriteAllText(string csProj, string content)
    {
        await File.WriteAllTextAsync(csProj, content).ConfigureAwait(false);
    }

    /// <summary>
    /// Reads all lines of a file asynchronously.
    /// </summary>
    public static async Task<List<string>> ReadAllLines(string file)
    {
        return (await File.ReadAllLinesAsync(file).ConfigureAwait(false)).ToList();
    }
}
