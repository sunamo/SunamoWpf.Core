#define ASYNC
namespace SunamoWpf;

public class FontHelper
{
    public static List<string> DivideStringToRows(FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, System.Windows.FontWeight fontWeight, string text, Size maxSize)
    {
        FontArgs fontArgs = new FontArgs(fontFamily, fontSize, fontStyle, fontStretch, fontWeight);
        List<string> rows = SHWithControls.DivideStringToRowsList(fontFamily, fontSize, fontStyle, fontStretch, fontWeight, text, maxSize);
        return rows;
    }
}