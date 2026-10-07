#define ASYNC
namespace SunamoWpf.Helpers.ContainerControls;

public partial class GridHelper
{
    public static Grid GetAutoSize(int columns, int rows)
    {
        Grid grid = new Grid();
        GetAutoSize(grid, columns, rows);
        return grid;
    }
    /// <summary>
    /// Assign to every cell GridLength.Auto
    /// </summary>
    /// <param name = "grid"></param>
    /// <param name = "columns"></param>
    /// <param name = "rows"></param>
    public static void GetAutoSize(Grid grid, int columns, int rows)
    {
        for (int index = 0; index < columns; index++)
        {
            grid.ColumnDefinitions.Add(GetColumnDefinition(GridLength.Auto));
        }

        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            grid.RowDefinitions.Add(GetRowDefinition(GridLength.Auto));
        }
    }

    public static ColumnDefinition GetColumnDefinition(GridLength oneC)
    {
        ColumnDefinition columnDefinition = new ColumnDefinition();
        columnDefinition.Width = oneC;
        return columnDefinition;
    }

    public static ColumnDefinition GetColumnDefinitionDirect(double pixels)
    {
        ColumnDefinition columnDefinition = new ColumnDefinition();
        columnDefinition.Width = new GridLength(pixels);
        return columnDefinition;
    }

    public static ColumnDefinition GetColumnDefinitionDirect(double value, GridUnitType type)
    {
        ColumnDefinition columnDefinition = new ColumnDefinition();
        columnDefinition.Width = new GridLength(value, type);
        return columnDefinition;
    }

    /// <summary>
    /// With auto and star must be alwys value 1. When will be 0, no controls will be show!!!
    /// </summary>
    /// <param name="auto"></param>
    public static RowDefinition GetRowDefinition(GridLength auto)
    {
        RowDefinition rowDefinition = new RowDefinition();
        rowDefinition.Height = auto;
        return rowDefinition;
    }

    public static RowDefinition GetRowDefinitionDirect(double pixels)
    {
        RowDefinition rowDefinition = new RowDefinition();
        rowDefinition.Height = new GridLength(pixels);
        return rowDefinition;
    }

    public static RowDefinition GetRowDefinitionDirect(double value, GridUnitType type)
    {
        RowDefinition rowDefinition = new RowDefinition();
        rowDefinition.Height = new GridLength(value, type);
        return rowDefinition;
    }

    /// <summary>
    /// Will increment A3 due to top
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="row"></param>
    /// <param name="index"></param>
    public static IList<T> GetControlsFrom<T>(Grid grid, bool row, int index) where T : UIElement
    {
        index++;

        IList<UIElement> uiElements = null;
        if (row)
        {

            uiElements = grid.Children.Cast<UIElement>().Where(element => Grid.GetRow(element) == index).ToList();
        }
        else
        {
            uiElements = grid.Children.Cast<UIElement>().Where(child => Grid.GetColumn(child) == index).ToList();
        }

        List<T> result = new List<T>();

        foreach (var item in uiElements)
        {
            //var v = ControlFinder.FindControlExclude<UIElement>(item);
            result.Add((T)item);
        }

        return result;
    }
}