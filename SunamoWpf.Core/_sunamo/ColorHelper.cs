namespace SunamoWpf.Core._sunamo;

internal class ColorHelper
{
    internal static Color GetColorFromBytes(byte red, byte green, byte blue)
    {
        //System.Drawing.Color c = new System.Drawing.Color();
        return Color.FromArgb(0, red, green, blue);
    }

    internal static string RandomColorHex(bool light)
    {
        throw new Exception("StringHexColorConverter not in net core");
        //int r = RandomHelper.RandomColorPart(light);
        //int g = RandomHelper.RandomColorPart(light);
        //int b = RandomHelper.RandomColorPart(light);
        //return StringHexColorConverter.ConvertToWoAlpha(r, g, b);
    }

    internal static object FromRgb(byte current_R, byte current_G, byte current_B)
    {
        return Color.FromArgb(0, current_R, current_G, current_B);
    }

    internal static bool IsColorSimilar(Color first, Color second, int threshold = 50)
    {
        int redDifference = first.R - second.R;
        int greenDifference = first.G - second.G;
        int blueDifference = first.B - second.B;
        return redDifference * redDifference + greenDifference * greenDifference + blueDifference * blueDifference <= threshold * threshold;
    }

    internal static bool IsColorSimilar(PixelColorWpf first, PixelColorWpf second, int threshold = 50)
    {
        int redDifference = first.Red - second.Red;
        int greenDifference = first.Green - second.Green;
        int blueDifference = first.Blue - second.Blue;
        return redDifference * redDifference + greenDifference * greenDifference + blueDifference * blueDifference <= threshold * threshold;
    }

    internal static bool IsColorSame(PixelColorWpf first, PixelColorWpf pxsi)
    {
        return first.Red == pxsi.Red && first.Green == pxsi.Green && first.Blue == pxsi.Blue;
    }


}