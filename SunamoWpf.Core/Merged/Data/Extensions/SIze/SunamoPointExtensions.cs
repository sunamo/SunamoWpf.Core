namespace SunamoWpf.Extensions.SIze;

/// <summary>
/// Represents the sunamo point extensions type.
/// </summary>
public static class SunamoPointExtensions
{
    /// <summary>
    /// To system windows.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <returns>The to system windows result.</returns>
    public static System.Windows.Point ToSystemWindows(this SunamoPoint point)
    {
        return new System.Windows.Point(point.X, point.Y);
    }
}