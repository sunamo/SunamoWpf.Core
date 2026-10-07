namespace SunamoWpf.Extensions.SIze;

/// <summary>
/// 
/// </summary>
public static class SunamoColorExtensions
{
    public static System.Drawing.Color ToSystemDrawing(this SunamoColor color)
    {
        System.Drawing.Color result = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        return result;
    }

    public static System.Windows.Media.Color ToSystemWindowsMedia(this SunamoColor color)
    {
        var result = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        return result;
    }
}