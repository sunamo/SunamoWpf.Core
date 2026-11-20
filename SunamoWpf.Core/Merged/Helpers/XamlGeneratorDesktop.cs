#define ASYNC
namespace SunamoWpf;

/// <summary>
/// Represents the xaml generator desktop type.
/// </summary>
public class XamlGeneratorDesktop //: XamlGenerator
{
    static Type type = typeof(XamlGeneratorDesktop);



    /// <summary>
    /// Get control t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="xml">The xml.</param>
    /// <returns>The get control t result.</returns>
    public T GetControl<T>(string xml)
    {

        xml = SHReplace.ReplaceFirstOccurences(xml, ">", " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">");
        var vrR = (T)XamlReader.Parse(xml);
        return vrR;
    }
}