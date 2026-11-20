namespace SunamoWpf._shared.Helpers;

public partial class ColorH
{
    #region For easy copy
    static Type type = typeof(ColorH);
    /// <summary>
    /// Pixel color from color.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="alpha">The alpha.</param>
    /// <returns>The pixel color from color result.</returns>
    public static PixelColorWpf PixelColorFromColor(Color color, byte? alpha)
    {
        if (alpha == null)
        {
            alpha = color.A;
        }
        PixelColorWpf white2 = new PixelColorWpf() { Alpha = alpha.Value, Red = color.R, Green = color.G, Blue = color.B };
        return white2;
    }
    /// <summary>
    /// Random light brush.
    /// </summary>
    /// <param name="shade">The shade.</param>
    /// <returns>The random light brush result.</returns>
    public static SolidColorBrush RandomLightBrush(ColorComponent shade)
    {
        byte red = 0;
        byte green = 0;
        byte blue = 0;
        switch (shade)
        {
            case ColorComponent.Red:
                red = 255;
                green = blue = RandomHelper.RandomByte(200, 250);
                break;
            case ColorComponent.Green:
                green = 255;
                green = red = RandomHelper.RandomByte(200, 250);
                break;
            case ColorComponent.Blue:
                blue = 255;
                green = red = RandomHelper.RandomByte(200, 250);
                break;
            case ColorComponent.None:
            default:
                red = green = blue = 255;
                break;
        }
        return new SolidColorBrush(GetColorWithAlpha(red, green, blue, 150));
    }
    /// <summary>
    /// Random brush.
    /// </summary>
    /// <param name="light">The light.</param>
    /// <param name="into">The into.</param>
    /// <returns>The random brush result.</returns>
    public static SolidColorBrush RandomBrush(bool light, ColorComponent into)
    {
        byte red = RandomHelper.RandomColorPart(light, 0);
        byte green = RandomHelper.RandomColorPart(light, 0);
        byte blue = RandomHelper.RandomColorPart(light, 0);
        switch (into)
        {
            case ColorComponent.Red:
                red += 127;
                break;
            case ColorComponent.Green:
                green += 127;
                break;
            case ColorComponent.Blue:
                blue += 127;
                break;
            case ColorComponent.None:
                red += 127;
                green += 127;
                blue += 127;
                break;
            default:
                ThrowEx.Custom("Not implemented case in color helper apps random brush");
                return Brushes.Black;
        }
        return new SolidColorBrush(GetOpaqueColor(red, green, blue));
    }
    /// <summary>
    /// Get color with alpha.
    /// </summary>
    /// <param name="red">The red.</param>
    /// <param name="green">The green.</param>
    /// <param name="blue">The blue.</param>
    /// <param name="alpha">The alpha.</param>
    /// <returns>The get color with alpha result.</returns>
    public static Color GetColorWithAlpha(byte red, byte green, byte blue, byte alpha)
    {
        Color white2 = new Color { A = alpha, R = red, G = green, B = blue };
        return white2;
    }
    /// <summary>
    /// Get color with alpha.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="alpha">The alpha.</param>
    /// <returns>The get color with alpha result.</returns>
    public static Color GetColorWithAlpha(Color color, byte? alpha)
    {
        if (alpha == null)
        {
            alpha = color.A;
        }
        Color white2 = new Color { A = alpha.Value, R = color.R, G = color.G, B = color.B };
        return white2;
    }
    /// <summary>
    /// Is color same.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="pxsi">The pxsi.</param>
    /// <returns>The is color same result.</returns>
    public static bool IsColorSame(Color first, Color pxsi)
    {
        return first.R == pxsi.R && first.G == pxsi.G && first.B == pxsi.B;
    }
#if DEBUG
    /// <summary>
    /// Debug write.
    /// </summary>
    /// <param name="c">The c.</param>
    public static void DebugWrite(Color c)
    {
        Debug.WriteLine("A: " + c.A + " R: " + c.R + " G: " + c.G + " : " + c.B);
    }
#endif
    #endregion
}