#define ASYNC
namespace SunamoWpf.Helpers.ContainerControls;

/// <summary>
/// Represents the grid helper type.
/// </summary>
public partial class GridHelper
{
    /// <summary>
    /// The gl auto.
    /// </summary>
    public static readonly GridLength glAuto = new System.Windows.GridLength(1, System.Windows.GridUnitType.Auto);
    /// <summary>
    /// Cant be used due to
    /// ''value' already belongs to another 'RowDefinitionCollection'.'
    /// </summary>
    public static readonly RowDefinition rdAuto = GetRowDefinition(glAuto);
    /// <summary>
    /// Cant be used due to
    /// ''value' already belongs to another 'RowDefinitionCollection'.'
    /// </summary>
    public static readonly ColumnDefinition cdAuto = GetColumnDefinition(glAuto);

    /// <summary>
    /// For all the same runtime.
    /// </summary>
    /// <param name="grid">The grid.</param>
    /// <param name="count">The count.</param>
    /// <param name="columns">The columns.</param>
    public static void ForAllTheSameRuntime(Grid grid, int count, bool columns)
    {
        var percent = 100d / (double)count;
        for (int index = 0; index < count; index++)
        {
            if (columns)
            {
                grid.ColumnDefinitions.Add(GetColumnDefinitionDirect(1, System.Windows.GridUnitType.Star));
            }
            else
            {
                grid.RowDefinitions.Add(GetRowDefinitionDirect(1, System.Windows.GridUnitType.Star));
            }
        }

    }
}