namespace SunamoWpf.Core._sunamo;

internal static class StringHexWindowsMediaColorConverter //: ISimpleConverter<string, Color>
{
    public static string ConvertTo(Color color)
    {
        return SHFormat.Format4("#{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
    }
    public static Color ConvertFrom(string hex)
    {
        Color color = new Color();
        hex = hex.TrimStart('#');
        if (hex.Length == 8)
        {
            color.A = GetGroup(0, hex);
            color.R = GetGroup(1, hex);
            color.G = GetGroup(2, hex);
            color.B = GetGroup(3, hex);
        }
        else if (hex.Length == 6)
        {
            color.A = 255;
            color.R = GetGroup(0, hex);
            color.G = GetGroup(1, hex);
            color.B = GetGroup(2, hex);
        }
        else
        {
            return Colors.Black;
        }
        return color;
    }
    private static byte GetGroup(int groupIndex, string hex)
    {
        string result = "";
        if (groupIndex == 0)
        {
            result = hex[0].ToString() + hex[1].ToString();
        }
        else if (groupIndex == 1)
        {
            result = hex[2].ToString() + hex[3].ToString();
        }
        else if (groupIndex == 2)
        {
            result = hex[4].ToString() + hex[5].ToString();
        }
        else
        {
            result = hex[6].ToString() + hex[7].ToString();
        }
        return Convert.ToByte(result, 16);
    }
}
