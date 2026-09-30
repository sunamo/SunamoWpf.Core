#define ASYNC
namespace SunamoWpf._sunamo;
/// <summary>
///     U��v� se v SunamoReflection+SUnamoLogger
/// </summary>
internal class DumpAsStringArgs : DumpAsStringHeaderArgsReflection
{
    public DumpProvider d = DumpProvider.Yaml;
    public string deli = " - ";
    public string name = string.Empty;
    public object o;

    /// <summary>
    ///     Good for fast comparing objects
    /// </summary>
    public bool onlyValues;
}