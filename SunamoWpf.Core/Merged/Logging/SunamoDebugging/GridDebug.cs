namespace SunamoWpf.SunamoDebugging;

/// <summary>
/// Represents the grid debug type.
/// </summary>
public class GridDebug
{
    /// <summary>
    /// Print actual height of row definitions.
    /// </summary>
    /// <param name="grid">The grid.</param>
    public static void PrintActualHeightOfRowDefinitions(Grid grid)
    {
        foreach (var item in grid.RowDefinitions)
        {
            d("rd ActualHeight: " + item.ActualHeight);
        }
    }

    /// <summary>
    /// Print actual width of column definitions.
    /// </summary>
    /// <param name="grid">The grid.</param>
    public static void PrintActualWidthOfColumnDefinitions(Grid grid)
    {
        foreach (var item in grid.ColumnDefinitions)
        {
            d("rd ActualHeight: " + item.ActualWidth);
        }
    }

    /// <summary>
    /// Print rows and columns of all childrens.
    /// </summary>
    /// <param name="grid">The grid.</param>
    public static void PrintRowsAndColumnsOfAllChildrens(Grid grid)
    {
        foreach (FrameworkElement item in grid.Children)
        {
            d(item.Name + ": " + Grid.GetRow(item) + ", " + Grid.GetColumn(item));
        }
    }

    static void d(string text)
    {
        Debug.WriteLine(text);
    }
}