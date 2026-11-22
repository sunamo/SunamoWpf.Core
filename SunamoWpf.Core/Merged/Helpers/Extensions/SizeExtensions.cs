#define ASYNC
namespace SunamoWpf.Extensions;

/// <summary>
/// Represents the size extensions type.
/// </summary>
public static class SizeExtensions
{
    /// <summary>
    /// Recalculate size with scale factor.
    /// </summary>
    /// <param name="unscaledSize">The unscaled size.</param>
    /// <returns>The recalculate size with scale factor result.</returns>
    public static Size RecalculateSizeWithScaleFactor(this Size unscaledSize)
    {
        var scaleFactor = DisplayHelper.GetScaleFactor();
        var size = new Size(unscaledSize.Width / scaleFactor, unscaledSize.Height / scaleFactor);
        return size;
    }


}