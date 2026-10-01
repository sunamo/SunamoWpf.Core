namespace SunamoWpf.Extensions.SIze;

/// <summary>
/// 
/// </summary>
public static class SunamoColorExtensions
{
    public static System.Drawing.Color ToSystemDrawing(this SunamoColor c)
    {
        System.Drawing.Color r = System.Drawing.Color.FromArgb(c.A, c.R, c.G, c.B);
        return r;
    }

    public static System.Windows.Media.Color ToSystemWindowsMedia(this SunamoColor c)
    {
        var r = System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
        return r;
    }
}