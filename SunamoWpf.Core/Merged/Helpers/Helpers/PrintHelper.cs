#define ASYNC
namespace SunamoWpf.Helpers;

public enum FormatOfPaper
{
    A,
    B,
    C
}
public enum LengthUnit
{
    Mm,
    In
}
public class PrintHelper
{
    public static Size GetPixelSizeForPaper(int dpiXPrinter, int dpiYPrinter, FormatOfPaper formatOfPaper, int size, LandscapePortraitWpf landscapePortrait)
    {
        Size sizeInOfPaper = SizeOfPaper.GetPaperSize(formatOfPaper.ToString() + size, LengthUnit.In, landscapePortrait);
        sizeInOfPaper = SizeH.Multiply(sizeInOfPaper, dpiXPrinter, dpiYPrinter);
        return SizeH.Divide(sizeInOfPaper, 2);
    }
}
public static class SizeOfPaper
{
    const double mmInInch = 25.4d;
    /// <summary>
    /// V režimu Portrait pouze
    /// </summary>
    static Dictionary<string, Size> papersInMm = new Dictionary<string, Size>();
    static SizeOfPaper()
    {
        papersInMm.Add("A4", new Size(210, 297));
    }
    static Type type = typeof(PrintHelper);
    public static Size GetPaperSize(string paperName, LengthUnit lengthUnit, LandscapePortraitWpf landscapePortrait)
    {
        if (papersInMm.ContainsKey(paperName))
        {
            Size result = papersInMm[paperName];
            if (landscapePortrait == LandscapePortraitWpf.Landscape)
            {
                result = new Size(result.Height, result.Width);
            }
            if (lengthUnit == LengthUnit.Mm)
            {
                return result;
            }
            else if (lengthUnit == LengthUnit.In)
            {
                return SizeH.Divide(result, mmInInch);
            }
        }
        else
        {
        }
        ThrowEx.Custom(Translate.FromKey(XlfKeys.NISizeOfPaperGetPaperSize) + "()");
        return Size.Empty;
    }
}