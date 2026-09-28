namespace SunamoWpf._sunamo;

/// <summary>
/// Method which takes System.Drawing.Color
/// </summary>
internal class DrawingColorHelper
{
    internal static PixelColorWpf PixelColorFromDrawingColor(System.Drawing.Color color, byte? alpha)
    {
        if (alpha == null)
        {
            alpha = color.A;
        }
        PixelColorWpf white2 = new PixelColorWpf() { Alpha = alpha.Value, Red = color.R, Green = color.G, Blue = color.B };
        return white2;
    }
}