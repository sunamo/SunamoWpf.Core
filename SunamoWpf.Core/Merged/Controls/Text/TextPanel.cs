#define ASYNC
namespace SunamoWpf.Controls.Text;

public class TextPanel : StackPanel
{
    public FontFamily fontFamily = new FontFamily(Translate.FromKey(XlfKeys.SegoeUI));
    public double fontSize = 12;
    public FontStyle fontStyle = FontStyles.Normal;
    /// <summary>
    /// Hodnota mezi 1-9, průměrná je 5
    /// </summary>
    public FontStretch fontStretch = FontStretch.FromOpenTypeStretch(5);
    public FontWeight fontWeight = FontWeight.FromOpenTypeWeight(500);

    public TextPanel()
    {
        Orientation = Orientation.Vertical;

    }

    public void H1(string text)
    {
        List<string> dd = FontHelper.DivideStringToRows(fontFamily, 50, FontStyles.Normal, fontStretch, FontWeight.FromOpenTypeWeight(601), text, new Size(ActualWidth, ActualHeight));
        foreach (var item in dd)
        {
            TextBlock tb = new TextBlock();
            tb.FontFamily = fontFamily;
            tb.FontSize = 50;
            tb.FontStyle = FontStyles.Normal;
            tb.FontStretch = fontStretch;
            tb.FontWeight = FontWeight.FromOpenTypeWeight(601);
            Children.Add(tb);
        }
    }
}