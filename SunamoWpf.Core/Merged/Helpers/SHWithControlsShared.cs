#define ASYNC
namespace SunamoWpf;

public static partial class SHWithControls
{
    static TextBlock tb = new TextBlock();

    /// <summary>
    /// Measure string.
    /// </summary>
    /// <param name="fontFamily">The font family.</param>
    /// <param name="fontSize">The font size.</param>
    /// <param name="fontStyle">The font style.</param>
    /// <param name="fontStretch">The font stretch.</param>
    /// <param name="fontWeight">The font weight.</param>
    /// <param name="text">The text.</param>
    /// <param name="maxSize">The max size.</param>
    /// <returns>The measure string result.</returns>
    public static double MeasureString(FontFamily fontFamily, double fontSize, System.Windows.FontStyle fontStyle, FontStretch fontStretch, System.Windows.FontWeight fontWeight, string text, Size maxSize)
    {
        //tb.Height = Double.PositiveInfinity;
        tb.FontFamily = fontFamily;
        tb.FontSize = fontSize;
        tb.FontStyle = fontStyle;
        tb.FontStretch = fontStretch;
        tb.FontWeight = fontWeight;
        tb.Text = text;
        tb.Measure(maxSize);
        //tb.Arrange(new Rect(new Point(0, 0), maxSize));
        return tb.DesiredSize.Width;
    }

    /// <summary>
    /// Measure string.
    /// </summary>
    /// <param name="formattedText">The formatted text.</param>
    /// <returns>The measure string result.</returns>
    public static object MeasureString(FormattedText formattedText)
    {
        //tb.FontFamily = fontFamily;
        //tb.FontSize = f.;
        tb.FontStyle = FontStyles.Normal;
        //tb.FontStretch = FontStretch;
        tb.FontWeight = System.Windows.FontWeights.Normal;
        tb.Text = formattedText.Text;
        tb.Measure(ControlHelper.SizePositiveInfinity);
        //tb.Arrange(new Rect(new Point(0, 0), maxSize));
        return tb.DesiredSize.Width;
    }
}