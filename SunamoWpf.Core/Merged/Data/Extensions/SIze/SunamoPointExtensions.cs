namespace SunamoWpf.Extensions.SIze;

public static class SunamoPointExtensions
{
    public static System.Windows.Point ToSystemWindows(this SunamoPoint point)
    {
        return new System.Windows.Point(point.X, point.Y);
    }
}