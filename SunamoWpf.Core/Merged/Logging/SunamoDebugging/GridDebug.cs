namespace SunamoWpf.SunamoDebugging;

public class GridDebug
{
    public static void PrintActualHeightOfRowDefinitions(Grid g)
    {
        foreach (var item in g.RowDefinitions)
        {
            d("rd ActualHeight: " + item.ActualHeight);
        }
    }

    public static void PrintActualWidthOfColumnDefinitions(Grid g)
    {
        foreach (var item in g.ColumnDefinitions)
        {
            d("rd ActualHeight: " + item.ActualWidth);
        }
    }

    public static void PrintRowsAndColumnsOfAllChildrens(Grid g)
    {
        foreach (FrameworkElement item in g.Children)
        {
            d(item.Name + ": " + Grid.GetRow(item) + ", " + Grid.GetColumn(item));
        }
    }

    static void d(string s)
    {
        Debug.WriteLine(s);
    }
}