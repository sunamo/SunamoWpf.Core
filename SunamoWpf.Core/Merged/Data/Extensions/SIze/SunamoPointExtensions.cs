namespace SunamoWpf.Extensions.SIze;

public static class SunamoPointExtensions
{
    public static System.Windows.Point ToSystemWindows(this SunamoPoint ss)
    {
        return new System.Windows.Point(ss.X, ss.Y);
    }
}