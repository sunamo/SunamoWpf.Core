namespace SunamoWpf.Core._sunamo;

[System.Runtime.Versioning.SupportedOSPlatform("windows")]
internal static class SystemWindowsMediaSolidColorBrushExtensions
{
    public static System.Drawing.Brush ToSystemDrawing(this System.Windows.Media.SolidColorBrush brush)
    {
        var color = brush.Color;
        return new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B));
    }
}
