#define ASYNC
namespace SunamoWpf;

/// <summary>
/// Represents the font helper type.
/// </summary>
public class FontHelper
{
    /// <summary>
    /// Divide string to rows.
    /// </summary>
    /// <param name="fontFamily">The font family.</param>
    /// <param name="fontSize">The font size.</param>
    /// <param name="fontStyle">The font style.</param>
    /// <param name="fontStretch">The font stretch.</param>
    /// <param name="fontWeight">The font weight.</param>
    /// <param name="text">The text.</param>
    /// <param name="maxSize">The max size.</param>
    /// <returns>The divide string to rows result.</returns>
    public static List<string> DivideStringToRows(FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, System.Windows.FontWeight fontWeight, string text, Size maxSize)
    {
        FontArgs fontArgs = new FontArgs(fontFamily, fontSize, fontStyle, fontStretch, fontWeight);
        List<string> rows = SHWithControls.DivideStringToRowsList(fontFamily, fontSize, fontStyle, fontStretch, fontWeight, text, maxSize);
        return rows;
    }
}