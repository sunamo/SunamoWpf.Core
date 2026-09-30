#define ASYNC
namespace SunamoWpf._sunamo;

internal class SerializeContentArgs
{
    internal string separatorString = "|";

    /// <summary>
    ///     Must be property - I can forget change value on three occurences.
    /// </summary>
    internal char separatorChar => separatorString[0];

    internal int keyCodeSeparator => separatorChar;
}