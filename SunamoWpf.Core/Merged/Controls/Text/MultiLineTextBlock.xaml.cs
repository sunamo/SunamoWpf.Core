#define ASYNC
namespace SunamoWpf.Controls;


public partial class MultiLineTextBlock : UserControl
{
    /// <summary>
    /// Initializes a new instance of the multi line text block class.
    /// </summary>
    public MultiLineTextBlock()
    {
        try
        {
            InitializeComponent();
        }
        catch (Exception)
        {
#if DEBUG
            Debugger.Break();
#endif
        }


    }

    /// <summary>
    /// Add lines.
    /// </summary>
    /// <param name="background">The background.</param>
    /// <param name="foreground">The foreground.</param>
    /// <param name="lines">The lines.</param>
    public void AddLines(Brush background, Brush foreground, params string[] lines)
    {
        foreach (var item in lines)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
            textBlock.Background = background;
            textBlock.Foreground = foreground;
            textBlock.Text = item;
            spLines.Children.Add(textBlock);
        }
    }
}
