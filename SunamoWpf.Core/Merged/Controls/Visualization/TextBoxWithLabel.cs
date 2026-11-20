#define ASYNC
namespace SunamoWpf.Controls.Visualization;

/// <summary>
/// Represents the text box with label type.
/// </summary>
public class TextBoxWithLabel : UserControl
{
    ColumnDefinition cdLabel = null;
    /// <summary>
    /// The lbl.
    /// </summary>
    public Label lbl = new Label();
    /// <summary>
    /// The txt.
    /// </summary>
    public TextBox txt = new TextBox();

    /// <summary>
    /// The px label column.
    /// </summary>
    public double PxLabelColumn
    {
        get => cdLabel.ActualWidth;
        set => cdLabel.Width = new GridLength(value, GridUnitType.Pixel);
    }

    /// <summary>
    /// Initializes a new instance of the text box with label class.
    /// </summary>
    public TextBoxWithLabel()
    {
        Grid grid = new Grid();
        grid.RowDefinitions.Add(GridHelper.GetRowDefinition(GridLength.Auto));

        cdLabel = GridHelper.GetColumnDefinition(GridLength.Auto);
        grid.ColumnDefinitions.Add(cdLabel);
        grid.ColumnDefinitions.Add(GridHelper.GetColumnDefinition(GridLength.Auto));

        grid.Children.Add(lbl);
        grid.Children.Add(txt);
        Grid.SetColumn(txt, 1);

        Content = grid;
    }
}