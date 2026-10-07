#define ASYNC
namespace SunamoWpf.Controls.Visualization;

public class TextBoxWithLabel : UserControl
{
    ColumnDefinition cdLabel = null;
    public Label lbl = new Label();
    public TextBox txt = new TextBox();

    public double PxLabelColumn
    {
        get => cdLabel.ActualWidth;
        set => cdLabel.Width = new GridLength(value, GridUnitType.Pixel);
    }

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