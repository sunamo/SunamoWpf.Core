namespace SunamoWpf._shared.Helpers;

public partial class ColorH
{
    /// <summary>
    /// Get opaque color.
    /// </summary>
    /// <param name="red">The red.</param>
    /// <param name="green">The green.</param>
    /// <param name="blue">The blue.</param>
    /// <returns>The get opaque color result.</returns>
    public static Color GetOpaqueColor(byte red, byte green, byte blue)
    {
        Color color = new Color();
        color.A = 255;
        color.R = red;
        color.G = green;
        color.B = blue;
        return color;
    }

    /// <summary>
    /// Random color.
    /// </summary>
    /// <param name="dark">The dark.</param>
    /// <returns>The random color result.</returns>
    public static Color RandomColor(bool dark)
    {
        return GetOpaqueColor(RandomHelper.RandomColorPart(dark), RandomHelper.RandomColorPart(dark), RandomHelper.RandomColorPart(dark));
    }


}