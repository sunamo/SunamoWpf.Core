#define ASYNC
namespace SunamoWpf.Controls;


public partial class MultiLineTextBlock : UserControl
{
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
