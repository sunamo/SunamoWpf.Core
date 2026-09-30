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

    public void AddLines(Brush bg, Brush fg, params string[] lines)
    {
        foreach (var item in lines)
        {
            TextBlock tb = new TextBlock();
            tb.HorizontalAlignment = HorizontalAlignment.Stretch;
            tb.Background = bg;
            tb.Foreground = fg;
            tb.Text = item;
            spLines.Children.Add(tb);
        }
    }
}
