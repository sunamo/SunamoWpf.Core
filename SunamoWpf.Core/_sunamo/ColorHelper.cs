namespace SunamoWpf._sunamo;

internal class ColorHelper
{
    internal static Color GetColorFromBytes(byte r, byte g, byte b)
    {
        //System.Drawing.Color c = new System.Drawing.Color();
        return Color.FromArgb(0, r, g, b);
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

    internal static bool IsColorSimilar(Color a, Color b, int threshold = 50)
    {
        int r = a.R - b.R;
        int g = a.G - b.G;
        int b2 = a.B - b.B;
        return r * r + g * g + b2 * b2 <= threshold * threshold;
    }

    internal static bool IsColorSimilar(PixelColorWpf a, PixelColorWpf b, int threshold = 50)
    {
        int r = a.Red - b.Red;
        int g = a.Green - b.Green;
        int b2 = a.Blue - b.Blue;
        return r * r + g * g + b2 * b2 <= threshold * threshold;
    }

    internal static bool IsColorSame(PixelColorWpf first, PixelColorWpf pxsi)
    {
        return first.Red == pxsi.Red && first.Green == pxsi.Green && first.Blue == pxsi.Blue;
    }


}