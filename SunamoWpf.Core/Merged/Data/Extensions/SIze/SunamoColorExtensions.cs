namespace SunamoWpf.Extensions.SIze;

/// <summary>
/// 
/// </summary>
public static class SunamoColorExtensions
{
    /// <summary>
    /// To system drawing.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <returns>The to system drawing result.</returns>
    public static System.Drawing.Color ToSystemDrawing(this SunamoColor color)
    {
        System.Drawing.Color result = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        return result;
    }

    /// <summary>
    /// To system windows media.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <returns>The to system windows media result.</returns>
    public static System.Windows.Media.Color ToSystemWindowsMedia(this SunamoColor color)
    {
        var result = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        return result;
    }
}