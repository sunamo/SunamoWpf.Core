#define ASYNC
namespace SunamoWpf._sunamo;

internal class TypesControlsSunamo
{
    /// <summary>
    /// Is initialized directly in PathEditor to avoid referencing not used assembly
    /// In default is type's object to avoid exception in waterfall type checking
    /// </summary>
    public static Type tPathEditor = typeof(Object);
    public const string CheckBoxListUC = "SunamoWpf.Controls.Collections.CheckBoxListUC";
}