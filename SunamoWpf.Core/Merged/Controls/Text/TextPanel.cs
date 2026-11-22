#define ASYNC
namespace SunamoWpf.Controls.Text;

/// <summary>
/// Represents the text panel type.
/// </summary>
public class TextPanel : StackPanel
{
    /// <summary>
    /// The font family.
    /// </summary>
    public FontFamily fontFamily = new FontFamily("SegoeUI");
    /// <summary>
    /// The font size.
    /// </summary>
    public double fontSize = 12;
    /// <summary>
    /// The font style.
    /// </summary>
    public FontStyle fontStyle = FontStyles.Normal;
    /// <summary>
    /// Hodnota mezi 1-9, průměrná je 5
    /// </summary>
    public FontStretch fontStretch = FontStretch.FromOpenTypeStretch(5);
    /// <summary>
    /// The font weight.
    /// </summary>
    public FontWeight fontWeight = FontWeight.FromOpenTypeWeight(500);

    /// <summary>
    /// Initializes a new instance of the text panel class.
    /// </summary>
    public TextPanel()
    {
        Orientation = Orientation.Vertical;

    }

    /// <summary>
    /// H 1.
    /// </summary>
    /// <param name="text">The text.</param>
    public void H1(string text)
    {
        List<string> rows = FontHelper.DivideStringToRows(fontFamily, 50, FontStyles.Normal, fontStretch, FontWeight.FromOpenTypeWeight(601), text, new Size(ActualWidth, ActualHeight));
        foreach (var item in rows)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.FontFamily = fontFamily;
            textBlock.FontSize = 50;
            textBlock.FontStyle = FontStyles.Normal;
            textBlock.FontStretch = fontStretch;
            textBlock.FontWeight = FontWeight.FromOpenTypeWeight(601);
            Children.Add(textBlock);
        }
    }
}