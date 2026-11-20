namespace SunamoWpf.Extensions.SIze;

/// <summary>
/// Represents the sunamo size extensions type.
/// </summary>
public static partial class SunamoSizeExtensions
{
    /// <summary>
    /// To system drawing.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <returns>The to system drawing result.</returns>
    public static System.Drawing.Size ToSystemDrawing(this SunamoSize size)
    {
        return new System.Drawing.Size((int)size.Width, (int)size.Height);
    }
}