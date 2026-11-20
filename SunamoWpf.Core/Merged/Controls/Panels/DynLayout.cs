#define ASYNC
namespace SunamoWpf.Controls.Panels;

/// <summary>
/// Represents the dyn layout type.
/// </summary>
public class DynLayout
{
    Grid gridGrowable = null;

    /// <summary>
    /// Initializes a new instance of the dyn layout class.
    /// </summary>
    /// <param name="grid">The grid.</param>
    public DynLayout(Grid grid)
    {
        gridGrowable = grid;
    }

    /// <summary>
    /// The fw elements.
    /// </summary>
    public List<FrameworkElement> fwElements = new List<FrameworkElement>();

    /// <summary>
    /// Get content by tag.
    /// </summary>
    /// <param name="tag">The tag.</param>
    /// <returns>The get content by tag result.</returns>
    public object GetContentByTag(object tag)
    {
        foreach (var item in fwElements)
        {
            if (item.Tag == tag)
            {
                return item.GetContent();
            }
        }
        return null;
    }

    /// <summary>
    /// The this int.
    /// </summary>
    public object this[int index]
    {
        get
        {
            return fwElements[index].GetContent();
        }
    }

    Thickness uit = new Thickness(10, 5, 10, 5);

    /// <summary>
    /// Example and best case use is in Wpf.Tests
    /// </summary>
    /// <param name="row"></param>
    /// <param name="name"></param>
    /// <param name="control"></param>
    public void AddControl(int row, string name, FrameworkElement control)
    {
        Grid.SetRow(control, row);
        Grid.SetColumn(control, 1);
        // Horizontal alignment cant be set here - otherwise won't be horizontally stretched
        //ui.HorizontalAlignment = HorizontalAlignment.Left;
        control.Margin = uit;
        // double.NaN to fill all available width
        // HorizontalAligment have no effect
        control.Width = double.NaN;
        gridGrowable.Children.Add(control);

        if (name != null)
        {
            AddLabel(row, name);
        }

        fwElements.Add(control);
    }

    /// <summary>
    /// Add label.
    /// </summary>
    /// <param name="row">The row.</param>
    /// <param name="name">The name.</param>
    public void AddLabel(int row, string name)
    {
        var textBlock = TextBlockHelper.Get(new ControlInitData { text = name });

        AddLabel(row, textBlock);
    }

    /// <summary>
    /// Add label.
    /// </summary>
    /// <param name="row">The row.</param>
    /// <param name="label">The label.</param>
    public void AddLabel(int row, UIElement label)
    {
        if (label is TextBlock)
        {
            var tbb = (TextBlock)label;
            tbb.HorizontalAlignment = HorizontalAlignment.Right;
            tbb.VerticalAlignment = VerticalAlignment.Center;
            tbb.Margin = uit;
        }

        Grid.SetRow(label, row);
        Grid.SetColumn(label, 0);
        gridGrowable.Children.Add(label);
    }
}