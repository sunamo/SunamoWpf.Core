namespace SunamoWpf.SunamoDebugging;

public class GridDebug
{
    public static void PrintActualHeightOfRowDefinitions(Grid grid)
    {
        foreach (var item in grid.RowDefinitions)
        {
            d("rd ActualHeight: " + item.ActualHeight);
        }
    }

    public static void PrintActualWidthOfColumnDefinitions(Grid grid)
    {
        foreach (var item in grid.ColumnDefinitions)
        {
            d("rd ActualHeight: " + item.ActualWidth);
        }
    }

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