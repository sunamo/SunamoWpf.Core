#define ASYNC
namespace SunamoWpf.Helpers;

/// <summary>
/// Represents the format of paper type.
/// </summary>
public enum FormatOfPaper
{
    /// <summary>
    /// The a value.
    /// </summary>
    A,
    /// <summary>
    /// The b value.
    /// </summary>
    B,
    /// <summary>
    /// The c value.
    /// </summary>
    C
}
/// <summary>
/// Represents the length unit type.
/// </summary>
public enum LengthUnit
{
    /// <summary>
    /// The mm value.
    /// </summary>
    Mm,
    /// <summary>
    /// The in value.
    /// </summary>
    In
}
/// <summary>
/// Represents the print helper type.
/// </summary>
public class PrintHelper
{
    /// <summary>
    /// Get pixel size for paper.
    /// </summary>
    /// <param name="dpiXPrinter">The dpi x printer.</param>
    /// <param name="dpiYPrinter">The dpi y printer.</param>
    /// <param name="formatOfPaper">The format of paper.</param>
    /// <param name="size">The size.</param>
    /// <param name="landscapePortrait">The landscape portrait.</param>
    /// <returns>The get pixel size for paper result.</returns>
    public static Size GetPixelSizeForPaper(int dpiXPrinter, int dpiYPrinter, FormatOfPaper formatOfPaper, int size, LandscapePortraitWpf landscapePortrait)
    {
        Size sizeInOfPaper = SizeOfPaper.GetPaperSize(formatOfPaper.ToString() + size, LengthUnit.In, landscapePortrait);
        sizeInOfPaper = SizeH.Multiply(sizeInOfPaper, dpiXPrinter, dpiYPrinter);
        return SizeH.Divide(sizeInOfPaper, 2);
    }
}
/// <summary>
/// Represents the size of paper type.
/// </summary>
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
    /// <summary>
    /// Get paper size.
    /// </summary>
    /// <param name="paperName">The paper name.</param>
    /// <param name="lengthUnit">The length unit.</param>
    /// <param name="landscapePortrait">The landscape portrait.</param>
    /// <returns>The get paper size result.</returns>
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
        ThrowEx.Custom("NI size of paper get paper size" + "()");
        return Size.Empty;
    }
}