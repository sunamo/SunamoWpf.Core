namespace SunamoWpf._shared.Helpers;

public partial class ColorH
{
    public static Color GetOpaqueColor(byte red, byte green, byte blue)
    {
        Color color = new Color();
        color.A = 255;
        color.R = red;
        color.G = green;
        color.B = blue;
        return color;
    }

    public static Color RandomColor(bool dark)
    {
        return GetOpaqueColor(RandomHelper.RandomColorPart(dark), RandomHelper.RandomColorPart(dark), RandomHelper.RandomColorPart(dark));
    }


}