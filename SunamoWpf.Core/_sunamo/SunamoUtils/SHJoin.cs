#define ASYNC
namespace SunamoWpf.Core._sunamo;

internal class SHJoin
{
    public static string JoinDictionary(Dictionary<string, string> dictionary, string delimiter)
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in dictionary) stringBuilder.AppendLine(item.Key + delimiter + item.Value);
        return stringBuilder.ToString();
    }
}
