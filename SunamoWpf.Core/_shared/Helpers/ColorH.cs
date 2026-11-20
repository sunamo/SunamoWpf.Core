namespace SunamoWpf._shared.Helpers;

/// <summary>
/// Is shared between apps ColorH and shared's ColorH 
/// </summary>
public partial class ColorH
{


    /// <summary>
    /// Is color same.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="pxsi">The pxsi.</param>
    /// <returns>The is color same result.</returns>
    public static bool IsColorSame(PixelColorWpf first, PixelColorWpf pxsi)
    {
        return first.Red == pxsi.Red && first.Green == pxsi.Green && first.Blue == pxsi.Blue;
    }
}